using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool LtONBCOAjOjRZEHJPkaydNJKzboYB;

		private int NwpaWITHlzwMyEdXxJVCNXwqBdpV;

		private Vector2 NInHVOtevFdPRHUlJbpNSKRGWIDsA;

		private Vector2 vLnkwYdAYWmDDJZLYBIUFzSsagdL;

		private Vector2 UcrMoNspVKqpncTnAsPLBHLWBayFA;

		private Vector2 pMVyHUEzaQSBzrRBggTBsDCiemTd;

		private float yccQyXZVqTVpkpXzHOcMCkMycWzj;

		private int vgVCztwmViIlbIQEuLNeznJWlAMr;

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
			LtONBCOAjOjRZEHJPkaydNJKzboYB = false;
			NwpaWITHlzwMyEdXxJVCNXwqBdpV = 0;
			NInHVOtevFdPRHUlJbpNSKRGWIDsA = default(Vector2);
			vLnkwYdAYWmDDJZLYBIUFzSsagdL = default(Vector2);
			UcrMoNspVKqpncTnAsPLBHLWBayFA = default(Vector2);
			pMVyHUEzaQSBzrRBggTBsDCiemTd = default(Vector2);
			yccQyXZVqTVpkpXzHOcMCkMycWzj = 0f;
			vgVCztwmViIlbIQEuLNeznJWlAMr = 0;
		}
	}
}
