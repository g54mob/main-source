using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool ZMYmpXuTmfgjsFZCBuXpCpzLQuMG;

		private int TJzgrTbQkGJzZOjSdHJJArIOtSRS;

		private Vector2 XxbuUJJamgHcyGtmDNdCTSneehzhA;

		private Vector2 pubRXLNAThSBwHBKOyFZSdmQXNLt;

		private Vector2 KDbJlMKGIrFCMwnyQzNWQojaeFQcA;

		private Vector2 rtTbJAbgyfJvSMlMmAoWerzjYDrmb;

		private float gDoJqIfoleyIHfCuRHGJXLwMcNNX;

		private int lZTDEeEiGTzIUMfXaFVveelqPneOA;

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
			ZMYmpXuTmfgjsFZCBuXpCpzLQuMG = false;
			TJzgrTbQkGJzZOjSdHJJArIOtSRS = 0;
			XxbuUJJamgHcyGtmDNdCTSneehzhA = default(Vector2);
			pubRXLNAThSBwHBKOyFZSdmQXNLt = default(Vector2);
			KDbJlMKGIrFCMwnyQzNWQojaeFQcA = default(Vector2);
			rtTbJAbgyfJvSMlMmAoWerzjYDrmb = default(Vector2);
			gDoJqIfoleyIHfCuRHGJXLwMcNNX = 0f;
			lZTDEeEiGTzIUMfXaFVveelqPneOA = 0;
		}
	}
}
