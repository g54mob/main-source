using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using ModApi.Design;
using ModApi.Levels;
using ModApi.Math;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class LevelDesignerUIController : XmlLayoutController, ILevelUI, IXmlLayoutController
	{
		private XmlElement _headerPanel;

		private XmlElement _infoPanel;

		private bool _infoPanelPinned;

		private XmlElement _levelDescription;

		public bool CustomUI { get; private set; }

		public bool InfoPanelPinned
		{
			get
			{
				return _infoPanelPinned;
			}
			set
			{
				if (_infoPanelPinned != value)
				{
					_infoPanelPinned = value;
					if (_infoPanelPinned)
					{
						_headerPanel.AddClass("pinned");
					}
					else
					{
						_headerPanel.RemoveClass("pinned");
					}
				}
			}
		}

		public ILevel Level { get; private set; }

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public static LevelDesignerUIController CreateUI(RectTransform parent, ILevel level)
		{
			string uIXml = level.GetUIXml();
			bool flag = !string.IsNullOrWhiteSpace(uIXml);
			BuildUserInterfaceXmlRequest request = (flag ? BuildUserInterfaceXmlRequest.CreateFromXml(uIXml, level.LevelData.Id) : BuildUserInterfaceXmlRequest.CreateFromResource("Ui/Xml/Design/LevelUIDefault"));
			LevelDesignerUIController levelDesignerUIController = UiUtilities.CreateUiGameObject("LevelUIController", parent).AddComponent<LevelDesignerUIController>();
			levelDesignerUIController.EventTarget = (flag ? ((object)level) : ((object)levelDesignerUIController));
			levelDesignerUIController.CustomUI = flag;
			levelDesignerUIController.Level = level;
			Game.Instance.UserInterface.BuildUserInterfaceFromRequest(request, levelDesignerUIController.xmlLayout);
			level.Initialize(levelDesignerUIController);
			return levelDesignerUIController;
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			base.xmlLayout.GetElementById("level-title").SetText(Level.LevelData.DisplayName);
			_levelDescription = base.xmlLayout.GetElementById("level-description");
			_headerPanel = base.xmlLayout.GetElementById("header-panel");
			_infoPanel = base.xmlLayout.GetElementById("info-panel");
		}

		public void OnSceneLoaded()
		{
		}

		public void OnSceneUnloading()
		{
		}

		public void ShowMessage(string message, float duration = 5f)
		{
			Game.Instance.Designer?.ShowMessage(message, duration);
		}

		protected virtual void OnDisable()
		{
			IDesigner designer = Game.Instance.Designer;
			designer.CraftStructureChanged -= OnCraftStructureChanged;
			designer.CraftLoaded -= OnCraftStructureChanged;
		}

		protected virtual void OnEnable()
		{
			IDesigner designer = Game.Instance.Designer;
			designer.CraftStructureChanged += OnCraftStructureChanged;
			designer.CraftLoaded += OnCraftStructureChanged;
		}

		private string GetTotalCraftFuelString()
		{
			double num = 0.0;
			foreach (PartData part in Game.Instance.Designer.CraftScript.Data.Assembly.Parts)
			{
				FuelTankData modifier = part.GetModifier<FuelTankData>();
				if (modifier != null && modifier.FuelType != FuelType.Battery && !part.PartScript.Disconnected)
				{
					num += modifier.Fuel;
				}
			}
			return Units.GetVolumeString((float)num);
		}

		private void OnCraftStructureChanged()
		{
			UpdateDescriptionText();
		}

		private void OnExitClicked()
		{
			Game.Instance.Designer.Exit();
		}

		private void OnMouseClickPanel()
		{
			InfoPanelPinned = !InfoPanelPinned;
			if (InfoPanelPinned)
			{
				if (!_infoPanel.Visible)
				{
					_infoPanel.Show();
				}
			}
			else if (_infoPanel.Visible)
			{
				_infoPanel.Hide();
			}
		}

		private void OnMouseEnterPanel()
		{
			if (!_infoPanel.Visible)
			{
				_infoPanel.Show();
			}
		}

		private void OnMouseExitPanel()
		{
			if (!InfoPanelPinned)
			{
				_infoPanel.Hide();
			}
		}

		private void UpdateDescriptionText()
		{
			if (Level.DisplayCraftFuelInDesigner)
			{
				_levelDescription.SetText(Level.LevelData.Description + "\n\nTotal Fuel: " + GetTotalCraftFuelString());
			}
			else
			{
				_levelDescription.SetText(Level.LevelData.Description);
			}
		}
	}
}
