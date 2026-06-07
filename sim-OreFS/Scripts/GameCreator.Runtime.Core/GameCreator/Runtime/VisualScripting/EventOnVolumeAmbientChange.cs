using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Change Ambient Volume")]
	[Category("Audio/On Change Ambient Volume")]
	[Description("Executed when the Ambient Volume is changed")]
	[Image(typeof(IconVolume), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Audio", "Sound", "Level" })]
	public class EventOnVolumeAmbientChange : Event
	{
		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Singleton<AudioManager>.Instance.Volume.EventAmbient -= OnChange;
			Singleton<AudioManager>.Instance.Volume.EventAmbient += OnChange;
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			Singleton<AudioManager>.Instance.Volume.EventAmbient -= OnChange;
		}

		private void OnChange()
		{
			m_Trigger.Execute(base.Self);
		}
	}
}
