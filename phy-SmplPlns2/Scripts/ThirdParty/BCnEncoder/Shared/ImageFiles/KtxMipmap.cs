using System;

namespace BCnEncoder.Shared.ImageFiles
{
	public class KtxMipmap
	{
		public uint SizeInBytes { get; }

		public uint Width { get; }

		public uint Height { get; }

		public uint NumberOfFaces { get; }

		public KtxMipFace[] Faces { get; }

		public KtxMipmap(uint sizeInBytes, uint width, uint height, uint numberOfFaces)
		{
			SizeInBytes = sizeInBytes;
			Width = Math.Max(1u, width);
			Height = Math.Max(1u, height);
			NumberOfFaces = numberOfFaces;
			Faces = new KtxMipFace[numberOfFaces];
		}
	}
}
