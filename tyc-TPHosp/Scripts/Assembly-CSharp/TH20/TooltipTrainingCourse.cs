using I2.Loc;
using JetBrains.Annotations;
using TMPro;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipTrainingCourse : Tooltip
	{
		public TMP_Text Description;

		public TMP_Text StaffWithCount;

		public TMP_Text StaffAbleCount;

		public TMP_Text TrainingUnits;

		public void SetData(string courseName, string description, int numStaffWithQualification, int numStaffCanLearn, float trainingPoints)
		{
			base.Text = courseName;
			Description.text = description;
			StaffWithCount.text = ScriptLocalization.Tooltip.TrainingCourse_StaffWithQualification_CS.Replace("{[COUNT]}", numStaffWithQualification.ToString());
			StaffAbleCount.text = ScriptLocalization.Tooltip.TrainingCourse_StaffAbleToLearn_CS.Replace("{[COUNT]}", numStaffCanLearn.ToString());
			TrainingUnits.text = ScriptLocalization.Tooltip.TrainingCourse_PointsRequired_CS.Replace("{[POINTS]}", ((int)trainingPoints).ToString());
		}
	}
}
