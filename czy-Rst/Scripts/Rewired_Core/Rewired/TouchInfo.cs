using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool GmhDfMpKlExHOYbUjUjBfYgpWGLF;

		private int KMGZQOwYEvicvDmjVpRtlzbcGKEi;

		private Vector2 QPCHWYQAPPvmIJVodXuagERQpIeD;

		private Vector2 kqGdiMaYhQcUURCjuvfjgvHweDCXA;

		private Vector2 FcKkqDTwUUVBqrGTktMcfLSENHXi;

		private Vector2 gSsowNhyCQkQyyCbAeSuShKssFgy;

		private float hWLkDUyNgFfijgXotyUdqBNcVAGF;

		private int gVyzbvHcmeABgJLqSHvXrPCYJtvhA;

		public bool isValid
		{
			get
			{
				return GmhDfMpKlExHOYbUjUjBfYgpWGLF;
			}
			internal set
			{
				GmhDfMpKlExHOYbUjUjBfYgpWGLF = value;
			}
		}

		public int touchId
		{
			get
			{
				return KMGZQOwYEvicvDmjVpRtlzbcGKEi;
			}
			internal set
			{
				KMGZQOwYEvicvDmjVpRtlzbcGKEi = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return QPCHWYQAPPvmIJVodXuagERQpIeD;
			}
			internal set
			{
				QPCHWYQAPPvmIJVodXuagERQpIeD = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return kqGdiMaYhQcUURCjuvfjgvHweDCXA;
			}
			internal set
			{
				kqGdiMaYhQcUURCjuvfjgvHweDCXA = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return FcKkqDTwUUVBqrGTktMcfLSENHXi;
			}
			internal set
			{
				FcKkqDTwUUVBqrGTktMcfLSENHXi = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return gSsowNhyCQkQyyCbAeSuShKssFgy;
			}
			internal set
			{
				gSsowNhyCQkQyyCbAeSuShKssFgy = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return hWLkDUyNgFfijgXotyUdqBNcVAGF;
			}
			internal set
			{
				hWLkDUyNgFfijgXotyUdqBNcVAGF = value;
			}
		}

		public int tapCount
		{
			get
			{
				return gVyzbvHcmeABgJLqSHvXrPCYJtvhA;
			}
			internal set
			{
				gVyzbvHcmeABgJLqSHvXrPCYJtvhA = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			GmhDfMpKlExHOYbUjUjBfYgpWGLF = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			GmhDfMpKlExHOYbUjUjBfYgpWGLF = P_0;
			KMGZQOwYEvicvDmjVpRtlzbcGKEi = P_1;
			QPCHWYQAPPvmIJVodXuagERQpIeD = P_2;
			kqGdiMaYhQcUURCjuvfjgvHweDCXA = P_3;
			FcKkqDTwUUVBqrGTktMcfLSENHXi = P_4;
			gSsowNhyCQkQyyCbAeSuShKssFgy = P_5;
			hWLkDUyNgFfijgXotyUdqBNcVAGF = P_6;
			gVyzbvHcmeABgJLqSHvXrPCYJtvhA = P_7;
		}
	}
}
