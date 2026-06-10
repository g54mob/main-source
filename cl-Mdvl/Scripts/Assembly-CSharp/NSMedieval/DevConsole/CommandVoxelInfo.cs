using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandVoxelInfo : ConsoleCommand
	{
		private bool active;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandVoxelInfo()
		{
			Command = "voxelInfo";
			Description = "Display info of the currently selected voxel.";
			Help = "Displays info of the currently selected voxel (position, ground type, voxel data).";
		}

		private void CommandMethod()
		{
			active = !active;
			MonoSingleton<DevVoxelInfoController>.Instance.SetEnabled(active);
			MonoSingleton<GlobalShaderVariables>.Instance.SetEffectMaskTextureEnabled(!active);
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("VoxelInfo Mode <color=lime>activated</color>!", ConsoleMessageType.Warning);
		}

		private void OnSelectionPanelToggle(bool opened, int panelID)
		{
			CommandMethod();
		}
	}
}
