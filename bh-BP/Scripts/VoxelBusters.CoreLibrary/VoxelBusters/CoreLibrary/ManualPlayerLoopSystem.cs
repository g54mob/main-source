using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.LowLevel;

namespace VoxelBusters.CoreLibrary
{
	public class ManualPlayerLoopSystem
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate uint PlayerLoopDelegate();

		private readonly PlayerLoopSystem m_playerLoopSystem;

		public ManualPlayerLoopSystem(List<object> requiredSubSystems)
		{
		}

		public void Process()
		{
		}

		private PlayerLoopSystem GetPlayerLoopSystemWithRequiredSubSystems(List<object> requiredSubSystems)
		{
			return default(PlayerLoopSystem);
		}

		private PlayerLoopSystem GetPlayerLoopSystemForType(Type type)
		{
			return default(PlayerLoopSystem);
		}
	}
}
