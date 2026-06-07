using System.Runtime.CompilerServices;
using Noesis;

namespace NoesisApp
{
	public class MouseDragElementBehavior : Behavior<FrameworkElement>
	{
		public static readonly DependencyProperty XProperty;

		public static readonly DependencyProperty YProperty;

		public static readonly DependencyProperty ConstrainToParentBoundsProperty;

		private TranslateTransform _transform;

		private Point _relativePosition;

		private bool _settingPosition;

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
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

		public event MouseEventHandler DragBegun
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

		public event MouseEventHandler Dragging
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

		public event MouseEventHandler DragFinished
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

		public new MouseDragElementBehavior Clone()
		{
			return null;
		}

		public new MouseDragElementBehavior CloneCurrentValue()
		{
			return null;
		}

		private static void OnXChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnYChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		private static void OnConstrainToParentBoundsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		protected override void OnAttached()
		{
		}

		protected override void OnDetaching()
		{
		}

		private void OnMouseLeftButtonDown(object sender, MouseEventArgs e)
		{
		}

		private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
		}

		private void OnLostMouseCapture(object sender, MouseEventArgs e)
		{
		}

		private void StartDrag(Point relativePosition)
		{
		}

		private void Drag(Point relativePosition)
		{
		}

		private void EndDrag()
		{
		}

		private void UpdatePosition(float x, float y)
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdateTransform(float x, float y)
		{
		}
	}
}
