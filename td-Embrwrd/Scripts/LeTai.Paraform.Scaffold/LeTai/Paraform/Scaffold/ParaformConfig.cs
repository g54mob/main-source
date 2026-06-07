using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace LeTai.Paraform.Scaffold
{
	[Serializable]
	public struct ParaformConfig
	{
		public static readonly ParaformConfig DEFAULT;

		[SerializeField]
		[Tooltip("Indiviual corner radii. You can drag the rounded corner symbols to fine tune each radius. Click the link button to keep all corners the same.")]
		internal Vector4 cornerRadii;

		[SerializeField]
		[Range(0f, 6f)]
		[Tooltip("0 is a flat diagonal corner. 1 is the perfect circle. Value > 1 increase curvature continuity target: 2 for G2 continuity, 3 for G3, and so on. Note that curvature continuity requires increased transition length, and is not guaranteed if the corner radius is too large compared to side length.")]
		internal float cornerCurvature;

		[SerializeField]
		[Range(0f, 6f)]
		[Tooltip("0 is a flat diagonal corner. 1 is the perfect circle. Value > 1 increase curvature continuity target: 2 for G2 continuity, 3 for G3, and so on")]
		internal float filletCurvature;

		[SerializeField]
		[Min(0f)]
		internal float edgeWidth;

		[SerializeField]
		[Tooltip("Distance to the below surface, affecting refraction")]
		[Range(0f, 1000f)]
		internal float elevation;

		public Vector4 CornerRadii
		{
			get
			{
				return default(Vector4);
			}
			set
			{
			}
		}

		public float CornerCurvature
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float FilletCurvature
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Tooltip("Bevel width or thickness")]
		public float EdgeWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Elevation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public event Action changed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void NotifyChanged()
		{
		}
	}
}
