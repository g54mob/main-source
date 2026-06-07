using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
	{
		private class MvobXFGMEIFVQNGvzmfnepSWbMIj
		{
			private float[] bvWmNNuhxiWjGNCSexuxGXNAUUZ;

			private bool[] NAinekULsoKbJnFppqZtFAAuOJN;

			public MvobXFGMEIFVQNGvzmfnepSWbMIj(int P_0, int P_1)
			{
			}

			public void cvpAVmdQhadYjvNyOqobxwBmJVRb(bool[] P_0, float[] P_1)
			{
			}

			public void ToeASnfqSaKZIxbQdikfrpwEoekB(ControllerDataUpdater P_0)
			{
			}

			public void tnPMvOhBpjvxYNUlgoWzWsITeuGP()
			{
			}

			public void IDrywvorrgxouKEvbvkUhijwgJcE()
			{
			}
		}

		[Serializable]
		private sealed class WNPIJXFEanedPkvBcNAfLGmugoFI
		{
			public static readonly WNPIJXFEanedPkvBcNAfLGmugoFI _003C_003E9;

			public static Func<MvobXFGMEIFVQNGvzmfnepSWbMIj> _003C_003E9__20_0;

			internal MvobXFGMEIFVQNGvzmfnepSWbMIj EgofZKmGzYougWiQAWPFxAHuGKLs()
			{
				return null;
			}
		}

		private static HardwareControllerMap_Game nXheGgTNHblnFEyABIbFGBWnzZn;

		private UpdateLoopDataSet<MvobXFGMEIFVQNGvzmfnepSWbMIj> RCTKNOorxaKSdafAFCNhqeplgjXj;

		private float[] FmszaTTFbKeSlgKImBbUeNnVzBQN;

		private bool[] AGdZXtHRInntjbHiSTnaWMtGluiv;

		private bool YFIOVhZbwMunhsxFaSxeHPQzgnBe;

		private bool LXWdiRhhonXzBMVOZSZAIieyBmrx;

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

		private void aPLFUgctBpOtJQATFBjMZNbscGqEb()
		{
		}

		private void JPRoVzBgaKIAwHfuZdmyPCjRAVbMA(UpdateLoopType P_0)
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
