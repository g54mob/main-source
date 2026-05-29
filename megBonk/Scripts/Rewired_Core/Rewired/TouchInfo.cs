using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool SzxDbpYCjRjSoFUWmwIaBjpkpIRBb;

		private int GDUcodTspyBMRLFQMApCnfIlPCEV;

		private Vector2 QDERvbvlvKdQsHHwmMJViylETdidB;

		private Vector2 cyCBQtxmWLirkGyOzslMhpmxTJSv;

		private Vector2 NuQMOigPVNqmSnxwxrtLnapBABLFA;

		private Vector2 cJsOLqOzmHBAGwMrJUIXMflpNoai;

		private float tJLGYmJboKKMFumqoMaEaaghsDCy;

		private int cMcDrKoLZfaYSDTEJxYsVvJNfEnC;

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
			SzxDbpYCjRjSoFUWmwIaBjpkpIRBb = false;
			GDUcodTspyBMRLFQMApCnfIlPCEV = 0;
			QDERvbvlvKdQsHHwmMJViylETdidB = default(Vector2);
			cyCBQtxmWLirkGyOzslMhpmxTJSv = default(Vector2);
			NuQMOigPVNqmSnxwxrtLnapBABLFA = default(Vector2);
			cJsOLqOzmHBAGwMrJUIXMflpNoai = default(Vector2);
			tJLGYmJboKKMFumqoMaEaaghsDCy = 0f;
			cMcDrKoLZfaYSDTEJxYsVvJNfEnC = 0;
		}
	}
}
