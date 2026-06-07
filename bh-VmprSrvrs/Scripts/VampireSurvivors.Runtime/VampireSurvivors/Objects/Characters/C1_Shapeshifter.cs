using Coherence.Toolkit;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class C1_Shapeshifter : CharacterController
	{
		private bool _canDropBodyPart;

		private Timer _bodyPartTimer;

		private ShapeShifterShapes currentForm;

		private ShapeShifterShapes[] shapesBag;

		private bool _hasSecondAnim;

		private float _meatDelay;

		private int MaxHealthMaxBonus;

		private int CurrentMaxHPBonus;

		public Weapon FireNovaWeapon { get; set; }

		public Weapon IceNovaWeapon { get; set; }

		public Weapon FearNovaWeapon { get; set; }

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public float MeatInterval()
		{
			return 0f;
		}

		public override void AfterFullInitialization()
		{
		}

		public override void LevelUp()
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		[Command]
		public void TurnToNormal()
		{
		}

		[Command]
		public void TurnToSnow()
		{
		}

		[Command]
		public void TurnToLava()
		{
		}

		[Command]
		public void TurnToGhost(string anim)
		{
		}

		[Command]
		public void TurnToSus(string anim)
		{
		}

		private string GetSusAnimation()
		{
			return null;
		}

		private string GetGhostAnimation()
		{
			return null;
		}

		private void AddMaxHPBonus(int value)
		{
		}

		private void DebugTurnToGhost()
		{
		}

		private void DebugTurnToSus()
		{
		}
	}
}
