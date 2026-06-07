using System;
using Assets.Scripts.Craft.Parts.Modifiers;
using ModApi.Automation;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using UnityEngine;

namespace Assets.Scripts.Automation
{
	public class AutoPilot : IAutoPilot, IDisposable
	{
		private float _alignment;

		private CommandPodScript _commandPod;

		private ICraftConfiguration _craftConfiguration;

		private bool _enabledLastFrame;

		private PidController _pidGravityAlign;

		private PidController _pidPitch;

		private PidController _pidRoll;

		private PidController _pidYaw;

		public int MaxPitchPidRange { get; set; } = 100;

		public int MaxRollPidRange { get; set; } = 100;

		public Vector3 PidGainsGrav
		{
			get
			{
				return _pidGravityAlign.PidGains;
			}
			set
			{
				_pidGravityAlign.PidGains = value;
			}
		}

		public Vector3 PidGainsPitch
		{
			get
			{
				return _pidPitch.PidGains;
			}
			set
			{
				_pidPitch.PidGains = value;
			}
		}

		public Vector3 PidGainsRoll
		{
			get
			{
				return _pidRoll.PidGains;
			}
			set
			{
				_pidRoll.PidGains = value;
			}
		}

		public void Dispose()
		{
			CraftControls craftControls = _commandPod?.Controls;
			if (craftControls != null)
			{
				craftControls.TargetHeadingChanged -= OnTargetHeadingChanged;
			}
		}

		public void Initialize(ICommandPodScript commandPod, IAutoPilot source)
		{
			Initialize(commandPod);
			CopyFrom(source as AutoPilot);
		}

		public void Initialize(ICommandPodScript commandPod)
		{
			_commandPod = commandPod as CommandPodScript;
			_craftConfiguration = commandPod.CraftConfiguration;
			_pidYaw = new PidController();
			_pidRoll = new PidController();
			_pidGravityAlign = new PidController();
			_pidPitch = new PidController();
			switch (_craftConfiguration.Type)
			{
			case CrafConfigurationType.Plane:
			{
				_pidGravityAlign.PidGains = new Vector3(2f, 0f, 0f);
				PidController pidGravityAlign = _pidGravityAlign;
				PidController pidPitch2 = _pidPitch;
				PidController pidYaw2 = _pidYaw;
				float? num = (_pidRoll.ErrorMaxAccum = 1f / 18f);
				float? num3 = (pidYaw2.ErrorMaxAccum = num);
				float? errorMaxAccum = (pidPitch2.ErrorMaxAccum = num3);
				pidGravityAlign.ErrorMaxAccum = errorMaxAccum;
				break;
			}
			case CrafConfigurationType.Rocket:
			{
				Vector3 vector = new Vector3(10f, 0f, 25f);
				PidController pidPitch = _pidPitch;
				PidController pidYaw = _pidYaw;
				Vector3 vector2 = (_pidRoll.PidGains = vector);
				Vector3 pidGains = (pidYaw.PidGains = vector2);
				pidPitch.PidGains = pidGains;
				break;
			}
			}
			_commandPod.Controls.TargetHeadingChanged += OnTargetHeadingChanged;
		}

		public void Update(bool enabled, FlightFrameData frame)
		{
			if (enabled)
			{
				if (_enabledLastFrame != enabled)
				{
					OnEnabled();
				}
				CraftControls controls = _commandPod.Controls;
				Vector3 pidGainPitch = _commandPod.Data.PidGainPitch;
				Vector3 pidGainRoll = _commandPod.Data.PidGainRoll;
				PidController pidPitch = _pidPitch;
				Vector3 pidGains = (_pidYaw.PidGains = pidGainPitch);
				pidPitch.PidGains = pidGains;
				_pidRoll.PidGains = pidGainRoll;
				UpdateAutopilot(frame.DeltaTime, controls.TargetDirection.Value, _commandPod.CraftConfiguration, _commandPod.Part.PartScript, _pidRoll, _pidPitch, _pidYaw, _pidGravityAlign, pidGainPitch, pidGainRoll, controls.RollInputReceived ? controls.Roll : 0f, out var roll, out var pitch, out var yaw, out _alignment);
				controls.Roll = roll;
				bool flag = false;
				if (controls.YawInputReceived)
				{
					flag = true;
				}
				else
				{
					controls.Yaw = yaw;
				}
				if (controls.PitchInputReceived)
				{
					flag = true;
				}
				else
				{
					controls.Pitch = pitch;
				}
				if (flag)
				{
					Game.Instance.FlightScene.FlightSceneUI.NavSphere.LockCurrentHeading();
				}
			}
			_enabledLastFrame = enabled;
		}

		private static Vector3 ScaleIntegral(PidController pidController, Vector3 basePidGains, float error, float angularVelocity)
		{
			float num;
			if (Mathf.Sign(angularVelocity) == Mathf.Sign(error))
			{
				num = 1f;
			}
			else
			{
				num = 1f - Mathf.Clamp01(Mathf.Abs(angularVelocity * 10f));
				if (num < 0.25f)
				{
					num = 0f;
					pidController.Reset();
				}
			}
			return new Vector3(basePidGains.x, basePidGains.y * num, basePidGains.z);
		}

		private static void UpdateAutopilot(float deltaTime, Vector3d targetDirection, ICraftConfiguration craftConfig, IPartScript part, PidController rollPid, PidController pitchPid, PidController yawPid, PidController pidGravityAlign, Vector3 basePitchPid, Vector3 baseRollPid, float rollInputReceived, out float roll, out float pitch, out float yaw, out float alignment)
		{
			roll = (pitch = (yaw = 0f));
			ICraftScript craftScript = part.CraftScript;
			Vector3 vector = craftScript.ReferenceFrame.PlanetToFrameVector(targetDirection);
			Vector3 vector2 = Quaternion.Inverse(craftScript.CenterOfMass.rotation) * vector;
			alignment = Vector3.Dot(vector, craftScript.CenterOfMass.forward);
			Vector3 vector3 = craftScript.CenterOfMass.InverseTransformDirection(part.BodyScript.RigidBody.angularVelocity);
			switch (craftConfig.Type)
			{
			case CrafConfigurationType.Plane:
			{
				Vector2 to3 = new Vector2(vector2.y, vector2.z);
				float num4 = Vector2.Dot(rhs: new Vector2(vector2.x, vector2.z), lhs: Vector2.right);
				float num5 = Vector2.Angle(Vector2.up, to3) * Mathf.Sign(to3.x) / 180f;
				num5 *= to3.magnitude;
				float num6 = 1f - Mathf.Pow(Mathf.Clamp01(Mathf.Abs(num4)), 0.1f);
				num5 *= num6;
				Vector3 vector4 = craftScript.CenterOfMass.InverseTransformDirection(-craftScript.GravityNormal);
				Vector2 vector5 = new Vector2(vector4.x, vector4.y);
				float magnitude = vector5.magnitude;
				vector5 = ((magnitude > 0.05f) ? (vector5 / magnitude) : Vector2.up);
				float num7 = Vector2.Dot(vector5, Vector2.up);
				pitchPid.PidGains = ScaleIntegral(pitchPid, basePitchPid, num5, vector3.x);
				rollPid.PidGains = ScaleIntegral(rollPid, baseRollPid, num4, vector3.z);
				float num8 = (1f - num7) * Mathf.Sign(Vector2.Dot(vector5, Vector2.right));
				float num9 = Mathf.Pow(Mathf.Abs(alignment), 1000f);
				num8 *= num9;
				if (rollInputReceived == 0f)
				{
					roll = 0f - Mathf.Clamp(rollPid.Update(num4, 0f, deltaTime, (0f - vector3.z) / MathF.PI), -1f, 1f);
					roll += 0f - Mathf.Clamp(pidGravityAlign.Update(num8, 0f, deltaTime, (0f - vector3.z) / MathF.PI), -1f, 1f);
				}
				else
				{
					roll = rollInputReceived;
				}
				pitch = Mathf.Clamp(pitchPid.Update(num5, 0f, deltaTime, (0f - vector3.x) / MathF.PI), -1f, 1f);
				break;
			}
			case CrafConfigurationType.Rocket:
			{
				Vector2 to = new Vector2(vector2.y, vector2.z);
				Vector2 to2 = new Vector2(vector2.x, vector2.z);
				float num = Vector2.Angle(Vector2.up, to) * Mathf.Sign(vector2.y);
				float num2 = Vector2.Angle(Vector2.up, to2) * Mathf.Sign(vector2.x);
				num /= 180f;
				num2 /= 180f;
				float num3 = 1f - Mathf.Clamp01(Mathf.Abs(vector3.z) * 0.5f);
				yaw = (0f - Mathf.Clamp(yawPid.Update(num2, 0f, deltaTime, vector3.y / MathF.PI), -1f, 1f)) * num3;
				pitch = Mathf.Clamp(pitchPid.Update(num, 0f, deltaTime, (0f - vector3.x) / MathF.PI), -1f, 1f) * num3;
				if (rollInputReceived == 0f)
				{
					roll = Mathf.Clamp(vector3.z, -1f, 1f);
				}
				else
				{
					roll = rollInputReceived;
				}
				break;
			}
			default:
				Debug.LogError($"Unknown configuration type: {craftConfig.Type}");
				break;
			}
		}

		private void CopyFrom(AutoPilot source)
		{
			_pidRoll = source._pidRoll.MakeCopy();
			_pidPitch = source._pidPitch.MakeCopy();
			_pidGravityAlign = source._pidGravityAlign.MakeCopy();
			ResetPids();
		}

		private void OnEnabled()
		{
			ResetPids();
		}

		private void OnTargetHeadingChanged(Quaterniond? newHeading, Quaterniond? oldHeading)
		{
			ResetPids();
		}

		private void ResetPids()
		{
			_pidGravityAlign.Reset();
			_pidPitch.Reset();
			_pidRoll.Reset();
			_pidYaw.Reset();
		}
	}
}
