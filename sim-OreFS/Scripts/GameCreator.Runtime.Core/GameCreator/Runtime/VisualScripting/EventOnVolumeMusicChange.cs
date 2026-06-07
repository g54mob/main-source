using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Change Music Volume")]
	[Category("Audio/On Change Music Volume")]
	[Description("Executed when the Music Volume is changed")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Audio", "Sound", "Level" })]
	public class EventOnVolumeMusicChange : Event
	{
		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Singleton<AudioManager>.Instance.Volume.EventMusic -= OnChange;
			Singleton<AudioManager>.Instance.Volume.EventMusic += OnChange;
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			Singleton<AudioManager>.Instance.Volume.EventMusic -= OnChange;
		}

		private void OnChange()
		{
			m_Trigger.Execute(base.Self);
		}
	}
}
