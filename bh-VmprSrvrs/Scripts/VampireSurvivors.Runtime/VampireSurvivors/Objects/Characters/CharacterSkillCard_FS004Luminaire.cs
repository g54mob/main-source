using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterSkillCard_FS004Luminaire : CharacterSkillCard_Base
	{
		private float _cooldownBonus;

		private float _moveBonus;

		private float _bonusDuration;

		private bool _hasBonus;

		private List<PhaserSprite> _doilies;

		private MultiTargetTween _tween1;

		private float _mightBonus;

		private MorphVFX _morphVFX;

		private float _elapsedGFBonusTime;

		private PhaserSprite _fogRays;

		private float _timesRevived;

		private float _originalMoveSpeed;

		public CharacterSkillCard_FS004Luminaire(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}

		public void SetupGraphics()
		{
		}

		public override void Update()
		{
		}

		public override void OnOwnerLevelUp()
		{
		}

		public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
		{
		}

		public void RemoveBonus()
		{
		}

		private void RosaryDamage()
		{
		}

		private void PlayRosaryAnim()
		{
		}
	}
}
