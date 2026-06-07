using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Flight.WorldObjects.Structures;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using DG.Tweening;
using FishNet.Serializing;
using Jundroo.Common.Utils;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class FiretruckScript : NetworkedAreaItemScript
	{
		public enum FiretruckState
		{
			Idle = 0,
			ExitFirehouse = 1,
			ChasePlayer = 2
		}

		private const float MaxPlayerDistance = 500f;

		private NetworkedAreaBodyScript _body;

		private NetworkFlightObjectDamageReceiverScript _damageReceiver;

		[SerializeField]
		private Transform _exitFirehouseWaypoint;

		[SerializeField]
		private GameObject _fireParticlesPrefab;

		[SerializeField]
		private LuxuryHangarDoorScript _garageDoor;

		private float _showMessageDuration;

		[SerializeField]
		private GameObject _smokeParticlesPrefab;

		private FiretruckState _state;

		private AircraftScript _targetPlayer;

		[SerializeField]
		private TextMeshPro _text;

		private SimpleGroundVehicleScript _vehicle;

		[SerializeField]
		private GameObject _waterParticles;

		public FiretruckState CurrentState
		{
			get
			{
				return _state;
			}
			private set
			{
				if (_state != value)
				{
					_state = value;
					_waterParticles.SetActive(_state == FiretruckState.ChasePlayer);
					if (_state == FiretruckState.ChasePlayer)
					{
						_vehicle.NavigationTargetDistanceThreshold = 0f;
						_text.gameObject.SetActive(value: true);
					}
					else if (_state == FiretruckState.ExitFirehouse)
					{
						_vehicle.NavigationTargetDistanceThreshold = 10f;
						_vehicle.NavigationTarget = _exitFirehouseWaypoint;
						_showMessageDuration = 10f;
						_text.gameObject.SetActive(value: true);
						_text.text = "Stop, drop, and roll, baby!";
					}
				}
			}
		}

		private AircraftScript TargetPlayer
		{
			get
			{
				return _targetPlayer;
			}
			set
			{
				if (_targetPlayer != value)
				{
					if (_targetPlayer != null)
					{
						_targetPlayer.Unloaded -= OnTargetUnloaded;
						_vehicle.NavigationTarget = null;
					}
					_targetPlayer = value;
					if (_targetPlayer != null)
					{
						_targetPlayer.Unloaded += OnTargetUnloaded;
						_vehicle.NavigationTarget = _targetPlayer.MainCockpit?.transform;
					}
				}
			}
		}

		public override void InitializeArea(INetworkedArea area, byte itemID)
		{
			base.InitializeArea(area, itemID);
			_body = GetComponent<NetworkedAreaBodyScript>();
			area.FlightObjectLoaded += OnAreaFlightObjectLoaded;
			area.FlightObjectUnloaded += OnAreaFlightObjectUnloaded;
			area.OwnershipChanged += OnAreaOwnershipChanged;
			_vehicle.IsOwner = area.IsOwner;
			_garageDoor.Opened += OnGarageDoorOpened;
		}

		public override void ReadState(PooledReader reader, float timeDelta)
		{
			base.ReadState(reader, timeDelta);
			CurrentState = (FiretruckState)reader.ReadUInt8Unpacked();
		}

		public override void WriteState(PooledWriter writer)
		{
			base.WriteState(writer);
			writer.WriteUInt8Unpacked((byte)_state);
		}

		protected override void Awake()
		{
			base.Awake();
			LayerUtility.SetLayerRecursive(base.gameObject, base.gameObject.layer);
			_vehicle = base.gameObject.GetComponent<SimpleGroundVehicleScript>();
			_vehicle.Initialize(GetComponent<Rigidbody>(), null, null);
			_vehicle.NavigationTargetReached += OnVehicleNavigationTargetReached;
			_vehicle.IsOwner = true;
			_damageReceiver = _vehicle.InitializeDamgeReceiver();
		}

		protected virtual void Update()
		{
			if (CurrentState == FiretruckState.ChasePlayer)
			{
				_showMessageDuration -= Time.unscaledDeltaTime;
				if (_showMessageDuration <= 0f)
				{
					ShowRandomMessage();
				}
			}
			if (_body == null || !base.Area.IsOwner || _state != FiretruckState.ChasePlayer)
			{
				return;
			}
			if (TargetPlayer != null)
			{
				Vector3? vector = TargetPlayer.MainCockpit?.transform.position - base.transform.position;
				if (vector.HasValue && vector.Value.magnitude > 500f)
				{
					TargetPlayer = null;
				}
				else if (TargetPlayer.CriticallyDamaged)
				{
					AircraftScript aircraftScript = FindClosestPlayerAircraft(base.transform.position);
					if (aircraftScript != null)
					{
						TargetPlayer = aircraftScript;
					}
				}
			}
			else
			{
				TargetPlayer = FindClosestPlayerAircraft(base.transform.position);
			}
		}

		private AircraftScript FindClosestPlayerAircraft(Vector3 position)
		{
			return (from x in FlightSceneScript.Instance.AllPlayers
				select new
				{
					Distance = (x.FramePosition - position).magnitude,
					Aircraft = x.Aircraft
				} into x
				where x.Distance < 500f && x.Aircraft != null && !x.Aircraft.CriticallyDamaged
				orderby x.Distance
				select x.Aircraft).FirstOrDefault();
		}

		private void OnAreaFlightObjectLoaded(NetworkFlightObject obj)
		{
			NetworkFlightObjectDamageScript component = obj.GetComponent<NetworkFlightObjectDamageScript>();
			if (base.DamageReceiverId.HasValue)
			{
				_damageReceiver.Initialize(base.DamageReceiverId.Value, component);
			}
			else
			{
				Debug.LogError("NetworkedAreaItem was not configured to request a damage receiver ID", base.gameObject);
			}
		}

		private void OnAreaFlightObjectUnloaded(NetworkFlightObject obj)
		{
			if (_damageReceiver.IsInitialized)
			{
				_damageReceiver.Uninitialize();
			}
		}

		private void OnAreaOwnershipChanged(bool isOwner)
		{
			_vehicle.IsOwner = isOwner;
		}

		private void OnGarageDoorOpened()
		{
			if (base.Area.IsOwner)
			{
				CurrentState = FiretruckState.ExitFirehouse;
			}
		}

		private void OnTargetUnloaded(object sender, AircraftScriptEventArgs e)
		{
			TargetPlayer = null;
		}

		private void OnVehicleNavigationTargetReached(object sender, ConvoyNavigationTargetReachedEventArgs e)
		{
			if (base.Area.IsOwner && _state == FiretruckState.ExitFirehouse)
			{
				CurrentState = FiretruckState.ChasePlayer;
			}
		}

		private void ShowRandomMessage()
		{
			string[] array = new string[31]
			{
				"Hold still, so I can douse your flames!", "There's always flames, even if you can't see them!", "Stop resisting my assistance!", "Let me help you!", "Help is on the way!", "You're welcome, by the way!", "Incoming water rescue!", "Stay put, fire hazard!", "No need to thank me!", "Flame extinguishing in progress!",
				"Don't worry, I've got this!", "Not on my watch!", "Safety first!", "Just doing my duty!", "I'm no hero! Well, maybe a little.", "Hold on, I see smoke!", "Don't run, it's just water!", "Emergency response coming through!", "I'll put out those invisible flames!", "You might not see the fire, but I do!",
				"This is for your own good!", "Flame detection mode activated!", "Better safe than sorry!", "You can thank me later!", "Dousing mode: Engaged!", "Fire truck to the rescue!", "Where there's smoke, there's me!", "Don't move, you're in danger!", "Stay still, fire isn't a joke!", "Just doing my job, citizen!",
				"Ready or not, here comes the hose!"
			};
			_showMessageDuration = 15f;
			_text.text = array[Random.Range(0, array.Length - 1)];
			_text.transform.localScale = Vector3.zero;
			_text.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
		}
	}
}
