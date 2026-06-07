using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Behaviours.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ShootWeapon : NimbatusAction
	{
		public List<WeaponSlot> Weapons = new List<WeaponSlot>();

		public float Duration;

		private bool _isShooting;

		private float _startTime;

		protected override void OnInit()
		{
			base.OnInit();
			Weapons.ForEach(delegate(WeaponSlot w)
			{
				w.Init(OwnWorldObject, 1, ShootingCheck);
			});
			OwnWorldObject.OnUpdate += OwnWorldObject_OnUpdate;
		}

		private void OwnWorldObject_OnUpdate()
		{
			if (Time.time - _startTime > Duration)
			{
				_isShooting = false;
			}
		}

		private bool ShootingCheck(EnemyWeapon weapon)
		{
			return _isShooting;
		}

		protected override void OnRelease()
		{
			base.OnRelease();
			Weapons.ForEach(delegate(WeaponSlot w)
			{
				w.Release();
			});
			OwnWorldObject.OnUpdate -= OwnWorldObject_OnUpdate;
		}

		public override void Execute()
		{
			_isShooting = true;
			_startTime = Time.time;
		}
	}
}
