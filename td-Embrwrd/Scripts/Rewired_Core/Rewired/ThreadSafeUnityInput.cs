using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal static class ThreadSafeUnityInput
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Keyboard
		{
			private const int rEljkfjPbjEmMdRbuGdBXAuyMnbH = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] rFsrMrsmyvCCMcJwWOZamiOArLC;

			private readonly int WQWNMNkrvZEtDBhSaXPStohHoyNl;

			private readonly int[] nTKgTGxwFTEZERSIsAoKjirocuGZA;

			private readonly bool[] EeKgoGTtLWPchXQymGiAoAzfhGmS;

			private bool IMXhcaXPurATTqmRshqkHMbGvrd;

			private int pnnTEzLCWDtKfFmwpytMOHFCYBjO;

			private readonly bool PhOrWOplQYnqGYFsIGRkrLRfbdmFA;

			private bool tPvbjkhmYtDyldHRbUAQayDXtZrjA;

			public bool enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool monitoring => false;

			public int keyCount => 0;

			static Keyboard()
			{
			}

			public void Initialize()
			{
			}

			public void PostInitialize()
			{
			}

			public void Update()
			{
			}

			public void Monitor(bool state)
			{
			}

			public bool GetKey(KeyCode keyCode)
			{
				return false;
			}

			public void GetKeyValues(bool[] values)
			{
			}

			public void Clear()
			{
			}

			private void jeIkxHYvzFUKAdMBCRWRRsXRZubd()
			{
			}

			private void AIJZNRcFFncZwnYTSAZrqXLNQDtM()
			{
			}

			private void KHQTdcfLYNFDRLQvyrPwqHWrqzpS()
			{
			}

			private void kakETyHXSEpvbEfrmjWFJWTnqrTIA()
			{
			}

			private void pzSkTKIbNvsptItvxLHPyaaLzkNl()
			{
			}

			private void sNKyTFTSmXoYxffrYBhwLUcZDwYQ()
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int FwsqIiYPtuwOwWAuGxwninlzvnDH = 7;

			private const int TmLlhrpKrTqCqChqlZBzYUHNLBDb = 4;

			private readonly bool[] ijtzhFMsXbEIjKZjnXxlafYiZTeo;

			private readonly float[] LxhsoVyrRTskjKcxKxxiRqnhChpQ;

			private int TpUHTSGKCqezkHUzoikkJwgdOzpG;

			private Vector3 UrWhrAbxuMLIRBWEQGUtwUELNOVo;

			private bool FVWXkxLhHykWtWaxlGGgJpRofbgm;

			private bool UHAagqjEZKCWwtKDtDWJJrxpmshWA;

			public bool monitoring => false;

			public Vector3 mousePosition => default(Vector3);

			public bool mousePresent => false;

			public void PostInitialize()
			{
			}

			public void Update()
			{
			}

			public void Monitor(bool state)
			{
			}

			public bool GetButton(int index)
			{
				return false;
			}

			public float GetAxisRaw(int index)
			{
				return 0f;
			}

			public void GetButtonValues(bool[] buttons)
			{
			}

			public void GetAxisRawValues(float[] axes)
			{
			}

			private void DrqpuGrHsBSZMHEASxmAqkLJVJol()
			{
			}

			private void jmSrwwxkCPpqaQUASTATCQBHfhrgA()
			{
			}

			private void ntioWNlhqKLZuJzVvnRSnYNmTpik()
			{
			}

			private void RTCJcVakVCrRBzMRqERXpXCgdUkj()
			{
			}

			private void OGgWrBXsEkQnewaOxvDlJfQRUshl()
			{
			}

			private void HywbjzrTcJbfxyNIFQduFXCHwgNI()
			{
			}
		}

		private static Mouse dNgoVrJQcEUiuVYaFOPHMCZKgwFb;

		private static Keyboard TLEymujaaFNbFperlgoaSIZbhaZH;

		public static Mouse mouse => null;

		public static Keyboard keyboard => null;

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
		}

		public static void Update()
		{
		}
	}
}
