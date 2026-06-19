using TMPro;
using UnityEngine;

namespace TMPEffects.CharacterData
{
	public class ReadOnlyVertexData
	{
		private TMP_Vertex vertex_BL;

		private TMP_Vertex vertex_TL;

		private TMP_Vertex vertex_TR;

		private TMP_Vertex vertex_BR;

		public Color32 BL_Color => default(Color32);

		public Color32 TL_Color => default(Color32);

		public Color32 TR_Color => default(Color32);

		public Color32 BR_Color => default(Color32);

		public byte BL_Alpha => 0;

		public byte TL_Alpha => 0;

		public byte TR_Alpha => 0;

		public byte BR_Alpha => 0;

		public Vector3 BL_Position => default(Vector3);

		public Vector3 TL_Position => default(Vector3);

		public Vector3 TR_Position => default(Vector3);

		public Vector3 BR_Position => default(Vector3);

		public Vector3 BL_UV0 => default(Vector3);

		public Vector3 TL_UV0 => default(Vector3);

		public Vector3 TR_UV0 => default(Vector3);

		public Vector3 BR_UV0 => default(Vector3);

		public Vector3 BL_UV2 => default(Vector3);

		public Vector3 TL_UV2 => default(Vector3);

		public Vector3 TR_UV2 => default(Vector3);

		public Vector3 BR_UV2 => default(Vector3);

		public ReadOnlyVertexData(TMP_Vertex bl, TMP_Vertex tl, TMP_Vertex tr, TMP_Vertex br)
		{
		}

		public ReadOnlyVertexData(TMP_CharacterInfo info)
		{
		}

		public Vector3 GetPosition(int i)
		{
			return default(Vector3);
		}

		public Color32 GetColor(int i)
		{
			return default(Color32);
		}

		public byte GetAlpha(int i)
		{
			return 0;
		}

		public Vector2 GetUV0(int i)
		{
			return default(Vector2);
		}

		public Vector2 GetUV2(int i)
		{
			return default(Vector2);
		}
	}
}
