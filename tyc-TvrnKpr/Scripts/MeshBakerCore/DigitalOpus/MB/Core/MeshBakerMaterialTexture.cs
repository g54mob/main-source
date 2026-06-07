using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MeshBakerMaterialTexture
	{
		private Texture2D _t;

		public float texelDensity;

		internal static bool readyToBuildAtlases;

		private DRect encapsulatingSamplingRect;

		public Texture2D t
		{
			set
			{
			}
		}

		public DRect matTilingRect { get; private set; }

		public int isImportedAsNormalMap { get; private set; }

		public bool isNull => false;

		public int width => 0;

		public int height => 0;

		public MeshBakerMaterialTexture(Texture tx, Vector2 matTilingOffset, Vector2 matTilingScale, float texelDens, int isImportedAsNormalMap)
		{
		}

		public DRect GetEncapsulatingSamplingRect()
		{
			return default(DRect);
		}

		public void SetEncapsulatingSamplingRect(MB_TexSet ts, DRect r)
		{
		}

		public Texture2D GetTexture2D()
		{
			return null;
		}

		public string GetTexName()
		{
			return null;
		}

		public bool AreTexturesEqual(MeshBakerMaterialTexture b)
		{
			return false;
		}
	}
}
