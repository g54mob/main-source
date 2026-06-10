using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandSetWildAggressive : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetWildAggressive()
		{
			Command = "setWildAggressiveAnimal";
			Description = "Sets animal as wild aggressive";
			Help = "Use this to set animal as wild aggressive";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null) && obj.GetAsCreature() is AnimalInstance animalInstance)
			{
				StatInstance stat = animalInstance.Stats.GetStat(StatType.AnimalWild);
				stat.SetCurrent(stat.Max);
				animalInstance.SetAnimalType(AnimalType.WildAggressive);
			}
		}

		private void OnRightMouseClick()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
