using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandDeleteMapMarker : ConsoleCommand
	{
		private bool subscribed;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandDeleteMapMarker()
		{
			Command = "deleteMapMarker";
			Description = "Click on any map marker on Region map to <color=red>delete</color> it. Right click to stop.";
			Help = Description;
		}

		private void CommandMethod()
		{
			if (!subscribed)
			{
				subscribed = true;
				MonoSingleton<SceneController>.Instance.Tick += OnTick;
				MonoSingleton<WorldMapController>.Instance.PlaceClickedEvent += OnPlaceClicked;
				MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string>
				{
					"<color=\"white\">Command: </color><#9CFF92><i>" + Command,
					"Click on any map marker on Region map to <color=red>delete</color> it. Right click to stop."
				});
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Click on any map marker on Region map to <color=red>delete</color> it. Right click to stop.");
			}
		}

		private void OnPlaceClicked(WorldMapPlace obj)
		{
			if (obj is WorldMapMarkerPlace marker)
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.MarkerManager.DestroyMarker(marker);
			}
		}

		private void OnTick(float dt)
		{
			if (Input.GetMouseButtonDown(1))
			{
				OnRightMouseClick();
			}
		}

		private void OnRightMouseClick()
		{
			if (subscribed)
			{
				subscribed = false;
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
				MonoSingleton<WorldMapController>.Instance.PlaceClickedEvent -= OnPlaceClicked;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
		}
	}
}
