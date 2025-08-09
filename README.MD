throwaway utility for testing various shit

(btw if you have an nvidia gpu, send your results in! just run it and paste the output, we need more data points)

Status update: we got another result back, same as my machine:

TerminateSequenceCommandNV: 0xe0000000 (size: 4)
NopCommandNV: 0x00000000 (size: 4)
DrawElementsCommandNV: 0xa0030e38 (size: 16)
DrawArraysCommandNV: 0xa0020e36 (size: 12)
DrawElementsStripCommandNV: 0xa0030e3c (size: 16)
DrawArraysStripCommandNV: 0xa0020e3a (size: 12)
DrawElementsInstancedCommandNV: 0xa0060e28 (size: 28)
DrawArraysInstancedCommandNV: 0xa0050e26 (size: 24)
ElementAddressCommandNV: 0xa0030e2c (size: 16)
AttributeAddressCommandNV: 0xa0030e40 (size: 16)
UniformAddressCommandNV: 0xa0030e3e (size: 16)
BlendColorCommandNV: 0x200404c7 (size: 20)
StencilRefCommandNV: 0xa0020e34 (size: 12)
LineWidthCommandNV: 0xa0010e2e (size: 8)
PolygonOffsetCommandNV: 0xa0020e30 (size: 12)
AlphaRefCommandNV: 0x200104c4 (size: 8)
ViewportCommandNV: 0xa0040e42 (size: 20)
ScissorCommandNV: 0xa0040e32 (size: 20)
FrontFaceCommandNV: 0xa0010e2a (size: 8)
Hello, World!

Looks like the commands are the same on Turing+ (still need to test on Pascal and Maxwell, and fuck cares about older ones atm)