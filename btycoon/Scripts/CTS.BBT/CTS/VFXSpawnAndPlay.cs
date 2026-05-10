using System.Collections;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class VFXSpawnAndPlay : MonoRoutine
	{
		[SerializeField]
		private MonoRoutine _spawnPrefab;

		[SerializeField]
		private Transform _spawnTarget;

		[SerializeField]
		private Vector3 _spawnLocalOffset;

		[SerializeField]
		private Vector3 _spawnLocalRotationOffset;

		[SerializeField]
		private bool _spawnUpright;

		[SerializeField]
		private bool _parentToTarget;

		private RoomObject _parentRoomData;

		protected override string Name
		{
			get
			{
				if (!_spawnPrefab)
				{
					return "Undefined VFX";
				}
				return _spawnPrefab.name;
			}
		}

		private void Awake()
		{
			_parentRoomData = GetComponentInParent<RoomObject>();
		}

		protected override IEnumerator Routine()
		{
			MonoRoutine routine;
			if ((bool)_spawnTarget)
			{
				Quaternion rotation = _spawnTarget.rotation;
				Quaternion rotation2 = rotation * Quaternion.Euler(_spawnLocalRotationOffset);
				Vector3 position = _spawnTarget.position + rotation * _spawnLocalOffset;
				routine = Object.Instantiate(_spawnPrefab, position, rotation2);
				if (_parentToTarget)
				{
					routine.transform.SetParent(_spawnTarget);
				}
			}
			else
			{
				Quaternion rotation3 = base.transform.rotation;
				Quaternion rotation4 = rotation3 * Quaternion.Euler(_spawnLocalRotationOffset);
				Vector3 position2 = base.transform.position + rotation3 * _spawnLocalOffset;
				routine = Object.Instantiate(_spawnPrefab, position2, rotation4);
			}
			RoomObject roomData = null;
			if (_parentToTarget)
			{
				if ((bool)_parentRoomData && routine.TryGetComponent<RoomObject>(out roomData))
				{
					roomData.SetParent(_parentRoomData);
				}
			}
			else if ((bool)_parentRoomData && routine.TryGetComponent<RoomObject>(out roomData))
			{
				roomData.CurrentRoom = _parentRoomData.CurrentRoom;
			}
			yield return routine.Play();
			if ((bool)roomData || TryGetComponent<RoomObject>(out roomData))
			{
				roomData.SetParent(null);
			}
			Object.Destroy(routine.gameObject);
		}

		private void OnDrawGizmosSelected()
		{
			if ((bool)_spawnTarget)
			{
				Vector3 center = _spawnTarget.position + _spawnTarget.rotation * _spawnLocalOffset;
				_ = _spawnTarget.rotation * Quaternion.Euler(_spawnLocalRotationOffset);
				Gizmos.color = new Color(1f, 1f, 1f, 0.53f);
				Gizmos.DrawSphere(center, 0.1f);
			}
		}
	}
}
