using UnityEngine.Playables;

namespace TH20.Timeline
{
	public sealed class EventMixer : PlayableBehaviour
	{
		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			EventBehaviour eventBehaviour = playerData as EventBehaviour;
			if (eventBehaviour == null)
			{
				return;
			}
			int inputCount = playable.GetInputCount();
			for (int i = 0; i < inputCount; i++)
			{
				ScriptPlayable<EventPlayable> playable2 = (ScriptPlayable<EventPlayable>)playable.GetInput(i);
				EventPlayable behaviour = playable2.GetBehaviour();
				if (behaviour != null)
				{
					if (playable2.GetPreviousTime() <= 0.0 && playable2.GetTime() > 0.0)
					{
						eventBehaviour.OnClipStart(behaviour.EventName, behaviour.EventTag);
					}
					if (playable2.GetPlayState() == PlayState.Playing)
					{
						eventBehaviour.OnClipPlaying(behaviour.EventName, behaviour.EventTag, playable2.GetTime());
					}
				}
			}
		}
	}
}
