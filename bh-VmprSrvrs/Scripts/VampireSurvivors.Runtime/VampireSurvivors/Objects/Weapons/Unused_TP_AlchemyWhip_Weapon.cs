using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_TP_AlchemyWhip_Weapon : Weapon
	{
		private int _iterations;

		private int _totalNodes;

		private float _nodeDistance;

		private Vector2 _gravity;

		private Vector2 _whipForce;

		private VerletNode[] _nodes;

		private Projectile[] _whipProjectiles;

		private List<float2> _whipFireList;

		private float _flipNum;

		private float _tempArea;

		private Timer _resetFireTimer;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void updateScale()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void shiftWhipForce(int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Simulate()
		{
		}

		private void ApplyConstraints()
		{
		}
	}
}
