using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Utils;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Sea
{
	public class AircraftCarrierElevatorScript : MonoBehaviour, INetworkStateReceiver
	{
		private Collider _carpetZone;

		private float _cooldownTime;

		private int _currentState;

		private Vector3 _defaultLocalPosition;

		private AudioSource _elevatorSound;

		private FlightScenePlayer _localPlayer;

		private Vector3 _localPositionLastCheck;

		private Vector3 _localPositionLastFrame;

		private bool _moving;

		[SerializeField]
		private Vector3 _otherLocalPosition = Vector3.zero;

		private Rigidbody _parent;

		private INetworkStateRegistry _stateRegistry;

		public int ReceiverId { get; private set; }

		public void SetState(int state, bool initialValue)
		{
			_cooldownTime = Time.time + 1f;
			_currentState = state;
			if (initialValue)
			{
				base.transform.localPosition = GetTargetPosition();
			}
		}

		protected virtual void FixedUpdate()
		{
			Vector3 targetPosition = GetTargetPosition();
			if (!Utilities.CompareVector3s(base.transform.localPosition, targetPosition))
			{
				base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, targetPosition, Time.fixedDeltaTime);
			}
		}

		protected virtual void OnDestroy()
		{
			if (_stateRegistry != null)
			{
				_stateRegistry.Unregister(this);
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.FlightUI.ElevatorButtonClicked -= OnElevatorButtonClicked;
			}
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			if (localPlayer != null)
			{
				AircraftScript componentInParent = other.GetComponentInParent<AircraftScript>();
				CharacterActor characterActor = other.GetComponent<CharacterActor>();
				if ((object)characterActor == null)
				{
					characterActor = other.GetComponentInParent<CharacterActor>();
				}
				if ((componentInParent != null && componentInParent == localPlayer.Aircraft) || (characterActor != null && localPlayer.CharacterActor == characterActor))
				{
					TrackPlayer(localPlayer);
				}
			}
		}

		protected virtual void Start()
		{
			if (!Game.Instance.SceneManager.InFlightScene)
			{
				base.enabled = false;
			}
			_carpetZone = GetComponent<Collider>();
			_defaultLocalPosition = base.transform.localPosition;
			_parent = GetComponentInParent<Rigidbody>();
			_elevatorSound = GetComponentInChildren<AudioSource>();
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.FlightUI.ElevatorButtonClicked += OnElevatorButtonClicked;
				_stateRegistry = instance.NetworkStateRegistry;
				ReceiverId = _stateRegistry.Register(this, Utilities.GetFullObjectHierarchy(base.transform));
			}
		}

		protected virtual void Update()
		{
			_moving = !Utilities.CompareVector3s(base.transform.localPosition, _localPositionLastFrame);
			if (_elevatorSound != null)
			{
				_elevatorSound.pitch = Time.timeScale;
				if (!_elevatorSound.isPlaying && _moving)
				{
					_elevatorSound.Play();
				}
			}
			if (_localPlayer != null)
			{
				if (!IsCraftInsideTrigger(_localPlayer.Aircraft))
				{
					Collider[] componentsInChildren = _localPlayer.Avatar.GetComponentsInChildren<Collider>();
					bool flag = false;
					Collider[] array = componentsInChildren;
					foreach (Collider collider in array)
					{
						if (CheckColliderIntersectZone(collider))
						{
							flag = true;
						}
					}
					if (!flag)
					{
						TrackPlayer(null);
					}
				}
				if (Game.Inputs.Interact.GetButtonDownIfEnabled())
				{
					ActivateElevator();
				}
			}
			_localPositionLastFrame = base.transform.localPosition;
		}

		private void ActivateElevator()
		{
			if (_localPlayer != null && Time.time > _cooldownTime)
			{
				_cooldownTime = Time.time + 1f;
				_stateRegistry.SetState(this, (_currentState == 0) ? 1 : 0);
			}
		}

		private bool CheckColliderIntersectZone(Collider collider)
		{
			return _carpetZone.bounds.Intersects(collider.bounds);
		}

		private Vector3 GetTargetPosition()
		{
			if (_currentState != 0)
			{
				return _otherLocalPosition;
			}
			return _defaultLocalPosition;
		}

		private bool IsColliderOnElevator(Collider collider)
		{
			if (_carpetZone.bounds.Contains(collider.bounds.max))
			{
				return _carpetZone.bounds.Contains(collider.bounds.min);
			}
			return false;
		}

		private bool IsCraftInsideTrigger(AircraftScript aircraftScript)
		{
			if (aircraftScript == null)
			{
				return false;
			}
			foreach (PartData part in aircraftScript.Parts)
			{
				if (!part.PartScript.ConnectedToMainCockpit || !part.PartScript.gameObject.activeInHierarchy)
				{
					continue;
				}
				Collider[] componentsInChildren = part.PartScript.GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (!componentsInChildren[i].isTrigger && IsColliderOnElevator(componentsInChildren[i]))
					{
						return true;
					}
				}
			}
			return false;
		}

		private void OnElevatorButtonClicked()
		{
			ActivateElevator();
		}

		private void TrackPlayer(FlightScenePlayer localPlayer)
		{
			_localPlayer = localPlayer;
			if (_localPlayer != null)
			{
				FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Elevator);
			}
			else
			{
				FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Hidden);
			}
		}
	}
}
