using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class Crime : CTSBehaviour, IVisible, IObject, ILockable
	{
		[SerializeField]
		public bool DestroyOnDisable = true;

		public ECriminalActs CriminalAct;

		public Transform Transform => base.transform;

		public bool IsVisible { get; private set; } = true;

		public Action WasSeen { get; set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public float AlertDurationMultiplicator { get; private set; } = 1f;

		public int CredibilityMultiplier { get; private set; } = 1;

		public bool IsTemporary { get; private set; }

		public static Crime CreateCrime(Vector3 p_worldPosition, float p_alertDurationMultiplicator = 1f, ECriminalActs p_criminalAct = ECriminalActs.None, int p_credibilityMultiplicator = 1, Transform p_parent = null)
		{
			GameObject obj = new GameObject("Crime");
			obj.transform.parent = p_parent;
			obj.transform.position = p_worldPosition + Vector3.up;
			obj.layer = 17;
			obj.AddComponent<SphereCollider>().radius = 0.2f;
			Crime crime = obj.AddComponent<Crime>();
			crime.InitializeCrime(p_alertDurationMultiplicator, p_criminalAct, p_credibilityMultiplicator);
			return crime;
		}

		public void InitializeCrime(float p_alertDurationMultiplicator, ECriminalActs p_criminalAct, int p_credibilityMultiplicator)
		{
			AlertDurationMultiplicator = p_alertDurationMultiplicator;
			CriminalAct = p_criminalAct;
			CredibilityMultiplier = p_credibilityMultiplicator;
			IsTemporary = true;
		}

		protected override void OnEnabled()
		{
			Crimes.AddCrime(this);
		}

		protected override void OnDisabled()
		{
			if (DestroyOnDisable)
			{
				DestroyCrime();
			}
			Crimes.RemoveCrime(this);
		}

		public void DestroyCrime()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		void ILockable.OnLocked()
		{
			IsVisible = false;
		}

		void ILockable.OnUnlocked()
		{
			IsVisible = true;
		}
	}
}
