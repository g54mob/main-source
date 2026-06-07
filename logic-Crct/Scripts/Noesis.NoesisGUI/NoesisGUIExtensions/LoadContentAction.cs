using System;
using Noesis;
using NoesisApp;

namespace NoesisGUIExtensions
{
	public class LoadContentAction : TargetedTriggerAction<ContentControl>
	{
		public static readonly DependencyProperty SourceProperty;

		public Uri Source
		{
			get
			{
				return null;
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
