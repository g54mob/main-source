using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuTraining : HoverMenuRoomItem
	{
		[SerializeField]
		private TMP_Text _qualificationName;

		[SerializeField]
		private TMP_Text _daysRemaining;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			Update();
		}

		protected override void Update()
		{
			base.Update();
			RoomLogicTrainingRoom component = _roomItem.OwningRoom.GetComponent<RoomLogicTrainingRoom>();
			if (component != null)
			{
				if (component.IsAvailable)
				{
					_qualificationName.text = ScriptLocalization.Menu.Hover_Training_StartCourse_CS;
					GameObjectUtils.SetActive(_progressBar.gameObject, isActive: false);
					GameObjectUtils.SetActive(_daysRemaining.gameObject, isActive: false);
				}
				else
				{
					_qualificationName.text = component.Qualification.NameLocalised.Translation;
					_progressBar.Progress = GameAlgorithms.CalculateTrainingCourseProgress(component.Qualification, component.Pupils);
					_daysRemaining.text = GameStringUtils.GetTrainingCourseDaysRemainingString(component.Qualification, component.Teacher, component.Pupils, _roomItem.OwningRoom);
					GameObjectUtils.SetActive(_progressBar.gameObject, isActive: true);
					GameObjectUtils.SetActive(_daysRemaining.gameObject, isActive: true);
				}
			}
		}
	}
}
