using System;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Discoverables;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Multiplayer;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Craft
{
	public class AircraftCatapultScript : MonoBehaviour, INetworkStateReceiver
	{
		private bool _connected;

		private float? _connectedAccelerationMultiplier;

		private AircraftScript _connectedAircraft;

		private BodyScript _connectedBody;

		private PartScript _connectedPart;

		private float? _connectedTargetVelocity;

		[SerializeField]
		private Transform _connector;

		private ConfigurableJoint _connectorJoint;

		private Rigidbody _connectorRigidbody;

		private int _currentlyInUse;

		[SerializeField]
		[FormerlySerializedAs("_targetVelocity")]
		private float _defaultTargetVelocity = 79f;

		[SerializeField]
		private float _launchForce = 250f;

		[SerializeField]
		private AnimationCurve _launchForceCurve = AnimationCurve.Linear(0f, 1f, 1f, 2f);

		private bool _launching;

		[SerializeField]
		private Transform _launchPad;

		private TweenerCore<Quaternion, Vector3, QuaternionOptions> _launchPadAnimation;

		[SerializeField]
		private Vector3 _launchPadOpenEulers = new Vector3(75f, 0f, 0f);

		private AudioSource _launchSound;

		[SerializeField]
		[Tooltip("The id of the location which connects to the catapult.")]
		private string _locationId = "USSBeastCatapult";

		[SerializeField]
		private float _maximumConnectorZ = 38.9f;

		[SerializeField]
		private float _minimumConnectorZ = -28.68f;

		private DiscoverableLocationScript _myLocation;

		private Vector3 _originalConnectorPosition;

		private Rigidbody _parent;

		private bool _playerConnectableLastFrame;

		private INetworkStateRegistry _stateRegistry;

		public int ReceiverId { get; private set; }

		public void SetState(int state, bool initialValue)
		{
			_currentlyInUse = state;
			_launchPadAnimation?.Kill();
			_launchPadAnimation = null;
			bool active = _currentlyInUse == 0 || (_connectedAircraft?.IsPrimaryLocalPlayer ?? false);
			_connector.gameObject.SetActive(active);
			Vector3 vector = ((_currentlyInUse == 0) ? Vector3.zero : _launchPadOpenEulers);
			if (initialValue)
			{
				_launchPad.localEulerAngles = vector;
			}
			else
			{
				_launchPadAnimation = _launchPad.DOLocalRotate(vector, 5f);
			}
		}

		[ContextMenu("Test Connector")]
		public void Test()
		{
			if (!Application.isPlaying)
			{
				Debug.Log("This will only work in play mode.");
			}
			else
			{
				ConnectToAircraft(FlightSceneScript.Instance.LocalPlayer.Aircraft);
			}
		}

		protected virtual void Awake()
		{
			_connectorJoint = _connector.GetComponent<ConfigurableJoint>();
			_parent = GetComponentInParent<Rigidbody>();
			_connector.localPosition.Set(_connector.localPosition.x, _connector.localPosition.y, _minimumConnectorZ);
			_originalConnectorPosition = _connector.localPosition;
			_launchPad.localEulerAngles = Vector3.zero;
			_connectorRigidbody = _connector.GetComponent<Rigidbody>();
			_launchSound = GetComponentInChildren<AudioSource>();
			_myLocation = GetComponentInChildren<DiscoverableLocationScript>(includeInactive: true);
		}

		protected virtual void FixedUpdate()
		{
			if (_launching)
			{
				Vector3 localPosition = _connector.localPosition;
				float time = Mathf.Clamp01(_connectedAircraft.AirSpeed / (_connectedTargetVelocity ?? _defaultTargetVelocity));
				_connectorRigidbody.AddForce(_connector.forward * (_launchForce * (_connectedAccelerationMultiplier ?? 1f) * _launchForceCurve.Evaluate(time)), ForceMode.Acceleration);
				if (localPosition.z > _maximumConnectorZ || Mathf.Approximately(localPosition.z, _maximumConnectorZ))
				{
					Disconnect();
				}
			}
		}

		protected virtual void OnDestroy()
		{
			GameState.Instance.MapLocationChanging -= OnMapLocationChanging;
			GameState.Instance.MapLocationChanged -= OnMapLocationChanged;
			if (_stateRegistry != null)
			{
				_stateRegistry.Unregister(this);
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.FlightSceneLoaded -= OnFlightSceneLoaded;
				instance.FlightUI.CatapultButtonClicked -= CatapultButtonClicked;
			}
			_launchPadAnimation?.Kill();
			_launchPadAnimation = null;
		}

		protected virtual void Start()
		{
			GameState.Instance.MapLocationChanging += OnMapLocationChanging;
			GameState.Instance.MapLocationChanged += OnMapLocationChanged;
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.FlightSceneLoaded += OnFlightSceneLoaded;
				instance.FlightUI.CatapultButtonClicked += CatapultButtonClicked;
				_stateRegistry = instance.NetworkStateRegistry;
				ReceiverId = _stateRegistry.Register(this, Utilities.GetFullObjectHierarchy(base.transform));
			}
		}

		protected virtual void Update()
		{
			if (PauseManager.Paused || FlightSceneScript.Instance == null)
			{
				return;
			}
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			if (localPlayer == null)
			{
				return;
			}
			AircraftScript aircraft = localPlayer.Aircraft;
			if ((object)aircraft == null)
			{
				return;
			}
			if (_connected && _connectedAircraft == null)
			{
				Disconnect();
			}
			_launchSound.pitch = Time.timeScale;
			Vector3 vector = aircraft.Velocity - ((_parent == null) ? Vector3.zero : _parent.linearVelocity);
			bool isConnectedToCatapult = aircraft.IsConnectedToCatapult;
			bool flag = _myLocation.IsPlayerInBounds(localPlayer);
			bool flag2 = !isConnectedToCatapult && _currentlyInUse == 0 && flag && !_launching && vector.magnitude < 5f && _connectedBody == null;
			if (!isConnectedToCatapult)
			{
				if (flag2)
				{
					FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Connect);
				}
				else if (_playerConnectableLastFrame)
				{
					FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Hidden);
				}
			}
			_playerConnectableLastFrame = flag2;
			if (aircraft.Controls.GetButtonDownControlInput(Game.Inputs.Interact) == true)
			{
				if (flag2)
				{
					ConnectToPlayerAircraft();
				}
				else if (_connectedAircraft == aircraft && _connectorJoint.connectedBody != null && !_launching)
				{
					Launch();
				}
			}
		}

		private Vector3 CalculateCenterOfLift(AircraftScript aircraft)
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (IWingScript wing in aircraft.Wings)
			{
				Vector3 centre;
				float projectedAreaMoment = wing.GetProjectedAreaMoment(Vector3.up, out centre);
				zero += centre * projectedAreaMoment;
				num += projectedAreaMoment;
			}
			if (num > 0f)
			{
				return zero / num;
			}
			return aircraft.OrientedCenterOfMassRigidBodies.position;
		}

		private void CatapultButtonClicked()
		{
			if (_connectedBody != null && !_connectedBody.Aircraft.IsPrimaryLocalPlayer)
			{
				return;
			}
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			if (localPlayer == null)
			{
				return;
			}
			AircraftScript aircraft = localPlayer.Aircraft;
			if ((object)aircraft != null)
			{
				Vector3 vector = aircraft.Velocity - ((_parent == null) ? Vector3.zero : _parent.linearVelocity);
				if (_myLocation.IsPlayerInBounds(localPlayer) && vector.magnitude < 5f && !_launching && _connectedBody == null)
				{
					ConnectToPlayerAircraft();
				}
				else if (_connectorJoint.connectedBody != null && !_launching)
				{
					Launch();
				}
			}
		}

		private void ConnectToAircraft(AircraftScript aircraft)
		{
			_stateRegistry.SetState(this, 1);
			aircraft.Rotation = _connector.transform.rotation.eulerAngles;
			_connectedPart = GetConnectionPart(aircraft);
			CatapultConnectorScript catapultConnectorScript = _connectedPart?.GetModifier<CatapultConnectorScript>();
			bool flag = _connectedPart != null && catapultConnectorScript != null;
			_connectedAccelerationMultiplier = null;
			_connectedTargetVelocity = null;
			if (_connectedPart != null)
			{
				_connectedBody = _connectedPart.Body;
				Vector3 vector = -((_parent == null) ? Vector3.zero : (_parent.linearVelocity * Time.fixedDeltaTime));
				Vector3 zero = Vector3.zero;
				if (!flag)
				{
					Vector3 vector2 = _connector.position + Vector3.Scale(_connectorJoint.anchor, _connector.localScale);
					vector2.y += aircraft.CalculateBounds(includeDisconnectedParts: false).extents.y / 2f;
					zero = _connectedPart.PrimaryPartCollider.transform.position - vector2 + vector;
				}
				else
				{
					_connectedAccelerationMultiplier = catapultConnectorScript.CatapultAcceleration;
					_connectedTargetVelocity = catapultConnectorScript.TargetLaunchSpeed / 2.23694f + 1f;
					Vector3 vector3 = _connector.position + Vector3.Scale(_connectorJoint.anchor, _connector.localScale);
					vector3.y += aircraft.CalculateBounds(includeDisconnectedParts: false).extents.y / 2f;
					zero = _connectedPart.transform.position - vector3 + vector;
				}
				aircraft.Position -= zero;
				PositionUtility.RepositionAircraftOnGround(aircraft, excludePartsDisconnectedFromMainCockpit: true, float.PositiveInfinity);
				if (_connectedBody != null && _parent != null)
				{
					aircraft.SetVelocity(_parent.linearVelocity);
				}
			}
			else
			{
				if (!Physics.autoSyncTransforms)
				{
					Physics.SyncTransforms();
				}
				Vector3 vector4 = CalculateCenterOfLift(aircraft);
				_connectedBody = GetClosestBody(aircraft, vector4);
				Vector3 vector5 = -((_parent == null) ? Vector3.zero : (_parent.linearVelocity * Time.fixedDeltaTime));
				Vector3 vector6 = _connector.position + Vector3.Scale(_connectorJoint.anchor, _connector.localScale);
				vector6.y += aircraft.CalculateBounds(includeDisconnectedParts: false).extents.y / 2f;
				Vector3 vector7 = vector4 - vector6 + vector5;
				aircraft.Position -= vector7;
				PositionUtility.RepositionAircraftOnGround(aircraft, excludePartsDisconnectedFromMainCockpit: true, float.PositiveInfinity);
				if (_connectedBody != null && _parent != null)
				{
					aircraft.SetVelocity(_parent.linearVelocity);
				}
			}
			_connectorJoint.connectedBody = _connectedBody.RigidBody.PhysxRigidBody;
			Vector3 connectedAnchor = _connectedBody.transform.InverseTransformPoint(_connector.position + Vector3.Scale(_connectorJoint.anchor, _connector.localScale));
			_connectorJoint.connectedAnchor = connectedAnchor;
			_connected = true;
			_connectedAircraft = aircraft;
			_connectedAircraft.IsConnectedToCatapult = true;
			static BodyScript GetClosestBody(AircraftScript craft, Vector3 targetPoint)
			{
				BodyScript result = craft.Bodies[0];
				float num = float.MaxValue;
				foreach (BodyScript body in craft.Bodies)
				{
					foreach (PartGroupScript partGroup in body.PartGroups)
					{
						foreach (PartScript part in partGroup.Parts)
						{
							Collider primaryPartCollider = part.PrimaryPartCollider;
							if (!(primaryPartCollider == null) && primaryPartCollider.enabled && primaryPartCollider.gameObject.activeInHierarchy)
							{
								float num2 = Vector3.SqrMagnitude(primaryPartCollider.ClosestPoint(targetPoint) - targetPoint);
								if (num2 < num)
								{
									num = num2;
									result = body;
									if (num == 0f)
									{
										return result;
									}
								}
							}
						}
					}
				}
				return result;
			}
		}

		private void ConnectToPlayerAircraft()
		{
			try
			{
				ConnectToAircraft(FlightSceneScript.Instance.LocalPlayer.Aircraft);
				FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Launch);
				FlightSceneScript.Instance.FlightUI.ShowMessage("Ready for catapult launch!");
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Disconnect();
			}
		}

		private void Disconnect()
		{
			_stateRegistry.SetState(this, 0);
			if (_connectedAircraft != null)
			{
				_connectedAircraft.IsConnectedToCatapult = false;
			}
			_connectorJoint.connectedBody = null;
			_connectorRigidbody.isKinematic = true;
			_connectedBody = null;
			_connectedPart = null;
			_connectedAircraft = null;
			_connector.localPosition = _originalConnectorPosition;
			_connected = false;
			_launching = false;
			FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Hidden);
		}

		private PartScript GetConnectionPart(AircraftScript aircraft)
		{
			CatapultConnectorScript catapultConnectorScript = aircraft.GetComponentsInChildren<CatapultConnectorScript>(includeInactive: true).FirstOrDefault((CatapultConnectorScript x) => x.PartScript.ConnectedToMainCockpit);
			if (catapultConnectorScript != null)
			{
				return catapultConnectorScript.PartScript;
			}
			LandingGearScript[] array = (from x in aircraft.GetComponentsInChildren<LandingGearScript>()
				where x.PartScript.ConnectedToMainCockpit
				select x).ToArray();
			LandingGearScript landingGearScript = ((array.Length == 0) ? null : array[0]);
			if (array.Length > 1)
			{
				for (int num = 1; num < array.Length; num++)
				{
					Vector3 vector = base.transform.InverseTransformPoint(array[num].transform.position);
					Vector3 vector2 = base.transform.InverseTransformPoint(landingGearScript.transform.position);
					if (vector.z > vector2.z)
					{
						landingGearScript = array[num];
					}
					else if (num == array.Length - 1 && Mathf.Approximately(vector.z, vector2.z))
					{
						return null;
					}
				}
			}
			if (landingGearScript != null)
			{
				return landingGearScript.PartScript;
			}
			return null;
		}

		private void Launch()
		{
			_connectorRigidbody.isKinematic = false;
			_connectorRigidbody.linearVelocity = _parent?.linearVelocity ?? _connectorRigidbody.linearVelocity;
			_launching = true;
			_launchSound.Play();
			FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Hidden);
		}

		private void OnFlightSceneLoaded(object sender, EventArgs e)
		{
			string text = Game.Instance.Settings.Cloud.Locations.GetSelectedLocation(Game.Instance.CurrentMap.MapId)?.Id;
			if (!string.IsNullOrEmpty(text) && text == _locationId && _myLocation.IsPlayerInBounds(FlightSceneScript.Instance.LocalPlayer))
			{
				ConnectToPlayerAircraft();
			}
		}

		private void OnMapLocationChanged(object sender, MapLocationChangedEventArgs e)
		{
			if (base.enabled && e.LocationId == _locationId && _connectedBody == null && _currentlyInUse == 0)
			{
				AircraftScript aircraft = FlightSceneScript.Instance.LocalPlayer.Aircraft;
				if (aircraft != null && !aircraft.CriticallyDamaged)
				{
					ConnectToPlayerAircraft();
				}
			}
		}

		private void OnMapLocationChanging(object sender, MapLocationChangedEventArgs e)
		{
			if (base.enabled && e.LocationId != _locationId && _connectedBody != null && _connectedBody.Aircraft.IsPrimaryLocalPlayer)
			{
				Disconnect();
			}
		}
	}
}
