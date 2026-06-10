using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.View;

namespace NSMedieval.DevConsole
{
	public class CommandSetDomestic : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetDomestic()
		{
			Command = "setDomesticAnimal";
			Description = "Sets animal as domestic";
			Help = "Use this to set animal as domestic";
		}

		private void CommandMethod()
		{
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (!(obj == null) && obj.GetAsCreature() is AnimalInstance animalInstance && animalInstance.Blueprint.CanBeTamed)
			{
				animalInstance.Stats.GetStat(StatType.AnimalWild).SetCurrent(0f);
				animalInstance.SetAnimalType(AnimalType.Domestic);
				if (animalInstance.HasHarvestableProduction())
				{
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animalInstance);
				}
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
