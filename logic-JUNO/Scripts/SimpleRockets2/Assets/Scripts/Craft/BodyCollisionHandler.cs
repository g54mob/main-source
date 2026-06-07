using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class BodyCollisionHandler : IBodyCollisionHandler
	{
		public enum CollisionResponseType
		{
			None = 0,
			Damage = 1,
			Disconnect = 2,
			Explode = 3
		}

		[Flags]
		private enum PartDisconnectFlags
		{
			None = 0,
			Explode = 1,
			DisablePart = 2,
			PlayDisconnectSound = 4,
			DefaultExplosion = 7,
			DefaultNoExplosion = 4
		}

		private class DisconnectedPart
		{
			public PartDisconnectFlags DisconnectFlags { get; set; }

			public float Force { get; set; }

			public IPartScript Part { get; set; }
		}

		private static FlightSettings _flightSettings;

		private BodyScript _bodyScript;

		private bool? _collidingWithTerrainOverrideFlag;

		private bool _collidingWithTerrainThisFrame;

		private CraftScript _craftScript;

		private Dictionary<IPartGroupScript, BodyScript> _debugCheckPartLookup;

		private List<DisconnectedPart> _disconnectParts = new List<DisconnectedPart>();

		private bool _jointBroke;

		private bool _playCollisionSound;

		private bool _playDisconnectSound;

		public static bool BodyCollisionsEnabled { get; set; }

		public bool CollidingWithTerrain { get; private set; }

		public BodyCollisionHandler(BodyScript bodyScript, CraftScript craftScript)
		{
			_bodyScript = bodyScript;
			_craftScript = craftScript;
			_flightSettings = Game.Instance.Settings.Game.Flight;
		}

		public void CollidePart(IPartFlightCollision collision)
		{
			HandleCollision(collision);
		}

		public void DisconnectPart(IPartScript part)
		{
			AddDisconnectedPart(CreateDisconnectedPart(explode: false, part));
		}

		public void ExplodePart(IPartScript part, float power)
		{
			_disconnectParts.Add(new DisconnectedPart
			{
				Part = part,
				DisconnectFlags = ((power > 0f) ? PartDisconnectFlags.DefaultExplosion : PartDisconnectFlags.DisablePart),
				Force = power
			});
		}

		public void FixedUpdate()
		{
			bool flag = _collidingWithTerrainOverrideFlag ?? _collidingWithTerrainThisFrame;
			if (CollidingWithTerrain != flag)
			{
				CollidingWithTerrain = flag;
			}
			_collidingWithTerrainThisFrame = false;
			HandleBrokenJoints();
		}

		public void OnCollisionEnter(Collision collision)
		{
			bool flag = false;
			Collider collider = null;
			Collider collider2 = null;
			for (int i = 0; i < collision.contactCount; i++)
			{
				if (flag)
				{
					break;
				}
				ContactPoint contact = collision.GetContact(i);
				if (collider != contact.thisCollider || collider2 != contact.otherCollider)
				{
					PartScript componentInParent = contact.thisCollider.GetComponentInParent<PartScript>();
					if (componentInParent != null)
					{
						PartFlightCollision partFlightCollision = new PartFlightCollision(collision, contact, componentInParent);
						flag = HandleCollision(partFlightCollision);
						_craftScript.OnPartCollisionEnter(partFlightCollision);
					}
					collider = contact.thisCollider;
					collider2 = contact.otherCollider;
				}
			}
		}

		public void OnCollisionStay(Collision collision)
		{
			if (!_bodyScript.Disconnected && Masks.IsLayerInMask(collision.gameObject.layer, 603979776))
			{
				_collidingWithTerrainThisFrame = true;
			}
		}

		public void OnJointBreak()
		{
			_jointBroke = true;
		}

		public void QueuePartGroupForDisconnect(IPartGroupScript partGroup, bool disable)
		{
			foreach (PartData part in partGroup.Data.Parts)
			{
				_disconnectParts.Add(new DisconnectedPart
				{
					Part = part.PartScript,
					DisconnectFlags = (disable ? PartDisconnectFlags.DisablePart : PartDisconnectFlags.PlayDisconnectSound),
					Force = 0f
				});
			}
		}

		public void SetCollidingWithTerrainOverrideFlag(bool? collidingWithTerrain)
		{
			_collidingWithTerrainOverrideFlag = collidingWithTerrain;
			if (collidingWithTerrain.HasValue)
			{
				CollidingWithTerrain = collidingWithTerrain.Value;
			}
		}

		public void Update()
		{
			if (_disconnectParts.Count > 0)
			{
				DisconnectParts(_disconnectParts);
				_disconnectParts.Clear();
				Physics.SyncTransforms();
			}
			if (_playCollisionSound)
			{
				_playCollisionSound = false;
				_craftScript.CraftAudio.PlayCollisionSound(_bodyScript.Transform.position);
			}
			if (_playDisconnectSound)
			{
				_playDisconnectSound = false;
				_craftScript.CraftAudio.PlayDisconnectSound(_bodyScript.Transform.position);
			}
		}

		private static DisconnectedPart CreateDisconnectedPart(bool explode, IPartScript part)
		{
			DisconnectedPart disconnectedPart = new DisconnectedPart();
			disconnectedPart.Part = part;
			if (explode)
			{
				disconnectedPart.DisconnectFlags = PartDisconnectFlags.DefaultExplosion;
				Game.Instance.FlightScene.FlightSceneUI.FlightLog.LogExplodedPart(part);
			}
			else
			{
				disconnectedPart.DisconnectFlags = PartDisconnectFlags.PlayDisconnectSound;
				Game.Instance.FlightScene.FlightSceneUI.FlightLog.LogDisconnectedPart(part);
			}
			disconnectedPart.Force = 1000f;
			return disconnectedPart;
		}

		private static CollisionResponseType GetCollisionResponse(IPartFlightCollision collision, IConfigData partConfig)
		{
			if (((float)_flightSettings.ImpactDamageScale == 0f && (!Game.IsCareer || Game.Instance.GameState.Validator.IsItemAvailable("Cheats.FlightCheats"))) || partConfig.PartCollisionResponse == PartCollisionResponseType.None || collision.Impulse <= 0f)
			{
				return CollisionResponseType.None;
			}
			CollisionResponseType result = CollisionResponseType.Damage;
			float num = Mathf.Max(10f, collision.PartScript.BodyScript.RigidBody.mass * 100f) * 0.0001f;
			if (partConfig.CollisionDisconnectImpulse >= 0f && collision.Impulse > partConfig.CollisionDisconnectImpulse * num)
			{
				if (partConfig.CanExplode && collision.Impulse > partConfig.CollisionExplodeImpulse * num)
				{
					return CollisionResponseType.Explode;
				}
				result = CollisionResponseType.Disconnect;
			}
			if (collision.IsGroundCollision)
			{
				float num2;
				switch (partConfig.CollisionVelocityMode)
				{
				case PartCollisionVelocityMode.OmniDirectional:
					num2 = collision.RelativeVelocityMagnitude;
					break;
				case PartCollisionVelocityMode.NormalOnly:
					num2 = collision.NormalVelocity;
					break;
				default:
					return result;
				}
				if (num2 > partConfig.CollisionDisconnectVelocity)
				{
					if (num2 > partConfig.CollisionExplodeVelocity && partConfig.CanExplode)
					{
						return CollisionResponseType.Explode;
					}
					return CollisionResponseType.Disconnect;
				}
			}
			return result;
		}

		private void AddDisconnectedPart(DisconnectedPart disconnectedPart)
		{
			bool flag = false;
			for (int i = 0; i < _disconnectParts.Count; i++)
			{
				if (_disconnectParts[i].Part.PartGroup == disconnectedPart.Part.PartGroup)
				{
					flag = true;
					if (_disconnectParts[i].Force < disconnectedPart.Force)
					{
						_disconnectParts[i] = disconnectedPart;
					}
				}
			}
			if (!flag)
			{
				_disconnectParts.Add(disconnectedPart);
			}
		}

		private void CreateBodyScript(List<PartData> bodyPartList, float maxSeparationTorque)
		{
			BodyData body = CraftBuilder.CreateBodyData(bodyPartList, _craftScript.Transform);
			_craftScript.Data.Assembly.AddBody(body);
			BodyScript bodyScript = CraftBuilder.CreateBodyScript(_craftScript, body, _bodyScript.Transform.localRotation);
			Dictionary<IPartGroupScript, bool> dictionary = new Dictionary<IPartGroupScript, bool>();
			foreach (PartData part in bodyScript.Data.Parts)
			{
				dictionary[part.PartScript.PartGroup] = true;
			}
			foreach (PartGroupScript key in dictionary.Keys)
			{
				bodyScript.PartGroups.Add(key);
				key.BodyScript = bodyScript;
				key.transform.SetParent(bodyScript.transform, worldPositionStays: true);
				if (_debugCheckPartLookup.ContainsKey(key))
				{
					if (_debugCheckPartLookup[key] != bodyScript)
					{
						Debug.Log("Part group has already been used in a different body script.");
					}
				}
				else
				{
					_debugCheckPartLookup[key] = bodyScript;
				}
			}
			CraftBuilder.CalculateInertiaTensors(bodyScript, finalKinematicState: false);
			bodyScript.RigidBody.velocity = _bodyScript.RigidBody.velocity;
			bodyScript.RigidBody.angularVelocity = _bodyScript.RigidBody.angularVelocity;
			bodyScript.RigidBody.AddTorque(UnityEngine.Random.insideUnitSphere * maxSeparationTorque);
			bodyScript.OnInitialized();
		}

		private void DisconnectPartGroup(IPartGroupScript partGroup, bool isExploding)
		{
			partGroup.OnBeingDisconnected(isExploding);
			List<PartConnection> list = new List<PartConnection>();
			foreach (PartData part in partGroup.Data.Parts)
			{
				foreach (PartConnection partConnection in part.PartConnections)
				{
					if (!list.Contains(partConnection))
					{
						IPartScript partScript = partConnection.GetOtherPart(part).PartScript;
						if (!partScript.Data.Config.CollisionPreventExternalDisconnections && partScript.PartGroup != partGroup)
						{
							list.Add(partConnection);
						}
					}
				}
			}
			foreach (PartConnection item in list)
			{
				if (!item.IsDestroyed)
				{
					item.DestroyConnection();
				}
			}
		}

		private void DisconnectParts(List<DisconnectedPart> disconnectedParts)
		{
			if (disconnectedParts == null || disconnectedParts.Count == 0 || !_bodyScript.gameObject.activeSelf)
			{
				return;
			}
			if (_bodyScript.PartGroups.Count <= 1 && _bodyScript.Joints.Count == 0)
			{
				foreach (DisconnectedPart disconnectedPart in disconnectedParts)
				{
					bool flag = (disconnectedPart.DisconnectFlags & PartDisconnectFlags.Explode) == PartDisconnectFlags.Explode;
					DisconnectPartGroup(disconnectedPart.Part.PartGroup, flag);
					if (flag)
					{
						OnPartDisconnectExplosion(disconnectedPart);
					}
					if ((disconnectedPart.DisconnectFlags & PartDisconnectFlags.DisablePart) == PartDisconnectFlags.DisablePart && !_bodyScript.Data.IsDestroyed)
					{
						_craftScript.DestroyBody(_bodyScript.Data);
					}
				}
				_craftScript.SetStructureChanged();
				return;
			}
			for (int i = 0; i < disconnectedParts.Count; i++)
			{
				if ((disconnectedParts[i].DisconnectFlags & PartDisconnectFlags.PlayDisconnectSound) == PartDisconnectFlags.PlayDisconnectSound)
				{
					_playDisconnectSound = true;
					break;
				}
			}
			Dictionary<PartData, bool> dictionary = new Dictionary<PartData, bool>();
			foreach (PartData part in _bodyScript.Data.Parts)
			{
				dictionary[part] = true;
			}
			List<IPartGroupScript> list = new List<IPartGroupScript>();
			List<List<PartData>> list2 = new List<List<PartData>>();
			float maxSeparationTorque = 0f;
			foreach (DisconnectedPart disconnectedPart2 in disconnectedParts)
			{
				bool flag2 = (disconnectedPart2.DisconnectFlags & PartDisconnectFlags.Explode) == PartDisconnectFlags.Explode;
				DisconnectPartGroup(disconnectedPart2.Part.PartGroup, flag2);
				if (flag2)
				{
					OnPartDisconnectExplosion(disconnectedPart2);
					maxSeparationTorque = 100f;
					if ((disconnectedPart2.DisconnectFlags & PartDisconnectFlags.DisablePart) == PartDisconnectFlags.DisablePart)
					{
						_craftScript.DestroyPartGroup(disconnectedPart2.Part.PartGroup);
					}
				}
				else if ((disconnectedPart2.DisconnectFlags & PartDisconnectFlags.DisablePart) == PartDisconnectFlags.DisablePart)
				{
					_craftScript.DestroyPartGroup(disconnectedPart2.Part.PartGroup);
				}
				else
				{
					if (list.Contains(disconnectedPart2.Part.PartGroup))
					{
						continue;
					}
					list.Add(disconnectedPart2.Part.PartGroup);
					IPartGroupScript partGroup = disconnectedPart2.Part.PartGroup;
					List<PartData> list3 = new List<PartData>();
					foreach (PartData part2 in partGroup.Data.Parts)
					{
						dictionary[part2] = false;
						list3.Add(part2);
					}
					list2.Add(list3);
				}
			}
			List<PartData> list4 = new List<PartData>();
			foreach (KeyValuePair<PartData, bool> item in dictionary)
			{
				if (item.Value)
				{
					list4.Add(item.Key);
				}
			}
			while (list4.Count > 0)
			{
				PartGraph partGraph = new PartGraph(list4[0], dictionary);
				if (partGraph.Parts.Count > 1 || list4[0].PartScript.GameObject.activeInHierarchy)
				{
					List<PartData> list5 = new List<PartData>();
					list5.AddRange(partGraph.Parts);
					list2.Add(list5);
				}
				foreach (PartData part3 in partGraph.Parts)
				{
					list4.Remove(part3);
				}
			}
			_debugCheckPartLookup = new Dictionary<IPartGroupScript, BodyScript>();
			foreach (List<PartData> item2 in list2)
			{
				CreateBodyScript(item2, maxSeparationTorque);
			}
			_bodyScript.gameObject.name += " (Dead)";
			IBodyJoint[] array = _bodyScript.Joints.ToArray();
			foreach (IBodyJoint bodyJoint in array)
			{
				if (!bodyJoint.PartConnection.IsDestroyed)
				{
					RecreateJoint(bodyJoint);
				}
			}
			_bodyScript.PartGroups.Clear();
			_craftScript.DestroyBody(_bodyScript.Data);
			_craftScript.SetStructureChanged();
		}

		private void HandleBrokenJoints()
		{
			if (!_jointBroke)
			{
				return;
			}
			_jointBroke = false;
			List<IBodyJoint> list = new List<IBodyJoint>();
			foreach (IBodyJoint joint in _bodyScript.Joints)
			{
				foreach (BodyPhysicsJoint joint2 in joint.Joints)
				{
					if (joint2.Joint == null)
					{
						list.Add(joint);
						break;
					}
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			foreach (IBodyJoint item in list)
			{
				item.Destroy();
			}
			_playDisconnectSound = true;
		}

		private bool HandleCollision(IPartFlightCollision collision)
		{
			bool flag = false;
			List<PartModifierScript> modifiers = collision.PartScript.Modifiers;
			for (int i = 0; i < modifiers.Count; i++)
			{
				if (modifiers[i].OnCollision(collision))
				{
					flag = true;
				}
			}
			if (flag)
			{
				return true;
			}
			if (!BodyCollisionsEnabled)
			{
				return false;
			}
			switch (GetCollisionResponse(collision, collision.PartScript.Data.Config))
			{
			case CollisionResponseType.Damage:
				HandleDamage();
				break;
			case CollisionResponseType.Disconnect:
				HandleDamage();
				AddDisconnectedPart(CreateDisconnectedPart(explode: false, collision.PartScript));
				break;
			case CollisionResponseType.Explode:
				AddDisconnectedPart(CreateDisconnectedPart(explode: true, collision.PartScript));
				break;
			}
			return false;
			void HandleDamage()
			{
				PartData data = collision.PartScript.Data;
				float num = Mathf.Max(10f, collision.PartScript.BodyScript.RigidBody.mass * 100f) * 0.0001f;
				float num2 = 1.5f * collision.Impulse / (data.Config.CollisionExplodeImpulse * num) - 0.5f;
				if (num2 > 0f)
				{
					collision.PartScript.TakeDamage(Mathf.Lerp(0f, 100f, num2));
					if (collision.PartScript.Data.Damage < collision.PartScript.Data.Config.MaxDamage)
					{
						_playCollisionSound |= collision.PartScript.CollisionSoundsEnabled;
					}
				}
			}
		}

		private void OnPartDisconnectExplosion(DisconnectedPart disconnectedPart)
		{
			float powerModifier = 0f;
			float totalMass = 0f;
			foreach (PartData part in disconnectedPart.Part.PartGroup.Data.Parts)
			{
				FuelTankData modifier = part.GetModifier<FuelTankData>();
				if (modifier != null)
				{
					powerModifier += (float)modifier.ExplosivePower;
				}
				totalMass += part.Mass;
				_craftScript.OnPartExploded(part);
			}
			float force = disconnectedPart.Force;
			Vector3 position = disconnectedPart.Part.Transform.position;
			Vector3 velocity = _bodyScript.RigidBody.velocity;
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				List<PartData> list = new List<PartData>();
				if (powerModifier > 0f)
				{
					foreach (CraftNode item in Game.Instance.FlightScene.ViewManager.GameView.PlanetNode.DynamicNodes.OfType<CraftNode>())
					{
						if (item.IsPhysicsEnabled)
						{
							foreach (PartData part2 in item.CraftScript.Data.Assembly.Parts)
							{
								list.Add(part2);
							}
						}
					}
				}
				Game.Instance.FlightScene.CreateExplosion(list, position, velocity, Mathf.Max(0.1f * (force + powerModifier), totalMass), 0.1f * powerModifier);
			});
		}

		private void RecreateJoint(IBodyJoint joint)
		{
			((BodyJoint)joint).Destroy(destroyPartConnection: false);
			IBodyScript bodyScript = joint.OtherBody(_bodyScript);
			if (bodyScript != null && bodyScript.RigidBody != null)
			{
				bodyScript.RigidBody.WakeUp();
			}
			if (!joint.PartConnection.IsDestroyed && joint.PartConnection.PartA.PartScript.GameObject.activeInHierarchy && joint.PartConnection.PartB.PartScript.GameObject.activeInHierarchy)
			{
				IBodyScript bodyScript2 = null;
				bodyScript2 = ((bodyScript != joint.PartConnection.PartA.PartScript.BodyScript) ? joint.PartConnection.PartA.PartScript.BodyScript : joint.PartConnection.PartB.PartScript.BodyScript);
				BodyJointData bodyJointData = joint.PartConnection.BodyJointData;
				if (bodyJointData.Body == _bodyScript.Data)
				{
					bodyJointData.Body = bodyScript2.Data;
					Vector3 position = _bodyScript.Transform.TransformPoint(bodyJointData.Position);
					bodyJointData.Position = bodyScript2.Transform.InverseTransformPoint(position);
				}
				else
				{
					bodyJointData.ConnectedBody = bodyScript2.Data;
					Vector3 position2 = _bodyScript.Transform.TransformPoint(bodyJointData.ConnectedPosition);
					bodyJointData.ConnectedPosition = bodyScript2.Transform.InverseTransformPoint(position2);
				}
				CraftBuilder.CreateBodyJoint(joint.PartConnection);
			}
		}
	}
}
