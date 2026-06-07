using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons
{
	public class ActiveAccessory : Accessory
	{
		[SerializeField]
		protected WeaponType HiddenWeaponTypeToAdd;

		[SerializeField]
		protected Weapon HiddenWeaponLinked;

		[SerializeField]
		protected bool _hasPet;

		[SerializeField]
		protected string _petSprite;

		[SerializeField]
		protected string _petAnimPrefix;

		[SerializeField]
		protected int _petAnimFrameCount;

		[SerializeField]
		protected float _petOffset;

		[SerializeField]
		protected int _framesPerSecond;

		protected override void MakeLevelOne()
		{
		}

		public virtual void AfterWeaponAdded()
		{
		}

		public override bool LevelUp(bool skipFire = false)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		private void MakePetFollower()
		{
		}
	}
}
