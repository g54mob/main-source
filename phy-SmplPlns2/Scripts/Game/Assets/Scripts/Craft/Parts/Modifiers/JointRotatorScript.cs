using System;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Misc.SimpleBehaviours;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class JointRotatorScript : PartModifierScript, IVariableOutput
	{
		private float _angle;

		private AudioSource _audio;

		private float _audioVolume;

		private Vector3 _connectedPerpendicularVector;

		private Rigidbody _connectedRigidBody;

		private InputControllerScript _controller;

		private bool _enableBaseMesh = true;

		private bool _floppyJoint;

		private bool _freeSpin;

		private ConfigurableJoint _joint;

		private Vector3 _perpendicularVector;

		private NotifyOnDestroyScript _reparentedVisualMeshDestroyedNotifier;

		private Rigidbody _rigidBody;

		private float _speed;

		private float _targetAngle;

		private Transform _visualMesh;

		public bool IsDamaged { get; protected set; }

		public JointRotatorData JointRotator { get; set; }

		[VariableOutput("Current Angle")]
		private float BodyAngle { get; set; }

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light && !IsDamaged)
			{
				if (level == PartDamageLevel.Moderate && !JointRotator.AllowFreeSpin)
				{
					base.PartScript.Aircraft.DamageEffects.CreateFireSmall(base.PartScript, null);
				}
				float value = UnityEngine.Random.value;
				if (value < 0.4f)
				{
					IsDamaged = true;
				}
				else if (value < 0.8f)
				{
					_speed *= 0.25f;
				}
			}
		}

		public void UpdateOutputs()
		{
			if (_joint != null && _joint.connectedBody != null)
			{
				Vector3 vector = _joint.transform.TransformVector(-_joint.axis);
				Vector3 vector2 = Vector3.ProjectOnPlane(_joint.transform.TransformVector(_perpendicularVector), vector);
				Vector3 to = Vector3.ProjectOnPlane(_joint.connectedBody.transform.TransformVector(_connectedPerpendicularVector), vector);
				BodyAngle = Vector3.SignedAngle(vector2, to, vector);
			}
		}

		protected virtual void OnDestroy()
		{
			base.PartScript.Aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
			if (_reparentedVisualMeshDestroyedNotifier != null)
			{
				_reparentedVisualMeshDestroyedNotifier.OnDestroyed -= OnReparentedVisualMeshDestroyed;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocal | CraftUpdateFlags.DesignerScene);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private void EnableBaseMesh(bool enable)
		{
			if (_enableBaseMesh != enable)
			{
				_enableBaseMesh = enable;
				GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("RotatorBase", base.PartScript.gameObject);
				if (gameObject != null)
				{
					gameObject.SetActive(enable);
				}
			}
		}

		private void OnAircraftStructureChanged()
		{
			if (_rigidBody != base.PartScript.Body.RigidBody.PhysxRigidBody)
			{
				SetupJoint();
			}
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_freeSpin || _floppyJoint || _joint == null)
			{
				return;
			}
			float num = _targetAngle - _angle;
			if (JointRotator.ShortestAngle)
			{
				num = Mathf.DeltaAngle(_angle, _targetAngle);
			}
			if (num != 0f)
			{
				float num2 = num / Mathf.Abs(num) * _speed * frame.DeltaTime;
				if (Mathf.Abs(num2) > Mathf.Abs(num))
				{
					num2 = num;
				}
				if (!float.IsNaN(num2))
				{
					_angle += num2;
				}
			}
			_joint.targetRotation = Quaternion.Euler(0f - _angle, 0f, 0f);
			if (_rigidBody.IsSleeping())
			{
				_rigidBody.WakeUp();
			}
			if (_connectedRigidBody.IsSleeping())
			{
				_connectedRigidBody.WakeUp();
			}
		}

		private void OnReparentedVisualMeshDestroyed(object sender, EventArgs e)
		{
			MeshRenderer componentInChildren = _visualMesh.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			if (componentInChildren != null)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(componentInChildren, destroy: true);
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			_audio = base.transform.parent.GetComponent<AudioSource>();
			_audioVolume = _audio.volume;
			_audio.volume = 0f;
			_controller = base.PartScript.GetModifier<InputControllerScript>();
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Hinge", base.PartScript.gameObject);
			if (gameObject != null)
			{
				_visualMesh = gameObject.transform;
			}
			if (JointRotator.Range > 180f)
			{
				Debug.LogFormat("JointRotator Range ({0}) was beyond the max allowable in Unity5, capping at {1}", JointRotator.Range, 180f);
				JointRotator.Range = 180f;
			}
			if (base.LoadContext == CraftLoadContext.Flight && base.PartScript.PhysicsEnabled)
			{
				SetupJoint();
				base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				_audio.enabled = JointRotator.AudioEnabled && !_floppyJoint;
			}
			else if (JointRotator.Speed < 0.0001f || JointRotator.DisableBaseMesh)
			{
				EnableBaseMesh(enable: false);
			}
			else
			{
				EnableBaseMesh(enable: true);
			}
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (frame.CraftLoadContext == CraftLoadContext.Flight)
			{
				if (frame.Paused)
				{
					return;
				}
				if (_joint != null)
				{
					if (!IsDamaged)
					{
						_targetAngle = _controller.Value * JointRotator.Range;
					}
					if (_audio.isActiveAndEnabled && !_floppyJoint)
					{
						float num = Mathf.Abs(_targetAngle - _angle);
						_audio.volume = Mathf.Clamp01(num) * _audioVolume;
						_audio.pitch = Mathf.Lerp(0.5f, 1.5f, JointRotator.Speed) * Mathf.Clamp01(0.5f + 0.25f * num);
						if (_audio.volume > 0.1f && !_audio.isPlaying)
						{
							_audio.Play();
							_audio.timeSamples = (int)(UnityEngine.Random.value * (float)_audio.clip.samples);
						}
					}
					if (_visualMesh != null && !_floppyJoint)
					{
						_visualMesh.localRotation = Quaternion.Euler(0f, 0f - _angle, 0f);
					}
				}
				else if (_audio.isPlaying)
				{
					_audio.Stop();
				}
			}
			else if (JointRotator.Speed < 0.0001f || JointRotator.DisableBaseMesh)
			{
				EnableBaseMesh(enable: false);
			}
			else
			{
				EnableBaseMesh(enable: true);
			}
		}

		private void SetupJoint()
		{
			_joint = null;
			_rigidBody = null;
			_connectedRigidBody = null;
			int attachPointIndex = JointRotator.AttachPointIndex;
			if (base.PartScript.Part.AttachPoints.Count > attachPointIndex)
			{
				AttachPointData attachPointData = base.PartScript.Part.AttachPoints[attachPointIndex];
				if (attachPointData.PartConnections.Count == 1)
				{
					foreach (BodyJoint joint in base.PartScript.Body.Joints)
					{
						ConfigurableJoint jointForAttachPoint = joint.GetJointForAttachPoint(attachPointData);
						if (jointForAttachPoint != null)
						{
							_joint = jointForAttachPoint;
							_rigidBody = _joint.GetComponent<Rigidbody>();
							_connectedRigidBody = _joint.connectedBody;
							_joint.anchor += JointRotator.HingeOffset;
						}
					}
				}
			}
			_speed = JointRotator.Speed * JointRotator.Speed * JointRotator.MaxSpeed;
			if (_joint != null)
			{
				JointDrive angularXDrive = _joint.angularXDrive;
				angularXDrive.positionDamper *= JointRotator.DamperMultiplier;
				_joint.angularXDrive = angularXDrive;
				if (JointRotator.Range < 0.0001f && JointRotator.AllowFreeSpin)
				{
					_freeSpin = true;
					angularXDrive.positionDamper = 0f;
					angularXDrive.positionSpring = 0f;
					_joint.angularXDrive = angularXDrive;
				}
				else if (JointRotator.Speed < 0.0001f)
				{
					_floppyJoint = true;
					angularXDrive.positionDamper = 0f;
					angularXDrive.positionSpring = 0f;
					_joint.angularXDrive = angularXDrive;
					_joint.angularXMotion = ConfigurableJointMotion.Limited;
					SoftJointLimit lowAngularXLimit = _joint.lowAngularXLimit;
					lowAngularXLimit.limit = 0f - JointRotator.Range;
					_joint.lowAngularXLimit = lowAngularXLimit;
					lowAngularXLimit.limit = JointRotator.Range;
					_joint.highAngularXLimit = lowAngularXLimit;
				}
				if (_floppyJoint && _visualMesh != null)
				{
					_visualMesh.parent = _joint.connectedBody.transform;
					if (_reparentedVisualMeshDestroyedNotifier == null)
					{
						_reparentedVisualMeshDestroyedNotifier = _visualMesh.gameObject.AddComponent<NotifyOnDestroyScript>();
						_reparentedVisualMeshDestroyedNotifier.OnDestroyed += OnReparentedVisualMeshDestroyed;
					}
				}
				Vector3 normal = _joint.axis;
				Vector3.OrthoNormalize(ref normal, ref _perpendicularVector);
				_connectedPerpendicularVector = _joint.connectedBody.transform.InverseTransformVector(_joint.transform.TransformVector(_perpendicularVector));
			}
			if (JointRotator.Speed < 0.0001f || JointRotator.DisableBaseMesh)
			{
				EnableBaseMesh(enable: false);
			}
		}
	}
}
