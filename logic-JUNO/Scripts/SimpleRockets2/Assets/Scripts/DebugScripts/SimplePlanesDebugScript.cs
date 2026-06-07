using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.MapView.Items;
using ModApi;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Settings;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.DebugScripts
{
	internal class SimplePlanesDebugScript : MonoBehaviour
	{
		private const int QueueCapacity = 300;

		private float _accel;

		private float _accelMax;

		private GameObject _ball;

		[SerializeField]
		private bool _cancelGravity;

		[SerializeField]
		private bool _displayCenterOfMass;

		[SerializeField]
		private Transform _distanceObjectA;

		[SerializeField]
		private Transform _distanceObjectB;

		[SerializeField]
		private bool _distanceTrack;

		[SerializeField]
		private MapItem _distanceTrackItemA;

		[SerializeField]
		private MapItem _distanceTrackItemB;

		[SerializeField]
		private bool _distanceTrackRelativeSelf;

		[SerializeField]
		private bool _drawGravity;

		[SerializeField]
		private Camera _drawLineCamera;

		[SerializeField]
		private Transform _drawLineEnd;

		[SerializeField]
		private Transform _drawLineStart;

		[SerializeField]
		private float _forceForward;

		[SerializeField]
		private float _forceUp;

		[SerializeField]
		private Vector3 _gravity = Vector3.up;

		[SerializeField]
		private Vector3 _inertiaTensor;

		[SerializeField]
		private float _inertiaTensorMag;

		[SerializeField]
		private bool _inertiaTensorRecalculate;

		[SerializeField]
		private Vector3 _inertiaTensorRotation;

		[Range(0.1f, 10f)]
		[SerializeField]
		private float _inertiaTensorScale = 1f;

		[Range(0.1f, 100f)]
		[SerializeField]
		private float _inertiaTensorScale2 = 1f;

		private Vector3 _initialInertiaTensor;

		private Transform _inverseTransform;

		private Vector3d _lastDelta;

		private Vector3d _lastPosition;

		private Vector3? _lastVelocity;

		[SerializeField]
		private float _maxAngularVelocity;

		[SerializeField]
		private bool _measureDistanceToPlayer;

		private PartScript _partScript;

		[SerializeField]
		private bool _playAudioSource;

		[SerializeField]
		private ImageEffectsQualitySettings.ReEntryQuality _reentryQuality;

		private Rigidbody _rigidBody;

		[SerializeField]
		[Range(0f, 50f)]
		private float _rotateSpeed;

		[SerializeField]
		private bool _setBodyToOrbit;

		[SerializeField]
		private bool _showAcceleration;

		[SerializeField]
		private bool _showAccelerationResetMax;

		[SerializeField]
		private bool _showAngularVelocity;

		[SerializeField]
		private bool _showAngularVelocityLocal;

		[SerializeField]
		private bool _showAngularVelocityMag;

		[SerializeField]
		private bool _showColliderVolume;

		[SerializeField]
		private bool _showCollisionEnter;

		[SerializeField]
		private bool _showHeightAboveTerrain;

		[SerializeField]
		private bool _showIsSleeping;

		[SerializeField]
		private bool _showOnDestroy;

		[SerializeField]
		private bool _showOnDisable;

		[SerializeField]
		private bool _showOnEnable;

		[SerializeField]
		private bool _showPosition;

		[SerializeField]
		private bool _showPositionAbsolute;

		[SerializeField]
		private bool _showRotationLocal;

		[SerializeField]
		private bool _showRotationWorld;

		[SerializeField]
		private bool _showSurfaceRotation;

		[SerializeField]
		private bool _showTensor;

		[SerializeField]
		private bool _showTriggerEnter;

		[SerializeField]
		private bool _showUnderwaterPercent;

		[SerializeField]
		private bool _showVelocity;

		[SerializeField]
		private bool _showVelocityMag;

		[SerializeField]
		private bool _showWorldSale;

		[SerializeField]
		private float _sleepThreshold;

		[SerializeField]
		private int _solverIterationCount = -1;

		private List<double> _speeds = new List<double>(300);

		[SerializeField]
		private float _timeScale;

		[SerializeField]
		private float _torque;

		[SerializeField]
		private int _velocitySolverIterationCount = -1;

		public float Torque
		{
			get
			{
				return _torque;
			}
			set
			{
				_torque = value;
			}
		}

		public void Awake()
		{
			_gravity = Physics.gravity;
			_timeScale = Time.timeScale;
			_reentryQuality = Game.Instance.QualitySettings.ImageEffects.ReEntry.Value;
			_partScript = GetComponentInParent<PartScript>();
			_rigidBody = GetComponent<Rigidbody>();
			if (_rigidBody != null)
			{
				_inertiaTensor = _rigidBody.inertiaTensor;
				_inertiaTensorRotation = _rigidBody.inertiaTensorRotation.eulerAngles;
				_initialInertiaTensor = _inertiaTensor;
				_sleepThreshold = _rigidBody.sleepThreshold;
				_maxAngularVelocity = _rigidBody.maxAngularVelocity;
			}
		}

		public void FixedUpdate()
		{
			_gravity = Physics.gravity;
			_timeScale = Time.timeScale;
			Rigidbody component = GetComponent<Rigidbody>();
			if (!(component != null))
			{
				return;
			}
			if (_forceForward != 0f)
			{
				component.AddForce(component.transform.forward * _forceForward);
			}
			if (_forceUp != 0f)
			{
				component.AddForce(component.transform.up * _forceUp);
			}
			if (!Mathf.Approximately(Torque, 0f))
			{
				component.AddTorque(Torque * base.transform.forward);
			}
			if (_cancelGravity)
			{
				component.AddForce(-Physics.gravity, ForceMode.Acceleration);
			}
			if (true)
			{
				component.inertiaTensor = _inertiaTensor;
				component.inertiaTensorRotation = Quaternion.Euler(_inertiaTensorRotation);
				if (_inertiaTensorRecalculate)
				{
					_inertiaTensorRecalculate = false;
					component.ResetInertiaTensor();
					_initialInertiaTensor = (_inertiaTensor = component.inertiaTensor);
					_inertiaTensorRotation = component.inertiaTensorRotation.eulerAngles;
				}
				_initialInertiaTensor = component.inertiaTensor;
				_inertiaTensorMag = component.inertiaTensor.magnitude;
				if (_initialInertiaTensor.magnitude > 0f)
				{
					component.inertiaTensor = _initialInertiaTensor * (_inertiaTensorScale * _inertiaTensorScale2);
				}
			}
			if (!_showAcceleration)
			{
				return;
			}
			if (_lastVelocity.HasValue)
			{
				_accel = (component.velocity - _lastVelocity.Value).magnitude / Time.deltaTime;
				_accel /= 9.80665f;
				if (_showAccelerationResetMax)
				{
					_accelMax = 0f;
					_showAccelerationResetMax = false;
				}
				if (_accel > _accelMax)
				{
					_accelMax = _accel;
				}
			}
			_lastVelocity = component.velocity;
		}

		public void LateUpdate()
		{
			if (_displayCenterOfMass && _ball == null)
			{
				_ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				_ball.GetComponent<Collider>().enabled = false;
			}
			else if (!_displayCenterOfMass && _ball != null)
			{
				UnityEngine.Object.Destroy(_ball);
			}
			if (GetComponent<Rigidbody>() != null && _displayCenterOfMass)
			{
				_ball.transform.position = GetComponent<Rigidbody>().worldCenterOfMass;
			}
		}

		public void OnCollisionEnter(Collision collision)
		{
			if (_showCollisionEnter)
			{
				Debug.LogFormat("Collisions Enter with: {0}", collision.gameObject.name);
			}
		}

		public void OnTriggerEnter(Collider other)
		{
			if (_showTriggerEnter)
			{
				Debug.LogFormat("Trigger Enter with: {0}", other.name);
			}
		}

		[ContextMenu("CreatePlanePerpendicularToGravity")]
		private void CreatePlanePerpendicularToGravity()
		{
			ICraftScript craftScript = Game.Instance.FlightScene.CraftNode.CraftScript;
			Vector3 gravityNormal = craftScript.GravityNormal;
			Vector3 forward = Vector3.Cross(gravityNormal, Vector3.forward);
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Plane);
			obj.transform.localScale = Vector3.one * 1000f;
			obj.transform.position = craftScript.Transform.position;
			obj.transform.forward = forward;
			obj.transform.up = -gravityNormal;
			UnityEngine.Object.DestroyImmediate(obj.GetComponent<Collider>());
		}

		private void DistanceTrackUpdate(Vector3d posA, Vector3d posB, double distanceScale)
		{
			Vector3d vector3d = (posA - posB) / distanceScale;
			double magnitude = (vector3d - _lastDelta).magnitude;
			_lastDelta = vector3d;
			float num = ((!FlightSceneScript.Instance.TimeManager.CurrentMode.WarpMode) ? Time.deltaTime : (Time.deltaTime * (float)FlightSceneScript.Instance.TimeManager.CurrentMode.TimeMultiplier));
			double num2 = magnitude / (double)num;
			double num3 = ((_speeds.Count > 0) ? _speeds.Last() : num2);
			double num4 = ((_speeds.Count > 0) ? _speeds.Max() : num2);
			if ((num3 + num2) / 2.0 > num4)
			{
				Debug.LogErrorFormat("Sudden new max speed.  Previous: {0}, New: {1}", num4, num2);
			}
			_speeds.Add(num2);
			while (_speeds.Count > 300)
			{
				_speeds.RemoveAt(0);
			}
			DebugGraph.Log(num2);
		}

		private void OnDestroy()
		{
			if (_showOnDestroy)
			{
				Debug.Log(base.name + "- OnDestroy: - " + ((_partScript == null) ? base.name : _partScript.name));
			}
		}

		private void OnDisable()
		{
			if (_showOnDisable)
			{
				Debug.Log(base.name + "- OnDisable: - " + ((_partScript == null) ? base.name : _partScript.name));
			}
		}

		private void OnEnable()
		{
			if (_showOnEnable)
			{
				Debug.Log(base.name + "- OnEnable: - " + ((_partScript == null) ? base.name : _partScript.name));
			}
		}

		private void OnValidate()
		{
			if (!Utilities.CompareFloats(_timeScale, Time.timeScale))
			{
				Time.timeScale = _timeScale;
			}
			if (!Utilities.CompareVector3s(_gravity, Physics.gravity))
			{
				Physics.gravity = _gravity;
			}
			Rigidbody component = GetComponent<Rigidbody>();
			if (component != null)
			{
				if (Utilities.CompareVector3s(_inertiaTensor, component.inertiaTensor))
				{
					component.inertiaTensor = _inertiaTensor;
				}
				if (component.maxAngularVelocity != _maxAngularVelocity)
				{
					component.maxAngularVelocity = _maxAngularVelocity;
				}
				if (_solverIterationCount > 0 && _solverIterationCount != component.solverIterations)
				{
					component.solverIterations = _solverIterationCount;
				}
				if (_velocitySolverIterationCount > 0 && _velocitySolverIterationCount != component.solverVelocityIterations)
				{
					component.solverVelocityIterations = _velocitySolverIterationCount;
				}
			}
		}

		private void Update()
		{
			ICraftScript craftScript = Game.Instance?.FlightScene?.CraftNode?.CraftScript;
			if (_showWorldSale)
			{
				Debug.Log($"WorldScale: {base.transform.lossyScale}");
			}
			if (_drawGravity)
			{
				DebugGizmos.DrawRay("GravityVec", new Ray(base.transform.position, _gravity.normalized), _gravity.magnitude, Color.blue);
			}
			if (_distanceObjectA != null && _distanceObjectB != null)
			{
				Debug.Log($"{Time.time} - {(_distanceObjectA.position - _distanceObjectB.position).magnitude}m");
			}
			if (_reentryQuality != Game.Instance.QualitySettings.ImageEffects.ReEntry.Value)
			{
				Game.Instance.QualitySettings.ImageEffects.ReEntry.Value = _reentryQuality;
				Game.Instance.QualitySettings.ImageEffects.ReEntry.RaiseSettingChangedEvent();
			}
			if (_showSurfaceRotation)
			{
				IReferenceFrame referenceFrame = Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame;
				Quaterniond quaterniond = Game.Instance.FlightScene.CraftNode.Parent.RotationInverse * referenceFrame.FrameToPlanetRotation(base.transform.rotation);
				Debug.LogFormat("SurfaceRotation Quaternion: {0}, {1}, {2}, {3}", quaterniond.x, quaterniond.y, quaterniond.z, quaterniond.w);
			}
			if (_rotateSpeed > 0f)
			{
				base.transform.Rotate(base.transform.up, _rotateSpeed * Time.deltaTime, Space.World);
			}
			if (_drawLineEnd != null && _drawLineStart != null)
			{
				if (_drawLineCamera != null)
				{
					VectorLine.SetCamera3D(_drawLineCamera);
				}
				else
				{
					Debug.LogWarning("Set camera to ensure line is rendered properly.");
				}
			}
			if (_showAcceleration)
			{
				Debug.Log($"Acceleration (earth G): {_accel}g, Max: {_accelMax}g");
			}
			if (_showIsSleeping)
			{
				Debug.LogFormat("{0}: {1} (threshold - {2}", base.gameObject.GetInstanceID(), _rigidBody.IsSleeping(), _rigidBody.sleepThreshold);
			}
			if (_rigidBody != null)
			{
				_rigidBody.sleepThreshold = _sleepThreshold;
			}
			if (_showUnderwaterPercent)
			{
				if (_partScript != null)
				{
					Debug.LogFormat("{0} - Underwater %: {1}", _partScript.name, _partScript.WaterPhysics.UnderWaterAmount);
				}
				else
				{
					Debug.LogWarning("DebugScript: ShowUnderwaterPercent can only be used for an object on or a child of a part");
				}
			}
			if (_inverseTransform != null)
			{
				Debug.Log("Point: " + base.transform.InverseTransformPoint(_inverseTransform.position).ToString() + ", Vector: " + base.transform.InverseTransformVector(_inverseTransform.position).ToString() + ", Direction: " + base.transform.InverseTransformDirection(_inverseTransform.position).ToString());
			}
			if (_showPosition)
			{
				Debug.Log($"{Time.time}s, {base.name} - position - {base.transform.position}, mag: {base.transform.position.magnitude}");
			}
			if (_showPositionAbsolute)
			{
				Debug.LogWarning("Not Implemented for SR2");
			}
			if (_playAudioSource)
			{
				_playAudioSource = false;
				AudioSource component = GetComponent<AudioSource>();
				if (component != null)
				{
					component.Play();
				}
			}
			if (_showRotationLocal)
			{
				Debug.LogFormat("{0} - localEulerAngles - {1} ", base.name, base.transform.localEulerAngles);
			}
			if (_showRotationWorld)
			{
				Debug.LogFormat("{0} - eulerAngles - {1} ", base.name, base.transform.eulerAngles);
			}
			if (_measureDistanceToPlayer)
			{
				Debug.LogWarning("Not Implemented for SR2");
			}
			Rigidbody rigidbody = base.gameObject.GetComponent<Rigidbody>();
			try
			{
				if (_showTensor)
				{
					Vector3 vector = rigidbody.transform.TransformDirection(rigidbody.inertiaTensor);
					Vector3 position = rigidbody.transform.position;
					string text = rigidbody.GetInstanceID().ToString();
					DebugGizmos.DrawLine(text + "_x", position, position + vector.normalized * 50f, Color.red);
					Vector3 vector2 = rigidbody.transform.TransformDirection(rigidbody.inertiaTensorRotation * rigidbody.inertiaTensor);
					DebugGizmos.DrawLine(text + "_x(rot)", position, position + vector2.normalized * 50f, Color.yellow);
				}
				if (_setBodyToOrbit && craftScript != null)
				{
					IGameView gameView = Game.Instance.FlightScene.ViewManager.GameView;
					rigidbody.transform.position = gameView.ReferenceFrame.PlanetToFramePosition(craftScript.CraftNode.Orbit.Position);
					rigidbody.velocity = gameView.ReferenceFrame.PlanetToFrameVelocity(craftScript.CraftNode.Orbit.Velocity);
				}
				if (rigidbody != null)
				{
					_solverIterationCount = rigidbody.solverIterations;
					_velocitySolverIterationCount = rigidbody.solverVelocityIterations;
				}
				if (_showVelocity)
				{
					Debug.Log(base.name + "- velocity - " + rigidbody.velocity.ToString());
				}
				if (_showVelocityMag)
				{
					Debug.Log(base.name + "- velocity.magnitude - " + rigidbody.velocity.magnitude);
				}
				if (_showAngularVelocity)
				{
					double num = (double)rigidbody.angularVelocity.magnitude * 9.5492965964254;
					Debug.Log($"{base.name} - angularVelocity ({rigidbody.angularVelocity.magnitude}) ({num:0}rpm) - {rigidbody.angularVelocity}");
				}
				if (_showAngularVelocityMag)
				{
					Debug.Log(base.name + "- angularVelocity - " + rigidbody.angularVelocity.magnitude);
				}
				if (_showAngularVelocityLocal)
				{
					Debug.Log(base.name + "- angularVelocity Local - " + rigidbody.transform.InverseTransformDirection(rigidbody.angularVelocity).ToString());
				}
				if (_showColliderVolume)
				{
					bool flag = false;
					float mass = 0f;
					if (rigidbody == null)
					{
						rigidbody = base.gameObject.AddComponent<Rigidbody>();
						rigidbody.isKinematic = true;
						flag = true;
					}
					else
					{
						mass = rigidbody.mass;
					}
					rigidbody.SetDensity(5f);
					float num2 = rigidbody.mass / 5f;
					Debug.LogFormat("Collider Volume {0}m^3", num2);
					if (flag)
					{
						UnityEngine.Object.Destroy(rigidbody);
					}
					else
					{
						rigidbody.mass = mass;
					}
				}
			}
			catch (Exception)
			{
				if (rigidbody == null)
				{
					Debug.LogError("Error processing rigidbody debug info...a rigidbody must be present on this GameObject.");
				}
			}
			if (_showHeightAboveTerrain && craftScript != null)
			{
				Debug.Log($"AGL: {craftScript.GetAltitudeAboveGroundLevel(base.transform.position)}");
			}
			if (_distanceTrack)
			{
				DistanceTrackUpdate(posB: (!_distanceTrackRelativeSelf) ? _distanceTrackItemB.OrbitInfo.OrbitNode.SolarPosition : _lastPosition, posA: _distanceTrackItemA.OrbitInfo.OrbitNode.SolarPosition, distanceScale: 1.0);
				_lastPosition = _distanceTrackItemA.OrbitInfo.OrbitNode.SolarPosition;
			}
		}
	}
}
