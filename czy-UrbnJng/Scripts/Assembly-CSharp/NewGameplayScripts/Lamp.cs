using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using RotaryHeart.Lib.PhysicsExtension;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace NewGameplayScripts
{
	public class Lamp : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IMovable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
	{
		[SerializeField]
		private EnvironmentSunlight[] environmentSunlights;

		[SerializeField]
		private Color color;

		[SerializeField]
		private LayerMask boundaryLayerMask;

		[SerializeField]
		private LayerMask surfaceToPlaceLayerMask;

		[SerializeField]
		private LayerMask cantPlaceLayerMask;

		[SerializeField]
		private LayerMask interactableLayerMask;

		[SerializeField]
		private GameObject lampVisual;

		[SerializeField]
		private Light lightMin;

		[SerializeField]
		private Light lightMax;

		[SerializeField]
		private Light secondLightMin;

		[SerializeField]
		private Light secondLightMax;

		[SerializeField]
		private DecalProjector projector;

		[SerializeField]
		private DecalProjector projector2;

		[SerializeField]
		private Transform iconButton;

		[SerializeField]
		private Image redButton;

		[SerializeField]
		private Image greenButton;

		[SerializeField]
		private bool _isWorking;

		[SerializeField]
		private bool candle;

		[SerializeField]
		private Material transparentMaterialInstance;

		private bool isMoving;

		private bool canUpdateMaterial;

		private bool canPlace = true;

		private bool lastCanPlace = true;

		private Bounds bounds;

		private Renderer[] renderers;

		private List<Material[]> materials = new List<Material[]>();

		private Dictionary<string, Material[]> originalMaterials = new Dictionary<string, Material[]>();

		private List<Color> colors = new List<Color>();

		private Transform lastSurfaceToPlace;

		private bool inBoundaries;

		private bool isColliding;

		private Vector3 boxCastSize;

		private LayerMask boxCastAllLayerMask;

		private RaycastHit[] raycastHitArray;

		private Transform parent;

		private Outline outline;

		private CursorObject cursor;

		public bool movable = true;

		private Rigidbody Rigidbody;

		private Collider[] overlapResults = new Collider[5];

		private bool pointEnter;

		public string MoveId { get; set; }

		public string itemGUID { get; set; }

		public int itemLevelNumber { get; set; }

		public bool isWorkingItem { get; set; } = true;

		public bool isWorking { get; set; } = true;

		public bool secondProjectorOn { get; set; }

		public bool trashInCan { get; set; }

		Transform IMovable.transform => base.transform;

		private void Awake()
		{
			HideLight();
			bounds = GetMaxBounds(lampVisual);
			MoveId = base.transform.position.x.ToString() + base.transform.position.y + base.transform.position.z;
			boxCastSize = new Vector3(0.8f * bounds.size.x / 2f, 0f, 0.8f * bounds.size.z / 2f);
			boxCastAllLayerMask = (int)surfaceToPlaceLayerMask | (int)interactableLayerMask;
			parent = base.transform.parent;
			cursor = GetComponent<CursorObject>();
			outline = GetComponentInChildren<Outline>();
			Rigidbody = GetComponent<Rigidbody>();
			renderers = base.transform.GetComponentsInChildren<Renderer>();
			SaveOriginalMaterials();
		}

		private void Start()
		{
			if (_isWorking != isWorking)
			{
				TogglePrimaryState();
			}
			transparentMaterialInstance = new Material(MovementSystem.Instance.transparentMaterialPrefab);
		}

		private void FixedUpdate()
		{
			if (isMoving)
			{
				if (!inBoundaries || isColliding)
				{
					return;
				}
				raycastHitArray = RotaryHeart.Lib.PhysicsExtension.Physics.BoxCastAll(base.transform.position, boxCastSize, Vector3.down, Quaternion.identity, 100f, boxCastAllLayerMask, PreviewCondition.Both);
				int num = 1;
				if (raycastHitArray.Length > 2)
				{
					if (raycastHitArray[num].transform == base.transform)
					{
						num++;
					}
					if ((int)interactableLayerMask == ((int)interactableLayerMask | (1 << raycastHitArray[num].transform.gameObject.layer)))
					{
						canPlace = false;
					}
					else
					{
						canPlace = true;
					}
				}
				else
				{
					canPlace = true;
				}
			}
			else
			{
				bool flag = IsOnSurface();
				Rigidbody.useGravity = !flag;
				Rigidbody.isKinematic = flag;
				if (outline.enabled && !pointEnter)
				{
					outline.enabled = false;
					ToggleTurnOnOffButton(valueOff: false, valueOn: false);
				}
			}
		}

		private void LateUpdate()
		{
			if (isMoving && lastCanPlace != canPlace)
			{
				UpdateMaterials();
				lastCanPlace = canPlace;
			}
		}

		private void SaveOriginalMaterials()
		{
			Renderer[] array = renderers;
			foreach (Renderer obj in array)
			{
				string key = obj.gameObject.name;
				Material[] array2 = obj.materials;
				Material[] array3 = new Material[array2.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					array3[j] = array2[j];
				}
				originalMaterials[key] = array3;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (!isMoving && movable && !InputManager.Instance.gamePause)
			{
				MovementSystem.Instance.StartMovingTransform(base.transform, isCreated: false, this);
			}
		}

		public void StartMoving()
		{
			SetIsMoving(value: true);
			EnvironmentManager.Instance.ShowSunlight();
			EnvironmentManager.Instance.ShowHumidity();
			ShowLight();
			ToggleTurnOnOffButton(!isWorking, isWorking);
			if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				NewScoreUI.Instance.StartPlantMoving();
			}
		}

		public void StopMoving()
		{
			HideLight();
			SetIsMoving(value: false);
			base.transform.SetParent(parent);
			if (pointEnter)
			{
				ToggleOutline(value: true);
				ToggleTurnOnOffButton(!isWorking, isWorking);
				CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Select);
			}
			else
			{
				ToggleOutline(value: false);
				ToggleTurnOnOffButton(valueOff: false, valueOn: false);
				CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
			}
			if (!AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				NewScoreUI.Instance.StopPlantMoving();
			}
		}

		public string PassThroughItem()
		{
			return string.Empty;
		}

		public bool CheckIfCanPlace()
		{
			return canPlace;
		}

		public void ToggleOutline(bool value)
		{
			if (outline != null && movable)
			{
				outline.enabled = value;
			}
		}

		public void SwitchMovement(bool turnOn)
		{
			cursor.cursorType = (turnOn ? CursorManager.CursorType.Select : CursorManager.CursorType.Arrow);
			movable = turnOn;
			EnvironmentSunlight[] array = environmentSunlights;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].movable = turnOn;
			}
		}

		public void RightClickAction()
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				base.transform.gameObject.SetActive(value: false);
				Object.Destroy(base.transform.gameObject);
			}
			else if (candle)
			{
				isWorking = !isWorking;
				lightMin.enabled = isWorking;
				redButton.gameObject.SetActive(!isWorking);
				greenButton.gameObject.SetActive(isWorking);
			}
			else if (isWorking && !secondProjectorOn)
			{
				ActivateSecondProjector();
				if (!InputManager.Instance.gamePause)
				{
					SoundManager.Instance.OnObjectTurnOn();
				}
			}
			else
			{
				TogglePrimaryState();
			}
		}

		private void UpdateEnvironmentSunlight(int index, EnvironmentSunlight.Sunlight sunlightLevel)
		{
			environmentSunlights[index].gameObject.SetActive(value: false);
			environmentSunlights[index].sunlight = sunlightLevel;
			environmentSunlights[index].gameObject.SetActive(value: true);
		}

		private void TogglePrimaryState()
		{
			if (!InputManager.Instance.gamePause)
			{
				if (isWorking)
				{
					SoundManager.Instance.OnObjectTurnOff();
				}
				else
				{
					SoundManager.Instance.OnObjectTurnOn();
				}
			}
			isWorking = !isWorking;
			lightMin.enabled = isWorking;
			if (secondLightMin != null)
			{
				secondLightMin.enabled = isWorking;
			}
			projector.enabled = isWorking;
			UpdateEnvironmentSunlight(0, isWorking ? EnvironmentSunlight.Sunlight.Middle : EnvironmentSunlight.Sunlight.Low);
			ToggleTurnOnOffButton(!isWorking, isWorking);
			if (!isMoving)
			{
				ToggleTurnOnOffButton(valueOff: false, valueOn: false);
			}
			if (secondProjectorOn)
			{
				secondProjectorOn = false;
				lightMax.enabled = false;
				projector2.enabled = false;
				UpdateEnvironmentSunlight(1, EnvironmentSunlight.Sunlight.Low);
			}
		}

		private void ActivateSecondProjector()
		{
			secondProjectorOn = true;
			if (!(projector2 == null))
			{
				projector.enabled = false;
				lightMin.enabled = false;
				UpdateEnvironmentSunlight(0, EnvironmentSunlight.Sunlight.Low);
				lightMax.enabled = true;
				projector2.enabled = true;
				UpdateEnvironmentSunlight(1, EnvironmentSunlight.Sunlight.Middle);
			}
		}

		private void SetIsMoving(bool value)
		{
			canUpdateMaterial = value;
			if (!value)
			{
				Animate();
				StopAllCoroutines();
				StartCoroutine(WaitTillMoving());
			}
			else
			{
				isMoving = value;
			}
		}

		private bool IsOnSurface()
		{
			return UnityEngine.Physics.OverlapSphereNonAlloc(base.transform.position, 0.03f, overlapResults, surfaceToPlaceLayerMask) > 0;
		}

		private IEnumerator WaitTillMoving()
		{
			yield return new WaitForSeconds(0.25f);
			isMoving = false;
		}

		private void UpdateMaterials()
		{
			ToggleOutline(value: false);
			if (canUpdateMaterial)
			{
				Renderer[] array = renderers;
				foreach (Renderer renderer in array)
				{
					string key = renderer.gameObject.name;
					if (originalMaterials.TryGetValue(key, out var value))
					{
						Material[] array2 = renderer.materials;
						for (int j = 0; j < array2.Length; j++)
						{
							array2[j] = (canPlace ? value[j] : transparentMaterialInstance);
						}
						renderer.materials = array2;
					}
				}
			}
			ToggleOutline(value: true);
		}

		private Bounds GetMaxBounds(GameObject parent)
		{
			Bounds result = new Bounds(parent.transform.position, Vector3.zero);
			Collider[] components = parent.GetComponents<Collider>();
			foreach (Collider collider in components)
			{
				result.Encapsulate(collider.bounds);
			}
			return result;
		}

		private void ShowLight()
		{
			EnvironmentSunlight[] array = environmentSunlights;
			foreach (EnvironmentSunlight obj in array)
			{
				obj.SetCanChange(value: false);
				obj.Show();
			}
		}

		private void HideLight()
		{
			EnvironmentSunlight[] array = environmentSunlights;
			foreach (EnvironmentSunlight obj in array)
			{
				obj.SetCanChange(value: true);
				obj.Hide();
			}
		}

		private void Animate()
		{
			base.transform.DOScale(0.9f, 0.05f).SetEase(Ease.InOutSine).OnComplete(delegate
			{
				base.transform.DOScale(1.1f, 0.1f).SetEase(Ease.InOutSine).OnComplete(delegate
				{
					base.transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine);
				});
			});
		}

		private void OnTriggerEnter(Collider other)
		{
			if (((int)boundaryLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer)
			{
				canPlace = true;
				inBoundaries = true;
			}
			if (((int)interactableLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer || ((int)cantPlaceLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer)
			{
				canPlace = false;
				isColliding = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (((int)boundaryLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer)
			{
				canPlace = false;
				inBoundaries = false;
			}
			if ((((int)interactableLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer || ((int)cantPlaceLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer) && inBoundaries)
			{
				canPlace = true;
				isColliding = false;
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (((int)interactableLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer || ((int)cantPlaceLayerMask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer)
			{
				canPlace = false;
				isColliding = true;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointEnter = true;
			if (movable && !isMoving && !MovementSystem.Instance.IsMoving() && !InputManager.Instance.gamePause)
			{
				ToggleOutline(value: true);
				ToggleTurnOnOffButton(!isWorking, isWorking);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			pointEnter = false;
			if (movable && !isMoving && !MovementSystem.Instance.IsMoving() && !InputManager.Instance.gamePause)
			{
				ToggleOutline(value: false);
				ToggleTurnOnOffButton(valueOff: false, valueOn: false);
			}
		}

		private void ToggleTurnOnOffButton(bool valueOff, bool valueOn)
		{
			redButton.gameObject.SetActive(valueOff);
			greenButton.gameObject.SetActive(valueOn);
			if (!valueOff && !valueOn)
			{
				iconButton.gameObject.SetActive(value: false);
			}
			else
			{
				iconButton.gameObject.SetActive(value: true);
			}
		}
	}
}
