using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.Messages;
using Cysharp.Threading.Tasks;
using FishNet.Serializing;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class MagnetScript : PartModifierScript, IWinchCableAttachment
	{
		private static class MessageTypes
		{
			public const byte CreateMagnetJoint = 1;

			public const byte DestroyMagnetJoint = 2;
		}

		private class MagneticJoint
		{
			public Transform BodyTransform { get; set; }

			public float DistanceSquared
			{
				get
				{
					Vector3 vector = BodyTransform.TransformPoint(Joint.anchor);
					Vector3 vector2 = TargetBody.transform.TransformPoint(Joint.connectedAnchor);
					return (vector - vector2).sqrMagnitude;
				}
			}

			public ConfigurableJoint Joint { get; set; }

			public Rigidbody TargetBody { get; set; }

			public void Break()
			{
				UnityEngine.Object.Destroy(Joint);
				Joint = null;
				BodyTransform = null;
				TargetBody = null;
			}
		}

		private bool _active;

		private Func<bool> _activeFunc;

		private float _animateBackToZero;

		private AudioSource _attachAudio;

		private AudioSource _audio;

		private Transform _cableAttachPoint;

		private Transform _centerTransform;

		private GameObject _magnetCollider;

		private List<MagneticJoint> _magneticJoints = new List<MagneticJoint>();

		private Vector3 _magnetLocalPositionToJoint;

		private Vector3 _magnetLocalRotationToTarget;

		private NetworkJointScript _networkJoint;

		private float? _restoreDrag;

		private Transform _visualRoot;

		private Vector3 _visualRootOrigin;

		public bool Active
		{
			get
			{
				return _active;
			}
			private set
			{
				if (_active != value)
				{
					_active = value;
					if (!_active)
					{
						DestroyMagneticJoints();
					}
					else
					{
						_audio.Play();
					}
					if (_magnetCollider != null && _magnetCollider.activeSelf != Active)
					{
						_magnetCollider.SetActive(Active);
					}
				}
			}
		}

		public Transform CableAttachmentTransform => _cableAttachPoint;

		public bool IsDamaged { get; private set; }

		public MagnetData Magnet { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void OnColliderEnterMagneticField(Collider other)
		{
			if (_networkJoint != null || !Active)
			{
				return;
			}
			Rigidbody otherRigidBody = other.GetComponentInParent<Rigidbody>();
			BodyScript body = base.PartScript.Body;
			if (otherRigidBody != null && otherRigidBody != body.RigidBody.PhysxRigidBody && other.GetComponentInParent<IgnoreMagnetScript>() == null && !_magneticJoints.Where((MagneticJoint x) => x.TargetBody == otherRigidBody).Any())
			{
				Vector3 vector = other.ClosestPoint(_centerTransform.position);
				NetworkAircraftScript componentInParent = otherRigidBody.GetComponentInParent<NetworkAircraftScript>();
				if (componentInParent != null && !componentInParent.IsOwner)
				{
					CreateJointWithRemoteAircraft(otherRigidBody, body, vector);
				}
				else
				{
					ConfigurableJoint joint = CreateJoint(base.PartScript.Body, _centerTransform.position, body.transform.InverseTransformDirection(base.transform.up), body.transform.InverseTransformDirection(base.transform.right), otherRigidBody, vector, 1000f * Magnet.Power);
					MagneticJoint item = new MagneticJoint
					{
						Joint = joint,
						BodyTransform = base.PartScript.Body.transform,
						TargetBody = otherRigidBody
					};
					_magneticJoints.Add(item);
				}
				if (!_attachAudio.isPlaying)
				{
					_attachAudio.Play();
				}
			}
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light && UnityEngine.Random.value < 0.3f)
			{
				IsDamaged = true;
			}
		}

		public override void OnReceiveNetworkMessage(byte messageType, PooledReader reader)
		{
			base.OnReceiveNetworkMessage(messageType, reader);
			switch (messageType)
			{
			case 1:
			{
				CreateNetworkMagnetJointInfo jointInfo = new CreateNetworkMagnetJointInfo();
				jointInfo.SerializeRead(reader);
				if (_networkJoint == null)
				{
					FlightScenePlayer flightScenePlayer = FlightSceneScript.Instance.AllPlayers.Where((FlightScenePlayer x) => x.NetworkPlayer.PlayerId == jointInfo.TargetPlayerID).FirstOrDefault();
					if (flightScenePlayer?.Aircraft != null)
					{
						BodyScript body = flightScenePlayer.Aircraft.GetBody(jointInfo.TargetBodyID);
						NetworkJointScript.SimulationModeType simulationMode = (body.Aircraft.NetworkAircraft.IsOwner ? NetworkJointScript.SimulationModeType.Target : NetworkJointScript.SimulationModeType.Observer);
						CreateNetworkJointInternal(base.PartScript.Body, jointInfo.SourceLocalPosition, body, jointInfo.TargetLocalPosition, jointInfo.Power, simulationMode);
						_magnetLocalPositionToJoint = jointInfo.MagnetLocalPosition;
						_magnetLocalRotationToTarget = jointInfo.MagnetLocalRotation;
					}
				}
				else
				{
					Debug.Log("Network joint already exists on this part.");
				}
				break;
			}
			case 2:
				DestroyNetworkJoint();
				break;
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_centerTransform = Utilities.GetFirstChild<Transform>("Center", base.PartScript.gameObject);
				_cableAttachPoint = Utilities.GetFirstChild<Transform>("CableAttachPoint", base.PartScript.gameObject);
				_visualRoot = Utilities.GetFirstChild<Transform>("VisualRoot", base.PartScript.gameObject);
				_visualRootOrigin = _visualRoot.localPosition;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private static ConfigurableJoint CreateJoint(BodyScript jointBody, Vector3 jointPosition, Vector3 jointAxis, Vector3 secondaryAxis, Rigidbody connectedBody, Vector3 connectedPosition, float jointForce)
		{
			ConfigurableJoint configurableJoint = jointBody.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = connectedBody;
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.axis = jointAxis;
			configurableJoint.secondaryAxis = secondaryAxis;
			configurableJoint.anchor = jointBody.transform.InverseTransformPoint(jointPosition);
			configurableJoint.connectedAnchor = connectedBody.transform.InverseTransformPoint(connectedPosition);
			configurableJoint.xMotion = ConfigurableJointMotion.Free;
			configurableJoint.yMotion = ConfigurableJointMotion.Free;
			configurableJoint.zMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Free;
			configurableJoint.enableCollision = true;
			JointDrive jointDrive = new JointDrive
			{
				maximumForce = jointForce,
				positionSpring = jointForce,
				positionDamper = 1f
			};
			configurableJoint.xDrive = jointDrive;
			configurableJoint.yDrive = jointDrive;
			configurableJoint.zDrive = jointDrive;
			return configurableJoint;
		}

		private void CreateJointWithRemoteAircraft(Rigidbody otherRigidBody, BodyScript body, Vector3 jointPosition)
		{
			BodyScript componentInParent = otherRigidBody.GetComponentInParent<BodyScript>();
			if (componentInParent != null)
			{
				Vector3 sourceLocalPosition = body.transform.InverseTransformPoint(_centerTransform.position);
				Vector3 vector = componentInParent.transform.InverseTransformPoint(jointPosition);
				CreateNetworkJointInternal(body, sourceLocalPosition, componentInParent, vector, 1000f * Magnet.Power, NetworkJointScript.SimulationModeType.Source);
				_magnetLocalPositionToJoint = vector;
				_magnetLocalRotationToTarget = (Quaternion.Inverse(componentInParent.transform.rotation) * _visualRoot.rotation).eulerAngles;
				Vector3 position = _centerTransform.position;
				Vector3 direction = jointPosition - position;
				float maxDistance = direction.magnitude * 1.1f;
				direction.Normalize();
				if (Physics.Raycast(position, direction, out var hitInfo, maxDistance))
				{
					_ = hitInfo.normal;
					_magnetLocalRotationToTarget = (Quaternion.Inverse(componentInParent.transform.rotation) * Quaternion.FromToRotation(-Vector3.up, hitInfo.normal)).eulerAngles;
				}
				else
				{
					_magnetLocalRotationToTarget = (Quaternion.Inverse(componentInParent.transform.rotation) * _visualRoot.rotation).eulerAngles;
				}
				SendCreateNetworkJointMessage(sourceLocalPosition, componentInParent, vector, 1000f * Magnet.Power);
				_restoreDrag = base.PartScript.Body.RigidBody.drag;
				base.PartScript.Body.RigidBody.drag = 5f;
			}
		}

		private void CreateNetworkJointInternal(BodyScript sourceBody, Vector3 sourceLocalPosition, BodyScript targetBody, Vector3 targetLocalPosition, float power, NetworkJointScript.SimulationModeType simulationMode)
		{
			GameObject gameObject = new GameObject("Network Joint");
			gameObject.transform.parent = sourceBody.transform;
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = sourceLocalPosition;
			_networkJoint = gameObject.AddComponent<NetworkJointScript>();
			_networkJoint.Initialize(sourceBody, sourceLocalPosition, targetBody, targetLocalPosition, power, simulationMode);
		}

		private void DestroyMagneticJoints()
		{
			foreach (MagneticJoint magneticJoint in _magneticJoints)
			{
				UnityEngine.Object.Destroy(magneticJoint.Joint);
			}
			_magneticJoints.Clear();
			if (_networkJoint != null)
			{
				DestroyNetworkJoint();
			}
			Active = false;
		}

		private void DestroyNetworkJoint()
		{
			if (_networkJoint != null)
			{
				Debug.Log("Destroying network joint");
				if (base.PartScript.PhysicsEnabled)
				{
					base.PartScript.Aircraft.NetworkAircraft.SendPartNetworkMessage(2, base.PartScript.Part, delegate
					{
					});
				}
				_networkJoint.DestroyJoint();
				_networkJoint = null;
				if (_restoreDrag.HasValue)
				{
					base.PartScript.Body.RigidBody.drag = _restoreDrag.Value;
					_restoreDrag = null;
				}
			}
			else
			{
				Debug.Log("Network joint does not exist");
			}
		}

		private void OnAircraftStructureChanged()
		{
			DestroyMagneticJoints();
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			Active = !IsDamaged && _activeFunc();
			if (_networkJoint != null && (!_networkJoint.BodiesAlive || _networkJoint.Distance > 50f))
			{
				DestroyNetworkJoint();
			}
			for (int num = _magneticJoints.Count - 1; num >= 0; num--)
			{
				MagneticJoint magneticJoint = _magneticJoints[num];
				if (magneticJoint.DistanceSquared > 0.16000001f)
				{
					magneticJoint.Break();
					_magneticJoints.RemoveAt(num);
				}
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_audio = base.transform.parent.GetComponent<AudioSource>();
			if (loadContext == CraftLoadContext.Flight)
			{
				MagnetColliderScript componentInChildren = base.PartScript.GetComponentInChildren<MagnetColliderScript>(includeInactive: true);
				if (base.PartScript.PhysicsEnabled)
				{
					base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
					componentInChildren.Initialize(this);
					_magnetCollider = componentInChildren.gameObject;
				}
				else
				{
					componentInChildren.gameObject.SetActive(value: false);
				}
				_attachAudio = componentInChildren.GetComponent<AudioSource>();
				if (Magnet.ActivationGroup != "None")
				{
					_activeFunc = base.Controls.GetActivatorGetter(Magnet.ActivationGroup, base.PartScript);
				}
				else
				{
					_activeFunc = () => false;
				}
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_networkJoint?.TargetBodyTransform != null)
			{
				_visualRoot.SetPositionAndRotation(_networkJoint.TargetBodyTransform.TransformPoint(_magnetLocalPositionToJoint), _networkJoint.TargetBodyTransform.rotation * Quaternion.Euler(_magnetLocalRotationToTarget));
				_animateBackToZero = 0.5f;
			}
			else if (_animateBackToZero > 0f)
			{
				_animateBackToZero -= Time.deltaTime;
				float t = (0.5f - _animateBackToZero) / 0.5f;
				_visualRoot.SetLocalPositionAndRotation(Vector3.Lerp(_visualRoot.localPosition, _visualRootOrigin, t), Quaternion.Lerp(_visualRoot.localRotation, Quaternion.identity, t));
			}
		}

		private void SendCreateNetworkJointMessage(Vector3 sourceLocalPosition, BodyScript targetBody, Vector3 targetLocalPosition, float power)
		{
			CreateNetworkMagnetJointInfo jointInfo = new CreateNetworkMagnetJointInfo
			{
				MagnetLocalPosition = _magnetLocalPositionToJoint,
				MagnetLocalRotation = _magnetLocalRotationToTarget,
				Power = power,
				SourceLocalPosition = sourceLocalPosition,
				TargetOwnerID = targetBody.Aircraft.NetworkAircraft.OwnerId,
				TargetPlayerID = targetBody.Aircraft.NetworkAircraft.PlayerId,
				TargetBodyID = targetBody.Id,
				TargetLocalPosition = targetLocalPosition
			};
			base.PartScript.Aircraft.NetworkAircraft.SendPartNetworkMessage(1, base.PartScript.Part, delegate(PooledWriter w)
			{
				jointInfo.SerializeWrite(w);
			});
		}
	}
}
