using System;
using System.Collections;
using System.Collections.Generic;
using Mandragora.PWS;
using Restory.Data.Devices.Condition;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.GameWarnings;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Quests;
using Restory.Gameplay.Soldering;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.Workplace;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class ElementService : MonoBehaviour
	{
		private struct PendingDirtyCondition
		{
			public ElementData ElementData;

			public ElementConditionHandler ConditionHandler;

			public PendingDirtyCondition(ElementData elementData, ElementConditionHandler conditionHandler)
			{
				ElementData = elementData;
				ConditionHandler = conditionHandler;
			}
		}

		[SerializeField]
		private ElementDirtMaskCreationRestrictions maskGenerationRestrictions;

		private ElementFactory elementFactory;

		private ElementPlacementController placementController;

		private WorkSurface workSurface;

		private IInventory inventory;

		private InventoryBox inventoryBox;

		private TextureSaveLoadService textureSaveLoadService;

		private TextureCacheService textureCacheService;

		private TextureMaskCreationService textureMaskCreator;

		private ElementDirtMaskPresetSelectionService elementDirtMaskPresetSelectionService;

		private CleanColorCalculator cleanColorCalculator;

		private GameWarningDatabase gameWarningDatabase;

		private GameWarningService gameWarningService;

		private BurntTraceGenerator burntTraceGenerator;

		private MaskPresetInfoBase defaultMaskPreset;

		private Coroutine placementCoroutine;

		private Coroutine dirtyConditionsBatchCoroutine;

		private readonly Queue<PendingDirtyCondition> pendingDirtyConditions = new Queue<PendingDirtyCondition>();

		public bool IsPlacementProcess => placementCoroutine != null;

		public event Action<IReadOnlyStorageSlot> OnItemReadyToDrop;

		public event Action OnPostDrop;

		[Inject]
		public void Construct(ElementFactory elementFactory, ElementPlacementController placementController, WorkSurface workSurface, IInventory inventory, InventoryBox inventoryBox, TextureSaveLoadService textureSaveLoadService, TextureCacheService textureCacheService, TextureMaskCreationService textureMaskCreator, ElementDirtMaskPresetSelectionService elementDirtMaskPresetSelectionService, GameWarningDatabase gameWarningDatabase, GameWarningService gameWarningService, CleanColorCalculator cleanColorCalculator, BurntTraceGenerator burntTraceGenerator, [Inject(Id = "DefaultMaskPreset")] MaskPresetInfoBase defaultMaskPreset)
		{
			this.elementFactory = elementFactory;
			this.placementController = placementController;
			this.workSurface = workSurface;
			this.inventory = inventory;
			this.inventoryBox = inventoryBox;
			this.textureSaveLoadService = textureSaveLoadService;
			this.textureCacheService = textureCacheService;
			this.textureMaskCreator = textureMaskCreator;
			this.cleanColorCalculator = cleanColorCalculator;
			this.elementDirtMaskPresetSelectionService = elementDirtMaskPresetSelectionService;
			this.gameWarningDatabase = gameWarningDatabase;
			this.gameWarningService = gameWarningService;
			this.burntTraceGenerator = burntTraceGenerator;
			this.defaultMaskPreset = defaultMaskPreset;
		}

		public ElementBase CreateElement(ElementData elementData)
		{
			ElementBase elementBase = elementFactory.CreateElement(elementData.Info.Prefab, workSurface.DefaultPlacementPosition);
			ApplyElementCondition(elementBase, elementData, async: false);
			return elementBase;
		}

		public ElementBase CreateElementOnSurface(ElementData elementData)
		{
			ElementBase elementBase = CreateElement(elementData);
			workSurface.AddElement(elementBase);
			elementBase.SkipProgress();
			return elementBase;
		}

		public QuestItem CreateQuestItem(QuestItemInfo questItemInfo, Transform parent)
		{
			QuestItem obj = (elementFactory.CreateElement(questItemInfo.Prefab, parent.position) as QuestItem) ?? throw new InvalidOperationException(questItemInfo.ID + " does not provide QuestItem prefab");
			obj.transform.SetParent(parent);
			return obj;
		}

		public void DestroyElement(ElementBase element)
		{
			workSurface.RemoveElement(element);
			elementFactory.DestroyElement(element);
		}

		public void DropItemsFromStorage(IEnumerable<IReadOnlyStorageSlot> slots)
		{
			if (placementCoroutine == null)
			{
				placementCoroutine = StartCoroutine(DropItemsRoutine(slots));
			}
		}

		public bool TrySendItemToStorage(ElementBase element)
		{
			if (element.ConditionHandler.ElementData.Condition is DamagedElementCondition)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.BrokenElementWarning);
				return false;
			}
			if (element is QuestItem)
			{
				return false;
			}
			if (!element.Info)
			{
				Debug.LogError($"Element {element.name} has no {typeof(ElementInfo)} attached");
				return false;
			}
			ElementData elementData = element.ConditionHandler.ElementData;
			StorageItemElement item = new StorageItemElement(elementData);
			if (inventory.StorageElements.AddItem(item) != 0)
			{
				Debug.LogError("Failed send " + elementData.Info.ID + " item to inventory");
				return false;
			}
			inventoryBox.HandleItemAdded();
			DestroyElement(element);
			return true;
		}

		public void ApplyElementCondition(ElementBase element, ElementData elementData, bool async)
		{
			ElementConditionBase condition = elementData.Condition;
			if (!(condition is PerfectElementCondition))
			{
				if (!(condition is DamagedElementCondition))
				{
					if (!(condition is DirtyElementCondition))
					{
						throw new NotImplementedException();
					}
					if (async)
					{
						ApplyDirtyConditionAsync(elementData, element.ConditionHandler);
					}
					else
					{
						ApplyDirtyCondition(elementData, element.ConditionHandler);
					}
				}
				else
				{
					element.ConditionHandler.InitCondition(elementData);
				}
			}
			else
			{
				element.ConditionHandler.InitCondition(elementData);
			}
		}

		public ElementData[] CreateElementsData(IDeviceCondition deviceCondition)
		{
			IReadOnlyCollection<ElementSocket> sockets = deviceCondition.DeviceInfo.Sockets;
			List<ElementData> list = new List<ElementData>();
			List<ElementData> elementsCondition = deviceCondition.GetElementsCondition();
			byte[] customTexture = ((deviceCondition is DeviceCondition deviceCondition2 && (bool)deviceCondition2.CustomDirtMaskTexture) ? textureSaveLoadService.ConvertTextureToData(deviceCondition2.CustomDirtMaskTexture) : null);
			foreach (ElementSocket item in sockets)
			{
				ElementData elementData = null;
				for (int i = 0; i < elementsCondition.Count; i++)
				{
					if (elementsCondition[i].Info == item.CompatibleElementInfo)
					{
						elementData = elementsCondition[i];
						elementsCondition.RemoveAt(i);
						break;
					}
				}
				if (elementData == null)
				{
					if (item.CompatibleElementInfo.Category != ElementCategory.Small)
					{
						Debug.LogError(item.CompatibleElementInfo.ID + " socket is empty in " + deviceCondition.ID);
					}
					elementData = new ElementData
					{
						Info = item.CompatibleElementInfo
					};
				}
				if (elementData.Condition is DirtyElementCondition)
				{
					InitDirtyElementData(elementData, deviceCondition, customTexture);
				}
				list.Add(elementData);
			}
			foreach (ElementData item2 in elementsCondition)
			{
				if (item2.Info is QuestItemInfo)
				{
					list.Add(item2);
				}
				else
				{
					Debug.LogError("elementsCondition contains extra entry " + item2.Info.ID);
				}
			}
			return list.ToArray();
		}

		public void ApplyScorchedCircuitProperty(ElementData elementData)
		{
			if (elementData.AdditionalProperty != null && !(elementData.AdditionalProperty is ScorchedCircuitProperty))
			{
				Debug.LogError("Failed to apply ScorchedCircuitProperty to " + elementData.Info.ID + "," + $" it has already {elementData.AdditionalProperty.GetType()} applied");
				return;
			}
			ContactLinesHandler componentInChildren = elementData.Info.Prefab.GetComponentInChildren<ContactLinesHandler>();
			if (!componentInChildren)
			{
				Debug.LogError("Failed to find ContactLinesHandler in " + elementData.Info.ID + " prefab");
				return;
			}
			ContactLine[] contactLines = componentInChildren.GetContactLines();
			if (contactLines.Length == 0)
			{
				Debug.LogError("contactLines collection is empty in ContactLinesHandler of " + elementData.Info.ID + " prefab");
				return;
			}
			List<BurntTraceData> list = burntTraceGenerator.GenerateBurntTraces(contactLines);
			if (list.Count == 0)
			{
				Debug.LogError("All items in contactLines collection not valid");
				return;
			}
			int num = 0;
			foreach (BurntTraceData item in list)
			{
				num += item.SolderPoints.Count;
			}
			ScorchedCircuitProperty additionalProperty = new ScorchedCircuitProperty
			{
				InitialBurntPointsCount = num,
				BurntTraces = list
			};
			elementData.AdditionalProperty = additionalProperty;
		}

		private IEnumerator DropItemsRoutine(IEnumerable<IReadOnlyStorageSlot> slots)
		{
			placementController.LastPlacementHit = default(RaycastHit);
			float rotationAngle = 0f;
			foreach (IReadOnlyStorageSlot slot in slots)
			{
				if (!TryCreateAndDropElement(slot, rotationAngle, out var element))
				{
					break;
				}
				rotationAngle = UnityEngine.Random.Range(0f, 360f);
				yield return null;
				element.Activate();
				element = null;
			}
			this.OnPostDrop?.Invoke();
			placementController.Clear();
			placementCoroutine = null;
		}

		private bool TryCreateAndDropElement(IReadOnlyStorageSlot slot, float rotationAngle, out ElementBase element)
		{
			if (!(slot.Item is StorageItemElement storageItemElement))
			{
				element = null;
				return false;
			}
			ElementData elementData = storageItemElement.ElementData.Clone();
			element = CreateElement(elementData);
			placementController.SetTargetElement(element);
			Quaternion quaternion = Quaternion.Euler(0f, 0f, rotationAngle);
			if (placementController.TryFindAvailablePlacementPosition(quaternion))
			{
				workSurface.AddElement(element);
				this.OnItemReadyToDrop?.Invoke(slot);
				placementController.SetPlacementPosition();
				element.transform.rotation *= quaternion;
				element.BehaviorSwitcher.SwitchToPlacedBehavior();
				element.ConditionHandler.ElementData.IsInspected = true;
				return true;
			}
			Debug.LogWarning("Failed to place new element " + elementData.Info.ID);
			UnityEngine.Object.Destroy(element.gameObject);
			element = null;
			return false;
		}

		private void ApplyDirtyConditionAsync(ElementData elementData, ElementConditionHandler conditionHandler)
		{
			if (!(elementData.Condition is DirtyElementCondition))
			{
				Debug.LogError("Condition is not dirty on ApplyDirtyCondition");
				return;
			}
			pendingDirtyConditions.Enqueue(new PendingDirtyCondition(elementData, conditionHandler));
			if (dirtyConditionsBatchCoroutine == null)
			{
				dirtyConditionsBatchCoroutine = StartCoroutine(ProcessDirtyConditionsBatch());
			}
		}

		private void ApplyDirtyCondition(ElementData elementData, ElementConditionHandler conditionHandler)
		{
			byte[] textureData;
			if (!(elementData.Condition is DirtyElementCondition))
			{
				Debug.LogError("Condition is not dirty on ApplyDirtyCondition");
			}
			else if (elementData.DirtMaskTextureId > 0 && textureCacheService.TryGetTextureData(elementData.DirtMaskTextureId, out textureData))
			{
				Texture2D restoredTexture = textureSaveLoadService.ConvertDataToTexture(textureData, TextureFormat.RGBA32, isTargetTextureLinear: false);
				conditionHandler.RestoreCondition(elementData, restoredTexture);
			}
			else
			{
				conditionHandler.InitCondition(elementData);
				GenerateDirtMaskForElement(elementData, conditionHandler);
			}
		}

		private void GenerateDirtMaskForElement(ElementData elementData, ElementConditionHandler conditionHandler)
		{
			Mesh sharedMesh = conditionHandler.TextureMaskHolder.SharedMesh;
			MeshUVProcessor.ProcessingSettings processingSettings = new MeshUVProcessor.ProcessingSettings
			{
				enableDebugOutput = false,
				enableWireframe = true,
				wireThickness = 0.5f,
				wrapUV = false
			};
			Texture2D workTexture = conditionHandler.TextureMaskHolder.WorkTexture;
			GenerateTextureMask(elementData.NoiseSeed, conditionHandler, workTexture, elementData.DirtMaskPresetOverride, sharedMesh, processingSettings, out var pixelsOnMeshCount, out var dirtyPixels);
			ValidateTextureMaskAndRepeatGenerationIfNeeded(elementData, conditionHandler, elementData.DirtMaskPresetOverride, dirtyPixels, pixelsOnMeshCount, workTexture, sharedMesh, processingSettings);
		}

		private void ValidateTextureMaskAndRepeatGenerationIfNeeded(ElementData elementData, ElementConditionHandler conditionHandler, MaskPresetInfoBase maskCreatorPreset, DirtyPixelsCount dirtyPixels, int pixelsOnMeshCount, Texture2D workTexture, Mesh sharedMesh, MeshUVProcessor.ProcessingSettings processingSettings)
		{
			if (maskCreatorPreset.IsInDebugMode)
			{
				return;
			}
			int i;
			for (i = 0; i < maskGenerationRestrictions.MaxGenerationAttempts; i++)
			{
				if (IsDirtyTextureGenerationAcceptable(dirtyPixels, pixelsOnMeshCount, maskCreatorPreset))
				{
					break;
				}
				if (i == 0)
				{
					Debug.LogError($"Failed to use proven or debug noise seed {elementData.NoiseSeed}" + " with preset " + maskCreatorPreset.ID + " on element " + elementData.Info.ID + ". Started loop of noise loop regenerating iterations.");
				}
				Debug.Log("[ElementService] generated dirt mask texture for element '" + elementData.Info.ID + "', but the amount of generated dirtied pixels was too small, trying to generate again!Previous attempt get the following dirt pixels percentages from total pixels in mesh: " + $"DUST - '{(float)dirtyPixels.R / (float)pixelsOnMeshCount * 100f}%', " + $"DIRT - '{(float)dirtyPixels.G / (float)pixelsOnMeshCount * 100f}%', " + $"RUST - '{(float)dirtyPixels.B / (float)pixelsOnMeshCount * 100f}%'");
				elementData.NoiseSeed = textureMaskCreator.GetRandomOrDebugNoiseSeed(maskCreatorPreset);
				conditionHandler.TextureMaskHolder.ResetPreInitializationDirtyPixels();
				GenerateTextureMask(elementData.NoiseSeed, conditionHandler, workTexture, maskCreatorPreset, sharedMesh, processingSettings, out pixelsOnMeshCount, out dirtyPixels);
			}
			if (i >= maskGenerationRestrictions.MaxGenerationAttempts && !IsDirtyTextureGenerationAcceptable(dirtyPixels, pixelsOnMeshCount, maskCreatorPreset))
			{
				Debug.LogError("[ElementService] tried to generate dirt mask texture for element '" + elementData.Info.ID + "', but exceeded the allowed amount of attempts and got the following dirt pixels percentages from total pixels in mesh: " + $"DUST - '{(float)dirtyPixels.R / (float)pixelsOnMeshCount * 100f}%', " + $"DIRT - '{(float)dirtyPixels.G / (float)pixelsOnMeshCount * 100f}%', " + $"RUST - '{(float)dirtyPixels.B / (float)pixelsOnMeshCount * 100f}%'");
			}
		}

		private void GenerateTextureMask(float noiseSeed, ElementConditionHandler conditionHandler, Texture2D workTexture, MaskPresetInfoBase maskCreatorPreset, Mesh sharedMesh, MeshUVProcessor.ProcessingSettings processingSettings, out int pixelsOnMeshCount, out DirtyPixelsCount dirtyPixels)
		{
			textureMaskCreator.CreateTextureMaskWithMesh(workTexture, maskCreatorPreset, sharedMesh, processingSettings, noiseSeed, out pixelsOnMeshCount);
			conditionHandler.TextureMaskHolder.SetTotalPixelsInMeshCount(pixelsOnMeshCount);
			cleanColorCalculator.CalculateProgress(conditionHandler.TextureMaskHolder);
			dirtyPixels = conditionHandler.TextureMaskHolder.GetInitialDirtyPixelsCount();
		}

		private IEnumerator ProcessDirtyConditionsBatch()
		{
			yield return new WaitForEndOfFrame();
			while (pendingDirtyConditions.Count > 0)
			{
				PendingDirtyCondition pendingDirtyCondition = pendingDirtyConditions.Dequeue();
				ApplyDirtyCondition(pendingDirtyCondition.ElementData, pendingDirtyCondition.ConditionHandler);
			}
			dirtyConditionsBatchCoroutine = null;
		}

		private void InitDirtyElementData(ElementData elementData, IDeviceCondition deviceCondition, byte[] customTexture)
		{
			switch (elementData.DirtTextureOption)
			{
			case TextureUsageOptions.UseCustomTexture:
				if (customTexture != null)
				{
					Debug.LogError("[ElementService] tried to initialize element with a custom texture, but this feature is not supported currently!");
					textureCacheService.CacheTextureData(elementData, customTexture);
					break;
				}
				goto default;
			case TextureUsageOptions.UseGeneratedTexture:
			{
				elementData.NoiseSeed = textureMaskCreator.GetRandomOrDebugNoiseSeed(deviceCondition.DirtMaskGenerationPreset, elementData.Info);
				elementData.DirtMaskPresetOverride = (elementData.DirtMaskPresetOverride ? elementData.DirtMaskPresetOverride : (elementDirtMaskPresetSelectionService.TryToGetDirtMaskCreationPreset(elementData.Info.ElementMaterialType, out var preset) ? preset : defaultMaskPreset));
				elementData.DirtMaskTextureSize = deviceCondition.DeviceInfo.GeneratedDirtMaskTextureSize;
				if (elementData.DirtMaskPresetOverride is ScorchedCircuitPresetInfo)
				{
					ApplyScorchedCircuitProperty(elementData);
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
		}

		private bool IsDirtyTextureGenerationAcceptable(DirtyPixelsCount dirtyPixelsCount, int pixelsOnMeshCount, MaskPresetInfoBase maskCreatorPreset)
		{
			MaskPresetInfoBase maskPresetInfoBase = (maskCreatorPreset ? maskCreatorPreset : defaultMaskPreset);
			if ((maskPresetInfoBase.RedChannel.MaxColorValueClamp <= 0f || IsChannelPixelsInAcceptableRange(dirtyPixelsCount.R, pixelsOnMeshCount)) && (maskPresetInfoBase.GreenChannel.MaxColorValueClamp <= 0f || IsChannelPixelsInAcceptableRange(dirtyPixelsCount.G, pixelsOnMeshCount)))
			{
				if (!(maskPresetInfoBase.BlueChannel.MaxColorValueClamp <= 0f))
				{
					return IsChannelPixelsInAcceptableRange(dirtyPixelsCount.B, pixelsOnMeshCount);
				}
				return true;
			}
			return false;
		}

		private bool IsChannelPixelsInAcceptableRange(int channelPixelsCount, int pixelsOnMeshCount)
		{
			if (channelPixelsCount > 0)
			{
				return !((float)channelPixelsCount / (float)pixelsOnMeshCount < maskGenerationRestrictions.MinDirtyPixelsToTotalPixelsInMeshRatio);
			}
			return true;
		}
	}
}
