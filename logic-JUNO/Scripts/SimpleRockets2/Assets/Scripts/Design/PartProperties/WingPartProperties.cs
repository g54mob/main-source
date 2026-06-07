using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using Assets.Scripts.Design.Tools.Wing;
using ModApi.Common.Extensions;
using ModApi.Craft.Parts;
using ModApi.Design.PartProperties;
using ModApi.Scripts.State.Validation;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.PartProperties
{
	public class WingPartProperties : PartPropertiesScript
	{
		private Button _addControlSurfaceButton;

		private Dictionary<GenericPartPropertiesScript, Button> _deleteButtons;

		public override bool HandlesMultipleModifiers => true;

		protected WingScript CurrentWing { get; private set; }

		public override void OnPartDeselected(IPartScript part)
		{
			CurrentWing = null;
		}

		public override bool OnPartSelected(IPartScript part)
		{
			CurrentWing = part.GetModifier<WingScript>();
			bool result = false;
			WingScript currentWing = CurrentWing;
			if ((object)currentWing != null && currentWing.Data.AllowControlSurfaces)
			{
				UpdateControlSurfaces();
				result = true;
			}
			return result;
		}

		protected override void OnInitialized()
		{
			_deleteButtons = new Dictionary<GenericPartPropertiesScript, Button>();
			XmlElement xmlElement = (base.Flyout as PartPropertiesFlyoutScript).CloneTemplateElement("template-button", base.transform);
			_addControlSurfaceButton = xmlElement.GetElementByInternalId<Button>("button");
			_addControlSurfaceButton.name = "PartProperties.AddControlSurface";
			xmlElement.GetElementByInternalId<TextMeshProUGUI>("label").text = "Add Control Surface";
			_addControlSurfaceButton.onClick.AddListener(AddControlSurfaceButtonClicked);
		}

		private void AddControlSurfaceButtonClicked()
		{
			CurrentWing.GetNextControlSurfaceSpot(out var start, out var length);
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (validator.IsCareerMode && (float)CurrentWing.ControlSurfaces.Count >= validator.ItemValue("Wing.ControlSurfaces"))
			{
				base.Designer.ShowMessage("You have reached your limit of control surfaces, you can unlock more in the Tech Tree");
			}
			else if (length > 0)
			{
				CurrentWing.AddControlSurface(start, length, "Auto", 35, invert: false);
				PartPropertiesFlyoutScript.ChangesSinceLastUndoStep = true;
				base.Designer.ShowMessage("Control surface added");
				base.Flyout.RefreshUI();
			}
			else
			{
				base.Designer.ShowMessage("No room for additional control surfaces");
			}
		}

		private Button AddDeleteButton(GenericPartPropertiesScript script)
		{
			Button headerDeleteButton = script.HeaderDeleteButton;
			if (headerDeleteButton != null)
			{
				headerDeleteButton.onClick.AddListener(delegate
				{
					DeleteButtonClicked(script);
				});
			}
			return headerDeleteButton;
		}

		private void DeleteButtonClicked(GenericPartPropertiesScript script)
		{
			ControlSurfaceScript script2 = ((ControlSurfaceData)script.CurrentPartModifier.PartModifierData).Script;
			_ = script2.PartScript;
			CurrentWing.DeleteControlSurface(script2);
			CurrentWing.UpdateWingShape();
			base.Designer.ShowMessage("Deleted Control Surface");
			base.Designer.CreateUndoStep();
			base.Flyout.RefreshUI();
			base.Designer.DeselectTool(base.Designer.GetTool<ControlSurfaceTool>());
		}

		private void UpdateControlSurfaces()
		{
			foreach (Transform item in base.transform.parent)
			{
				GenericPartPropertiesScript component = item.GetComponent<GenericPartPropertiesScript>();
				if (!(component == null) && component.ModifierType == typeof(ControlSurfaceData) && !_deleteButtons.ContainsKey(component))
				{
					Button button = AddDeleteButton(component);
					if (button == null)
					{
						this.LogError("Unable to create a delete button for a control surface.");
						continue;
					}
					button.gameObject.SetActive(value: true);
					_deleteButtons.Add(component, button);
				}
			}
		}
	}
}
