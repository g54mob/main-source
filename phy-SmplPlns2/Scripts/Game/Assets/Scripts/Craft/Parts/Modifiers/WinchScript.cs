using System;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class WinchScript : PartModifierScript
	{
		private const float BreakMagnitude = 5000f;

		private AudioSource _audio;

		private Transform _cable;

		private Transform _cableAttachmentTransform;

		private AttachPointData _cableAttachPoint;

		private Vector3 _cableConnectionPointLocalPosition;

		private Transform _coilMesh;

		private Rigidbody _connectedRigidBody;

		private InputControllerScript _controller;

		private ConfigurableJoint _joint;

		private float _jointScale = 1f;

		private bool _playAudio;

		private float _range;

		private Rigidbody _rigidBody;

		private float _targetRange;

		public bool IsDamaged { get; private set; }

		public WinchData Winch { get; set; }

		public void OnAttachPointMoved(AttachPointData attachPoint)
		{
			Vector3 delta = base.PartScript.transform.TransformPoint(attachPoint.Position) - attachPoint.AttachPointScript.transform.position;
			attachPoint.AttachPointScript.transform.localPosition = attachPoint.Position;
			if (attachPoint.PartConnections.Count == 1)
			{
				RepositionParts(base.PartScript.Part, attachPoint.PartConnections[0], delta);
			}
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light && UnityEngine.Random.value < 0.3f)
			{
				IsDamaged = true;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterFixedUpdate(OnFixedUpdateLocal, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterLateUpdate(OnLateUpdateFlightLocal, CraftUpdateFlags.FlightLocalUnpaused);
			registrar.RegisterLateUpdate(OnLateUpdateFlightRemote, CraftUpdateFlags.FlightRemoteUnpaused);
			registrar.RegisterUpdate(OnUpdateDesigner, CraftUpdateFlags.DesignerDefault);
		}

		private void BreakJoint()
		{
			foreach (BodyJoint joint in base.PartScript.Body.Joints)
			{
				if (joint.HasJoint(_joint))
				{
					joint.Break(playSound: true);
					break;
				}
			}
		}

		private void OnAircraftStructureChanged()
		{
			if (_rigidBody != base.PartScript.Body.RigidBody.PhysxRigidBody)
			{
				RefreshAttachedPartReference();
				SetupJoint(_cableAttachPoint);
			}
		}

		private void OnFixedUpdateLocal(in CraftUpdateFrameData frame)
		{
			_playAudio = false;
			if (!(_joint != null) || frame.Paused)
			{
				return;
			}
			if (_controller.Active && !IsDamaged)
			{
				float num = _targetRange - _range;
				if (num != 0f)
				{
					_playAudio = true;
					float num2 = Mathf.Lerp(0.1f, 1f, Mathf.Clamp01(Mathf.Abs(num) * 2f));
					_coilMesh.Rotate(new Vector3(180f * num2 * (float)Math.Sign(num) * Winch.Speed * frame.DeltaTime, 0f, 0f));
					float num3 = Winch.Speed * num2;
					_range = Utilities.StepTowards(_range, num3 * frame.DeltaTime, _targetRange);
				}
			}
			SoftJointLimit linearLimit = _joint.linearLimit;
			linearLimit.limit = _range * _jointScale;
			_joint.linearLimit = linearLimit;
			_connectedRigidBody?.WakeUp();
		}

		private void OnLateUpdateFlightLocal(in CraftUpdateFrameData frame)
		{
			UpdateCableFromJoint();
			UpdateVolume();
			_targetRange = _controller.Value * (Winch.Range - Winch.MinRange) + Winch.MinRange;
		}

		private void OnLateUpdateFlightRemote(in CraftUpdateFrameData frame)
		{
			if (_cableAttachmentTransform != null)
			{
				Vector3 connectionPoint = _cableAttachmentTransform.TransformPoint(_cableConnectionPointLocalPosition);
				UpdateCable(connectionPoint);
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			_audio = base.transform.parent.GetComponent<AudioSource>();
			_controller = base.PartScript.GetModifier<InputControllerScript>();
			_cable = Utilities.FindFirstGameObjectMyselfOrChildren("Cable", base.PartScript.gameObject).transform;
			_coilMesh = Utilities.FindFirstGameObjectMyselfOrChildren("CoilMesh", base.PartScript.gameObject).transform;
			_range = Winch.MinRange;
			if (frame.CraftLoadContext == CraftLoadContext.Flight)
			{
				RefreshAttachedPartReference();
				if (_cableAttachmentTransform != null)
				{
					Vector3 position = base.PartScript.transform.TransformPoint(_cableAttachPoint.Position);
					_cableConnectionPointLocalPosition = _cableAttachmentTransform.InverseTransformPoint(position);
				}
				if (!frame.Craft.RemoteAircraft)
				{
					SetupJoint(_cableAttachPoint);
					base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				}
			}
		}

		private void OnUpdateDesigner(in CraftUpdateFrameData frame)
		{
			AttachPointScript attachPointScript = base.PartScript.AttachPointScripts[Winch.AttachPointIndex];
			UpdateCable(attachPointScript.transform.position);
		}

		private void RefreshAttachedPartReference()
		{
			_cableAttachPoint = null;
			_cableAttachmentTransform = null;
			int attachPointIndex = Winch.AttachPointIndex;
			if (base.PartScript.Part.AttachPoints.Count <= attachPointIndex)
			{
				return;
			}
			AttachPointData attachPointData = base.PartScript.Part.AttachPoints[attachPointIndex];
			if (attachPointData.PartConnections.Count != 1)
			{
				return;
			}
			_cableAttachPoint = attachPointData;
			PartScript partScript = _cableAttachPoint.PartConnections[0].GetOtherPart(base.PartScript.Part)?.PartScript;
			if (partScript != null)
			{
				IWinchCableAttachment componentInChildren = partScript.GetComponentInChildren<IWinchCableAttachment>();
				if (componentInChildren != null)
				{
					_cableAttachmentTransform = componentInChildren.CableAttachmentTransform;
				}
				else
				{
					_cableAttachmentTransform = partScript.transform;
				}
			}
		}

		private void RepositionParts(PartData part, PartConnection partConnection, Vector3 delta)
		{
			PartGraph partGraph = new PartGraph(partConnection.GetOtherPart(part), part);
			if (!partGraph.HasCockpit)
			{
				foreach (PartData part2 in partGraph.Parts)
				{
					part2.PartScript.transform.position += delta;
				}
				return;
			}
			partConnection.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: false);
		}

		private void SetupJoint(AttachPointData cableAttachPoint)
		{
			_joint = null;
			_rigidBody = null;
			_connectedRigidBody = null;
			if (base.PartScript.Part.PartScale.HasValue)
			{
				_jointScale = base.PartScript.Part.PartScale.Value.y;
			}
			if (cableAttachPoint == null)
			{
				return;
			}
			foreach (BodyJoint joint in base.PartScript.Body.Joints)
			{
				ConfigurableJoint jointForAttachPoint = joint.GetJointForAttachPoint(cableAttachPoint);
				if (jointForAttachPoint != null)
				{
					_joint = jointForAttachPoint;
					_rigidBody = _joint.GetComponent<Rigidbody>();
					_connectedRigidBody = _joint.connectedBody;
					_joint.breakForce = 5000f * Winch.BreakScale;
					if (cableAttachPoint.PartConnections[0].GetOtherAttachPoint(cableAttachPoint) != null)
					{
						_joint.autoConfigureConnectedAnchor = false;
						_joint.enableCollision = true;
						cableAttachPoint.PartConnections[0].GetOtherPart(base.PartScript.Part);
						Vector3 position = base.PartScript.transform.TransformPoint(cableAttachPoint.Position);
						_joint.connectedAnchor = _connectedRigidBody.transform.InverseTransformPoint(position);
					}
				}
			}
			if (_joint != null)
			{
				JointDrive jointDrive = new JointDrive
				{
					maximumForce = 0f,
					positionSpring = 0f,
					positionDamper = 0f
				};
				_joint.linearLimitSpring = new SoftJointLimitSpring
				{
					damper = 1f,
					spring = 10000f
				};
				_joint.xDrive = jointDrive;
				_joint.yDrive = jointDrive;
				_joint.zDrive = jointDrive;
				_joint.angularXDrive = jointDrive;
				_joint.angularYZDrive = jointDrive;
				_joint.xMotion = ConfigurableJointMotion.Limited;
				_joint.yMotion = ConfigurableJointMotion.Limited;
				_joint.zMotion = ConfigurableJointMotion.Limited;
				_joint.angularXMotion = ConfigurableJointMotion.Free;
				_joint.angularYMotion = ConfigurableJointMotion.Free;
				_joint.angularZMotion = ConfigurableJointMotion.Free;
			}
		}

		private void UpdateCable(Vector3 connectionPoint)
		{
			Vector3 vector = _cable.parent.InverseTransformPoint(connectionPoint);
			float magnitude = vector.magnitude;
			if (magnitude > 0f)
			{
				if (!_cable.gameObject.activeSelf)
				{
					_cable.gameObject.SetActive(value: true);
				}
				_cable.localScale = new Vector3(0.03f, magnitude * 0.5f, 0.03f);
				_cable.localPosition = vector * 0.5f;
				if (magnitude > 0.05f)
				{
					Quaternion quaternion = Quaternion.Euler(90f, 0f, 0f);
					Quaternion quaternion2 = Quaternion.LookRotation(vector.normalized);
					_cable.localRotation = quaternion2 * quaternion;
				}
				else
				{
					_cable.localRotation = Quaternion.identity;
				}
			}
			else if (_cable.gameObject.activeSelf)
			{
				_cable.gameObject.SetActive(value: false);
			}
		}

		private void UpdateCableFromJoint()
		{
			if (_joint != null)
			{
				Vector3 connectionPoint = _cableAttachmentTransform.TransformPoint(_cableConnectionPointLocalPosition);
				UpdateCable(connectionPoint);
			}
			else if (_cable.gameObject.activeSelf)
			{
				_cable.gameObject.SetActive(value: false);
			}
		}

		private void UpdateVolume()
		{
			if (_joint != null)
			{
				float volume = _audio.volume;
				if (_playAudio)
				{
					float b = Mathf.Clamp01(0.4f * Winch.Volume);
					volume = Mathf.Lerp(volume, b, Time.deltaTime * 5f);
				}
				else
				{
					volume = Mathf.Lerp(volume, 0f, Time.deltaTime * 10f);
				}
				if (volume > 0.1f && !_audio.isPlaying)
				{
					_audio.Play();
					_audio.volume = volume;
				}
				else if (volume < 0.01f && _audio.isPlaying)
				{
					_audio.Stop();
					_audio.volume = 0f;
				}
				else if (_audio.isPlaying)
				{
					_audio.volume = volume;
				}
			}
			else if (_audio.isPlaying)
			{
				_audio.Stop();
			}
		}
	}
}
