using UMA.CharacterSystem;
using UnityEngine.Playables;

namespace UMA.Timeline
{
	public class UmaColorMixerBehaviour : PlayableBehaviour
	{
		private DynamicCharacterAvatar avatar;

		public float elapsedTime;

		public float timeStep;

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
		}
	}
}
