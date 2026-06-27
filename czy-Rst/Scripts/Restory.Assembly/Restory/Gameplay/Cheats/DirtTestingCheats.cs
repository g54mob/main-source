using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Mandragora.PWS;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.Elements.Condition;
using Restory.Data.Elements.ElementTypes;
using Restory.Gameplay.Cleaning;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.Soldering;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.UserInterface;
using Restory.Gameplay.Workplace;
using Restory.StorageSystem;
using Restory.StorageSystem.StorageElements;
using Restory.Utils;
using SRDebugger.Services;
using SRDebugger.Services.Implementation;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class DirtTestingCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private const string COMMON_CATEGORY = "Testing dirt on elements";

		private const string SELECTED_DIRT_MASK_PRESET_NAME = "               Selected Dirt Mask Preset               ";

		private const string SELECTED_ELEMENT_NAME = "                         Selected Element                         ";

		private ElementDirtMaskPresetSelectionService dirtMaskPresetSelector;

		private ApplicationQuitDetectionService applicationQuitDetectionService;

		private TextureMaskCreationService textureMaskCreator;

		private CleanColorCalculator cleanColorCalculator;

		private DeviceService deviceService;

		private ElementService elementService;

		private WorkSurface workSurface;

		private Restory.Gameplay.Inventory.Inventory inventory;

		private DefaultElementConditions defaultElementConditions;

		private DebugPanelServiceImpl debugPanelService;

		private int selectedPresetLineLength;

		private int selectedElementLineLength;

		private readonly List<MaskPresetInfoBase> applicablePresets = new List<MaskPresetInfoBase>();

		private readonly List<ElementBase> elementsList = new List<ElementBase>();

		private ElementBase selectedElement;

		private MaskPresetInfoBase selectedPreset;

		private ElementCleaner elementCleaner;

		private GUI_ElementCleanerPanel elementCleanerPanel;

		[Category("Testing dirt on elements")]
		[DisplayName("                         Selected Element                         ")]
		[SROptions.Sort(1)]
		public string SelectedElementName
		{
			get
			{
				string text = ((!deviceService.PlacedDeviceContainer) ? "No device on the table" : ((elementsList.Count <= 0) ? "No elements to select from" : (selectedElement ? selectedElement.Info.ID : "No element selected")));
				StringBuilder stringBuilder = new StringBuilder();
				int num = selectedElementLineLength - text.Length;
				if (num > 0)
				{
					int num2 = num / 2;
					for (int i = 0; i < num2; i++)
					{
						stringBuilder.Append(" ");
					}
				}
				stringBuilder.Append(text);
				return stringBuilder.ToString();
			}
		}

		[Category("Testing dirt on elements")]
		[DisplayName("Lock Selection")]
		[SROptions.Sort(2)]
		public bool LockElementSelection { get; set; }

		[Category("Testing dirt on elements")]
		[DisplayName("               Selected Dirt Mask Preset               ")]
		[SROptions.Sort(6)]
		public string SelectedPresetName
		{
			get
			{
				string text = ((!selectedElement) ? "No element selected" : ((applicablePresets.Count <= 0) ? "No applicable presets" : (selectedPreset ? selectedPreset.ID : "No preset selected")));
				StringBuilder stringBuilder = new StringBuilder();
				int num = selectedPresetLineLength - text.Length;
				if (num > 0)
				{
					int num2 = num / 2;
					for (int i = 0; i < num2; i++)
					{
						stringBuilder.Append(" ");
					}
				}
				stringBuilder.Append(text);
				return stringBuilder.ToString();
			}
		}

		[Category("Testing dirt on elements")]
		[DisplayName("Lock Selection")]
		[SROptions.Sort(7)]
		public bool LockPresetSelection { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		[Inject]
		public DirtTestingCheats(ElementDirtMaskPresetSelectionService dirtMaskPresetSelector, ApplicationQuitDetectionService applicationQuitDetectionService, TextureMaskCreationService textureMaskCreator, CleanColorCalculator cleanColorCalculator, ElementCleaner elementCleaner, GUI_ElementCleanerPanel elementCleanerPanel, DeviceService deviceService, ElementService elementService, WorkSurface workSurface, Restory.Gameplay.Inventory.Inventory inventory, DefaultElementConditions defaultElementConditions, DebugPanelServiceImpl debugPanelService)
		{
			this.debugPanelService = debugPanelService;
			this.elementCleanerPanel = elementCleanerPanel;
			this.elementCleaner = elementCleaner;
			this.elementService = elementService;
			this.workSurface = workSurface;
			this.inventory = inventory;
			this.deviceService = deviceService;
			this.textureMaskCreator = textureMaskCreator;
			this.applicationQuitDetectionService = applicationQuitDetectionService;
			this.dirtMaskPresetSelector = dirtMaskPresetSelector;
			this.cleanColorCalculator = cleanColorCalculator;
			this.defaultElementConditions = defaultElementConditions;
		}

		protected override void Init()
		{
			base.Init();
			debugPanelService.VisibilityChanged += OnPanelVisibilityChanged;
			selectedPresetLineLength = "               Selected Dirt Mask Preset               ".Length;
			selectedElementLineLength = "                         Selected Element                         ".Length;
		}

		protected override void CleanUp()
		{
			if ((bool)debugPanelService)
			{
				debugPanelService.VisibilityChanged -= OnPanelVisibilityChanged;
			}
			Clear();
			base.CleanUp();
		}

		[Category("Testing dirt on elements")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleElementLeft()
		{
			SwitchElementSelection(-1);
		}

		[Category("Testing dirt on elements")]
		[DisplayName(">")]
		[SROptions.Sort(4)]
		public void CycleElementRight()
		{
			SwitchElementSelection(1);
		}

		[Category("Testing dirt on elements")]
		[DisplayName("<")]
		[SROptions.Sort(5)]
		public void CycleDirtPresetLeft()
		{
			SwitchDirtPreset(-1);
		}

		[Category("Testing dirt on elements")]
		[DisplayName(">")]
		[SROptions.Sort(8)]
		public void CycleDirtPresetRight()
		{
			SwitchDirtPreset(1);
		}

		[Category("Testing dirt on elements")]
		[DisplayName("Generate Dirt On Element")]
		[SROptions.Sort(10)]
		public void GenerateDirtOnElement()
		{
			if ((bool)deviceService.PlacedDeviceContainer && (bool)selectedElement && (bool)selectedPreset)
			{
				if (selectedElement.ConditionHandler.ElementData.Condition is DirtyElementCondition)
				{
					GenerateNewDirtTexture();
					return;
				}
				ElementData elementData = new ElementData
				{
					Info = selectedElement.Info,
					Condition = defaultElementConditions.DirtyElementCondition,
					DirtMaskTextureSize = deviceService.PlacedDeviceContainer.Device.Info.GeneratedDirtMaskTextureSize,
					DirtMaskPresetOverride = selectedPreset
				};
				elementService.ApplyElementCondition(selectedElement, elementData, async: false);
			}
		}

		[Category("Testing dirt on elements")]
		[DisplayName("Scorch All Circuits In Inventory")]
		[SROptions.Sort(12)]
		public void ScorchAllCircuitsInInventory()
		{
			foreach (IReadOnlyStorageSlot storageElement in inventory.StorageElements)
			{
				if (storageElement.Item is StorageItemElement storageItemElement)
				{
					ElementMaterialType elementMaterialType = storageItemElement.ElementData.Info.ElementMaterialType;
					List<MaskPresetInfoBase> list = (from x in dirtMaskPresetSelector.GetAllApplicableDirtMaskPresetsByElementType(elementMaterialType)
						where x is ScorchedCircuitPresetInfo
						select x).ToList();
					if (list.Count != 0)
					{
						MaskPresetInfoBase maskPresetInfoBase = list[Random.Range(0, list.Count)];
						ElementData elementData = storageItemElement.ElementData;
						ElementInfo info = elementData.Info;
						elementData.Condition = defaultElementConditions.DirtyElementCondition;
						elementData.DirtMaskPresetOverride = maskPresetInfoBase;
						elementData.NoiseSeed = textureMaskCreator.GetRandomOrDebugNoiseSeed(maskPresetInfoBase, info);
						elementData.DirtMaskTextureSize = (info.SourceDevice as DeviceInfo).GeneratedDirtMaskTextureSize;
						elementService.ApplyScorchedCircuitProperty(elementData);
						Debug.Log("Scorched " + info.ID + " with preset " + maskPresetInfoBase.ID);
					}
				}
			}
		}

		private void GenerateNewDirtTexture()
		{
			TextureMaskHolder componentInChildren = selectedElement.GetComponentInChildren<TextureMaskHolder>();
			float noiseSeed = selectedElement.Info.ProvenNoiseSeeds[Random.Range(0, selectedElement.Info.ProvenNoiseSeeds.Count)];
			MeshUVProcessor.ProcessingSettings meshSettings = new MeshUVProcessor.ProcessingSettings
			{
				enableDebugOutput = false,
				enableWireframe = true,
				wireThickness = 0.5f,
				wrapUV = false
			};
			textureMaskCreator.CreateTextureMaskWithMesh(componentInChildren.WorkTexture, selectedPreset, componentInChildren.SharedMesh, meshSettings, noiseSeed, out var _);
			componentInChildren.ResetPreInitializationDirtyPixels();
			CleaningProgressInPercentage cleaningProgress = cleanColorCalculator.CalculateProgress(componentInChildren);
			DirtyPixelsCount initialDirtyPixelsCount = componentInChildren.InitialDirtyPixelsCount;
			SolderingProgressInPercentage solderingProgress = SolderingProgressInPercentage.FullProgress;
			int solderPointsCount = 0;
			if (selectedElement.ConditionHandler.ElementData.AdditionalProperty is ScorchedCircuitProperty scorchedCircuitProperty)
			{
				solderingProgress = scorchedCircuitProperty.GetProgress();
				solderPointsCount = scorchedCircuitProperty.InitialBurntPointsCount;
			}
			if ((bool)elementCleaner.TargetElement)
			{
				InitialCleaningData initialCleaningData = new InitialCleaningData
				{
					CleaningProgress = cleaningProgress,
					SolderingProgress = solderingProgress,
					DirtyPixelsCount = initialDirtyPixelsCount,
					SolderPointsCount = solderPointsCount
				};
				elementCleanerPanel.ResetCleaningProgressToNewValue(initialCleaningData);
			}
		}

		private void SwitchDirtPreset(int increment)
		{
			if ((bool)selectedElement && applicablePresets.Count != 0)
			{
				if (!selectedPreset)
				{
					selectedPreset = applicablePresets[0];
				}
				int index = (applicablePresets.IndexOf(selectedPreset) + increment + applicablePresets.Count) % applicablePresets.Count;
				selectedPreset = applicablePresets[index];
				OnPropertyChanged("SelectedPresetName");
			}
		}

		private void SwitchElementSelection(int increment)
		{
			if ((bool)deviceService.PlacedDeviceContainer && elementsList.Count != 0)
			{
				if (!selectedElement)
				{
					selectedElement = elementsList[0];
				}
				int index = (elementsList.IndexOf(selectedElement) + increment + elementsList.Count) % elementsList.Count;
				selectedElement = elementsList[index];
				FillPresetsListWithApplicableDirtMasks();
				SelectInitialPreset();
				OnPropertyChanged("SelectedElementName");
				OnPropertyChanged("SelectedPresetName");
			}
		}

		private void OnPanelVisibilityChanged(IDebugPanelService panelService, bool isDebugPanelVisible)
		{
			if (isDebugPanelVisible)
			{
				FillElementsList();
				SelectInitialElement();
				FillPresetsListWithApplicableDirtMasks();
				SelectInitialPreset();
			}
			else
			{
				ClearLists();
			}
		}

		private void SelectInitialElement()
		{
			if (!LockElementSelection || !deviceService.PlacedDeviceContainer || !selectedElement || !elementsList.Contains(selectedElement))
			{
				selectedElement = ((elementsList.Count > 0) ? elementsList[0] : null);
			}
		}

		private void SelectInitialPreset()
		{
			if (!LockPresetSelection || !selectedPreset || !applicablePresets.Contains(selectedPreset))
			{
				selectedPreset = ((applicablePresets.Count > 0) ? applicablePresets[0] : null);
			}
		}

		private void Clear()
		{
			ClearLists();
			ClearSelection();
		}

		private void ClearLists()
		{
			applicablePresets.Clear();
			elementsList.Clear();
		}

		private void ClearSelection()
		{
			selectedElement = null;
			selectedPreset = null;
		}

		private void FillElementsList()
		{
			elementsList.Clear();
			if (!deviceService.PlacedDeviceContainer)
			{
				return;
			}
			List<ElementBase> value;
			using (CollectionPool<List<ElementBase>, ElementBase>.Get(out value))
			{
				foreach (ElementSocket elementSocket in deviceService.PlacedDeviceContainer.Device.ElementSockets)
				{
					if ((bool)elementSocket && (bool)elementSocket.NestedElement && elementSocket.NestedElement.Info.CanBeDirty)
					{
						value.Add(elementSocket.NestedElement);
					}
				}
				foreach (ElementBase placedElement in workSurface.PlacedElements)
				{
					if ((bool)placedElement && placedElement.Info.CanBeDirty)
					{
						value.Add(placedElement);
					}
				}
				foreach (IElementInfo element in deviceService.PlacedDeviceContainer.Device.Info.Elements)
				{
					if (!(element is ElementInfo elementInfo))
					{
						continue;
					}
					foreach (ElementBase item in value)
					{
						if (item.Info.ID == elementInfo.ID && !elementsList.Contains(item))
						{
							elementsList.Add(item);
							break;
						}
					}
				}
			}
		}

		private void FillPresetsListWithApplicableDirtMasks()
		{
			if ((bool)selectedElement)
			{
				applicablePresets.Clear();
				applicablePresets.AddRange(dirtMaskPresetSelector.GetAllApplicableDirtMaskPresetsByElementType(selectedElement.Info.ElementMaterialType));
			}
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
