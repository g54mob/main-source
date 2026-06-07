using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Radar
{
	public class EnemyRadar : SerializedMonoBehaviour
	{
		public float MaxPersistentDistance = 120f;

		public LayerMask LayerMask = 512;

		public LayerMask FriendlyLayerMask = 4096;

		[HideInInspector]
		public readonly List<Transform> Targets = new List<Transform>();

		private Transform _nearestTarget;

		[HideInInspector]
		private readonly List<Rigidbody> _friendlyUnits = new List<Rigidbody>();

		private bool _inCombat;

		[HideInInspector]
		public Vector3 FriendlyFlockVelocity { get; private set; }

		[HideInInspector]
		public Vector3 FriendlyFlockCenter { get; private set; }

		[HideInInspector]
		public bool HasFriendlyUnits
		{
			get
			{
				return _friendlyUnits.Count > 1;
			}
		}

		[HideInInspector]
		public Transform NearestTarget
		{
			get
			{
				if (_nearestTarget == null && Targets.Count > 0)
				{
					Targets.RemoveAll((Transform t) => t == null);
					_nearestTarget = Targets.FirstOrDefault();
				}
				return _nearestTarget;
			}
			private set
			{
				_nearestTarget = value;
				if (_nearestTarget != null)
				{
					Action action = this.OnTargetFound;
					if (action != null)
					{
						action();
					}
				}
				else
				{
					Action action2 = this.OnTargetLost;
					if (action2 != null)
					{
						action2();
					}
				}
			}
		}

		public event Action OnTargetFound;

		public event Action OnTargetLost;

		public void SetFocusTarget(Transform target)
		{
			NearestTarget = target;
		}

		public void Start()
		{
			StartCoroutine(CheckDistance());
			StartCoroutine(CheckCombat());
			StartCoroutine(UpdateFlock());
		}

		public void AddFriendlyUnit(Rigidbody r)
		{
			_friendlyUnits.Add(r);
		}

		public void OnDisable()
		{
			if (_inCombat)
			{
				if (WorldController.PlanetMusic != null)
				{
					WorldController.PlanetMusic.EnemyCount--;
				}
				_inCombat = false;
			}
		}

		public IEnumerator CheckCombat()
		{
			while (true)
			{
				bool flag = false;
				if (NearestTarget != null)
				{
					flag = TransformHelper.IsInsideCameraViewport(RuntimeGlobals.MainCamera, NearestTarget.position, 0.1f);
				}
				if (!_inCombat && flag && NearestTarget != null)
				{
					if (WorldController.PlanetMusic != null)
					{
						WorldController.PlanetMusic.EnemyCount++;
					}
					_inCombat = true;
				}
				if (_inCombat && (!flag || NearestTarget == null))
				{
					if (WorldController.PlanetMusic != null)
					{
						WorldController.PlanetMusic.EnemyCount--;
					}
					_inCombat = false;
				}
				yield return new WaitForSeconds(0.1f);
			}
		}

		public IEnumerator CheckDistance()
		{
			while (true)
			{
				if (NearestTarget != null && (NearestTarget.gameObject == null || Vector2.Distance(NearestTarget.position, base.transform.position) > MaxPersistentDistance))
				{
					NearestTarget = Targets.FirstOrDefault();
				}
				yield return new WaitForSeconds(1f);
			}
		}

		public IEnumerator UpdateFlock()
		{
			while (true)
			{
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				_friendlyUnits.RemoveAll((Rigidbody f) => f == null);
				if (_friendlyUnits != null && _friendlyUnits.Count > 0)
				{
					foreach (Rigidbody friendlyUnit in _friendlyUnits)
					{
						if (friendlyUnit != null)
						{
							zero += friendlyUnit.transform.position;
							zero2 += friendlyUnit.velocity;
						}
					}
					FriendlyFlockCenter = zero / _friendlyUnits.Count;
					FriendlyFlockVelocity = zero2 / _friendlyUnits.Count;
				}
				yield return new WaitForSeconds(0.1f);
			}
		}

		public void OnTriggerEnter(Collider col)
		{
			if (PhysicsHelper.IsLayer(LayerMask, col.gameObject.layer))
			{
				if (NearestTarget != null)
				{
					float num = Vector2.Distance(base.transform.position, col.transform.position);
					float num2 = Vector2.Distance(base.transform.position, NearestTarget.position);
					if (num < num2)
					{
						NearestTarget = col.transform;
					}
				}
				else
				{
					NearestTarget = col.transform;
				}
				Targets.Add(col.transform);
			}
			else if (PhysicsHelper.IsLayer(FriendlyLayerMask, col.gameObject.layer) && col.attachedRigidbody != null)
			{
				_friendlyUnits.Add(col.attachedRigidbody);
			}
		}

		public void OnTriggerExit(Collider col)
		{
			if (PhysicsHelper.IsLayer(LayerMask, col.gameObject.layer))
			{
				Targets.Remove(col.transform);
				if (NearestTarget == col.transform && (NearestTarget.gameObject == null || Vector2.Distance(NearestTarget.position, base.transform.position) > MaxPersistentDistance))
				{
					NearestTarget = Targets.FirstOrDefault();
				}
			}
			else if (PhysicsHelper.IsLayer(FriendlyLayerMask, col.gameObject.layer) && col.attachedRigidbody != null)
			{
				_friendlyUnits.Remove(col.attachedRigidbody);
			}
		}

		public void Clear()
		{
			_friendlyUnits.Clear();
			Targets.Clear();
		}
	}
}
