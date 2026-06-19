using System;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public class TMPMeshModifiers
	{
		[Flags]
		public enum ModifierFlags : byte
		{
			Deltas = 1,
			Colors = 2,
			UVs = 4,
			All = byte.MaxValue
		}

		[SerializeField]
		private Vector3 bl_Delta;

		[SerializeField]
		private Vector3 tl_Delta;

		[SerializeField]
		private Vector3 tr_Delta;

		[SerializeField]
		private Vector3 br_Delta;

		[SerializeField]
		private ColorOverride bl_Color;

		[SerializeField]
		private ColorOverride tl_Color;

		[SerializeField]
		private ColorOverride tr_Color;

		[SerializeField]
		private ColorOverride br_Color;

		[SerializeField]
		private Vector3Override bl_UV0;

		[SerializeField]
		private Vector3Override tl_UV0;

		[SerializeField]
		private Vector3Override tr_UV0;

		[SerializeField]
		private Vector3Override br_UV0;

		[SerializeField]
		private Vector3Override bl_UV2;

		[SerializeField]
		private Vector3Override tl_UV2;

		[SerializeField]
		private Vector3Override tr_UV2;

		[SerializeField]
		private Vector3Override br_UV2;

		[SerializeField]
		private ModifierFlags modifier;

		private Vector3 BLMin;

		private Vector3 BLMax;

		private Vector3 TLMin;

		private Vector3 TLMax;

		private Vector3 TRMin;

		private Vector3 TRMax;

		private Vector3 BRMin;

		private Vector3 BRMax;

		public Vector3 BL_Delta
		{
			get
			{
				return bl_Delta;
			}
			set
			{
				bl_Delta = value;
				modifier |= ModifierFlags.Deltas;
			}
		}

		public Vector3 TL_Delta
		{
			get
			{
				return tl_Delta;
			}
			set
			{
				tl_Delta = value;
				modifier |= ModifierFlags.Deltas;
			}
		}

		public Vector3 TR_Delta
		{
			get
			{
				return tr_Delta;
			}
			set
			{
				tr_Delta = value;
				modifier |= ModifierFlags.Deltas;
			}
		}

		public Vector3 BR_Delta
		{
			get
			{
				return br_Delta;
			}
			set
			{
				br_Delta = value;
				modifier |= ModifierFlags.Deltas;
			}
		}

		public ColorOverride BL_Color
		{
			get
			{
				return bl_Color;
			}
			set
			{
				bl_Color = value;
				modifier |= ModifierFlags.Colors;
			}
		}

		public ColorOverride TL_Color
		{
			get
			{
				return tl_Color;
			}
			set
			{
				tl_Color = value;
				modifier |= ModifierFlags.Colors;
			}
		}

		public ColorOverride TR_Color
		{
			get
			{
				return tr_Color;
			}
			set
			{
				tr_Color = value;
				modifier |= ModifierFlags.Colors;
			}
		}

		public ColorOverride BR_Color
		{
			get
			{
				return br_Color;
			}
			set
			{
				br_Color = value;
				modifier |= ModifierFlags.Colors;
			}
		}

		public Vector3Override BL_UV0
		{
			get
			{
				return bl_UV0;
			}
			set
			{
				bl_UV0 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public Vector3Override TL_UV0
		{
			get
			{
				return tl_UV0;
			}
			set
			{
				tl_UV0 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public Vector3Override TR_UV0
		{
			get
			{
				return tr_UV0;
			}
			set
			{
				tr_UV0 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public Vector3Override BR_UV0
		{
			get
			{
				return br_UV0;
			}
			set
			{
				br_UV0 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public Vector3Override BL_UV2
		{
			get
			{
				return bl_UV2;
			}
			set
			{
				bl_UV2 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public Vector3Override TL_UV2
		{
			get
			{
				return tl_UV2;
			}
			set
			{
				tl_UV2 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public Vector3Override TR_UV2
		{
			get
			{
				return tr_UV2;
			}
			set
			{
				tr_UV2 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public Vector3Override BR_UV2
		{
			get
			{
				return br_UV2;
			}
			set
			{
				br_UV2 = value;
				modifier |= ModifierFlags.UVs;
			}
		}

		public ModifierFlags Modifier => modifier;

		public TMPMeshModifiers()
		{
		}

		public TMPMeshModifiers(TMPMeshModifiers original)
		{
			bl_Delta = original.bl_Delta;
			tl_Delta = original.tl_Delta;
			tr_Delta = original.tr_Delta;
			br_Delta = original.br_Delta;
			bl_UV0 = original.bl_UV0;
			tl_UV0 = original.tl_UV0;
			tr_UV0 = original.tr_UV0;
			br_UV0 = original.br_UV0;
			bl_UV2 = original.bl_UV2;
			tl_UV2 = original.tl_UV2;
			tr_UV2 = original.tr_UV2;
			br_UV2 = original.br_UV2;
			bl_Color = original.bl_Color;
			tl_Color = original.tl_Color;
			tr_Color = original.tr_Color;
			br_Color = original.br_Color;
			modifier = original.Modifier;
		}

		public void ClearModifiers()
		{
			if (modifier.HasFlag(ModifierFlags.Deltas))
			{
				ClearDeltas();
			}
			if (modifier.HasFlag(ModifierFlags.Colors))
			{
				ClearColors();
			}
			if (modifier.HasFlag(ModifierFlags.UVs))
			{
				ClearUVs();
			}
		}

		public void ClearModifiers(ModifierFlags flags)
		{
			ModifierFlags modifierFlags = modifier & flags;
			if (modifierFlags.HasFlag(ModifierFlags.Deltas))
			{
				ClearDeltas();
			}
			if (modifierFlags.HasFlag(ModifierFlags.Colors))
			{
				ClearColors();
			}
			if (modifierFlags.HasFlag(ModifierFlags.UVs))
			{
				ClearUVs();
			}
		}

		private void ClearDeltas()
		{
			bl_Delta = Vector3.zero;
			tl_Delta = Vector3.zero;
			tr_Delta = Vector3.zero;
			br_Delta = Vector3.zero;
			modifier &= ~ModifierFlags.Deltas;
		}

		private void ClearColors()
		{
			bl_Color = default(ColorOverride);
			tl_Color = default(ColorOverride);
			tr_Color = default(ColorOverride);
			br_Color = default(ColorOverride);
			modifier &= ~ModifierFlags.Colors;
		}

		private void ClearUVs()
		{
			bl_UV0 = Vector3Override.GetDefault;
			tl_UV0 = Vector3Override.GetDefault;
			tr_UV0 = Vector3Override.GetDefault;
			br_UV0 = Vector3Override.GetDefault;
			bl_UV2 = Vector3Override.GetDefault;
			tl_UV2 = Vector3Override.GetDefault;
			tr_UV2 = Vector3Override.GetDefault;
			br_UV2 = Vector3Override.GetDefault;
			modifier &= ~ModifierFlags.UVs;
		}

		private void UpdateMinMax(TMPMeshModifiers other)
		{
			BLMin = Vector3.Min(bl_Delta, other.bl_Delta);
			BLMax = Vector3.Max(bl_Delta, other.bl_Delta);
			TLMin = Vector3.Min(tl_Delta, other.tl_Delta);
			TLMax = Vector3.Max(tl_Delta, other.tl_Delta);
			TRMin = Vector3.Min(tr_Delta, other.tr_Delta);
			TRMax = Vector3.Max(tr_Delta, other.tr_Delta);
			BRMin = Vector3.Min(br_Delta, other.br_Delta);
			BRMax = Vector3.Max(br_Delta, other.br_Delta);
		}

		public void Combine(TMPMeshModifiers other)
		{
			if (other.modifier.HasFlag(ModifierFlags.Deltas))
			{
				UpdateMinMax(other);
				bl_Delta += other.bl_Delta;
				BL_Delta = new Vector3(Mathf.Clamp(bl_Delta.x, BLMin.x, BLMax.x), Mathf.Clamp(bl_Delta.y, BLMin.y, BLMax.y), Mathf.Clamp(bl_Delta.z, BLMin.z, BLMax.z));
				tl_Delta += other.tl_Delta;
				TL_Delta = new Vector3(Mathf.Clamp(tl_Delta.x, TLMin.x, TLMax.x), Mathf.Clamp(tl_Delta.y, TLMin.y, TLMax.y), Mathf.Clamp(tl_Delta.z, TLMin.z, TLMax.z));
				tr_Delta += other.tr_Delta;
				TR_Delta = new Vector3(Mathf.Clamp(tr_Delta.x, TRMin.x, TRMax.x), Mathf.Clamp(tr_Delta.y, TRMin.y, TRMax.y), Mathf.Clamp(tr_Delta.z, TRMin.z, TRMax.z));
				br_Delta += other.br_Delta;
				BR_Delta = new Vector3(Mathf.Clamp(br_Delta.x, BRMin.x, BRMax.x), Mathf.Clamp(br_Delta.y, BRMin.y, BRMax.y), Mathf.Clamp(br_Delta.z, BRMin.z, BRMax.z));
			}
			if (other.modifier.HasFlag(ModifierFlags.Colors))
			{
				BL_Color += other.BL_Color;
				TL_Color += other.TL_Color;
				TR_Color += other.TR_Color;
				BR_Color += other.BR_Color;
			}
			if (other.modifier.HasFlag(ModifierFlags.UVs))
			{
				BL_UV0 += other.BL_UV0;
				TL_UV0 += other.TL_UV0;
				TR_UV0 += other.TR_UV0;
				BR_UV0 += other.BR_UV0;
				BL_UV2 += other.BL_UV2;
				TL_UV2 += other.TL_UV2;
				TR_UV2 += other.TR_UV2;
				BR_UV2 += other.BR_UV2;
			}
			modifier |= other.modifier;
		}

		public void CopyFrom(TMPMeshModifiers other)
		{
			ClearModifiers();
			BL_Delta = other.BL_Delta;
			TL_Delta = other.TL_Delta;
			TR_Delta = other.TR_Delta;
			BR_Delta = other.BR_Delta;
			BL_Color = other.BL_Color;
			TL_Color = other.TL_Color;
			TR_Color = other.TR_Color;
			BR_Color = other.BR_Color;
			BL_UV0 = other.BL_UV0;
			TL_UV0 = other.TL_UV0;
			TR_UV0 = other.TR_UV0;
			BR_UV0 = other.BR_UV0;
			BL_UV2 = other.BL_UV2;
			TL_UV2 = other.TL_UV2;
			TR_UV2 = other.TR_UV2;
			BR_UV2 = other.BR_UV2;
			modifier = other.modifier;
		}

		public static TMPMeshModifiers operator +(TMPMeshModifiers lhs, TMPMeshModifiers rhs)
		{
			if (rhs.modifier.HasFlag(ModifierFlags.Deltas))
			{
				lhs.BL_Delta += rhs.BL_Delta;
				lhs.TL_Delta += rhs.TL_Delta;
				lhs.TR_Delta += rhs.TR_Delta;
				lhs.BR_Delta += rhs.BR_Delta;
			}
			if (rhs.modifier.HasFlag(ModifierFlags.Colors))
			{
				lhs.BL_Color += rhs.BL_Color;
				lhs.TL_Color += rhs.TL_Color;
				lhs.TR_Color += rhs.TR_Color;
				lhs.BR_Color += rhs.BR_Color;
			}
			if (rhs.modifier.HasFlag(ModifierFlags.UVs))
			{
				lhs.BL_UV0 += rhs.BL_UV0;
				lhs.TL_UV0 += rhs.TL_UV0;
				lhs.TR_UV0 += rhs.TR_UV0;
				lhs.BR_UV0 += rhs.BR_UV0;
			}
			return lhs;
		}
	}
}
