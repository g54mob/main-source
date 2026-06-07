using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	[RequireComponent(typeof(Collider))]
	public class RaceBooster : RaceTrigger
	{
		public EBoostModes BoostMode;

		[ShowIf("BoostMode", EBoostModes.Forward, true)]
		public float BoostForward = 50f;

		[ShowIf("BoostMode", EBoostModes.BoostThrusters, true)]
		public float BoostThrusters = 20f;

		[ShowIf("BoostMode", EBoostModes.BoostThrusters, true)]
		public float BoostTime = 1f;

		[ShowIf("BoostMode", EBoostModes.Backward, true)]
		public float BoostBackward = 50f;

		[ShowIf("BoostMode", EBoostModes.SlowDown, true)]
		public float SlowDownSpeed = 20f;

		[ShowIf("BoostMode", EBoostModes.SlowDown, true)]
		public float SlowDownHarshness = 0.1f;

		public string AudioLoop;

		private RaceBoosterManager _boosterManager;

		private readonly List<DronePart> _rootParts = new List<DronePart>();

		protected override void Start()
		{
			base.Start();
			switch (BoostMode)
			{
			case EBoostModes.Forward:
				base.gameObject.layer = 17;
				break;
			case EBoostModes.Backward:
				base.gameObject.layer = 18;
				break;
			case EBoostModes.SlowDown:
				base.gameObject.layer = 18;
				break;
			case EBoostModes.BoostThrusters:
				if (RaceBoosterManager.Instance != null)
				{
					_boosterManager = RaceBoosterManager.Instance;
					base.gameObject.layer = 17;
					break;
				}
				throw new Exception("Add RaceBoostermanager to scene");
			}
		}

		public void FixedUpdate()
		{
			_rootParts.Clear();
			if (Colliders.Count > 0)
			{
				GetComponentInChildren<Renderer>().material.SetFloat("_AcceleratorActivated", 1f);
				GetComponentInChildren<Renderer>().material.SetFloat("_DeceleratorActivated", 1f);
				StartSoundLoop(AudioLoop);
			}
			else
			{
				GetComponentInChildren<Renderer>().material.SetFloat("_AcceleratorActivated", 0f);
				GetComponentInChildren<Renderer>().material.SetFloat("_DeceleratorActivated", 0f);
				StopSoundLoop();
			}
		}

		public void OnTriggerStay(Collider other)
		{
			if (other.isTrigger)
			{
				return;
			}
			DronePart rootPart = GetRootPart(other);
			if (rootPart == null)
			{
				return;
			}
			Rigidbody rigidbody = rootPart.Rigidbody;
			switch (BoostMode)
			{
			case EBoostModes.Forward:
				rigidbody.AddForceAtPosition(base.transform.up * Mathf.Abs(BoostForward), rootPart.GetCenterOfMass(), ForceMode.Force);
				break;
			case EBoostModes.Backward:
				rigidbody.AddForceAtPosition(base.transform.up * (0f - Mathf.Abs(BoostBackward)), rootPart.GetCenterOfMass(), ForceMode.Force);
				break;
			case EBoostModes.SlowDown:
				if (rigidbody.velocity.magnitude > SlowDownSpeed)
				{
					rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, rigidbody.velocity.normalized * SlowDownSpeed, SlowDownHarshness);
					rigidbody.angularVelocity = Vector3.Lerp(rigidbody.angularVelocity, Vector3.zero, SlowDownHarshness);
				}
				break;
			case EBoostModes.BoostThrusters:
				if (_rootParts.Contains(rootPart))
				{
					break;
				}
				_rootParts.Add(rootPart);
				{
					foreach (DronePart item in rootPart.Children.Where((DronePart c) => c is IThruster).ToList())
					{
						_boosterManager.TryAddThrust(item as IThruster, BoostThrusters, BoostTime, rootPart);
					}
					break;
				}
			}
		}

		private DronePart GetRootPart(Collider other)
		{
			DronePart dronePart = other.GetComponent<DronePart>();
			if (dronePart == null)
			{
				return null;
			}
			while (dronePart.ParentDronePart != null)
			{
				dronePart = dronePart.ParentDronePart;
			}
			return dronePart;
		}
	}
}
