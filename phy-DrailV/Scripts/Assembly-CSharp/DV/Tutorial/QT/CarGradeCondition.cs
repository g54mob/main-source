using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CarGradeCondition : AQuickTutorialCondition
	{
		private string message;

		private float minAcceptableGrade;

		private float maxAcceptableGrade;

		public CarGradeCondition(float minAcceptableGrade, float maxAcceptableGrade, string message = null)
		{
			this.minAcceptableGrade = minAcceptableGrade;
			this.maxAcceptableGrade = maxAcceptableGrade;
			if (string.IsNullOrEmpty(message))
			{
				this.message = "Grade is too high.";
			}
			else
			{
				this.message = message;
			}
		}

		public override string Check()
		{
			if (PlayerManager.Car == null)
			{
				return string.Empty;
			}
			float num = Mathf.Abs(Mathf.DeltaAngle(PlayerManager.Car.transform.eulerAngles.x, 0f));
			if (num < minAcceptableGrade || num > maxAcceptableGrade)
			{
				Debug.Log("Grade out of range: " + num);
				return message;
			}
			return string.Empty;
		}
	}
}
