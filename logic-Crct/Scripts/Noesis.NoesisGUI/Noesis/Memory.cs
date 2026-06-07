using System.Runtime.InteropServices;

namespace Noesis
{
	public class Memory
	{
		public static uint Current => 0u;

		public static uint Accumulated => 0u;

		public static uint Allocs => 0u;

		[PreserveSig]
		private static extern uint Noesis_GetAllocatedMemory();

		[PreserveSig]
		private static extern uint Noesis_GetAllocatedMemoryAccum();

		[PreserveSig]
		private static extern uint Noesis_GetAllocationsCount();
	}
}
