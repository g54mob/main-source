using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool BMPaAddjGVntYYgkrBMzijyMLyTiA;

		private int VjoNFbsxGkoarLVwBrvPzcTJhqEO;

		private Vector2 XvkGIxORMEfqADGxrVCAoGglLosL;

		private Vector2 rPkklfMLvRZGMQBwqGbPCrjRmvUZ;

		private Vector2 IeubWuXwQLJGgdHOyhVExTspzqPL;

		private Vector2 tOCuvsxGIDWauoEoWnYCMfiBzvsK;

		private float idfAxoebDKZldmmQnXmVmlhVLrCr;

		private int nzYlmSRekhULoXflOzftDjmbgNjW;

		public bool isValid
		{
			get
			{
				return BMPaAddjGVntYYgkrBMzijyMLyTiA;
			}
			internal set
			{
				BMPaAddjGVntYYgkrBMzijyMLyTiA = value;
			}
		}

		public int touchId
		{
			get
			{
				return VjoNFbsxGkoarLVwBrvPzcTJhqEO;
			}
			internal set
			{
				VjoNFbsxGkoarLVwBrvPzcTJhqEO = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return XvkGIxORMEfqADGxrVCAoGglLosL;
			}
			internal set
			{
				XvkGIxORMEfqADGxrVCAoGglLosL = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return rPkklfMLvRZGMQBwqGbPCrjRmvUZ;
			}
			internal set
			{
				rPkklfMLvRZGMQBwqGbPCrjRmvUZ = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return IeubWuXwQLJGgdHOyhVExTspzqPL;
			}
			internal set
			{
				IeubWuXwQLJGgdHOyhVExTspzqPL = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return tOCuvsxGIDWauoEoWnYCMfiBzvsK;
			}
			internal set
			{
				tOCuvsxGIDWauoEoWnYCMfiBzvsK = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return idfAxoebDKZldmmQnXmVmlhVLrCr;
			}
			internal set
			{
				idfAxoebDKZldmmQnXmVmlhVLrCr = value;
			}
		}

		public int tapCount
		{
			get
			{
				return nzYlmSRekhULoXflOzftDjmbgNjW;
			}
			internal set
			{
				nzYlmSRekhULoXflOzftDjmbgNjW = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			BMPaAddjGVntYYgkrBMzijyMLyTiA = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			BMPaAddjGVntYYgkrBMzijyMLyTiA = P_0;
			VjoNFbsxGkoarLVwBrvPzcTJhqEO = P_1;
			XvkGIxORMEfqADGxrVCAoGglLosL = P_2;
			rPkklfMLvRZGMQBwqGbPCrjRmvUZ = P_3;
			IeubWuXwQLJGgdHOyhVExTspzqPL = P_4;
			tOCuvsxGIDWauoEoWnYCMfiBzvsK = P_5;
			idfAxoebDKZldmmQnXmVmlhVLrCr = P_6;
			nzYlmSRekhULoXflOzftDjmbgNjW = P_7;
		}
	}
}
