using System;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class UnityUnifiedMouseSource : IDisposable, IUnifiedMouseSource
	{
		private class kMOlcbboXAKPMEpIizTgrMCNXCS
		{
			private float[] JvXPsaYhETvUcPTkTXxYDdPsXbv;

			private bool[] nAoVXKwMBTWoUzenSnuIByUpmGg;

			public kMOlcbboXAKPMEpIizTgrMCNXCS(int buttonCount, int axisCount)
			{
			}

			public void tbaHCfkOIpQfphIPVKAzLCvrlNq(bool[] P_0, float[] P_1)
			{
			}

			public void dXlEwBePKOnFwNbkeaVaJhfvyjy(ControllerDataUpdater P_0)
			{
			}

			public void DcbUeIfyTfvTrRQxceAMfGCsJNs()
			{
			}

			public void SeEIWaNplDHZurQenBtAiCdBgnv()
			{
			}
		}

		private static HardwareControllerMap_Game QHWpuSHybsCpWwbHqQiDJLegBLk;

		private UpdateLoopDataSet<kMOlcbboXAKPMEpIizTgrMCNXCS> MQgrVhBOSyxbQHeEKBSwMkdjbbV;

		private float[] JvXPsaYhETvUcPTkTXxYDdPsXbv;

		private bool[] nAoVXKwMBTWoUzenSnuIByUpmGg;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		[CompilerGenerated]
		private static Func<kMOlcbboXAKPMEpIizTgrMCNXCS> vjmCaqpLhyEsQKsuFnUlrPQgCptJ;

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

		private void KrueWEHBXjqzzICyjCDAzqmsYFs()
		{
		}

		private void KdKJNgXdNxGswUmXNSTCxBOlrSM(UpdateLoopType P_0)
		{
		}

		private static HardwareControllerMap_Game WKtVOpXzeTkyLFPPnaChpDWlCQH()
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

		[CompilerGenerated]
		private static kMOlcbboXAKPMEpIizTgrMCNXCS kQypCTxEGqfudvprNAEhysirTA()
		{
			return null;
		}
	}
}
