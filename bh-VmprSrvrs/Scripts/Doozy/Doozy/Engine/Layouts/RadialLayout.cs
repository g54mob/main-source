using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Layouts
{
	[AddComponentMenu("Doozy/Layouts/Radial Layout", 13)]
	[DefaultExecutionOrder(-98)]
	[RequireComponent(typeof(RectTransform))]
	public class RadialLayout : LayoutGroup
	{
		public const bool AUTO_REBUILD_DEFAULT_VALUE = true;

		public const bool CLOCKWISE_DEFAULT_VALUE = false;

		public const bool CONTROL_CHILD_HEIGHT_DEFAULT_VALUE = false;

		public const bool CONTROL_CHILD_WIDTH_DEFAULT_VALUE = false;

		public const bool RADIUS_CONTROLS_HEIGHT_DEFAULT_VALUE = false;

		public const bool RADIUS_CONTROLS_WIDTH_DEFAULT_VALUE = false;

		public const bool ROTATE_CHILDREN_DEFAULT_VALUE = false;

		public const float CHILD_HEIGHT_DEFAULT_VALUE = 100f;

		public const float CHILD_ROTATION_DEFAULT_VALUE = 0f;

		public const float CHILD_WIDTH_DEFAULT_VALUE = 100f;

		public const float MAX_ANGLE = 360f;

		public const float MAX_ANGLE_DEFAULT_VALUE = 360f;

		public const float MAX_RADIUS_DEFAULT_VALUE = 1000f;

		public const float MIN_ANGLE = 0f;

		public const float MIN_ANGLE_DEFAULT_VALUE = 0f;

		public const float RADIUS_DEFAULT_VALUE = 100f;

		public const float RADIUS_HEIGHT_FACTOR_DEFAULT_VALUE = 1f;

		public const float RADIUS_WIDTH_FACTOR_DEFAULT_VALUE = 1f;

		public const float SPACING_DEFAULT_VALUE = 0f;

		public const float START_ANGLE_DEFAULT_VALUE = 0f;

		[SerializeField]
		protected bool m_AutoRebuild;

		[SerializeField]
		protected float m_ChildHeight;

		[SerializeField]
		protected float m_ChildRotation;

		[SerializeField]
		protected float m_ChildWidth;

		[SerializeField]
		protected bool m_Clockwise;

		[SerializeField]
		protected bool m_ControlChildHeight;

		[SerializeField]
		protected bool m_ControlChildWidth;

		[Range(0f, 360f)]
		[SerializeField]
		protected float m_MaxAngle;

		[SerializeField]
		protected float m_MaxRadius;

		[Range(0f, 360f)]
		[SerializeField]
		protected float m_MinAngle;

		[SerializeField]
		protected float m_Radius;

		[SerializeField]
		protected bool m_RadiusControlsHeight;

		[SerializeField]
		protected bool m_RadiusControlsWidth;

		[SerializeField]
		protected float m_RadiusHeightFactor;

		[SerializeField]
		protected float m_RadiusWidthFactor;

		[SerializeField]
		protected bool m_RotateChildren;

		[SerializeField]
		protected float m_Spacing;

		[Range(0f, 360f)]
		[SerializeField]
		protected float m_StartAngle;

		private List<RectTransform> m_childList;

		private RectTransform m_rectTransform;

		public bool AutoRebuild
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float ChildHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ChildRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ChildWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Clockwise
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ControlChildHeight
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ControlChildWidth
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float MaxAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MinAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Radius
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool RadiusControlsHeight
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RadiusControlsWidth
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float RadiusHeightFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RadiusWidthFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public RectTransform RectTransform => null;

		public bool RotateChildren
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Spacing
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float StartAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		public override void SetLayoutHorizontal()
		{
		}

		public override void SetLayoutVertical()
		{
		}

		public override void CalculateLayoutInputVertical()
		{
		}

		public override void CalculateLayoutInputHorizontal()
		{
		}

		public void CalculateRadial()
		{
		}

		private void OnValueChanged()
		{
		}
	}
}
