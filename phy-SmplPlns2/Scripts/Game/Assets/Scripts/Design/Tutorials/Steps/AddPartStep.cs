using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class AddPartStep : TutorialStep
	{
		public enum SymmetrySetting
		{
			Any = 0,
			Disabled = 1,
			Enabled = 2
		}

		private List<int> _additionalPartsToHide;

		private List<int> _additionalPartsToHighlight;

		private DesignerPart _designerPart;

		private SymmetrySetting _symmetrySetting;

		public bool? CuttingOutlinesState { get; set; }

		public DesignerViewMode? DesignerViewMode { get; set; }

		public float PlacementDistanceThreshold { get; set; } = 0.25f;

		public AddPartStep(TutorialStepBuilderContext context, int[] partIds, SymmetrySetting symmetrySetting, string designerPartName, string stepText = null)
			: base(context, partIds[0], symmetrySetting == SymmetrySetting.Enabled, stepText)
		{
			base.AddedPartIds.Add(base.TargetPartId);
			if (symmetrySetting == SymmetrySetting.Enabled)
			{
				base.AddedPartIds.Add(base.TargetSymmetricPartId);
			}
			_symmetrySetting = symmetrySetting;
			_designerPart = Game.Instance.CachedDesignerParts.Parts.FirstOrDefault((DesignerPart x) => x.Name == designerPartName);
			if (_designerPart == null)
			{
				Debug.Log("Designer part '" + designerPartName + "' not found.");
			}
			_additionalPartsToHide = new List<int>();
			_additionalPartsToHighlight = new List<int>();
			for (int num = 1; num < partIds.Length; num++)
			{
				int num2 = partIds[num];
				if (num2 < 0)
				{
					continue;
				}
				if (!base.LoadedPartIds.Contains(num2))
				{
					base.LoadedPartIds.Add(num2);
				}
				if (!base.AddedPartIds.Contains(num2))
				{
					base.AddedPartIds.Add(num2);
				}
				_additionalPartsToHighlight.Add(num2);
				if (symmetrySetting != SymmetrySetting.Enabled)
				{
					continue;
				}
				int symmetricPartId = TutorialStep.GetSymmetricPartId(num2, base.CraftXml);
				if (symmetricPartId >= 0)
				{
					if (!base.LoadedPartIds.Contains(symmetricPartId))
					{
						base.LoadedPartIds.Add(symmetricPartId);
					}
					if (!base.AddedPartIds.Contains(symmetricPartId))
					{
						base.AddedPartIds.Add(symmetricPartId);
					}
					_additionalPartsToHide.Add(symmetricPartId);
				}
			}
		}

		public AddPartStep(TutorialStepBuilderContext context, string designerPartName, IEnumerable<string> partNames, SymmetrySetting symmetrySetting, string stepText = null)
			: this(context, partNames.Select((string x) => context.GetPartIdByName(x)).ToArray(), symmetrySetting, designerPartName, stepText)
		{
		}

		public AddPartStep(TutorialStepBuilderContext context, int partId, SymmetrySetting symmetrySetting, string designerPartName, string stepText = null)
			: this(context, new int[1] { partId }, symmetrySetting, designerPartName, stepText)
		{
		}

		public AddPartStep(TutorialStepBuilderContext context, string designerPartName, string partName, SymmetrySetting symmetrySetting, string stepText = null)
			: this(context, context.GetPartIdByName(partName), symmetrySetting, designerPartName, stepText)
		{
		}

		protected override void OnCraftInitialized(AircraftScript craft)
		{
			base.OnCraftInitialized(craft);
			ConfigurePartForNonInteractableHighlight(base.TargetPart);
			ConfigurePartForNonInteractableHighlight(base.TargetSymmetricPart);
			foreach (int item in _additionalPartsToHighlight)
			{
				PartData partById = craft.Aircraft.Assembly.GetPartById(item);
				if (partById != null)
				{
					ConfigurePartForNonInteractableHighlight(partById);
					HighlightPart(partById);
				}
			}
			foreach (int item2 in _additionalPartsToHide)
			{
				PartData partById2 = craft.Aircraft.Assembly.GetPartById(item2);
				if (partById2 != null)
				{
					ConfigurePartForNonInteractableHighlight(partById2);
					HidePart(partById2);
				}
			}
		}

		protected override void OnUpdate()
		{
			base.OnUpdate();
			DisableUIHighlight();
			HighlightAllTargetParts();
			List<PartScript> value;
			using (CollectionPool<List<PartScript>, PartScript>.Get(out value))
			{
				GetUserAddedParts(value);
				base.Tutorial.TutorialScript.UI.EnableEmptySpaceWidget(enable: false);
				if (value.Count == 0)
				{
					bool symmetryDisabledForNewParts = base.Designer.Designer.Symmetry.SymmetryDisabledForNewParts;
					if ((_symmetrySetting == SymmetrySetting.Enabled && symmetryDisabledForNewParts) || (_symmetrySetting == SymmetrySetting.Disabled && !symmetryDisabledForNewParts))
					{
						ClearAllTargetPartHighlights();
						if (base.Designer.SelectedPart != null)
						{
							base.InstructionText = "[Click:] empty space to deselect your part so we can toggle symmetry.";
							base.Tutorial.TutorialScript.UI.EnableEmptySpaceWidget(enable: true);
						}
						else if (symmetryDisabledForNewParts)
						{
							base.InstructionText = "We want this part mirrored. [Click:] the symmetry button to turn it on.[keyboard: Shortcut: '[keybind:SymmetryInitialStateToggle]']";
							HighlightUIElement("btn-designer-symmetry", new Vector2(5f, 5f));
						}
						else
						{
							base.InstructionText = "We don't want this part mirrored. [Click:] the symmetry button to turn it off.[keyboard: Shortcut: '[keybind:SymmetryInitialStateToggle]']";
							HighlightUIElement("btn-designer-symmetry", new Vector2(5f, 5f));
						}
					}
					else if (CuttingOutlinesState.HasValue && CuttingOutlinesState.Value != base.Designer.DesignerUI.CuttingOutlinesVisible)
					{
						ClearAllTargetPartHighlights();
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
					}
					else if (DesignerViewMode.HasValue && DesignerViewMode.Value != base.Designer.Designer.ViewMode)
					{
						ClearAllTargetPartHighlights();
						DesignerViewMode viewMode = base.Designer.Designer.ViewMode;
						DesignerViewMode value2 = DesignerViewMode.Value;
						DesignerViewMode num = ((value2 != Assets.Scripts.Design.DesignerViewMode.Normal) ? value2 : viewMode);
						string text = ((num == Assets.Scripts.Design.DesignerViewMode.Ghost) ? "button-ghost-view" : "button-powertrain-view");
						string text2 = ((num == Assets.Scripts.Design.DesignerViewMode.Ghost) ? "x-ray" : "powertrain");
						string text3 = ((value2 != Assets.Scripts.Design.DesignerViewMode.Normal) ? "Enable" : "Disable");
						if (HighlightUIElement("panel-view/" + text, new Vector2(5f, 5f)))
						{
							base.InstructionText = text3 + " " + text2 + " view by [clicking:] the indicated button.";
						}
						else if (HighlightUIElement("btn-panel-view", new Vector2(5f, 5f)))
						{
							base.InstructionText = "We need to " + text3.ToLower() + " " + text2 + " view for this step. First, [click:] the indicated button to open the view panel.";
						}
					}
					else if (!base.Designer.DesignerUI.Flyouts.PartList.IsOpen)
					{
						base.InstructionText = "[Click:] the 'Add Parts' button to open the parts list.";
						HighlightUIElement("btn-add-parts", new Vector2(5f, 5f));
					}
					else
					{
						string text4 = (string.IsNullOrEmpty(_designerPart.Header) ? _designerPart.Category : _designerPart.Header);
						if (HighlightUIElement("flyout-part-list/go:PartButton-" + _designerPart.Name, Vector2.zero))
						{
							base.InstructionText = "[Click:] and drag the '" + _designerPart.Name + "' part from the part list and add it to your craft at the indicated position.";
						}
						else if (HighlightUIElement("flyout-part-list/go:PartHeader-" + text4, new Vector2(5f, 5f)))
						{
							base.InstructionText = "Select the '" + text4 + "' category in the part list flyout on the left to expand its parts list.";
						}
						else if (HighlightUIElement("flyout-part-list/go:PartButton-" + _designerPart.Category, Vector2.zero))
						{
							base.InstructionText = "Select the '" + _designerPart.Category + "' category in the part list flyout on the left.";
						}
						else if (HighlightUIElement("flyout-part-list/flyout-header", Vector2.zero))
						{
							base.InstructionText = "[Click:] the back button in the part list header to go back to the part categories, then select the '" + _designerPart.Category + "' category.";
						}
					}
					return;
				}
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				foreach (PartScript item in value)
				{
					if (!(item.Part.PartType.PartTypeId == base.TargetPart.PartType.PartTypeId))
					{
						continue;
					}
					flag2 = true;
					flag |= base.Designer.SelectedPart == item;
					flag4 = _symmetrySetting == SymmetrySetting.Any || (_symmetrySetting == SymmetrySetting.Enabled && !item.Part.SymmetryDisabled) || (_symmetrySetting == SymmetrySetting.Disabled && item.Part.SymmetryDisabled);
					if (!item.ConnectedToMainCockpit)
					{
						continue;
					}
					flag3 = true;
					ControlSurfacePartScript modifier = item.GetModifier<ControlSurfacePartScript>();
					if (modifier != null)
					{
						JWingScript connectedWing = modifier.ConnectedWing;
						JWingScript jWingScript = base.TargetPart.PartScript.GetModifier<ControlSurfacePartScript>()?.ConnectedWing;
						if ((!(connectedWing == null) || !(jWingScript == null)) && Utilities.CompareVector3s(connectedWing.transform.position, jWingScript.transform.position, 0.1f))
						{
							flag5 = true;
							break;
						}
					}
					else if (Utilities.CompareVector3s(item.transform.position, base.TargetPart.PartScript.transform.position, PlacementDistanceThreshold))
					{
						flag5 = true;
						break;
					}
				}
				if (flag5)
				{
					if (flag4)
					{
						CompleteStep();
					}
					else if (flag && _symmetrySetting == SymmetrySetting.Enabled)
					{
						base.InstructionText = "The part is in the correct position, but it has symmetry disabled. [Click:] the symmetry button on the right[keyboard: or hit the '[keybind:SymmetryMultiPartToggle]' key] to enable symmetry and automatically create and/or link the symmetric part.";
						HighlightUIElement("btn-part-symmetry", new Vector2(5f, 5f));
					}
					else
					{
						base.InstructionText = "The part is in the correct position, but its symmetry mode is not correct. Disconnect the part, change its symmetry mode, then reconnect the part.";
					}
				}
				else if (flag2 && !flag4)
				{
					if (flag)
					{
						base.InstructionText = "You have the correct part, but its symmetry mode is not correct. [Click:] the symmetry button on the right[keyboard: or hit the '[keybind:SymmetryMultiPartToggle]' key] to " + ((_symmetrySetting == SymmetrySetting.Enabled) ? "enable" : "disable") + " symmetry for this part.";
						HighlightUIElement("btn-part-symmetry", new Vector2(5f, 5f));
					}
					else
					{
						base.InstructionText = "You have the correct part, but its symmetry mode is not correct. First, select the part to change its symmetry mode.";
					}
				}
				else if (flag3)
				{
					base.InstructionText = "You have the right part, but it's not in the right place. Try and move it to the indicated spot.";
				}
				else if (flag2)
				{
					base.InstructionText = "Now drag and drop this part on to the craft at the indicated position.";
				}
				else
				{
					HighlightUIElement("drop-zone-trash", new Vector2(5f, 5f));
					base.InstructionText = "It looks like you have the wrong part. You can drag it up to the trash in the top right to delete it.[keyboard: You can also select the part and hit the '[keybind:DeletePart]' key.]";
				}
			}
		}

		private void ClearAllTargetPartHighlights()
		{
			ClearHighlightedPart(base.TargetPart);
			Assembly assembly = base.Designer.Designer.Aircraft.Aircraft.Assembly;
			foreach (int item in _additionalPartsToHighlight)
			{
				PartData partById = assembly.GetPartById(item);
				if (partById != null)
				{
					ClearHighlightedPart(partById);
				}
			}
		}

		private void HighlightAllTargetParts()
		{
			HighlightPart(base.TargetPart);
			Assembly assembly = base.Designer.Designer.Aircraft.Aircraft.Assembly;
			foreach (int item in _additionalPartsToHighlight)
			{
				PartData partById = assembly.GetPartById(item);
				if (partById != null)
				{
					HighlightPart(partById);
				}
			}
		}
	}
}
