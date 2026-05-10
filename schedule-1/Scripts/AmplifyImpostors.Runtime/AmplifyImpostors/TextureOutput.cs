using System;
using UnityEngine;

namespace AmplifyImpostors
{
	[Serializable]
	public class TextureOutput
	{
		[SerializeField]
		public int Index;

		[SerializeField]
		public OverrideMask OverrideMask;

		public bool Active;

		public string Name;

		public TextureScale Scale;

		public bool SRGB;

		public TextureChannels Channels;

		public TextureCompression Compression;

		public ImageFormat ImageFormat;

		public TextureOutput()
		{
		}

		public TextureOutput(bool a, string n, TextureScale s, bool sr, TextureChannels c, TextureCompression nc, ImageFormat i)
		{
		}

		public TextureOutput Clone()
		{
			return null;
		}
	}
}
