using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
	{
		private class SKknIYwjDbLklZlcxuwcjBycyOcy
		{
			private float[] frxGTQbleSgtYNETQNhlYkrxbxsKA;

			private bool[] XzSfQdJUAJNhQINEvQqAFkwoZhxAA;

			public SKknIYwjDbLklZlcxuwcjBycyOcy(int P_0, int P_1)
			{
			}

			public void gytffOkCTGzInulSsfandwWCwkrhb(bool[] P_0, float[] P_1)
			{
			}

			public void RRuerJGNhNJlmPlaxzydSaXsvBIMA(ControllerDataUpdater P_0)
			{
			}

			public void rSFMxPTtiQOPjJhuiEUqVlkpcPgp()
			{
			}

			public void AChANwkGmZMWHwMTvlvNfcQfUDENb()
			{
			}
		}

		[Serializable]
		private sealed class IsZbtUlWTMYLyuTqutDuQKKIORpO
		{
			public static readonly IsZbtUlWTMYLyuTqutDuQKKIORpO _003C_003E9;

			public static Func<SKknIYwjDbLklZlcxuwcjBycyOcy> _003C_003E9__20_0;

			internal SKknIYwjDbLklZlcxuwcjBycyOcy AaiUSTAdyrBZPSSVGZCIaBpQAjngA()
			{
				return null;
			}
		}

		private static HardwareControllerMap_Game tCPiKVAOAyFYEfJbkIGeMWdgmSrUA;

		private UpdateLoopDataSet<SKknIYwjDbLklZlcxuwcjBycyOcy> TdTqzPIgsPjXUyFTBhOqbZNHNNvq;

		private float[] BuulWGlqyxclEmBHcrvHvyPlWwyo;

		private bool[] IZxypmbBsWYlQvvBSrrnVNpyTnIE;

		private bool KaOAryAxehETAoyqeaEjaWbRKVxuA;

		private bool ViCEDYJstSnKwQyZJJNRZJSIEDLw;

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

		private void iBFnxlDICAOwjIWGFtPICHiKzCWc()
		{
		}

		private void BQJqTchrvfflTbAfXasxDFDbByXL(UpdateLoopType P_0)
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
