using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.View.Animals;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class LadderFalldown : ConsoleCommand
	{
		private bool active;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public LadderFalldown()
		{
			Command = "ladderFalldown";
			Description = "Selected agent will fall from ladder";
			Help = "Selected agent will fall form ladder";
		}

		private void CommandMethod()
		{
			if (active)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<SceneController>.Instance.UnscaledTick -= OnTick;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("LadderFall <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<SceneController>.Instance.UnscaledTick += OnTick;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("LadderFall Mode <color=lime>activated</color>!", ConsoleMessageType.Warning);
		}

		private void OnTick(float dt)
		{
			if (MonoSingleton<SelectableObjectManager>.IsInstantiated() && Input.GetMouseButtonDown(0) && !(MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject == null))
			{
				SelectableObject mouseHoverObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
				CreatureBase creatureBase = null;
				if (mouseHoverObject is WorkerView workerView)
				{
					creatureBase = workerView.HumanoidInstance;
				}
				else if (mouseHoverObject is NPCView nPCView)
				{
					creatureBase = nPCView.HumanoidInstance;
				}
				else if (mouseHoverObject is AnimalView animalView)
				{
					creatureBase = animalView.AnimalInstance;
				}
				creatureBase?.LadderFallDown();
			}
		}

		private void OnRightMouseDown()
		{
			CommandMethod();
		}
	}
}
