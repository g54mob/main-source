using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Scripts.Pooler;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnParticleSystem : ConsoleCommand
	{
		private bool active;

		private string particleSystemId;

		private Ray ray;

		private RaycastHit hit;

		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSpawnParticleSystem()
		{
			Command = "spawnParticleSystem";
			Description = "Spawns the given particle system on mouse click.";
			Help = "Use this command to spawn a specific particle system.";
		}

		private void CommandMethod(string particleSystemId)
		{
			if (active && this.particleSystemId == particleSystemId)
			{
				active = false;
				MonoSingleton<DeveloperConsoleController>.Instance.ToggleInfoCursor(active: false);
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent -= OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent -= SpawnParticleSystem;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnWorker Mode <color=red>disabled!</color>", ConsoleMessageType.Warning);
				return;
			}
			if (!active)
			{
				active = true;
				MonoSingleton<DebugInputController>.Instance.RightMouseDownEvent += OnRightMouseDown;
				MonoSingleton<DebugInputController>.Instance.MouseUpEvent += SpawnParticleSystem;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.UpdateInfoCursorContent(new List<string> { "<color=\"white\">Command: </color><#9CFF92><i>" + Command + " " + particleSystemId });
			this.particleSystemId = particleSystemId;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("SpawnWorker Mode <color=lime>activated</color>! Use same command call to disable it", ConsoleMessageType.Warning);
		}

		private void SpawnParticleSystem()
		{
			if (!MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked)
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << MonoSingleton<World>.Instance.TerrainLayer) && MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(particleSystemId, hit.point) == null)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage("Debug: did not spawn " + particleSystemId + ", pool is empty, frustum check failed or creating new instances is not allowed.");
				}
			}
		}

		private void OnRightMouseDown()
		{
			CommandMethod(particleSystemId);
		}
	}
}
