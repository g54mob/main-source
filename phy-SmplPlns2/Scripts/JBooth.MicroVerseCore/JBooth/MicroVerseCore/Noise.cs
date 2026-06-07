using System;
using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	[Serializable]
	public class Noise : ICloneable
	{
		public enum NoiseType
		{
			None = 0,
			Simple = 1,
			FBM = 2,
			Worley = 3,
			Worm = 4,
			WormFBM = 5,
			Texture = 6
		}

		public enum NoiseSpace
		{
			World = 0,
			Stamp = 1
		}

		public NoiseType noiseType;

		public NoiseSpace noiseSpace;

		public float frequency = 10f;

		public float amplitude = 1f;

		public float offset;

		[Range(-0.5f, 0.5f)]
		public float balance;

		public Texture2D texture;

		public Vector4 textureST = new Vector4(0f, 0f, 1f, 1f);

		public FalloffFilter.TextureChannel channel;

		public float displayGamma;

		public Vector4 GetParamVector()
		{
			return new Vector4(frequency, amplitude, offset, balance);
		}

		public Vector4 GetParam2Vector()
		{
			return new Vector4((float)noiseSpace, 0f, 0f, 0f);
		}

		public Vector4 GetTextureParams()
		{
			return textureST;
		}

		public Vector2 GetTextureScale()
		{
			return new Vector2(textureST.x, textureST.y);
		}

		public Vector2 GetTextureOffset()
		{
			return new Vector2(textureST.z, textureST.w);
		}

		private static string KeywordLookup(string key, NoiseType nt)
		{
			return nt switch
			{
				NoiseType.Simple => key + "NOISE", 
				NoiseType.FBM => key + "FBM", 
				NoiseType.Worley => key + "WORLEY", 
				NoiseType.Worm => key + "WORM", 
				NoiseType.WormFBM => key + "WORMFBM", 
				NoiseType.Texture => key + "NOISETEXTURE", 
				_ => "", 
			};
		}

		public void PrepareMaterial(Material mat, string key, string prop, List<string> keywords)
		{
			EnableKeyword(mat, key, keywords);
			mat.SetVector(prop + "Noise", GetParamVector());
			mat.SetVector(prop + "Noise2", GetParam2Vector());
			string name = prop + "NoiseTexture";
			mat.SetTexture(name, texture);
			mat.SetTextureOffset(name, GetTextureOffset());
			mat.SetTextureScale(name, GetTextureScale());
			mat.SetFloat(prop + "NoiseChannel", (float)channel);
		}

		public void EnableKeyword(Material material, string prefix, List<string> keywords)
		{
			if (noiseType != NoiseType.None)
			{
				string item = KeywordLookup(prefix, noiseType);
				keywords.Add(item);
			}
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
