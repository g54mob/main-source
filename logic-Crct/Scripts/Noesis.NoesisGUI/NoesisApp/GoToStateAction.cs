using Noesis;

namespace NoesisApp
{
	public class GoToStateAction : TargetedTriggerAction<FrameworkElement>
	{
		public static readonly DependencyProperty StateNameProperty;

		public static readonly DependencyProperty UseTransitionsProperty;

		private FrameworkElement _stateTarget;

		public string StateName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseTransitions
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public new GoToStateAction Clone()
		{
			return null;
		}

		public new GoToStateAction CloneCurrentValue()
		{
			return null;
		}

		protected override void Invoke(object parameter)
		{
		}

		protected override void OnTargetChanged(FrameworkElement oldTarget, FrameworkElement newTarget)
		{
		}

		private FrameworkElement FindStateGroup(FrameworkElement context)
		{
			return null;
		}

		private bool HasStateGroup(FrameworkElement element)
		{
			return false;
		}

		private bool ShouldWalkTree(FrameworkElement element)
		{
			return false;
		}
	}
}
