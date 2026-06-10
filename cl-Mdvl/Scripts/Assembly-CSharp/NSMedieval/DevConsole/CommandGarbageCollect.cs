using System;
using FoxyVoxel.Logging;
using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandGarbageCollect : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandGarbageCollect()
		{
			Command = "gc";
			Description = "Forces 2 passes of GC.Collect, logs out allocated memory.";
			Help = "";
		}

		private void CommandMethod()
		{
			long totalMemory = GC.GetTotalMemory(forceFullCollection: true);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			long totalMemory2 = GC.GetTotalMemory(forceFullCollection: true);
			string text = $"Performed garbage collection.\nFreed {totalMemory - totalMemory2:N0} bytes.\nAllocated memory before GC: {totalMemory:N0} bytes\nAllocated memory after GC: {totalMemory2:N0} bytes.\n";
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(text, ConsoleMessageType.Warning);
			Log.Warning(text, "C:\\GIT\\dev\\Assets\\Scripts\\Debug\\Console\\Commands\\CommandGarbageCollect.cs");
		}
	}
}
