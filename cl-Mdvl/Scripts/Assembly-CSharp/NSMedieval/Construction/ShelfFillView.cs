using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StorageUniversal;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using NSMedieval_Pooling;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class ShelfFillView : NSEipix.Base.View
	{
		[SerializeField]
		private List<Transform> shelfObjectTransforms;

		[SerializeField]
		private List<GameObject> shelfItemsForced;

		private readonly Dictionary<int, GameObject> shelfData = new Dictionary<int, GameObject>();

		public void Initialize(ShelfTransformSettings shelfTransformSettings)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(36, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\Stocketables\\ShelfFillView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Initializing TransformSettings for: ");
				messageBuilder.AppendFormatted(shelfTransformSettings.GetType());
			}
			Log.Debug(messageBuilder);
			TransformSettings[] transformSettingsArray = shelfTransformSettings.TransformSettingsArray;
			foreach (TransformSettings obj in transformSettingsArray)
			{
				Transform transform = GameObjectPool.GetDefaultEmpty().transform;
				transform.SetParent(base.transform, worldPositionStays: false);
				obj.ApplyToTransform(transform);
				shelfObjectTransforms.Add(transform);
			}
			for (int j = 0; j < shelfTransformSettings.ForcedItemsPrefabIds?.Length && j < shelfObjectTransforms.Count; j++)
			{
				GameObject gameObject = GameObjectPool.Get(shelfTransformSettings.ForcedItemsPrefabIds[j], returnActive: false);
				gameObject.transform.SetParent(shelfObjectTransforms[j], worldPositionStays: false);
				shelfItemsForced.Add(gameObject);
			}
		}

		public void Dispose()
		{
			for (int i = 0; i < shelfObjectTransforms.Count; i++)
			{
				DestroyStoredItem(i);
				GameObjectPool.Return(shelfObjectTransforms[i].gameObject);
			}
			shelfObjectTransforms.Clear();
			foreach (GameObject item in shelfItemsForced)
			{
				GameObjectPool.Return(item);
			}
			shelfItemsForced.Clear();
		}

		public int GetNumberOfSlots()
		{
			if (shelfItemsForced.Count > 0)
			{
				return shelfItemsForced.Count;
			}
			return shelfObjectTransforms.Count;
		}

		public void SetPilesOcclusionCulled(bool isCulled)
		{
			if (shelfData == null)
			{
				return;
			}
			foreach (GameObject value in shelfData.Values)
			{
				if (value == null)
				{
					continue;
				}
				HideResource component = value.GetComponent<HideResource>();
				if (component != null)
				{
					component.IsOcclusionCulled = isCulled;
					continue;
				}
				MeshRenderer component2 = value.GetComponent<MeshRenderer>();
				if (component2 != null)
				{
					component2.enabled = !isCulled;
				}
			}
		}

		public void SpawnObject(int index, StorageSlot storageSlot)
		{
			if (storageSlot?.Pile?.GetStoredResource() == null || index >= shelfObjectTransforms.Count)
			{
				return;
			}
			Transform transform = shelfObjectTransforms[index];
			if (shelfData.ContainsKey(index))
			{
				return;
			}
			GameObject forcedItem = GetForcedItem(index);
			ResourcePileInstance pile = storageSlot.Pile;
			if (forcedItem != null)
			{
				pile.DoNotCreateView = true;
				MonoSingleton<ResourcePileManager>.Instance.SpawnPile(pile);
				forcedItem.SetActive(value: true);
				shelfData.Add(index, forcedItem);
				return;
			}
			ResourcePileView view = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(pile);
			if (!(view != null))
			{
				return;
			}
			view.ResetMeshTransform();
			view.transform.SetParent(transform.transform, worldPositionStays: false);
			shelfData.Add(index, view.gameObject);
			HideResource hideResource = view.GetComponent<HideResource>();
			if (!(hideResource != null))
			{
				return;
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				if (view != null)
				{
					RemoveExcessComponents(view.gameObject);
				}
				if (!(hideResource == null))
				{
					hideResource.SetElevationOnShelf(pile.GridDataPosition.y);
					hideResource.TryForceHide(MonoSingleton<World>.Instance.LayerLevel);
				}
			});
		}

		public void RemoveObject(int index, StorageSlot storageSlot)
		{
			ResourceInstance resourceInstance = storageSlot?.Pile?.GetStoredResource();
			if (resourceInstance != null && resourceInstance.Amount > 0)
			{
				Log.Debug("resourceInstance is null", "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\Stocketables\\ShelfFillView.cs");
			}
			else if (index < shelfObjectTransforms.Count)
			{
				DestroyStoredItem(index);
			}
		}

		private void DestroyStoredItem(int index)
		{
			if (!shelfData.ContainsKey(index))
			{
				return;
			}
			GameObject gameObject = shelfData[index];
			shelfData.Remove(index);
			if (gameObject != null)
			{
				if (shelfItemsForced.Contains(gameObject))
				{
					gameObject.SetActive(value: false);
				}
				else
				{
					Object.Destroy(gameObject);
				}
			}
		}

		private GameObject GetForcedItem(int index)
		{
			if (shelfItemsForced != null && shelfItemsForced.Count > 0 && index >= 0 && index < shelfItemsForced.Count)
			{
				return shelfItemsForced[index];
			}
			return null;
		}

		private Transform GetTransform(int index)
		{
			if (shelfItemsForced != null && shelfItemsForced.Count > 0 && index >= 0 && index < shelfItemsForced.Count)
			{
				return shelfItemsForced[index].transform;
			}
			return shelfObjectTransforms[index];
		}

		public static void RemoveExcessComponents(GameObject target, bool resetEulerAngles = true)
		{
			Component[] components = target.GetComponents<Component>();
			foreach (Component component in components)
			{
				if (component is NSEipix.Base.View)
				{
					if (component is EquipmentPileView equipmentPileView)
					{
						equipmentPileView.DetachAllEvents();
					}
					if (component is ResourcePileView resourcePileView)
					{
						resourcePileView.DetachAllEvents();
					}
					Object.Destroy(component);
				}
				if (component is Collider)
				{
					Object.Destroy(component);
				}
			}
			ClickDetection component2 = target.GetComponent<ClickDetection>();
			if (component2 != null)
			{
				Object.Destroy(component2);
			}
			Transform[] componentsInChildren = target.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if (resetEulerAngles)
				{
					transform.localEulerAngles = Vector3.zero;
				}
				transform.localPosition = Vector3.zero;
				transform.localScale = new Vector3(1f, 1f, 1f);
				if (transform.gameObject.name.StartsWith("item_pile_mark"))
				{
					Object.Destroy(transform.gameObject);
				}
			}
			Collider[] componentsInChildren2 = target.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren2.Length; i++)
			{
				Object.Destroy(componentsInChildren2[i]);
			}
		}

		public void OnPileDurabilityDepleted(int index)
		{
			RemoveObject(index, null);
		}
	}
}
