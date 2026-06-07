using System;
using DV.Garages;
using DV.InventorySystem;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class CommsRadioCarDeleter : MonoBehaviour, ICommsRadioMode
	{
		public enum State
		{
			ScanCarToDelete = 0,
			ConfirmDelete = 1,
			CancelDelete = 2
		}

		private const float SIGNAL_RANGE = 100f;

		private static Vector3 HIGHLIGHT_BOUNDS_EXTENSION = new Vector3(0.25f, 0.8f, 0f);

		private static Color laserColor = new Color(1f, 1f, 0f, 1f);

		public Transform signalOrigin;

		public CommsRadioDisplay display;

		public Material selectionMaterial;

		public Material deleteMaterial;

		[Header("Sounds")]
		public AudioClip hoverOverCar;

		public AudioClip selectedCarSound;

		public AudioClip removeCarSound;

		public AudioClip confirmSound;

		public AudioClip cancelSound;

		public AudioClip warningSound;

		public AudioClip moneyRemovedSound;

		[Header("Highlighters")]
		public GameObject trainHighlighter;

		private MeshRenderer trainHighlighterRender;

		public TrainCar SingleAllowedCar;

		private TrainCar pointedCar;

		private TrainCar carToDelete;

		private Job jobOfCar;

		private RaycastHit hit;

		private LayerMask trainCarMask;

		private float removePrice = float.PositiveInfinity;

		private bool forbiddenDeleteByDifficulty;

		public State CurrentState { get; private set; }

		public ButtonBehaviourType ButtonBehaviour { get; private set; }

		public event Action<TrainCar> CarDeleted;

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
			case State.ScanCarToDelete:
				SetStartingDisplay();
				ButtonBehaviour = ButtonBehaviourType.Regular;
				break;
			case State.ConfirmDelete:
				display.SetAction(CommsRadioLocalization.CONFIRM);
				HighlightCar(carToDelete, deleteMaterial);
				ButtonBehaviour = ButtonBehaviourType.Ignore;
				if (currentState != State.ScanCarToDelete)
				{
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				break;
			case State.CancelDelete:
				display.SetAction(CommsRadioLocalization.CANCEL);
				HighlightCar(carToDelete, selectionMaterial);
				ButtonBehaviour = ButtonBehaviourType.Ignore;
				if (currentState != State.ScanCarToDelete)
				{
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				break;
			}
		}

		private void Awake()
		{
			if (!signalOrigin)
			{
				Debug.LogError("signalOrigin on CommsRadioCarDeleter isn't set, using this.transform!", this);
				signalOrigin = base.transform;
			}
			if (display == null)
			{
				Debug.LogError("display not set, can't function properly!", this);
			}
			if (selectionMaterial == null || deleteMaterial == null)
			{
				Debug.LogError("Some of the required materials isn't set. Visuals won't be correct.", this);
			}
			if (trainHighlighter == null)
			{
				Debug.LogError("trainHighlighter not set, can't function properly!!", this);
			}
			if (hoverOverCar == null || selectedCarSound == null || confirmSound == null || cancelSound == null || warningSound == null || removeCarSound == null || moneyRemovedSound == null)
			{
				Debug.LogError("Not all audio clips set, some sounds won't be played!", this);
			}
			trainCarMask = LayerMask.GetMask("Train_Big_Collider");
			trainHighlighterRender = trainHighlighter.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			trainHighlighter.SetActive(value: false);
			trainHighlighter.transform.SetParent(null);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && trainHighlighter != null)
			{
				UnityEngine.Object.Destroy(trainHighlighter.gameObject);
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
			case State.ScanCarToDelete:
				if (pointedCar != null)
				{
					carToDelete = pointedCar;
					pointedCar = null;
					HighlightCar(carToDelete, deleteMaterial);
					CommsRadioController.PlayAudioFromCar(selectedCarSound, carToDelete);
					GameParams gameParams = Globals.G.GameParams;
					forbiddenDeleteByDifficulty = !gameParams.ClearDerailedAllowed && carToDelete.derailed;
					if (forbiddenDeleteByDifficulty)
					{
						display.SetContent(CommsRadioLocalization.CLEAR_CAR_FORBIDDEN_BY_DIFFICULTY);
						SetState(State.CancelDelete);
					}
					else
					{
						removePrice = (carToDelete.playerSpawnedCar ? 0f : ((float)Mathf.RoundToInt(gameParams.DeleteCarMaxPrice)));
						jobOfCar = SingletonBehaviour<JobsManager>.Instance.GetJobOfCar(carToDelete.logicCar);
						bool flag = SingletonBehaviour<Inventory>.Instance.PlayerMoney >= (double)removePrice;
						string text = ((jobOfCar != null) ? ("\n" + CommsRadioLocalization.DISCARD_JOB_WARNING) : "");
						string text2 = (flag ? CommsRadioLocalization.CLEAR_CAR_PROMPT(carToDelete.ID, removePrice) : CommsRadioLocalization.INSUFFICIENT_FUNDS);
						display.SetContent(text2 + "\n" + text);
						SetState(flag ? State.ConfirmDelete : State.CancelDelete);
					}
					CommsRadioController.PlayAudioFromRadio(warningSound, base.transform);
				}
				break;
			case State.ConfirmDelete:
				if (carToDelete == PlayerManager.Car)
				{
					break;
				}
				if (SingletonBehaviour<Inventory>.Instance.RemoveMoney(removePrice))
				{
					if (removePrice > 0f && moneyRemovedSound != null)
					{
						moneyRemovedSound.Play2D();
					}
					if (jobOfCar != null)
					{
						switch (jobOfCar.State)
						{
						case JobState.Available:
							jobOfCar.ExpireJob();
							break;
						case JobState.InProgress:
							SingletonBehaviour<JobsManager>.Instance.AbandonJob(jobOfCar);
							break;
						default:
							Debug.LogWarning("Job state changed in the meantime, not forcing abandon/expire.");
							break;
						}
					}
					CommsRadioController.PlayAudioFromCar(removeCarSound, carToDelete, parentToWorld: true);
					ClearHighlightCar();
					HomeGarageReference component = carToDelete.GetComponent<HomeGarageReference>();
					if (component != null && component.garageCarSpawner != null)
					{
						component.garageCarSpawner.ReturnCarHome(carToDelete);
					}
					else
					{
						SingletonBehaviour<CarSpawner>.Instance.DeleteCar(carToDelete);
						SingletonBehaviour<UnusedTrainCarDeleter>.Instance.ClearInvalidCarReferencesAfterManualDelete();
						if (carToDelete != null)
						{
							carToDelete.gameObject.SetActive(value: false);
							carToDelete.interior.gameObject.SetActive(value: false);
						}
					}
					this.CarDeleted?.Invoke(carToDelete);
					ClearFlags();
					CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				}
				else
				{
					Debug.LogWarning("Shouldn't happen, if there weren't enough money it shouldn't be in this state!", this);
					ClearFlags();
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				}
				break;
			case State.CancelDelete:
				ClearFlags();
				CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				break;
			}
		}

		public void OnUpdate()
		{
			switch (CurrentState)
			{
			case State.ScanCarToDelete:
				if (carToDelete == null)
				{
					if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trainCarMask))
					{
						TrainCar trainCar2 = TrainCar.Resolve(hit.transform.root);
						if (trainCar2 == null || trainCar2 == PlayerManager.Car || trainCar2.preventDelete)
						{
							PointToCar(null);
						}
						else
						{
							PointToCar(trainCar2);
						}
					}
					else
					{
						PointToCar(null);
					}
				}
				else
				{
					Debug.LogError("Invalid setup for current state, reseting flags!", this);
					ClearFlags();
				}
				break;
			case State.ConfirmDelete:
			case State.CancelDelete:
				if (SingletonBehaviour<Inventory>.Instance.PlayerMoney < (double)removePrice || forbiddenDeleteByDifficulty)
				{
					SetState(State.CancelDelete);
				}
				else if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trainCarMask))
				{
					TrainCar trainCar = TrainCar.Resolve(hit.transform.root);
					if (trainCar != null && trainCar == carToDelete)
					{
						SetState(State.ConfirmDelete);
					}
					else
					{
						SetState(State.CancelDelete);
					}
				}
				else
				{
					SetState(State.CancelDelete);
				}
				break;
			}
		}

		public bool ButtonACustomAction()
		{
			Debug.LogError("Unexpected ButtonACustomAction!", this);
			return false;
		}

		public bool ButtonBCustomAction()
		{
			Debug.LogError("Unexpected ButtonBCustomAction!", this);
			return false;
		}

		public void SetStartingDisplay()
		{
			display.SetDisplay(CommsRadioLocalization.MODE_CLEAR, CommsRadioLocalization.CLEAR_INSTRUCTION);
		}

		public Color GetLaserBeamColor()
		{
			return laserColor;
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
			if (pointedCar != car)
			{
				if (pointedCar != null)
				{
					pointedCar.OnDestroyCar -= OnCarToDeleteDestroy;
				}
				if (car != null && (SingleAllowedCar == null || SingleAllowedCar == car))
				{
					pointedCar = car;
					pointedCar.OnDestroyCar += OnCarToDeleteDestroy;
					HighlightCar(pointedCar, selectionMaterial);
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				else
				{
					pointedCar = null;
					ClearHighlightCar();
				}
			}
		}

		private void OnCarToDeleteDestroy(TrainCar destroyedCar)
		{
			if (destroyedCar != null)
			{
				destroyedCar.OnDestroyCar -= OnCarToDeleteDestroy;
			}
			ClearFlags();
		}

		private void ClearFlags()
		{
			if (pointedCar != null)
			{
				pointedCar.OnDestroyCar -= OnCarToDeleteDestroy;
			}
			pointedCar = null;
			if (carToDelete != null)
			{
				carToDelete.OnDestroyCar -= OnCarToDeleteDestroy;
			}
			carToDelete = null;
			jobOfCar = null;
			forbiddenDeleteByDifficulty = false;
			ClearHighlightCar();
			removePrice = float.PositiveInfinity;
			SetState(State.ScanCarToDelete);
		}
	}
}
