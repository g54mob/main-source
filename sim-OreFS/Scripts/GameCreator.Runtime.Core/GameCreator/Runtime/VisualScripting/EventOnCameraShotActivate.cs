using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Change to Shot")]
	[Category("Cameras/On Change to Shot")]
	[Description("Executed when the Camera Shot is activated")]
	[Image(typeof(IconCameraShot), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Shot", "Switch", "Cut" })]
	public class EventOnCameraShotActivate : Event
	{
		[SerializeField]
		private PropertyGetGameObject m_CameraShot = GetGameObjectInstance.Create();

		[NonSerialized]
		private ShotCamera m_Cache;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			m_Cache = m_CameraShot.Get<ShotCamera>(base.Self);
			if (!(m_Cache == null))
			{
				m_Cache.EventChangeTo -= OnChange;
				m_Cache.EventChangeTo += OnChange;
			}
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			if (!(m_Cache == null))
			{
				m_Cache.EventChangeTo -= OnChange;
			}
		}

		private void OnChange(TCamera camera)
		{
			m_Trigger.Execute(base.Self);
		}
	}
}
