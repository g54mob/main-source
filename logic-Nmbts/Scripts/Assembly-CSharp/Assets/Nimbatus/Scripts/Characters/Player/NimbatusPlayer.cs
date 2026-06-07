using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Characters.Player
{
	public class NimbatusPlayer : NimbatusObject
	{
		public NimbatusDrone Drone;

		internal Vector3 StartPosition;

		protected override void Awake()
		{
			base.Awake();
			RuntimeGlobals.NimbatusPlayer = this;
		}

		protected override void Start()
		{
			base.Start();
			Rigidbody.isKinematic = true;
			StartPosition = base.transform.position;
			Drone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone);
		}

		public override void WakeUp()
		{
			base.WakeUp();
			StartCoroutine(WakeUpRigidbody());
		}

		private IEnumerator WakeUpRigidbody()
		{
			if (RunningModeSpecifics.Has(ERunningModeSpecific.GenerateTerrain))
			{
				yield return new WaitForSeconds(0.5f);
				RuntimeGlobals.Camera.FocusTarget = true;
				yield return new WaitForSeconds(1f);
			}
			else
			{
				RuntimeGlobals.Camera.FocusTarget = true;
			}
			Drone.ActivatePhysics();
			Rigidbody.isKinematic = false;
			Rigidbody.WakeUp();
		}

		public void Sleep()
		{
			Rigidbody.isKinematic = true;
		}
	}
}
