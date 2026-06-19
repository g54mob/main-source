#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AnimationEventListener : MonoBehaviour
	{
		private Dictionary<string, List<Action<AnimationEvent>>> _events = new Dictionary<string, List<Action<AnimationEvent>>>();

		private AnimationSFXLoopMaintainer _sfxLoopMaintainer;

		private AnimationSFXLoopMaintainer SFXLoopMaintainer
		{
			get
			{
				if (_sfxLoopMaintainer == null)
				{
					_sfxLoopMaintainer = base.gameObject.AddComponent<AnimationSFXLoopMaintainer>();
				}
				return _sfxLoopMaintainer;
			}
		}

		private void OnDestroy()
		{
			foreach (KeyValuePair<string, List<Action<AnimationEvent>>> @event in _events)
			{
				if (@event.Value.Count != 0)
				{
					Logging.Error(LogChannels.Animation, "AnimationEventListener for " + base.gameObject.name + " still has events registered to '" + @event.Key + "' event!");
				}
			}
			if (_sfxLoopMaintainer != null)
			{
				_sfxLoopMaintainer.EndAllAudioLoops();
			}
		}

		public void RegisterEvent(string eventName, Action<AnimationEvent> callback)
		{
			if (!_events.ContainsKey(eventName))
			{
				_events.Add(eventName, new List<Action<AnimationEvent>>());
			}
			_events[eventName].Add(callback);
		}

		public void UnregisterEvent(string eventName, Action<AnimationEvent> callback)
		{
			if (_events.ContainsKey(eventName))
			{
				_events[eventName].Remove(callback);
				return;
			}
			Logging.Error(LogChannels.Animation, "Animation event '{0}' isn't registered for {1}", eventName, base.transform.gameObject.name);
		}

		public void Event(AnimationEvent animationEvent)
		{
			if (_events.ContainsKey(animationEvent.stringParameter))
			{
				Action<AnimationEvent>[] array = _events[animationEvent.stringParameter].ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i].InvokeSafe(animationEvent);
				}
			}
		}

		public void InvokeAudioEvent(AnimationEvent animationEvent)
		{
			if (AudioManager.Instance != null)
			{
				AudioManager.Instance.Play(animationEvent.stringParameter, base.gameObject);
			}
		}

		public void BeginAudioLoop(AnimationEvent animationEvent)
		{
			SFXLoopMaintainer.BeginAudioLoopMaintainer(animationEvent.stringParameter, animationEvent.animatorClipInfo.clip);
		}

		public void EndAudioLoop(AnimationEvent animationEvent)
		{
			SFXLoopMaintainer.EndAudioLoopMaintainer(animationEvent.stringParameter);
		}

		public void OnAnimGraphChanged()
		{
			if (_sfxLoopMaintainer != null)
			{
				_sfxLoopMaintainer.EndAllAudioLoops();
			}
		}
	}
}
