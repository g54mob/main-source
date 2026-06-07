using Brewery.EmoteSystem;
using UnityEngine;

namespace Brewery.Face
{
	public class EmoteFaceSource : FaceSource
	{
		[Header("Emote Source")]
		[SerializeField]
		private EmoteController emoteController;

		private FaceExpressionPlayer _player;

		private EmoteDefinition _lastSeenEmote;

		private bool _wasEmoting;

		public override string DebugName => null;

		private void OnEnable()
		{
		}

		protected override float ComputeTargetWeight(float dt)
		{
			return 0f;
		}

		protected override void Sample(FaceFrame frame, float dt, float sourceFade)
		{
		}
	}
}
