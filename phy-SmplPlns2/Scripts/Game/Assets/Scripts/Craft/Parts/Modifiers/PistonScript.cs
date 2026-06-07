using System;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PistonScript : PartModifierScript
	{
		private AudioSource _audio;

		private BodyJoint _bodyJoint;

		private float _breakTimer;

		private InputControllerScript _controller;

		private float _currentPosition;

		private float _cycleTime;

		private Transform _expectedJointPosition;

		private ConfigurableJoint _joint;

		private bool _moving;

		private float _partScale = 1f;

		private Transform _pistonShaft;

		private GameObject _pistonShaftTelescope;

		private float _pitch;

		private float _speed;

		private bool _updatePistonShaft;

		private float _volume;

		public PistonData Piston { get; set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(PistonData piston)
		{
			Piston = piston;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				float value = UnityEngine.Random.value;
				if (value < 0.4f)
				{
					_speed = 0f;
				}
				else if (value < 0.8f)
				{
					_speed *= 0.25f;
				}
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterUpdate(OnUpdate);
		}

		private void BreakJoint()
		{
			_bodyJoint.Break(playSound: true);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			_moving = false;
			float num = _controller.Value;
			if (Piston.Cycle)
			{
				_cycleTime += num * Piston.Speed * Time.deltaTime * 20f;
				num = (Mathf.Cos(MathF.PI + _cycleTime) + 1f) / 2f;
			}
			if (!Piston.Extend)
			{
				num = 1f - num;
			}
			float num2 = num * Piston.Range * _partScale;
			float f = num2 - _currentPosition;
			if (Mathf.Abs(f) < 0.001f)
			{
				_currentPosition = num2;
			}
			else
			{
				_volume = Mathf.Clamp01(Mathf.Abs(f) * 25f);
				_pitch = Mathf.Clamp01(Mathf.Abs(f) * 50f);
				_moving = true;
				float step = (num2 - _currentPosition) * Time.deltaTime * _speed;
				_currentPosition = Utilities.StepTowards(_currentPosition, step, num2);
			}
			if (Piston.Cycle)
			{
				_currentPosition = num2;
			}
			if (_updatePistonShaft)
			{
				_pistonShaft.localPosition = new Vector3(0f, _currentPosition / _partScale, 0f);
			}
			if (_joint != null && !_bodyJoint.PartConnection.IsDestroyed)
			{
				_joint.connectedBody.WakeUp();
				_joint.GetComponent<Rigidbody>().WakeUp();
				float num3 = 0f;
				if (!Piston.Extend)
				{
					num3 = 1f * Piston.Range * _partScale;
				}
				_joint.targetPosition = new Vector3(_currentPosition - num3, 0f, 0f);
			}
			_pistonShaftTelescope.SetActive(_currentPosition > 0.39f);
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (base.PartScript.Part.PartScale.HasValue)
			{
				_partScale = base.PartScript.Part.PartScale.Value.y;
			}
			_controller = base.PartScript.GetModifier<InputControllerScript>();
			_expectedJointPosition = Utilities.FindFirstGameObjectMyselfOrChildren("ExpectedJointPosition", base.PartScript.gameObject).transform;
			_pistonShaftTelescope = Utilities.FindFirstGameObjectMyselfOrChildren("PistonShaftTelescope", base.PartScript.gameObject);
			_pistonShaft = Utilities.FindFirstGameObjectMyselfOrChildren("PistonShaft", base.PartScript.gameObject).transform;
			if (loadContext == CraftLoadContext.Flight)
			{
				_audio = base.PartScript.GetComponent<AudioSource>();
				_speed = Piston.Speed * Piston.Speed * Piston.MaxSpeed;
				int attachPointIndex = Piston.AttachPointIndex;
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
								Rigidbody component = jointForAttachPoint.GetComponent<Rigidbody>();
								if (base.PartScript.Body.RigidBody.PhysxRigidBody == component)
								{
									_bodyJoint = joint;
									_updatePistonShaft = true;
									_joint = jointForAttachPoint;
								}
							}
						}
					}
					else if (attachPointData.PartConnections.Count == 0)
					{
						_updatePistonShaft = true;
					}
				}
				if (!Piston.Extend)
				{
					_currentPosition = Piston.Range * _partScale;
				}
			}
			else
			{
				_pistonShaftTelescope.SetActive(value: false);
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (frame.CraftLoadContext != CraftLoadContext.Flight)
			{
				float num = 0f;
				if (!Piston.Extend)
				{
					num = Piston.Range * _partScale;
				}
				_pistonShaft.localPosition = new Vector3(0f, num / _partScale, 0f);
				_pistonShaftTelescope.SetActive(num > 0.39f);
			}
			else if (_joint != null && !_bodyJoint.Broken)
			{
				Vector3 position = _expectedJointPosition.position;
				Vector3 vector = _joint.connectedBody.transform.TransformPoint(_joint.connectedAnchor);
				if ((position - vector).sqrMagnitude > 0.0225f)
				{
					_breakTimer += frame.DeltaTime;
				}
				else
				{
					_breakTimer = 0f;
				}
				if (_breakTimer > 0.5f && !Piston.PreventBreaking)
				{
					BreakJoint();
				}
			}
			if (!(_audio != null))
			{
				return;
			}
			if (_moving)
			{
				if (!_audio.isPlaying)
				{
					_audio.Play();
					_audio.timeSamples = (int)(UnityEngine.Random.value * (float)_audio.clip.samples);
				}
				_audio.pitch = _pitch;
				_audio.volume = _volume * 0.5f;
			}
			else if (_audio.isPlaying)
			{
				_audio.Stop();
			}
		}
	}
}
