using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct TouchInfo
	{
		private bool xhFJJGDiKvRiLmguDLDnIgIPLnO;

		private int XHUbYEgXOqgtiruYhEEpREMIQeup;

		private Vector2 rnRyoORYedNKcmCSszmDmWTWApi;

		private Vector2 HejwNhiTIqEyKPQZqUEyqLOJiTC;

		private Vector2 ZSqonlzWGtOQKZWIvKicxgwcXMO;

		private Vector2 PwHDfhBoFsiQHGuCNghMUYPOrdNu;

		private float LCFdMobMUWrXtLPAsaHGYoBTpDL;

		private int ThzimEFixwDgsySPEpnOmGCXAXJ;

		public bool isValid
		{
			get
			{
				return xhFJJGDiKvRiLmguDLDnIgIPLnO;
			}
			internal set
			{
				xhFJJGDiKvRiLmguDLDnIgIPLnO = value;
			}
		}

		public int touchId
		{
			get
			{
				return XHUbYEgXOqgtiruYhEEpREMIQeup;
			}
			internal set
			{
				XHUbYEgXOqgtiruYhEEpREMIQeup = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return rnRyoORYedNKcmCSszmDmWTWApi;
			}
			internal set
			{
				rnRyoORYedNKcmCSszmDmWTWApi = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return HejwNhiTIqEyKPQZqUEyqLOJiTC;
			}
			internal set
			{
				HejwNhiTIqEyKPQZqUEyqLOJiTC = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return ZSqonlzWGtOQKZWIvKicxgwcXMO;
			}
			internal set
			{
				ZSqonlzWGtOQKZWIvKicxgwcXMO = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return PwHDfhBoFsiQHGuCNghMUYPOrdNu;
			}
			internal set
			{
				PwHDfhBoFsiQHGuCNghMUYPOrdNu = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return LCFdMobMUWrXtLPAsaHGYoBTpDL;
			}
			internal set
			{
				LCFdMobMUWrXtLPAsaHGYoBTpDL = value;
			}
		}

		public int tapCount
		{
			get
			{
				return ThzimEFixwDgsySPEpnOmGCXAXJ;
			}
			internal set
			{
				ThzimEFixwDgsySPEpnOmGCXAXJ = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			xhFJJGDiKvRiLmguDLDnIgIPLnO = false
		};

		internal TouchInfo(bool isValid, int touchId, Vector2 touchPos, Vector2 touchPosRaw, Vector2 deltaPos, Vector2 deltaPosRaw, float deltaTime, int tapCount)
		{
			xhFJJGDiKvRiLmguDLDnIgIPLnO = isValid;
			XHUbYEgXOqgtiruYhEEpREMIQeup = touchId;
			rnRyoORYedNKcmCSszmDmWTWApi = touchPos;
			HejwNhiTIqEyKPQZqUEyqLOJiTC = touchPosRaw;
			ZSqonlzWGtOQKZWIvKicxgwcXMO = deltaPos;
			PwHDfhBoFsiQHGuCNghMUYPOrdNu = deltaPosRaw;
			LCFdMobMUWrXtLPAsaHGYoBTpDL = deltaTime;
			ThzimEFixwDgsySPEpnOmGCXAXJ = tapCount;
		}
	}
}
