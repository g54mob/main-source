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
			private const int rvPqvDEoYGZJQYOduCFowegtWFlI = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] vbpbYsMCPNqpAxdveQYkBgtRKDxc;

			private readonly int GswgVzJpUuQmFinXecRjCIxKscBM;

			private readonly int[] lSauCuYteyuGWaKXuUofXorjYwAN;

			private readonly bool[] OfsPzgsCotFndepluaMvfFlkIWwZA;

			private bool EZwMOCRfyJcPJaNjXuoZVkDmMYdh;

			private int nyTFTZHeriSDvAildYtnktDPEZtVA;

			private readonly bool DWcyHiSBndIcGbFrQqPBQiJcChyeA;

			private bool hqPuWCKKhUpVzkqQpATxFTtONxfE;

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

			private void pwqfJbdSegJlEYPDQTRgseEYHPpe()
			{
			}

			private void SWbSadLgcQcQmWgYUOBYZqRUBXzX()
			{
			}

			private void SbuiiAEGvmOSFfkictPXEDYyjrlqA()
			{
			}

			private void sICvEYgdzhRibSiqwnYifIJebpRX()
			{
			}

			private void lGsbfgxwgIQddzralEHqRBwYMpXr()
			{
			}

			private void oyoAIxcxNgbHbkMoOTdBCqoUPyAcA()
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int VJWdvMbjSBfXefbtUevMDavqZtNN = 7;

			private const int NqpqCBOjpmllGhNerBxuhHQSFZBf = 4;

			private readonly bool[] odFewrcboKnBxmcwlNzUXlApfNkz;

			private readonly float[] JmXFztPcuwinbvDkKOzVgilmglfP;

			private int RqqbSyzKxLrbkqsomGaPqJyueYnBA;

			private Vector3 KpgOiiQXVpaHRqULEvWCTdWGDQBZ;

			private bool BojARynyXYpbdzwnmWLwdRllnkU;

			private bool IbkazWbnydNTclvAvTWcYrjyAapz;

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

			private void TLMbagQpLwbFUdgJMmrbFWVOWLwO()
			{
			}

			private void pwsEhQWJdiBrijMPAKYgnXBMOnpv()
			{
			}

			private void bPIGHbQpRnaQsmgWvodxCNVvjFqS()
			{
			}

			private void NpuLtlRGqxdOZgAWwMSsCUWfJvajA()
			{
			}

			private void AZGALrifzDkBmNMDpwzSuVOYTIlT()
			{
			}

			private void JiAcXXAdZkyTdHyNTKnJwFWMGgTO()
			{
			}
		}

		private static Mouse twxnitSKzNNHeFLLgCkydLIQkTaH;

		private static Keyboard XqwdAIMTaiIGZOuytuRRlREqvZnc;

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
