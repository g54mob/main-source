using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
	{
		private class RoNRJyCyELCVlYHkQYCrSweDMDxl
		{
			private float[] ibQGYgHanuPjAPHLhCZcXthEdxpN;

			private bool[] WqrLSHyFPpFZQOJWACCLTssTbgoI;

			public RoNRJyCyELCVlYHkQYCrSweDMDxl(int P_0, int P_1)
			{
			}

			public void doQysgghWewXhqUXBAyyDEdzufgD(bool[] P_0, float[] P_1)
			{
			}

			public void AYBgrjfqYtFBsgcKESFyBPhRTSBE(ControllerDataUpdater P_0)
			{
			}

			public void spqkVldfpgvuhYVcXPazsKkMiVxp()
			{
			}

			public void TjSIkQinwbuoNXRZWZFWVQklJhTe()
			{
			}
		}

		[Serializable]
		private sealed class NimyLoTYnmxpqzsUBpLdlQNfJywc
		{
			public static readonly NimyLoTYnmxpqzsUBpLdlQNfJywc _003C_003E9;

			public static Func<RoNRJyCyELCVlYHkQYCrSweDMDxl> _003C_003E9__20_0;

			internal RoNRJyCyELCVlYHkQYCrSweDMDxl HJFcNbgTvHNrNXeZfTqZZQlbslus()
			{
				return null;
			}
		}

		private static HardwareControllerMap_Game mjyRRfaJNIclGOidfciztIdHRYon;

		private UpdateLoopDataSet<RoNRJyCyELCVlYHkQYCrSweDMDxl> IWmaejqetnMPOnsPglurKqFiTXkQ;

		private float[] WDRPMgHdbNeVGroTFbHQQgBGyadN;

		private bool[] PjYevSEDCoyoScclzCFiUiNXFPVFb;

		private bool FQlyjSVnnJnZYjsoLwNylhDeTemG;

		private bool CLhUHcpMuseLqHbLirEAiAGlFNGx;

		public bool enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public InputSource inputSource => default(InputSource);

		public HardwareControllerMap_Game hardwareMap => null;

		public int buttonCount => 0;

		public int axisCount => 0;

		public Vector2 mousePosition => default(Vector2);

		public Controller.Extension controllerExtension => null;

		public void UpdateInputData(ControllerDataUpdater dataUpdater)
		{
		}

		public void Clear()
		{
		}

		private void dhutwRzWLsfygZiGurVQxcJjrnPT()
		{
		}

		private void MGujvODkaJIZPfqbkfGmgqNaMkMwB(UpdateLoopType P_0)
		{
		}

		internal static HardwareControllerMap_Game CreateHardwareMap()
		{
			return null;
		}

		public void Dispose()
		{
		}

		~UnityUnifiedMouseSource()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
		{
			return default(ControllerElementType);
		}
	}
}
