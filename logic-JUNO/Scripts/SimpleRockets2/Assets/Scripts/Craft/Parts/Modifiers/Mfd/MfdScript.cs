using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Craft.Program.Craft;
using ModApi.Flight.GameView;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class MfdScript : PartModifierScript<MfdData>, IAnalyzePerformance, IFlightUpdate, IGameLoopItem
	{
		private const int HudStencilValue = 50;

		private const string ScreenWidgetName = "_Screen";

		private static int _nextStencilValue = 51;

		private IFuelSource _battery;

		private IGameViewPointerEventHandler _capturedHandler;

		private IMfdWidget _capturedWidget;

		private Dictionary<string, Material> _materialHash = new Dictionary<string, Material>();

		private GameObject _screen;

		private GameObject _screenNoBatteriesIcon;

		private GameObject _screenOff;

		private ScreenWidgetScript _screenWidget;

		private Dictionary<string, IMfdWidget> _widgets = new Dictionary<string, IMfdWidget>(StringComparer.OrdinalIgnoreCase);

		public Canvas Canvas { get; private set; }

		public RectTransform CanvasTransform { get; private set; }

		public FlightProgramScript FlightProgram { get; private set; }

		public Transform ScaleRoot { get; private set; }

		public int StencilValue { get; private set; }

		public bool UsesMachNumber => false;

		private IPartStyle Style => base.PartScript.Data.Styles[0].Style;

		public IMfdWidget CreateWidget(MfdWidgetType widgetType, string name)
		{
			if (widgetType == MfdWidgetType.Screen)
			{
				if (!Canvas.TryGetComponent<ScreenWidgetScript>(out var component))
				{
					component = Canvas.gameObject.AddComponent<ScreenWidgetScript>();
					component.Initialize(this, "_Screen", widgetType);
					_widgets["_Screen"] = component;
					InitializeWidgetMaterial(component);
					PartMaterial partMaterial = base.PartScript.PartMaterialScript.GetPartMaterial(0);
					Color color = partMaterial.Color;
					component.Color = new Vector3(color.r, color.g, color.b);
					component.Opacity = Mathf.Clamp01(1f - partMaterial.TransparencyStrength);
				}
				return component;
			}
			if (_widgets.Count < base.Data.MaxWidgets)
			{
				if (!_widgets.ContainsKey(name))
				{
					IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
					WidgetScript widgetScript = widgetType switch
					{
						MfdWidgetType.RadialGauge => resourceLoader.InstantiatePrefab("Ui/Prefabs/Mfd/MfdRadialGauge").AddComponent<GaugeWidgetScript>(), 
						MfdWidgetType.Label => resourceLoader.InstantiatePrefab("Ui/Prefabs/Mfd/MfdLabel").AddComponent<LabelWidgetScript>(), 
						MfdWidgetType.Line => resourceLoader.InstantiatePrefab("Ui/Prefabs/Mfd/MfdLine").AddComponent<LineWidgetScript>(), 
						MfdWidgetType.Sprite => resourceLoader.InstantiatePrefab("Ui/Prefabs/Mfd/MfdSprite").AddComponent<SpriteWidgetScript>(), 
						MfdWidgetType.Texture => resourceLoader.InstantiatePrefab("Ui/Prefabs/Mfd/MfdTexture").AddComponent<TextureWidgetScript>(), 
						MfdWidgetType.Navball => resourceLoader.InstantiatePrefab("Ui/Prefabs/Mfd/MfdNavball").AddComponent<NavballWidgetScript>(), 
						MfdWidgetType.Map => resourceLoader.InstantiatePrefab("Ui/Prefabs/Mfd/MfdMap").AddComponent<MapWidgetScript>(), 
						_ => throw new ArgumentException($"Unsupported widget type {widgetType}"), 
					};
					widgetScript.Initialize(this, name, widgetType);
					widgetScript.SetParent(_screenWidget, worldPositionStays: false);
					InitializeWidgetMaterial(widgetScript);
					_widgets[name] = widgetScript;
					return widgetScript;
				}
				throw new Exception("Cannot create widget because one already exists with the name '" + name + "'");
			}
			throw new Exception($"Cannot create widget because MFD already has the max allowed number of widgets: '{base.Data.MaxWidgets}'");
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (base.PartScript.Data.Activated)
			{
				IFuelSource battery = _battery;
				if ((battery != null && !battery.IsEmpty) || base.Data.PowerUsage == 0f)
				{
					_battery.RemoveFuel(base.Data.PowerUsage * Time.deltaTime * 0.001f);
					if (!_screen.activeSelf)
					{
						_screen.SetActive(value: true);
						_screenOff?.SetActive(value: false);
					}
					return;
				}
			}
			if (_screen.activeSelf)
			{
				_screen.SetActive(value: false);
				_screenOff?.SetActive(value: true);
			}
			_screenNoBatteriesIcon.SetActive(base.PartScript.Data.Activated);
		}

		public IEnumerable<IMfdWidget> GetMfdChildWidgets(string parentName)
		{
			List<IMfdWidget> list = new List<IMfdWidget>();
			if (!string.IsNullOrEmpty(parentName))
			{
				foreach (RectTransform item in GetWidget(parentName).Transform)
				{
					IMfdWidget component = item.GetComponent<IMfdWidget>();
					list.Add(component);
				}
			}
			else
			{
				foreach (IMfdWidget value in _widgets.Values)
				{
					if (value.Transform.parent == CanvasTransform)
					{
						list.Add(value);
					}
				}
			}
			return list;
		}

		public IMfdWidget GetWidget(string name)
		{
			if (!string.IsNullOrEmpty(name) && _widgets.TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		public override IGameViewPointerEventHandler HandleGameViewPointerEvent(GameViewPointerEvent pointerEvent)
		{
			if (_capturedHandler != null)
			{
				_capturedHandler = _capturedWidget.HandleGameViewPointerEvent(pointerEvent);
			}
			else if (!Game.Instance.FlightScene.TimeManager.Paused)
			{
				List<RaycastResult> list = new List<RaycastResult>();
				EventSystem.current.RaycastAll(pointerEvent.EventData, list);
				foreach (RaycastResult item in list)
				{
					if (item.gameObject.TryGetComponent<IMfdWidget>(out var component) && component.Transform.IsChildOf(CanvasTransform) && component.Transform != CanvasTransform)
					{
						_capturedHandler = component.HandleGameViewPointerEvent(pointerEvent);
						_capturedWidget = component;
						if (_capturedHandler != null || pointerEvent.Handled)
						{
							break;
						}
					}
				}
			}
			return _capturedHandler;
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Power Consumption", () => (!base.PartScript.Data.Activated) ? "0W" : Units.GetPowerString(base.Data.PowerUsage)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Power Consumption", () => Units.GetPowerString(base.Data.PowerUsage), null, "The power consumption of the MFD."));
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			FlightProgram = base.PartScript.GetModifier<FlightProgramScript>();
			base.Data.OnModifiersCreated(FlightProgram.Data);
			if (Game.InFlightScene)
			{
				if (base.Data.RestoredWidgetsElement != null)
				{
					RestoreFromXml(base.Data.RestoredWidgetsElement);
					base.Data.RestoredWidgetsElement = null;
				}
				MfdData.DefaultMfdProgram mfdProgram = base.Data.MfdProgram;
				if (mfdProgram?.Id != "Custom")
				{
					string text = Game.Instance.ResourceLoader.LoadText("Craft/Parts/Mfd/" + mfdProgram.Filename, logErrors: false);
					FlightProgram.Data.FlightProgramXml = XElement.Parse(text);
					FlightProgram.Data.SaveFlightProgram = false;
				}
			}
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
		}

		public void RemoveWidget(IMfdWidget widget)
		{
			_widgets.Remove(widget.Name);
		}

		public void SaveXml(XElement xml)
		{
			if (_widgets.Values.Count <= 0 || !FlightProgram.Data.SaveFlightProgram)
			{
				return;
			}
			XElement xElement = new XElement("Widgets");
			xml.Add(xElement);
			foreach (IMfdWidget value in _widgets.Values)
			{
				XElement xElement2 = new XElement("Widget");
				xElement.Add(xElement2);
				value.SaveXml(xElement2);
			}
		}

		public void UpdatePartStyle()
		{
			MeshRenderer[] componentsInChildren;
			if (ScaleRoot != null)
			{
				componentsInChildren = ScaleRoot.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(renderer);
				}
				UnityEngine.Object.Destroy(ScaleRoot.gameObject);
				ScaleRoot = null;
			}
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/Prefabs/Mfd/" + Style.Id);
			EnabledScript.ProcessGameObject(gameObject);
			ScaleRoot = gameObject.transform;
			gameObject.transform.SetParent(base.gameObject.transform, worldPositionStays: false);
			gameObject.layer = base.gameObject.layer;
			gameObject.transform.localPosition = Vector3.zero;
			componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer2 in componentsInChildren)
			{
				base.PartScript.PartMaterialScript.AddRenderer(renderer2);
			}
			_screen = Utilities.FindFirstGameObjectMyselfOrChildren("Screen", base.gameObject);
			_screenNoBatteriesIcon = Utilities.FindFirstGameObjectMyselfOrChildren("ScreenNoBatteriesIcon", base.gameObject);
			_screenOff = Utilities.FindFirstGameObjectMyselfOrChildren("ScreenOff", base.gameObject);
			_screenOff?.SetActive(value: false);
			if (Game.InFlightScene)
			{
				StencilValue = GetNextStencilValue();
				if (base.PartScript.Data.Styles.ElementAt(0)?.Style?.Id == "HUD")
				{
					StencilValue = 50;
				}
				Canvas = _screen.GetComponentInChildren<Canvas>();
				Canvas[] componentsInChildren2 = GetComponentsInChildren<Canvas>(includeInactive: true);
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					componentsInChildren2[i].worldCamera = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.NearCamera;
				}
				CanvasTransform = Canvas.GetComponent<RectTransform>();
				_screenWidget = CreateWidget(MfdWidgetType.Screen, "_Screen") as ScreenWidgetScript;
				UpdateFlightMask(base.PartScript.Data.Config.RenderQueue == PartMeshRenderQueue.BeforeDepthMask);
			}
			UpdateSize();
		}

		public void UpdateSize()
		{
			Vector3 partScale = base.PartScript.Data.Config.PartScale;
			partScale.x *= base.Data.Width;
			partScale.z *= base.Data.Height;
			ScaleRoot.localScale = new Vector3(base.Data.Width, base.Data.Height, 1f);
			UpdateCanvasSize(CanvasTransform);
			UpdateCanvasSize(_screenOff?.GetComponentInChildren<RectTransform>());
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (base.Data.PowerUsage > 0f)
			{
				result.ValidatFuel(this, _battery, base.Data.PowerUsage * 0.1f);
			}
		}

		protected virtual void Awake()
		{
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			UpdatePartStyle();
		}

		private static int GetNextStencilValue()
		{
			_nextStencilValue++;
			if (_nextStencilValue > 100)
			{
				_nextStencilValue = 51;
			}
			return _nextStencilValue;
		}

		private void InitializeWidgetMaterial(WidgetScript widget)
		{
			Graphic[] componentsInChildren = widget.GetComponentsInChildren<Graphic>();
			foreach (Graphic graphic in componentsInChildren)
			{
				TextMeshProUGUI textMeshProUGUI = graphic as TextMeshProUGUI;
				string key = graphic.material.name;
				if (textMeshProUGUI != null)
				{
					key = textMeshProUGUI.fontMaterial.name;
				}
				Material material;
				if (_materialHash.ContainsKey(key))
				{
					material = _materialHash[key];
				}
				else
				{
					material = ((!(textMeshProUGUI != null)) ? UnityEngine.Object.Instantiate(graphic.material) : UnityEngine.Object.Instantiate(textMeshProUGUI.fontMaterial));
					material.SetInt("_Stencil", StencilValue);
					_materialHash[key] = material;
				}
				if (textMeshProUGUI != null)
				{
					textMeshProUGUI.fontMaterial = material;
				}
				else
				{
					graphic.material = material;
				}
			}
		}

		private void RestoreFromXml(XElement xml)
		{
			IEnumerable<XElement> enumerable = xml.Elements();
			foreach (XElement item in enumerable)
			{
				MfdWidgetType enumAttribute = Utilities.GetEnumAttribute(item, "type", MfdWidgetType.Sprite);
				string value = item.Attribute("name").Value;
				CreateWidget(enumAttribute, value);
			}
			foreach (XElement item2 in enumerable)
			{
				string value2 = item2.Attribute("name").Value;
				IMfdWidget widget = GetWidget(value2);
				string text = item2.Attribute("parent")?.Value;
				if (text != null)
				{
					widget.SetParent(GetWidget(text), worldPositionStays: false);
				}
				widget.RestoreFromXml(item2);
			}
		}

		private void UpdateCanvasSize(RectTransform canvasTransform)
		{
			if (canvasTransform != null)
			{
				canvasTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, base.Data.Width * base.Data.Resolution);
				canvasTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, base.Data.Height * base.Data.Resolution);
				canvasTransform.localScale = new Vector3(1f / (base.Data.Width * base.Data.Resolution), 1f / (base.Data.Height * base.Data.Resolution), 1f);
			}
		}

		private void UpdateFlightMask(bool beforeDepthMask)
		{
			MeshRenderer meshRenderer = Utilities.FindFirstGameObjectMyselfOrChildren("FlightMask", base.gameObject)?.GetComponent<MeshRenderer>();
			if (meshRenderer != null)
			{
				Material material = UnityEngine.Object.Instantiate(meshRenderer.sharedMaterial);
				if (beforeDepthMask)
				{
					material.renderQueue = 1991;
				}
				material.SetInt("_Stencil", StencilValue);
				meshRenderer.material = material;
			}
		}
	}
}
