namespace MiscUtil.Compression.Vcdiff
{
	internal enum InstructionType : byte
	{
		NoOp = 0,
		Add = 1,
		Run = 2,
		Copy = 3
	}
}
