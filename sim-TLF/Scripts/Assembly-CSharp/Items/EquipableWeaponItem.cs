using Player.FSM;
using Player.RangedActions;
using Player.Weapons;
using UnityEngine;
using Zenject;

namespace Items
{
	public class EquipableWeaponItem : EquipableToolItem
	{
		[Inject]
		private IPlayerStateMachineParametersManipulator _playerFSM;

		[Header("Weapon Stats (applied to player's RocketLauncher on equip)")]
		[SerializeField]
		private RocketLauncherStatsOverride _stats = new RocketLauncherStatsOverride();

		private RocketLauncher _rocketLauncher;

		private EnemySpotter _enemySpotter;

		private void Awake()
		{
			Transform root = (_playerFSM as MonoBehaviour).transform.root;
			_rocketLauncher = root.GetComponentInChildren<RocketLauncher>(includeInactive: true);
			_enemySpotter = root.GetComponentInChildren<EnemySpotter>(includeInactive: true);
		}

		protected override void DoEquip()
		{
			ApplyStatsToLauncher();
			_enemySpotter.enabled = true;
			_rocketLauncher.enabled = true;
		}

		protected override void DoUnequip()
		{
			_enemySpotter.enabled = false;
			_rocketLauncher.enabled = false;
		}

		private void ApplyStatsToLauncher()
		{
			if (!(_rocketLauncher == null) && _stats != null && _stats.overrideStats)
			{
				if (_stats.projectilePrefab != null)
				{
					_rocketLauncher.projectilePrefab = _stats.projectilePrefab;
				}
				_rocketLauncher.initialSpeed = _stats.initialSpeed;
				_rocketLauncher.projectileMass = _stats.projectileMass;
				_rocketLauncher.gravityScale = _stats.gravityScale;
				_rocketLauncher.airDrag = _stats.airDrag;
				_rocketLauncher.angularDrag = _stats.angularDrag;
				_rocketLauncher.explosionRadius = _stats.explosionRadius;
				_rocketLauncher.explosionForce = _stats.explosionForce;
				_rocketLauncher.fireRate = _stats.fireRate;
				if (_stats.explosionEffectPrefab != null)
				{
					_rocketLauncher.explosionEffectPrefab = _stats.explosionEffectPrefab;
				}
			}
		}
	}
}
