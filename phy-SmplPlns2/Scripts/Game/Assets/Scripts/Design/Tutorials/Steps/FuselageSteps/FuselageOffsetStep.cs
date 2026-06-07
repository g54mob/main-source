using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public abstract class FuselageOffsetStep : FuselageShapeStep
	{
		protected class FuselageOffsetChange : ITutorialStepPartChange
		{
			private float _newValue;

			private int _partId;

			private float _previousValue;

			private int _vectorValueIndex;

			public FuselageOffsetChange(int partId, int vectorValueIndex, float previousValue, float newValue)
			{
				_partId = partId;
				_vectorValueIndex = vectorValueIndex;
				_previousValue = previousValue;
				_newValue = newValue;
			}

			public void Apply(AircraftData craft)
			{
				SetOffset(craft, _newValue);
			}

			public void Revert(AircraftData craft)
			{
				SetOffset(craft, _previousValue);
			}

			private void SetOffset(AircraftData craft, float value)
			{
				JFuselageData jFuselageData = craft.Assembly.GetPartById(_partId)?.GetModifier<JFuselageData>();
				if (jFuselageData == null)
				{
					return;
				}
				List<JFuselageData> value2;
				using (CollectionPool<List<JFuselageData>, JFuselageData>.Get(out value2))
				{
					SymmetryUtility.GetSymmetricModifiers(jFuselageData, includeCurrentModifier: true, value2);
					foreach (JFuselageData item in value2)
					{
						Vector3 offset = item.Offset;
						offset[_vectorValueIndex] = value;
						item.Offset = offset;
						item.RaiseChange();
					}
				}
			}
		}

		private float _targetValue;

		private int _vectorOffsetIndex;

		public float OffsetTolerance { get; set; } = 0.075f;

		public float PositionTolerance { get; set; } = 0.075f;

		private FuselageEndType? EndType { get; }

		public FuselageOffsetStep(TutorialStepBuilderContext context, int partId, FuselageSectionType type, int vectorOffsetIndex, float previousValue, float newValue, string stepText = null)
			: base(context, partId, (vectorOffsetIndex == 2) ? FuselageSectionType.Middle : type, null, highlightGoalFuselage: true, stepText)
		{
			base.AppliedPartChanges.Add(new FuselageOffsetChange(partId, vectorOffsetIndex, previousValue, newValue));
			if (type != FuselageSectionType.Middle && vectorOffsetIndex == 2)
			{
				Vector3 change = new Vector3(0f, 0f, (newValue - previousValue) * 0.5f * (float)((type != FuselageSectionType.Back) ? 1 : (-1)));
				base.AppliedPartChanges.Add(new PartPositionRelativeChange(partId, change, applyPartRotation: true));
			}
			EndType = ((type == FuselageSectionType.Middle) ? ((FuselageEndType?)null) : new FuselageEndType?((type == FuselageSectionType.Front) ? FuselageEndType.Front : FuselageEndType.Back));
			_vectorOffsetIndex = vectorOffsetIndex;
			_targetValue = newValue;
		}

		public FuselageOffsetStep(TutorialStepBuilderContext context, string partName, FuselageSectionType type, int vectorOffsetIndex, float previousValue, float newValue, string stepText = null)
			: this(context, context.GetPartIdByName(partName), type, vectorOffsetIndex, previousValue, newValue, stepText)
		{
		}

		protected override bool IsFuselageChangeComplete()
		{
			if (base.FuselageData?.Part.PartScript == null || base.GoalFuselage?.Part.PartScript == null)
			{
				return false;
			}
			bool num = Utilities.CompareVector3s(base.FuselageData.Offset, base.GoalFuselage.Offset, OffsetTolerance);
			bool flag = Utilities.CompareVector3s(base.FuselageData.Part.PartScript.transform.position, base.GoalFuselage.Part.PartScript.transform.position, PositionTolerance);
			return num && flag;
		}

		protected override void OnFuselageStepUpdate()
		{
			if (IsFuselageChangeComplete())
			{
				CompleteStep();
			}
			else if (_vectorOffsetIndex == 0)
			{
				base.InstructionText = $"Adjust the run of the fuselage to match the indicated shape by using the spinner control on the left, setting the value to '{_targetValue}'.";
				HighlightUIElement(base.Flyout.Widget, "spinner-run", new Vector2(25f, 25f));
			}
			else if (_vectorOffsetIndex == 1)
			{
				base.InstructionText = $"Adjust the rise of the fuselage to match the indicated shape by using the spinner control on the left, setting the value to '{_targetValue}'.";
				HighlightUIElement(base.Flyout.Widget, "spinner-rise", new Vector2(25f, 25f));
			}
			else if (_vectorOffsetIndex == 2)
			{
				if (EndType == FuselageEndType.Front)
				{
					base.InstructionText = "Adjust the length of the fuselage to match the indicated shape by [clicking:] and dragging the blue arrow at the front of the fuselage.";
					base.HighlightedGizmo = JFuselageGizmoController.FuselageGizmoID.FrontLength;
				}
				else if (EndType == FuselageEndType.Back)
				{
					base.InstructionText = "Adjust the length of the fuselage to match the indicated shape by [clicking:] and dragging the blue arrow at the back of the fuselage.";
					base.HighlightedGizmo = JFuselageGizmoController.FuselageGizmoID.BackLength;
				}
			}
		}
	}
}
