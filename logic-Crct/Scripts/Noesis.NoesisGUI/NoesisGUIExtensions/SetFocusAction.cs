using Noesis;
using NoesisApp;

namespace NoesisGUIExtensions
{
	public class SetFocusAction : TargetedTriggerAction<UIElement>
	{
		public static readonly DependencyProperty EngageProperty;

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

		public new SetFocusAction Clone()
		{
			return null;
		}

		public new SetFocusAction CloneCurrentValue()
		{
			return null;
		}

		protected override void Invoke(object parameter)
		{
		}
	}
}
