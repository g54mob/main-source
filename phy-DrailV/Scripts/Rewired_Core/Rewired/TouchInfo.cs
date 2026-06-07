using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool khVRRDZeyAQMCtyEScaUzBYcNoig;

		private int MdEfGVDSqTacljzOksrGIbOpUaOcA;

		private Vector2 gSDkXVFZAAKIjnsMhEXwJmTvAHAK;

		private Vector2 WzvytwyRyPBXHUNFhhDFXUQawXyG;

		private Vector2 INguXglkkURSXQaWcfxVKPyRPzsj;

		private Vector2 IWRhniBqnPELAfNOMSWjdLZxtIrK;

		private float KBNzpxtamhuGAKhPldLxtoqojXdL;

		private int YIjaIpZCOVERvbKEPYfGFKGsEOdm;

		public bool isValid
		{
			get
			{
				return khVRRDZeyAQMCtyEScaUzBYcNoig;
			}
			internal set
			{
				khVRRDZeyAQMCtyEScaUzBYcNoig = value;
			}
		}

		public int touchId
		{
			get
			{
				return MdEfGVDSqTacljzOksrGIbOpUaOcA;
			}
			internal set
			{
				MdEfGVDSqTacljzOksrGIbOpUaOcA = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return gSDkXVFZAAKIjnsMhEXwJmTvAHAK;
			}
			internal set
			{
				gSDkXVFZAAKIjnsMhEXwJmTvAHAK = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return WzvytwyRyPBXHUNFhhDFXUQawXyG;
			}
			internal set
			{
				WzvytwyRyPBXHUNFhhDFXUQawXyG = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return INguXglkkURSXQaWcfxVKPyRPzsj;
			}
			internal set
			{
				INguXglkkURSXQaWcfxVKPyRPzsj = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return IWRhniBqnPELAfNOMSWjdLZxtIrK;
			}
			internal set
			{
				IWRhniBqnPELAfNOMSWjdLZxtIrK = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return KBNzpxtamhuGAKhPldLxtoqojXdL;
			}
			internal set
			{
				KBNzpxtamhuGAKhPldLxtoqojXdL = value;
			}
		}

		public int tapCount
		{
			get
			{
				return YIjaIpZCOVERvbKEPYfGFKGsEOdm;
			}
			internal set
			{
				YIjaIpZCOVERvbKEPYfGFKGsEOdm = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			khVRRDZeyAQMCtyEScaUzBYcNoig = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			khVRRDZeyAQMCtyEScaUzBYcNoig = P_0;
			MdEfGVDSqTacljzOksrGIbOpUaOcA = P_1;
			gSDkXVFZAAKIjnsMhEXwJmTvAHAK = P_2;
			WzvytwyRyPBXHUNFhhDFXUQawXyG = P_3;
			INguXglkkURSXQaWcfxVKPyRPzsj = P_4;
			IWRhniBqnPELAfNOMSWjdLZxtIrK = P_5;
			KBNzpxtamhuGAKhPldLxtoqojXdL = P_6;
			YIjaIpZCOVERvbKEPYfGFKGsEOdm = P_7;
		}
	}
}
