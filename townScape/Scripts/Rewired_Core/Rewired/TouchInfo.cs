using UnityEngine;

namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal struct TouchInfo
	{
		private bool QHebLaPsQCgsQUgoaPAXQjJFagd;

		private int gCvggaKXiDNMzwMEAAYFLMrWWZTi;

		private Vector2 MtsAGgZUWCEgzANMHtRvwBoIHdJ;

		private Vector2 qYKUaTcbmJrQDvfBBkMSsMpFcVb;

		private Vector2 cnXGbRhnkQzNPjGMGBAMniFaIkp;

		private Vector2 oxagNRFjbBEdIhMIczpcJMoIwSkn;

		private float qceBlSjKmzUJKhVxJmGmGaHPYOy;

		private int siSWdEZMeHowzMIqdbHJwzbVjWa;

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
			QHebLaPsQCgsQUgoaPAXQjJFagd = false;
			gCvggaKXiDNMzwMEAAYFLMrWWZTi = 0;
			MtsAGgZUWCEgzANMHtRvwBoIHdJ = default(Vector2);
			qYKUaTcbmJrQDvfBBkMSsMpFcVb = default(Vector2);
			cnXGbRhnkQzNPjGMGBAMniFaIkp = default(Vector2);
			oxagNRFjbBEdIhMIczpcJMoIwSkn = default(Vector2);
			qceBlSjKmzUJKhVxJmGmGaHPYOy = 0f;
			siSWdEZMeHowzMIqdbHJwzbVjWa = 0;
		}
	}
}
