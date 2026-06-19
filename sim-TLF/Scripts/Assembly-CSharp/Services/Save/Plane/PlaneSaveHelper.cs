using AssembleSystem.FSM.Plane;

namespace Services.Save.Plane
{
	internal static class PlaneSaveHelper
	{
		internal static PlaneSaveData BuildSaveData(PlaneStateMachine fsm, AirplaneController controller)
		{
			return new PlaneSaveData
			{
				EnginePlaced = fsm.MotorPlaced,
				EngineTightened = fsm.MotorTightened,
				HandBreakPerentage = controller.handBreakPercent
			};
		}

		internal static void ApplySaveData(PlaneStateMachine fsm, AirplaneController controller, PlaneSaveData data)
		{
			fsm.MotorPlaced = data.EnginePlaced;
			fsm.MotorTightened = data.EngineTightened;
			controller.handBreakPercent = data.HandBreakPerentage;
			controller.UpdateWheelsPhysics();
		}
	}
}
