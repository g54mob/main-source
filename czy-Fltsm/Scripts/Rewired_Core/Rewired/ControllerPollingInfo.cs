using UnityEngine;

namespace Rewired
{
	public struct ControllerPollingInfo
	{
		private bool kwcbMLtgipbkIbnyIcAIHmqjsrvyA;

		private int QwSaksEetDWASPBhoUSJAkjOpkft;

		private int gQRuzSLbqVOXGfIOQPoHcYLlJxYQ;

		private string mZhmhyQEGQoZxqdLfjJQAatLVhhl;

		private ControllerType JYAcNdKDfiFzQUWqyqCmNkxCMUODA;

		private ControllerElementType itxvxikvVUchtWvxXFxnRthkvJMG;

		private int uClJcmBrEFaiYwZJwjIrDyNtMEsA;

		private Pole rJRlvvRzsuRGCOJaifgRioiFSlYY;

		private string lxYaOkQIWusdaCGnqJJptenxpuYO;

		private int LXxrIFpuuDPXRXUeJtSJFhmQENvQ;

		private KeyCode dCGhCcFKknGPgbOsfLZqcLtsDCCu;

		public bool success
		{
			get
			{
				return kwcbMLtgipbkIbnyIcAIHmqjsrvyA;
			}
			internal set
			{
				kwcbMLtgipbkIbnyIcAIHmqjsrvyA = flag;
			}
		}

		public int playerId
		{
			get
			{
				return QwSaksEetDWASPBhoUSJAkjOpkft;
			}
			internal set
			{
				QwSaksEetDWASPBhoUSJAkjOpkft = qwSaksEetDWASPBhoUSJAkjOpkft;
			}
		}

		public int controllerId
		{
			get
			{
				return gQRuzSLbqVOXGfIOQPoHcYLlJxYQ;
			}
			internal set
			{
				gQRuzSLbqVOXGfIOQPoHcYLlJxYQ = num;
			}
		}

		public string controllerName
		{
			get
			{
				return mZhmhyQEGQoZxqdLfjJQAatLVhhl;
			}
			internal set
			{
				mZhmhyQEGQoZxqdLfjJQAatLVhhl = text;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return JYAcNdKDfiFzQUWqyqCmNkxCMUODA;
			}
			internal set
			{
				JYAcNdKDfiFzQUWqyqCmNkxCMUODA = jYAcNdKDfiFzQUWqyqCmNkxCMUODA;
			}
		}

		public ControllerElementType elementType
		{
			get
			{
				return itxvxikvVUchtWvxXFxnRthkvJMG;
			}
			internal set
			{
				itxvxikvVUchtWvxXFxnRthkvJMG = controllerElementType;
			}
		}

		public int elementIndex
		{
			get
			{
				return uClJcmBrEFaiYwZJwjIrDyNtMEsA;
			}
			internal set
			{
				uClJcmBrEFaiYwZJwjIrDyNtMEsA = num;
			}
		}

		public Pole axisPole
		{
			get
			{
				return rJRlvvRzsuRGCOJaifgRioiFSlYY;
			}
			internal set
			{
				rJRlvvRzsuRGCOJaifgRioiFSlYY = pole;
			}
		}

		public string elementIdentifierName
		{
			get
			{
				return lxYaOkQIWusdaCGnqJJptenxpuYO;
			}
			internal set
			{
				lxYaOkQIWusdaCGnqJJptenxpuYO = text;
			}
		}

		public int elementIdentifierId
		{
			get
			{
				return LXxrIFpuuDPXRXUeJtSJFhmQENvQ;
			}
			internal set
			{
				LXxrIFpuuDPXRXUeJtSJFhmQENvQ = lXxrIFpuuDPXRXUeJtSJFhmQENvQ;
			}
		}

		public KeyCode keyboardKey
		{
			get
			{
				return dCGhCcFKknGPgbOsfLZqcLtsDCCu;
			}
			internal set
			{
				dCGhCcFKknGPgbOsfLZqcLtsDCCu = keyCode;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				if (!ReInput.BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.WbfSUuQhwzzYOgqDCeHuXhKAZPOB(QwSaksEetDWASPBhoUSJAkjOpkft))
				{
					return null;
				}
				return ReInput.BmmzPGNuZrdZxdhYqgOOCPaOiRrkA.SsVuigQhQtABwxcDHPRhTnSsVBJh(QwSaksEetDWASPBhoUSJAkjOpkft);
			}
		}

		public Controller controller
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.controllers.GetController(JYAcNdKDfiFzQUWqyqCmNkxCMUODA, gQRuzSLbqVOXGfIOQPoHcYLlJxYQ);
			}
		}

		public ControllerElementIdentifier elementIdentifier
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return controller?.GetElementIdentifierById(LXxrIFpuuDPXRXUeJtSJFhmQENvQ);
			}
		}

		internal ControllerPollingInfo(bool P_0, int P_1, int P_2, string P_3, ControllerType P_4, ControllerElementType P_5, int P_6, Pole P_7, string P_8, int P_9, KeyCode P_10)
		{
			kwcbMLtgipbkIbnyIcAIHmqjsrvyA = P_0;
			QwSaksEetDWASPBhoUSJAkjOpkft = P_1;
			gQRuzSLbqVOXGfIOQPoHcYLlJxYQ = P_2;
			mZhmhyQEGQoZxqdLfjJQAatLVhhl = P_3;
			JYAcNdKDfiFzQUWqyqCmNkxCMUODA = P_4;
			itxvxikvVUchtWvxXFxnRthkvJMG = P_5;
			uClJcmBrEFaiYwZJwjIrDyNtMEsA = P_6;
			rJRlvvRzsuRGCOJaifgRioiFSlYY = P_7;
			lxYaOkQIWusdaCGnqJJptenxpuYO = P_8;
			LXxrIFpuuDPXRXUeJtSJFhmQENvQ = P_9;
			dCGhCcFKknGPgbOsfLZqcLtsDCCu = P_10;
		}

		internal ControllerPollingInfo(ControllerPollingInfo P_0)
		{
			kwcbMLtgipbkIbnyIcAIHmqjsrvyA = P_0.kwcbMLtgipbkIbnyIcAIHmqjsrvyA;
			QwSaksEetDWASPBhoUSJAkjOpkft = P_0.QwSaksEetDWASPBhoUSJAkjOpkft;
			gQRuzSLbqVOXGfIOQPoHcYLlJxYQ = P_0.gQRuzSLbqVOXGfIOQPoHcYLlJxYQ;
			mZhmhyQEGQoZxqdLfjJQAatLVhhl = P_0.mZhmhyQEGQoZxqdLfjJQAatLVhhl;
			JYAcNdKDfiFzQUWqyqCmNkxCMUODA = P_0.JYAcNdKDfiFzQUWqyqCmNkxCMUODA;
			itxvxikvVUchtWvxXFxnRthkvJMG = P_0.itxvxikvVUchtWvxXFxnRthkvJMG;
			uClJcmBrEFaiYwZJwjIrDyNtMEsA = P_0.uClJcmBrEFaiYwZJwjIrDyNtMEsA;
			rJRlvvRzsuRGCOJaifgRioiFSlYY = P_0.rJRlvvRzsuRGCOJaifgRioiFSlYY;
			lxYaOkQIWusdaCGnqJJptenxpuYO = P_0.lxYaOkQIWusdaCGnqJJptenxpuYO;
			LXxrIFpuuDPXRXUeJtSJFhmQENvQ = P_0.LXxrIFpuuDPXRXUeJtSJFhmQENvQ;
			dCGhCcFKknGPgbOsfLZqcLtsDCCu = P_0.dCGhCcFKknGPgbOsfLZqcLtsDCCu;
		}

		internal static ControllerPollingInfo ZwUAppCOgCTgGUtaDtNagYmPnIimA()
		{
			return new ControllerPollingInfo(false, -1, -1, string.Empty, ControllerType.Keyboard, ControllerElementType.Axis, -1, Pole.Positive, string.Empty, -1, KeyCode.None);
		}
	}
}
