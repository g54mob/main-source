using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class PausePhysicsHandler : SingletonBehaviour<PausePhysicsHandler>
	{
		private struct RBData
		{
			public Rigidbody rb;

			public Vector3 velocity;

			public Vector3 angularVelocity;

			public bool useGravity;

			public bool isKinematic;

			public RigidbodyInterpolation rbInterpolation;

			public RBData(Rigidbody rb)
			{
				this.rb = rb;
				velocity = rb.velocity;
				angularVelocity = rb.angularVelocity;
				useGravity = rb.useGravity;
				isKinematic = rb.isKinematic;
				rbInterpolation = rb.interpolation;
			}
		}

		private HashSet<Rigidbody> registered = new HashSet<Rigidbody>();

		private List<RBData> pauseData = new List<RBData>();

		private Coroutine delayedDisabler;

		public bool PhysicsHandlingInProcess { get; private set; }

		public bool IgnorePhysicsEvents { get; private set; }

		public new static string AllowAutoCreate()
		{
			return "[PausePhysicsHandler]";
		}

		private void Start()
		{
			SetupListeners(on: true);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		public void Register(Rigidbody rb)
		{
			if (rb.isKinematic)
			{
				Debug.LogWarning("PausePhysicsHandler registered a kinematic rigidbody '" + rb.name + "'", rb);
			}
			if (!registered.Add(rb))
			{
				Debug.LogError("Trying to add rb " + rb.name + " to PausePhysicsHandler, but it is already registered!");
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused += OnPaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused += OnUnpaused;
			}
			else
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused -= OnPaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= OnUnpaused;
			}
		}

		private void OnPaused()
		{
			PhysicsHandlingInProcess = true;
			StopAllCoroutines();
			delayedDisabler = null;
			pauseData.Clear();
			IgnorePhysicsEvents = true;
			registered.RemoveWhere((Rigidbody rb) => rb == null);
			foreach (Rigidbody item2 in registered)
			{
				RBData item = new RBData(item2);
				pauseData.Add(item);
				item2.velocity = Vector3.zero;
				item2.angularVelocity = Vector3.zero;
				item2.useGravity = false;
				item2.isKinematic = true;
				item2.interpolation = RigidbodyInterpolation.None;
			}
			delayedDisabler = StartCoroutine(UnignoreTriggerEventsAfterPhysicsUpdate());
		}

		private void OnUnpaused()
		{
			StartCoroutine(RestorePrepauseRigidbodyData());
		}

		private IEnumerator RestorePrepauseRigidbodyData()
		{
			yield return null;
			if (delayedDisabler != null)
			{
				StopCoroutine(delayedDisabler);
				delayedDisabler = null;
			}
			IgnorePhysicsEvents = true;
			for (int i = 0; i < pauseData.Count; i++)
			{
				RBData rBData = pauseData[i];
				if (!(rBData.rb == null))
				{
					rBData.rb.isKinematic = rBData.isKinematic;
					rBData.rb.useGravity = rBData.useGravity;
					rBData.rb.velocity = rBData.velocity;
					rBData.rb.angularVelocity = rBData.angularVelocity;
					rBData.rb.interpolation = rBData.rbInterpolation;
				}
			}
			for (int j = 0; j < pauseData.Count; j++)
			{
				RBData rBData2 = pauseData[j];
				if (!rBData2.isKinematic && !(rBData2.rb == null))
				{
					rBData2.rb.isKinematic = true;
					rBData2.rb.isKinematic = false;
					rBData2.rb.velocity = rBData2.velocity;
					rBData2.rb.angularVelocity = rBData2.angularVelocity;
				}
			}
			delayedDisabler = StartCoroutine(UnignoreTriggerEventsAfterPhysicsUpdate());
			PhysicsHandlingInProcess = false;
			pauseData.Clear();
		}

		private IEnumerator UnignoreTriggerEventsAfterPhysicsUpdate()
		{
			yield return WaitFor.FixedUpdate;
			yield return WaitFor.EndOfFrame;
			IgnorePhysicsEvents = false;
			delayedDisabler = null;
		}
	}
}
