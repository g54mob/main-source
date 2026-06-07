using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Change Master Volume")]
	[Category("Audio/On Change Master Volume")]
	[Description("Executed when the Master Volume is changed")]
	[Image(typeof(IconVolume), ColorTheme.Type.Blue)]
	[Keywords(new string[] { "Audio", "Sound", "Level" })]
	public class EventOnVolumeMasterChange : Event
	{
		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			Singleton<AudioManager>.Instance.Volume.EventMaster -= OnChange;
			Singleton<AudioManager>.Instance.Volume.EventMaster += OnChange;
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			Singleton<AudioManager>.Instance.Volume.EventMaster -= OnChange;
		}

		private void OnChange()
		{
			m_Trigger.Execute(base.Self);
		}
	}
}
