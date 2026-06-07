using Noesis;

namespace NoesisApp
{
	public class LaunchUriOrFileAction : TriggerAction<DependencyObject>
	{
		public static readonly DependencyProperty PathProperty;

		public string Path
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public new LaunchUriOrFileAction Clone()
		{
			return null;
		}

		public new LaunchUriOrFileAction CloneCurrentValue()
		{
			return null;
		}

		protected override void Invoke(object parameter)
		{
		}
	}
}
