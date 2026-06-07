using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.Combat;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class BodyConfigurationState
	{
		public class BodyIsland
		{
			public List<BodyScript> Bodies { get; private set; } = new List<BodyScript>();

			public BodyScript Root { get; set; }
		}

		private static class Profile
		{
			public static readonly ProfilerMarker CheckIfBodyIslandIsDebris = new ProfilerMarker("BodyConfigurationState.CheckIfBodyIslandIsDebris");

			public static readonly ProfilerMarker CreateBodyIsland = new ProfilerMarker("BodyConfigurationState.CreateBodyIsland");

			public static readonly ProfilerMarker GenerateMessage = new ProfilerMarker("BodyConfigurationState.GenerateMessage");

			public static readonly ProfilerMarker UpdateAircraftFromMessage = new ProfilerMarker("BodyConfigurationState.UpdateAircraftFromMessage");
		}

		private AircraftScript _aircraft;

		private List<int> _deadBodies = new List<int>();

		private List<int> _newBodies = new List<int>();

		private int _state;

		private RelativeVelocityZoneScript _zone;

		public List<BodyIsland> BodyIslands { get; private set; } = new List<BodyIsland>();

		public bool Changed { get; private set; }

		public bool IsOwner { get; }

		public int State => _state;

		public BodyConfigurationState(AircraftScript aircraft, RelativeVelocityZoneScript zone)
		{
			_aircraft = aircraft;
			_zone = zone;
			_aircraft.BodyCreated += OnBodyCreated;
			_aircraft.BodyRemoved += OnBodyRemoved;
			_aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
		}

		public BodyConfigurationMessage GenerateMessage(NetworkAircraftScript netAircraft)
		{
			using (Profile.GenerateMessage.Auto())
			{
				AircraftScript aircraftScript = netAircraft.AircraftScript;
				if (Changed)
				{
					BuildBodyIslandList(aircraftScript);
					Changed = false;
				}
				BodyConfigurationMessage bodyConfigurationMessage = new BodyConfigurationMessage();
				bodyConfigurationMessage.State = _state;
				bodyConfigurationMessage.DeadBodies.AddRange(_deadBodies);
				foreach (int newBody in _newBodies)
				{
					BodyScript body = aircraftScript.GetBody(newBody);
					if (body != null)
					{
						BodyConfigurationMessage.BodyInfo bodyInfo = new BodyConfigurationMessage.BodyInfo();
						bodyConfigurationMessage.NewBodies.Add(bodyInfo);
						bodyInfo.Id = body.Id;
						foreach (PartGroupScript partGroup in body.PartGroups)
						{
							BodyConfigurationMessage.PartGroupInfo partGroupInfo = new BodyConfigurationMessage.PartGroupInfo();
							partGroupInfo.Id = partGroup.Id;
							partGroupInfo.LocalRotation = partGroup.transform.localEulerAngles;
							partGroupInfo.LocalPosition = partGroup.transform.localPosition;
							bodyInfo.PartGroups.Add(partGroupInfo);
						}
					}
					else
					{
						Debug.LogError($"Could not find body with id {newBody}");
					}
				}
				foreach (BodyIsland bodyIsland in BodyIslands)
				{
					BodyConfigurationMessage.BodyIslandInfo bodyIslandInfo = new BodyConfigurationMessage.BodyIslandInfo();
					bodyIslandInfo.RootId = bodyIsland.Root.Id;
					bodyIslandInfo.IsDebris = bodyIsland.Root.IsDebris;
					foreach (BodyScript body2 in bodyIsland.Bodies)
					{
						bodyIslandInfo.Bodies.Add(new BodyConfigurationMessage.BodyIslandInfo.SubBodyInfo(body2.Id, body2.SyncData.ParentBody.Id));
					}
					bodyConfigurationMessage.BodyIslands.Add(bodyIslandInfo);
				}
				return bodyConfigurationMessage;
			}
		}

		public void MarkAsChanged()
		{
			if (!Changed)
			{
				_state++;
				Changed = true;
			}
		}

		public void UpdateAircraftFromMessage(NetworkAircraftScript netAircraft, BodyConfigurationMessage message)
		{
			using (Profile.UpdateAircraftFromMessage.Auto())
			{
				AircraftScript aircraftScript = netAircraft.AircraftScript;
				foreach (BodyConfigurationMessage.BodyInfo newBody in message.NewBodies)
				{
					BodyScript body = aircraftScript.GetBody(newBody.Id);
					if (!(body == null))
					{
						continue;
					}
					RigidBodyGroup rigidBodyGroup = new RigidBodyGroup();
					foreach (BodyConfigurationMessage.PartGroupInfo partGroup2 in newBody.PartGroups)
					{
						foreach (PartScript part in aircraftScript.GetPartGroup(partGroup2.Id).Parts)
						{
							rigidBodyGroup.Parts.Add(part.Part);
						}
					}
					body = BodyScript.MoveExistingPartsToNewBody(aircraftScript, rigidBodyGroup);
					foreach (BodyConfigurationMessage.PartGroupInfo partGroup3 in newBody.PartGroups)
					{
						PartGroupScript partGroup = aircraftScript.GetPartGroup(partGroup3.Id);
						partGroup.transform.localPosition = partGroup3.LocalPosition;
						partGroup.transform.localRotation = Quaternion.Euler(partGroup3.LocalRotation);
					}
					if (body.Id != newBody.Id)
					{
						body.Id = newBody.Id;
						body.gameObject.name = $"Body {body.Id} - Mismatched";
					}
				}
				foreach (int deadBody in message.DeadBodies)
				{
					BodyScript body2 = aircraftScript.GetBody(deadBody);
					if (body2 != null)
					{
						body2.SetParentBody(null, null, remoteCraft: true);
						body2.gameObject.name = $"Remote Dead Body {deadBody}";
						body2.gameObject.SetActive(value: false);
					}
				}
				foreach (BodyConfigurationMessage.BodyIslandInfo bodyIsland in message.BodyIslands)
				{
					BodyScript body3 = aircraftScript.GetBody(bodyIsland.RootId);
					body3.SetParentBody(null, null, remoteCraft: true);
					body3.IsDebris = bodyIsland.IsDebris;
					body3.RigidBody.isKinematic = false;
					body3.RigidBody.useGravity = bodyIsland.IsDebris;
					body3.RigidBody.automaticCenterOfMass = false;
					body3.RigidBody.drag = 0f;
					body3.RigidBody.angularDrag = 0f;
					float num = body3.InitialMass;
					foreach (BodyConfigurationMessage.BodyIslandInfo.SubBodyInfo body7 in bodyIsland.Bodies)
					{
						BodyScript body4 = aircraftScript.GetBody(body7.Id);
						BodyScript body5 = aircraftScript.GetBody(body7.ParentId);
						body4.SetParentBody(body5, body3, remoteCraft: true);
						num += body4.InitialMass;
					}
					body3.RigidBody.mass = num;
				}
				aircraftScript.AircraftStructureChanged();
				BodyScript body6 = aircraftScript.GetBody(message.BodyIslands[0].RootId);
				ConfigureRelativeVelocityZone(body6);
			}
		}

		private static bool CheckIfBodyIslandIsDebris(BodyIsland bodyIsland)
		{
			using (Profile.CheckIfBodyIslandIsDebris.Auto())
			{
				if (bodyIsland.Bodies.Count == 0 && bodyIsland.Root.PartGroups.Count <= 1)
				{
					if (bodyIsland.Root.Joints.Count > 0)
					{
						return false;
					}
					foreach (PartGroupScript partGroup in bodyIsland.Root.PartGroups)
					{
						foreach (PartScript part in partGroup.Parts)
						{
							if (part.GetModifierWithInterface<IWeapon>() != null)
							{
								return false;
							}
						}
					}
					return true;
				}
				return false;
			}
		}

		private void BuildBodyIslandList(AircraftScript aircraft)
		{
			List<BodyScript> list = new List<BodyScript>();
			foreach (BodyScript body in aircraft.Bodies)
			{
				body.SetParentBody(null, null, remoteCraft: false);
				list.Add(body);
			}
			list = list.OrderByDescending((BodyScript x) => x.InitialMass).ToList();
			BodyIsland bodyIsland = CreateBodyIsland(list[0], list);
			BodyIslands.Clear();
			BodyIslands.Add(bodyIsland);
			while (list.Count > 0)
			{
				BodyIsland bodyIsland2 = CreateBodyIsland(list[0], list);
				if (!bodyIsland2.Root.IsDebris)
				{
					bodyIsland2.Root.IsDebris = CheckIfBodyIslandIsDebris(bodyIsland2);
				}
				BodyIslands.Add(bodyIsland2);
			}
			ConfigureRelativeVelocityZone(bodyIsland.Root);
		}

		private void ConfigureRelativeVelocityZone(BodyScript bodyScript)
		{
			if (bodyScript?.RigidBody?.PhysxRigidBody == null)
			{
				Debug.LogError("Craft nas no main body.", _aircraft.gameObject);
			}
			else if (_zone.Rigidbody != bodyScript.RigidBody.PhysxRigidBody)
			{
				_zone.Rigidbody = bodyScript.RigidBody.PhysxRigidBody;
			}
		}

		private BodyIsland CreateBodyIsland(BodyScript firstBody, List<BodyScript> bodies)
		{
			using (Profile.CreateBodyIsland.Auto())
			{
				BodyIsland bodyIsland = new BodyIsland();
				bodyIsland.Root = firstBody;
				TraverseConnectedBodies(firstBody, bodies, bodyIsland, null);
				bodyIsland.Bodies.Remove(bodyIsland.Root);
				return bodyIsland;
			}
		}

		private void OnAircraftStructureChanged()
		{
			MarkAsChanged();
		}

		private void OnBodyCreated(BodyScript body)
		{
			if (_aircraft.GenerationComplete)
			{
				_newBodies.Add(body.Id);
				MarkAsChanged();
			}
		}

		private void OnBodyRemoved(BodyScript body)
		{
			if (_aircraft.GenerationComplete)
			{
				_newBodies.Remove(body.Id);
				_deadBodies.Add(body.Id);
				MarkAsChanged();
			}
		}

		private void TraverseConnectedBodies(BodyScript body, List<BodyScript> bodies, BodyIsland bodyIsland, BodyScript parent)
		{
			bodyIsland.Bodies.Add(body);
			body.SetParentBody(parent, null, remoteCraft: false);
			bodies.Remove(body);
			foreach (BodyJoint joint in body.Joints)
			{
				if (!joint.BodyIslandBoundary)
				{
					BodyScript bodyScript = ((body == joint.BodyA) ? joint.BodyB : joint.BodyA);
					if (bodyScript != null && bodies.Contains(bodyScript))
					{
						TraverseConnectedBodies(bodyScript, bodies, bodyIsland, body);
					}
				}
			}
		}
	}
}
