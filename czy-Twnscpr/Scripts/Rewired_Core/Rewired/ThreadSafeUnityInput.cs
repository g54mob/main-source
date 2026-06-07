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
			private const int KHMUiUwFxgBkOdGppNpWfZanfjTr = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] lsLXhqnTKnvOIgwCcIbiLfIXqba;

			private readonly int ivNhrKvFfqJjVPiWuHEEPQgFEzNG;

			private readonly int[] kjcPkDWZyxZwfYtVDAvcamyIOud;

			private readonly bool[] cvDxavnstobtXBlWHHjlkuDslWA;

			private bool ebJsAuYejvRqociTxulmKyAPKrq;

			private int eRmDLfvPwqjzMWGuKHaRBCzaAkeg;

			private readonly bool qbBJFcIBKCfIeulrbQwcUfGSarS;

			private bool wGeccZjSKcJXWVCBnSWeahDvTA;

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

			private void KOdoINRCmkneEewWlxWXPBaqGOo()
			{
			}

			private void pgnlyEdlmTJJdFuqtwqgZcYCNzz()
			{
			}

			private void EjpLTuIpjPjLpYFuRnNgdRHOXFB()
			{
			}

			private void kWESwHfFHBszAkcagbTpbdJrvtNS()
			{
			}

			private void lYZdTrHOPBXXJHxqgoeghynlqZng()
			{
			}

			private void ZfzRXdUwplBAZPUWlPKdIEBFHAI()
			{
			}
		}

		[CustomObfuscation]
		[CustomClassObfuscation]
		public sealed class Mouse
		{
			private const int NoIkHJatIKHMFGIHJxPWgXaDsAp = 7;

			private const int HkPyUGvYbjfhjSKDxFZprCOWIEl = 4;

			private readonly bool[] WlmpbMCpbLOJssSkuliwJzUqMhA;

			private readonly float[] dBMAXHXIAwbgAgwBUEAvGHYmxpVa;

			private int eRmDLfvPwqjzMWGuKHaRBCzaAkeg;

			private Vector3 iXsbdWJRkhQigLieXMeJufoXoaM;

			private bool jKQWfCmEZRzVOITaaQvkcSqeNhI;

			private bool zFqJNVgsDUAFnEqUIrXOIgzOqhr;

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

			private void KOdoINRCmkneEewWlxWXPBaqGOo()
			{
			}

			private void pgnlyEdlmTJJdFuqtwqgZcYCNzz()
			{
			}

			private void EjpLTuIpjPjLpYFuRnNgdRHOXFB()
			{
			}

			private void kWESwHfFHBszAkcagbTpbdJrvtNS()
			{
			}

			private void hdpjdPbIQOfgdyMSaUaLcBGpxvIf()
			{
			}

			private void ZfzRXdUwplBAZPUWlPKdIEBFHAI()
			{
			}
		}

		private static Mouse fCgccRdFEsFVhwfUIsuonGQrOSsO;

		private static Keyboard IfyeNQnjbulRbHlFtvaCaRVLyzE;

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
