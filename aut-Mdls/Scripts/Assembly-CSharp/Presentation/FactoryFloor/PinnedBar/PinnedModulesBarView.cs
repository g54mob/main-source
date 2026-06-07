using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Data.Quests.SubQuestEvents;
using Data.Shapes;
using Data.Variables;
using Events;
using Events.UI.ModuleViewer;
using Presentation.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.PinnedBar
{
	public class PinnedModulesBarView : MonoBehaviour
	{
		[Serializable]
		public struct ModuleViewerDataAndModuleIndex
		{
			public ModuleViewerData ModuleViewerData;

			public int Index;
		}

		[Serializable]
		public struct PinnedModuleHighlightEvents
		{
			public StartHighlightingUIPinnedModuleSubQuestEventSO StartHighlightingEvent;

			public StopHighlightingUIButtonSubQuestEventSO StopHighlightingEvent;
		}

		[FormerlySerializedAs("_pinnedModuleListView")]
		[SerializeField]
		private PinnedModuleButton pinnedModuleButton;

		[SerializeField]
		private GameObject _canvas;

		[SerializeField]
		private Transform _pinnedModuleParent;

		[SerializeField]
		private PinModuleUIEvent _pinShapeUIEvent;

		[SerializeField]
		private BaseEvent _hideBuildingModulesEvent;

		[SerializeField]
		private PinnedModulesViewLocator _locator;

		[SerializeField]
		private SerializedDictionary<ModuleViewerDataAndModuleIndex, PinnedModuleHighlightEvents> _buttonHighlightEvents;

		[SerializeField]
		private Button _closeViewButton;

		[SerializeField]
		private BoolVariableSO _pinnedModulesBarIsActive;

		private readonly Dictionary<(ModuleViewerData, ShapeData), PinnedModuleButton> _pinnedModules = new Dictionary<(ModuleViewerData, ShapeData), PinnedModuleButton>();

		public List<(ModuleViewerData, ShapeData)> PinnedModules => _pinnedModules.Keys.ToList();

		private void Awake()
		{
			_locator.PinnedModulesBarView = this;
			_pinShapeUIEvent.Register(HandlePinEvent);
			_canvas.SetActive(value: false);
			_closeViewButton.onClick.AddListener(DestroyAllPinnedModules);
			PinnedModuleQuestHighlighter.OnPinnedModuleHighlightChanged += HandlePinnedModuleHighlightChanged;
		}

		private void SetIsActive(bool value)
		{
			_pinnedModulesBarIsActive.SetValue(value);
			_canvas.SetActive(value);
		}

		private void HandlePinnedModuleHighlightChanged(bool isHighlighted)
		{
			if (isHighlighted)
			{
				_closeViewButton.gameObject.SetActive(value: false);
				return;
			}
			foreach (KeyValuePair<(ModuleViewerData, ShapeData), PinnedModuleButton> pinnedModule in _pinnedModules)
			{
				PinnedModuleQuestHighlighter component = pinnedModule.Value.GetComponent<PinnedModuleQuestHighlighter>();
				if (component != null && component.IsHighlighting)
				{
					_closeViewButton.gameObject.SetActive(value: false);
					return;
				}
			}
			_closeViewButton.gameObject.SetActive(value: true);
		}

		private void HandlePinEvent((ModuleViewerData, int) dataAndIndex)
		{
			var (moduleViewerData, _) = dataAndIndex;
			if (dataAndIndex.Item2 < moduleViewerData.Modules.Count)
			{
				ModuleViewerData.ShapeDataAndAmount shapeDataAndAmount = moduleViewerData.Modules.ElementAt(dataAndIndex.Item2);
				int item = dataAndIndex.Item2;
				if (_pinnedModules.ContainsKey((moduleViewerData, shapeDataAndAmount.Shape.Data)))
				{
					UnpinModule(moduleViewerData, shapeDataAndAmount.Shape.Data, item);
				}
				else
				{
					PinModule(moduleViewerData, shapeDataAndAmount.Shape.Data, item);
				}
			}
		}

		private void UnpinModule(ModuleViewerData moduleViewerData, ShapeData shape, int shapeIndex)
		{
			PinnedModuleButton obj = _pinnedModules[(moduleViewerData, shape)];
			_pinnedModules.Remove((moduleViewerData, shape));
			UnityEngine.Object.Destroy(obj.gameObject);
			SetIsActive(_pinnedModules.Count > 0);
		}

		private void PinModule(ModuleViewerData moduleViewerData, ShapeData shapeData, int shapeIndex)
		{
			PinnedModuleButton pinnedModuleButton = UnityEngine.Object.Instantiate(this.pinnedModuleButton, _pinnedModuleParent);
			pinnedModuleButton.Show(shapeData, moduleViewerData, shapeIndex);
			_pinnedModules.Add((moduleViewerData, shapeData), pinnedModuleButton);
			SetQuestHighlighterEvents(pinnedModuleButton, moduleViewerData, shapeIndex);
			SetIsActive(_pinnedModules.Count > 0);
		}

		private void SetQuestHighlighterEvents(PinnedModuleButton newPinnedModule, ModuleViewerData moduleViewerData, int shapeIndex)
		{
			PinnedModuleQuestHighlighter component = newPinnedModule.GetComponent<PinnedModuleQuestHighlighter>();
			ModuleViewerDataAndModuleIndex key = new ModuleViewerDataAndModuleIndex
			{
				ModuleViewerData = moduleViewerData,
				Index = shapeIndex
			};
			if (component != null && _buttonHighlightEvents.ContainsKey(key))
			{
				PinnedModuleHighlightEvents pinnedModuleHighlightEvents = _buttonHighlightEvents[key];
				component.SetEvents(pinnedModuleHighlightEvents.StartHighlightingEvent, pinnedModuleHighlightEvents.StopHighlightingEvent, moduleViewerData, shapeIndex);
			}
		}

		private void HandlePinnedModuleClosed(ModuleViewerData moduleViewerData, ShapeData shape, int shapeIndex)
		{
			UnpinModule(moduleViewerData, shape, shapeIndex);
		}

		private void OnDestroy()
		{
			_pinShapeUIEvent.UnRegister(HandlePinEvent);
			_closeViewButton.onClick.RemoveListener(DestroyAllPinnedModules);
			PinnedModuleQuestHighlighter.OnPinnedModuleHighlightChanged -= HandlePinnedModuleHighlightChanged;
			DestroyAllPinnedModules();
		}

		public void DestroyAllPinnedModules()
		{
			foreach (KeyValuePair<(ModuleViewerData, ShapeData), PinnedModuleButton> pinnedModule in _pinnedModules)
			{
				UnityEngine.Object.Destroy(pinnedModule.Value.gameObject);
			}
			_pinnedModules.Clear();
			SetIsActive(value: false);
			_hideBuildingModulesEvent.Fire();
		}

		public bool IsModulePinned(ModuleViewerData moduleViewerData, ShapeData shape)
		{
			return _pinnedModules.ContainsKey((moduleViewerData, shape));
		}
	}
}
