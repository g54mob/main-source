using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors
{
	public class Report2VotingScreenOption : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _nineSliceSprite;

		[SerializeField]
		private SpriteRenderer _maskSprite;

		[SerializeField]
		private SpriteMask _spriteMask;

		[SerializeField]
		private SpriteRenderer _enemySprite;

		[SerializeField]
		private SpriteRenderer _voteSprite;

		private MultiTargetTween _voteTween;

		private MultiTargetTween _screenShakeTween;

		private void Awake()
		{
		}

		public void SetVoteTargetSprite(Sprite sprite, Color tint)
		{
		}

		public void AddVote()
		{
		}

		public void ScreenShake(int repeats = 6)
		{
		}

		public void ClearVotes()
		{
		}

		public void Cleanup()
		{
		}
	}
}
