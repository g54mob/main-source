using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public class FuselageCuttingStep : FuselageShapeStep
	{
		protected class FuselageCuttingChange : ITutorialStepPartChange
		{
			private bool _isFront;

			private JFuselageData.CuttingParams _newValues;

			private int _partId;

			private JFuselageData.CuttingParams _previousValues;

			public FuselageCuttingChange(int partId, bool isFront, JFuselageData.CuttingParams previousValues, JFuselageData.CuttingParams newValues)
			{
				_partId = partId;
				_isFront = isFront;
				_previousValues = previousValues;
				_newValues = newValues;
			}

			public void Apply(AircraftData craft)
			{
				SetCutting(craft, _newValues);
			}

			public void Revert(AircraftData craft)
			{
				SetCutting(craft, _previousValues);
			}

			private void SetCutting(AircraftData craft, JFuselageData.CuttingParams values)
			{
				JFuselageData jFuselageData = craft.Assembly.GetPartById(_partId)?.GetModifier<JFuselageData>();
				if (jFuselageData != null)
				{
					int endSlice = jFuselageData.GetEndSlice(_isFront);
					jFuselageData.SetCutting(endSlice, values);
					JFuselageData mirroredModifier = SymmetryUtility.GetMirroredModifier(jFuselageData);
					if (mirroredModifier != null)
					{
						values.Mirror();
						endSlice = mirroredModifier.GetEndSlice(_isFront);
						mirroredModifier.SetCutting(endSlice, values);
					}
				}
			}
		}

		private JFuselageData.CuttingParams _startValues;

		private JFuselageData.CuttingParams _targetValues;

		public FuselageCuttingStep(TutorialStepBuilderContext context, int partId, FuselageEndType endType, JFuselageData.CuttingParams? startValues, JFuselageData.CuttingParams? targetValues, string stepText = null)
			: base(context, partId, (endType == FuselageEndType.Front) ? FuselageSectionType.Front : FuselageSectionType.Back, FuselageModificationType.Cutting, highlightGoalFuselage: false, stepText)
		{
			_startValues = startValues.GetValueOrDefault();
			_targetValues = targetValues.GetValueOrDefault();
			base.AppliedPartChanges.Add(new FuselageCuttingChange(partId, endType == FuselageEndType.Front, _startValues, _targetValues));
		}

		public FuselageCuttingStep(TutorialStepBuilderContext context, string partName, FuselageEndType endType, JFuselageData.CuttingParams? startValues, JFuselageData.CuttingParams? targetValues, string stepText = null)
			: this(context, context.GetPartIdByName(partName), endType, startValues, targetValues, stepText)
		{
		}

		protected override bool IsFuselageChangeComplete()
		{
			if (base.FuselageData == null)
			{
				return false;
			}
			if (IsCuttingParamAtTarget(0) && IsCuttingParamAtTarget(2) && IsCuttingParamAtTarget(3))
			{
				return IsCuttingParamAtTarget(1);
			}
			return false;
		}

		protected override void OnFuselageStepUpdate()
		{
			JFuselageTool.SliceSelection slice = base.Tool.Slice;
			if (slice == null)
			{
				base.InstructionText = "An error occurred in the tutorial. Please select the correct end of the fuselage to continue. Restart or skip this step if you continue to experience issues.";
				return;
			}
			bool skip = false;
			skip = CuttingParamStepUpdate(slice, 0, "Top", skip);
			skip = CuttingParamStepUpdate(slice, 2, "Bottom", skip);
			skip = CuttingParamStepUpdate(slice, 3, "Left", skip);
			if (!CuttingParamStepUpdate(slice, 1, "Right", skip))
			{
				CompleteStep();
			}
		}

		private bool CuttingParamStepUpdate(JFuselageTool.SliceSelection slice, int cuttingParamIndex, string parameterName, bool skip)
		{
			if (skip)
			{
				return true;
			}
			if (!IsCuttingParamAtTarget(cuttingParamIndex))
			{
				slice.GetCutting(cuttingParamIndex, out var minCutting, out var _);
				base.InstructionText = ((!_targetValues[cuttingParamIndex].HasValue) ? $"Change the {parameterName} cutting parameter to {minCutting * 100f:F0}% by sliding the indicated slider all the way to the left." : $"Change the {parameterName} cutting parameter to {_targetValues[cuttingParamIndex] * (decimal?)100:F0}% using the indicated slider.");
				HighlightUIElement(base.Flyout.Widget, "cutting-" + parameterName.ToLower(), new Vector2(25f, 25f));
				return true;
			}
			return false;
		}

		private bool IsCuttingParamAtTarget(int cuttingParamIndex)
		{
			if (base.FuselageData == null)
			{
				return false;
			}
			int endSlice = base.FuselageData.GetEndSlice(base.SectionType == FuselageSectionType.Front);
			decimal? num = base.FuselageData.GetCutting(endSlice)[cuttingParamIndex];
			decimal? num2 = _targetValues[cuttingParamIndex];
			if (!num.HasValue || !num2.HasValue)
			{
				if (!num.HasValue)
				{
					return !num2.HasValue;
				}
				return false;
			}
			return Utilities.CompareFloats((float)num.Value, (float)num2.Value, 0.02f);
		}
	}
}
