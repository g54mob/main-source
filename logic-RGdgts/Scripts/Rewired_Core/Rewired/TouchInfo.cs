using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation]
	[CustomObfuscation]
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
				return false;
			}
			internal set
			{
			}
		}

		public int touchId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return default(Vector2);
			}
			internal set
			{
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return default(Vector2);
			}
			internal set
			{
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return default(Vector2);
			}
			internal set
			{
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return default(Vector2);
			}
			internal set
			{
			}
		}

		public float deltaTime
		{
			get
			{
				return 0f;
			}
			internal set
			{
			}
		}

		public int tapCount
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		internal static TouchInfo Invalid => default(TouchInfo);

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			TDDNWUzJKMwhkWMQvgSgckxbIHat = false;
			zTUCFKbiIPWDNCRiZCLisZvkAgSu = 0;
			BPVGjEixuIdhFhOeeOgAUIcAaWGsb = default(Vector2);
			tIlYxrIWMFPkfpOlSFXjfOnvleiPA = default(Vector2);
			rkuwlpDhOEQgbrSiRbDdZvDSvXgr = default(Vector2);
			rnZsrHrJcHwetYuXbaFoeuNkbvMb = default(Vector2);
			fYFqcqFESzODgvkxGgfDGaZjghlOA = 0f;
			vszGnojZeLdRFYAcqhmoSmtpgMhiA = 0;
		}
	}
}
