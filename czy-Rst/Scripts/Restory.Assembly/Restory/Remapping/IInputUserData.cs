using Restory.Data.Remapping;
using Rewired;

namespace Restory.Remapping
{
	public interface IInputUserData
	{
		RemappingButtonsList RemappingButtonsList { get; }

		ActionsRewiredDependencyMap ActionsDependencyMap { get; }

		bool LoadDataOnStart { get; set; }

		bool IsDefault();

		void LoadDefault();

		void Load();

		void Save();

		string GetButtonName(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange);

		bool TryGetInputButtonData(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange, out InputButtonData inputButtonData);

		void SetInputButtonData(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange, InputButtonData inputButtonData);

		bool CheckConflict(int playerId, ControllerType controllerType, int controllerId, Restory.Data.Remapping.InputAction action, AxisRange axisRange);
	}
}
