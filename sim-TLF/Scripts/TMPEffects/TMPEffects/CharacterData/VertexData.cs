using System;
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

		public TMPMeshModifiers Modifiers => modifiers;

		public bool positionsDirty { get; private set; }

		public bool colorsDirty { get; private set; }

		public bool alphasDirty { get; private set; }

		public bool uvsDirty { get; private set; }

		public Color32 BL_Color
		{
			get
			{
				return modifiers.BL_Color.GetValue(vertex_BL.color);
			}
			set
			{
				ColorOverride bL_Color = modifiers.BL_Color;
				bL_Color.Override |= ColorOverride.OverrideMode.Color | ColorOverride.OverrideMode.Alpha;
				bL_Color.Color = value;
				modifiers.BL_Color = bL_Color;
				colorsDirty = true;
				alphasDirty = true;
			}
		}

		public Color32 TL_Color
		{
			get
			{
				return modifiers.TL_Color.GetValue(vertex_TL.color);
			}
			set
			{
				ColorOverride tL_Color = modifiers.TL_Color;
				tL_Color.Override |= ColorOverride.OverrideMode.Color | ColorOverride.OverrideMode.Alpha;
				tL_Color.Color = value;
				modifiers.TL_Color = tL_Color;
				colorsDirty = true;
				alphasDirty = true;
			}
		}

		public Color32 TR_Color
		{
			get
			{
				return modifiers.TR_Color.GetValue(vertex_TR.color);
			}
			set
			{
				ColorOverride tR_Color = modifiers.TR_Color;
				tR_Color.Override |= ColorOverride.OverrideMode.Color | ColorOverride.OverrideMode.Alpha;
				tR_Color.Color = value;
				modifiers.TR_Color = tR_Color;
				colorsDirty = true;
				alphasDirty = true;
			}
		}

		public Color32 BR_Color
		{
			get
			{
				return modifiers.BR_Color.GetValue(vertex_BR.color);
			}
			set
			{
				ColorOverride bR_Color = modifiers.BR_Color;
				bR_Color.Override |= ColorOverride.OverrideMode.Color | ColorOverride.OverrideMode.Alpha;
				bR_Color.Color = value;
				modifiers.BR_Color = bR_Color;
				colorsDirty = true;
				alphasDirty = true;
			}
		}

		public byte BL_Alpha
		{
			get
			{
				return modifiers.BL_Color.GetValue(vertex_BL.color).a;
			}
			set
			{
				ColorOverride bL_Color = modifiers.BL_Color;
				bL_Color.Override |= ColorOverride.OverrideMode.Alpha;
				bL_Color.Color.a = value;
				modifiers.BL_Color = bL_Color;
				alphasDirty = true;
			}
		}

		public byte TL_Alpha
		{
			get
			{
				return modifiers.TL_Color.GetValue(vertex_TL.color).a;
			}
			set
			{
				ColorOverride tL_Color = modifiers.TL_Color;
				tL_Color.Override |= ColorOverride.OverrideMode.Alpha;
				tL_Color.Color.a = value;
				modifiers.TL_Color = tL_Color;
				alphasDirty = true;
			}
		}

		public byte TR_Alpha
		{
			get
			{
				return modifiers.TR_Color.GetValue(vertex_TR.color).a;
			}
			set
			{
				ColorOverride tR_Color = modifiers.TR_Color;
				tR_Color.Override |= ColorOverride.OverrideMode.Alpha;
				tR_Color.Color.a = value;
				modifiers.TR_Color = tR_Color;
				alphasDirty = true;
			}
		}

		public byte BR_Alpha
		{
			get
			{
				return modifiers.BR_Color.GetValue(vertex_BR.color).a;
			}
			set
			{
				ColorOverride bR_Color = modifiers.BR_Color;
				bR_Color.Override |= ColorOverride.OverrideMode.Alpha;
				bR_Color.Color.a = value;
				modifiers.BR_Color = bR_Color;
				alphasDirty = true;
			}
		}

		public Vector3 BL_Position
		{
			get
			{
				return vertex_BL.position + modifiers.BL_Delta;
			}
			set
			{
				modifiers.BL_Delta = value - vertex_BL.position;
				positionsDirty = true;
			}
		}

		public Vector3 TL_Position
		{
			get
			{
				return vertex_TL.position + modifiers.TL_Delta;
			}
			set
			{
				modifiers.TL_Delta = value - vertex_TL.position;
				positionsDirty = true;
			}
		}

		public Vector3 TR_Position
		{
			get
			{
				return vertex_TR.position + modifiers.TR_Delta;
			}
			set
			{
				modifiers.TR_Delta = value - vertex_TR.position;
				positionsDirty = true;
			}
		}

		public Vector3 BR_Position
		{
			get
			{
				return vertex_BR.position + modifiers.BR_Delta;
			}
			set
			{
				modifiers.BR_Delta = value - vertex_BR.position;
				positionsDirty = true;
			}
		}

		public Vector3 BL_UV0
		{
			get
			{
				return modifiers.BL_UV0.GetValue(vertex_BL.uv);
			}
			set
			{
				modifiers.BL_UV0 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public Vector3 TL_UV0
		{
			get
			{
				return modifiers.TL_UV0.GetValue(vertex_TL.uv);
			}
			set
			{
				modifiers.TL_UV0 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public Vector3 TR_UV0
		{
			get
			{
				return modifiers.TR_UV0.GetValue(vertex_TR.uv);
			}
			set
			{
				modifiers.TR_UV0 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public Vector3 BR_UV0
		{
			get
			{
				return modifiers.BR_UV0.GetValue(vertex_BR.uv);
			}
			set
			{
				modifiers.BR_UV0 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public Vector3 BL_UV2
		{
			get
			{
				return modifiers.BL_UV2.GetValue(vertex_BL.uv2);
			}
			set
			{
				modifiers.BL_UV2 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public Vector3 TL_UV2
		{
			get
			{
				return modifiers.TL_UV2.GetValue(vertex_TL.uv2);
			}
			set
			{
				modifiers.TL_UV2 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public Vector3 TR_UV2
		{
			get
			{
				return modifiers.TR_UV2.GetValue(vertex_TR.uv2);
			}
			set
			{
				modifiers.TR_UV2 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public Vector3 BR_UV2
		{
			get
			{
				return modifiers.BR_UV2.GetValue(vertex_BR.uv2);
			}
			set
			{
				modifiers.BR_UV2 = new Vector3Override(value);
				uvsDirty = true;
			}
		}

		public VertexData(TMP_Vertex bl, TMP_Vertex tl, TMP_Vertex tr, TMP_Vertex br)
		{
			positionsDirty = false;
			uvsDirty = false;
			colorsDirty = false;
			alphasDirty = false;
			initial = new ReadOnlyVertexData(bl, tl, tr, br);
			vertex_BL = bl;
			vertex_TL = tl;
			vertex_TR = tr;
			vertex_BR = br;
			modifiers = new TMPMeshModifiers();
		}

		public VertexData(TMP_CharacterInfo info)
		{
			positionsDirty = false;
			uvsDirty = false;
			colorsDirty = false;
			alphasDirty = false;
			initial = new ReadOnlyVertexData(info);
			vertex_BL = info.vertex_BL;
			vertex_TL = info.vertex_TL;
			vertex_TR = info.vertex_TR;
			vertex_BR = info.vertex_BR;
			modifiers = new TMPMeshModifiers();
		}

		public Vector3 GetPosition(int i)
		{
			return i switch
			{
				0 => BL_Position, 
				1 => TL_Position, 
				2 => TR_Position, 
				3 => BR_Position, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public void SetPosition(int i, Vector3 value)
		{
			switch (i)
			{
			case 0:
				BL_Position = value;
				break;
			case 1:
				TL_Position = value;
				break;
			case 2:
				TR_Position = value;
				break;
			case 3:
				BR_Position = value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			positionsDirty = true;
		}

		public Color32 GetColor(int i)
		{
			return i switch
			{
				0 => BL_Color, 
				1 => TL_Color, 
				2 => TR_Color, 
				3 => BR_Color, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public void SetColor(int i, Color32 value, bool ignoreAlpha = false)
		{
			if (!ignoreAlpha)
			{
				switch (i)
				{
				case 0:
					BL_Color = value;
					break;
				case 1:
					TL_Color = value;
					break;
				case 2:
					TR_Color = value;
					break;
				case 3:
					BR_Color = value;
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				colorsDirty = true;
				alphasDirty = true;
				return;
			}
			switch (i)
			{
			case 0:
			{
				ColorOverride bR_Color = modifiers.BL_Color;
				bR_Color.Override |= ColorOverride.OverrideMode.Color;
				Color32 color = bR_Color.Color;
				bR_Color.Color = new Color32(value.r, value.g, value.b, color.a);
				modifiers.BL_Color = bR_Color;
				break;
			}
			case 1:
			{
				ColorOverride bR_Color = modifiers.TL_Color;
				bR_Color.Override |= ColorOverride.OverrideMode.Color;
				Color32 color = bR_Color.Color;
				bR_Color.Color = new Color32(value.r, value.g, value.b, color.a);
				modifiers.TL_Color = bR_Color;
				break;
			}
			case 2:
			{
				ColorOverride bR_Color = modifiers.TR_Color;
				bR_Color.Override |= ColorOverride.OverrideMode.Color;
				Color32 color = bR_Color.Color;
				bR_Color.Color = new Color32(value.r, value.g, value.b, color.a);
				modifiers.TR_Color = bR_Color;
				break;
			}
			case 3:
			{
				ColorOverride bR_Color = modifiers.BR_Color;
				bR_Color.Override |= ColorOverride.OverrideMode.Color;
				Color32 color = bR_Color.Color;
				bR_Color.Color = new Color32(value.r, value.g, value.b, color.a);
				modifiers.BR_Color = bR_Color;
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
			colorsDirty = true;
		}

		public byte GetAlpha(int i)
		{
			return i switch
			{
				0 => BL_Color.a, 
				1 => TL_Color.a, 
				2 => TR_Color.a, 
				3 => BR_Color.a, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public void SetAlpha(int i, float value)
		{
			switch (i)
			{
			case 0:
				BL_Alpha = (byte)value;
				break;
			case 1:
				TL_Alpha = (byte)value;
				break;
			case 2:
				TR_Alpha = (byte)value;
				break;
			case 3:
				BR_Alpha = (byte)value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			alphasDirty = true;
		}

		public Vector2 GetUV0(int i)
		{
			return i switch
			{
				0 => BL_UV0, 
				1 => TL_UV0, 
				2 => TR_UV0, 
				3 => BR_UV0, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public void SetUV0(int i, Vector2 value)
		{
			switch (i)
			{
			case 0:
				BL_UV0 = value;
				break;
			case 1:
				TL_UV0 = value;
				break;
			case 2:
				TR_UV0 = value;
				break;
			case 3:
				BR_UV0 = value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			uvsDirty = true;
		}

		public Vector2 GetUV2(int i)
		{
			return i switch
			{
				0 => BL_UV2, 
				1 => TL_UV2, 
				2 => TR_UV2, 
				3 => BR_UV2, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public void SetUV2(int i, Vector2 value)
		{
			switch (i)
			{
			case 0:
				BL_UV2 = value;
				break;
			case 1:
				TL_UV2 = value;
				break;
			case 2:
				TR_UV2 = value;
				break;
			case 3:
				BR_UV2 = value;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			uvsDirty = true;
		}

		public void Reset()
		{
			modifiers.ClearModifiers();
		}

		public void ResetColors()
		{
			if (!colorsDirty)
			{
				return;
			}
			if (alphasDirty)
			{
				if (modifiers.BL_Color.OverrideAlpha)
				{
					modifiers.BL_Color = new ColorOverride(modifiers.BL_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Alpha);
				}
				else
				{
					modifiers.BL_Color = new ColorOverride(initial.GetColor(0), ColorOverride.OverrideMode.None);
				}
				if (modifiers.TL_Color.OverrideAlpha)
				{
					modifiers.TL_Color = new ColorOverride(modifiers.TL_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Alpha);
				}
				else
				{
					modifiers.TL_Color = new ColorOverride(initial.GetColor(1), ColorOverride.OverrideMode.None);
				}
				if (modifiers.TR_Color.OverrideAlpha)
				{
					modifiers.TR_Color = new ColorOverride(modifiers.TR_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Alpha);
				}
				else
				{
					modifiers.TR_Color = new ColorOverride(initial.GetColor(2), ColorOverride.OverrideMode.None);
				}
				if (modifiers.BR_Color.OverrideAlpha)
				{
					modifiers.BR_Color = new ColorOverride(modifiers.BR_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Alpha);
				}
				else
				{
					modifiers.BR_Color = new ColorOverride(initial.GetColor(3), ColorOverride.OverrideMode.None);
				}
			}
			else
			{
				modifiers.BL_Color = new ColorOverride(initial.GetColor(0), ColorOverride.OverrideMode.None);
				modifiers.TL_Color = new ColorOverride(initial.GetColor(1), ColorOverride.OverrideMode.None);
				modifiers.TR_Color = new ColorOverride(initial.GetColor(2), ColorOverride.OverrideMode.None);
				modifiers.BR_Color = new ColorOverride(initial.GetColor(3), ColorOverride.OverrideMode.None);
			}
			colorsDirty = false;
		}

		public void ResetAlphas()
		{
			if (!alphasDirty)
			{
				return;
			}
			if (colorsDirty)
			{
				if (modifiers.BL_Color.OverrideColor)
				{
					modifiers.BL_Color = new ColorOverride(modifiers.BL_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Color);
				}
				else
				{
					modifiers.BL_Color = new ColorOverride(initial.GetColor(0), ColorOverride.OverrideMode.None);
				}
				if (modifiers.TL_Color.OverrideColor)
				{
					modifiers.TL_Color = new ColorOverride(modifiers.TL_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Color);
				}
				else
				{
					modifiers.TL_Color = new ColorOverride(initial.GetColor(1), ColorOverride.OverrideMode.None);
				}
				if (modifiers.TR_Color.OverrideColor)
				{
					modifiers.TR_Color = new ColorOverride(modifiers.TR_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Color);
				}
				else
				{
					modifiers.TR_Color = new ColorOverride(initial.GetColor(2), ColorOverride.OverrideMode.None);
				}
				if (modifiers.BR_Color.OverrideColor)
				{
					modifiers.BR_Color = new ColorOverride(modifiers.BR_Color.Color, modifiers.BL_Color.Override & ~ColorOverride.OverrideMode.Color);
				}
				else
				{
					modifiers.BR_Color = new ColorOverride(initial.GetColor(1), ColorOverride.OverrideMode.None);
				}
			}
			else
			{
				modifiers.BL_Color = new ColorOverride(initial.GetColor(0), ColorOverride.OverrideMode.None);
				modifiers.TL_Color = new ColorOverride(initial.GetColor(1), ColorOverride.OverrideMode.None);
				modifiers.TR_Color = new ColorOverride(initial.GetColor(2), ColorOverride.OverrideMode.None);
				modifiers.BR_Color = new ColorOverride(initial.GetColor(3), ColorOverride.OverrideMode.None);
			}
			alphasDirty = false;
		}

		public void ResetPositions()
		{
			if (positionsDirty)
			{
				modifiers.ClearModifiers(TMPMeshModifiers.ModifierFlags.Deltas);
				positionsDirty = false;
			}
		}

		public void ResetUVs()
		{
			if (uvsDirty)
			{
				modifiers.ClearModifiers(TMPMeshModifiers.ModifierFlags.UVs);
				uvsDirty = false;
			}
		}
	}
}
