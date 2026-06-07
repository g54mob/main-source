using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Tantawowa.TimelineEvents
{
	[Serializable]
	public class TimelineEventBehaviour : PlayableBehaviour
	{
		public string HandlerKey;

		public bool IsMethodWithParam;

		public bool InvokeEventsInEditMode;

		public GameObject TargetObject;

		public string ArgValue;

		private EventInvocationInfo invocationInfo;

		public override void OnBehaviourPlay(Playable playable, FrameData info)
		{
		}

		private void UpdateDelegates()
		{
		}

		private EventInvocationInfo GetInvocationInfo(bool isEnabled, string methodKey, EventInvocationInfo currentInfo, bool methodWitharg)
		{
			return null;
		}

		private void GetBehaviourAndMethod(bool isEnabled, string key, ref Behaviour targetBehaviour, ref string methodName)
		{
		}
	}
}
