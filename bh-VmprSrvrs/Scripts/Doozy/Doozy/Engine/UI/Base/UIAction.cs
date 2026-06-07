using System;
using System.Collections.Generic;
using Doozy.Engine.Events;
using Doozy.Engine.Soundy;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI.Base
{
	[Serializable]
	public class UIAction
	{
		public Action<GameObject> Action;

		public List<AnimatorEvent> AnimatorEvents;

		public UIEffect Effect;

		public UnityEvent Event;

		public List<string> GameEvents;

		public SoundyData SoundData;

		private Canvas m_canvasForEffect;

		public int AnimatorEventsCount => 0;

		public int GameEventsCount => 0;

		public bool HasAnimatorEvents => false;

		public bool HasEffect => false;

		public bool HasGameEvents => false;

		public bool HasSound => false;

		public bool HasUnityEvent => false;

		public int UnityEventListenerCount => 0;

		public UIAction AddAnimatorEvent(AnimatorEvent animatorEvent)
		{
			return null;
		}

		public UIAction AddAnimatorEvents(List<AnimatorEvent> animatorEvents)
		{
			return null;
		}

		public UIAction AddGameEvent(string gameEvent, bool clearGameEventsList = false)
		{
			return null;
		}

		public UIAction AddGameEvents(List<string> gameEvents, bool clearGameEventsList = false)
		{
			return null;
		}

		public Canvas GetCanvas(GameObject source, bool refresh = false)
		{
			return null;
		}

		public void Invoke(GameObject source, bool playSound = true, bool playEffect = true, bool playAnimatorEvents = true, bool sendGameEvents = true, bool invokeUnityEvent = true, bool invokeAction = true)
		{
		}

		public void InvokeAction(GameObject source)
		{
		}

		public void InvokeUnityEvent()
		{
		}

		public void InvokeAnimatorEvents()
		{
		}

		public void ExecuteEffect(Canvas canvas)
		{
		}

		public void PlaySound()
		{
		}

		public void Reset()
		{
		}

		public void SendGameEvents(GameObject source)
		{
		}

		public UIAction SetAction(Action<GameObject> action)
		{
			return null;
		}

		public UIAction SetEffect(UIEffect effect)
		{
			return null;
		}

		public UIAction SetSoundyData(SoundyData soundyData)
		{
			return null;
		}
	}
}
