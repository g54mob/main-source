using System;

namespace Jundroo.ModTools.Core.Events
{
	public class PreProcessAssemblyEventArgs : EventArgs
	{
		public byte[] AssemblyBytes { get; set; }

		public string AssemblyPath { get; private set; }

		public ModInfo ModInfo { get; private set; }

		public PreProcessAssemblyEventArgs(ModInfo modInfo, string assemblyPath, byte[] assemblyBytes)
		{
			ModInfo = modInfo;
			AssemblyPath = assemblyPath;
			AssemblyBytes = assemblyBytes;
		}
	}
}
