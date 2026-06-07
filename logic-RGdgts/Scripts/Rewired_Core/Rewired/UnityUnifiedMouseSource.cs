using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class UnityUnifiedMouseSource : IDisposable, IGetSetEnabled, IUnifiedMouseSource
	{
		private class qbYYvgdvNywLkOHcvSdhjCnEbxFZ
		{
			private float[] VOdcCxGpnuflkFUltgtmdTSOLsszA;

			private bool[] fMmsOPeSTxakcjrZNcSDeNzkYtrAA;

			public qbYYvgdvNywLkOHcvSdhjCnEbxFZ(int P_0, int P_1)
			{
			}

			public void bRcBGZsEAHPATdseEayuTKIegMdx(bool[] P_0, float[] P_1)
			{
			}

			public void tJxRcImkKqvmMRbSpjmbXPMuSelH(ControllerDataUpdater P_0)
			{
			}

			public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
			}

			public void CuKbNfFFbvNNOElOidzNqiYASKahA()
			{
			}
		}

		[Serializable]
		private sealed class gAhKWwurVZsgbnNqkTKvKlHkByOS
		{
			public static readonly gAhKWwurVZsgbnNqkTKvKlHkByOS _003C_003E9;

			public static Func<qbYYvgdvNywLkOHcvSdhjCnEbxFZ> _003C_003E9__20_0;

			internal qbYYvgdvNywLkOHcvSdhjCnEbxFZ VmbfQsPLyFGZnvWIapEPANmyjTLv()
			{
				return null;
			}
		}

		private static HardwareControllerMap_Game MWUXdFVnrMGjoJuplFCUaTFIzejiB;

		private UpdateLoopDataSet<qbYYvgdvNywLkOHcvSdhjCnEbxFZ> GesyYeBpGYjhiPhqJvunCCEmAIOj;

		private float[] VOdcCxGpnuflkFUltgtmdTSOLsszA;

		private bool[] fMmsOPeSTxakcjrZNcSDeNzkYtrAA;

		private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

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

		private void ABemZVTTHZtsBAXUqzbHwVVruOdh()
		{
		}

		private void ANWWxmBLjBmUkWbQltRWrtgDpXUA(UpdateLoopType P_0)
		{
		}

		private static HardwareControllerMap_Game UbrfMNNvrvFcOBozobIHidyuqtTEb()
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
