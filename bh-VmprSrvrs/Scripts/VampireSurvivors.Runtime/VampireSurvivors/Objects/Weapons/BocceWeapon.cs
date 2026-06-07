using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class BocceWeapon : Weapon
	{
		protected int _radius;

		protected string _orbFrame;

		private SpriteRenderer _image;

		private MultiTargetTween _imageTween;

		private List<SpriteRenderer> _orbs;

		private List<float> _angles;

		private float _angleUnit;

		private List<float> _anglesMul;

		public float _Alpha;

		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
