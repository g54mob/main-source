using Noesis;
using NoesisApp;

namespace NoesisGUIExtensions
{
	public class MoveFocusAction : TriggerAction<UIElement>
	{
		public static readonly DependencyProperty DirectionProperty;

		public static readonly DependencyProperty EngageProperty;

		public FocusDirection Direction
		{
			get
			{
				return default(FocusDirection);
			}
			set
			{
			}
		}

		public bool Engage
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void Invoke(object parameter)
		{
		}
	}
}
