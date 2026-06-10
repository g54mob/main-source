using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool ZsZyPFdVWepsAMegkdwtgzGwOgz;

		private int rDUKLufOglXjBMWIUpnQeQdhXEL;

		private Vector2 PaLheVvnguAnhSwIDiGDAvHvrhX;

		private Vector2 xTbleyQrAdToDfiHBOreWFIeZFh;

		private Vector2 zwuqawPCQoNgHfAKUGreJJuNcmtN;

		private Vector2 bdDapcdqJjiiQISEgPWIfwPcpQuy;

		private float nMFwnxHMQLRXUlXNFcPIyJggbAoe;

		private int tGdcirkzsvCzhFAWbjWzpSSOcdkO;

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

		internal TouchInfo(bool isValid, int touchId, Vector2 touchPos, Vector2 touchPosRaw, Vector2 deltaPos, Vector2 deltaPosRaw, float deltaTime, int tapCount)
		{
			ZsZyPFdVWepsAMegkdwtgzGwOgz = false;
			rDUKLufOglXjBMWIUpnQeQdhXEL = 0;
			PaLheVvnguAnhSwIDiGDAvHvrhX = default(Vector2);
			xTbleyQrAdToDfiHBOreWFIeZFh = default(Vector2);
			zwuqawPCQoNgHfAKUGreJJuNcmtN = default(Vector2);
			bdDapcdqJjiiQISEgPWIfwPcpQuy = default(Vector2);
			nMFwnxHMQLRXUlXNFcPIyJggbAoe = 0f;
			tGdcirkzsvCzhFAWbjWzpSSOcdkO = 0;
		}
	}
}
