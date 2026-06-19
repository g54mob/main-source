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
			All = 0xFF
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
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TL_Delta
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 TR_Delta
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 BR_Delta
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public ColorOverride BL_Color
		{
			get
			{
				return default(ColorOverride);
			}
			set
			{
			}
		}

		public ColorOverride TL_Color
		{
			get
			{
				return default(ColorOverride);
			}
			set
			{
			}
		}

		public ColorOverride TR_Color
		{
			get
			{
				return default(ColorOverride);
			}
			set
			{
			}
		}

		public ColorOverride BR_Color
		{
			get
			{
				return default(ColorOverride);
			}
			set
			{
			}
		}

		public Vector3Override BL_UV0
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public Vector3Override TL_UV0
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public Vector3Override TR_UV0
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public Vector3Override BR_UV0
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public Vector3Override BL_UV2
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public Vector3Override TL_UV2
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public Vector3Override TR_UV2
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public Vector3Override BR_UV2
		{
			get
			{
				return default(Vector3Override);
			}
			set
			{
			}
		}

		public ModifierFlags Modifier => default(ModifierFlags);

		public TMPMeshModifiers()
		{
		}

		public TMPMeshModifiers(TMPMeshModifiers original)
		{
		}

		public void ClearModifiers()
		{
		}

		public void ClearModifiers(ModifierFlags flags)
		{
		}

		private void ClearDeltas()
		{
		}

		private void ClearColors()
		{
		}

		private void ClearUVs()
		{
		}

		private void UpdateMinMax(TMPMeshModifiers other)
		{
		}

		public void Combine(TMPMeshModifiers other)
		{
		}

		public void CopyFrom(TMPMeshModifiers other)
		{
		}

		public static TMPMeshModifiers operator +(TMPMeshModifiers lhs, TMPMeshModifiers rhs)
		{
			return null;
		}
	}
}
