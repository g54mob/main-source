using System;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class PartPropertyStep : TutorialStep
	{
		private PartPropertyChange _propertyChange;

		public bool? CuttingOutlinesState { get; set; }

		public PartPropertyStep(TutorialStepBuilderContext context, PartPropertyChange propertyChange, string stepText = null)
			: base(context, propertyChange.PartId, stepText)
		{
			_propertyChange = propertyChange;
			base.AppliedPartChanges.Add(propertyChange);
		}

		public PartPropertyStep(TutorialStepBuilderContext context, int partId, Type modifierType, string propertyName, object previousValue, object newValue, string newValueDisplayLabel, string stepText = null)
			: this(context, new PartPropertyChange(partId, modifierType, propertyName, previousValue, newValue, newValueDisplayLabel), stepText)
		{
		}

		public PartPropertyStep(TutorialStepBuilderContext context, string partName, Type modifierType, string propertyName, object previousValue, object newValue, string newValueDisplayLabel, string stepText = null)
			: this(context, new PartPropertyChange(context.GetPartIdByName(partName), modifierType, propertyName, previousValue, newValue, newValueDisplayLabel), stepText)
		{
		}

		public static PartPropertyStep Create<TModifier, TProperty>(TutorialStepBuilderContext context, string partName, string propertyName, TProperty previousValue, TProperty newValue, string newValueDisplayLabel, string stepText = null)
		{
			return new PartPropertyStep(context, PartPropertyChange.Create<TModifier, TProperty>(context, partName, propertyName, previousValue, newValue, newValueDisplayLabel), stepText);
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			DisableUIHighlight();
			PartModifierData partModifierData = base.Designer.Aircraft.Aircraft.Assembly.GetPartById(_propertyChange.PartId)?.GetModifier(_propertyChange.ModifierType);
			if (partModifierData == null)
			{
				base.InstructionText = "The part to be modified cannot be found. Please restart this tutorial step.";
				return;
			}
			if (_propertyChange.IsComplete(partModifierData))
			{
				CompleteStep();
				return;
			}
			if (CuttingOutlinesState.HasValue && CuttingOutlinesState.Value != base.Designer.DesignerUI.CuttingOutlinesVisible)
			{
				ClearHighlightedPart(base.TargetPart);
				if (HighlightUIElement("panel-view/toggle-cutting-outlines", new Vector2(5f, 5f)))
				{
					if (CuttingOutlinesState.Value)
					{
						base.InstructionText = "Enable the hole cutting outlines by [clicking:] the indicated button.[keyboard: You can also use the '[keybind:ToggleCuttingVisibility]' key.]";
					}
					else
					{
						base.InstructionText = "Disable the hole cutting outlines by [clicking:] the indicated button.[keyboard: You can also use the '[keybind:ToggleCuttingVisibility]' key.]";
					}
				}
				else if (HighlightUIElement("btn-panel-view", new Vector2(5f, 5f)))
				{
					if (CuttingOutlinesState.Value)
					{
						base.InstructionText = "We want to be able to see the outlines of our hole cutting parts for this step. Let's enable their outlines for now. First, [click:] the indicated button to open the view panel.";
					}
					else
					{
						base.InstructionText = "Our hole cutting parts may be in our way for this step. Let's disable their outlines for now. First, [click:] the indicated button to open the view panel.";
					}
				}
				return;
			}
			HighlightPart(base.TargetPart);
			GenericPartPropertiesScript propertiesByType = PartPropertiesPanelScript.GetPropertiesByType(_propertyChange.ModifierType);
			IConfigurableProperty configurableProperty = propertiesByType?.GetProperty(_propertyChange.PropertyName);
			if (base.Designer.Designer.SelectedPart?.Part != base.TargetPart)
			{
				base.InstructionText = "Select the part to be modified.";
				return;
			}
			if (!base.Designer.DesignerUI.Flyouts.PartProperties.IsOpen)
			{
				base.InstructionText = "[Click:] the 'Part Properties' button to open the part property options for this part.";
				HighlightUIElement("button-part-properties", new Vector2(5f, 5f));
				return;
			}
			if (propertiesByType.Header.Collapsed)
			{
				base.InstructionText = "Expand the '" + propertiesByType.Header.LabelText + "' section to show the property we are looking for.";
				HighlightUIElement(propertiesByType.Header.Widget, new Vector2(20f, 20f), highlightEvenIfInactive: false);
				return;
			}
			base.InstructionText = "Change the value of the '" + configurableProperty.GetDefaultLabel() + "' property to '" + _propertyChange.NewValueDisplayLabel + "'.";
			HighlightUIElement(configurableProperty.RootWidget, new Vector2(20f, 20f), highlightEvenIfInactive: false);
		}
	}
}
