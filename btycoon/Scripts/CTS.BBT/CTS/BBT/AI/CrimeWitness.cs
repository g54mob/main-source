using System;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class CrimeWitness : CTSBehaviour, ILockable
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private Agent _agent;

		[field: SerializeField]
		[field: Inject(false)]
		public Vision Vision { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public event Action<Crime> CrimeDetected;

		protected override void OnEnabled()
		{
			if ((bool)Vision)
			{
				Vision.GameObjectSighted += OnGameObjectSighted;
			}
		}

		protected override void OnDisabled()
		{
			if ((bool)Vision)
			{
				Vision.GameObjectSighted -= OnGameObjectSighted;
			}
		}

		public void RestartObservingAfterCooldown(float cooldown)
		{
			_agent.Cooldowns.StartCooldown(BBTAgentTags.Oblivious, cooldown);
		}

		private void OnGameObjectSighted(GameObject p_objectSighted)
		{
			if (!ObjectLock.IsLocked() && !_agent.Cooldowns.IsOnCooldown(BBTAgentTags.Oblivious) && p_objectSighted.TryGetComponent<Crime>(out var component))
			{
				this.CrimeDetected?.Invoke(component);
			}
		}

		public bool CheckCrimesInSight()
		{
			foreach (GameObject sightedObject in Vision.SightedObjects)
			{
				if (!(sightedObject == null) && sightedObject.TryGetComponent<Crime>(out var component) && component.IsVisible && Vision.IsInSight(sightedObject.transform.position))
				{
					return true;
				}
			}
			return false;
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
