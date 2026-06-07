using JetBrains.Annotations;
using UnityEngine;

namespace Motorways.UI
{
	public class MapButtonChallengeCardLockScreen : MonoBehaviour
	{
		[SerializeField]
		private MapButtonChallengeCard _challengeCard;

		[UsedImplicitly]
		public void UnlockAnimationComplete()
		{
			_challengeCard.UnlockAnimationComplete();
		}

		[UsedImplicitly]
		public void FadeOutAnimationComplete()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
