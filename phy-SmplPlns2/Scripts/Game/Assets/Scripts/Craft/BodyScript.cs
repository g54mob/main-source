using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Craft.Wings.Physics;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Multiplayer.SyncData;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class BodyScript : MonoBehaviour
	{
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

		private readonly struct DisconnectedPart
		{
			public PartDisconnectFlags DisconnectFlags { get; }

			public int ExplosionCascadeCount { get; }

			public float Force { get; }

			public PartScript Part { get; }

			public DisconnectedPart(PartScript part, float force, int cascadeCount, PartDisconnectFlags disconnectFlags)
			{
				Part = part;
				Force = force;
				ExplosionCascadeCount = cascadeCount;
				DisconnectFlags = disconnectFlags;
			}
		}

		private struct PartExplosiveBlastInfo
		{
			public Vector3 BlastDirection;

			public float BlastForce;

			public PartScript Part;

			public bool PartDisconnected;

			public PartExplosiveBlastInfo(PartScript part, float blastForce, Vector3 blastDirection, bool partDisconnected)
			{
				Part = part;
				BlastForce = blastForce;
				BlastDirection = blastDirection;
				PartDisconnected = partDisconnected;
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker ResetInertiaTensor = new ProfilerMarker("BodyScript.ResetInertiaTensor");
		}

		private static float[] _partDamageLevelDisconnectChances;

		private int _ageInFrames;

		private List<DisconnectedPart> _disconnectParts = new List<DisconnectedPart>();

		private bool _jointBroke;

		private bool _recalculateInertiaTensor;

		private IRigidBody _rigidBody;

		private Rigidbody _rigidBodyComponent;

		private bool _rigidBodyEnabled;

		private RigidBodySettings _rigidBodySettings;

		public AeroForcesManager AeroManager { get; private set; }

		public AircraftScript Aircraft { get; set; }

		public bool ConnectedToMainCockpit { get; set; }

		public IBodyDragPhysics DragPhysics { get; private set; }

		public int Id { get; set; }

		public int InertiaTensorDiffusionJointCount
		{
			get
			{
				int num = 0;
				foreach (BodyJoint joint in Joints)
				{
					if (!joint.PreventInertiaTensorDiffusion)
					{
						num++;
					}
				}
				return num;
			}
		}

		public float InertiaTensorInitial { get; set; }

		public float InertiaTensorMagnitude { get; set; }

		public bool InertiaTensorRecalculationEnabled { get; set; } = true;

		public float InitialMass { get; private set; }

		public bool IsDebris { get; set; }

		public List<BodyJoint> Joints { get; private set; } = new List<BodyJoint>();

		public PartMeshLodTreeScript LodTree { get; set; }

		public float MachNumber => Velocity.magnitude / Aircraft.AtmosphereSample.SpeedOfSound;

		public float MaxConnectedInertiaTensor { get; set; }

		public Vector3? OriginalInertiaTensor { get; set; }

		public List<PartGroupScript> PartGroups { get; private set; } = new List<PartGroupScript>();

		public bool RecalculateInertiaTensor
		{
			get
			{
				return _recalculateInertiaTensor;
			}
			set
			{
				_recalculateInertiaTensor = value && InertiaTensorRecalculationEnabled;
			}
		}

		public IRigidBody RigidBody => _rigidBody;

		public RigidBodyGroup RigidBodyGroup { get; set; }

		public BodySyncData SyncData { get; private set; }

		public bool UpdateAngularDrag { get; set; } = true;

		public Vector3 Velocity
		{
			get
			{
				if (!_rigidBodyEnabled)
				{
					return Aircraft.Velocity;
				}
				return _rigidBody.velocity;
			}
			set
			{
				if (_rigidBodyEnabled)
				{
					CraftUpdateScript craftUpdateScript = Aircraft?.CraftUpdate;
					if ((object)craftUpdateScript != null && craftUpdateScript.IsPaused)
					{
						craftUpdateScript.UpdatePausedVelocity(Id, value);
					}
					else
					{
						RigidBody.velocity = value;
					}
				}
			}
		}

		public event EventHandler<PartDisconnectExplosionEventArgs> PartDisconnectExplosion;

		static BodyScript()
		{
			_partDamageLevelDisconnectChances = new float[5] { 0f, 0f, 0.25f, 0.5f, 0.9f };
			AeroForcesManager.OnAdded += delegate(AeroForcesManager afm)
			{
				if (afm.TryGetComponent<BodyScript>(out var component))
				{
					component.AeroManager = afm;
				}
			};
		}

		public static BodyScript MoveExistingPartsToNewBody(AircraftScript aircraft, RigidBodyGroup newRigidBodyGroup)
		{
			BodyScript bodyScript = aircraft.CreateBodyScript(newRigidBodyGroup);
			HashSet<PartGroupScript> value;
			using (CollectionPool<HashSet<PartGroupScript>, PartGroupScript>.Get(out value))
			{
				foreach (PartData part in bodyScript.RigidBodyGroup.Parts)
				{
					part.PartScript.Body = bodyScript;
					PartGroupScript partGroup = part.PartScript.PartGroup;
					if (value.Add(partGroup))
					{
						bodyScript.PartGroups.Add(partGroup);
						partGroup.Body = bodyScript;
						partGroup.transform.parent = bodyScript.transform;
					}
				}
				bodyScript.CalculateDrag();
				return bodyScript;
			}
		}

		public void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			foreach (PartGroupScript partGroup in PartGroups)
			{
				partGroup.BuildPreStartInitializationPlan(plan);
			}
		}

		public void CalculateDrag()
		{
			if (RigidBodyGroup != null)
			{
				DragPhysics.CalculateDrag();
			}
		}

		public void CalculateIntake()
		{
			List<JetEngineScript> list = new List<JetEngineScript>();
			List<JetEngineAfterburningScript> list2 = new List<JetEngineAfterburningScript>();
			List<InletScript> list3 = new List<InletScript>();
			float num = 0f;
			float num2 = 0f;
			foreach (PartData part in RigidBodyGroup.Parts)
			{
				JetEngineScript modifier = part.PartScript.GetModifier<JetEngineScript>();
				if (modifier != null)
				{
					list.Add(modifier);
					num += modifier.Engine.RequiredAirIntake;
					num2 += part.PartDrag.GetDrag(PartDrag.DragDirection.Forward);
				}
				JetEngineAfterburningScript modifier2 = part.PartScript.GetModifier<JetEngineAfterburningScript>();
				if (modifier2 != null)
				{
					list2.Add(modifier2);
					num += modifier2.Engine.RequiredAirIntake;
					num2 += part.PartDrag.GetDrag(PartDrag.DragDirection.Forward);
				}
				InletScript modifier3 = part.PartScript.GetModifier<InletScript>();
				if (modifier3 != null)
				{
					list3.Add(modifier3);
					float drag = part.PartDrag.GetDrag(PartDrag.DragDirection.Forward);
					drag = Mathf.Max(0.25f, drag);
					float num3 = drag * modifier3.Inlet.AirIntakeMultiplier;
					num2 += num3;
				}
			}
			float num4 = 0f;
			if (num2 > 0f && num > 0f)
			{
				num4 = num2 / num;
				if (Aircraft.Aircraft.AerodynamicsModelType != CraftAerodynamicsModelType.Legacy)
				{
					num4 = Mathf.Clamp(num4, 0f, 1.25f);
				}
			}
			string empty = string.Empty;
			foreach (JetEngineScript item in list)
			{
				item.AvailableAirIntakeRatio = num4;
			}
			foreach (JetEngineAfterburningScript item2 in list2)
			{
				item2.AvailableAirIntakeRatio = num4;
			}
			if (!string.IsNullOrEmpty(empty))
			{
				Debug.Log(empty);
			}
		}

		public void ExplodePart(PartScript part, float magnitude, int numExplosionCascades)
		{
			PartDisconnectFlags disconnectFlags = ((!part.PartGroup.HasCockpit) ? PartDisconnectFlags.DefaultExplosion : PartDisconnectFlags.PlayDisconnectSound);
			AddDisconnectedPart(new DisconnectedPart(part, magnitude, numExplosionCascades, disconnectFlags));
		}

		public void ExplodePart(PartScript part)
		{
			if (part.PartGroup == Aircraft.MainCockpit.PartGroup)
			{
				Aircraft.QueueExplosion(Aircraft.MainCockpit, 100f);
			}
			else
			{
				AddDisconnectedPart(new DisconnectedPart(part, 0f, 10, PartDisconnectFlags.DefaultExplosion));
			}
		}

		public float GetJointBreakTorque()
		{
			float num = 0f;
			if (_rigidBody != null)
			{
				num = _rigidBody.mass;
			}
			if (RigidBodyGroup.Parts.Count == 1)
			{
				WingScript modifier = RigidBodyGroup.Parts[0].PartScript.GetModifier<WingScript>();
				if (modifier != null)
				{
					num = modifier.Wing.Mass;
				}
			}
			return 20000f * (num / 50f);
		}

		public void HandleExplosiveBlast(List<PartScript> parts, float blastForce, float blastRadius, float criticalBlastRadius, Vector3 blastOrigin, AircraftScript owner)
		{
			float num = blastRadius - criticalBlastRadius;
			List<DisconnectedPart> value;
			using (CollectionPool<List<DisconnectedPart>, DisconnectedPart>.Get(out value))
			{
				List<PartExplosiveBlastInfo> value2;
				using (CollectionPool<List<PartExplosiveBlastInfo>, PartExplosiveBlastInfo>.Get(out value2))
				{
					for (int i = 0; i < parts.Count; i++)
					{
						PartScript partScript = parts[i];
						if (partScript == null)
						{
							continue;
						}
						BombScript modifier = partScript.GetModifier<BombScript>();
						MissileScript modifier2 = partScript.GetModifier<MissileScript>();
						if ((!(modifier != null) || !modifier.Fired) && (!(modifier2 != null) || !modifier2.Fired))
						{
							Vector3 vector = partScript.transform.position - blastOrigin;
							Vector3 normalized = vector.normalized;
							float magnitude = vector.magnitude;
							float num2 = blastForce;
							if (magnitude > criticalBlastRadius)
							{
								num2 *= 1f - (magnitude - criticalBlastRadius) / num;
							}
							float num3 = 30f + Mathf.Pow(UnityEngine.Random.value, 3f) * 65f;
							bool flag = num2 >= num3;
							if (flag)
							{
								value.Add(new DisconnectedPart(partScript, num2, 0, PartDisconnectFlags.None));
							}
							if (num2 > 0f)
							{
								value2.Add(new PartExplosiveBlastInfo(partScript, num2, normalized, flag));
							}
						}
					}
					int num4 = DisconnectParts(value, raiseAircraftStructureChangedEvent: false);
					float num5 = 1f;
					if (num4 >= 1)
					{
						num5 = 1f / (float)(num4 + 1);
					}
					else if (PartGroups.Count == 1 && PartGroups[0].Parts.Count == 1)
					{
						num5 = 0.5f;
					}
					Dictionary<IRigidBody, List<PartExplosiveBlastInfo>> value3;
					using (CollectionPool<Dictionary<IRigidBody, List<PartExplosiveBlastInfo>>, KeyValuePair<IRigidBody, List<PartExplosiveBlastInfo>>>.Get(out value3))
					{
						for (int j = 0; j < value2.Count; j++)
						{
							PartExplosiveBlastInfo item = value2[j];
							IRigidBody rigidBody = item.Part.Body.RigidBody;
							if (!value3.TryGetValue(rigidBody, out var value4))
							{
								value4 = (value3[rigidBody] = CollectionPool<List<PartExplosiveBlastInfo>, PartExplosiveBlastInfo>.Get());
							}
							value4.Add(item);
						}
						foreach (KeyValuePair<IRigidBody, List<PartExplosiveBlastInfo>> item2 in value3)
						{
							for (int k = 0; k < item2.Value.Count; k++)
							{
								PartExplosiveBlastInfo partExplosiveBlastInfo = item2.Value[k];
								float num6 = partExplosiveBlastInfo.BlastForce / (float)item2.Value.Count * num5;
								item2.Key.AddForceAtPosition(num6 * partExplosiveBlastInfo.BlastDirection, partExplosiveBlastInfo.Part.transform.position, ForceMode.Impulse);
								for (int l = 0; l < partExplosiveBlastInfo.Part.Modifiers.Count; l++)
								{
									partExplosiveBlastInfo.Part.Modifiers[l].OnExplosiveForceApplied(num6, partExplosiveBlastInfo.BlastDirection);
								}
							}
							CollectionPool<List<PartExplosiveBlastInfo>, PartExplosiveBlastInfo>.Release(item2.Value);
						}
						int? attackerPlayerId = owner?.NetworkAircraft?.PlayerId;
						for (int m = 0; m < value2.Count; m++)
						{
							PartExplosiveBlastInfo partExplosiveBlastInfo2 = value2[m];
							if (!partExplosiveBlastInfo2.PartDisconnected)
							{
								partExplosiveBlastInfo2.Part.OnDamaged(attackerPlayerId, partExplosiveBlastInfo2.BlastForce, partExplosiveBlastInfo2.Part.transform.position, partExplosiveBlastInfo2.BlastDirection);
							}
							else
							{
								Aircraft.OnDamaged(attackerPlayerId, partExplosiveBlastInfo2.BlastForce);
							}
						}
					}
				}
			}
		}

		public void InitializeRigidBody(RigidBodyGroup rigidBodyGroup, bool remoteAircraft)
		{
			if (Aircraft.Aircraft.AerodynamicsModelType == CraftAerodynamicsModelType.Legacy)
			{
				DragPhysics = new BodyDragPhysicsLegacy(this);
			}
			else
			{
				if (Aircraft.Aircraft.AerodynamicsModelType != CraftAerodynamicsModelType.StandardV1)
				{
					throw new NotImplementedException($"AerodynamicsModelType '{Aircraft.Aircraft.AerodynamicsModelType}' is not implemented");
				}
				DragPhysics = new BodyDragPhysics(this);
			}
			EnableRigidBody(enabled: true);
			float num = 0.005f;
			InitialMass = rigidBodyGroup.Mass;
			if (Utilities.CompareFloats(0f, InitialMass, num))
			{
				InitialMass = num;
			}
			Rigidbody rigidBodyComponent = _rigidBodyComponent;
			rigidBodyComponent.maxAngularVelocity = 10f;
			rigidBodyComponent.angularDamping = 0.05f;
			rigidBodyComponent.mass = InitialMass;
			rigidBodyComponent.linearVelocity = rigidBodyGroup.Velocity;
			rigidBodyComponent.angularVelocity = rigidBodyGroup.AngularVelocity;
			rigidBodyComponent.solverIterations = 50;
			if (remoteAircraft)
			{
				_rigidBody = new RigidBodyRemote();
				_rigidBody.SetRootRigidBody(rigidBodyComponent, null);
			}
			else
			{
				_rigidBody = new RigidBodyPhysx(_rigidBodyComponent);
			}
			SyncData = new BodySyncData(this);
			if ((object)Aircraft == null)
			{
				AircraftScript aircraftScript = (Aircraft = GetComponentInParent<AircraftScript>());
			}
		}

		public virtual void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (PauseManager.Paused || !_rigidBodyEnabled)
			{
				return;
			}
			if (_jointBroke)
			{
				Joint[] components = GetComponents<Joint>();
				List<BodyJoint> list = new List<BodyJoint>();
				foreach (BodyJoint joint2 in Joints)
				{
					bool flag = false;
					Joint[] array = components;
					foreach (Joint joint in array)
					{
						if (joint2.HasJoint(joint))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.Add(joint2);
					}
				}
				if (list.Count > 0)
				{
					_jointBroke = false;
					foreach (BodyJoint item in list)
					{
						item.BodyA.Joints.Remove(item);
						item.BodyB.Joints.Remove(item);
						item.PartConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
					}
					AudioManager.PlaySound(AudioStore.PartBreakOffAudio, base.transform.position);
					Aircraft.AircraftDamaged(null);
					Aircraft.AircraftStructureChanged();
				}
			}
			Vector3 velocity = _rigidBody.velocity;
			DragPhysics.ApplyDrag(velocity);
			if (PartGroups.Count != 1 || PartGroups[0].Parts.Count != 1)
			{
				return;
			}
			PartScript partScript = PartGroups[0].Parts[0];
			if (partScript == Aircraft.MainCockpit && partScript.Part.PartConnections.Count == 0)
			{
				float sqrMagnitude = velocity.sqrMagnitude;
				if (sqrMagnitude > 1000000f)
				{
					_rigidBody.velocity = velocity.normalized * 1000f;
					_rigidBody.drag = 0.2f;
				}
				else if (sqrMagnitude > 250000f)
				{
					_rigidBody.drag = 0.1f;
				}
				else
				{
					_rigidBody.drag = 0.05f;
				}
			}
		}

		public void OnPartDamageLevelIncreased(PartScript part)
		{
			if (!part.Part.PartType.DamageDisconnect && part.MaxHealth > part.PartDamage)
			{
				return;
			}
			float num = 0f;
			if (part.PartGroup is GlassGroupScript)
			{
				ExplodePart(part);
				return;
			}
			foreach (PartScript part2 in part.PartGroup.Parts)
			{
				num += _partDamageLevelDisconnectChances[(int)part2.PartDamageLevel];
			}
			num /= (float)part.PartGroup.Parts.Count;
			if (UnityEngine.Random.value < num)
			{
				ExplodePart(part);
			}
		}

		public void OnRepositioned()
		{
			RigidBody.drag = 0f;
			DragPhysics.OnRepositioned();
		}

		public virtual void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (PauseManager.Paused)
			{
				return;
			}
			_ageInFrames++;
			if (Aircraft.RemoteAircraft)
			{
				PartMeshLodTreeScript lodTree = LodTree;
				if ((object)lodTree != null && !lodTree.Visible)
				{
					return;
				}
				BodySyncData syncData = SyncData;
				if (syncData != null && syncData.TargetRotation.HasValue)
				{
					if ((base.transform.localEulerAngles - SyncData.TargetRotation.Value.eulerAngles).sqrMagnitude < 0.01f)
					{
						base.transform.localRotation = SyncData.TargetRotation.Value;
						SyncData.TargetRotation = null;
					}
					else
					{
						base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, SyncData.TargetRotation.Value, 10f * Time.deltaTime);
					}
				}
				BodySyncData syncData2 = SyncData;
				if (syncData2 != null && syncData2.TargetPosition.HasValue)
				{
					if ((base.transform.localPosition - SyncData.TargetPosition.Value).sqrMagnitude < 0.01f)
					{
						base.transform.localPosition = SyncData.TargetPosition.Value;
						SyncData.TargetPosition = null;
					}
					else
					{
						base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, SyncData.TargetPosition.Value, 10f * Time.deltaTime);
					}
				}
			}
			else if (_disconnectParts.Count > 0)
			{
				DisconnectParts(_disconnectParts, raiseAircraftStructureChangedEvent: true);
				_disconnectParts.Clear();
			}
			else if (_rigidBodyEnabled)
			{
				float num = CalculateMass();
				if (Mathf.Abs(_rigidBody.mass - num) > 1f)
				{
					_rigidBody.mass = num;
				}
			}
		}

		public void ResetInertiaTensor()
		{
			using (Profile.ResetInertiaTensor.Auto())
			{
				RigidBody.automaticInertiaTensor = true;
				OriginalInertiaTensor = null;
			}
		}

		public void SetParentBody(BodyScript parent, BodyScript rootBody, bool remoteCraft)
		{
			try
			{
				if (remoteCraft)
				{
					base.transform.parent = ((parent != null) ? parent.transform : Aircraft.Children);
					SetRootBody(rootBody);
				}
				SyncData.ParentBody = parent;
				LodTree?.SetParent(parent?.LodTree);
			}
			catch (NullReferenceException exception)
			{
				Debug.LogException(exception);
				Debug.LogError($"SetParentBody null ref encountered on body '{base.gameObject.name}' Active state: {base.gameObject.activeInHierarchy}, SyncData: {SyncData}, Aircraft: {Aircraft}");
			}
		}

		public void SilentlyDisconnectAndDisablePart(PartScript part)
		{
			for (int i = 0; i < _disconnectParts.Count; i++)
			{
				if (_disconnectParts[i].Part.PartGroup == part.PartGroup)
				{
					return;
				}
			}
			AddDisconnectedPart(new DisconnectedPart(part, 0f, 0, PartDisconnectFlags.DisablePart));
		}

		protected virtual void Awake()
		{
			if ((object)Aircraft == null)
			{
				AircraftScript aircraftScript = (Aircraft = GetComponentInParent<AircraftScript>());
			}
			Aircraft.CraftUpdate.RegisterUpdate(CraftUpdateType.Start, this, OnStart, CraftUpdateFlags.Default, -900);
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (Aircraft.RemoteAircraft)
			{
				return;
			}
			Rigidbody rigidbody = collision.rigidbody;
			if ((object)rigidbody != null && rigidbody.TryGetComponent<BodyScript>(out var component) && (_ageInFrames < 2 || component._ageInFrames < 2) && (object)component.Aircraft == Aircraft)
			{
				return;
			}
			List<ContactPoint> value;
			using (CollectionPool<List<ContactPoint>, ContactPoint>.Get(out value))
			{
				int contacts = collision.GetContacts(value);
				Collider thisCollider = value[0].thisCollider;
				Collider otherCollider = value[0].otherCollider;
				PartScript componentInParent = thisCollider.GetComponentInParent<PartScript>();
				if (componentInParent == null)
				{
					return;
				}
				HashSet<int> partCollidersSkippingCollisionHandler = componentInParent.Aircraft.PartCollidersSkippingCollisionHandler;
				if (partCollidersSkippingCollisionHandler.Contains(thisCollider.GetInstanceID()) || partCollidersSkippingCollisionHandler.Contains(otherCollider.GetInstanceID()))
				{
					return;
				}
				float num = 0f;
				int index = 0;
				for (int i = 0; i < contacts; i++)
				{
					float num2 = Mathf.Abs(Vector3.Dot(value[i].normal, collision.relativeVelocity));
					if (num2 > num)
					{
						num = num2;
						index = i;
					}
				}
				ContactPoint contactPoint = value[index];
				if (componentInParent.OnCollision(collision, in contactPoint))
				{
					return;
				}
				PartCollisionResponseType partCollisionResponse = componentInParent.Part.PartCollisionResponse;
				if (partCollisionResponse == PartCollisionResponseType.None)
				{
					return;
				}
				if ((object)rigidbody != null && rigidbody.mass < RigidBody.mass)
				{
					num *= rigidbody.mass / RigidBody.mass;
				}
				float disconnectForce = componentInParent.Part.PartType.DisconnectForce;
				if (num > disconnectForce * 2f && partCollisionResponse == PartCollisionResponseType.Default)
				{
					componentInParent.OnDamaged(null, num, componentInParent.transform.position, -contactPoint.normal);
					AddDisconnectedPart(CreateDisconnectedPart(num, componentInParent));
				}
				else if (num > disconnectForce)
				{
					componentInParent.OnDamaged(null, num, componentInParent.transform.position, -contactPoint.normal);
				}
				else if (num > 1.5f && !componentInParent.ThudSoundDisabled)
				{
					float num3 = Mathf.Clamp01(num / 7f);
					if (Aircraft.IsThudSoundEnabled && num3 > 0.25f)
					{
						AudioManager.PlayTrackedSound(AudioStore.ThudAudio, base.transform.position, num3);
					}
				}
			}
		}

		protected virtual void OnJointBreak(float breakForce)
		{
			_jointBroke = true;
		}

		private static DisconnectedPart CreateDisconnectedPart(float disconnectForce, PartScript part)
		{
			PartType partType = part.Part.PartType;
			PartDisconnectFlags disconnectFlags = ((disconnectForce > partType.ExplodeForce && partType.CanExplode && !part.PartGroup.HasCockpit) ? PartDisconnectFlags.DefaultExplosion : PartDisconnectFlags.PlayDisconnectSound);
			return new DisconnectedPart(part, disconnectForce, 0, disconnectFlags);
		}

		private void AddDisconnectedPart(in DisconnectedPart disconnectedPart)
		{
			if (Aircraft.RemoteAircraft)
			{
				return;
			}
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

		private float CalculateMass()
		{
			float num = 0f;
			List<PartData> parts = RigidBodyGroup.Parts;
			for (int i = 0; i < parts.Count; i++)
			{
				PartData partData = parts[i];
				if (partData.Enabled)
				{
					num += partData.LoadedMass;
				}
			}
			return num;
		}

		private void DestroyAndRecreateJoints(bool allowJointCreation)
		{
			List<BodyJoint> value;
			using (CollectionPool<List<BodyJoint>, BodyJoint>.Get(out value))
			{
				value.AddRange(Joints);
				foreach (BodyJoint item in value)
				{
					item.BodyA.Joints.Remove(item);
					item.BodyB.Joints.Remove(item);
					item.DestroyPhysicsJoints();
					BodyScript bodyScript = item.OtherBody(this);
					if (bodyScript != null && bodyScript.RigidBody != null)
					{
						bodyScript.RigidBody.WakeUp();
					}
					if (allowJointCreation && !item.PartConnection.IsDestroyed)
					{
						PartScript partScript = item.PartConnection.PartA.PartScript;
						PartScript partScript2 = item.PartConnection.PartB.PartScript;
						if (partScript.gameObject.activeInHierarchy && partScript2.gameObject.activeInHierarchy)
						{
							Assembly.CreateBodyJoint(item.PartConnection, partScript.Body, partScript2.Body);
						}
					}
					if (Aircraft.InertiaTensorRecalculationEnabled)
					{
						RecalculateInertiaTensor = true;
						bodyScript.RecalculateInertiaTensor = true;
						continue;
					}
					if (Joints.Count == 0)
					{
						RigidBody.automaticInertiaTensor = true;
					}
					if (bodyScript.Joints.Count == 0)
					{
						bodyScript.RigidBody.automaticInertiaTensor = true;
					}
				}
			}
		}

		private void DisconnectPartGroup(PartGroupScript partGroup)
		{
			List<PartConnection> value;
			using (CollectionPool<List<PartConnection>, PartConnection>.Get(out value))
			{
				foreach (PartScript part in partGroup.Parts)
				{
					foreach (PartConnection partConnection in part.Part.PartConnections)
					{
						value.Add(partConnection);
					}
				}
				foreach (PartConnection item in value)
				{
					if (!item.IsDestroyed)
					{
						item.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
					}
				}
			}
		}

		private int DisconnectParts(List<DisconnectedPart> disconnectedParts, bool raiseAircraftStructureChangedEvent)
		{
			if (disconnectedParts == null || disconnectedParts.Count == 0)
			{
				return 0;
			}
			Aircraft.QueueDragRecalculation();
			if (PartGroups.Count == 0)
			{
				Debug.LogError("BodyScript.DisconnectParts running for a body with zero part groups.");
				return 0;
			}
			if (PartGroups.Count == 1)
			{
				PartGroupScript partGroup = PartGroups[0];
				DisconnectPartGroup(partGroup);
				DestroyAndRecreateJoints(allowJointCreation: false);
				foreach (DisconnectedPart disconnectedPart in disconnectedParts)
				{
					DisconnectedPart part = disconnectedPart;
					Aircraft.PartHasBeenDisconnected(part.Part);
					if (part.Part.PartGroup is GlassGroupScript glassGroupScript)
					{
						foreach (PartModifierScript modifier in part.Part.Modifiers)
						{
							modifier.OnPreDisable(ModifierScriptDisableConditionType.Explosion);
						}
						glassGroupScript.Shatter();
					}
					else if ((part.DisconnectFlags & PartDisconnectFlags.Explode) == PartDisconnectFlags.Explode)
					{
						foreach (PartModifierScript modifier2 in part.Part.Modifiers)
						{
							modifier2.OnPreDisable(ModifierScriptDisableConditionType.Explosion);
						}
						OnPartDisconnectExplosion(in part);
					}
					if ((part.DisconnectFlags & PartDisconnectFlags.DisablePart) == PartDisconnectFlags.DisablePart)
					{
						GameObject gameObject = part.Part.PartGroup.Body.gameObject;
						Aircraft.DamageEffects.DestroyAndOrphanEffects(gameObject);
						gameObject.SetActive(value: false);
						gameObject.name = $"Disabled Body {Id}";
						Aircraft.RemoveBody(this);
					}
					Aircraft.AircraftDamaged(part.Part);
				}
				if (raiseAircraftStructureChangedEvent)
				{
					Aircraft.AircraftStructureChanged();
				}
				return 0;
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < disconnectedParts.Count; i++)
			{
				if ((disconnectedParts[i].DisconnectFlags & PartDisconnectFlags.PlayDisconnectSound) == PartDisconnectFlags.PlayDisconnectSound)
				{
					if (disconnectedParts[i].Part.PartGroup is GlassGroupScript)
					{
						flag2 = true;
					}
					else
					{
						flag = true;
					}
					if (flag2 && flag)
					{
						break;
					}
				}
			}
			if (flag)
			{
				AudioManager.PlaySound(AudioStore.PartBreakOffAlternate, base.transform.position);
			}
			if (flag2)
			{
				AudioManager.PlaySound(AudioStore.GlassShatterAudio, base.transform.position);
			}
			Dictionary<PartData, bool> value;
			using (CollectionPool<Dictionary<PartData, bool>, KeyValuePair<PartData, bool>>.Get(out value))
			{
				foreach (PartData part3 in RigidBodyGroup.Parts)
				{
					value[part3] = true;
				}
				Dictionary<PartGroupScript, PartDisconnectFlags> value2;
				using (CollectionPool<Dictionary<PartGroupScript, PartDisconnectFlags>, KeyValuePair<PartGroupScript, PartDisconnectFlags>>.Get(out value2))
				{
					foreach (DisconnectedPart disconnectedPart2 in disconnectedParts)
					{
						DisconnectedPart part2 = disconnectedPart2;
						PartGroupScript partGroup2 = part2.Part.PartGroup;
						PartDisconnectFlags value3;
						PartDisconnectFlags partDisconnectFlags = (value2.TryGetValue(partGroup2, out value3) ? value3 : PartDisconnectFlags.None);
						value2[partGroup2] = partDisconnectFlags | part2.DisconnectFlags;
						Aircraft.PartHasBeenDisconnected(part2.Part);
						if (part2.DisconnectFlags.HasFlag(PartDisconnectFlags.Explode) && !(partGroup2 is GlassGroupScript))
						{
							OnPartDisconnectExplosion(in part2);
						}
						if (part2.DisconnectFlags != PartDisconnectFlags.DisablePart)
						{
							Aircraft.AircraftDamaged(part2.Part);
						}
					}
					List<RigidBodyGroup> value4;
					using (CollectionPool<List<RigidBodyGroup>, RigidBodyGroup>.Get(out value4))
					{
						foreach (KeyValuePair<PartGroupScript, PartDisconnectFlags> item in value2)
						{
							PartGroupScript key = item.Key;
							PartDisconnectFlags value5 = item.Value;
							DisconnectPartGroup(key);
							if (value5.HasFlag(PartDisconnectFlags.Explode))
							{
								if (key is GlassGroupScript glassGroupScript2)
								{
									glassGroupScript2.Shatter();
								}
								if (value5.HasFlag(PartDisconnectFlags.DisablePart))
								{
									GameObject gameObject2 = key.gameObject;
									Aircraft.DamageEffects.DestroyAndOrphanEffects(gameObject2);
									gameObject2.name = $"Disabled Part Group {key.Id}";
									gameObject2.SetActive(value: false);
								}
								continue;
							}
							if (value5.HasFlag(PartDisconnectFlags.DisablePart))
							{
								GameObject gameObject3 = key.gameObject;
								Aircraft.DamageEffects.DestroyAndOrphanEffects(gameObject3);
								gameObject3.name = $"Disabled Part Group {key.Id}";
								gameObject3.SetActive(value: false);
								continue;
							}
							RigidBodyGroup rigidBodyGroup = new RigidBodyGroup();
							foreach (PartScript part4 in key.Parts)
							{
								value[part4.Part] = false;
								rigidBodyGroup.Parts.Add(part4.Part);
							}
							rigidBodyGroup.Velocity = _rigidBody.velocity;
							rigidBodyGroup.AngularVelocity = _rigidBody.angularVelocity;
							value4.Add(rigidBodyGroup);
						}
						List<PartData> value6;
						using (CollectionPool<List<PartData>, PartData>.Get(out value6))
						{
							foreach (KeyValuePair<PartData, bool> item2 in value)
							{
								if (item2.Value)
								{
									value6.Add(item2.Key);
								}
							}
							while (value6.Count > 0)
							{
								PartGraph partGraph = new PartGraph(value6[0], value);
								if (partGraph.Parts.Count > 1 || value6[0].PartScript.gameObject.activeInHierarchy)
								{
									RigidBodyGroup rigidBodyGroup2 = new RigidBodyGroup();
									rigidBodyGroup2.Parts.AddRange(partGraph.Parts);
									rigidBodyGroup2.Velocity = _rigidBody.velocity;
									rigidBodyGroup2.AngularVelocity = _rigidBody.angularVelocity;
									value4.Add(rigidBodyGroup2);
								}
								foreach (PartData part5 in partGraph.Parts)
								{
									value6.Remove(part5);
								}
							}
							int num = 0;
							foreach (RigidBodyGroup item3 in value4)
							{
								num++;
								MoveExistingPartsToNewBody(Aircraft, item3);
							}
							foreach (DisconnectedPart disconnectedPart3 in disconnectedParts)
							{
								if (disconnectedPart3.Part.gameObject.activeInHierarchy)
								{
									disconnectedPart3.Part.Body.RigidBody.AddTorque(UnityEngine.Random.insideUnitSphere * 100f);
								}
							}
							DestroyAndRecreateJoints(allowJointCreation: true);
							PartGroups.Clear();
							Aircraft.RemoveBody(this);
							RigidBodyGroup = null;
							if (raiseAircraftStructureChangedEvent)
							{
								Aircraft.AircraftStructureChanged();
							}
							GameWorld.Instance.FloatingOriginChanged -= FloatingOriginChanged;
							base.gameObject.name = $"Dead Body {Id}";
							base.gameObject.SetActive(value: false);
							return num;
						}
					}
				}
			}
		}

		private void EnableRigidBody(bool enabled)
		{
			if (_rigidBodyEnabled == enabled)
			{
				return;
			}
			_rigidBodyEnabled = enabled;
			if (enabled)
			{
				_rigidBodyComponent = base.gameObject.AddComponent<Rigidbody>();
				if (_rigidBodySettings != null)
				{
					_rigidBodySettings.Restore(_rigidBodyComponent);
					_rigidBodySettings = null;
				}
			}
			else
			{
				_rigidBodySettings = new RigidBodySettings(_rigidBodyComponent);
				UnityEngine.Object.Destroy(_rigidBodyComponent);
				_rigidBodyComponent = null;
			}
		}

		private IEnumerator FirstFrameUpdate()
		{
			yield return null;
			if (_rigidBody != null)
			{
				_rigidBody.centerOfMass = Vector3.zero;
			}
		}

		private void FloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			Vector3 delta = e.NewFloatingOriginOffset - e.OldFloatingOriginOffset;
			DragPhysics.OnFloatingOriginChanged(delta);
		}

		private void OnPartDisconnectExplosion(in DisconnectedPart part)
		{
			ExplosionScript.CreateExplosion(Aircraft, part.Part.transform.position, RigidBody.velocity, part.Force, part.ExplosionCascadeCount);
			this.PartDisconnectExplosion?.Invoke(this, new PartDisconnectExplosionEventArgs(Aircraft, part.Part, part.Part.transform.position, part.Force, part.ExplosionCascadeCount));
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (_rigidBodyEnabled)
			{
				_rigidBody.centerOfMass = Vector3.zero;
			}
			GameWorld.Instance.FloatingOriginChanged += FloatingOriginChanged;
			StartCoroutine(FirstFrameUpdate());
		}

		private void SetRootBody(BodyScript rootBody)
		{
			if (rootBody == null)
			{
				EnableRigidBody(enabled: true);
				_rigidBody.SetRootRigidBody(_rigidBodyComponent, null);
			}
			else
			{
				EnableRigidBody(enabled: false);
				_rigidBody.SetRootRigidBody(rootBody._rigidBodyComponent, base.transform);
			}
		}
	}
}
