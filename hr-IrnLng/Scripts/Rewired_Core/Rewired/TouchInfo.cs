using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct TouchInfo
	{
		private bool XunqwswVrwsPPbJKQLruGBplRnw;

		private int dVanpacqxfnOitlowqQsUSlySwE;

		private Vector2 RglDryqJgistexgzzbTAyuDsIRU;

		private Vector2 fHVLTeJfYbjIkEzZhUvHadsxeaV;

		private Vector2 hgULGFYbWgxEKMqseSIzlRBWVPe;

		private Vector2 xjntKHcjwjSbPxmqEDbZSsguFrnA;

		private float vttELMSChXhQNSexxjoXUnTlfvv;

		private int teNJhQgLTngWefweRdLecWtnYXr;

		public bool isValid
		{
			get
			{
				return XunqwswVrwsPPbJKQLruGBplRnw;
			}
			internal set
			{
				XunqwswVrwsPPbJKQLruGBplRnw = value;
			}
		}

		public int touchId
		{
			get
			{
				return dVanpacqxfnOitlowqQsUSlySwE;
			}
			internal set
			{
				dVanpacqxfnOitlowqQsUSlySwE = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return RglDryqJgistexgzzbTAyuDsIRU;
			}
			internal set
			{
				RglDryqJgistexgzzbTAyuDsIRU = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return fHVLTeJfYbjIkEzZhUvHadsxeaV;
			}
			internal set
			{
				fHVLTeJfYbjIkEzZhUvHadsxeaV = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return hgULGFYbWgxEKMqseSIzlRBWVPe;
			}
			internal set
			{
				hgULGFYbWgxEKMqseSIzlRBWVPe = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return xjntKHcjwjSbPxmqEDbZSsguFrnA;
			}
			internal set
			{
				xjntKHcjwjSbPxmqEDbZSsguFrnA = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return vttELMSChXhQNSexxjoXUnTlfvv;
			}
			internal set
			{
				vttELMSChXhQNSexxjoXUnTlfvv = value;
			}
		}

		public int tapCount
		{
			get
			{
				return teNJhQgLTngWefweRdLecWtnYXr;
			}
			internal set
			{
				teNJhQgLTngWefweRdLecWtnYXr = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			XunqwswVrwsPPbJKQLruGBplRnw = false
		};

		internal TouchInfo(bool isValid, int touchId, Vector2 touchPos, Vector2 touchPosRaw, Vector2 deltaPos, Vector2 deltaPosRaw, float deltaTime, int tapCount)
		{
			XunqwswVrwsPPbJKQLruGBplRnw = isValid;
			dVanpacqxfnOitlowqQsUSlySwE = touchId;
			RglDryqJgistexgzzbTAyuDsIRU = touchPos;
			fHVLTeJfYbjIkEzZhUvHadsxeaV = touchPosRaw;
			hgULGFYbWgxEKMqseSIzlRBWVPe = deltaPos;
			xjntKHcjwjSbPxmqEDbZSsguFrnA = deltaPosRaw;
			vttELMSChXhQNSexxjoXUnTlfvv = deltaTime;
			teNJhQgLTngWefweRdLecWtnYXr = tapCount;
		}
	}
}
