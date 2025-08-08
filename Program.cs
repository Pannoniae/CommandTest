// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using Silk.NET.OpenGL.Legacy;
using Silk.NET.OpenGL.Legacy.Extensions.NV;
using Silk.NET.WGL;
using Silk.NET.Windowing;

var window = Window.Create(new WindowOptions() {
    API = GraphicsAPI.Default,
    Size = new Silk.NET.Maths.Vector2D<int>(800, 600),
    Title = "WGL Example"
});

window.Initialize();

var wgl = WGL.GetApi();
var gl = window.CreateLegacyOpenGL();

var b = gl.TryGetExtension(out NVCommandList nv);

gl.Enable(EnableCap.DebugOutput);
//GL.Enable(EnableCap.DebugOutputSynchronous);
gl.DebugMessageCallback(GLDebug, 0);

static void GLDebug(GLEnum _source, GLEnum _type, int id, GLEnum _severity, int length, IntPtr message,
    IntPtr userparam) {
        
    // convert types into something usable (probably a noop)
    var source = (DebugSource)_source;
    var type = (DebugType)_type;
    var severity = (DebugSeverity)_severity;
        
    string msg = Marshal.PtrToStringAnsi(message, length)!;
    Console.Out.WriteLine($"{source} [{type}] [{severity}] ({id}): , {msg}");
    // Dump stacktrace
    //Console.Out.WriteLine(Environment.StackTrace);
        
        
        
    // sort by severity
    if (type == DebugType.DebugTypeError || type == DebugType.DebugTypeOther || type == DebugType.DebugTypePortability) {
        Console.Out.WriteLine(Environment.StackTrace);
    }
}

if (!b) {
    Console.WriteLine("NV_command_list extension not supported.");
    return;
}

List<int> sizes = [1, 1, 4, 3, 4, 3, 7, 6, 4, 4, 4, 5, 3, 2, 3, 2, 5, 5, 2];

// print all tokens
for (CommandOpcodesNV i = 0; i < (CommandOpcodesNV)0x13; i++) {
    var name = i.ToString();
    var size = ((uint)sizes[(int)i]) * sizeof(int);
    var token = nv.GetCommandHeader(i, size);
    Console.Out.WriteLine($"{name}: 0x{token:x8} (size: {size})");
}

Console.WriteLine("Hello, World!");
Console.ReadKey();