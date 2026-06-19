using I2.Loc;

namespace TH20
{
	public class InspectorSubDataRoomTraining : InspectorSubDataRoom
	{
		private RoomLogicTrainingRoom _logicTraining;

		public InspectorSubDataRoomTraining(Room room)
			: base(room)
		{
			_logicTraining = room.GetComponent<RoomLogicTrainingRoom>();
		}

		public override string GetText()
		{
			if (_logicTraining == null)
			{
				return string.Empty;
			}
			if (_logicTraining.IsAvailable)
			{
				return ScriptLocalization.Inspector_Room_Training.Training_CS;
			}
			return ScriptLocalization.Inspector_Room_Training.CancelCourse_CS;
		}

		public override string GetTooltip()
		{
			if (_logicTraining == null)
			{
				return string.Empty;
			}
			if (_logicTraining.IsAvailable)
			{
				return ScriptLocalization.Inspector_Room_Training.StartCourse_CS;
			}
			return ScriptLocalization.Inspector_Room_Training.CancelCourse_CS;
		}

		public override bool OnButtonPressed()
		{
			if (_logicTraining == null)
			{
				return false;
			}
			if (_logicTraining.IsAvailable)
			{
				base.Level.HospitalHUDManager.TryOpenMenu(delegate
				{
					base.Level.HUD.CreateMenu<TrainingMenu>().Setup(base.Level, null, null, _room);
				});
				return true;
			}
			_logicTraining.CancelTraining();
			return false;
		}

		public override bool ShouldShowButton()
		{
			if (_logicTraining != null)
			{
				return _room.HasValidRequiredItems();
			}
			return false;
		}
	}
}
