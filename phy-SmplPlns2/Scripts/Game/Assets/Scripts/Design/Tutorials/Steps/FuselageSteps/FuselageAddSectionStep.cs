using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Symmetry;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public class FuselageAddSectionStep : FuselageShapeStep
	{
		private PartData _addedPart;

		private int _addedPartId;

		public FuselageAddSectionStep(TutorialStepBuilderContext context, int partId, int addedPartId, FuselageEndType endType, string stepText = null)
			: base(context, partId, (endType == FuselageEndType.Front) ? FuselageSectionType.Front : FuselageSectionType.Back, null, highlightGoalFuselage: true, stepText)
		{
			_addedPartId = addedPartId;
			base.LoadedPartIds.Add(addedPartId);
			int? symmetricPartIdOrNull = context.GetSymmetricPartIdOrNull(addedPartId);
			if (symmetricPartIdOrNull.HasValue)
			{
				base.LoadedPartIds.Add(symmetricPartIdOrNull.Value);
			}
		}

		public FuselageAddSectionStep(TutorialStepBuilderContext context, string partName, string addedPartName, FuselageEndType endType, string stepText = null)
			: this(context, context.GetPartIdByName(partName), context.GetPartIdByName(addedPartName), endType, stepText)
		{
		}

		protected override bool IsFuselageChangeComplete()
		{
			if (_addedPart.PartScript == null)
			{
				return false;
			}
			List<PartScript> value;
			using (CollectionPool<List<PartScript>, PartScript>.Get(out value))
			{
				GetUserAddedParts(value);
				foreach (PartScript item in value)
				{
					if (item.Part.PartType.PartTypeId != _addedPart.PartType.PartTypeId)
					{
						continue;
					}
					bool flag = false;
					foreach (PartConnection partConnection in item.Part.PartConnections)
					{
						if (partConnection.GetOtherPart(item.Part) == base.TargetPart)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return false;
					}
					return Utilities.CompareVector3s(item.transform.position, _addedPart.PartScript.transform.position, 0.5f);
				}
				return false;
			}
		}

		protected override void OnFuselageStepUpdate()
		{
			base.InstructionText = "[Click:] the 'Add Section' button to add a new section to the end of this fuselage";
			HighlightUIElement(base.Flyout.Widget, "add-section-button", new Vector2(15f, 15f));
		}

		protected override void OnStart()
		{
			base.OnStart();
			_addedPart = base.Designer.Aircraft.Aircraft.Assembly.GetPartById(_addedPartId);
			if (_addedPart == null)
			{
				throw new Exception($"Could not find part with ID {_addedPartId} in the aircraft assembly.");
			}
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				SymmetryUtility.FindSymmetricParts(_addedPart, includeSelf: true, value);
				foreach (PartData item in value)
				{
					ConfigurePartForNonInteractableHighlight(item);
					HidePart(item);
				}
			}
		}
	}
}
