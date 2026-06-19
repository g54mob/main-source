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
				return LtONBCOAjOjRZEHJPkaydNJKzboYB;
			}
			internal set
			{
				LtONBCOAjOjRZEHJPkaydNJKzboYB = value;
			}
		}

		public int touchId
		{
			get
			{
				return NwpaWITHlzwMyEdXxJVCNXwqBdpV;
			}
			internal set
			{
				NwpaWITHlzwMyEdXxJVCNXwqBdpV = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return NInHVOtevFdPRHUlJbpNSKRGWIDsA;
			}
			internal set
			{
				NInHVOtevFdPRHUlJbpNSKRGWIDsA = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return vLnkwYdAYWmDDJZLYBIUFzSsagdL;
			}
			internal set
			{
				vLnkwYdAYWmDDJZLYBIUFzSsagdL = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return UcrMoNspVKqpncTnAsPLBHLWBayFA;
			}
			internal set
			{
				UcrMoNspVKqpncTnAsPLBHLWBayFA = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return pMVyHUEzaQSBzrRBggTBsDCiemTd;
			}
			internal set
			{
				pMVyHUEzaQSBzrRBggTBsDCiemTd = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return yccQyXZVqTVpkpXzHOcMCkMycWzj;
			}
			internal set
			{
				yccQyXZVqTVpkpXzHOcMCkMycWzj = value;
			}
		}

		public int tapCount
		{
			get
			{
				return vgVCztwmViIlbIQEuLNeznJWlAMr;
			}
			internal set
			{
				vgVCztwmViIlbIQEuLNeznJWlAMr = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			LtONBCOAjOjRZEHJPkaydNJKzboYB = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			LtONBCOAjOjRZEHJPkaydNJKzboYB = P_0;
			NwpaWITHlzwMyEdXxJVCNXwqBdpV = P_1;
			NInHVOtevFdPRHUlJbpNSKRGWIDsA = P_2;
			vLnkwYdAYWmDDJZLYBIUFzSsagdL = P_3;
			UcrMoNspVKqpncTnAsPLBHLWBayFA = P_4;
			pMVyHUEzaQSBzrRBggTBsDCiemTd = P_5;
			yccQyXZVqTVpkpXzHOcMCkMycWzj = P_6;
			vgVCztwmViIlbIQEuLNeznJWlAMr = P_7;
		}
	}
}
