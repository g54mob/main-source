using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool TQiazvLBHQWhcwnRPIuSndzWSYQp;

		private int XwNNgrAcFriwBhnJhpDeQzGHoUTDA;

		private Vector2 FgRjIponNZfvsfNbPhohkejrvmjH;

		private Vector2 joRfMxsEoKGEcdoVSKDqtxkLsPNeA;

		private Vector2 YBVUhgvElMDDUPfjEMLjdlrtAJGbA;

		private Vector2 rSbzSaVOFWoyUWbPyjqdEOdHcDzOA;

		private float uZYaUgQVIRWzPQHrZfIsopkVfJZw;

		private int lhtqPCdzjyHQOlZMgJJATWpvnpqh;

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
			TQiazvLBHQWhcwnRPIuSndzWSYQp = false;
			XwNNgrAcFriwBhnJhpDeQzGHoUTDA = 0;
			FgRjIponNZfvsfNbPhohkejrvmjH = default(Vector2);
			joRfMxsEoKGEcdoVSKDqtxkLsPNeA = default(Vector2);
			YBVUhgvElMDDUPfjEMLjdlrtAJGbA = default(Vector2);
			rSbzSaVOFWoyUWbPyjqdEOdHcDzOA = default(Vector2);
			uZYaUgQVIRWzPQHrZfIsopkVfJZw = 0f;
			lhtqPCdzjyHQOlZMgJJATWpvnpqh = 0;
		}
	}
}
