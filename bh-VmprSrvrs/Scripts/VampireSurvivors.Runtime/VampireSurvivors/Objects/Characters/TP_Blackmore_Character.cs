using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Blackmore_Character : TP_Character
	{
		private SpriteRenderer _back2Sprite;

		private SpriteAnimation _back2Anim;

		private int _morphedTimes;

		private int _finalMorphedTimes;

		private int _finalThreshold;

		private int _enemiesTs;

		private bool _back2SpriteInitialized;

		private int[] _thresholds;

		private void CalculateTreshold()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		protected override void OnUpdate()
		{
		}

		[Command]
		public void EnterSkillSelection()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
