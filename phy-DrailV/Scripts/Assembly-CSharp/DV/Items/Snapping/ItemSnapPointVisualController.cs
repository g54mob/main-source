using DV.CabControls;
using UnityEngine;

namespace DV.Items.Snapping
{
	public class ItemSnapPointVisualController : MonoBehaviour
	{
		[SerializeField]
		private GameObject visualsParent;

		[SerializeField]
		private GameObject directionGuide;

		[SerializeField]
		private GameObject mainVisuals;

		[SerializeField]
		private Color[] validColors;

		[SerializeField]
		private Color[] invalidColors;

		[SerializeField]
		private Material ghostMaterial;

		private ItemSnapPointBelt snapPoint;

		private ItemSnapPointInteractionBelt interactionBelt;

		private ControllerPointerDetectorBelt controllerPointerDetector;

		private Renderer[] highlightDirectionGuideRenderers;

		private Renderer highlightSphereRenderer;

		public bool grabbed;

		private GameObject itemGhost;

		private static readonly int shaderColor = Shader.PropertyToID("_Color");

		private static readonly int shaderTintColor = Shader.PropertyToID("_TintColor");

		private static readonly int shaderFadeColor = Shader.PropertyToID("_FadeColor");

		private void Awake()
		{
			snapPoint = GetComponentInParent<ItemSnapPointBelt>();
			if (snapPoint == null)
			{
				Debug.LogError("Missing ItemSnapPointBase reference. ItemSnapPointBase destroying self.", base.gameObject);
				Object.Destroy(this);
				return;
			}
			controllerPointerDetector = GetComponent<ControllerPointerDetectorBelt>();
			if (controllerPointerDetector == null)
			{
				Debug.LogError("Missing ControllerPointerDetectorBelt reference. ControllerPointerDetectorBelt destroying self.", base.gameObject);
				Object.Destroy(this);
				return;
			}
			interactionBelt = GetComponentInParent<ItemSnapPointInteractionBelt>();
			if (interactionBelt == null)
			{
				Debug.LogError("Missing ItemSnapPointInteractionBelt reference. ItemSnapPointInteractionBelt destroying self.", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				highlightDirectionGuideRenderers = directionGuide.GetComponentsInChildren<Renderer>(includeInactive: true);
				highlightSphereRenderer = mainVisuals.GetComponent<Renderer>();
				SetupListeners(on: true);
			}
		}

		private void SetupListeners(bool on)
		{
			if (snapPoint != null)
			{
				snapPoint.ItemSnappedChanged -= OnItemSnappedChanged;
				snapPoint.ReservedChanged -= OnReservedChanged;
			}
			if (on && snapPoint != null)
			{
				snapPoint.ItemSnappedChanged += OnItemSnappedChanged;
				snapPoint.ReservedChanged += OnReservedChanged;
			}
		}

		private void OnReservedChanged(ItemSnapPointBelt _, ItemBase previouslyReservedFor, ItemBase reservedFor)
		{
			if (itemGhost != null)
			{
				Object.Destroy(itemGhost);
			}
			if (snapPoint.SnappedItem == null && reservedFor != null)
			{
				InstantiateGhost(reservedFor);
			}
			controllerPointerDetector.reservedItem = reservedFor;
		}

		private void OnItemSnappedChanged(ItemSnapPointBase _, ItemBase item, bool snapped, bool forced)
		{
			if (itemGhost != null)
			{
				Object.Destroy(itemGhost);
			}
			itemGhost = null;
			controllerPointerDetector.reservedItem = snapPoint.ReservedItem;
			if (!snapped && (!(snapPoint.ReservedItem == null) || !(item != snapPoint.ReservedItem)))
			{
				InstantiateGhost(item);
			}
		}

		private void InstantiateGhost(ItemBase item)
		{
			itemGhost = Object.Instantiate(item.InventorySpecs.PreviewPrefab, snapPoint.transform, worldPositionStays: false);
			var (position, rotation) = snapPoint.CalculateWorldEndPose(item);
			itemGhost.transform.SetPositionAndRotation(position, rotation);
			Renderer[] componentsInChildren = itemGhost.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material = ghostMaterial;
			}
			Page componentInChildren = item.GetComponentInChildren<Page>(includeInactive: true);
			Transform transform = ((componentInChildren != null) ? componentInChildren.transform : item.transform.Find("Paper"));
			if (!(transform == null))
			{
				Vector3 localScale = transform.localScale;
				localScale.y = 1f;
				itemGhost.transform.localScale = localScale;
			}
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void UpdateVisualRepresentation()
		{
			if (!(visualsParent == null))
			{
				bool flag;
				bool enable;
				if (grabbed)
				{
					flag = (enable = true);
				}
				else
				{
					bool flag2 = interactionBelt.NearbyFreePipa || interactionBelt.NearbyGrabbedAdjuster || (interactionBelt.NearbySnappable && snapPoint.SnappedItem == null);
					bool flag3 = controllerPointerDetector.IsProperlyTouched();
					flag = !flag3 && flag2;
					enable = flag || flag3;
					bool valid = flag3 || !controllerPointerDetector.WarnImproperTouch();
					ToggleColor(valid);
				}
				visualsParent.SetActive(flag);
				if (itemGhost != null)
				{
					itemGhost.SetActive(flag);
				}
				controllerPointerDetector.EnableTriggers(enable);
			}
		}

		private void LateUpdate()
		{
			UpdateVisualRepresentation();
		}

		public void ToggleColor(bool valid)
		{
			Renderer[] array;
			if (valid)
			{
				if (highlightSphereRenderer != null)
				{
					highlightSphereRenderer.material.SetColor(shaderColor, validColors[0]);
				}
				array = highlightDirectionGuideRenderers;
				foreach (Renderer renderer in array)
				{
					if (!(renderer == null))
					{
						renderer.material.SetColor(shaderTintColor, validColors[1]);
						renderer.material.SetColor(shaderFadeColor, validColors[1]);
					}
				}
				return;
			}
			if (highlightSphereRenderer != null)
			{
				highlightSphereRenderer.material.SetColor(shaderColor, invalidColors[0]);
			}
			array = highlightDirectionGuideRenderers;
			foreach (Renderer renderer2 in array)
			{
				if (!(renderer2 == null))
				{
					renderer2.material.SetColor(shaderTintColor, invalidColors[1]);
					renderer2.material.SetColor(shaderFadeColor, invalidColors[1]);
				}
			}
		}

		public void UpdateDirectionGuideVisibility(bool on)
		{
			controllerPointerDetector.UpdateDirectionGuideVisibility(on);
		}
	}
}
