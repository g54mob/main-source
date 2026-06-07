using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Design.Tutorials.Steps.PartChanges;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;

namespace Assets.Scripts.Design.Tutorials.Steps.FuselageSteps
{
	public abstract class FuselageSizeStep : FuselageShapeStep
	{
		protected enum FuselageSizeType
		{
			Width = 0,
			Height = 1
		}

		protected class FuselageSizeChange : ITutorialStepPartChange
		{
			private FuselageEndType _endType;

			private float _newValue;

			private int _partId;

			private float _previousValue;

			private FuselageSizeType _sizeType;

			public FuselageSizeChange(int partId, FuselageEndType endType, FuselageSizeType sizeType, float previousValue, float newValue)
			{
				_partId = partId;
				_endType = endType;
				_sizeType = sizeType;
				_previousValue = previousValue;
				_newValue = newValue;
			}

			public void Apply(AircraftData craft)
			{
				SetValue(craft, _newValue);
			}

			public void Revert(AircraftData craft)
			{
				SetValue(craft, _previousValue);
			}

			private void SetValue(AircraftData craft, float value)
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
						if (_endType == FuselageEndType.Front)
						{
							SectionParams sectionB = item.SectionB;
							sectionB.Size[(int)_sizeType] = value;
							item.SectionB = sectionB;
						}
						else
						{
							SectionParams sectionA = item.SectionA;
							sectionA.Size[(int)_sizeType] = value;
							item.SectionA = sectionA;
						}
						item.RaiseChange();
					}
				}
			}
		}

		public float PositionTolerance { get; set; } = 0.075f;

		public float SizeTolerance { get; set; } = 0.075f;

		protected FuselageEndType EndType { get; }

		protected FuselageSizeType SizeType { get; }

		protected float StartValue { get; }

		protected float TargetValue { get; }

		protected FuselageSizeStep(TutorialStepBuilderContext context, int partId, FuselageEndType endType, FuselageSizeType sizeType, float startValue, float targetValue, string stepText = null)
			: base(context, partId, FuselageSectionType.Middle, null, highlightGoalFuselage: true, stepText)
		{
			EndType = endType;
			SizeType = sizeType;
			StartValue = startValue;
			TargetValue = targetValue;
			base.AppliedPartChanges.Add(new FuselageSizeChange(partId, endType, sizeType, startValue, targetValue));
		}

		protected override bool IsFuselageChangeComplete()
		{
			if (base.FuselageData?.Part.PartScript == null || base.GoalFuselage?.Part.PartScript == null)
			{
				return false;
			}
			SectionParams sectionParams = GetSectionParams(base.FuselageData, EndType);
			SectionParams sectionParams2 = GetSectionParams(base.GoalFuselage, EndType);
			bool num = Utilities.CompareVector2s(sectionParams.Size, sectionParams2.Size, SizeTolerance);
			bool flag = Utilities.CompareVector3s(base.FuselageData.Part.PartScript.transform.position, base.GoalFuselage.Part.PartScript.transform.position, PositionTolerance);
			return num && flag;
		}

		protected override void OnFuselageStepUpdate()
		{
			if (SizeType == FuselageSizeType.Width)
			{
				if (EndType == FuselageEndType.Front)
				{
					base.InstructionText = "Adjust the front width to match the indicated shape by [clicking:] and dragging the red arrow at the front of the fuselage.";
					base.HighlightedGizmo = JFuselageGizmoController.FuselageGizmoID.FrontWidth;
				}
				else
				{
					base.InstructionText = "Adjust the back width to match the indicated shape by [clicking:] and dragging the red arrow at the back of the fuselage.";
					base.HighlightedGizmo = JFuselageGizmoController.FuselageGizmoID.BackWidth;
				}
			}
			else if (EndType == FuselageEndType.Front)
			{
				base.InstructionText = "Adjust the front height to match the indicated shape by [clicking:] and dragging the green arrow at the front of the fuselage.";
				base.HighlightedGizmo = JFuselageGizmoController.FuselageGizmoID.FrontHeight;
			}
			else
			{
				base.InstructionText = "Adjust the back height to match the indicated shape by [clicking:] and dragging the green arrow at the back of the fuselage.";
				base.HighlightedGizmo = JFuselageGizmoController.FuselageGizmoID.BackHeight;
			}
		}
	}
}
