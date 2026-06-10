using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.View;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandSetFreshness : ConsoleCommand
	{
		private float freshness;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetFreshness()
		{
			Command = "setFreshness";
			Description = "Set freshness of piles and items in the storage of creatures you click on.";
			Help = "setFreshness <freshness>";
		}

		private void CommandMethod(float value)
		{
			freshness = value;
			string result = "Click on a pile to set its freshness. If you click on a creature, freshness will be set for everything in its storage and food storage.";
			MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseClick;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { $"<color=\"white\">Command: </color><#9CFF92><i>{Command} {value}" });
		}

		private void OnSelected(SelectableObject obj)
		{
			if (obj == null)
			{
				return;
			}
			CreatureBase asCreature = obj.GetAsCreature();
			if (asCreature != null && !asCreature.HasDisposed)
			{
				if (asCreature.Storage?.Resources != null)
				{
					foreach (ResourceInstance resource in asCreature.Storage.Resources)
					{
						resource.GetStat(StatType.Freshness).SetCurrent(freshness);
						resource.GetStat(StatType.Health).SetCurrent(freshness);
					}
				}
				if (asCreature.FoodStorage?.Resources == null)
				{
					return;
				}
				{
					foreach (ResourceInstance resource2 in asCreature.FoodStorage.Resources)
					{
						resource2.GetStat(StatType.Freshness).SetCurrent(freshness);
						resource2.GetStat(StatType.Health).SetCurrent(freshness);
					}
					return;
				}
			}
			WorldObject asWorldObject = obj.GetAsWorldObject();
			if (asWorldObject == null || !(asWorldObject is IStatsOwner statsOwner))
			{
				return;
			}
			StatInstance statInstance = statsOwner.Stats?.GetStat(StatType.Freshness);
			if (statInstance != null)
			{
				statInstance.SetCurrent(freshness);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandSetFreshness.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Set freshness to ");
					messageBuilder.AppendFormatted(freshness);
					messageBuilder.AppendLiteral(" on ");
					messageBuilder.AppendFormatted(asWorldObject);
				}
				Log.Info(messageBuilder);
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
