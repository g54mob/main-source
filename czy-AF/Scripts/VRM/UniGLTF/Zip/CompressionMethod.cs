namespace UniGLTF.Zip
{
	internal enum CompressionMethod : ushort
	{
		Stored = 0,
		Shrink = 1,
		Reduced1 = 2,
		Reduced2 = 3,
		Reduced3 = 4,
		Reduced4 = 5,
		Imploded = 6,
		Reserved = 7,
		Deflated = 8
	}
}
