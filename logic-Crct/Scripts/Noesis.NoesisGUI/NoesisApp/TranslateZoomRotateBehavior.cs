using Noesis;

namespace NoesisApp
{
	public class TranslateZoomRotateBehavior : Behavior<FrameworkElement>
	{
		public static readonly DependencyProperty SupportedGesturesProperty;

		public static readonly DependencyProperty TranslateFrictionProperty;

		public static readonly DependencyProperty RotationalFrictionProperty;

		public static readonly DependencyProperty ConstrainToParentBoundsProperty;

		public static readonly DependencyProperty MinimumScaleProperty;

		public static readonly DependencyProperty MaximumScaleProperty;

		public static readonly DependencyProperty WheelSensitivityProperty;

		private ScaleTransform _scale;

		private RotateTransform _rotate;

		private TranslateTransform _translate;

		private Point _relativePosition;

		private bool _settingPosition;

		public ManipulationModes SupportedGestures
		{
			get
			{
				return default(ManipulationModes);
			}
			set
			{
			}
		}

		public float TranslateFriction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RotationalFriction
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool ConstrainToParentBounds
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float MinimumScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaximumScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float WheelSensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public new TranslateZoomRotateBehavior Clone()
		{
			return null;
		}

		public new TranslateZoomRotateBehavior CloneCurrentValue()
		{
			return null;
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		private void OnManipulationStarting(object sender, ManipulationStartingEventArgs e)
		{
		}

		private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
		{
		}

		private float Deceleration(float friction, float velocity)
		{
			return 0f;
		}

		private void OnManipulationInertia(object sender, ManipulationInertiaStartingEventArgs e)
		{
		}

		private void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
		}

		private void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
		}

		private void OnMouseMove(object seneder, MouseEventArgs e)
		{
		}

		private void OnMouseLost(object sender, MouseEventArgs e)
		{
		}

		private void OnMouseWheel(object sender, MouseWheelEventArgs e)
		{
		}
	}
}
