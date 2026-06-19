using TMPEffects.Modifiers;
using TMPro;
using UnityEngine;

namespace TMPEffects.CharacterData
{
	public class VertexData
	{
		private TMPMeshModifiers modifiers;

		private TMP_Vertex vertex_BL;

		private TMP_Vertex vertex_TL;

		private TMP_Vertex vertex_TR;

		private TMP_Vertex vertex_BR;

		public readonly ReadOnlyVertexData initial;

		public TMPMeshModifiers Modifiers => null;

		public bool positionsDirty { get; private set; }

		public bool colorsDirty { get; private set; }

		public bool alphasDirty { get; private set; }

		public bool uvsDirty { get; private set; }

		public Color32 BL_Color
		{
			get
			{
				return default(Color32);
			}
			set
			{
			}
		}

		public Color32 TL_Color
		{
			get
			{
				return default(Color32);
			}
			set
			{
			}
		}

		public Color32 TR_Color
		{
			get
			{
				return default(Color32);
			}
			set
			{
			}
		}

		public Color32 BR_Color
		{
			get
			{
				return default(Color32);
			}
			set
			{
			}
		}

		public byte BL_Alpha
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte TL_Alpha
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte TR_Alpha
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public byte BR_Alpha
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Vector3 BL_Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TL_Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TR_Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 BR_Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 BL_UV0
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TL_UV0
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TR_UV0
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 BR_UV0
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 BL_UV2
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TL_UV2
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TR_UV2
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 BR_UV2
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public VertexData(TMP_Vertex bl, TMP_Vertex tl, TMP_Vertex tr, TMP_Vertex br)
		{
		}

		public VertexData(TMP_CharacterInfo info)
		{
		}

		public Vector3 GetPosition(int i)
		{
			return default(Vector3);
		}

		public void SetPosition(int i, Vector3 value)
		{
		}

		public Color32 GetColor(int i)
		{
			return default(Color32);
		}

		public void SetColor(int i, Color32 value, bool ignoreAlpha = false)
		{
		}

		public byte GetAlpha(int i)
		{
			return 0;
		}

		public void SetAlpha(int i, float value)
		{
		}

		public Vector2 GetUV0(int i)
		{
			return default(Vector2);
		}

		public void SetUV0(int i, Vector2 value)
		{
		}

		public Vector2 GetUV2(int i)
		{
			return default(Vector2);
		}

		public void SetUV2(int i, Vector2 value)
		{
		}

		public void Reset()
		{
		}

		public void ResetColors()
		{
		}

		public void ResetAlphas()
		{
		}

		public void ResetPositions()
		{
		}

		public void ResetUVs()
		{
		}
	}
}
