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
			private const int pKLyHKcLrtlsfGLLyBGvezYBCtZAA = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] lEjUOrqxAyBDvvbuoIMjGeSnxhxQ;

			private readonly int CoqaawxqFNDFsFaQsNPmsFRmMZxLA;

			private readonly int[] vnmnLjmChFnVnqmSkmWiCLHZNLsJ;

			private readonly bool[] UAmKNbYVtOYjSaOuqCmeImLQrOQK;

			private bool EGqStLlxjcDXewFeHTuSYQjAVlTN;

			private int tLloIGNsBTyAkzerghkkKlzxaVO;

			private readonly bool DJkkDvwvkQkRllAmYnNYFQlKZICp;

			private bool dqZrVFeQgnhMKoEPlCEoAAlePuZmA;

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

			private void vJiAWcVWTLBglFOAOsRbglWequFfB()
			{
			}

			private void MjhlrcpUrpBlLCMJKgTTgGxsbsFzA()
			{
			}

			private void QsJgXeXmNjesuUfaPUEAByOGONi()
			{
			}

			private void mxEjcJQkmOJxKQshoMUnoMzGCkvj()
			{
			}

			private void vzoEKpHLtjDYObvhdRPlcWCqVMbhA()
			{
			}

			private void uHkrjyQAaNwAWQnIAhyExAzmTGmC()
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int PwWHQPBPTsmIZhdkGAzHhKHOrKtAA = 7;

			private const int TPtUBCupsFfQdrFntPXbkymueirU = 4;

			private readonly bool[] uCNZbcBdlngFAsbnbhZLIpiPqKAi;

			private readonly float[] XTDcEipDvRSYArkvMftWvrXCBGHR;

			private int PPqEzpBciofSDcmtqGqSTvWIanXNA;

			private Vector3 YQaNizoPUOwNewICASXHYaewtnlH;

			private bool FzcGtUFQhoLYIUvdbgAWchbDZIIOb;

			private bool WEaMSJXlOOeVHnTUbKlvTTiEFGBd;

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

			private void NuUEVjqNCFOofcmSSDzgWOzuigOs()
			{
			}

			private void vJobMReYqXdEJzgWKnWxyzpwrQRt()
			{
			}

			private void jQKAmguWWCpXBcfZrebkJLvBteSQ()
			{
			}

			private void TQeEgojalOedeCZJitIpDMsJRYYM()
			{
			}

			private void IGMGeiUQgigVPDGSlaxFrbcaYnXs()
			{
			}

			private void XXSHTIctMPnBAXDKNmKMjMuwjDts()
			{
			}
		}

		private static Mouse rJlTAsmCgoRiXJaEsZCvwoocaLGEA;

		private static Keyboard NPkbWTdyGBZniaAbvdoGTczUIEdeb;

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
