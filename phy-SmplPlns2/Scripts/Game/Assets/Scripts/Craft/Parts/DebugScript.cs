using System;
using Assets.Scripts.Flight;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class DebugScript : MonoBehaviour
	{
		private GameObject _ball;

		[SerializeField]
		private bool _calculateCenterOfMassOfAllChildBodies;

		[SerializeField]
		private bool _cancelGravity;

		[SerializeField]
		private bool _displayCenterOfMass;

		[SerializeField]
		private float _forceGravity;

		[SerializeField]
		private Vector3 _gravity = Vector3.up;

		[SerializeField]
		private Vector3 _inertiaTensor;

		[SerializeField]
		private Transform _inverseTransform;

		[SerializeField]
		private float _maxAngularVelocity;

		[SerializeField]
		private Transform _measureDistanceA;

		[SerializeField]
		private Transform _measureDistanceB;

		[SerializeField]
		private bool _measureDistanceToPlayer;

		private PartScript _partScript;

		[SerializeField]
		private bool _playAudioSource;

		private Rigidbody _rigidBody;

		[SerializeField]
		private float _setSpeed;

		[SerializeField]
		private bool _showAllCenterOfMassesLocal;

		[SerializeField]
		private bool _showAngularVelocity;

		[SerializeField]
		private bool _showAngularVelocityLocal;

		[SerializeField]
		private bool _showAngularVelocityRotationPerUpdate;

		[SerializeField]
		private bool _showColliderVolume;

		[SerializeField]
		private bool _showCollissionEnter;

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
		private bool _showTriggerEnter;

		[SerializeField]
		private bool _showUnderwaterPercent;

		[SerializeField]
		private bool _showVelocity;

		[SerializeField]
		private bool _showVelocityMag;

		[SerializeField]
		private float _sleepThreshold;

		[SerializeField]
		private int _solverIterationCount = int.MinValue;

		[SerializeField]
		private Terrain _terrain;

		[SerializeField]
		private float _torque;

		[Range(0f, 5000f)]
		[SerializeField]
		private int _wasteTimeCount;

		[ContextMenu("Pause Game")]
		public void PauseGame()
		{
			PauseManager.RequestPauseChange(paused: true, userInitiated: true);
		}

		[ContextMenu("Toggle TouchEnabled")]
		public void ToggleTouchEnabled()
		{
		}

		[ContextMenu("Unpause Game")]
		public void UnpauseGame()
		{
			PauseManager.RequestPauseChange(paused: false, userInitiated: true);
		}

		protected virtual void Awake()
		{
			_gravity = Physics.gravity;
			_partScript = base.transform.GetComponentInParent<PartScript>();
			_rigidBody = GetComponent<Rigidbody>();
			if (_rigidBody != null)
			{
				_inertiaTensor = _rigidBody.inertiaTensor;
				_maxAngularVelocity = _rigidBody.maxAngularVelocity;
				_sleepThreshold = _rigidBody.sleepThreshold;
			}
		}

		protected virtual void FixedUpdate()
		{
			if (!Utilities.CompareVector3s(_gravity, Physics.gravity))
			{
				Physics.gravity = _gravity;
			}
			if (TryGetComponent<Rigidbody>(out var component))
			{
				if (_torque != 0f)
				{
					component.AddTorque(_torque * base.transform.forward);
				}
				if (_cancelGravity)
				{
					component.AddForce(-Physics.gravity, ForceMode.Acceleration);
				}
				if (_forceGravity != 0f)
				{
					component.AddForce(Physics.gravity.normalized * _forceGravity);
				}
				if (_setSpeed != 0f)
				{
					component.linearVelocity = component.transform.forward * _setSpeed;
					_setSpeed = 0f;
				}
				component.maxAngularVelocity = _maxAngularVelocity;
				component.SetInertiaTensor(_inertiaTensor);
			}
		}

		protected virtual void LateUpdate()
		{
			if (_calculateCenterOfMassOfAllChildBodies)
			{
				_calculateCenterOfMassOfAllChildBodies = false;
				CalculateCenterOfMassOfAllChildBodies();
			}
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

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (_showCollissionEnter)
			{
				Debug.LogFormat("Collisions Enter with: {0}", collision.gameObject.name);
			}
		}

		protected virtual void OnDestroy()
		{
			if (_showOnDestroy)
			{
				Debug.Log(base.name + "- OnDestroy: - " + ((_partScript == null) ? base.name : _partScript.name));
			}
		}

		protected virtual void OnDisable()
		{
			if (_showOnDisable)
			{
				Debug.Log(base.name + "- OnDisable: - " + ((_partScript == null) ? base.name : _partScript.name));
			}
		}

		protected virtual void OnEnable()
		{
			if (_showOnEnable)
			{
				Debug.Log(base.name + "- OnEnable: - " + ((_partScript == null) ? base.name : _partScript.name));
			}
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (_showTriggerEnter)
			{
				Debug.LogFormat("Trigger Enter with: {0}", other.name);
			}
		}

		protected virtual void Update()
		{
			if (_measureDistanceA != null && _measureDistanceB != null)
			{
				Debug.Log($"{Time.frameCount} - Distance: {Vector3.Distance(_measureDistanceA.position, _measureDistanceB.position)}m, {_measureDistanceA.name} - {_measureDistanceB.name}");
			}
			for (int i = 0; i < _wasteTimeCount; i++)
			{
				for (int j = 0; j < 1000; j++)
				{
					Mathf.Cos(j);
				}
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
					Debug.LogFormat("{0} - Underwater %: {1}", _partScript.name, _partScript.EstimateOfUnderwaterPercent);
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
				Debug.Log(base.name + "- position - " + base.transform.position.ToString());
			}
			if (_showPositionAbsolute)
			{
				Debug.Log(base.name + "- absolute position (position as it would be w/o floating origin) - " + Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position).ToString());
			}
			if (_playAudioSource)
			{
				_playAudioSource = false;
				if (TryGetComponent<AudioSource>(out var component))
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
				Debug.LogFormat("Dist to player: {0}", Vector3.Distance(base.transform.position, FlightSceneScript.Instance.LocalPlayer.FramePosition));
			}
			Rigidbody rigidbody = base.transform.GetComponentInParent<Rigidbody>();
			if (rigidbody != null)
			{
				if (_solverIterationCount < 0)
				{
					_solverIterationCount = rigidbody.solverIterations;
				}
				else if (_solverIterationCount != rigidbody.solverIterations)
				{
					rigidbody.solverIterations = _solverIterationCount;
					_solverIterationCount = rigidbody.solverIterations;
				}
				if (_showVelocity)
				{
					Debug.Log(base.name + "- velocity - " + rigidbody.linearVelocity.ToString());
				}
				if (_showVelocityMag)
				{
					Debug.Log(base.name + "- velocity.magnitude - " + rigidbody.linearVelocity.magnitude);
				}
				if (_showAngularVelocity)
				{
					Debug.Log($"{base.name}  -angularVelocity- {rigidbody.angularVelocity} (mag: {rigidbody.angularVelocity.magnitude})");
				}
				if (_showAngularVelocityLocal)
				{
					Debug.Log(base.name + "- angularVelocity Local - " + rigidbody.transform.InverseTransformDirection(rigidbody.angularVelocity).ToString());
				}
				if (_showAngularVelocityRotationPerUpdate)
				{
					float num = rigidbody.transform.InverseTransformDirection(rigidbody.angularVelocity).z / (MathF.PI * 2f) * Time.deltaTime;
					Debug.Log($"RotationsPerFixedUpdate: {num}");
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
			if (_showAllCenterOfMassesLocal)
			{
				string text = string.Empty;
				BodyScript[] componentsInChildren = GetComponentInParent<AircraftScript>().GetComponentsInChildren<BodyScript>();
				foreach (BodyScript bodyScript in componentsInChildren)
				{
					text += $"{bodyScript.GetComponent<Rigidbody>().centerOfMass}\n";
				}
				Debug.Log(text);
			}
			if (_showHeightAboveTerrain)
			{
				if (_terrain != null)
				{
					float? heightAboveTerrain = Utilities.GetHeightAboveTerrain(_terrain, base.transform.position);
					Debug.LogFormat("Height above terrain ({0}): {1}", _terrain.name, heightAboveTerrain);
				}
				else
				{
					float? heightAboveTerrain2 = Utility.GetHeightAboveTerrain(base.transform.position);
					Debug.LogFormat("Height above terrain: {0}", heightAboveTerrain2);
				}
			}
		}

		private void CalculateCenterOfMassOfAllChildBodies()
		{
			Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
			Rigidbody rigidbody = null;
			Vector3 zero = Vector3.zero;
			float num = 0f;
			Rigidbody[] array = componentsInChildren;
			foreach (Rigidbody rigidbody2 in array)
			{
				if (rigidbody == null)
				{
					rigidbody = rigidbody2;
				}
				zero += rigidbody2.position * rigidbody2.mass;
				num += rigidbody2.mass;
			}
			zero /= num;
			if (rigidbody != null)
			{
				GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				UnityEngine.Object.Destroy(obj.GetComponent<Collider>());
				obj.name = "CenterOfMass - DebugScriptCalculated";
				obj.transform.localScale = Vector3.one * 2f;
				obj.transform.parent = rigidbody.transform;
				obj.transform.position = zero;
			}
			else
			{
				Debug.LogError("There were no rigidbodies to commify!");
			}
		}
	}
}
