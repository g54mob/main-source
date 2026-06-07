using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.PlanetStudio.UI.Inspector;
using Assets.Scripts.Ui;
using ModApi.Audio;
using ModApi.Planet;
using ModApi.Planet.Modifiers;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using ModApi.Ui.Inspector.Events;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class NoiseFlyoutScript : PlanetStudioFlyoutScript, IDragDropContainer
	{
		public enum ViewModeType
		{
			Basic = 0,
			Advanced = 1
		}

		private const string BasicViewKeyName = "PlanetStudio.NoiseFlyout.BasicView";

		private const string IconClassNameContainer = "icon-container";

		private const string IconClassNameModifier = "icon-modifier";

		private const string IconClassNamePass = "icon-pass";

		private static bool _advancedSettingsCollapsedState = true;

		private float _autoScrollAmount;

		private Dictionary<Type, List<Tuple<FieldInfo, DataSlotAttribute>>> _dataSlotCache = new Dictionary<Type, List<Tuple<FieldInfo, DataSlotAttribute>>>();

		private CelestialBodyDesignerScript _designer;

		private NoiseElement _dragSource;

		private TreeNode<NoiseElement>.DropTarget _dropTarget;

		private bool _hideEmptyPasses = true;

		private XmlElement _insertIndicator;

		private XmlElement _mainPanel;

		private List<NoiseElement> _passContainers = new List<NoiseElement>();

		private XmlElement _performanceHeader;

		private XmlElement _rowTemplate;

		private ScrollRect _scrollRect;

		private NoiseElement _selectedElement;

		private bool _showDataVisualization;

		private bool _showProfilerColumns;

		private ViewModeType _viewMode;

		public CelestialBodyViewerScript CelestialBodyViewer => _designer.CelestialBodyViewer;

		public Transform DragParent { get; private set; }

		public bool HideEmptyPasses
		{
			get
			{
				return _hideEmptyPasses;
			}
			set
			{
				if (_hideEmptyPasses != value)
				{
					_hideEmptyPasses = value;
					XmlElement elementById = base.xmlLayout.GetElementById("hide-empty-button");
					if (_hideEmptyPasses)
					{
						elementById.AddClass("enabled");
					}
					else
					{
						elementById.RemoveClass("enabled");
					}
					UpdateRowElements();
				}
			}
		}

		public bool IsDragging { get; private set; }

		public PlanetDataScript PlanetData => base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesigner.CurrentCelestialBody;

		public NoiseElement Root { get; private set; }

		public NoiseElement SelectedElement
		{
			get
			{
				return _selectedElement;
			}
			private set
			{
				if (_selectedElement == value)
				{
					return;
				}
				if (_selectedElement != null)
				{
					_selectedElement.RowElement.RemoveClass("selected");
					IInspectorPanel inspectorPanel = _selectedElement.InspectorPanel;
					if (inspectorPanel != null && !inspectorPanel.IsPinned)
					{
						_selectedElement.InspectorPanel?.Close();
						_selectedElement.InspectorPanel = null;
					}
				}
				_selectedElement = value;
				if (_selectedElement != null)
				{
					if (!_selectedElement.IsPass && (ViewMode == ViewModeType.Advanced || !_selectedElement.IsContainer) && _selectedElement.InspectorPanel == null)
					{
						int panelOffset = (ShowDataVisualization ? 250 : (ShowProfilerColumns ? 400 : 0));
						CreatePanelForElement(_selectedElement, panelOffset, null);
					}
					_selectedElement.RowElement.AddClass("selected");
				}
			}
		}

		public bool ShowDataVisualization
		{
			get
			{
				return _showDataVisualization;
			}
			set
			{
				if (_showDataVisualization == value)
				{
					return;
				}
				if (value)
				{
					ShowProfilerColumns = false;
				}
				_showDataVisualization = value;
				XmlElement elementById = base.xmlLayout.GetElementById("toggle-data-flow-button");
				if (_showDataVisualization)
				{
					base.Flyout.AddClass("noise-flyout-expanded");
					elementById.AddClass("btn-primary");
					_mainPanel.AddClass("data-flow-enabled");
				}
				else
				{
					elementById.RemoveClass("btn-primary");
					base.Flyout.RemoveClass("noise-flyout-expanded");
					_mainPanel.RemoveClass("data-flow-enabled");
				}
				foreach (NoiseElement passContainer in _passContainers)
				{
					passContainer.UpdateVisualization();
				}
			}
		}

		public bool ShowProfilerColumns
		{
			get
			{
				return _showProfilerColumns;
			}
			set
			{
				if (_showProfilerColumns != value)
				{
					_showProfilerColumns = value;
					_performanceHeader.SetActive(value);
					_performanceHeader.transform.SetAsFirstSibling();
					if (value)
					{
						ShowDataVisualization = false;
					}
					XmlElement elementById = base.xmlLayout.GetElementById("toggle-profiler");
					if (_showProfilerColumns)
					{
						base.Flyout.AddClass("noise-flyout-expanded-profiler");
						elementById.AddClass("btn-primary");
						_mainPanel.AddClass("profiler-enabled");
					}
					else
					{
						elementById.RemoveClass("btn-primary");
						base.Flyout.RemoveClass("noise-flyout-expanded-profiler");
						_mainPanel.RemoveClass("profiler-enabled");
					}
					Root.UpdateProfilerColumns();
				}
			}
		}

		public ViewModeType ViewMode
		{
			get
			{
				return _viewMode;
			}
			set
			{
				_viewMode = value;
				Game.Instance.Settings.UserPrefs.SetBool("PlanetStudio.NoiseFlyout.BasicView", value == ViewModeType.Basic);
			}
		}

		public void Dragging(PointerEventData eventData)
		{
			_autoScrollAmount = 0f;
			XmlElement xmlElement = eventData.pointerCurrentRaycast.gameObject?.GetComponentInParent<XmlElement>();
			TreeNode<NoiseElement>.DropTarget dropTarget = new TreeNode<NoiseElement>.DropTarget();
			if (xmlElement != null)
			{
				XmlElement rowElement = xmlElement.GetParentElementWithClass("list-item");
				NoiseElement noiseElement = Root.FindNode((TreeNode<NoiseElement> n) => n.Item.RowElement == rowElement)?.Item;
				if (noiseElement != null && noiseElement.AllowDrop && !_dragSource.IsAncestor(noiseElement))
				{
					RectTransformUtility.ScreenPointToLocalPointInRectangle(rowElement.rectTransform, eventData.position, null, out var localPoint);
					if (localPoint.y >= 0f)
					{
						if (!noiseElement.IsPass)
						{
							dropTarget.Container = noiseElement.Parent;
							dropTarget.InsertBefore = noiseElement;
						}
						else
						{
							dropTarget.Container = noiseElement;
						}
					}
					else if (localPoint.y < 0f)
					{
						if (noiseElement.IsContainer && !noiseElement.Collapsed && noiseElement.Children.Count > 0)
						{
							dropTarget.Container = noiseElement;
							dropTarget.InsertBefore = noiseElement.Children.First();
						}
						else if (!noiseElement.IsPass)
						{
							dropTarget.Container = noiseElement.Parent;
							dropTarget.InsertBefore = noiseElement.GetNextOrNull();
						}
						else
						{
							dropTarget.Container = noiseElement;
						}
					}
					if (noiseElement.IsContainer)
					{
						float num = rowElement.rectTransform.rect.height * 0.25f;
						if (Mathf.Abs(localPoint.y) < num)
						{
							dropTarget.Container = noiseElement;
							dropTarget.InsertBefore = null;
						}
					}
				}
			}
			if (_dropTarget?.InsertBefore != dropTarget.InsertBefore)
			{
				int num2 = -1;
				if (dropTarget.InsertBefore != null)
				{
					num2 = dropTarget.InsertBefore.RowElement.transform.GetSiblingIndex();
				}
				else if (dropTarget.Container != null && !dropTarget.Container.Collapsed)
				{
					num2 = dropTarget.Container.LastSiblingIndex + 1;
				}
				if (num2 >= 0)
				{
					_insertIndicator.SetActive(active: true);
					if (_insertIndicator.transform.GetSiblingIndex() < num2)
					{
						num2--;
					}
					_insertIndicator.transform.SetSiblingIndex(num2);
				}
				else
				{
					_insertIndicator.SetActive(active: false);
				}
			}
			_dropTarget = dropTarget;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_scrollRect.viewport, eventData.position, null, out var localPoint2))
			{
				float num3 = Mathf.Clamp(0f - localPoint2.y, 0f, _scrollRect.viewport.rect.height);
				if (num3 < 50f)
				{
					_autoScrollAmount = Mathf.Clamp01((50f - num3) / 50f * 2f);
				}
				else if (num3 > _scrollRect.viewport.rect.height - 50f)
				{
					float num4 = _scrollRect.viewport.rect.height - num3;
					_autoScrollAmount = 0f - Mathf.Clamp01((50f - num4) / 50f * 2f);
				}
			}
		}

		public void EndDrag(IDragDropElement element)
		{
			NoiseElement noiseElement = element as NoiseElement;
			if (_dropTarget?.Container != null)
			{
				List<NoiseElement> list = new List<NoiseElement>();
				FindIncompatibleElements(_dragSource, _dropTarget.Container, list);
				if (list.Count == 0)
				{
					_dragSource.MoveToContainer(_dropTarget.Container, _dropTarget.InsertBefore);
					UpdateRowElements();
					base.PlanetStudioUI.CreateUndoStep(null, "Moved " + noiseElement.Name);
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDropPart);
				}
				else
				{
					string text = "Cannot move the selection because it contains at least one element that is not compatible with the destination:";
					foreach (NoiseElement item in list.Take(10))
					{
						text = text + "\n" + item.Name;
					}
					Game.Instance.UserInterface.CreateMessageDialog(text);
				}
				_dropTarget = null;
			}
			_insertIndicator.SetActive(active: false);
			_dragSource = null;
			_autoScrollAmount = 0f;
		}

		public NoiseElement GetOrCreateContainer(NoiseElement root, VertexDataPlanetModifierPassType pass, string biomeName, bool allowDragging, string container = null, string iconClassName = "icon-container")
		{
			string[] array = GetPassPath(pass, biomeName, container).Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
			NoiseElement noiseElement = root;
			for (int i = 0; i < array.Length; i++)
			{
				NoiseElement noiseElement2 = null;
				foreach (NoiseElement child in noiseElement.Children)
				{
					if (child.Name == array[i])
					{
						noiseElement2 = child;
						break;
					}
				}
				if (noiseElement2 == null)
				{
					NoiseElement noiseElement4 = new NoiseElement(this, array[i], pass, (biomeName == null) ? VertexDataType.Common : VertexDataType.Biome);
					CreateRowElement(noiseElement4, allowDragging, iconClassName);
					noiseElement4.SetParent(noiseElement);
					noiseElement2 = noiseElement4;
				}
				noiseElement = noiseElement2;
			}
			return noiseElement;
		}

		public void StartDrag(IDragDropElement element)
		{
			_dragSource = element as NoiseElement;
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.StagingDragStage);
		}

		protected override void OnCelestialBodyViewRefreshed()
		{
			if (ShowProfilerColumns)
			{
				Root.UpdateProfilerColumns();
			}
		}

		protected override void OnFlyoutClosed()
		{
			base.OnFlyoutClosed();
			CloseAllInspectorPanels();
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			_designer = base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript;
			DragParent = base.xmlLayout.GetElementById("drag-parent").transform;
			_scrollRect = base.xmlLayout.GetElementById<ScrollRect>("scroll-view");
			_insertIndicator = base.xmlLayout.GetElementById("insert-indicator");
			_mainPanel = base.xmlLayout.GetElementById("main-panel");
			_rowTemplate = base.xmlLayout.GetElementById("row-template");
			_performanceHeader = base.xmlLayout.GetElementById("performance-header");
			ViewMode = ((!Game.Instance.Settings.UserPrefs.GetBool("PlanetStudio.NoiseFlyout.BasicView", defaultValue: true)) ? ViewModeType.Advanced : ViewModeType.Basic);
			RefreshViewMode();
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			CloseAllInspectorPanels();
			RebuildRows();
		}

		private static void CreateModelForContainer(NoiseElement noiseElement, InspectorModel model)
		{
			model.Add(new TextInputModel("Name", () => noiseElement.Name, delegate(string x)
			{
				noiseElement.Name = x;
				noiseElement.UpdatePassModifierTransformOrdering();
			}));
			model.Add(new ToggleModel("Enabled", () => noiseElement.IsActive, delegate(bool x)
			{
				noiseElement.IsActive = x;
				noiseElement.PassContainer.UpdateVisualization();
			}));
		}

		private static void FindIncompatibleElements(TreeNode<NoiseElement> subTree, TreeNode<NoiseElement> container, List<NoiseElement> incompatibleElements)
		{
			if (subTree.Item.Modifier != null)
			{
				if (!subTree.Item.Modifier.SupportedPassTypes.Contains(container.Item.Pass) || (subTree.Item.Modifier.VertexDataType & container.Item.VertexDataType) == 0)
				{
					incompatibleElements.Add(subTree.Item);
				}
				return;
			}
			foreach (TreeNode<NoiseElement> child in subTree.Children)
			{
				FindIncompatibleElements(child, container, incompatibleElements);
			}
		}

		private static string GetPassPath(VertexDataPlanetModifierPassType pass, string biomeName, string container)
		{
			string text = $"{pass}";
			if (biomeName != null)
			{
				biomeName = biomeName.Replace("/", "-");
				text = text + " Biomes Pass/" + biomeName;
			}
			else
			{
				text += " Pass";
			}
			if (container != null)
			{
				text = text + "/" + container;
			}
			return text;
		}

		private void CloseAllInspectorPanels()
		{
			if (Root == null)
			{
				return;
			}
			Root.ExecuteTree(delegate(NoiseElement x)
			{
				if (x.InspectorPanel != null)
				{
					x.InspectorPanel.Close();
					x.InspectorPanel = null;
				}
			});
		}

		private NoiseElement CreateElementForModifier(bool allowDragging, VertexDataPlanetModifier modifier, NoiseElement container)
		{
			NoiseElement noiseElement = new NoiseElement(this, modifier.transform, modifier);
			List<DataSlotField> list = new List<DataSlotField>();
			List<Tuple<FieldInfo, DataSlotAttribute>> value = null;
			Type type = modifier.GetType();
			if (modifier is IDataSlotConfiguration dataSlotConfiguration)
			{
				dataSlotConfiguration.GetDataSlots(list);
			}
			else
			{
				if (!_dataSlotCache.TryGetValue(type, out value))
				{
					value = new List<Tuple<FieldInfo, DataSlotAttribute>>();
					FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						DataSlotAttribute dataSlotAttribute = fieldInfo.GetCustomAttributes(typeof(DataSlotAttribute), inherit: false).Cast<DataSlotAttribute>().FirstOrDefault();
						if (dataSlotAttribute != null)
						{
							value.Add(new Tuple<FieldInfo, DataSlotAttribute>(fieldInfo, dataSlotAttribute));
						}
					}
					_dataSlotCache[type] = value;
				}
				foreach (Tuple<FieldInfo, DataSlotAttribute> item in value)
				{
					list.Add(new DataSlotField(modifier, item.Item2, item.Item1));
				}
			}
			noiseElement.DataSlots.AddRange(list);
			CreateRowElement(noiseElement, allowDragging, "icon-modifier");
			return noiseElement;
		}

		private void CreateElementsForModifiers(List<PlanetModifier> modifiers, PlanetBiome biome)
		{
			bool allowDragging = ViewMode == ViewModeType.Advanced;
			foreach (PlanetModifier modifier in modifiers)
			{
				VertexDataPlanetModifier vertexDataPlanetModifier = modifier as VertexDataPlanetModifier;
				if (vertexDataPlanetModifier != null && (ViewMode == ViewModeType.Advanced || vertexDataPlanetModifier.VisibleInBasicViewMode))
				{
					NoiseElement orCreateContainer = GetOrCreateContainer(Root, vertexDataPlanetModifier.Pass, biome?.Name, allowDragging, modifier.Container);
					CreateElementForModifier(allowDragging, vertexDataPlanetModifier, orCreateContainer).SetParent(orCreateContainer);
				}
			}
		}

		private void CreateModelForModifier(NoiseElement noiseElement, InspectorModel model, int panelOffset)
		{
			TerrainModifierInspector terrainModifierInspector = new TerrainModifierInspector(noiseElement.Modifier.gameObject.name, noiseElement.Modifier, noiseElement);
			model.Add(new TextInputModel("Name", () => noiseElement.Name, delegate(string x)
			{
				noiseElement.Name = x;
			}, ElementAlignment.Right));
			model.Add(new ToggleModel("Enabled", () => noiseElement.IsActive, delegate(bool x)
			{
				noiseElement.IsActive = x;
				noiseElement.PassContainer.UpdateVisualization();
			}));
			terrainModifierInspector.PreprocessField = (object obj, FieldInfo field) => field.GetCustomAttributes(typeof(DataSlotAttribute), inherit: false).Count() <= 0;
			terrainModifierInspector.BuildModel(model);
			if (Game.Instance.Settings.UserPrefs.GetBool("PlanetStudio.TerrainGeneration.AdvancedSettings"))
			{
				GroupModel groupModel = model.AddGroup(new GroupModel("Advanced Settings"));
				groupModel.CollapsedChanged += delegate(object sender, GroupModelCollapsedChangedEventArgs e)
				{
					_advancedSettingsCollapsedState = e.Collapsed;
				};
				groupModel.Collapsed = _advancedSettingsCollapsedState;
				string symbolsInfo = "This is should be a comma separated list of 'symbols'." + Environment.NewLine + Environment.NewLine + "CUBEMAP: This symbol is defined when the cubemap is generated for the planet (used in map view and distant viewing)." + Environment.NewLine + Environment.NewLine + "EQUIRECTANGULARMAP: This symbol is defined when the equirectangular map is generated for the planet." + Environment.NewLine + Environment.NewLine + "Cubemap - [MapName]: This symbol is defined when a planet brush cubemap (created with the brush flyout) exists for the planet, with [MapName] being replaced with the actual name of the planet brush cubemap.";
				groupModel.Add(new ToggleModel("Visible in Basic View", () => noiseElement.Modifier.VisibleInBasicViewMode, delegate(bool x)
				{
					noiseElement.Modifier.VisibleInBasicViewMode = x;
				}, "Toggles whether or not this modifier shows up in the 'Basic' view of the terrain generation flyout."));
				FieldInfo enabledWithSymbols = typeof(PlanetModifier).GetField("_enabledWithSymbols", BindingFlags.Instance | BindingFlags.NonPublic);
				groupModel.AddAndBuild(new TextInputModel("Enabled With Symbols", () => string.Join(",", noiseElement.Modifier.EnabledWithSymbols), delegate(string x)
				{
					enabledWithSymbols.SetValue(noiseElement.Modifier, (from y in x.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
						select y.Trim()).ToArray());
				})).Build(delegate(TextInputModel x)
				{
					x.Tooltip = "This modifier will only be enabled when ALL of these symbols are defined. " + symbolsInfo;
				});
				FieldInfo disabledWithSymbols = typeof(PlanetModifier).GetField("_disabledWithSymbols", BindingFlags.Instance | BindingFlags.NonPublic);
				groupModel.AddAndBuild(new TextInputModel("Disabled With Symbols", () => string.Join(",", noiseElement.Modifier.DisabledWithSymbols), delegate(string x)
				{
					disabledWithSymbols.SetValue(noiseElement.Modifier, (from y in x.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries)
						select y.Trim()).ToArray());
				})).Build(delegate(TextInputModel x)
				{
					x.Tooltip = "This modifier will disabled when ANY of these symbols are defined. " + symbolsInfo;
				});
			}
			if (noiseElement.DataSlots.Any((DataSlotField x) => x.Attribute.UserEditable) && ViewMode == ViewModeType.Advanced)
			{
				GroupModel groupModel2 = new GroupModel("Data Inputs / Outputs");
				groupModel2.AutoGenerateCollapsedId = false;
				groupModel2.FullCollapsedId = "Noise/DataInputsOutputs";
				model.AddGroup(groupModel2);
				foreach (DataSlotField dataSlot in from x in noiseElement.DataSlots
					where x.Attribute.UserEditable
					orderby x.Attribute.Order, x.Attribute.Name
					select x)
				{
					SliderModel sliderModel = groupModel2.Add(new SliderModel(dataSlot.Attribute.Name, () => dataSlot.DataIndex, delegate(float x)
					{
						dataSlot.DataIndex = (int)x;
						noiseElement.PassContainer.UpdateVisualization();
					}, dataSlot.Attribute.Optional ? (-1) : 0, 9f, wholeNumbers: true));
					sliderModel.ValueFormatter = (float x) => (x >= 0f) ? x.ToString() : "Unused";
					sliderModel.Tooltip = dataSlot.Attribute.Tooltip;
				}
			}
			terrainModifierInspector.RebuildModel = delegate
			{
				InspectorPanelCreationInfo.InspectorPanelRestoreState restoreState = noiseElement.InspectorPanel.GenerateRestoreState();
				noiseElement.InspectorPanel.Close();
				if (noiseElement.Modifier is IDataSlotConfiguration dataSlotConfiguration)
				{
					noiseElement.DataSlots.Clear();
					dataSlotConfiguration.GetDataSlots(noiseElement.DataSlots);
				}
				CreatePanelForElement(noiseElement, panelOffset, restoreState);
				noiseElement.PassContainer.UpdateVisualization();
			};
		}

		private void CreatePanelForElement(NoiseElement noiseElement, int panelOffset, InspectorPanelCreationInfo.InspectorPanelRestoreState restoreState)
		{
			Type type = noiseElement.Modifier?.GetType();
			PlanetModifierInfoAttribute planetModifierInfoAttribute = type?.GetCustomAttribute<PlanetModifierInfoAttribute>();
			string title = planetModifierInfoAttribute?.DisplayName ?? type?.Name ?? noiseElement.Name ?? string.Empty;
			InspectorModel inspectorModel = new InspectorModel(noiseElement.Name, title);
			if (noiseElement.IsContainer)
			{
				CreateModelForContainer(noiseElement, inspectorModel);
			}
			else
			{
				TerrainFeature terrainFeature = null;
				if (ViewMode == ViewModeType.Basic)
				{
					terrainFeature = FeatureRegistry.CreateFeatureForModifier(noiseElement.Modifier);
				}
				if (terrainFeature != null)
				{
					terrainFeature.CreateModel(inspectorModel, delegate
					{
						InspectorPanelCreationInfo.InspectorPanelRestoreState restoreState2 = noiseElement.InspectorPanel.GenerateRestoreState();
						noiseElement.InspectorPanel.Close();
						CreatePanelForElement(noiseElement, panelOffset, restoreState2);
					});
				}
				else
				{
					CreateModelForModifier(noiseElement, inspectorModel, panelOffset);
					inspectorModel.TitleTextTooltip = planetModifierInfoAttribute?.Description;
				}
			}
			base.PlanetStudioUI.PrepareInspectorModel(inspectorModel);
			InspectorPanelCreationInfo inspectorPanelCreationInfo = new InspectorPanelCreationInfo(restoreState);
			inspectorPanelCreationInfo.PanelWidth = 400;
			inspectorPanelCreationInfo.StartOffset = new Vector2(400 + panelOffset, 0f);
			inspectorPanelCreationInfo.PanelMaxHeight = 0.8f;
			noiseElement.InspectorPanel = Game.Instance.UserInterface.CreateInspectorPanel(inspectorModel, inspectorPanelCreationInfo);
			noiseElement.InspectorPanel.Closed += delegate
			{
				noiseElement.InspectorPanel = null;
			};
		}

		private void CreateRowElement(NoiseElement noiseElement, bool allowDragging, string iconClassName)
		{
			XmlElement rowTemplate = _rowTemplate;
			XmlElement xmlElement = UiUtilities.CloneTemplate(rowTemplate, rowTemplate.parentElement, applyAttributes: false);
			if (!noiseElement.IsContainer)
			{
				noiseElement.SupportsArrow = false;
				if (!noiseElement.IsActive)
				{
					xmlElement.AddClass("disabled");
				}
			}
			noiseElement.NameText = xmlElement.GetElementByInternalId<TextMeshProUGUI>("name");
			noiseElement.NameText.text = noiseElement.Name;
			noiseElement.RowElement = xmlElement;
			if (allowDragging)
			{
				xmlElement.gameObject.AddComponent<ElementDragHandlerScript>().Initialize(noiseElement, this);
			}
			if (iconClassName != null)
			{
				xmlElement.GetElementByInternalId("icon").AddClass(iconClassName);
			}
		}

		private void DuplicateElement(NoiseElement element)
		{
			if (element != null && !element.IsContainer)
			{
				VertexDataPlanetModifier modifier = DuplicateModifier(element.Modifier);
				TreeNode<NoiseElement> treeNode = (element.IsContainer ? element : element.Parent);
				NoiseElement noiseElement = CreateElementForModifier(ViewMode == ViewModeType.Advanced, modifier, treeNode.Item);
				noiseElement.MoveToContainer(treeNode, element.IsContainer ? null : element.GetNextOrNull());
				UpdateRowElements();
				SelectedElement = noiseElement;
				return;
			}
			throw new NotImplementedException();
		}

		private VertexDataPlanetModifier DuplicateModifier(VertexDataPlanetModifier modifier)
		{
			XElement xml = new XElement(modifier.GetType().Name);
			modifier.SaveXml(xml);
			VertexDataPlanetModifier vertexDataPlanetModifier = PlanetModifier.CreateFromXml(xml, PlanetData.TerrainData.transform, PlanetData.TerrainData, modifier.Biome) as VertexDataPlanetModifier;
			PlanetData.TerrainData.Modifiers.Add(vertexDataPlanetModifier);
			if (modifier.Biome != null)
			{
				modifier.Biome.Modifiers.Add(vertexDataPlanetModifier);
			}
			return vertexDataPlanetModifier;
		}

		private void OnAddButtonClicked()
		{
			if (SelectedElement != null)
			{
				NoiseElement selectedElement = SelectedElement;
				NoiseElement passContainer = SelectedElement.PassContainer;
				AddNoiseViewModel addNoiseViewModel = new AddNoiseViewModel(passContainer.Pass, passContainer.VertexDataType);
				addNoiseViewModel.OnComplete = delegate(VertexDataPlanetModifier m)
				{
					PlanetData.TerrainData.Modifiers.Add(m);
					selectedElement.PassContainer.PassBiome?.Modifiers.Add(m);
					TreeNode<NoiseElement> treeNode = (selectedElement.IsContainer ? selectedElement : selectedElement.Parent);
					VertexDataPlanetModifier modifier = selectedElement.Modifier;
					m.OnCreatingInPlanetStudio(PlanetData.TerrainData, modifier);
					NoiseElement noiseElement = CreateElementForModifier(ViewMode == ViewModeType.Advanced, m, treeNode.Item);
					noiseElement.MoveToContainer(treeNode, selectedElement.IsContainer ? null : selectedElement.GetNextOrNull());
					UpdateRowElements(updateDataVisualation: false);
					SelectedElement = noiseElement;
					m.OnCreatedInPlanetStudio(modifier);
					foreach (NoiseElement passContainer2 in _passContainers)
					{
						passContainer2.UpdateVisualization();
					}
				};
				Game.Instance.UserInterface.CreateListView(addNoiseViewModel);
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Please select an element above before clicking the add button.";
			}
		}

		private void OnAddContainerButtonClicked()
		{
			if (SelectedElement != null)
			{
				NoiseElement selectedElement = SelectedElement;
				NoiseElement passContainer = SelectedElement.PassContainer;
				ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
				inputDialogScript.InvalidCharacters.AddRange(Path.GetInvalidFileNameChars());
				inputDialogScript.InputPlaceholderText = "Container Name";
				inputDialogScript.MessageText = "Add New Container";
				inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
				{
					d.Close();
					NoiseElement noiseElement = new NoiseElement(this, d.InputText, passContainer.Pass, passContainer.VertexDataType);
					CreateRowElement(noiseElement, allowDragging: true, "icon-container");
					TreeNode<NoiseElement> container = (selectedElement.IsContainer ? selectedElement : selectedElement.Parent);
					noiseElement.MoveToContainer(container, selectedElement.IsContainer ? null : selectedElement.GetNextOrNull());
					UpdateRowElements();
					SelectedElement = noiseElement;
				};
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Please select an element above before clicking the add button.";
			}
		}

		private void OnDeleteButtonClicked()
		{
			NoiseElement noiseElement = SelectedElement;
			if (noiseElement != null)
			{
				if (noiseElement.CanModify)
				{
					ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
					if (noiseElement.IsContainer)
					{
						messageDialogScript.MessageText = "Please confirm that you want to delete the '" + noiseElement.Name + "' container and all of its children.";
					}
					else
					{
						messageDialogScript.MessageText = "Please confirm that you want to delete the '" + noiseElement.Name + "' element.";
					}
					messageDialogScript.UseDangerButtonStyle = true;
					messageDialogScript.OkayButtonText = "DELETE";
					messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript d)
					{
						d.Close();
						SelectedElement = null;
						noiseElement.Delete();
						noiseElement.PassContainer?.UpdateVisualization();
					};
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "This element cannot be deleted.";
				}
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Please select an element above before clicking the delete button.";
			}
		}

		private void OnDuplicateButtonClicked()
		{
			if (SelectedElement != null)
			{
				if (!SelectedElement.IsContainer)
				{
					DuplicateElement(SelectedElement);
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "The selected element cannot be duplicated.";
				}
			}
			else
			{
				Game.Instance.UserInterface.CreateMessageDialog().MessageText = "Select an element before clicking the duplicate button.";
			}
		}

		private void OnHideEmptyButtonClicked()
		{
			HideEmptyPasses = !HideEmptyPasses;
		}

		private void OnListItemClicked(XmlElement element)
		{
			XmlElement rowElement = element.GetParentElementWithClass("list-item");
			NoiseElement noiseElement = Root.FindNode((TreeNode<NoiseElement> n) => n.RowElement == rowElement)?.Item;
			if (noiseElement != null)
			{
				if (SelectedElement == noiseElement)
				{
					SelectedElement = null;
				}
				else
				{
					SelectedElement = noiseElement;
				}
			}
		}

		private void OnRandomizeButtonClicked()
		{
			NoiseElement noiseElement = SelectedElement;
			if (noiseElement == null)
			{
				noiseElement = Root;
			}
			int count = 0;
			RandomizeContext context = new RandomizeContext(PlanetModifierRandomizationFlags.SeedValues);
			noiseElement.ExecuteTree(delegate(NoiseElement x)
			{
				if (x.Modifier != null && x.Modifier.Randomize(context))
				{
					count++;
				}
			});
			Root.Collapsed = false;
			UpdateRowElements();
			_designer.RaiseCelestialBodyModifiedEvent();
			base.PlanetStudioUI.ShowMessage($"{count} element(s) were eligible and randomized.");
			base.PlanetStudioUI.PlanetStudioScript.CelestialBodyDesignerScript.StartViewCelestialBodyInteractive();
		}

		private void OnToggleCollapseButtonClicked()
		{
			NoiseElement noiseElement = SelectedElement;
			bool action = false;
			if (noiseElement == null)
			{
				noiseElement = Root;
				action = !Root.Children[0].Collapsed;
			}
			else
			{
				action = !noiseElement.Collapsed;
			}
			noiseElement.ExecuteTree(delegate(NoiseElement x)
			{
				x.Collapsed = action;
			});
			Root.Collapsed = false;
			UpdateRowElements();
		}

		private void OnToggleDataFlowButtonClicked()
		{
			ShowDataVisualization = !ShowDataVisualization;
		}

		private void OnToggleProfilerButtonClicked()
		{
			ShowProfilerColumns = !ShowProfilerColumns;
		}

		private void OnViewModeButtonClicked()
		{
			if (ViewMode == ViewModeType.Advanced)
			{
				ViewMode = ViewModeType.Basic;
				ShowDataVisualization = false;
			}
			else
			{
				ViewMode = ViewModeType.Advanced;
			}
			RefreshViewMode();
			RefreshUI();
		}

		private void RebuildRows()
		{
			SelectedElement = null;
			if (Root != null)
			{
				Root.ExecuteTree(delegate(NoiseElement n)
				{
					UnityEngine.Object.Destroy(n.RowElement.gameObject);
				});
			}
			Root = new NoiseElement(this, "Root", VertexDataPlanetModifierPassType.Final, VertexDataType.Both);
			Root.AllowDrop = false;
			Root.ContributesToContainerPath = false;
			CreateRowElement(Root, allowDragging: false, null);
			Root.RowElement.SetActive(active: false);
			var array = new[]
			{
				new
				{
					Pass = VertexDataPlanetModifierPassType.Biome,
					CreateBiomes = false
				},
				new
				{
					Pass = VertexDataPlanetModifierPassType.Height,
					CreateBiomes = true
				},
				new
				{
					Pass = VertexDataPlanetModifierPassType.HeightFinal,
					CreateBiomes = false
				},
				new
				{
					Pass = VertexDataPlanetModifierPassType.Final,
					CreateBiomes = true
				},
				new
				{
					Pass = VertexDataPlanetModifierPassType.Water,
					CreateBiomes = true
				}
			};
			foreach (NoiseElement passContainer in _passContainers)
			{
				passContainer.DataFlowVisualization.ClearMarkers();
			}
			_passContainers.Clear();
			PlanetTerrainDataScript terrainData = PlanetData.TerrainData;
			var array2 = array;
			foreach (var anon in array2)
			{
				Transform passTransform = terrainData.transform.Find($"PlanetModifiers/{anon.Pass}");
				NoiseElement orCreateContainer = GetOrCreateContainer(Root, anon.Pass, null, allowDragging: false, null, "icon-pass");
				orCreateContainer.InitializePassContainer(passTransform, null);
				_passContainers.Add(orCreateContainer);
				if (!anon.CreateBiomes)
				{
					continue;
				}
				NoiseElement orCreateContainer2 = GetOrCreateContainer(Root, anon.Pass, string.Empty, allowDragging: false, null, "icon-pass");
				orCreateContainer2.InitializePassContainer(null, null);
				orCreateContainer2.AllowDrop = false;
				foreach (PlanetBiome biome in terrainData.Biomes)
				{
					Transform passTransform2 = biome.transform.Find($"{anon.Pass}");
					NoiseElement orCreateContainer3 = GetOrCreateContainer(Root, anon.Pass, biome.Name, allowDragging: false, null, "icon-pass");
					orCreateContainer3.InitializePassContainer(passTransform2, biome);
					_passContainers.Add(orCreateContainer3);
				}
			}
			List<PlanetModifier> modifiers = PlanetData.TerrainData.Modifiers;
			CreateElementsForModifiers(modifiers, null);
			foreach (PlanetBiome biome2 in PlanetData.TerrainData.Biomes)
			{
				CreateElementsForModifiers(biome2.Modifiers, biome2);
			}
			UpdateRowElements();
		}

		private void RefreshViewMode()
		{
			List<XmlElement> elementsByClass = base.xmlLayout.GetElementsByClass("view-basic");
			List<XmlElement> elementsByClass2 = base.xmlLayout.GetElementsByClass("view-advanced");
			elementsByClass.ForEach(delegate(XmlElement x)
			{
				x.SetActive(_viewMode == ViewModeType.Basic);
			});
			elementsByClass2.ForEach(delegate(XmlElement x)
			{
				x.SetActive(_viewMode == ViewModeType.Advanced);
			});
		}

		private void UpdateRowElements(bool updateDataVisualation = true)
		{
			Root.UpdateRowElements();
			if (!updateDataVisualation)
			{
				return;
			}
			foreach (NoiseElement passContainer in _passContainers)
			{
				passContainer.UpdateVisualization();
			}
		}
	}
}
