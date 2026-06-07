using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Animator))]
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class Fire : MonoBehaviour, IPersistable, IReferenceableObject, ILateRestoreState
	{
		private static SoundEngineParameterControl<int> _fireIntensity;

		public static string InterruptPropOnFire;

		public static HashSet<Fire> AllFires;

		public static EventHandler AllFiresChanged;

		public static EventHandler<EventArgs<Prop>> PropOnFireChanged;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _increasing;

		[PersistenceOptIn]
		private float _nextSpreading;

		[PersistenceOptIn]
		private float _currentTemperature;

		[PersistenceOptIn]
		private float _currentBrightness;

		private static List<TileData> _emptyList;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public GameObjectX ParentGameObjectX;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _incfireSpeed;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _decfireSpeed;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float _tempCap;

		[PersistenceOptIn]
		private bool _propWasBroken;

		private bool _setupDone;

		private const float MinimumTemperature = 3f;

		private const float MaximumTemperature = 10f;

		[PersistenceOptIn]
		private bool _useTimeLeft;

		[PersistenceOptIn]
		private float _timeLeft;

		private WetTrait _parentWetTrait;

		[SerializeField]
		private SimpleSoundPlayer _smallFire;

		[SerializeField]
		private SimpleSoundPlayer _bigFire;

		[SerializeField]
		private SimpleSoundPlayer _hugeFire;

		private float _spreadDistance;

		public static float SmallFireThreshold;

		public static float MaxVisibilityDistance;

		public ParticleSystem _ps;

		private Mesh _emissionMesh;

		public Animator _animator;

		[PersistenceOptIn]
		private List<Vector3> _verts;

		private int _lastVertsCount;

		private float _lastIntensity;

		private static readonly int Intensity;

		private static readonly int VertCount;

		[PersistenceOptIn]
		public int Id { get; private set; }

		public float CurrentTemperature
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CurrentBrightness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private List<TileData> CurrentTiles => null;

		public List<Room> CurrentRooms => null;

		public int Count => 0;

		private static void UpdateFireAudioIntensity()
		{
		}

		public void GenerateId()
		{
		}

		public static void Reset()
		{
		}

		public void Start()
		{
		}

		private void Setup()
		{
		}

		private float CalculateFireSpeed(bool increasing)
		{
			return 0f;
		}

		private void OnEnteredRoom(object sender, EventArgs<Room> e)
		{
		}

		private void OnLeftRoom(object sender, EventArgs<Room> e)
		{
		}

		public static void SpawnAsh(Vector3 position)
		{
		}

		public static float ApplyFireFightEffectivenessAdjustment(float value)
		{
			return 0f;
		}

		public void Update()
		{
		}

		private void UpdateVisualState(bool smolderingChanged)
		{
		}

		private float GetIntensity()
		{
			return 0f;
		}

		private void UpdateFireSound(bool stopSounds = false)
		{
		}

		private void UpdateFireVisuals()
		{
		}

		private void AddFireObjects(GameObjectX prop, Bounds totalBounds, int amount)
		{
		}

		private bool AddFireObject(GameObjectX gox, Bounds bounds)
		{
			return false;
		}

		private int GetMaxAmountOfFireObjects()
		{
			return 0;
		}

		private void RefreshSpreadingTime()
		{
		}

		private IEnumerable<GameObjectX> GetFireCatchingCandidates(List<Room> currentRooms, Flammability[] flammabilities, float maxDistance)
		{
			return null;
		}

		private void SpreadFire()
		{
		}

		private GameObjectX GetOtherGoxToCatchFire(List<Room> rooms)
		{
			return null;
		}

		public void OnDestroy()
		{
		}

		public bool IsBig()
		{
			return false;
		}

		public bool IsHuge()
		{
			return false;
		}

		public bool CanBeBlownOut()
		{
			return false;
		}

		public float GetVisibilityDistance()
		{
			return 0f;
		}

		public void Add(Vector3 position)
		{
		}

		public void Remove(int count)
		{
		}

		private void UpdatePosition()
		{
		}

		public void SetIntensity(float intensity)
		{
		}

		public void LateRestoreState(IDataStore data)
		{
		}

		public float GetProgressToBigFire()
		{
			return 0f;
		}
	}
}
