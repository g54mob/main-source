using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Data.Enums;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using RotaryHeart.Lib.PhysicsExtension;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NewGameplayScripts
{
	public class Plant : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IMovable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
	{
		public class OnEnvironmentChangedEventArgs : EventArgs
		{
			public EnvironmentSunlight.Sunlight sunlight;

			public EnvironmentHumidity.Humidity humidity;
		}

		[SerializeField]
		private LayerMask boundaryLayerMask;

		[SerializeField]
		private LayerMask surfaceToPlaceLayerMask;

		[SerializeField]
		private LayerMask clearSurfaceToPlaceLayerMask;

		[SerializeField]
		private LayerMask cantPlaceLayerMask;

		[SerializeField]
		private LayerMask interactableLayerMask;

		[SerializeField]
		private Material transparentMaterialInstance;

		private EnvironmentSunlight.Sunlight sunlight;

		private EnvironmentHumidity.Humidity humidity;

		private bool isCollidingSunlight;

		private bool isCollidingHumidity;

		private bool isInnerSunlight;

		private bool isInnerHumidity;

		private const int EnvironmentBonusPoints = 5;

		private const string INNER_SUNLIGHT = "InnerSunlight";

		private const string INNER_HUMIDITY = "InnerHumidity";

		private const int DISTANCE = 2;

		private int ID;

		private ObjectSO objectSO;

		public PlantSize plantSize;

		private int score;

		private Transform plantTransform;

		private Transform floorPotVisual;

		private Transform wallPotVisual;

		private int floorPotIndex;

		private int wallPotIndex;

		private bool hasVariant;

		private int variantIndex;

		private bool isMoving;

		private bool canPlace = true;

		private bool lastCanPlace;

		private bool canUpdateMaterial;

		private Bounds plantBounds;

		private Renderer[] plantTransformRenderers;

		private List<Material[]> plantTransformMaterials = new List<Material[]>();

		private Dictionary<string, Material[]> originalMaterials = new Dictionary<string, Material[]>();

		private List<Color> plantColors = new List<Color>();

		private Transform lastSurfaceToPlace;

		private bool inBoundaries;

		private bool isColliding;

		private Vector3 boxCastSize;

		private LayerMask boxCastAllLayerMask;

		private RaycastHit[] raycastHitArray;

		private Transform parent;

		private InstallationEffect installationEffect;

		private List<Outline> outlines = new List<Outline>();

		private bool wallPlant;

		private int firstStepOffsetCutoff = 10;

		private bool pointEnter;

		public Transform plantVisual;

		public bool creativeMode;

		private SinglePlantInfoUI singlePlantInfoUI;

		private Transform floorPot;

		private Transform wallPot;

		private bool movable = true;

		private CursorObject cursor;

		private Rigidbody Rigidbody;

		private Collider[] overlapResults = new Collider[5];

		public string MoveId { get; set; }

		public string itemGUID { get; set; }

		public int itemLevelNumber { get; set; }

		public bool isWorkingItem { get; set; }

		public bool isWorking { get; set; }

		public bool secondProjectorOn { get; set; }

		public bool trashInCan { get; set; }

		Transform IMovable.transform => base.transform;

		public event EventHandler<OnEnvironmentChangedEventArgs> OnEnvironmentChanged;

		public static Plant Create(ObjectSO objectSO, Transform plantVisual, bool hasVariant, int variantIndex, (Transform, int) floorPot, (Transform, int) wallPot, int ID, Transform plantParent)
		{
			Transform transform = UnityEngine.Object.Instantiate(plantVisual, plantParent);
			Plant component = transform.GetComponent<Plant>();
			component.objectSO = objectSO;
			component.plantTransform = transform;
			component.ID = ID;
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				component.creativeMode = true;
			}
			component.score = objectSO.score;
			component.plantSize = (PlantSize)objectSO.size.x;
			component.parent = plantParent;
			component.itemGUID = objectSO.GUID;
			if (hasVariant)
			{
				component.hasVariant = hasVariant;
				component.variantIndex = variantIndex;
				component.plantSize = (PlantSize)objectSO.variantsList[variantIndex].size.x;
				component.itemGUID = objectSO.variantsList[variantIndex].GUID;
			}
			if (floorPot.Item1 != null)
			{
				component.floorPotVisual = floorPot.Item1;
				component.floorPotIndex = floorPot.Item2;
				component.floorPot = UnityEngine.Object.Instantiate(component.floorPotVisual, transform);
				component.installationEffect = component.floorPot.GetComponentInChildren<InstallationEffect>();
			}
			if (wallPot.Item1 != null)
			{
				component.wallPotVisual = wallPot.Item1;
				component.wallPotIndex = wallPot.Item2;
				component.wallPot = UnityEngine.Object.Instantiate(component.wallPotVisual, transform);
			}
			component.plantTransformRenderers = component.plantTransform.GetComponentsInChildren<Renderer>();
			Renderer[] array = component.plantTransformRenderers;
			foreach (Renderer obj in array)
			{
				string key = obj.gameObject.name;
				Material[] materials = obj.materials;
				Material[] array2 = new Material[materials.Length];
				for (int j = 0; j < materials.Length; j++)
				{
					array2[j] = materials[j];
				}
				component.originalMaterials[key] = array2;
			}
			component.plantBounds = component.GetMaxBounds(component.plantTransform.gameObject);
			component.SetIsMoving(value: true);
			component.singlePlantInfoUI = component.GetComponentInChildren<SinglePlantInfoUI>();
			component.cursor = component.GetComponent<CursorObject>();
			component.Rigidbody = component.GetComponent<Rigidbody>();
			component.Rigidbody.drag = 1f;
			Outline[] componentsInChildren = component.GetComponentsInChildren<Outline>();
			foreach (Outline item in componentsInChildren)
			{
				component.outlines.Add(item);
			}
			component.boxCastSize = new Vector3(0.8f * component.plantBounds.size.x / 2f, 0f, 0.8f * component.plantBounds.size.z / 2f);
			component.boxCastAllLayerMask = (int)component.surfaceToPlaceLayerMask | (int)component.interactableLayerMask;
			component.wallPot.gameObject.SetActive(value: false);
			component.transparentMaterialInstance = new Material(MovementSystem.Instance.transparentMaterialPrefab);
			component.PlantVisualCheck(WorldOrientation.East);
			component.MoveId = "";
			return component;
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
				else if (RotaryHeart.Lib.PhysicsExtension.Physics.SphereCast(plantTransform.position, (float)objectSO.size.x / 4f, Vector3.up, plantBounds.size.y - (float)objectSO.size.x / 4f - 0.1f, cantPlaceLayerMask, PreviewCondition.Both))
				{
					canPlace = false;
				}
				else if (RotaryHeart.Lib.PhysicsExtension.Physics.SphereCast(plantTransform.position, (float)objectSO.size.x / 4f, Vector3.up, plantBounds.size.y - (float)objectSO.size.x / 4f - 0.1f, surfaceToPlaceLayerMask, PreviewCondition.Both))
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
				if (wallPlant)
				{
					return;
				}
				bool flag = IsOnSurface();
				Rigidbody.useGravity = !flag;
				Rigidbody.isKinematic = flag;
				if (pointEnter)
				{
					return;
				}
				foreach (Outline outline in outlines)
				{
					if (outline.enabled)
					{
						outline.enabled = false;
					}
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
			if (MovementSystem.Instance.IsMoving())
			{
				singlePlantInfoUI.UpdateScore();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (!MovementSystem.Instance.IsMoving() && movable && !InputManager.Instance.gamePause)
			{
				MovementSystem.Instance.StartMovingTransform(base.transform, isCreated: false, this);
			}
		}

		public void StartMoving()
		{
			SetIsMoving(value: true);
			MovementSystem.Instance.TurnOnEnvironmentCollider();
			MovementSystem.Instance.SetObjectSo(objectSO, MoveId);
			if (!creativeMode)
			{
				PlantNeeds.Instance.Show(objectSO, variantIndex, this);
				PlantNeeds.Instance.UpdateVisual(sunlight, humidity);
				NewScoreUI.Instance.StartPlantMoving();
			}
		}

		public void StopMoving()
		{
			SetIsMoving(value: false);
			MovementSystem.Instance.TurnOffEnvironmentCollider();
			base.transform.SetParent(parent);
			MoveId = base.transform.position.x.ToString() + base.transform.position.y + base.transform.position.z;
			if (installationEffect.isActiveAndEnabled)
			{
				installationEffect.TurnOnStandByEffect();
			}
			ToggleOutline(pointEnter);
			CursorManager.Instance.SetActiveCursorType(pointEnter ? CursorManager.CursorType.Select : CursorManager.CursorType.Arrow);
			if (!creativeMode)
			{
				PlantNeeds.Instance.HideAnimation();
				NewScoreUI.Instance.StopPlantMoving();
			}
		}

		public void SetIsMoving(bool value)
		{
			canUpdateMaterial = value;
			if (!value)
			{
				Animate();
				StopAllCoroutines();
				StartCoroutine(WaitTillMoving());
				lastSurfaceToPlace = null;
			}
			else
			{
				isMoving = value;
			}
		}

		public string PassThroughItem()
		{
			return string.Empty;
		}

		public int GetScore()
		{
			CalculateScore();
			return score;
		}

		public int GetFinalScore()
		{
			return score;
		}

		public int GetStars()
		{
			int num = 0;
			if (humidity == objectSO.humidity)
			{
				num++;
			}
			if (sunlight == objectSO.sunlight)
			{
				num++;
			}
			if (BonusPoints() > 0)
			{
				num++;
			}
			return num;
		}

		public ObjectSO GetObjectSO()
		{
			return objectSO;
		}

		public Transform GetPlantTransform()
		{
			return plantTransform;
		}

		public bool GetHasVariant()
		{
			return hasVariant;
		}

		public int GetVariantIndex()
		{
			return variantIndex;
		}

		public int GetFloorPotIndex()
		{
			return floorPotIndex;
		}

		public int GetWallPotIndex()
		{
			return wallPotIndex;
		}

		public int GetID()
		{
			return ID;
		}

		public string GetGUID()
		{
			if (hasVariant)
			{
				return objectSO.variantsList[variantIndex].GUID;
			}
			return objectSO.GUID;
		}

		public bool IsWallPlant()
		{
			return wallPlant;
		}

		public bool CheckIfCanPlace()
		{
			return canPlace;
		}

		public Transform GetPlantVisual()
		{
			return plantVisual;
		}

		public SinglePlantInfoUI GetSinglePlantInfoUI()
		{
			return singlePlantInfoUI;
		}

		public Transform GetFloorPot()
		{
			return floorPot;
		}

		public Transform GetWallPot()
		{
			return wallPot;
		}

		public bool PlantHasBonusStar()
		{
			return BonusPoints() > 0;
		}

		private void CalculateScore()
		{
			int num = 0;
			if (objectSO.variantsList[variantIndex].rareLevel == PlantRareLevel.Uncommon)
			{
				num = 5;
			}
			if (objectSO.variantsList[variantIndex].rareLevel == PlantRareLevel.Rare)
			{
				num = 10;
			}
			score = objectSO.score + num;
			if (humidity == objectSO.humidity)
			{
				score += 5;
			}
			if (sunlight == objectSO.sunlight)
			{
				score += 5;
			}
			score += BonusPoints();
		}

		public void ToggleOutline(bool value)
		{
			if (!movable)
			{
				return;
			}
			foreach (Outline outline in outlines)
			{
				outline.enabled = value;
			}
		}

		public void SwitchMovement(bool turnOn)
		{
			cursor.cursorType = (turnOn ? CursorManager.CursorType.Select : CursorManager.CursorType.Arrow);
			singlePlantInfoUI.gameObject.SetActive(turnOn);
			movable = turnOn;
		}

		public void RightClickAction()
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.CreativeMode)
			{
				base.transform.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.transform.gameObject);
			}
		}

		public void ChangePot(bool plantOnWall, WorldOrientation orientation)
		{
			if (!plantOnWall || !IsOnSurface())
			{
				wallPlant = plantOnWall;
				wallPot.gameObject.SetActive(plantOnWall);
				floorPot.gameObject.SetActive(!plantOnWall);
				PlantVisualCheck(orientation);
			}
		}

		private void PlantVisualCheck(WorldOrientation orientation)
		{
			if (wallPlant)
			{
				float num = (float)((int)orientation * 90) - base.transform.rotation.y;
				float y = plantVisual.transform.eulerAngles.y;
				wallPot.transform.localRotation = Quaternion.Euler(-90f, 0f, num - y);
				plantVisual.transform.position = wallPot.GetChild(0).transform.position;
			}
			else
			{
				plantVisual.transform.position = floorPot.GetChild(0).transform.position;
			}
		}

		private void UpdateMaterials()
		{
			ToggleOutline(value: false);
			if (!canUpdateMaterial)
			{
				return;
			}
			Renderer[] array = plantTransformRenderers;
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
					Material material = (canPlace ? value[j] : transparentMaterialInstance);
					if (materials[j] != material)
					{
						materials[j] = material;
						flag = true;
					}
				}
				if (flag)
				{
					renderer.materials = materials;
				}
			}
			ToggleOutline(value: true);
			if (InputManager.Instance.gamePause)
			{
				ToggleOutline(value: false);
			}
		}

		private bool IsOnSurface()
		{
			return UnityEngine.Physics.OverlapSphereNonAlloc(base.transform.position, 0.03f, overlapResults, clearSurfaceToPlaceLayerMask) > 0;
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

		private IEnumerator WaitTillMoving()
		{
			yield return new WaitForSeconds(0.25f);
			isMoving = false;
		}

		private void Animate()
		{
			plantTransform.DOScale(0.9f, 0.05f).SetEase(Ease.InOutSine).OnComplete(delegate
			{
				plantTransform.DOScale(1.1f, 0.1f).SetEase(Ease.InOutSine).OnComplete(delegate
				{
					plantTransform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine);
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
			}
			if (other.TryGetComponent<EnvironmentSunlight>(out var _) && !isInnerSunlight)
			{
				if (sunlight == EnvironmentSunlight.Sunlight.Middle && other.GetComponent<EnvironmentSunlight>().sunlight == EnvironmentSunlight.Sunlight.Low)
				{
					return;
				}
				isCollidingSunlight = true;
				sunlight = other.GetComponent<EnvironmentSunlight>().sunlight;
				this.OnEnvironmentChanged?.Invoke(this, new OnEnvironmentChangedEventArgs
				{
					sunlight = sunlight,
					humidity = humidity
				});
				PlantNeeds.Instance.UpdateVisual(sunlight, humidity);
				if (other.CompareTag("InnerSunlight"))
				{
					isInnerSunlight = true;
				}
			}
			if (other.TryGetComponent<EnvironmentHumidity>(out var _) && !isInnerHumidity)
			{
				isCollidingHumidity = true;
				humidity = other.GetComponent<EnvironmentHumidity>().humidity;
				this.OnEnvironmentChanged?.Invoke(this, new OnEnvironmentChangedEventArgs
				{
					sunlight = sunlight,
					humidity = humidity
				});
				PlantNeeds.Instance.UpdateVisual(sunlight, humidity);
				if (other.CompareTag("InnerHumidity"))
				{
					isInnerHumidity = true;
				}
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
			}
			if (other.TryGetComponent<EnvironmentSunlight>(out var _))
			{
				isCollidingSunlight = false;
				sunlight = EnvironmentSunlight.Sunlight.Low;
				this.OnEnvironmentChanged?.Invoke(this, new OnEnvironmentChangedEventArgs
				{
					sunlight = sunlight,
					humidity = humidity
				});
				PlantNeeds.Instance.UpdateVisual(sunlight, humidity);
				if (other.CompareTag("InnerSunlight"))
				{
					isInnerSunlight = false;
				}
			}
			if (other.TryGetComponent<EnvironmentHumidity>(out var _))
			{
				isCollidingHumidity = false;
				humidity = EnvironmentHumidity.Humidity.Low;
				this.OnEnvironmentChanged?.Invoke(this, new OnEnvironmentChangedEventArgs
				{
					sunlight = sunlight,
					humidity = humidity
				});
				PlantNeeds.Instance.UpdateVisual(sunlight, humidity);
				if (other.CompareTag("InnerHumidity"))
				{
					isInnerHumidity = false;
				}
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (IsLayerInMask(other.gameObject.layer, interactableLayerMask) || IsLayerInMask(other.gameObject.layer, cantPlaceLayerMask))
			{
				canPlace = false;
				isColliding = true;
			}
			if (other.TryGetComponent<EnvironmentSunlight>(out var component) && !isCollidingSunlight)
			{
				isCollidingSunlight = true;
				sunlight = component.sunlight;
				this.OnEnvironmentChanged?.Invoke(this, new OnEnvironmentChangedEventArgs
				{
					sunlight = sunlight,
					humidity = humidity
				});
				PlantNeeds.Instance.UpdateVisual(sunlight, humidity);
			}
			if (other.TryGetComponent<EnvironmentHumidity>(out var component2) && !isCollidingHumidity)
			{
				isCollidingHumidity = true;
				humidity = component2.humidity;
				this.OnEnvironmentChanged?.Invoke(this, new OnEnvironmentChangedEventArgs
				{
					sunlight = sunlight,
					humidity = humidity
				});
				PlantNeeds.Instance.UpdateVisual(sunlight, humidity);
			}
		}

		private bool IsLayerInMask(int layer, LayerMask mask)
		{
			return ((int)mask & (1 << layer)) != 0;
		}

		private int BonusPoints()
		{
			int num = 0;
			foreach (Plant item2 in PlantsOnSceneCollection.Instance.collection)
			{
				if ((objectSO.friendPlant.Contains(item2.objectSO.objectName) || objectSO.friendSize == item2.plantSize) && Vector3.Distance(item2.transform.position, base.transform.position) <= 2f)
				{
					if (item2.MoveId == MoveId)
					{
						continue;
					}
					num += objectSO.addPoints;
				}
				if ((objectSO.enemyPlant.Contains(item2.objectSO.objectName) || objectSO.enemySize == item2.plantSize) && Vector3.Distance(item2.transform.position, base.transform.position) <= 2f && !(item2.MoveId == MoveId))
				{
					num -= objectSO.deductPoints;
				}
			}
			if (!MovementSystem.Instance.GetMovingPlant().success)
			{
				return num;
			}
			Plant item = MovementSystem.Instance.GetMovingPlant().plant;
			if (item.MoveId != MoveId)
			{
				if ((objectSO.friendPlant.Contains(item.objectSO.objectName) || objectSO.friendSize == item.plantSize) && Vector3.Distance(item.transform.position, base.transform.position) <= 2f)
				{
					num += objectSO.addPoints;
				}
				if ((objectSO.enemyPlant.Contains(item.objectSO.objectName) || objectSO.enemySize == item.plantSize) && Vector3.Distance(item.transform.position, base.transform.position) <= 2f)
				{
					num -= objectSO.deductPoints;
				}
			}
			return num;
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
			if (movable && !isMoving && !MovementSystem.Instance.IsMoving() && !InputManager.Instance.gamePause)
			{
				ToggleOutline(value: false);
			}
		}
	}
}
