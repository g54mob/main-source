using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CreativeMode;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace NewGameplayScripts
{
	public class MovementSystem : MonoBehaviour, ISavedProgress, ISavedProgressReader
	{
		[SerializeField]
		private Transform ghost;

		[SerializeField]
		private Transform environmentParent;

		[SerializeField]
		private Transform map;

		[SerializeField]
		private GameObject secondFloor;

		[SerializeField]
		private Transform environmentDetectionCollider;

		[SerializeField]
		private LayerMask surfaceToPlaceLayerMask;

		[SerializeField]
		private LayerMask clearSurfaceToPlaceLayerMask;

		[SerializeField]
		private float maxDistance = 100f;

		[SerializeField]
		public Material transparentMaterialPrefab;

		[SerializeField]
		public Material transparentMaterialForTrashPrefab;

		public MEvent ItemPassthrough;

		private Transform movingTransform;

		private IMovable item;

		private ObjectSO objectSO;

		private string plantMoveID;

		private bool isMoving;

		private float height;

		private Vector3 screenPosition;

		private Vector3 targetPosition;

		private Ray ray;

		private float yOffset = 0.05f;

		private float rotationSpeed = 300f;

		private float lerpSpeed = 30f;

		private Quaternion targetRotation;

		public bool wallPlant;

		private float topWall_Y;

		private InputAction zoomAction;

		private PlayerInputActions inputActions;

		private float previousScrollValue;

		private int rotateDelayCounter;

		private int rotateDelay = 30;

		public Action<ObjectSO, string> OnCancelMoving;

		private bool IsFirstPlantMoved = true;

		private bool IsFirstPlantCanceled = true;

		private bool IsFirstObjectMoved = true;

		private bool isPlant;

		private bool isLampHumidifier;

		private IEnumerable<IMovable> itemCollection = new List<IMovable>();

		private List<string> removedTrash = new List<string>();

		public static MovementSystem Instance { get; private set; }

		public event EventHandler OnStartMovingItem;

		public event EventHandler OnStartMovingTrash;

		public event EventHandler OnStopMovingItem;

		public event EventHandler OnStartGrabbing;

		public event EventHandler OnStopGrabbing;

		public event EventHandler OnFirstPlantPlaced;

		public event EventHandler OnFirstPlantMoved;

		public event EventHandler OnFirstPlantCanceled;

		public event EventHandler OnFirstObjectMoved;

		public event EventHandler OnFirstObjectRotate;

		public event EventHandler OnCannotPlacedObject;

		public event EventHandler OnStartMovingPlant;

		public event EventHandler OnStopMovingPlant;

		public event EventHandler OnStartMovingLamp_Humidifier;

		public event EventHandler OnStopMovingLamp_Humidifier;

		private void Awake()
		{
			Instance = this;
			environmentDetectionCollider.gameObject.SetActive(value: false);
			itemCollection = GetAllMovableItems();
			inputActions = new PlayerInputActions();
			zoomAction = inputActions.Camera.Zoom;
		}

		private void Start()
		{
			InputManager.Instance.OnInteract += InputManager_OnInteract;
			InputManager.Instance.OnInteractAlternate += InputManager_OnInteractAlternate;
			zoomAction.Enable();
		}

		private void InputManager_OnInteractAlternate(object sender, EventArgs e)
		{
			if (isMoving && movingTransform != null)
			{
				item.RightClickAction();
				if (AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
				{
					ClearElements();
				}
				if (objectSO != null)
				{
					CancelMoving();
				}
			}
		}

		private void InputManager_OnInteract(object sender, EventArgs e)
		{
			if (isMoving && movingTransform != null && item != null)
			{
				if (item.CheckIfCanPlace())
				{
					StopMovingTransform();
				}
				else
				{
					this.OnCannotPlacedObject?.Invoke(null, null);
				}
			}
		}

		private void Update()
		{
			if (!isMoving || !(movingTransform != null))
			{
				return;
			}
			ghost.position = Vector3.Lerp(ghost.position, targetPosition, Time.deltaTime * 15f);
			float num = zoomAction.ReadValue<Vector2>().normalized.y;
			if (previousScrollValue == num && rotateDelayCounter++ < rotateDelay && num != 0f)
			{
				num = 0f;
			}
			else
			{
				rotateDelayCounter = 0;
			}
			float num2 = (float)((double)num * 0.1);
			if (num2 != 0f)
			{
				if (wallPlant)
				{
					return;
				}
				this.OnFirstObjectRotate?.Invoke(null, null);
				targetRotation *= Quaternion.Euler(Vector3.up * num2 * rotationSpeed);
			}
			movingTransform.rotation = Quaternion.Lerp(movingTransform.rotation, targetRotation, lerpSpeed * Time.deltaTime);
			previousScrollValue = zoomAction.ReadValue<Vector2>().normalized.y;
		}

		private void CancelMoving()
		{
			StopAllCoroutines();
			Plant component = movingTransform.GetComponent<Plant>();
			component.GetID();
			string gUID = component.GetGUID();
			OnCancelMoving?.Invoke(objectSO, gUID);
			UnityEngine.Object.Destroy(movingTransform.GetComponent<Plant>().gameObject);
			NewScoreUI.Instance.StopPlantMoving();
			PlantNeeds.Instance.HideAnimation();
			TurnOffEnvironmentCollider();
			ClearElements();
			if (IsFirstPlantCanceled)
			{
				this.OnFirstPlantCanceled?.Invoke(this, EventArgs.Empty);
				IsFirstPlantCanceled = false;
			}
		}

		private void FixedUpdate()
		{
			if (!isMoving || item == null)
			{
				wallPlant = false;
				return;
			}
			screenPosition = InputManager.Instance.GetMousePosition();
			ray = Camera.main.ScreenPointToRay(screenPosition);
			RaycastHit[] array = Physics.RaycastAll(ray, 100f, surfaceToPlaceLayerMask);
			RaycastHit[] array2 = Physics.RaycastAll(ray, 100f, clearSurfaceToPlaceLayerMask);
			if (array.Length == 0)
			{
				return;
			}
			Array.Sort(array, (RaycastHit a, RaycastHit b) => a.distance.CompareTo(b.distance));
			Array.Sort(array2, (RaycastHit a, RaycastHit b) => a.distance.CompareTo(b.distance));
			if (wallPlant)
			{
				RaycastHit[] array3 = array;
				for (int num = 0; num < array3.Length; num++)
				{
					RaycastHit raycastHit = array3[num];
					if (!(raycastHit.transform == item.transform))
					{
						targetPosition = ((topWall_Y < raycastHit.point.y) ? new Vector3(raycastHit.point.x, topWall_Y, raycastHit.point.z) : raycastHit.point);
						break;
					}
				}
			}
			else
			{
				RaycastHit[] array3 = array2;
				for (int num = 0; num < array3.Length; num++)
				{
					RaycastHit raycastHit2 = array3[num];
					if (!(raycastHit2.transform == item.transform))
					{
						targetPosition = new Vector3(raycastHit2.point.x, raycastHit2.point.y + yOffset, raycastHit2.point.z);
						break;
					}
				}
			}
			if (item.transform.position.y <= -25f)
			{
				item.transform.position = new Vector3(item.transform.position.x, ghost.transform.position.y + 1f, item.transform.position.z);
				movingTransform.GetComponent<Rigidbody>().useGravity = false;
				movingTransform.GetComponent<Rigidbody>().isKinematic = true;
			}
		}

		public void StartMovingTransform(Transform selectedTransform, bool isCreated, IMovable item)
		{
			if (isMoving)
			{
				return;
			}
			if (isCreated)
			{
				screenPosition = InputManager.Instance.GetMousePosition();
				Vector3 vector = Camera.main.ScreenToWorldPoint(screenPosition);
				targetPosition = new Vector3(vector.x, yOffset, vector.z);
			}
			else
			{
				targetPosition = selectedTransform.position;
			}
			ghost.position = targetPosition;
			movingTransform = selectedTransform;
			movingTransform.SetParent(ghost);
			movingTransform.localPosition = Vector3.zero;
			targetRotation = movingTransform.rotation;
			this.item = item;
			this.item.StartMoving();
			string value = this.item.PassThroughItem();
			ItemPassthrough.Invoke(value);
			if (movingTransform.CompareTag("Trash"))
			{
				this.OnStartMovingTrash?.Invoke(this, EventArgs.Empty);
			}
			if (!movingTransform.GetComponent<MovableItem>())
			{
				this.OnStartMovingItem?.Invoke(this, EventArgs.Empty);
				if ((bool)movingTransform.GetComponent<Plant>())
				{
					this.OnStartMovingPlant?.Invoke(this, EventArgs.Empty);
					isPlant = true;
				}
				else if ((bool)movingTransform.GetComponent<Lamp>() || (bool)movingTransform.GetComponent<Humidifyer>())
				{
					this.OnStartMovingLamp_Humidifier?.Invoke(this, EventArgs.Empty);
					isLampHumidifier = true;
				}
			}
			this.OnStartGrabbing?.Invoke(this, EventArgs.Empty);
			SetIsMoving(value: true);
			if (!isCreated)
			{
				if (IsFirstPlantMoved)
				{
					this.OnFirstPlantMoved?.Invoke(this, EventArgs.Empty);
					IsFirstPlantMoved = false;
				}
				else if (!movingTransform.GetComponent<Plant>() && IsFirstObjectMoved)
				{
					this.OnFirstObjectMoved?.Invoke(this, EventArgs.Empty);
					IsFirstObjectMoved = false;
				}
			}
		}

		private void StopMovingTransform()
		{
			if (item.trashInCan)
			{
				CheckTrash();
			}
			else
			{
				Physics.Raycast(movingTransform.position, -Vector3.up, out var hitInfo, maxDistance, surfaceToPlaceLayerMask);
				if (wallPlant)
				{
					height = movingTransform.position.y;
				}
				else
				{
					height = movingTransform.position.y - hitInfo.distance;
				}
				movingTransform.position = new Vector3(targetPosition.x, height, targetPosition.z);
				item.StopMoving();
				if (AllServices.Container.Single<IPersistentProgressService>().Progress.IsTutorial)
				{
					this.OnFirstPlantPlaced?.Invoke(this, EventArgs.Empty);
				}
				ClearElements();
			}
			string value = "Exit";
			ItemPassthrough.Invoke(value);
		}

		public bool IsMoving()
		{
			return isMoving;
		}

		public void SetWallPlant(bool isWallPlant, Vector3 topWorld)
		{
			wallPlant = isWallPlant;
			topWall_Y = topWorld.y - 1f;
		}

		public (bool success, Plant plant) GetMovingPlant()
		{
			if (movingTransform == null || !movingTransform.TryGetComponent<Plant>(out var component))
			{
				return (success: false, plant: null);
			}
			return (success: true, plant: component);
		}

		public void SetObjectSo(ObjectSO objectSo, string moveID)
		{
			objectSO = objectSo;
			plantMoveID = moveID;
		}

		public void CheckTrash()
		{
			movingTransform.TryGetComponent<MovableItem>(out var component);
			Physics.Raycast(movingTransform.position, -Vector3.up, out var hitInfo, maxDistance, surfaceToPlaceLayerMask);
			height = movingTransform.position.y - hitInfo.distance;
			movingTransform.position = new Vector3(targetPosition.x, height, targetPosition.z);
			component.RemoveTrash();
			removedTrash.Add(component.MoveId);
			ClearElements();
		}

		private void RemoveTrash()
		{
			foreach (IMovable item in itemCollection)
			{
				foreach (string item2 in removedTrash)
				{
					if (item.MoveId == item2)
					{
						item.transform.gameObject.SetActive(value: false);
					}
				}
			}
		}

		public string GetPlantMoveID()
		{
			return plantMoveID;
		}

		public void TurnOnEnvironmentCollider()
		{
			environmentDetectionCollider.gameObject.SetActive(value: true);
		}

		public void TurnOffEnvironmentCollider()
		{
			environmentDetectionCollider.gameObject.SetActive(value: false);
		}

		public IEnumerable<IMovable> GetAllItemsOnLevel()
		{
			return itemCollection;
		}

		public void SwitchItemsMoveOnFirstFloorPossibility(bool TurnOn)
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				itemCollection = GetAllMovableItems();
			}
			foreach (IMovable item in itemCollection)
			{
				if (item.transform.localPosition.y < 10f)
				{
					item.SwitchMovement(TurnOn);
				}
			}
		}

		public void ShowPlantInfo()
		{
			this.OnStartMovingPlant?.Invoke(this, EventArgs.Empty);
		}

		public void HidePlantInfo()
		{
			this.OnStopMovingPlant?.Invoke(this, EventArgs.Empty);
		}

		private void SetIsMoving(bool value)
		{
			if (!value)
			{
				StopAllCoroutines();
				StartCoroutine(WaitTillMoving());
			}
			else
			{
				isMoving = value;
			}
		}

		private IEnumerator WaitTillMoving()
		{
			yield return new WaitForSeconds(0.25f);
			isMoving = false;
		}

		private void ClearElements()
		{
			AllServices.Container.Single<ISaveLoadService>().SaveProgress();
			SetIsMoving(value: false);
			movingTransform = null;
			item = null;
			objectSO = null;
			plantMoveID = null;
			ghost.position = Vector3.zero;
			EnvironmentManager.Instance.HideSunlight();
			EnvironmentManager.Instance.HideHumidity();
			this.OnStopMovingItem?.Invoke(this, EventArgs.Empty);
			if (isPlant)
			{
				this.OnStopMovingPlant?.Invoke(this, EventArgs.Empty);
			}
			else if (isLampHumidifier)
			{
				this.OnStopMovingLamp_Humidifier?.Invoke(this, EventArgs.Empty);
			}
			isPlant = false;
			isLampHumidifier = false;
			wallPlant = false;
			this.OnStopGrabbing?.Invoke(this, EventArgs.Empty);
		}

		public void LoadProgress(PlayerProgress progress)
		{
			if (!progress.CreativeMode)
			{
				if (itemCollection == null)
				{
					return;
				}
				IEnumerable<IMovable> source = itemCollection;
				foreach (MovableItems item in progress.movableItems)
				{
					IMovable movable = source.FirstOrDefault((IMovable x) => x.MoveId == item.ID);
					if (movable == null || item == null)
					{
						continue;
					}
					movable.transform.position = new Vector3(item.worldPositionX, item.worldPositionY, item.worldPositionZ);
					movable.transform.rotation = Quaternion.Euler(new Vector3(0f, item.rotation, 0f));
					if (item.isWorkingItem)
					{
						if (item.isWorking != movable.isWorking || item.secondProjectorOn != movable.secondProjectorOn)
						{
							movable.RightClickAction();
						}
						if (item.isWorking != movable.isWorking || item.secondProjectorOn != movable.secondProjectorOn)
						{
							movable.RightClickAction();
						}
					}
				}
				removedTrash.Clear();
				foreach (string item2 in progress.RemovedTrash)
				{
					removedTrash.Add(item2);
				}
				RemoveTrash();
				return;
			}
			string key = SceneManager.GetActiveScene().name;
			foreach (MovableItems movableItem in progress.CreativeModeProgresses[key].movableItems)
			{
				IMovable movable2 = ItemCreatingSystem.Instance.LoadItem(movableItem.levelNumber, movableItem.ItemGUID, movableItem.worldPositionY);
				if (movable2 != null)
				{
					movable2.transform.position = new Vector3(movableItem.worldPositionX, movableItem.worldPositionY, movableItem.worldPositionZ);
					movable2.transform.rotation = Quaternion.Euler(new Vector3(0f, movableItem.rotation, 0f));
					if (movableItem.isWorkingItem && movableItem.isWorking != movable2.isWorking)
					{
						movable2.RightClickAction();
					}
				}
			}
		}

		public void UpdateProgress(PlayerProgress progress)
		{
			if (!progress.CreativeMode)
			{
				if (itemCollection == null)
				{
					return;
				}
				progress.movableItems.Clear();
				foreach (IMovable item in itemCollection)
				{
					MovableItems movableItems = new MovableItems();
					movableItems.ID = item.MoveId;
					movableItems.worldPositionX = item.transform.position.x;
					movableItems.worldPositionY = item.transform.position.y;
					movableItems.worldPositionZ = item.transform.position.z;
					movableItems.rotation = item.transform.eulerAngles.y;
					movableItems.isWorkingItem = item.isWorkingItem;
					movableItems.isWorking = item.isWorking;
					movableItems.secondProjectorOn = item.secondProjectorOn;
					progress.movableItems.Add(movableItems);
				}
				progress.RemovedTrash.Clear();
				{
					foreach (string item2 in removedTrash)
					{
						progress.RemovedTrash.Add(item2);
					}
					return;
				}
			}
			progress.CreativeModeProgresses[SceneManager.GetActiveScene().name].movableItems.Clear();
			itemCollection = GetAllMovableItems();
			foreach (IMovable item3 in itemCollection)
			{
				MovableItems movableItems2 = new MovableItems();
				movableItems2.ID = item3.MoveId;
				movableItems2.worldPositionX = item3.transform.position.x;
				movableItems2.worldPositionY = item3.transform.position.y;
				movableItems2.worldPositionZ = item3.transform.position.z;
				movableItems2.rotation = item3.transform.eulerAngles.y;
				movableItems2.isWorkingItem = item3.isWorkingItem;
				movableItems2.isWorking = item3.isWorking;
				movableItems2.levelNumber = item3.itemLevelNumber;
				movableItems2.ItemGUID = item3.itemGUID;
				progress.CreativeModeProgresses[SceneManager.GetActiveScene().name].movableItems.Add(movableItems2);
			}
		}

		private IEnumerable<IMovable> GetAllMovableItems()
		{
			List<IMovable> list = new List<IMovable>();
			bool flag = true;
			if (secondFloor != null)
			{
				flag = secondFloor.activeInHierarchy;
			}
			if (!flag)
			{
				secondFloor.SetActive(value: true);
			}
			list.AddRange(map.GetComponentsInChildren<IMovable>());
			list.AddRange(environmentParent.GetComponentsInChildren<IMovable>());
			if (secondFloor != null)
			{
				secondFloor.SetActive(flag);
			}
			return list;
		}

		private void OnDestroy()
		{
			InputManager.Instance.OnInteract -= InputManager_OnInteract;
			InputManager.Instance.OnInteractAlternate -= InputManager_OnInteractAlternate;
			itemCollection = null;
			zoomAction.Disable();
		}

		public void MouseEnterInWallForPlantZone(bool orientationX, float zCoordinate, float xCoordinate)
		{
			if (isMoving)
			{
				Vector3 mousePosition = Input.mousePosition;
				mousePosition.z = Vector3.Distance(base.transform.position, Camera.main.transform.position);
				Vector3 vector = Camera.main.ScreenToWorldPoint(mousePosition);
				if (orientationX)
				{
					vector.x = xCoordinate;
				}
				else
				{
					vector.z = zCoordinate;
				}
				if (Mathf.Abs(targetPosition.x - vector.x) > 5f || Mathf.Abs(targetPosition.y - vector.y) > 5f || Mathf.Abs(targetPosition.z - vector.z) > 5f)
				{
					targetPosition = vector;
				}
			}
		}
	}
}
