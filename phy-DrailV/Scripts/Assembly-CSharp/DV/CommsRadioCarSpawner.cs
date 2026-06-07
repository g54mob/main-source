using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DV.Localization;
using DV.OriginShift;
using DV.PointSet;
using DV.ThingTypes;
using DV.UserManagement;
using DV.Utils;
using TMPro;
using UnityEngine;

namespace DV
{
	public class CommsRadioCarSpawner : MonoBehaviour, ICommsRadioMode
	{
		private enum State : byte
		{
			EnterSpawnMode = 0,
			PickCategory = 1,
			PickLoco = 2,
			PickCarType = 3,
			PickCarLivery = 4,
			PickDestination = 5
		}

		private enum Category : byte
		{
			Loco = 0,
			Car = 1
		}

		private const float POTENTIAL_TRACKS_RADIUS = 200f;

		private const float MAX_DISTANCE_FROM_TRACK_POINT = 3f;

		private const float TRACK_POINT_POSITION_Y_OFFSET = -1.75f;

		private const float SIGNAL_RANGE = 100f;

		private const float INVALID_DESTINATION_HIGHLIGHTER_DISTANCE = 20f;

		private const float UPDATE_TRACKS_PERIOD = 2.5f;

		private static Color laserColor = new Color(1f, 0f, 0.9f, 1f);

		public Transform signalOrigin;

		public CommsRadioDisplay display;

		public Material validMaterial;

		public Material invalidMaterial;

		public ArrowLCD lcdArrow;

		[Header("Sounds")]
		public AudioClip spawnModeEnterSound;

		public AudioClip spawnVehicleSound;

		public AudioClip confirmSound;

		public AudioClip cancelSound;

		[Header("Highlighters")]
		public GameObject destinationHighlighterGO;

		public GameObject directionArrowsHighlighterGO;

		private CarDestinationHighlighter destHighlighter;

		private RaycastHit hit;

		private LayerMask trackMask;

		private readonly List<TrainCarLivery> locoLiveries = new List<TrainCarLivery>();

		private readonly Dictionary<TrainCarType_v2, List<TrainCarLivery>> carLiveriesToSpawn = new Dictionary<TrainCarType_v2, List<TrainCarLivery>>();

		private List<TrainCarType_v2> carTypesToSpawn;

		private int selectedLocoIndex;

		private int selectedCarLiveryIndex;

		private int selectedCarTypeIndex;

		private TrainCarType_v2 carTypeToSpawn;

		private GameObject carPrefabToSpawn;

		private Bounds carBounds;

		private bool spawnWithTrackDirection = true;

		private readonly List<RailTrack> potentialTracks = new List<RailTrack>();

		private Category category;

		private bool canSpawnAtPoint;

		private RailTrack destinationTrack;

		private EquiPointSet.Point? closestPointOnDestinationTrack;

		private bool spawnCooldownActive;

		private Coroutine trackUpdateCoro;

		private State state;

		public ButtonBehaviourType ButtonBehaviour { get; private set; }

		private void SetState(State newState)
		{
			if (state == newState)
			{
				return;
			}
			state = newState;
			switch (newState)
			{
			case State.EnterSpawnMode:
				SetStartingDisplay();
				lcdArrow.TurnOff();
				ButtonBehaviour = ButtonBehaviourType.Regular;
				break;
			case State.PickCategory:
				SwitchCategory(category);
				ButtonBehaviour = ButtonBehaviourType.Override;
				CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				break;
			case State.PickLoco:
				selectedLocoIndex--;
				SetCarLiveryToSpawn(IncOrDec(inc: true, locoLiveries, ref selectedLocoIndex, IsCarLiveryUnlocked));
				break;
			case State.PickCarType:
				selectedCarTypeIndex--;
				SetCarTypeToSpawn(IncOrDec(inc: true, carTypesToSpawn, ref selectedCarTypeIndex, IsCarTypeUnlocked));
				break;
			case State.PickCarLivery:
				selectedCarLiveryIndex--;
				SetCarLiveryToSpawn(IncOrDec(inc: true, carLiveriesToSpawn[carTypeToSpawn], ref selectedCarLiveryIndex, IsCarLiveryUnlocked));
				if (carLiveriesToSpawn[carTypeToSpawn].Count == 1)
				{
					SetState(State.PickDestination);
				}
				break;
			case State.PickDestination:
				ButtonBehaviour = ButtonBehaviourType.Override;
				break;
			}
			if (newState - 2 <= State.PickLoco)
			{
				if (trackUpdateCoro == null)
				{
					trackUpdateCoro = StartCoroutine(PotentialTracksUpdateCoro());
				}
				ButtonBehaviour = ButtonBehaviourType.Override;
				CommsRadioController.PlayAudioFromRadio(spawnModeEnterSound, base.transform);
			}
		}

		private void Awake()
		{
			if (!signalOrigin)
			{
				Debug.LogError("signalOrigin on CommsRadioCrewVehicle isn't set, using this.transform!", this);
				signalOrigin = base.transform;
			}
			if (display == null)
			{
				Debug.LogError("display not set, can't function properly!", this);
			}
			if (validMaterial == null || invalidMaterial == null)
			{
				Debug.LogError("Some of the required materials isn't set. Visuals won't be correct.", this);
			}
			if (lcdArrow == null)
			{
				Debug.LogError("lcdArrow not set, can't display arrow!", this);
			}
			if (destinationHighlighterGO == null || directionArrowsHighlighterGO == null)
			{
				Debug.LogError("destinationHighlighterGO or directionArrowsHighlighterGO is not set, can't function properly!!", this);
			}
			if (spawnVehicleSound == null || spawnModeEnterSound == null || confirmSound == null || cancelSound == null)
			{
				Debug.LogError("Not all audio clips set, some sounds won't be played!", this);
			}
			trackMask = LayerMask.GetMask("Default");
			destHighlighter = new CarDestinationHighlighter(destinationHighlighterGO, directionArrowsHighlighterGO);
			UpdateCarLiveriesToSpawn();
		}

		private void UpdateCarLiveriesToSpawn()
		{
			foreach (TrainCarLivery livery in Globals.G.Types.Liveries)
			{
				if (!livery.isHidden)
				{
					if (CarTypes.IsAnyLocoSlugTender(livery))
					{
						locoLiveries.Add(livery);
						continue;
					}
					if (carLiveriesToSpawn.TryGetValue(livery.parentType, out var value))
					{
						value.Add(livery);
						continue;
					}
					carLiveriesToSpawn[livery.parentType] = new List<TrainCarLivery> { livery };
				}
			}
			Comparison<TrainCarLivery> comparison = (TrainCarLivery a, TrainCarLivery b) => string.Compare(LocalizationAPI.L(a.localizationKey), LocalizationAPI.L(b.localizationKey), LocalizationAPI.CC, CompareOptions.IgnoreCase);
			locoLiveries.Sort(comparison);
			foreach (List<TrainCarLivery> value2 in carLiveriesToSpawn.Values)
			{
				value2.Sort(comparison);
			}
			carTypesToSpawn = new List<TrainCarType_v2>(carLiveriesToSpawn.Keys);
			carTypesToSpawn.Sort((TrainCarType_v2 a, TrainCarType_v2 b) => string.Compare(LocalizationAPI.L(a.localizationKey), LocalizationAPI.L(b.localizationKey), LocalizationAPI.CC, CompareOptions.IgnoreCase));
			ClearFlags();
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				destHighlighter.Destroy();
				destHighlighter = null;
			}
		}

		public void Enable()
		{
		}

		public void Disable()
		{
			ClearFlags();
			trackUpdateCoro = null;
			spawnCooldownActive = false;
			StopAllCoroutines();
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
			this.signalOrigin = signalOrigin;
		}

		public void OnUse()
		{
			switch (state)
			{
			case State.EnterSpawnMode:
				SetState(State.PickCategory);
				break;
			case State.PickCategory:
				SetState((category == Category.Loco) ? State.PickLoco : State.PickCarType);
				break;
			case State.PickCarType:
				SetState(State.PickCarLivery);
				break;
			case State.PickLoco:
			case State.PickCarLivery:
				if (carPrefabToSpawn == null)
				{
					Debug.LogError("carPrefabToSpawn is null! Something is wrong, can't spawn this car.", this);
					ClearFlags();
				}
				else if (canSpawnAtPoint)
				{
					SetState(State.PickDestination);
					CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				}
				else
				{
					ClearFlags();
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				}
				break;
			case State.PickDestination:
				if (spawnCooldownActive)
				{
					break;
				}
				if (canSpawnAtPoint)
				{
					Vector3 vector = closestPointOnDestinationTrack.Value.forward;
					if (!spawnWithTrackDirection)
					{
						vector = -vector;
					}
					Vector3 absolutePosition = (Vector3)closestPointOnDestinationTrack.Value.position;
					TrainCar trainCar = SingletonBehaviour<CarSpawner>.Instance.SpawnCarFromRemote(carPrefabToSpawn, destinationTrack, absolutePosition, vector);
					if (trainCar != null)
					{
						CommsRadioController.PlayAudioFromCar(spawnVehicleSound, trainCar);
						CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
						canSpawnAtPoint = false;
						StartCoroutine(SpawnCooldownCoro());
					}
					else
					{
						Debug.LogError("Couldn't spawn car!", carPrefabToSpawn);
						ClearFlags();
					}
				}
				else
				{
					ClearFlags();
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				}
				break;
			}
		}

		public void OnUpdate()
		{
			if (potentialTracks.Count == 0)
			{
				return;
			}
			State state = this.state;
			if (state != State.PickLoco && state - 4 > State.PickCategory)
			{
				return;
			}
			if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trackMask))
			{
				Vector3 point = hit.point;
				foreach (RailTrack potentialTrack in potentialTracks)
				{
					EquiPointSet.Point? pointWithinRangeWithYOffset = RailTrack.GetPointWithinRangeWithYOffset(potentialTrack, point, 3f, -1.75f);
					if (pointWithinRangeWithYOffset.HasValue)
					{
						destinationTrack = potentialTrack;
						EquiPointSet.Point[] points = potentialTrack.GetKinkedPointSet().points;
						int index = pointWithinRangeWithYOffset.Value.index;
						EquiPointSet.Point? point2 = CarSpawner.FindClosestValidPointForCarStartingFromIndex(points, index, carBounds.extents);
						bool hasValue = point2.HasValue;
						if (hasValue)
						{
							closestPointOnDestinationTrack = point2;
						}
						else
						{
							closestPointOnDestinationTrack = pointWithinRangeWithYOffset;
						}
						canSpawnAtPoint = hasValue;
						Vector3 position = (Vector3)closestPointOnDestinationTrack.Value.position + WorldMover.currentMove;
						Vector3 forward = closestPointOnDestinationTrack.Value.forward;
						if (!spawnWithTrackDirection)
						{
							forward *= -1f;
						}
						destHighlighter.Highlight(position, forward, carBounds, canSpawnAtPoint ? validMaterial : invalidMaterial);
						display.SetAction(canSpawnAtPoint ? CommsRadioLocalization.CONFIRM : CommsRadioLocalization.CANCEL);
						if (canSpawnAtPoint && this.state == State.PickDestination)
						{
							UpdateLCDRerailDirectionArrow();
						}
						else
						{
							lcdArrow.TurnOff();
						}
						return;
					}
				}
			}
			canSpawnAtPoint = false;
			destinationTrack = null;
			destHighlighter.Highlight(signalOrigin.position + signalOrigin.forward * 20f, signalOrigin.right, carBounds, invalidMaterial);
			display.SetAction(CommsRadioLocalization.CANCEL);
			lcdArrow.TurnOff();
		}

		public bool ButtonACustomAction()
		{
			switch (state)
			{
			case State.PickCategory:
				SwitchCategory();
				return true;
			case State.PickCarType:
				selectedCarLiveryIndex = 0;
				SetCarTypeToSpawn(IncOrDec(inc: true, carTypesToSpawn, ref selectedCarTypeIndex, IsCarTypeUnlocked));
				return true;
			case State.PickLoco:
				SetCarLiveryToSpawn(IncOrDec(inc: true, locoLiveries, ref selectedLocoIndex, IsCarLiveryUnlocked));
				return true;
			case State.PickCarLivery:
				SetCarLiveryToSpawn(IncOrDec(inc: true, carLiveriesToSpawn[carTypeToSpawn], ref selectedCarLiveryIndex, IsCarLiveryUnlocked));
				return true;
			case State.PickDestination:
				if (!canSpawnAtPoint)
				{
					return false;
				}
				spawnWithTrackDirection = !spawnWithTrackDirection;
				return true;
			default:
				Debug.LogError($"Unexpected state {state}!", this);
				return false;
			}
		}

		public bool ButtonBCustomAction()
		{
			switch (state)
			{
			case State.PickCategory:
				SwitchCategory();
				return true;
			case State.PickCarType:
				selectedCarLiveryIndex = 0;
				SetCarTypeToSpawn(IncOrDec(inc: false, carTypesToSpawn, ref selectedCarTypeIndex, IsCarTypeUnlocked));
				return true;
			case State.PickLoco:
				SetCarLiveryToSpawn(IncOrDec(inc: false, locoLiveries, ref selectedLocoIndex, IsCarLiveryUnlocked));
				return true;
			case State.PickCarLivery:
				SetCarLiveryToSpawn(IncOrDec(inc: false, carLiveriesToSpawn[carTypeToSpawn], ref selectedCarLiveryIndex, IsCarLiveryUnlocked));
				return true;
			case State.PickDestination:
				if (!canSpawnAtPoint)
				{
					return false;
				}
				spawnWithTrackDirection = !spawnWithTrackDirection;
				return true;
			default:
				Debug.LogError($"Unexpected state {state}!", this);
				return false;
			}
		}

		public void SetStartingDisplay()
		{
			display.SetDisplay(CommsRadioLocalization.MODE_SPAWNER, CommsRadioLocalization.ENABLE_SPAWNER);
		}

		public Color GetLaserBeamColor()
		{
			return laserColor;
		}

		private void SwitchCategory(Category? category = null)
		{
			this.category = (Category)(((int?)category) ?? ((this.category == Category.Loco) ? 1 : 0));
			display.SetContent((this.category == Category.Loco) ? CommsRadioLocalization.SPAWNER_CAT_LOCO : CommsRadioLocalization.SPAWNER_CAT_CARS);
		}

		private void SetCarTypeToSpawn(TrainCarType_v2 carType)
		{
			carTypeToSpawn = carType;
			display.SetContent(LocalizationAPI.L(carType.localizationKey));
		}

		private void SetCarLiveryToSpawn(TrainCarLivery carLivery)
		{
			carPrefabToSpawn = carLivery.prefab;
			if (carPrefabToSpawn == null)
			{
				Debug.LogError($"Couldn't load car prefab: {carLivery}! Won't be able to spawn this car.", this);
				return;
			}
			TrainCar component = carPrefabToSpawn.GetComponent<TrainCar>();
			carBounds = component.Bounds;
			string content = $"<uppercase>{LocalizationAPI.L(carLivery.localizationKey)}</uppercase>\n{component.InterCouplerDistance:N2}m";
			display.SetContent(content, FontStyles.Normal);
		}

		private void UpdatePotentialTracks()
		{
			potentialTracks.Clear();
			float num = 1f;
			while (true)
			{
				RailTrack[] allTracks = SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks;
				foreach (RailTrack railTrack in allTracks)
				{
					if (RailTrack.GetPointWithinRangeWithYOffset(railTrack, base.transform.position, num * 200f).HasValue)
					{
						potentialTracks.Add(railTrack);
					}
				}
				if (potentialTracks.Count > 0 || num > 4f)
				{
					break;
				}
				Debug.LogWarning($"No tracks in {num * 200f} radius. Expanding radius!", this);
				num += 0.2f;
			}
			if (potentialTracks.Count == 0)
			{
				Debug.LogError("No near tracks found. Can't spawn crew vehicle");
			}
		}

		private IEnumerator SpawnCooldownCoro()
		{
			spawnCooldownActive = true;
			yield return WaitFor.FixedUpdate;
			OnUpdate();
			spawnCooldownActive = false;
		}

		private IEnumerator PotentialTracksUpdateCoro()
		{
			Vector3 lastUpdatedTracksWorldPosition = Vector3.positiveInfinity;
			while (true)
			{
				if ((base.transform.AbsolutePosition() - lastUpdatedTracksWorldPosition).magnitude > 100f)
				{
					UpdatePotentialTracks();
					lastUpdatedTracksWorldPosition = base.transform.AbsolutePosition();
				}
				yield return WaitFor.Seconds(2.5f);
			}
		}

		private void UpdateLCDRerailDirectionArrow()
		{
			bool flag = Mathf.Sin(Vector3.SignedAngle(spawnWithTrackDirection ? closestPointOnDestinationTrack.Value.forward : (-closestPointOnDestinationTrack.Value.forward), signalOrigin.forward, Vector3.up) * ((float)Math.PI / 180f)) <= 0f;
			lcdArrow.TurnOn(!flag);
		}

		private void ClearFlags()
		{
			destinationTrack = null;
			canSpawnAtPoint = false;
			destHighlighter.TurnOff();
			SetState(State.EnterSpawnMode);
		}

		private static T IncOrDec<T>(bool inc, List<T> list, ref int index, Func<T, bool> isValidFunc)
		{
			int num = 0;
			T val;
			do
			{
				if (inc)
				{
					index = (index + 1) % list.Count;
				}
				else
				{
					index = ((index <= 0) ? (list.Count - 1) : (index - 1));
				}
				val = list[index];
			}
			while (!isValidFunc(val) && num++ < list.Count);
			return val;
		}

		private static bool IsCarTypeUnlocked(TrainCarType_v2 carType)
		{
			return !carType.liveries.TrueForAll((TrainCarLivery livery) => !IsCarLiveryUnlocked(livery));
		}

		private static bool IsCarLiveryUnlocked(TrainCarLivery carLivery)
		{
			if (carLivery.requiredLicense != null && !SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(carLivery.requiredLicense))
			{
				return false;
			}
			if (SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "Career")
			{
				return true;
			}
			if (Globals.G.Types.CarLiveryToGarageRequirement.TryGetValue(carLivery, out var value))
			{
				return SingletonBehaviour<LicenseManager>.Instance.IsGarageUnlocked(value);
			}
			return true;
		}
	}
}
