using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct TouchInfo
	{
		private bool TDDNWUzJKMwhkWMQvgSgckxbIHat;

		private int zTUCFKbiIPWDNCRiZCLisZvkAgSu;

		private Vector2 BPVGjEixuIdhFhOeeOgAUIcAaWGsb;

		private Vector2 tIlYxrIWMFPkfpOlSFXjfOnvleiPA;

		private Vector2 rkuwlpDhOEQgbrSiRbDdZvDSvXgr;

		private Vector2 rnZsrHrJcHwetYuXbaFoeuNkbvMb;

		private float fYFqcqFESzODgvkxGgfDGaZjghlOA;

		private int vszGnojZeLdRFYAcqhmoSmtpgMhiA;

		public bool isValid
		{
			get
			{
				return TDDNWUzJKMwhkWMQvgSgckxbIHat;
			}
			internal set
			{
				TDDNWUzJKMwhkWMQvgSgckxbIHat = value;
			}
		}

		public int touchId
		{
			get
			{
				return zTUCFKbiIPWDNCRiZCLisZvkAgSu;
			}
			internal set
			{
				zTUCFKbiIPWDNCRiZCLisZvkAgSu = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return BPVGjEixuIdhFhOeeOgAUIcAaWGsb;
			}
			internal set
			{
				BPVGjEixuIdhFhOeeOgAUIcAaWGsb = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return tIlYxrIWMFPkfpOlSFXjfOnvleiPA;
			}
			internal set
			{
				tIlYxrIWMFPkfpOlSFXjfOnvleiPA = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return rkuwlpDhOEQgbrSiRbDdZvDSvXgr;
			}
			internal set
			{
				rkuwlpDhOEQgbrSiRbDdZvDSvXgr = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return rnZsrHrJcHwetYuXbaFoeuNkbvMb;
			}
			internal set
			{
				rnZsrHrJcHwetYuXbaFoeuNkbvMb = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return fYFqcqFESzODgvkxGgfDGaZjghlOA;
			}
			internal set
			{
				fYFqcqFESzODgvkxGgfDGaZjghlOA = value;
			}
		}

		public int tapCount
		{
			get
			{
				return vszGnojZeLdRFYAcqhmoSmtpgMhiA;
			}
			internal set
			{
				vszGnojZeLdRFYAcqhmoSmtpgMhiA = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			TDDNWUzJKMwhkWMQvgSgckxbIHat = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			TDDNWUzJKMwhkWMQvgSgckxbIHat = P_0;
			zTUCFKbiIPWDNCRiZCLisZvkAgSu = P_1;
			BPVGjEixuIdhFhOeeOgAUIcAaWGsb = P_2;
			tIlYxrIWMFPkfpOlSFXjfOnvleiPA = P_3;
			rkuwlpDhOEQgbrSiRbDdZvDSvXgr = P_4;
			rnZsrHrJcHwetYuXbaFoeuNkbvMb = P_5;
			fYFqcqFESzODgvkxGgfDGaZjghlOA = P_6;
			vszGnojZeLdRFYAcqhmoSmtpgMhiA = P_7;
		}
	}
}
