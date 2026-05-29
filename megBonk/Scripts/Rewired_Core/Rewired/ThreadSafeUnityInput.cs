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
			private const int oOgdfbemjyirCvHSNmerPJkWPSsAA = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] sQYGmGciQxIWYMqhXvmtQsoggAGcb;

			private readonly int HfVWbHlEJIfIFtpLDqdetXfrocUP;

			private readonly int[] gPqJUafbYEiUehDZuAmkotMdwNIA;

			private readonly bool[] XyHaeEMcpTqRzdijRSauqAtBFEncA;

			private bool DpHfRmczbvAQNOxncpWArkPTRGmMA;

			private int epeSKpGiwOzXtdnlKJMqITNuBpef;

			private readonly bool QmHpdGoYkXkSCaxdpedYbjPBBhfbA;

			private bool aMifvqyrgshLrxKGQFoomuLtIXwaA;

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

			private void uLLyyRDKXKdhMJoZdUtjJiqvBDeKA()
			{
			}

			private void TTIIRHdsrmBmoNqMretLJmDzaTszA()
			{
			}

			private void TiBvlwwCmOkeDbDmJadSucWXczkeA()
			{
			}

			private void lpWTeWQeHsKzaLyPLojmANHnnEGb()
			{
			}

			private void mtHOkYFEtcDXfcgeWzxvpqqdRnGhA()
			{
			}

			private void jEJHVNYOIIjOjHkRlVoILqktgVZc()
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int WgrpqeNsTvmLewzblqHJoohHDlYAA = 7;

			private const int KJKEzlwpoQDRYcqoMNjlpGSvNDGFb = 4;

			private readonly bool[] dnifaPTfpgvCznYuKZPLwwGOXdpi;

			private readonly float[] IpmwYRjFzMXUvupkdFEABClXchmR;

			private int AxHrZCNBirfVqbbgBkSAIFsTjMmNA;

			private Vector3 JYXveKaXURzNXnfHlkoHciKvITAF;

			private bool GQNuVpEopbOFzwJwYGiSCTJCEnxPA;

			private bool JiDwgsHhNPnjyyWzEoNpvbHDaLqC;

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

			private void KCjTvEirCYorMrKLzGZoeXNrXHxK()
			{
			}

			private void sgZiuyabsITgisRJxsQfUNsffYse()
			{
			}

			private void oztAeZkOYToowjHQWDGmztLANrnL()
			{
			}

			private void KIDusTpznTkJJJwUBsIrxuAKbSni()
			{
			}

			private void XffQEVIrgdjVeQfXQDQTTzUtQKsF()
			{
			}

			private void UenpttuoMQnClIfBuMkILDUrzcMs()
			{
			}
		}

		private static Mouse yVAgyXAsctqjwHYHNXibVCIznkfEA;

		private static Keyboard SaLbwsCqEKLmDnNiKaIAHUDhVbSCB;

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
