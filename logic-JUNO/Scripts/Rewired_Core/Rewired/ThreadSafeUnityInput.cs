using System;
using Rewired.Utils;
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
			private const int fEXRHhWqXIlntPmxcJntlNRxUGEl = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] xtzMzAIWoXYrpovQsXwlMWZVOzsg;

			private readonly int KAygaHDJlmUMurloaMGskPKYxkuY;

			private readonly int[] dtqLfUEdHqmctrMwmjxcEjKnuqxn;

			private readonly bool[] EhaZIKehLzyJMjiKeNHcQiEcgUNbA;

			private bool AustWqRuZFQsyfECBjuCAWimAvWj;

			private int pcZLuvyMEwfzAdIWdouaumcVQLYn;

			private readonly bool NCsJGBIAdfKfxiWPYCCWRuBylAXF;

			private bool lQZHTuAQAWJlOxjWrDceUiiWVZAE;

			public bool enabled
			{
				get
				{
					return AustWqRuZFQsyfECBjuCAWimAvWj;
				}
				set
				{
					if (value != AustWqRuZFQsyfECBjuCAWimAvWj)
					{
						AustWqRuZFQsyfECBjuCAWimAvWj = value;
						if (!AustWqRuZFQsyfECBjuCAWimAvWj)
						{
							Clear();
						}
					}
				}
			}

			public bool monitoring => pcZLuvyMEwfzAdIWdouaumcVQLYn > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (UnityTools.isAndroidPlatform)
				{
					int[] keyboardKeyValues = Consts._keyboardKeyValues;
					xtzMzAIWoXYrpovQsXwlMWZVOzsg = new int[7]
					{
						(keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27)),
						(keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319)),
						(keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283)),
						(keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273)),
						(keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275)),
						(keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274)),
						(keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276))
					};
				}
			}

			public Keyboard()
			{
				EhaZIKehLzyJMjiKeNHcQiEcgUNbA = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > KAygaHDJlmUMurloaMGskPKYxkuY)
					{
						KAygaHDJlmUMurloaMGskPKYxkuY = keyboardKeyValues[i];
					}
				}
				dtqLfUEdHqmctrMwmjxcEjKnuqxn = new int[KAygaHDJlmUMurloaMGskPKYxkuY + 1];
				ArrayTools.Fill(dtqLfUEdHqmctrMwmjxcEjKnuqxn, -1);
				for (int j = 0; j < num; j++)
				{
					dtqLfUEdHqmctrMwmjxcEjKnuqxn[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (pcZLuvyMEwfzAdIWdouaumcVQLYn != 0)
				{
					zxobSBfpboVpxTouSMMtzATKvVUX();
				}
				AXpnnDFALYwoJBHhUfOXStgCWJCo();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (pcZLuvyMEwfzAdIWdouaumcVQLYn == 0)
				{
					return;
				}
				if (Input.anyKey)
				{
					lQZHTuAQAWJlOxjWrDceUiiWVZAE = true;
					if (AustWqRuZFQsyfECBjuCAWimAvWj)
					{
						int[] keyboardKeyValues = Consts._keyboardKeyValues;
						for (int i = 0; i < 132; i++)
						{
							EhaZIKehLzyJMjiKeNHcQiEcgUNbA[i] = Input.GetKey((KeyCode)keyboardKeyValues[i]);
						}
					}
					else if (NCsJGBIAdfKfxiWPYCCWRuBylAXF)
					{
						EhaZIKehLzyJMjiKeNHcQiEcgUNbA[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						EhaZIKehLzyJMjiKeNHcQiEcgUNbA[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						EhaZIKehLzyJMjiKeNHcQiEcgUNbA[keyValueIndex_F2] = GetKey(KeyCode.F2);
						EhaZIKehLzyJMjiKeNHcQiEcgUNbA[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
						EhaZIKehLzyJMjiKeNHcQiEcgUNbA[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
						EhaZIKehLzyJMjiKeNHcQiEcgUNbA[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
						EhaZIKehLzyJMjiKeNHcQiEcgUNbA[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
					}
				}
				else if (lQZHTuAQAWJlOxjWrDceUiiWVZAE)
				{
					Array.Clear(EhaZIKehLzyJMjiKeNHcQiEcgUNbA, 0, EhaZIKehLzyJMjiKeNHcQiEcgUNbA.Length);
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					pcZLuvyMEwfzAdIWdouaumcVQLYn++;
					if (pcZLuvyMEwfzAdIWdouaumcVQLYn == 1)
					{
						WXwjXsUeAyLaejnVmhIQSjliGjYDA();
					}
					return;
				}
				pcZLuvyMEwfzAdIWdouaumcVQLYn--;
				if (pcZLuvyMEwfzAdIWdouaumcVQLYn < 0)
				{
					pcZLuvyMEwfzAdIWdouaumcVQLYn = 0;
					yncfvJgjkojdQeXXKiqQvwDIzgns();
				}
				if (pcZLuvyMEwfzAdIWdouaumcVQLYn == 0)
				{
					uQKPdqaTAtMMWPpVcAXrbgacpdiIb();
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (pcZLuvyMEwfzAdIWdouaumcVQLYn == 0)
				{
					vAmKjSrZnMVmGgBZpCpTAZYOnsnB();
					return false;
				}
				if ((uint)keyCode > (uint)KAygaHDJlmUMurloaMGskPKYxkuY)
				{
					return false;
				}
				return EhaZIKehLzyJMjiKeNHcQiEcgUNbA[dtqLfUEdHqmctrMwmjxcEjKnuqxn[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (pcZLuvyMEwfzAdIWdouaumcVQLYn == 0)
				{
					vAmKjSrZnMVmGgBZpCpTAZYOnsnB();
				}
				else if (values != null && values.Length >= 132)
				{
					Array.Copy(EhaZIKehLzyJMjiKeNHcQiEcgUNbA, values, 132);
				}
			}

			public void Clear()
			{
				if (NCsJGBIAdfKfxiWPYCCWRuBylAXF)
				{
					for (int i = 0; i < 132; i++)
					{
						if (Array.IndexOf(xtzMzAIWoXYrpovQsXwlMWZVOzsg, i) < 0)
						{
							EhaZIKehLzyJMjiKeNHcQiEcgUNbA[i] = false;
						}
					}
				}
				else
				{
					Array.Clear(EhaZIKehLzyJMjiKeNHcQiEcgUNbA, 0, 132);
				}
			}

			private void zxobSBfpboVpxTouSMMtzATKvVUX()
			{
				Array.Clear(EhaZIKehLzyJMjiKeNHcQiEcgUNbA, 0, 132);
			}

			private void AXpnnDFALYwoJBHhUfOXStgCWJCo()
			{
				pcZLuvyMEwfzAdIWdouaumcVQLYn = 0;
				AustWqRuZFQsyfECBjuCAWimAvWj = true;
			}

			private void WXwjXsUeAyLaejnVmhIQSjliGjYDA()
			{
			}

			private void uQKPdqaTAtMMWPpVcAXrbgacpdiIb()
			{
				zxobSBfpboVpxTouSMMtzATKvVUX();
			}

			private void vAmKjSrZnMVmGgBZpCpTAZYOnsnB()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void yncfvJgjkojdQeXXKiqQvwDIzgns()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int XIMEgvxhrVZTlmWJAsJpYOAmtsxb = 7;

			private const int DxvJmtYNOcLlnihLnYypiAbEJisJ = 4;

			private readonly bool[] acTgRRliZIJzOhLDhsaNEmljlZRM;

			private readonly float[] NFVZIZPfRcbPIGqJCoqMdhQkkpYBA;

			private int LkofJCbUyTVJZhTvexaYtBIgYtKd;

			private Vector3 WJqVHGYAqpeboChkUGZNqGdIIWcyA;

			private bool BFwjmbmzLBFOWyDXjAFGdKyjehHU;

			private bool SzwROktpJdLbHcfffiXnbRUatkSz;

			public bool monitoring => LkofJCbUyTVJZhTvexaYtBIgYtKd > 0;

			public Vector3 mousePosition => WJqVHGYAqpeboChkUGZNqGdIIWcyA;

			public bool mousePresent => BFwjmbmzLBFOWyDXjAFGdKyjehHU;

			public Mouse()
			{
				acTgRRliZIJzOhLDhsaNEmljlZRM = new bool[7];
				NFVZIZPfRcbPIGqJCoqMdhQkkpYBA = new float[4];
				fqiAOoJEAwgHXTqkKULrhsoWSfIHA();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (LkofJCbUyTVJZhTvexaYtBIgYtKd == 0)
				{
					return;
				}
				if (!SzwROktpJdLbHcfffiXnbRUatkSz)
				{
					try
					{
						for (int i = 0; i < 7; i++)
						{
							acTgRRliZIJzOhLDhsaNEmljlZRM[i] = Input.GetButton(Consts.mouseButtonUnityNames[i]);
						}
						for (int j = 0; j < 3; j++)
						{
							NFVZIZPfRcbPIGqJCoqMdhQkkpYBA[j] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[j]);
						}
					}
					catch
					{
						Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
						SzwROktpJdLbHcfffiXnbRUatkSz = true;
					}
				}
				NFVZIZPfRcbPIGqJCoqMdhQkkpYBA[3] = Input.mouseScrollDelta.x;
				WJqVHGYAqpeboChkUGZNqGdIIWcyA = Input.mousePosition;
				BFwjmbmzLBFOWyDXjAFGdKyjehHU = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					LkofJCbUyTVJZhTvexaYtBIgYtKd++;
					if (LkofJCbUyTVJZhTvexaYtBIgYtKd == 1)
					{
						bjODoRkWcdQkDbrlrYiyRTknCTNCA();
					}
					return;
				}
				LkofJCbUyTVJZhTvexaYtBIgYtKd--;
				if (LkofJCbUyTVJZhTvexaYtBIgYtKd < 0)
				{
					LkofJCbUyTVJZhTvexaYtBIgYtKd = 0;
					VLILlUSqmkMWfYenNBWrlzHEuetc();
				}
				if (LkofJCbUyTVJZhTvexaYtBIgYtKd == 0)
				{
					TwgTMFBPVzAmgLedwqDfNorxHjPM();
				}
			}

			public bool GetButton(int index)
			{
				if (LkofJCbUyTVJZhTvexaYtBIgYtKd == 0)
				{
					UoCuPBwUrBfFsIuGpoHHxdCIIIAf();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return acTgRRliZIJzOhLDhsaNEmljlZRM[index];
			}

			public float GetAxisRaw(int index)
			{
				if (LkofJCbUyTVJZhTvexaYtBIgYtKd == 0)
				{
					UoCuPBwUrBfFsIuGpoHHxdCIIIAf();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return NFVZIZPfRcbPIGqJCoqMdhQkkpYBA[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (LkofJCbUyTVJZhTvexaYtBIgYtKd == 0)
				{
					UoCuPBwUrBfFsIuGpoHHxdCIIIAf();
				}
				else if (buttons != null && buttons.Length >= 7)
				{
					Array.Copy(acTgRRliZIJzOhLDhsaNEmljlZRM, buttons, 7);
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (LkofJCbUyTVJZhTvexaYtBIgYtKd == 0)
				{
					UoCuPBwUrBfFsIuGpoHHxdCIIIAf();
				}
				else if (axes != null && axes.Length >= 4)
				{
					Array.Copy(NFVZIZPfRcbPIGqJCoqMdhQkkpYBA, axes, 4);
				}
			}

			private void XnSXICUaiotuzxaAEkBkSqtMLQLC()
			{
				Array.Clear(acTgRRliZIJzOhLDhsaNEmljlZRM, 0, 7);
				Array.Clear(NFVZIZPfRcbPIGqJCoqMdhQkkpYBA, 0, 4);
			}

			private void fqiAOoJEAwgHXTqkKULrhsoWSfIHA()
			{
				LkofJCbUyTVJZhTvexaYtBIgYtKd = 0;
				WJqVHGYAqpeboChkUGZNqGdIIWcyA = Vector3.zero;
				BFwjmbmzLBFOWyDXjAFGdKyjehHU = false;
			}

			private void bjODoRkWcdQkDbrlrYiyRTknCTNCA()
			{
			}

			private void TwgTMFBPVzAmgLedwqDfNorxHjPM()
			{
				XnSXICUaiotuzxaAEkBkSqtMLQLC();
			}

			private void UoCuPBwUrBfFsIuGpoHHxdCIIIAf()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void VLILlUSqmkMWfYenNBWrlzHEuetc()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse zytSdZGYYVjMHQIqsPmxuSdCuZZE;

		private static Keyboard NksdWoASiiWayVOZrAhMHsmwFvsDb;

		public static Mouse mouse => zytSdZGYYVjMHQIqsPmxuSdCuZZE ?? (zytSdZGYYVjMHQIqsPmxuSdCuZZE = new Mouse());

		public static Keyboard keyboard => NksdWoASiiWayVOZrAhMHsmwFvsDb ?? (NksdWoASiiWayVOZrAhMHsmwFvsDb = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (NksdWoASiiWayVOZrAhMHsmwFvsDb != null)
			{
				NksdWoASiiWayVOZrAhMHsmwFvsDb.PostInitialize();
			}
			if (zytSdZGYYVjMHQIqsPmxuSdCuZZE != null)
			{
				zytSdZGYYVjMHQIqsPmxuSdCuZZE.PostInitialize();
			}
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (NksdWoASiiWayVOZrAhMHsmwFvsDb != null)
			{
				NksdWoASiiWayVOZrAhMHsmwFvsDb = null;
			}
			if (zytSdZGYYVjMHQIqsPmxuSdCuZZE != null)
			{
				zytSdZGYYVjMHQIqsPmxuSdCuZZE = null;
			}
		}

		public static void Update()
		{
			if (NksdWoASiiWayVOZrAhMHsmwFvsDb != null)
			{
				NksdWoASiiWayVOZrAhMHsmwFvsDb.enabled = ReInput.controllers.Keyboard.enabled;
				NksdWoASiiWayVOZrAhMHsmwFvsDb.Update();
			}
			if (zytSdZGYYVjMHQIqsPmxuSdCuZZE != null)
			{
				zytSdZGYYVjMHQIqsPmxuSdCuZZE.Update();
			}
		}
	}
}
