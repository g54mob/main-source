using System.Collections;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Sea;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class FlakCannonScript : MonoBehaviour, INpcWeaponSystem
	{
		private Transform _barrel;

		[SerializeField]
		private float _fireDelayMax = 10f;

		[SerializeField]
		private float _fireDelayMin = 2f;

		[SerializeField]
		private GameObject _flakExplosionPrefab;

		private Vector3 _lastTargetPosition;

		private Vector3 _lastTargetVelocity;

		[SerializeField]
		private float _leadMultiplier = 1f;

		[SerializeField]
		private float _maxRange = 15000f;

		[SerializeField]
		private float _minRange = 500f;

		private float _nextFireDelay = 5f;

		private Vector3? _nextTargetPosition;

		private int _positionIndex;

		private SinkableShipScript _ship;

		private float _timeUntilFire = 5f;

		[SerializeField]
		private float _volleyShellDelay = 0.05f;

		[SerializeField]
		private int _volleySize = 4;

		[SerializeField]
		private float _volleySpread = 5f;

		public bool IsArmed { get; private set; }

		public bool IsDisabled { get; private set; }

		public Vector3 Position => base.transform.position;

		public NpcTargetingSystem TargetingSystem { get; private set; }

		public void Arm()
		{
			IsArmed = true;
		}

		public void Disable()
		{
			IsDisabled = true;
		}

		public void InitializeTargetingSystem(NpcTargetingSystem targetingSystem)
		{
			TargetingSystem = targetingSystem;
		}

		protected virtual void Start()
		{
			_barrel = Utilities.FindFirstGameObjectMyselfOrChildren("TurretBarrel", base.gameObject).transform;
			_nextFireDelay = Random.Range(_fireDelayMin, _fireDelayMax);
			_timeUntilFire = _nextFireDelay;
			_ship = GetComponentInParent<SinkableShipScript>();
		}

		protected virtual void Update()
		{
			if (IsDisabled || !IsArmed || (_ship != null && _ship.IsCriticallyDamaged))
			{
				return;
			}
			TrackedTarget currentTarget = TargetingSystem.CurrentTarget;
			if (currentTarget == null)
			{
				return;
			}
			base.transform.LookAt(new Vector3(currentTarget.Target.Position.x, base.transform.position.y, currentTarget.Target.Position.z), Vector3.up);
			_barrel.LookAt(currentTarget.Target.Position, Vector3.up);
			if (currentTarget.Occluded || currentTarget.Target.IsDead)
			{
				_timeUntilFire = _fireDelayMax;
				_lastTargetPosition = Utility.ConvertFloatingOriginToAbsolutePosition(currentTarget.Target.Position);
				_lastTargetVelocity = currentTarget.Target.Velocity;
				_nextTargetPosition = _lastTargetPosition;
			}
			if (_timeUntilFire <= 0f)
			{
				float num = Vector3.Distance(base.transform.position, currentTarget.Target.Position);
				float maxRange = _maxRange;
				if (_nextTargetPosition.HasValue && num < maxRange && num > _minRange)
				{
					float num2 = Mathf.Max(_volleySpread, _volleySpread * Mathf.Lerp(0f, 5f, num / maxRange));
					Vector3 approximateGlobalLocation = _nextTargetPosition.Value + _lastTargetVelocity.normalized * (num2 * 0.75f);
					if (approximateGlobalLocation.y < GameWorld.Instance.FloatingOriginSeaLevel)
					{
						approximateGlobalLocation.y = GameWorld.Instance.FloatingOriginSeaLevel.Value + Random.Range(25f, 500f);
					}
					StartCoroutine(FireVolley(approximateGlobalLocation, _volleySize, num2, _volleyShellDelay));
				}
				Vector3 vector = Utility.ConvertFloatingOriginToAbsolutePosition(currentTarget.Target.Position);
				Vector3 vector2 = (vector - _lastTargetPosition) / _nextFireDelay;
				Vector3 vector3 = _lastTargetVelocity - vector2;
				vector3 = -vector3 * Time.deltaTime;
				vector2 += vector3;
				_lastTargetVelocity = vector2;
				float num3 = Mathf.Lerp(1f, 3f, (num - 4000f) / (_maxRange - 4000f));
				_nextFireDelay = Random.Range(_fireDelayMin, _fireDelayMax);
				_nextTargetPosition = vector + vector2 * (_leadMultiplier * num3) * _nextFireDelay;
				_timeUntilFire = _nextFireDelay;
				_lastTargetPosition = vector;
			}
			else
			{
				_timeUntilFire -= Time.deltaTime;
			}
		}

		private void FireShell(Vector3 globalLocation)
		{
			if (!((double)globalLocation.y <= (double?)GameWorld.Instance.SeaLevel + 5.0))
			{
				Vector3 position = Utility.ConvertAbsoluteToFloatingOriginPosition(globalLocation);
				Object.Instantiate(_flakExplosionPrefab, position, Quaternion.identity).SetActive(value: true);
			}
		}

		private IEnumerator FireVolley(Vector3 approximateGlobalLocation, int volleySize = 4, float spread = 2.5f, float shellDelay = 0.05f)
		{
			for (int i = 0; i < volleySize; i++)
			{
				FireShell(approximateGlobalLocation + Random.insideUnitSphere * spread);
				yield return new WaitForSeconds(shellDelay);
			}
		}
	}
}
