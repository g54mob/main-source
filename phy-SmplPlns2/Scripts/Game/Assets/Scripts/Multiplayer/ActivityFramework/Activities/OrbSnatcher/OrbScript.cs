using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.OrbSnatcher
{
	public class OrbScript : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker AttachToLocalPlayer = new ProfilerMarker("OrbScript.AttachToLocalPlayer");

			public static readonly ProfilerMarker DetachFromLocalPlayer = new ProfilerMarker("OrbScript.DetachFromLocalPlayer");

			public static readonly ProfilerMarker OnChainDestroyed = new ProfilerMarker("OrbScript.OnChainDestroyed");

			public static readonly ProfilerMarker OnOrbOwnerChanged = new ProfilerMarker("OrbScript.OnOrbOwnerChanged");

			public static readonly ProfilerMarker OnTriggerEnter = new ProfilerMarker("OrbScript.OnTriggerEnter");

			public static readonly ProfilerMarker Update = new ProfilerMarker("OrbScript.Update");
		}

		public const float DefaultGrabCooldown = 5f;

		private AircraftScript _aircraft;

		private OrbChainScript _chain;

		[SerializeField]
		private bool _enableLogging;

		[SerializeField]
		private Material _grabbedMaterial;

		private float _grabCooldown;

		private Material _initialMaterial;

		private ConfigurableJoint _joint;

		private MeshRenderer _meshRenderer;

		public OrbSnatcherActivityScript Activity { get; private set; }

		public int OrbId { get; private set; }

		public NetworkedActivityPlayer Owner { get; private set; }

		public Rigidbody Rigidbody { get; private set; }

		public Transform Transform { get; private set; }

		private Material CurrentMaterial
		{
			get
			{
				return _meshRenderer.sharedMaterial;
			}
			set
			{
				_meshRenderer.sharedMaterial = value;
			}
		}

		public void DetachFromLocalPlayer(bool includeChainedOrbs)
		{
			using (Profile.DetachFromLocalPlayer.Auto())
			{
				if (_enableLogging)
				{
					Debug.Log($"Detaching orb '{OrbId}' from player '{Owner?.Name}'");
				}
				if (_chain != null)
				{
					int num = _chain.Orbs.IndexOf(this);
					if (num < 0)
					{
						Debug.LogError($"Unable to detach orb '{OrbId}' from the local player's orb chain. " + "The orb could not be found in the orb chain for player '" + Owner?.Name + "'.");
					}
					else if (includeChainedOrbs && _chain.Orbs.Count > num + 1)
					{
						_chain.Orbs[num + 1].DetachFromLocalPlayer(includeChainedOrbs);
					}
					_chain.Orbs.RemoveAt(num);
					_chain = null;
				}
				if (Owner != null)
				{
					if (_enableLogging)
					{
						Debug.Log($"Orb '{OrbId}' detached from player '{Owner?.Name}'");
					}
					Owner = null;
				}
				if (_aircraft != null)
				{
					_aircraft.BodyRemoved -= OnAircraftBodyRemoved;
					_aircraft = null;
				}
				if (_joint != null)
				{
					Object.Destroy(_joint);
					_joint = null;
				}
			}
		}

		public void Initialize(OrbSnatcherActivityScript activity, int id, float orbScale)
		{
			Activity = activity;
			OrbId = id;
			base.transform.localScale *= orbScale;
			Transform = base.transform;
			Rigidbody = GetComponent<Rigidbody>();
			_meshRenderer = GetComponentInChildren<MeshRenderer>();
			_initialMaterial = CurrentMaterial;
		}

		public void OnChainDestroyed()
		{
			using (Profile.OnChainDestroyed.Auto())
			{
				if (!(_chain != null) || !Owner.Player.IsLocal)
				{
					return;
				}
				OrbSnatcherActivityScript activity = Activity;
				if ((object)activity == null || activity.State != NetworkedActivityState.Started)
				{
					return;
				}
				int num = _chain.Orbs.IndexOf(this);
				if (num < 0)
				{
					Debug.LogError($"Orb '{OrbId}' could not be found in the orb chain for local player '{Owner?.Name}'.");
					return;
				}
				if (_chain.Orbs.Count > num + 1)
				{
					_chain.Orbs[num + 1].OnChainDestroyed();
				}
				Activity.ChangeOrbOwner(this, null);
			}
		}

		public void OnOrbOwnerChanged(NetworkedActivityPlayer player)
		{
			using (Profile.OnOrbOwnerChanged.Auto())
			{
				NetworkedActivityPlayer owner = Owner;
				if (owner == player)
				{
					return;
				}
				if (owner != null && owner.Player.IsLocal)
				{
					if (_chain != null)
					{
						int num = _chain.Orbs.IndexOf(this);
						OrbScript orbScript = ((_chain.Orbs.Count > num + 1) ? _chain.Orbs[num + 1] : null);
						if (orbScript != null)
						{
							if (orbScript._grabCooldown > 0f)
							{
								orbScript.RebuildJointToCraft();
							}
							else
							{
								Activity.ChangeOrbOwner(orbScript, player);
							}
						}
					}
					DetachFromLocalPlayer(includeChainedOrbs: false);
				}
				if (owner != null && player != null)
				{
					Activity.RegisterPendingOrbTheftNotification(owner.PlayerId, player.PlayerId);
				}
				Owner = null;
				if (player != null)
				{
					if (_enableLogging)
					{
						Debug.Log($"Orb {OrbId} is now owned by player '{player?.Name}'");
					}
					if (player.Player.IsLocal)
					{
						AircraftScript aircraft = player.Player.Aircraft;
						if (aircraft != null)
						{
							AttachToLocalPlayer(aircraft, player);
						}
						if (player.Player.IsPrimaryLocal)
						{
							int num2 = _chain?.Orbs.Count ?? 0;
							if (num2 > 0)
							{
								string message = ((num2 == 1) ? "You grabbed an orb!" : $"You grabbed another orb! You have {num2} orbs now!");
								FlightSceneScript.Instance.FlightUI.ShowMessage(message, 7f, highlighted: true);
							}
						}
					}
					_grabCooldown = 5f;
					CurrentMaterial = _grabbedMaterial;
				}
				else
				{
					if (_enableLogging)
					{
						Debug.Log($"Orb {OrbId} is now owned by nobody");
					}
					_grabCooldown = 0f;
					CurrentMaterial = _initialMaterial;
				}
				Owner = player;
			}
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			using (Profile.OnTriggerEnter.Auto())
			{
				if (_grabCooldown > 0f)
				{
					return;
				}
				AircraftScript componentInParent = other.GetComponentInParent<AircraftScript>();
				if (componentInParent == null || !componentInParent.NetworkAircraft.IsOwner || _aircraft == componentInParent)
				{
					return;
				}
				NetworkedActivityPlayer networkedActivityPlayer = ((componentInParent.Player == null) ? null : Activity?.GetPlayer(componentInParent.Player));
				if (networkedActivityPlayer != null && networkedActivityPlayer.State == NetworkedActivityPlayerState.Playing)
				{
					if (!componentInParent.CriticallyDamaged)
					{
						Activity.ChangeOrbOwner(this, networkedActivityPlayer);
					}
					else
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("You are too damaged to grab any more orbs", 7f, highlighted: true);
					}
				}
			}
		}

		protected virtual void Update()
		{
			using (Profile.Update.Auto())
			{
				_grabCooldown = Mathf.Max(0f, _grabCooldown - Time.deltaTime);
			}
		}

		private static ConfigurableJoint CreateJoint(Rigidbody jointBody, Vector3 jointPosition, Vector3 jointAxis, Vector3 secondaryAxis, Rigidbody connectedBody, Vector3 connectedPosition, float jointForce)
		{
			ConfigurableJoint configurableJoint = jointBody.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = connectedBody;
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.axis = jointAxis;
			configurableJoint.secondaryAxis = secondaryAxis;
			configurableJoint.anchor = jointBody.transform.InverseTransformPoint(jointPosition);
			configurableJoint.connectedAnchor = connectedBody.transform.InverseTransformPoint(connectedPosition);
			configurableJoint.enableCollision = true;
			JointDrive jointDrive = new JointDrive
			{
				maximumForce = 0f,
				positionSpring = 0f,
				positionDamper = 0f
			};
			configurableJoint.linearLimitSpring = new SoftJointLimitSpring
			{
				damper = 1f,
				spring = 10f
			};
			SoftJointLimit linearLimit = configurableJoint.linearLimit;
			linearLimit.limit = 15f;
			configurableJoint.linearLimit = linearLimit;
			configurableJoint.xDrive = jointDrive;
			configurableJoint.yDrive = jointDrive;
			configurableJoint.zDrive = jointDrive;
			configurableJoint.angularXDrive = jointDrive;
			configurableJoint.angularYZDrive = jointDrive;
			configurableJoint.xMotion = ConfigurableJointMotion.Limited;
			configurableJoint.yMotion = ConfigurableJointMotion.Limited;
			configurableJoint.zMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
			return configurableJoint;
		}

		private void AttachToLocalPlayer(AircraftScript aircraft, NetworkedActivityPlayer player)
		{
			using (Profile.AttachToLocalPlayer.Auto())
			{
				if (_enableLogging)
				{
					Debug.Log($"Attaching orb '{OrbId}' to player '{player.Name}'");
				}
				if (Owner != null)
				{
					Debug.LogError($"Orb '{OrbId}' is already owned by local player '{Owner?.Name}'");
					return;
				}
				if (_aircraft != null)
				{
					Debug.LogError($"Orb '{OrbId}' is already attached to player '{_aircraft.Player?.Name}'");
					return;
				}
				_aircraft = aircraft;
				aircraft.BodyRemoved += OnAircraftBodyRemoved;
				if (!aircraft.TryGetComponent<OrbChainScript>(out var component))
				{
					component = aircraft.gameObject.AddComponent<OrbChainScript>();
				}
				_chain = component;
				Rigidbody rigidbody = aircraft.Bodies[0].RigidBody.PhysxRigidBody;
				if (component.Orbs.Count > 0)
				{
					rigidbody = component.Orbs.Last().Rigidbody ?? rigidbody;
				}
				if (_chain.Orbs.Contains(this))
				{
					Debug.LogError($"Orb '{OrbId}' is already part of the orb chain for player '{player.Name}'");
					return;
				}
				_joint = CreateJoint(rigidbody, rigidbody.transform.position, rigidbody.transform.InverseTransformDirection(base.transform.up), rigidbody.transform.InverseTransformDirection(base.transform.right), Rigidbody, base.transform.position, 50f);
				_chain.Orbs.Add(this);
				if (_enableLogging)
				{
					Debug.Log($"Orb '{OrbId}' attached to player '{player.Name}'");
				}
			}
		}

		private void OnAircraftBodyRemoved(BodyScript bodyScript)
		{
			Activity.ChangeOrbOwner(this, null);
		}

		private void RebuildJointToCraft()
		{
			if (_enableLogging)
			{
				Debug.Log($"Rebuilding joint to craft for orb '{OrbId}' and player '{Owner?.Name}'");
			}
			if (_joint != null)
			{
				Object.Destroy(_joint);
				_joint = null;
			}
			if (_aircraft == null)
			{
				Debug.LogError("Unable to rebuild orb joint to its craft because its current craft reference is null");
				return;
			}
			Rigidbody physxRigidBody = _aircraft.Bodies[0].RigidBody.PhysxRigidBody;
			_joint = CreateJoint(physxRigidBody, physxRigidBody.transform.position, physxRigidBody.transform.InverseTransformDirection(base.transform.up), physxRigidBody.transform.InverseTransformDirection(base.transform.right), Rigidbody, base.transform.position, 50f);
		}
	}
}
