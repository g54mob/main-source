using System;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Camera Change")]
	[Category("Cameras/On Camera Change")]
	[Description("Executed when the Camera changes to another Camera Shot")]
	[Image(typeof(IconCamera), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Shot", "Switch", "Cut" })]
	public class EventOnCameraChange : Event
	{
		private enum ChangeMode
		{
			AnyChange = 0,
			OnCut = 1,
			OnTransition = 2
		}

		[SerializeField]
		private PropertyGetGameObject m_Camera = GetGameObjectCameraMain.Create;

		[SerializeField]
		private ChangeMode m_When;

		[NonSerialized]
		private TCamera m_Cache;

		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			m_Cache = m_Camera.Get<TCamera>(base.Self);
			if (!(m_Cache == null))
			{
				m_Cache.EventCut -= OnChangeCut;
				m_Cache.EventCut += OnChangeCut;
				m_Cache.EventTransition -= OnChangeTransition;
				m_Cache.EventTransition += OnChangeTransition;
			}
		}

		protected internal override void OnDisable(Trigger trigger)
		{
			base.OnDisable(trigger);
			if (!(m_Cache == null))
			{
				m_Cache.EventCut -= OnChangeCut;
				m_Cache.EventTransition -= OnChangeTransition;
			}
		}

		private void OnChangeCut(ShotCamera shotCamera)
		{
			if (m_When != ChangeMode.OnTransition)
			{
				m_Trigger.Execute(base.Self);
			}
		}

		private void OnChangeTransition(ShotCamera shotCamera, float duration, Easing.Type ease)
		{
			if (m_When != ChangeMode.OnCut)
			{
				m_Trigger.Execute(base.Self);
			}
		}
	}
}
