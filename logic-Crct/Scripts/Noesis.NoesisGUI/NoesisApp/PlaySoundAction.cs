using System;
using Noesis;

namespace NoesisApp
{
	public class PlaySoundAction : TriggerAction<DependencyObject>
	{
		public static readonly DependencyProperty SourceProperty;

		public static readonly DependencyProperty VolumeProperty;

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

		public double Volume
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public new PlaySoundAction Clone()
		{
			return null;
		}

		public new PlaySoundAction CloneCurrentValue()
		{
			return null;
		}

		protected override void Invoke(object parameter)
		{
		}
	}
}
