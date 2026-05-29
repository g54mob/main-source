using System.Runtime.CompilerServices;
using FluffyUnderware.DevTools;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	public abstract class ScalingModule : CGModule
	{
		[Tooltip("What type of scaling should be applied")]
		[Tab("Scale", Sort = 101)]
		[Label("Mode", null)]
		[SerializeField]
		private ScaleMode m_ScaleMode;

		[SerializeField]
		[Label("Reference", null)]
		[Tooltip("Determines on what range the scale is applied:\r\nSelf: the scale is applied over the Path's active range\r\nSource: the scale is applied over the Path's total length")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private CGReferenceMode m_ScaleReference;

		[SerializeField]
		[Label("Offset", null)]
		[Tooltip("Scale is applied starting at this offset")]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		private float m_ScaleOffset;

		[Tooltip("If enabled, the same scale is applied to both X and Y axis of the cross section")]
		[SerializeField]
		[Label("Uniform Scaling", null)]
		private bool m_ScaleUniform;

		[SerializeField]
		[Tooltip("The (base) value of the scaling along the cross section's X axis, and Y axis if Uniform Scaling is disabled")]
		private float m_ScaleX;

		[Tooltip("Defines scale multiplier, depending on the Relative Distance (between 0 and 1) of a point on the path")]
		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[AnimationCurveEx("    Multiplier", null)]
		private AnimationCurve m_ScaleCurveX;

		[SerializeField]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("The (base) value of the scaling along the cross section's Y axis")]
		private float m_ScaleY;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[AnimationCurveEx("    Multiplier", null)]
		[Tooltip("Defines scale multiplier, depending on the Relative Distance (between 0 and 1) of a point on the path")]
		[SerializeField]
		private AnimationCurve m_ScaleCurveY;

		public ScaleMode ScaleMode
		{
			get
			{
				return default(ScaleMode);
			}
			set
			{
			}
		}

		public CGReferenceMode ScaleReference
		{
			get
			{
				return default(CGReferenceMode);
			}
			set
			{
			}
		}

		public bool ScaleUniform
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float ScaleOffset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ScaleX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve ScaleMultiplierX
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float ScaleY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve ScaleMultiplierY
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void Reset()
		{
		}

		public Vector2 GetScale(float relativeDistance)
		{
			return default(Vector2);
		}

		protected Vector2 GetScale(int sampleIndex, SubArray<float> relativeDistances, SubArray<float> sourceRelativeDistances)
		{
			return default(Vector2);
		}

		protected static Vector2 GetScale(float relativeDistance, ScaleMode mode, float offset, bool isUniform, float scaleX, AnimationCurve scaleMultiplierX, float scaleY, AnimationCurve scaleMultiplierY)
		{
			return default(Vector2);
		}

		protected static float GetRelativeDistance(int sampleIndex, CGReferenceMode cgReferenceMode, SubArray<float> relativeDistances, SubArray<float> sourceRelativeDistances)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static Vector2 GetAdvancedScale(float relativeDistance, float scaleOffset, bool isUniform, float scaleX, AnimationCurve scaleMultiplierX, float scaleY, AnimationCurve scaleMultiplierY)
		{
			return default(Vector2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected static Vector2 GetSimpleScale(bool isUniform, float scaleX, float scaleY)
		{
			return default(Vector2);
		}
	}
}
