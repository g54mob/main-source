using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Events;
using Cysharp.Threading.Tasks;
using FishNet.Serializing;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class TargetingPodScript : PartModifierScript, ICameraVideoStreamSource
	{
		private const byte MessageDisableLaserTarget = 2;

		private const byte MessageLaserTargetPosition = 1;

		private Func<bool> _activeFunc;

		private HashSet<ICameraVideoStreamConsumer> _consumers = new HashSet<ICameraVideoStreamConsumer>();

		private float _fovMax = 20f;

		private float _fovMin = 1f;

		private Transform _podCameraMesh;

		private Transform _podSwivelMesh;

		private bool _resetTransitionTime;

		private Vector2 _slewFrameRequest;

		private bool _syncLaserTarget;

		private LaserTarget _target;

		private TargetingSystem _targetingSystem;

		private Vector3? _targetPosition;

		private TrackedTarget _trackedTarget;

		private float _transitionTimer;

		private CameraVideoStream _videoStream;

		private float _zoom;

		public TargetingPodData Data { get; set; }

		public float Fov { get; private set; }

		public bool IsActive { get; private set; }

		public string Name => $"{base.PartScript.Part.PartType.Name}-{base.PartScript.Part.Id}";

		public LaserTarget Target => _target;

		public TrackedTarget TrackedTarget => _trackedTarget;

		public float Zoom
		{
			get
			{
				return _zoom;
			}
			set
			{
				_zoom = Mathf.Clamp01(value);
				CalculateFov();
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightDefault);
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				Debug.LogWarning("TODO: Targeting pod damage");
			}
		}

		public override void OnReceiveNetworkMessage(byte messageType, PooledReader reader)
		{
			base.OnReceiveNetworkMessage(messageType, reader);
			if (messageType == 1)
			{
				_target.IsActive = true;
				Vector3 absolutePosition = reader.ReadVector3();
				_target.SetPosition(Utility.ConvertAbsoluteToFloatingOriginPosition(absolutePosition));
			}
		}

		public void ReleaseVideoStream(ICameraVideoStreamConsumer consumer)
		{
			_consumers.Remove(consumer);
			if (_consumers.Count == 0)
			{
				StopVideoStream();
			}
		}

		public ICameraVideoStream RequestVideoStream(ICameraVideoStreamConsumer consumer)
		{
			if (_videoStream == null)
			{
				RenderTexture renderTexture = new RenderTexture(512, 512, 24);
				renderTexture.Create();
				Camera camera = new GameObject("RenderCamera").AddComponent<Camera>();
				camera.transform.SetParent(base.transform, worldPositionStays: false);
				camera.targetTexture = renderTexture;
				camera.clearFlags = CameraClearFlags.Skybox;
				camera.backgroundColor = Color.black;
				camera.orthographic = false;
				camera.nearClipPlane = 1f;
				camera.farClipPlane = 50000f;
				_videoStream = new CameraVideoStream(this, renderTexture, camera);
			}
			_consumers.Add(consumer);
			return _videoStream;
		}

		public void SetLaserTargetPosition(Vector3 position)
		{
			_target.SetPosition(position);
			if (_target.IsActive)
			{
				_syncLaserTarget = true;
			}
		}

		public void Slew(Vector2 slew)
		{
			_slewFrameRequest += slew;
		}

		public void UpdateLaserTarget(Ray ray)
		{
			int layerMask = 76558336;
			Vector3? vector = Utility.GetTerrainOrSeaIntersection(ray, GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault(), Data.MaxDistance, layerMask);
			if (!vector.HasValue)
			{
				vector = ray.GetPoint(Data.MaxDistance);
				_target.IsActive = false;
			}
			else
			{
				_target.IsActive = true;
			}
			SetLaserTargetPosition(vector.Value);
		}

		protected virtual void OnDestroy()
		{
			AircraftScript aircraftScript = base.PartScript?.Aircraft;
			if ((object)aircraftScript != null)
			{
				aircraftScript.TeamChanged -= OnTeamChanged;
			}
			GameWorld.Instance.FloatingOriginChanged -= OnFloatingOriginChanged;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdate, CraftUpdateFlags.FlightLocal);
		}

		private void CalculateFov()
		{
			float t = Mathf.Pow(1f - _zoom, 2.5f);
			Fov = Mathf.Lerp(_fovMin, _fovMax, t);
		}

		private void DisableLaserTarget()
		{
			_targetPosition = null;
			_target.IsActive = false;
			if (_trackedTarget != null)
			{
				_targetingSystem.RemoveTarget(_trackedTarget);
				_trackedTarget = null;
			}
			base.PartScript.Aircraft.NetworkAircraft.SendPartNetworkMessage(2, base.PartScript.Part, delegate
			{
			});
		}

		private void EnableLaserTarget()
		{
			if (_trackedTarget == null)
			{
				_trackedTarget = _targetingSystem.AddTarget(_target);
			}
		}

		private void HandleInputs()
		{
			if (_slewFrameRequest.sqrMagnitude > 0f)
			{
				SlewImmediate(_slewFrameRequest);
			}
			bool flag = UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
			float num = Fov * 0.25f * Time.unscaledDeltaTime * (flag ? 4f : 1f);
			float targetingPodSlewLeftRight = base.Controls.TargetingPodSlewLeftRight;
			float targetingPodSlewUpDown = base.Controls.TargetingPodSlewUpDown;
			if (targetingPodSlewLeftRight != 0f || targetingPodSlewUpDown != 0f)
			{
				SlewImmediate(new Vector2(targetingPodSlewLeftRight * num, (0f - targetingPodSlewUpDown) * num));
			}
			float num2 = 0.125f * Time.unscaledDeltaTime * (flag ? 4f : 1f);
			float targetingPodZoom = base.Controls.TargetingPodZoom;
			if (targetingPodZoom != 0f)
			{
				Zoom += targetingPodZoom * num2;
			}
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			if (_targetPosition.HasValue)
			{
				_targetPosition += e.Delta;
			}
			_target?.SetPosition(_target.Position + e.Delta);
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			bool flag = _activeFunc() && _targetingSystem.Mode == TargetingSystem.TargetingSystemMode.AirToGround && base.PartScript.ConnectedToMainCockpit;
			if (IsActive != flag)
			{
				IsActive = flag;
				if (IsActive)
				{
					EnableLaserTarget();
				}
				else
				{
					DisableLaserTarget();
				}
			}
			if (IsActive)
			{
				if (!_target.IsActive && !_target.IsUserInteracting)
				{
					UpdateLaserTarget(new Ray(base.transform.position, base.transform.forward));
				}
				UpdateCamera();
			}
			else if (_videoStream != null)
			{
				StopVideoStream();
			}
			if (_syncLaserTarget && _target != null)
			{
				_syncLaserTarget = false;
				SyncLaserTargetPosition(_target.Position);
			}
			_slewFrameRequest = Vector2.zero;
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			craftScript.TeamChanged += OnTeamChanged;
			GameWorld.Instance.FloatingOriginChanged += OnFloatingOriginChanged;
			CalculateFov();
			_targetingSystem = base.PartScript.Aircraft.TargetingSystem;
			_target = new LaserTarget(this, craftScript.TeamId);
			_podSwivelMesh = Utilities.FindFirstGameObjectMyselfOrChildren("CameraSwivel", base.PartScript.gameObject).transform;
			_podCameraMesh = Utilities.FindFirstGameObjectMyselfOrChildren("Camera", base.PartScript.gameObject).transform;
			_activeFunc = base.Controls.GetActivatorGetter(Data.ActivationGroup, base.PartScript, valueIfZero: true);
			return UniTask.CompletedTask;
		}

		private void OnTeamChanged(object sender, TeamChangedEventArgs e)
		{
			_target.TeamId = e.NewTeamId;
		}

		private void SlewImmediate(Vector2 slew)
		{
			base.transform.localRotation *= Quaternion.AngleAxis(slew.y, Vector3.right) * Quaternion.AngleAxis(slew.x, Vector3.up);
			UpdateLaserTarget(new Ray(base.transform.position, base.transform.forward));
		}

		private void StopVideoStream()
		{
			if (_videoStream != null)
			{
				CameraVideoStream videoStream = _videoStream;
				_videoStream = null;
				videoStream.Release();
				_consumers.Clear();
			}
		}

		private void SyncLaserTargetPosition(Vector3 position)
		{
			base.PartScript.Aircraft.NetworkAircraft.SendPartNetworkMessage(1, base.PartScript.Part, delegate(PooledWriter w)
			{
				Vector3 value = Utility.ConvertFloatingOriginToAbsolutePosition(position);
				w.WriteVector3(value);
			});
		}

		private void UpdateCamera()
		{
			LaserTarget target = _target;
			if (target != null)
			{
				if (!target.IsUserInteracting)
				{
					if (_resetTransitionTime)
					{
						_transitionTimer = 0f;
						_resetTransitionTime = false;
					}
				}
				else
				{
					_resetTransitionTime = true;
				}
				_targetPosition = target.Position;
			}
			if (_targetPosition.HasValue)
			{
				_transitionTimer = Mathf.Clamp01(_transitionTimer + Time.unscaledDeltaTime * 2f);
				Quaternion b = Quaternion.LookRotation((_targetPosition.Value - base.transform.position).normalized, Vector3.up);
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, _transitionTimer);
				Vector3 vector = _podSwivelMesh.parent.transform.InverseTransformDirection(base.transform.forward);
				float z = 90f + Mathf.Atan2(vector.y, vector.x) * 57.29578f;
				_podSwivelMesh.localRotation = Quaternion.Euler(0f, 0f, z);
				vector = _podSwivelMesh.transform.InverseTransformDirection(base.transform.forward);
				float x = (0f - Mathf.Atan2(vector.y, vector.z)) * 57.29578f;
				_podCameraMesh.localRotation = Quaternion.Euler(x, 0f, 0f);
			}
			HandleInputs();
			if (_videoStream?.RenderCamera != null)
			{
				_videoStream.RenderCamera.fieldOfView = Fov;
			}
		}
	}
}
