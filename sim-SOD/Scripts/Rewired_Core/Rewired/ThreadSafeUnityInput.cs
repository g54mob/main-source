using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal static class ThreadSafeUnityInput
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Keyboard
		{
			private const int LlrUovCfTUxGGUgnbJAcjbLKjpNi = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] yhyDRRZoLHBSEyONaYUQbdksrmk;

			private readonly int dcyhTxNlXIboFTaCcNpudNNwGrFe;

			private readonly int[] frVkdiyPMRpSbAuPLPjICNDxFKx;

			private readonly bool[] zekuRYZTHMOsPDNCDbiHUFeRqnA;

			private bool fYgWWBiWXTDKmooXjoXGiYdmpQy;

			private int fyRczSRiMYReMGBmSoRjbOUPLus;

			private readonly bool dksotJwRailPusWnrhjGmtljpnI;

			private bool hObGGTjtscArLoYWPUKqvSYehbQz;

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

			private void JYUtGmfdWSfqUaoGpVQvbxVDJKgO()
			{
			}

			private void efAGZBGRXjjWFHBqhmRKYtJjrFzV()
			{
			}

			private void PeWmhXkdTvDwdFOoZuWAdVqpAJNv()
			{
			}

			private void nZhGPcXCdpunEqJyqkvPBOcCxLN()
			{
			}

			private void mqVvKfsvCtKPQvyFcDCpGAKMFxa()
			{
			}

			private void UNCNfKqZXTGrHRbAxigPcwcowTA()
			{
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Mouse
		{
			private const int AGbvGyAZcoNXFAfJJcJqOTZcEUj = 7;

			private const int QmmoibDITFcHbYcFvIuDXnjfGMpc = 4;

			private readonly bool[] VkPFJCiiJjjRwtsEoPQYtrARvQCi;

			private readonly float[] eQpdvinqDQdyYoLCSrhJndOXzeX;

			private int fyRczSRiMYReMGBmSoRjbOUPLus;

			private Vector3 vrTEBltMUBKduZZiFDBfCNJsLsW;

			private bool sInZcbKisrdaIbQPsGdOYIvJQNGc;

			private bool kBRqpeGLjsGHlCDKAJEoJqQxBgvI;

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

			private void JYUtGmfdWSfqUaoGpVQvbxVDJKgO()
			{
			}

			private void efAGZBGRXjjWFHBqhmRKYtJjrFzV()
			{
			}

			private void PeWmhXkdTvDwdFOoZuWAdVqpAJNv()
			{
			}

			private void nZhGPcXCdpunEqJyqkvPBOcCxLN()
			{
			}

			private void sQePqOyicBnpZSImnBrXlhKKzMG()
			{
			}

			private void UNCNfKqZXTGrHRbAxigPcwcowTA()
			{
			}
		}

		private static Mouse urVOoypsBMELzlMtODSOqfBGWEk;

		private static Keyboard TeJgUeEJBHtiZABpdKGEECckTube;

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
