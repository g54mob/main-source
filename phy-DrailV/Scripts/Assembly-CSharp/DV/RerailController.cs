using System;
using System.Collections.Generic;
using System.Linq;
using DV.InventorySystem;
using DV.PointSet;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class RerailController : MonoBehaviour, ICommsRadioMode
	{
		public enum State
		{
			DerailedCarScan = 0,
			PickDestination = 1,
			ConfirmRerail = 2,
			CancelRerail = 3
		}

		private const float RERAIL_TRACKS_RADIUS = 200f;

		private const float RERAIL_MAX_DISTANCE_FROM_POINT = 3f;

		private const float TRACK_POINT_POSITION_Y_OFFSET = -1.75f;

		private const float SIGNAL_RANGE = 100f;

		private const float INVALID_DESTINATION_HIGHLIGHTER_DISTANCE = 20f;

		private const float BASE_RERAIL_PRICE = 500f;

		private const float PRICE_PER_METER = 150f;

		public RailTrack SingleAllowedTrack;

		public Collider ZoneCollider;

		private static Vector3 HIGHLIGHT_BOUNDS_EXTENSION = new Vector3(0.25f, 0.8f, 0f);

		private static Color laserColor = new Color(0.2f, 1f, 0f, 1f);

		public Transform signalOrigin;

		public CommsRadioDisplay display;

		public Material validMaterial;

		public Material invalidMaterial;

		public ArrowLCD lcdArrow;

		[Header("Sounds")]
		public AudioClip hoverOverCar;

		public AudioClip selectCarSound;

		public AudioClip rerailingSound;

		public AudioClip confirmSound;

		public AudioClip cancelSound;

		public AudioClip warningSound;

		public AudioClip moneyRemovedSound;

		[Header("Highlighters")]
		public GameObject trainHighlighter;

		private MeshRenderer trainHighlighterRender;

		public GameObject rerailDestinationHighlighterGO;

		public GameObject directionArrowsHighlighterGO;

		[Header("Licenses")]
		public GeneralLicenseType_v2[] nonNewbieGeneralLicenses;

		public JobLicenseType_v2[] nonNewbieJobLicenses;

		private CarDestinationHighlighter rerailHighlighter;

		private List<RailTrack> tracksForRerail = new List<RailTrack>();

		private TrainCar pointedDerailedCar;

		private TrainCar carToRerail;

		private bool rerailWithCurrentCarDirection = true;

		private bool canRerailToPoint;

		private RailTrack rerailTrack;

		private Vector3 rerailPointWorldAbsPosition;

		private Vector3 rerailPointWorldForward;

		private float rerailPrice = float.PositiveInfinity;

		private bool isPlayerNewbie;

		private RaycastHit hit;

		private LayerMask trainCarMask;

		private LayerMask trackMask;

		private LayerMask laserPointerMask;

		public State CurrentState { get; private set; }

		public ButtonBehaviourType ButtonBehaviour { get; private set; }

		public event Action<State> StateChanged;

		public event Action<TrainCar> CarRerailed;

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
			case State.DerailedCarScan:
				SetStartingDisplay();
				ButtonBehaviour = ButtonBehaviourType.Regular;
				lcdArrow.TurnOff();
				break;
			case State.PickDestination:
				ButtonBehaviour = ButtonBehaviourType.Override;
				break;
			case State.ConfirmRerail:
				display.SetAction(CommsRadioLocalization.CONFIRM);
				rerailHighlighter.Highlight(rerailPointWorldAbsPosition + WorldMover.currentMove, rerailPointWorldForward, carToRerail.Bounds, validMaterial);
				ButtonBehaviour = ButtonBehaviourType.Ignore;
				if (currentState != State.PickDestination)
				{
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				break;
			case State.CancelRerail:
				display.SetAction(CommsRadioLocalization.CANCEL);
				rerailHighlighter.Highlight(rerailPointWorldAbsPosition + WorldMover.currentMove, rerailPointWorldForward, carToRerail.Bounds, invalidMaterial);
				ButtonBehaviour = ButtonBehaviourType.Ignore;
				if (currentState != State.PickDestination)
				{
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				break;
			}
			this.StateChanged?.Invoke(CurrentState);
		}

		private void Awake()
		{
			if (!signalOrigin)
			{
				Debug.LogError("signalOrigin on RerailController isn't set, using this.transform!", this);
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
			if (trainHighlighter == null)
			{
				Debug.LogError("trainHighlighter not set, can't function properly!!", this);
			}
			if (rerailDestinationHighlighterGO == null || directionArrowsHighlighterGO == null)
			{
				Debug.LogError("rerailDestinationHighlighterGO or directionArrowsHighlighterGO is not set, can't function properly!!", this);
			}
			if (hoverOverCar == null || selectCarSound == null || rerailingSound == null || confirmSound == null || cancelSound == null || warningSound == null || moneyRemovedSound == null)
			{
				Debug.LogError("Not all audio clips set, some sounds won't be played!", this);
			}
			trainCarMask = LayerMask.GetMask("Train_Big_Collider");
			trackMask = LayerMask.GetMask("Default");
			laserPointerMask = LayerMask.GetMask("Laser_Pointer_Target");
			trainHighlighterRender = trainHighlighter.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			trainHighlighter.SetActive(value: false);
			trainHighlighter.transform.SetParent(null);
			rerailHighlighter = new CarDestinationHighlighter(rerailDestinationHighlighterGO, directionArrowsHighlighterGO);
			LicenseManager lm = SingletonBehaviour<LicenseManager>.Instance;
			isPlayerNewbie = nonNewbieGeneralLicenses.All((GeneralLicenseType_v2 license) => !lm.IsGeneralLicenseAcquired(license)) && nonNewbieJobLicenses.All((JobLicenseType_v2 license) => !lm.IsJobLicenseAcquired(license));
			if (isPlayerNewbie)
			{
				lm.JobLicenseAcquired += OnJobLicenseAcquired;
				lm.LicenseAcquired += OnGeneralLicenseAcquired;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
				instance.JobLicenseAcquired -= OnJobLicenseAcquired;
				instance.LicenseAcquired -= OnGeneralLicenseAcquired;
				if (trainHighlighter != null)
				{
					UnityEngine.Object.Destroy(trainHighlighter.gameObject);
				}
				rerailHighlighter.Destroy();
				rerailHighlighter = null;
			}
		}

		private void OnGeneralLicenseAcquired(GeneralLicenseType_v2 license)
		{
			LicenseManager lm = SingletonBehaviour<LicenseManager>.Instance;
			if (nonNewbieGeneralLicenses.Any((GeneralLicenseType_v2 l) => lm.IsGeneralLicenseAcquired(l)))
			{
				lm.LicenseAcquired -= OnGeneralLicenseAcquired;
				lm.JobLicenseAcquired -= OnJobLicenseAcquired;
				isPlayerNewbie = false;
			}
		}

		private void OnJobLicenseAcquired(JobLicenseType_v2 license)
		{
			LicenseManager lm = SingletonBehaviour<LicenseManager>.Instance;
			if (nonNewbieJobLicenses.Any((JobLicenseType_v2 l) => lm.IsJobLicenseAcquired(l)))
			{
				lm.LicenseAcquired -= OnGeneralLicenseAcquired;
				lm.JobLicenseAcquired -= OnJobLicenseAcquired;
				isPlayerNewbie = false;
			}
		}

		public void Enable()
		{
		}

		public void Disable()
		{
			ClearFlags();
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
			this.signalOrigin = signalOrigin;
		}

		public void OnUse()
		{
			switch (CurrentState)
			{
			case State.DerailedCarScan:
			{
				if (!pointedDerailedCar)
				{
					break;
				}
				carToRerail = pointedDerailedCar;
				pointedDerailedCar = null;
				HighlightCar(carToRerail, validMaterial);
				CommsRadioController.PlayAudioFromCar(selectCarSound, carToRerail);
				CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				SetState(State.PickDestination);
				tracksForRerail.Clear();
				float num = 1f;
				while (true)
				{
					if (SingleAllowedTrack != null)
					{
						tracksForRerail.Add(SingleAllowedTrack);
						break;
					}
					RailTrack[] allTracks = SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks;
					foreach (RailTrack railTrack in allTracks)
					{
						if (RailTrack.GetPointWithinRangeWithYOffset(railTrack, carToRerail.transform.position, num * 200f).HasValue)
						{
							tracksForRerail.Add(railTrack);
						}
					}
					if (tracksForRerail.Count > 0 || num > 4f)
					{
						break;
					}
					Debug.LogWarning($"No tracks in {num * 200f} radius of car. Expanding radius!", carToRerail);
					num += 0.2f;
				}
				if (tracksForRerail.Count == 0)
				{
					Debug.LogError("No near rerail tracks found. Can't rerail vehicle [" + carToRerail.ID + "]", carToRerail);
					ClearFlags();
				}
				break;
			}
			case State.PickDestination:
				if (canRerailToPoint)
				{
					bool flag = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)rerailPrice;
					display.SetContent(flag ? CommsRadioLocalization.RERAIL_PROMPT_1(carToRerail.ID, rerailPrice) : CommsRadioLocalization.RERAIL_INSUFFICIENT_FUNDS);
					SetState(flag ? State.ConfirmRerail : State.CancelRerail);
					CommsRadioController.PlayAudioFromRadio(warningSound, base.transform);
				}
				else
				{
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
					ClearFlags();
				}
				break;
			case State.ConfirmRerail:
				if (!carToRerail.IsRerailAllowed)
				{
					Debug.LogError("Unexpected state, trying to rerail non-derailed or moving car!", carToRerail);
				}
				else if (SingletonBehaviour<Inventory>.Instance.RemoveMoney(rerailPrice))
				{
					if (moneyRemovedSound != null)
					{
						moneyRemovedSound.Play2D();
					}
					Vector3 worldPos = rerailPointWorldAbsPosition + WorldMover.currentMove;
					carToRerail.Rerail(rerailTrack, worldPos, rerailPointWorldForward);
					CommsRadioController.PlayAudioFromCar(rerailingSound, carToRerail);
					CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
					ClearFlags();
					this.CarRerailed?.Invoke(carToRerail);
				}
				else
				{
					Debug.LogWarning("Shouldn't happen, if there weren't enough money it shouldn't be in this state!", this);
					SetState(State.PickDestination);
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				}
				break;
			case State.CancelRerail:
				ClearFlags();
				CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				break;
			}
		}

		public void OnUpdate()
		{
			switch (CurrentState)
			{
			case State.DerailedCarScan:
				if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trainCarMask))
				{
					TrainCar trainCar = TrainCar.Resolve(hit.transform.root);
					if (trainCar == null || !trainCar.IsRerailAllowed)
					{
						PointToCar(null);
					}
					else
					{
						PointToCar(trainCar);
					}
				}
				else
				{
					PointToCar(null);
				}
				break;
			case State.PickDestination:
				if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trackMask))
				{
					Vector3 point = hit.point;
					bool flag2 = PlayerManager.Car == carToRerail;
					foreach (RailTrack item in tracksForRerail)
					{
						EquiPointSet.Point? pointWithinRangeWithYOffset = RailTrack.GetPointWithinRangeWithYOffset(item, point, 3f, -1.75f);
						if (pointWithinRangeWithYOffset.HasValue)
						{
							rerailTrack = item;
							EquiPointSet.Point[] points = item.GetKinkedPointSet().points;
							int index = pointWithinRangeWithYOffset.Value.index;
							EquiPointSet.Point? point2 = CarSpawner.FindClosestValidPointForCarStartingFromIndex(points, index, carToRerail.Bounds.extents, carToRerail);
							bool hasValue = point2.HasValue;
							if (hasValue)
							{
								rerailPointWorldAbsPosition = (Vector3)point2.Value.position;
								rerailPointWorldForward = point2.Value.forward;
							}
							else
							{
								rerailPointWorldAbsPosition = (Vector3)pointWithinRangeWithYOffset.Value.position;
								rerailPointWorldForward = pointWithinRangeWithYOffset.Value.forward;
							}
							if (Vector3.Dot(rerailPointWorldForward, carToRerail.transform.forward) >= 0f != rerailWithCurrentCarDirection)
							{
								rerailPointWorldForward *= -1f;
							}
							canRerailToPoint = hasValue && !flag2;
							Vector3 vector = rerailPointWorldAbsPosition + WorldMover.currentMove;
							if (ZoneCollider != null && ZoneCollider.ClosestPoint(vector) != vector)
							{
								canRerailToPoint = false;
							}
							rerailHighlighter.Highlight(vector, rerailPointWorldForward, carToRerail.Bounds, canRerailToPoint ? validMaterial : invalidMaterial);
							if (canRerailToPoint)
							{
								rerailPrice = ((TutorialHelper.InRestrictedMode || isPlayerNewbie) ? 0f : CalculatePrice((carToRerail.transform.position - vector).magnitude, carToRerail.carType, Globals.G.GameParams.RerailMaxPrice));
								display.SetContentAndAction(carToRerail.ID + "\n" + CommsRadioLocalization.RERAIL_PROMPT_2(rerailPrice), CommsRadioLocalization.CONFIRM);
								UpdateLCDRerailDirectionArrow();
							}
							else
							{
								display.SetContentAndAction(carToRerail.ID, CommsRadioLocalization.CANCEL);
								lcdArrow.TurnOff();
							}
							return;
						}
					}
				}
				display.SetContentAndAction(carToRerail.ID, CommsRadioLocalization.CANCEL);
				canRerailToPoint = false;
				rerailTrack = null;
				rerailHighlighter.Highlight(signalOrigin.position + signalOrigin.forward * 20f, signalOrigin.right, carToRerail.Bounds, invalidMaterial);
				lcdArrow.TurnOff();
				break;
			case State.ConfirmRerail:
			case State.CancelRerail:
			{
				if (SingletonBehaviour<Inventory>.Instance.PlayerMoney < (double)rerailPrice)
				{
					SetState(State.CancelRerail);
					UpdateLCDRerailDirectionArrow();
					break;
				}
				bool num = CarSpawner.IsBoxOverlapping(rerailPointWorldAbsPosition + WorldMover.currentMove, carToRerail.Bounds.extents, Quaternion.LookRotation(rerailPointWorldForward), carToRerail);
				bool flag = PlayerManager.Car == carToRerail;
				if (num || !carToRerail.IsRerailAllowed || flag)
				{
					SetState(State.PickDestination);
					break;
				}
				if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, laserPointerMask))
				{
					if (hit.collider.transform == rerailDestinationHighlighterGO.transform || hit.collider.transform.parent == rerailDestinationHighlighterGO.transform)
					{
						SetState(State.ConfirmRerail);
					}
					else
					{
						SetState(State.CancelRerail);
					}
				}
				else
				{
					SetState(State.CancelRerail);
				}
				UpdateLCDRerailDirectionArrow();
				break;
			}
			}
		}

		public bool ButtonACustomAction()
		{
			State currentState = CurrentState;
			if (currentState == State.PickDestination)
			{
				if (!canRerailToPoint)
				{
					return false;
				}
				rerailWithCurrentCarDirection = !rerailWithCurrentCarDirection;
				return true;
			}
			Debug.LogError("Unexpected state for ButtonACustomAction!");
			return false;
		}

		public bool ButtonBCustomAction()
		{
			State currentState = CurrentState;
			if (currentState == State.PickDestination)
			{
				if (!canRerailToPoint)
				{
					return false;
				}
				rerailWithCurrentCarDirection = !rerailWithCurrentCarDirection;
				return true;
			}
			Debug.LogError("Unexpected state for ButtonBCustomAction!");
			return false;
		}

		public void SetStartingDisplay()
		{
			display.SetDisplay(CommsRadioLocalization.MODE_RERAIL, CommsRadioLocalization.RERAIL_INSTRUCTION);
		}

		public Color GetLaserBeamColor()
		{
			return laserColor;
		}

		private void UpdateLCDRerailDirectionArrow()
		{
			bool flag = Mathf.Sin(Vector3.SignedAngle(rerailPointWorldForward, signalOrigin.forward, Vector3.up) * ((float)Math.PI / 180f)) <= 0f;
			lcdArrow.TurnOn(!flag);
		}

		private void HighlightCar(TrainCar car, Material highlightMaterial)
		{
			if (car == null)
			{
				Debug.LogError("Highlight car is null. Ignoring request.");
				return;
			}
			trainHighlighterRender.material = highlightMaterial;
			trainHighlighter.transform.localScale = car.Bounds.size + HIGHLIGHT_BOUNDS_EXTENSION;
			Vector3 vector = car.transform.up * (trainHighlighter.transform.localScale.y / 2f);
			Vector3 vector2 = car.transform.forward * car.Bounds.center.z;
			Vector3 position = car.transform.position + vector + vector2;
			trainHighlighter.transform.SetPositionAndRotation(position, car.transform.rotation);
			trainHighlighter.SetActive(value: true);
			trainHighlighter.transform.SetParent(car.transform, worldPositionStays: true);
		}

		private void ClearHighlightCar()
		{
			trainHighlighter.SetActive(value: false);
			trainHighlighter.transform.SetParent(null);
		}

		private void PointToCar(TrainCar car)
		{
			if (pointedDerailedCar != car)
			{
				if (pointedDerailedCar != null)
				{
					pointedDerailedCar.OnDestroyCar -= OnRerailingCarDestroy;
				}
				if (car != null)
				{
					pointedDerailedCar = car;
					pointedDerailedCar.OnDestroyCar += OnRerailingCarDestroy;
					HighlightCar(pointedDerailedCar, validMaterial);
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				else
				{
					pointedDerailedCar = null;
					ClearHighlightCar();
				}
			}
		}

		private void ClearFlags()
		{
			if (pointedDerailedCar != null)
			{
				pointedDerailedCar.OnDestroyCar -= OnRerailingCarDestroy;
			}
			pointedDerailedCar = null;
			if (carToRerail != null)
			{
				carToRerail.OnDestroyCar -= OnRerailingCarDestroy;
			}
			carToRerail = null;
			tracksForRerail.Clear();
			rerailTrack = null;
			canRerailToPoint = false;
			rerailWithCurrentCarDirection = true;
			rerailPointWorldAbsPosition = Vector3.zero;
			rerailPointWorldForward = Vector3.zero;
			ClearHighlightCar();
			rerailHighlighter.TurnOff();
			rerailPrice = float.PositiveInfinity;
			SetState(State.DerailedCarScan);
		}

		private void OnRerailingCarDestroy(TrainCar destroyedCar)
		{
			if (destroyedCar != null)
			{
				destroyedCar.OnDestroyCar -= OnRerailingCarDestroy;
			}
			ClearFlags();
		}

		private static float CalculatePrice(float rerailDistance, TrainCarType carType, float priceCap)
		{
			if (carType == TrainCarType.HandCar)
			{
				return 0f;
			}
			return Mathf.RoundToInt(Mathf.Clamp(500f + rerailDistance * 150f, 0f, priceCap));
		}
	}
}
