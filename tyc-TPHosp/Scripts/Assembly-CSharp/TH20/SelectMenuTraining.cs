using System;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuTraining : SelectMenuRoomItem
	{
		[SerializeField]
		private TMP_Text _qualificationName;

		[SerializeField]
		private TMP_Text _daysRemaining;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		[SerializeField]
		private DynamicButton _cancelButton;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			RoomLogicTrainingRoom component = roomItem.OwningRoom.GetComponent<RoomLogicTrainingRoom>();
			if (component != null && component.IsAvailable)
			{
				CloseMenu();
				base.HUD.DestroyMenu(this);
				base.HUD.CreateMenu<TrainingMenu>().Setup(level, null, null, roomItem.OwningRoom);
			}
			else
			{
				Update();
				CharacterEvents characterEvents = base.Level.CharacterEvents;
				characterEvents.OnStaffEndedTraining = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffEndedTraining, new Action<Staff>(OnStaffEndedTraining));
			}
		}

		protected override void Update()
		{
			base.Update();
			RoomLogicTrainingRoom trainingLogic = _roomItem.OwningRoom.GetComponent<RoomLogicTrainingRoom>();
			if (trainingLogic == null || trainingLogic.Qualification == null)
			{
				CloseMenu();
				return;
			}
			_qualificationName.text = trainingLogic.Qualification.NameLocalised.Translation;
			_progressBar.Progress = GameAlgorithms.CalculateTrainingCourseProgress(trainingLogic.Qualification, trainingLogic.Pupils);
			_daysRemaining.text = GameStringUtils.GetTrainingCourseDaysRemainingString(trainingLogic.Qualification, trainingLogic.Teacher, trainingLogic.Pupils, _roomItem.OwningRoom);
			_cancelButton.onPrimaryDown.AddListener(delegate
			{
				trainingLogic.CancelTraining();
				CloseMenu();
			});
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnStaffEndedTraining = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffEndedTraining, new Action<Staff>(OnStaffEndedTraining));
			base.Destroy();
		}

		private void OnStaffEndedTraining(Staff staff)
		{
			CloseMenu();
		}
	}
}
