using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Mfd;
using Assets.Scripts.Levels;
using Assets.Scripts.Vizzy.UI;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Levels;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerUiScript : MonoBehaviour, IDesignerUi
	{
		[SerializeField]
		private DesignerScript _designer;

		private DesignerUiController _designerUiController;

		[SerializeField]
		private GameObject _designerUiControllerGameObject;

		[SerializeField]
		private DesignerWidgetScript _designerWidget;

		private IFlyout _selectedFlyout;

		public DesignerScript Designer => _designer;

		IDesigner IDesignerUi.Designer => _designer;

		public DesignerUiController DesignerUiController => _designerUiController;

		public DesignerWidgetScript DesignerWidget => _designerWidget;

		public IFingerTool FingerTool => DesignerUiController.FingerTool;

		public IFlyouts Flyouts => _designerUiController.Flyouts;

		public bool GhostViewEnabled { get; set; }

		public IFlyout SelectedFlyout
		{
			get
			{
				return _selectedFlyout;
			}
			set
			{
				if (_selectedFlyout != value)
				{
					IFlyout selectedFlyout = _selectedFlyout;
					_selectedFlyout = value;
					if (selectedFlyout != null && selectedFlyout.IsOpen)
					{
						selectedFlyout.Close();
					}
					if (_selectedFlyout != null && !_selectedFlyout.IsOpen)
					{
						_selectedFlyout.Open();
						DesignerUiController.PartPropertiesHintVisible = false;
					}
					if (this.SelectedFlyoutChanged != null)
					{
						this.SelectedFlyoutChanged(_selectedFlyout);
					}
				}
			}
		}

		public RectTransform Transform { get; private set; }

		public bool Visible
		{
			get
			{
				return DesignerUiController.gameObject.activeSelf;
			}
			set
			{
				if (Game.Instance.LevelManager?.CurrentLevel?.UI != null)
				{
					Game.Instance.LevelManager.CurrentLevel.UI.Visible = value;
				}
				Game.Instance.UserInterface.InspectorPanelsVisible = value;
				DesignerUiController.gameObject.SetActive(value);
			}
		}

		public event FlyoutDelegate SelectedFlyoutChanged;

		public void CloseFlyout(IFlyout flyout)
		{
			if (SelectedFlyout == flyout)
			{
				SelectedFlyout = null;
			}
		}

		public void EditFlightProgram(PartData part)
		{
			if (!(part != null))
			{
				return;
			}
			FlightProgramData flightProgram = part.GetModifier<FlightProgramData>();
			if (flightProgram == null)
			{
				flightProgram = FlightProgramData.Create(part);
				flightProgram.PowerConsumptionPerInstruction = 0.01f;
				flightProgram.BroadcastPowerConsumptionPerByte = 0.1f;
			}
			if (flightProgram != null)
			{
				XElement flightProgramXml = flightProgram.FlightProgramXml;
				VizzyUIScript vizzyUIScript = Game.Instance.ResourceLoader.InstantiatePrefab<VizzyUIScript>("Ui/Vizzy/Vizzy");
				Designer.InputEnabled = false;
				vizzyUIScript.Initialize(Game.Instance.UserInterface.Transform, flightProgramXml, part.GetModifier<MfdData>() != null, delegate(XElement xml)
				{
					Designer.CreateUndoStep();
					flightProgram.FlightProgramXml = xml;
				});
				vizzyUIScript.Closed += delegate
				{
					Designer.InputEnabled = true;
				};
			}
			else
			{
				ShowMessage($"Unable to find a flight program for the part {part.Name}.");
			}
		}

		public void Initialize()
		{
			Transform = GetComponent<RectTransform>();
			XmlLayout xmlLayout = _designerUiControllerGameObject.AddComponent<XmlLayout>();
			_designerUiController = _designerUiControllerGameObject.AddComponent<DesignerUiController>();
			_designerUiController.Initialize(this);
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Design/DesignerUi", xmlLayout);
			ILevel currentLevel = Game.Instance.LevelManager.CurrentLevel;
			if (currentLevel != null)
			{
				LevelDesignerUIController.CreateUI(Transform, currentLevel);
			}
		}

		public void OnBeginFlightClicked()
		{
			Designer.BeginFlight();
		}

		public void SetMainPanelVisibility(bool visible)
		{
			if (visible)
			{
				DesignerUiController.MainPanel.SetAndApplyAttribute("opacity", "1");
			}
			else
			{
				DesignerUiController.MainPanel.SetAndApplyAttribute("opacity", "0");
			}
		}

		public void ShowMessage(string message, float time = 7f)
		{
			_designerUiController.ShowMessage(message, time);
		}

		public void ShowValidationPanel()
		{
			SelectedFlyout = Flyouts.Preflight;
			Flyouts.Preflight.Transform.GetComponentInChildren<PreflightPanelScript>().ShowValidationPanel();
		}

		public void ToggleFlyout(IFlyout flyout)
		{
			if (SelectedFlyout != flyout)
			{
				SelectedFlyout = flyout;
			}
			else
			{
				SelectedFlyout = null;
			}
		}

		protected virtual void Start()
		{
			foreach (IFlyout item in Flyouts.All)
			{
				item.Close();
			}
			Designer.CraftStructureChanged += OnCraftStructureChanged;
			Designer.CraftLoaded += OnCraftLoaded;
		}

		private void OnCraftLoaded()
		{
		}

		private void OnCraftStructureChanged()
		{
		}

		private void OnDestroy()
		{
			Designer.CraftStructureChanged -= OnCraftStructureChanged;
		}
	}
}
