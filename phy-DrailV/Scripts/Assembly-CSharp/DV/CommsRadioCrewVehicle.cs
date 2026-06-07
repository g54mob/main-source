using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.InventorySystem;
using DV.Localization;
using DV.OriginShift;
using DV.PointSet;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class CommsRadioCrewVehicle : MonoBehaviour, ICommsRadioMode
	{
		private struct SelectedCar
		{
			public readonly TrainCarLivery livery;

			public readonly GameObject prefab;

			public Bounds bounds;

			public readonly GarageCarSpawner garageSpawner;

			public bool IsGarageCarSelected => garageSpawner != null;

			public SelectedCar(TrainCarLivery livery, Dictionary<TrainCarLivery, GarageCarSpawner> garageCarToGarageSpawner)
			{
				this.livery = livery;
				if (livery == null)
				{
					prefab = null;
					bounds = default(Bounds);
					garageSpawner = null;
				}
				else
				{
					prefab = livery.prefab;
					bounds = prefab.GetComponent<TrainCar>().Bounds;
					garageCarToGarageSpawner.TryGetValue(livery, out garageSpawner);
				}
			}
		}

		public enum State
		{
			EnterSpawnMode = 0,
			PickCrewVehicle = 1,
			PickDestination = 2,
			ConfirmSummon = 3,
			CancelSummon = 4
		}

		private const float POTENTIAL_TRACKS_RADIUS = 200f;

		private const float MAX_DISTANCE_FROM_TRACK_POINT = 3f;

		private const float TRACK_POINT_POSITION_Y_OFFSET = -1.75f;

		private const float SIGNAL_RANGE = 100f;

		private const float INVALID_DESTINATION_HIGHLIGHTER_DISTANCE = 20f;

		private const float UPDATE_TRACKS_PERIOD = 2.5f;

		public RailTrack SingleAllowedTrack;

		private static Color laserColor = new Color(0f, 0.5f, 1f, 1f);

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

		public AudioClip hoverOverCar;

		public AudioClip warningSound;

		public AudioClip moneyRemovedSound;

		[Header("Highlighters")]
		public GameObject destinationHighlighterGO;

		public GameObject directionArrowsHighlighterGO;

		private CarDestinationHighlighter destHighlighter;

		private RaycastHit hit;

		private LayerMask trackMask;

		private LayerMask laserPointerMask;

		private bool spawnWithTrackDirection = true;

		private readonly List<TrainCarLivery> availableVehiclesForSpawn = new List<TrainCarLivery>();

		private SelectedCar selectedCar;

		private int selectedVehicleIndex = -1;

		private List<RailTrack> potentialTracks = new List<RailTrack>();

		private bool canMoveToPoint;

		private RailTrack destinationTrack;

		private EquiPointSet.Point? closestPointOnDestinationTrack;

		private bool isActiveMode;

		private Coroutine trackUpdateCoro;

		public CarDestinationHighlighter Highlighter => destHighlighter;

		private float SummonPrice
		{
			get
			{
				if (!selectedCar.IsGarageCarSelected)
				{
					return 0f;
				}
				return Mathf.Min(selectedCar.garageSpawner.garageType.summonPrice, Globals.G.GameParams.WorkTrainSummonMaxPrice);
			}
		}

		public State CurrentState { get; private set; }

		public ButtonBehaviourType ButtonBehaviour { get; private set; }

		public event Action<TrainCar> CarSummoned;

		private void SetState(State newState)
		{
			if (CurrentState == newState)
			{
				return;
			}
			State currentState = CurrentState;
			CurrentState = newState;
			switch (CurrentState)
			{
			case State.EnterSpawnMode:
				ButtonBehaviour = ButtonBehaviourType.Regular;
				SetStartingDisplay();
				lcdArrow.TurnOff();
				break;
			case State.PickCrewVehicle:
				ButtonBehaviour = ButtonBehaviourType.Override;
				CommsRadioController.PlayAudioFromRadio(spawnModeEnterSound, base.transform);
				SetPickCarText();
				break;
			case State.PickDestination:
				if (trackUpdateCoro == null)
				{
					trackUpdateCoro = StartCoroutine(PotentialTracksUpdateCoro());
				}
				ButtonBehaviour = ButtonBehaviourType.Override;
				display.SetContent(CommsRadioLocalization.WORK_TRAIN_PICK_DESTINATION);
				break;
			case State.ConfirmSummon:
			{
				display.SetAction(CommsRadioLocalization.CONFIRM);
				Vector3 vector2 = closestPointOnDestinationTrack.Value.forward;
				if (!spawnWithTrackDirection)
				{
					vector2 = -vector2;
				}
				Vector3 position2 = (Vector3)closestPointOnDestinationTrack.Value.position + WorldMover.currentMove;
				destHighlighter.Highlight(position2, vector2, selectedCar.bounds, validMaterial);
				ButtonBehaviour = ButtonBehaviourType.Ignore;
				if (currentState != State.PickDestination)
				{
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				break;
			}
			case State.CancelSummon:
			{
				display.SetAction(CommsRadioLocalization.CANCEL);
				Vector3 vector = closestPointOnDestinationTrack.Value.forward;
				if (!spawnWithTrackDirection)
				{
					vector = -vector;
				}
				Vector3 position = (Vector3)closestPointOnDestinationTrack.Value.position + WorldMover.currentMove;
				destHighlighter.Highlight(position, vector, selectedCar.bounds, invalidMaterial);
				ButtonBehaviour = ButtonBehaviourType.Ignore;
				if (currentState != State.PickDestination)
				{
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				break;
			}
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
			if (spawnVehicleSound == null || spawnModeEnterSound == null || confirmSound == null || cancelSound == null || hoverOverCar == null || warningSound == null || moneyRemovedSound == null)
			{
				Debug.LogError("Not all audio clips set, some sounds won't be played!", this);
			}
			if (!Array.TrueForAll(SingletonBehaviour<CarSpawner>.Instance.crewVehicleGarages, (GarageType_v2 g) => g != null))
			{
				Debug.LogError("CommsRadioCrewVehicle has invalid Garage value in crewVehicleGarages. Destroying self.", this);
				UnityEngine.Object.Destroy(this);
				return;
			}
			trackMask = LayerMask.GetMask("Default");
			laserPointerMask = LayerMask.GetMask("Laser_Pointer_Target");
			destHighlighter = new CarDestinationHighlighter(destinationHighlighterGO, directionArrowsHighlighterGO);
			GarageType_v2[] crewVehicleGarages = SingletonBehaviour<CarSpawner>.Instance.crewVehicleGarages;
			foreach (GarageType_v2 garage in crewVehicleGarages)
			{
				if (GarageCarSpawner.Spawners.Values.All((GarageCarSpawner g) => g.garageType != garage))
				{
					Debug.LogError(string.Format("Couldn't find {0} for {1}, will be treated as locked.", "GarageCarSpawner", garage), this);
				}
			}
			UpdateAvailableVehicles();
			SingletonBehaviour<LicenseManager>.Instance.GarageUnlocked += OnGarageUnlocked;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<LicenseManager>.Instance.GarageUnlocked -= OnGarageUnlocked;
				destHighlighter.Destroy();
				destHighlighter = null;
			}
		}

		private void UpdateAvailableVehicles()
		{
			availableVehiclesForSpawn.Clear();
			availableVehiclesForSpawn.AddRange(SingletonBehaviour<CarSpawner>.Instance.vehiclesWithoutGarage);
			LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
			GarageType_v2[] crewVehicleGarages = SingletonBehaviour<CarSpawner>.Instance.crewVehicleGarages;
			foreach (GarageType_v2 garageType_v in crewVehicleGarages)
			{
				TrainCarLivery[] garageCarLiveries = garageType_v.garageCarLiveries;
				foreach (TrainCarLivery trainCarLivery in garageCarLiveries)
				{
					if (trainCarLivery == null)
					{
						Debug.LogError("Unexpected state: " + garageType_v.id + " doesn't have livery set! Skipping");
					}
					else if (instance.IsGarageUnlocked(garageType_v) && GarageCarSpawner.Spawners.ContainsKey(trainCarLivery))
					{
						availableVehiclesForSpawn.Add(trainCarLivery);
					}
				}
			}
			if (isActiveMode)
			{
				ClearFlags();
				SetStartingDisplay();
			}
			if (availableVehiclesForSpawn.Count != 0 && !selectedVehicleIndex.IsInRange(0, availableVehiclesForSpawn.Count))
			{
				selectedVehicleIndex = 0;
				selectedCar = new SelectedCar(availableVehiclesForSpawn[selectedVehicleIndex], GarageCarSpawner.Spawners);
			}
		}

		public void Enable()
		{
			isActiveMode = true;
		}

		public void Disable()
		{
			isActiveMode = false;
			ClearFlags();
			trackUpdateCoro = null;
			StopAllCoroutines();
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
			this.signalOrigin = signalOrigin;
		}

		public void OnUse()
		{
			switch (CurrentState)
			{
			case State.EnterSpawnMode:
				if (availableVehiclesForSpawn.Count > 0)
				{
					selectedCar = new SelectedCar(availableVehiclesForSpawn[selectedVehicleIndex], GarageCarSpawner.Spawners);
					SetState(State.PickCrewVehicle);
				}
				break;
			case State.PickCrewVehicle:
				SetState(State.PickDestination);
				CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				break;
			case State.PickDestination:
				if (canMoveToPoint)
				{
					float summonPrice = SummonPrice;
					bool flag = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)summonPrice;
					TrainCar trainCar2 = (selectedCar.IsGarageCarSelected ? selectedCar.garageSpawner.GetCar(selectedCar.livery) : null);
					bool flag2 = trainCar2 != null && trainCar2.LoadedCargo != CargoType.None;
					string text;
					if (flag2)
					{
						text = CommsRadioLocalization.LOADED_VEHICLE;
					}
					else
					{
						text = CommsRadioLocalization.WORK_TRAIN_SUMMON_PROMPT(LocalizationAPI.L(selectedCar.livery.localizationKey), summonPrice);
						if (!flag)
						{
							text = text + "\n" + CommsRadioLocalization.INSUFFICIENT_FUNDS;
						}
					}
					display.SetContent(text);
					lcdArrow.TurnOff();
					SetState((flag && !flag2) ? State.ConfirmSummon : State.CancelSummon);
					CommsRadioController.PlayAudioFromRadio(warningSound, base.transform);
				}
				else
				{
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
					ClearFlags();
				}
				break;
			case State.ConfirmSummon:
				if (SingletonBehaviour<Inventory>.Instance.RemoveMoney(SummonPrice))
				{
					if (moneyRemovedSound != null)
					{
						moneyRemovedSound.Play2D();
					}
					Vector3 vector = closestPointOnDestinationTrack.Value.forward;
					if (!spawnWithTrackDirection)
					{
						vector = -vector;
					}
					Vector3 absolutePosition = (Vector3)closestPointOnDestinationTrack.Value.position;
					TrainCar trainCar = SingletonBehaviour<CarSpawner>.Instance.SpawnCrewVehicle(selectedCar.livery, destinationTrack, absolutePosition, vector, selectedCar.garageSpawner);
					CommsRadioController.PlayAudioFromCar(spawnVehicleSound, trainCar);
					CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
					this.CarSummoned?.Invoke(trainCar);
					ClearFlags();
				}
				else
				{
					Debug.LogWarning("Shouldn't happen, if there weren't enough money it shouldn't be in this state!", this);
					ClearFlags();
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				}
				break;
			case State.CancelSummon:
				CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				ClearFlags();
				break;
			}
		}

		public void OnUpdate()
		{
			switch (CurrentState)
			{
			case State.PickDestination:
				if (potentialTracks.Count == 0)
				{
					break;
				}
				if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trackMask))
				{
					Vector3 point = hit.point;
					bool flag3 = PlayerManager.Car != null && PlayerManager.Car.carLivery == selectedCar.livery;
					foreach (RailTrack potentialTrack in potentialTracks)
					{
						EquiPointSet.Point? pointWithinRangeWithYOffset = RailTrack.GetPointWithinRangeWithYOffset(potentialTrack, point, 3f, -1.75f);
						if (pointWithinRangeWithYOffset.HasValue)
						{
							destinationTrack = potentialTrack;
							EquiPointSet.Point[] points = potentialTrack.GetKinkedPointSet().points;
							int index = pointWithinRangeWithYOffset.Value.index;
							EquiPointSet.Point? point2 = CarSpawner.FindClosestValidPointForCarStartingFromIndex(points, index, selectedCar.bounds.extents);
							bool hasValue = point2.HasValue;
							closestPointOnDestinationTrack = (hasValue ? point2 : pointWithinRangeWithYOffset);
							canMoveToPoint = hasValue && !flag3;
							Vector3 position = (Vector3)closestPointOnDestinationTrack.Value.position + WorldMover.currentMove;
							Vector3 forward = closestPointOnDestinationTrack.Value.forward;
							if (!spawnWithTrackDirection)
							{
								forward *= -1f;
							}
							destHighlighter.Highlight(position, forward, selectedCar.bounds, canMoveToPoint ? validMaterial : invalidMaterial);
							display.SetAction(canMoveToPoint ? CommsRadioLocalization.CONFIRM : CommsRadioLocalization.CANCEL);
							if (canMoveToPoint)
							{
								UpdateLCDDirectionArrow();
							}
							else
							{
								lcdArrow.TurnOff();
							}
							return;
						}
					}
				}
				canMoveToPoint = false;
				destHighlighter.Highlight(signalOrigin.position + signalOrigin.forward * 20f, signalOrigin.right, selectedCar.bounds, invalidMaterial);
				display.SetAction(CommsRadioLocalization.CANCEL);
				lcdArrow.TurnOff();
				break;
			case State.ConfirmSummon:
			case State.CancelSummon:
			{
				if (SingletonBehaviour<Inventory>.Instance.PlayerMoney < (double)SummonPrice)
				{
					SetState(State.CancelSummon);
					break;
				}
				TrainCar trainCar = (selectedCar.IsGarageCarSelected ? selectedCar.garageSpawner.GetCar(selectedCar.livery) : null);
				if (trainCar != null && trainCar.LoadedCargo != CargoType.None)
				{
					SetState(State.CancelSummon);
					break;
				}
				Vector3 vector = closestPointOnDestinationTrack.Value.forward;
				if (!spawnWithTrackDirection)
				{
					vector = -vector;
				}
				bool num = CarSpawner.IsBoxOverlapping((Vector3)closestPointOnDestinationTrack.Value.position + WorldMover.currentMove, selectedCar.bounds.extents, Quaternion.LookRotation(vector));
				bool flag = PlayerManager.Car != null && PlayerManager.Car.carLivery == selectedCar.livery;
				if (num || flag)
				{
					SetState(State.PickDestination);
				}
				else if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, laserPointerMask))
				{
					Transform transform = hit.collider.transform;
					bool flag2 = transform == destinationHighlighterGO.transform || transform.parent == destinationHighlighterGO.transform;
					SetState(flag2 ? State.ConfirmSummon : State.CancelSummon);
				}
				else
				{
					SetState(State.CancelSummon);
				}
				break;
			}
			}
		}

		public bool ButtonACustomAction()
		{
			switch (CurrentState)
			{
			case State.PickCrewVehicle:
				if (availableVehiclesForSpawn.Count == 0)
				{
					Debug.LogError("Unexpected state: no cars available!");
					ClearFlags();
					return false;
				}
				selectedVehicleIndex = ((selectedVehicleIndex <= 0) ? (availableVehiclesForSpawn.Count - 1) : (selectedVehicleIndex - 1));
				selectedCar = new SelectedCar(availableVehiclesForSpawn[selectedVehicleIndex], GarageCarSpawner.Spawners);
				SetPickCarText();
				return true;
			case State.PickDestination:
				if (!canMoveToPoint)
				{
					return false;
				}
				spawnWithTrackDirection = !spawnWithTrackDirection;
				return true;
			default:
				Debug.LogError($"Unexpected state {CurrentState}!", this);
				return false;
			}
		}

		public bool ButtonBCustomAction()
		{
			switch (CurrentState)
			{
			case State.PickCrewVehicle:
				if (availableVehiclesForSpawn.Count == 0)
				{
					Debug.LogError("Unexpected state: no cars available!");
					ClearFlags();
					return false;
				}
				selectedVehicleIndex = (selectedVehicleIndex + 1) % availableVehiclesForSpawn.Count;
				selectedCar = new SelectedCar(availableVehiclesForSpawn[selectedVehicleIndex], GarageCarSpawner.Spawners);
				SetPickCarText();
				return true;
			case State.PickDestination:
				if (!canMoveToPoint)
				{
					return false;
				}
				spawnWithTrackDirection = !spawnWithTrackDirection;
				return true;
			default:
				Debug.LogError($"Unexpected state {CurrentState}!", this);
				return false;
			}
		}

		public void SetStartingDisplay()
		{
			display.SetDisplay(CommsRadioLocalization.MODE_WORK_TRAIN, (availableVehiclesForSpawn.Count > 0) ? CommsRadioLocalization.REQUEST_WORK_TRAIN : CommsRadioLocalization.NO_UNLOCKED_WORK_TRAIN);
		}

		public Color GetLaserBeamColor()
		{
			return laserColor;
		}

		private void UpdatePotentialTracks()
		{
			potentialTracks.Clear();
			float num = 1f;
			while (true)
			{
				if (SingleAllowedTrack != null)
				{
					potentialTracks.Add(SingleAllowedTrack);
					break;
				}
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
				Debug.LogError("No near tracks found. Can't spawn work train");
			}
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

		private void OnGarageUnlocked(GarageType_v2 unlockedGarage)
		{
			UpdateAvailableVehicles();
		}

		private void ClearFlags()
		{
			destHighlighter.TurnOff();
			canMoveToPoint = false;
			selectedCar = new SelectedCar(null, GarageCarSpawner.Spawners);
			SetState(State.EnterSpawnMode);
		}

		private void UpdateLCDDirectionArrow()
		{
			bool flag = Mathf.Sin(Vector3.SignedAngle(spawnWithTrackDirection ? closestPointOnDestinationTrack.Value.forward : (-closestPointOnDestinationTrack.Value.forward), signalOrigin.forward, Vector3.up) * ((float)Math.PI / 180f)) <= 0f;
			lcdArrow.TurnOn(!flag);
		}

		private void SetPickCarText()
		{
			string content = LocalizationAPI.L(selectedCar.livery.localizationKey) ?? "";
			display.SetContentAndAction(content, CommsRadioLocalization.CONFIRM);
		}
	}
}
