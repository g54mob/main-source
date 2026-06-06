using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using RotaryHeart.Lib.PhysicsExtension;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NewGameplayScripts
{
	public class MovableItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IMovable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		public enum MovingItemType
		{
			Null = 0,
			Misc = 1,
			Bed = 2,
			CatBowl = 3,
			ScratchPost = 4
		}

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
		private TrashCanUI trashCan;

		private Material transparentMaterialInstance;

		private Material transparentMaterialForTrashInstance;

		public MovingItemType movingItemType;

		protected bool isMoving;

		private bool canUpdateMaterial;

		protected bool canPlace = true;

		private bool lastCanPlace = true;

		public bool materialIsGreen;

		private Bounds bounds;

		private Renderer[] renderers;

		private Dictionary<string, Material[]> originalMaterials = new Dictionary<string, Material[]>();

		private List<Color> colors = new List<Color>();

		private bool inBoundaries;

		protected bool isColliding;

		private Transform parent;

		private Vector3 boxCastSize;

		private LayerMask boxCastAllLayerMask;

		private RaycastHit[] raycastHitArray;

		private Outline outline;

		private CursorObject cursor;

		protected bool movable = true;

		private Rigidbody Rigidbody;

		private Collider[] overlapResults = new Collider[5];

		private BigItemPickUpUI bigItemPickUpUI;

		private bool pointEnter;

		public string MoveId { get; private set; }

		public string itemGUID { get; set; }

		public int itemLevelNumber { get; set; }

		public bool isWorkingItem { get; set; }

		public bool isWorking { get; set; }

		public bool secondProjectorOn { get; set; }

		public bool trashInCan { get; set; }

		Transform IMovable.transform => base.transform;

		private void Awake()
		{
			bounds = GetMaxBounds(base.gameObject);
			MoveId = base.transform.position.x.ToString() + base.transform.position.y + base.transform.position.z;
			boxCastSize = new Vector3(0.8f * bounds.size.x / 2f, 0f, 0.8f * bounds.size.z / 2f);
			boxCastAllLayerMask = (int)surfaceToPlaceLayerMask | (int)interactableLayerMask;
			parent = base.transform.parent;
			outline = GetComponent<Outline>();
			cursor = GetComponent<CursorObject>();
			Rigidbody = GetComponent<Rigidbody>();
			renderers = base.transform.GetComponentsInChildren<Renderer>();
			bigItemPickUpUI = GetComponentInChildren<BigItemPickUpUI>();
			SaveOriginalMaterials();
		}

		protected virtual void Start()
		{
			transparentMaterialInstance = new Material(MovementSystem.Instance.transparentMaterialPrefab);
			transparentMaterialForTrashInstance = new Material(MovementSystem.Instance.transparentMaterialForTrashPrefab);
			Rigidbody.drag = 1f;
		}

		private void SaveOriginalMaterials()
		{
			Renderer[] array = renderers;
			foreach (Renderer obj in array)
			{
				string key = obj.gameObject.name;
				Material[] materials = obj.materials;
				Material[] array2 = new Material[materials.Length];
				for (int j = 0; j < materials.Length; j++)
				{
					array2[j] = materials[j];
				}
				originalMaterials[key] = array2;
			}
		}

		private void FixedUpdate()
		{
			if (!isMoving || !inBoundaries || isColliding)
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
				canPlace = (int)interactableLayerMask != ((int)interactableLayerMask | (1 << raycastHitArray[num].transform.gameObject.layer));
			}
			else
			{
				canPlace = true;
			}
		}

		private void LateUpdate()
		{
			if (isMoving)
			{
				if (trashInCan)
				{
					UpdateMaterials(useGreenMaterial: true);
				}
				else if (lastCanPlace != canPlace || materialIsGreen)
				{
					UpdateMaterials(useGreenMaterial: false);
					lastCanPlace = canPlace;
				}
			}
			else if (!InputManager.Instance.gamePause)
			{
				bool flag = IsOnSurface();
				Rigidbody.useGravity = !flag;
				Rigidbody.isKinematic = flag;
				if (outline.enabled && !pointEnter)
				{
					outline.enabled = false;
				}
			}
			if (base.transform.rotation.x != 0f || base.transform.rotation.z != 0f)
			{
				base.transform.rotation = Quaternion.Euler(0f, base.transform.rotation.y, 0f);
			}
		}

		private bool IsOnSurface()
		{
			return UnityEngine.Physics.OverlapSphereNonAlloc(base.transform.position, 0.03f, overlapResults, surfaceToPlaceLayerMask) > 0;
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			if (isMoving || !movable || InputManager.Instance.gamePause || !outline.enabled)
			{
				return;
			}
			if (base.gameObject.CompareTag("BigItem"))
			{
				if (bigItemPickUpUI != null)
				{
					bigItemPickUpUI.StartFilling();
				}
			}
			else
			{
				MovementSystem.Instance.StartMovingTransform(base.transform, isCreated: false, this);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (bigItemPickUpUI != null)
			{
				bigItemPickUpUI.StopFilling();
			}
		}

		public void BigItemStartMoving()
		{
			MovementSystem.Instance.StartMovingTransform(base.transform, isCreated: false, this);
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

		private IEnumerator WaitTillMoving()
		{
			yield return new WaitForSeconds(0.25f);
			isMoving = false;
		}

		public virtual void StartMoving()
		{
			SetIsMoving(value: true);
		}

		public void StopMoving()
		{
			SetIsMoving(value: false);
			base.transform.SetParent(parent);
			ToggleOutline(pointEnter);
			CursorManager.Instance.SetActiveCursorType(pointEnter ? CursorManager.CursorType.Select : CursorManager.CursorType.Arrow);
		}

		public string PassThroughItem()
		{
			return movingItemType switch
			{
				MovingItemType.Null => "Null", 
				MovingItemType.Misc => "Misc", 
				MovingItemType.Bed => "Bed", 
				MovingItemType.CatBowl => "CatBowl", 
				MovingItemType.ScratchPost => "ScratchPost", 
				_ => "Null", 
			};
		}

		public void RemoveTrash()
		{
			SetIsMoving(value: false);
			base.transform.SetParent(parent);
			ToggleOutline(value: false);
			StopAllCoroutines();
			if (trashCan != null)
			{
				trashCan.AnimateTrashCan();
			}
			base.gameObject.SetActive(value: false);
		}

		public bool CheckIfCanPlace()
		{
			return canPlace;
		}

		private void UpdateMaterials(bool useGreenMaterial)
		{
			ToggleOutline(value: false);
			if (!canUpdateMaterial)
			{
				return;
			}
			Renderer[] array = renderers;
			foreach (Renderer renderer in array)
			{
				string key = renderer.gameObject.name;
				if (!originalMaterials.TryGetValue(key, out var value))
				{
					continue;
				}
				Material[] materials = renderer.materials;
				bool flag = false;
				for (int j = 0; j < materials.Length; j++)
				{
					Material material = (useGreenMaterial ? transparentMaterialForTrashInstance : (canPlace ? value[j] : transparentMaterialInstance));
					if (materials[j] != material)
					{
						materials[j] = material;
						flag = true;
					}
				}
				if (flag)
				{
					renderer.materials = materials;
					materialIsGreen = useGreenMaterial;
				}
			}
			ToggleOutline(value: true);
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
		}

		public void RightClickAction()
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				base.transform.gameObject.SetActive(value: false);
				Object.Destroy(base.transform.gameObject);
			}
		}

		private Bounds GetMaxBounds(GameObject parent)
		{
			Bounds result = new Bounds(parent.transform.position, Vector3.zero);
			Collider[] componentsInChildren = parent.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				result.Encapsulate(collider.bounds);
			}
			return result;
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
			if (IsLayerInMask(other.gameObject.layer, boundaryLayerMask))
			{
				canPlace = true;
				inBoundaries = true;
			}
			if (IsLayerInMask(other.gameObject.layer, interactableLayerMask) || IsLayerInMask(other.gameObject.layer, cantPlaceLayerMask))
			{
				canPlace = false;
				isColliding = true;
				trashInCan = false;
			}
			if (base.gameObject.CompareTag("Trash") && IsLayerInMask(other.gameObject.layer, interactableLayerMask) && other.gameObject.TryGetComponent<TrashCan>(out var _))
			{
				canPlace = true;
				trashInCan = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (IsLayerInMask(other.gameObject.layer, boundaryLayerMask))
			{
				canPlace = false;
				inBoundaries = false;
			}
			if ((IsLayerInMask(other.gameObject.layer, interactableLayerMask) || IsLayerInMask(other.gameObject.layer, cantPlaceLayerMask)) && inBoundaries)
			{
				canPlace = true;
				isColliding = false;
				trashInCan = false;
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (IsLayerInMask(other.gameObject.layer, interactableLayerMask) || IsLayerInMask(other.gameObject.layer, cantPlaceLayerMask))
			{
				canPlace = false;
				isColliding = true;
				trashInCan = false;
			}
			if (base.gameObject.CompareTag("Trash") && IsLayerInMask(other.gameObject.layer, interactableLayerMask) && other.gameObject.TryGetComponent<TrashCan>(out var _))
			{
				canPlace = true;
				trashInCan = true;
			}
		}

		private bool IsLayerInMask(int layer, LayerMask mask)
		{
			return ((int)mask & (1 << layer)) != 0;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			pointEnter = true;
			if (movable && !isMoving && !MovementSystem.Instance.IsMoving() && !InputManager.Instance.gamePause)
			{
				ToggleOutline(value: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			pointEnter = false;
			if (!MovementSystem.Instance.IsMoving() && !InputManager.Instance.gamePause && !isMoving)
			{
				ToggleOutline(value: false);
			}
		}
	}
}
