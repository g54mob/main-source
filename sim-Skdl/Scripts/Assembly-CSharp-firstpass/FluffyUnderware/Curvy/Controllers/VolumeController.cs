using System;
using FluffyUnderware.Curvy.Generator;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Controllers
{
	[HelpURL("https://curvyeditor.com/doclink/volumecontroller")]
	[AddComponentMenu("Curvy/Controllers/CG Volume Controller")]
	public class VolumeController : CurvyController
	{
		private const float CrossPositionRangeMin = -0.5f;

		private const float CrossPositionRangeMax = 0.5f;

		[Section("General", true, false, 100)]
		[CGDataReferenceSelector(typeof(CGVolume), Label = "Volume/Slot")]
		[SerializeField]
		private CGDataReference m_Volume;

		[FloatRegion(UseSlider = true, Precision = 4, RegionOptionsPropertyName = "CrossRangeOptions", Options = AttributeOptionsFlags.Full)]
		[Section("Cross Position", true, false, 100, Sort = 1, HelpURL = "https://curvyeditor.com/doclink/volumecontroller_crossposition")]
		[SerializeField]
		private FloatRegion m_CrossRange;

		[RangeEx("MinCrossRelativePosition", "MaxCrossRelativePosition", null, null)]
		[SerializeField]
		private float crossRelativePosition;

		[SerializeField]
		private CurvyClamping m_CrossClamping;

		[HideInInspector]
		[UsedImplicitly]
		[Obsolete("Use crossRelativePosition instead. This field is kept for retro compatibility reasons")]
		[SerializeField]
		private float m_CrossInitialPosition;

		public CGDataReference Volume
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[CanBeNull]
		public CGVolume VolumeData => null;

		public float CrossFrom
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CrossTo
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CrossLength => 0f;

		public CurvyClamping CrossClamping
		{
			get
			{
				return default(CurvyClamping);
			}
			set
			{
			}
		}

		public float CrossRelativePosition
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override float Length => 0f;

		public override bool IsReady => false;

		private RegionOptions<float> CrossRangeOptions => default(RegionOptions<float>);

		private float MinCrossRelativePosition => 0f;

		private float MaxCrossRelativePosition => 0f;

		public float CrossRelativeToAbsolute(float relativeDistance)
		{
			return 0f;
		}

		public float CrossAbsoluteToRelative(float worldUnitDistance)
		{
			return 0f;
		}

		protected override float RelativeToAbsolute(float relativeDistance)
		{
			return 0f;
		}

		protected override float AbsoluteToRelative(float worldUnitDistance)
		{
			return 0f;
		}

		protected override Vector3 GetInterpolatedSourcePosition(float tf)
		{
			return default(Vector3);
		}

		protected override void GetInterpolatedSourcePosition(float tf, out Vector3 interpolatedPosition, out Vector3 tangent, out Vector3 up)
		{
			interpolatedPosition = default(Vector3);
			tangent = default(Vector3);
			up = default(Vector3);
		}

		protected override Vector3 GetTangent(float tf)
		{
			return default(Vector3);
		}

		protected override Vector3 GetOrientation(float tf)
		{
			return default(Vector3);
		}

		protected override void Advance(float speed, float deltaTime)
		{
		}

		protected override void SimulateAdvance(ref float tf, ref MovementDirection direction, float speed, float deltaTime)
		{
		}

		private float GetClampedCrossPosition(float position)
		{
			return 0f;
		}

		public override void OnAfterDeserialize()
		{
		}
	}
}
