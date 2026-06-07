using UnityEngine;

namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal static class ThreadSafeUnityInput
	{
		[CustomObfuscation]
		[CustomClassObfuscation]
		public sealed class Keyboard
		{
			private const int RXjRgsOMDkllwCDJkaPbnwoTSzQH = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] ewmMiMDnonJriaNsfivBtvQjMOzi;

			private readonly int bSkEQoFNHmMejiZadjRvNbwinMCUE;

			private readonly int[] nfBdsxGcSnOQTMYpOdFZnKqcjnilA;

			private readonly bool[] freVGZZoLcUutVigWPIUYOXCaOFo;

			private bool llkLFSoLVtaASCstwdnHCsIDxnhYb;

			private int hHHiPLJOcmgggAGjRdFsxfAOXIlG;

			private readonly bool jYeZsMeNsIJLGmlRwyPXaqKuUsHK;

			private bool zyteTGlFgKrfnMkkIGebhCxfFOBXA;

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

			private void DmAsJbfQQaaUsgDgiDywzbcGfubK()
			{
			}

			private void iqSeAMNoRFWAzJLKanbJnrgyPcwX()
			{
			}

			private void LtUUiWcLZFdoJIVOQEyPFpJckyCw()
			{
			}

			private void jMzDHhPwtJmEmgfQrCGWVHZXAKKv()
			{
			}

			private void iOwcaJiNhHoUtnrAzFfLGltXcegHA()
			{
			}

			private void QCWAqVkqFddIpdFaitIGikJfbiFhB()
			{
			}
		}

		[CustomObfuscation]
		[CustomClassObfuscation]
		public sealed class Mouse
		{
			private const int CslwhBCeGKNctEjyAWkxAmQhbouC = 7;

			private const int AaihlwBABrsvNIbzidACPdKeixsCA = 4;

			private readonly bool[] ZvPFEBoODFIFAalgjPuHlidSttRw;

			private readonly float[] oelaYhnmcedAmsllPBWChpEQMWAf;

			private int hHHiPLJOcmgggAGjRdFsxfAOXIlG;

			private Vector3 rgTEYyHlAbgfWCHMWSrszGgvNFThA;

			private bool ytxhvgKCwJNkiUItnUJFKgIUvyVq;

			private bool gOTTwzSodYNHJYteHDopaepqDXihA;

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

			private void DmAsJbfQQaaUsgDgiDywzbcGfubK()
			{
			}

			private void iqSeAMNoRFWAzJLKanbJnrgyPcwX()
			{
			}

			private void LtUUiWcLZFdoJIVOQEyPFpJckyCw()
			{
			}

			private void jMzDHhPwtJmEmgfQrCGWVHZXAKKv()
			{
			}

			private void oFMdIngisYAfVIEwlujgcvGDvCBvA()
			{
			}

			private void QCWAqVkqFddIpdFaitIGikJfbiFhB()
			{
			}
		}

		private static Mouse efFBGlzgiieSBvsyNvhDahCFSnlM;

		private static Keyboard HpBePlHRDrcclVCNoiaHkUPloXeDA;

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
