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
			private const int zwoPVZwQslafzXhBjWAdnlZzAjvA = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] UBvNWhzFDktDprrsaOUJxzfFcjY;

			private readonly int RtQVZduUbcHoCKycbEtbpHVzbz;

			private readonly int[] BRQsYcEjToIGuDdJRlHZSTiACXD;

			private readonly bool[] TzjUZwdoZvqBsSkZLyNQAuQwzCg;

			private bool FnzJwrQpikWfZbmfjZhFwutJGAA;

			private int RIOEggBrfhlmzlPUOaPwvvUkLkUy;

			private readonly bool DQnwvjIBzLNvHhHKjrxTcxvEtjs;

			private bool FYwDTlFzDLdsmVWuFCchIwARjly;

			public bool enabled
			{
				get
				{
					return FnzJwrQpikWfZbmfjZhFwutJGAA;
				}
				set
				{
					if (value == FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						return;
					}
					while (true)
					{
						FnzJwrQpikWfZbmfjZhFwutJGAA = value;
						int num = 1301278412;
						while (true)
						{
							switch (num ^ 0x4D8FEECD)
							{
							case 3:
								num = 1301278415;
								continue;
							default:
								return;
							case 2:
								break;
							case 1:
								if (!FnzJwrQpikWfZbmfjZhFwutJGAA)
								{
									Clear();
									num = 1301278413;
									continue;
								}
								return;
							case 0:
								return;
							}
							break;
						}
					}
				}
			}

			public bool monitoring => RIOEggBrfhlmzlPUOaPwvvUkLkUy > 0;

			public int keyCount => 132;

			static Keyboard()
			{
				if (!UnityTools.isAndroidPlatform)
				{
					return;
				}
				int[] uBvNWhzFDktDprrsaOUJxzfFcjY = default(int[]);
				while (true)
				{
					int num = -1137295486;
					while (true)
					{
						switch (num ^ -1137295487)
						{
						case 2:
							break;
						default:
							return;
						case 3:
						{
							int[] keyboardKeyValues = Consts._keyboardKeyValues;
							uBvNWhzFDktDprrsaOUJxzfFcjY = new int[7]
							{
								(keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27)),
								(keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319)),
								(keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283)),
								(keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273)),
								(keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275)),
								(keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274)),
								(keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276))
							};
							num = -1137295487;
							continue;
						}
						case 0:
							UBvNWhzFDktDprrsaOUJxzfFcjY = uBvNWhzFDktDprrsaOUJxzfFcjY;
							num = -1137295488;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}

			public Keyboard()
			{
				TzjUZwdoZvqBsSkZLyNQAuQwzCg = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > RtQVZduUbcHoCKycbEtbpHVzbz)
					{
						RtQVZduUbcHoCKycbEtbpHVzbz = keyboardKeyValues[i];
					}
				}
				BRQsYcEjToIGuDdJRlHZSTiACXD = new int[RtQVZduUbcHoCKycbEtbpHVzbz + 1];
				ArrayTools.Fill(BRQsYcEjToIGuDdJRlHZSTiACXD, -1);
				for (int j = 0; j < num; j++)
				{
					BRQsYcEjToIGuDdJRlHZSTiACXD[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy != 0)
				{
					goto IL_0008;
				}
				goto IL_0037;
				IL_0008:
				int num = -1095284260;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ -1095284257)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						pJXVeCFSfvkpjdkvhEampKTgKdG();
						num = -1095284257;
						continue;
					case 0:
						goto IL_0037;
					case 1:
						return;
					}
					break;
				}
				goto IL_0008;
				IL_0037:
				SzVBYfzbaWIKmEuGhrHZnyHUdDX();
				num = -1095284258;
				goto IL_000d;
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					return;
				}
				int[] keyboardKeyValues = default(int[]);
				int num = default(int);
				while (true)
				{
					IL_012f:
					int num2;
					if (Input.anyKey)
					{
						FYwDTlFzDLdsmVWuFCchIwARjly = true;
						if (FnzJwrQpikWfZbmfjZhFwutJGAA)
						{
							keyboardKeyValues = Consts._keyboardKeyValues;
							num = 0;
							num2 = -2036616297;
							goto IL_0011;
						}
						goto IL_0049;
					}
					goto IL_0165;
					IL_0049:
					if (DQnwvjIBzLNvHhHKjrxTcxvEtjs)
					{
						TzjUZwdoZvqBsSkZLyNQAuQwzCg[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						TzjUZwdoZvqBsSkZLyNQAuQwzCg[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
						TzjUZwdoZvqBsSkZLyNQAuQwzCg[keyValueIndex_F2] = GetKey(KeyCode.F2);
						num2 = -2036616298;
						goto IL_0011;
					}
					break;
					IL_0011:
					while (true)
					{
						switch (num2 ^ -2036616304)
						{
						case 4:
							num2 = -2036616299;
							continue;
						default:
							return;
						case 2:
							break;
						case 6:
							TzjUZwdoZvqBsSkZLyNQAuQwzCg[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
							TzjUZwdoZvqBsSkZLyNQAuQwzCg[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
							TzjUZwdoZvqBsSkZLyNQAuQwzCg[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
							num2 = -2036616295;
							continue;
						case 9:
							TzjUZwdoZvqBsSkZLyNQAuQwzCg[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
							return;
						case 1:
							TzjUZwdoZvqBsSkZLyNQAuQwzCg[num] = Input.GetKey((KeyCode)keyboardKeyValues[num]);
							num++;
							num2 = -2036616297;
							continue;
						case 5:
							goto IL_012f;
						case 3:
							return;
						case 8:
							goto IL_0165;
						case 7:
							goto IL_018b;
						case 0:
							return;
						}
						break;
						IL_018b:
						int num3;
						if (num < 132)
						{
							num2 = -2036616303;
							num3 = num2;
						}
						else
						{
							num2 = -2036616301;
							num3 = num2;
						}
					}
					goto IL_0049;
					IL_0165:
					if (FYwDTlFzDLdsmVWuFCchIwARjly)
					{
						Array.Clear(TzjUZwdoZvqBsSkZLyNQAuQwzCg, 0, TzjUZwdoZvqBsSkZLyNQAuQwzCg.Length);
						num2 = -2036616304;
						goto IL_0011;
					}
					break;
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					RIOEggBrfhlmzlPUOaPwvvUkLkUy++;
					if (RIOEggBrfhlmzlPUOaPwvvUkLkUy != 1)
					{
						return;
					}
					goto IL_001a;
				}
				goto IL_0063;
				IL_0063:
				RIOEggBrfhlmzlPUOaPwvvUkLkUy--;
				int num;
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy < 0)
				{
					RIOEggBrfhlmzlPUOaPwvvUkLkUy = 0;
					ipHorkQmjmMjoManjoBKwkuJBDi();
					num = 180164670;
					goto IL_001f;
				}
				goto IL_004e;
				IL_001a:
				num = 180164668;
				goto IL_001f;
				IL_001f:
				switch (num ^ 0xABD183F)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					hCZwVtUugOoPCFClZESLVuhOFBz();
					return;
				case 1:
					goto IL_004e;
				case 4:
					goto IL_0063;
				case 2:
					return;
				}
				goto IL_001a;
				IL_004e:
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					HBeqHMtvAGwqpbiOqjyYRVilhlzB();
					num = 180164669;
					goto IL_001f;
				}
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					GFvEyaGcWWCQwkiSigPNKQCpMFVo();
					return false;
				}
				if ((uint)keyCode > (uint)RtQVZduUbcHoCKycbEtbpHVzbz)
				{
					return false;
				}
				return TzjUZwdoZvqBsSkZLyNQAuQwzCg[BRQsYcEjToIGuDdJRlHZSTiACXD[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					GFvEyaGcWWCQwkiSigPNKQCpMFVo();
					return;
				}
				while (values != null)
				{
					int num;
					int num2;
					if (values.Length < 132)
					{
						num = -692950945;
						num2 = num;
					}
					else
					{
						num = -692950946;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -692950948)
						{
						case 0:
							num = -692950947;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							Array.Copy(TzjUZwdoZvqBsSkZLyNQAuQwzCg, values, 132);
							num = -692950952;
							continue;
						case 3:
							return;
						case 4:
							return;
						}
						break;
					}
				}
			}

			public void Clear()
			{
				if (DQnwvjIBzLNvHhHKjrxTcxvEtjs)
				{
					int num = 0;
					while (true)
					{
						if (num >= 132)
						{
							return;
						}
						while (true)
						{
							IL_004d:
							int num2;
							if (Array.IndexOf(UBvNWhzFDktDprrsaOUJxzfFcjY, num) < 0)
							{
								TzjUZwdoZvqBsSkZLyNQAuQwzCg[num] = false;
								num2 = 1198167189;
								goto IL_0011;
							}
							goto IL_0042;
							IL_0011:
							while (true)
							{
								switch (num2 ^ 0x476A9491)
								{
								case 2:
									num2 = 1198167186;
									continue;
								case 1:
									break;
								case 4:
									goto IL_0042;
								case 3:
									goto IL_004d;
								default:
									goto end_IL_0032;
								}
								break;
							}
							break;
							IL_0042:
							num++;
							num2 = 1198167184;
							goto IL_0011;
						}
						continue;
						end_IL_0032:
						break;
					}
				}
				Array.Clear(TzjUZwdoZvqBsSkZLyNQAuQwzCg, 0, 132);
			}

			private void pJXVeCFSfvkpjdkvhEampKTgKdG()
			{
				Array.Clear(TzjUZwdoZvqBsSkZLyNQAuQwzCg, 0, 132);
			}

			private void SzVBYfzbaWIKmEuGhrHZnyHUdDX()
			{
				RIOEggBrfhlmzlPUOaPwvvUkLkUy = 0;
				FnzJwrQpikWfZbmfjZhFwutJGAA = true;
			}

			private void hCZwVtUugOoPCFClZESLVuhOFBz()
			{
			}

			private void HBeqHMtvAGwqpbiOqjyYRVilhlzB()
			{
				pJXVeCFSfvkpjdkvhEampKTgKdG();
			}

			private void GFvEyaGcWWCQwkiSigPNKQCpMFVo()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void ipHorkQmjmMjoManjoBKwkuJBDi()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Mouse
		{
			private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 7;

			private const int ooxLfNrAogzyUTrvphoSPkzSmQV = 4;

			private readonly bool[] duQdUwWCoAwHNtdgoIMHHlMkZKgA;

			private readonly float[] AkuouGDCFrzxtxPhCzXMdhnwfnh;

			private int RIOEggBrfhlmzlPUOaPwvvUkLkUy;

			private Vector3 HkKELrDfFchTaWARHXuSMVOByeW;

			private bool GbcafLemHYcqvJdxwOvTAZpwaRm;

			private bool IZSqQUmBUZLCYLpcYKilqbQSByF;

			public bool monitoring => RIOEggBrfhlmzlPUOaPwvvUkLkUy > 0;

			public Vector3 mousePosition => HkKELrDfFchTaWARHXuSMVOByeW;

			public bool mousePresent => GbcafLemHYcqvJdxwOvTAZpwaRm;

			public Mouse()
			{
				while (true)
				{
					int num = -775380595;
					while (true)
					{
						switch (num ^ -775380593)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						duQdUwWCoAwHNtdgoIMHHlMkZKgA = new bool[7];
						AkuouGDCFrzxtxPhCzXMdhnwfnh = new float[4];
						SzVBYfzbaWIKmEuGhrHZnyHUdDX();
						num = -775380594;
					}
				}
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					while (true)
					{
						switch (-2136288818 ^ -2136288820)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				if (!IZSqQUmBUZLCYLpcYKilqbQSByF)
				{
					try
					{
						int num = 0;
						int num2 = default(int);
						while (true)
						{
							IL_00a9:
							int num3;
							if (num >= 7)
							{
								num2 = 0;
								num3 = -2136288819;
								goto IL_0042;
							}
							goto IL_0063;
							IL_0042:
							while (true)
							{
								switch (num3 ^ -2136288820)
								{
								case 0:
									num3 = -2136288824;
									continue;
								case 4:
									break;
								case 2:
									AkuouGDCFrzxtxPhCzXMdhnwfnh[num2] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[num2]);
									num2++;
									num3 = -2136288819;
									continue;
								case 3:
									goto IL_00a9;
								default:
									if (num2 >= 3)
									{
										goto end_IL_00a9;
									}
									goto case 2;
								}
								break;
							}
							goto IL_0063;
							IL_0063:
							duQdUwWCoAwHNtdgoIMHHlMkZKgA[num] = Input.GetButton(Consts.mouseButtonUnityNames[num]);
							num++;
							num3 = -2136288817;
							goto IL_0042;
							continue;
							end_IL_00a9:
							break;
						}
					}
					catch
					{
						while (true)
						{
							IL_00bd:
							int num4 = -2136288819;
							while (true)
							{
								switch (num4 ^ -2136288820)
								{
								case 0:
									break;
								default:
									goto end_IL_00c2;
								case 1:
									goto IL_00db;
								case 2:
									goto end_IL_00c2;
								}
								goto IL_00bd;
								IL_00db:
								Logger.LogError("Unity Input Manager mouse entries are missing. Rewired was not installed properly or was canceled during installation, preventing it from installing the necessary Unity Input Manager entries for mouse input or the input manager entries may have been overwritten by another package installed in your project. Mouse input will not function if native mouse input is disabled or is unavailable on this platform.");
								IZSqQUmBUZLCYLpcYKilqbQSByF = true;
								num4 = -2136288818;
								continue;
								end_IL_00c2:
								break;
							}
							break;
						}
					}
				}
				AkuouGDCFrzxtxPhCzXMdhnwfnh[3] = Input.mouseScrollDelta.x;
				HkKELrDfFchTaWARHXuSMVOByeW = Input.mousePosition;
				GbcafLemHYcqvJdxwOvTAZpwaRm = Input.mousePresent;
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					RIOEggBrfhlmzlPUOaPwvvUkLkUy++;
					if (RIOEggBrfhlmzlPUOaPwvvUkLkUy != 1)
					{
						return;
					}
					goto IL_001d;
				}
				goto IL_0064;
				IL_0064:
				RIOEggBrfhlmzlPUOaPwvvUkLkUy--;
				int num;
				int num2;
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy < 0)
				{
					num = 1052439938;
					num2 = num;
				}
				else
				{
					num = 1052439937;
					num2 = num;
				}
				goto IL_0022;
				IL_001d:
				num = 1052439941;
				goto IL_0022;
				IL_0022:
				while (true)
				{
					switch (num ^ 0x3EBAF580)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_004b;
					case 6:
						goto IL_0064;
					case 5:
						hCZwVtUugOoPCFClZESLVuhOFBz();
						return;
					case 3:
						HBeqHMtvAGwqpbiOqjyYRVilhlzB();
						num = 1052439940;
						continue;
					case 2:
						RIOEggBrfhlmzlPUOaPwvvUkLkUy = 0;
						ipHorkQmjmMjoManjoBKwkuJBDi();
						num = 1052439937;
						continue;
					case 4:
						return;
					}
					break;
					IL_004b:
					int num3;
					if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
					{
						num = 1052439939;
						num3 = num;
					}
					else
					{
						num = 1052439940;
						num3 = num;
					}
				}
				goto IL_001d;
			}

			public bool GetButton(int index)
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					while (true)
					{
						int num = -1062321427;
						while (true)
						{
							switch (num ^ -1062321425)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							default:
								return false;
							}
							break;
							IL_0026:
							IKJiOAMSHZnbUHdeusXcxGfhWbu();
							num = -1062321426;
						}
					}
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return duQdUwWCoAwHNtdgoIMHHlMkZKgA[index];
			}

			public float GetAxisRaw(int index)
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					IKJiOAMSHZnbUHdeusXcxGfhWbu();
					return 0f;
				}
				if ((uint)index >= 4u)
				{
					return 0f;
				}
				return AkuouGDCFrzxtxPhCzXMdhnwfnh[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					goto IL_0008;
				}
				goto IL_003c;
				IL_0008:
				int num = -1105538685;
				goto IL_000d;
				IL_000d:
				switch (num ^ -1105538686)
				{
				case 4:
					break;
				case 1:
					IKJiOAMSHZnbUHdeusXcxGfhWbu();
					return;
				case 3:
					goto IL_003c;
				case 2:
					return;
				default:
					Array.Copy(duQdUwWCoAwHNtdgoIMHHlMkZKgA, buttons, 7);
					return;
				}
				goto IL_0008;
				IL_003c:
				if (buttons != null)
				{
					int num2;
					if (buttons.Length < 7)
					{
						num = -1105538688;
						num2 = num;
					}
					else
					{
						num = -1105538686;
						num2 = num;
					}
					goto IL_000d;
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (RIOEggBrfhlmzlPUOaPwvvUkLkUy == 0)
				{
					goto IL_0008;
				}
				goto IL_0046;
				IL_0008:
				int num = -1393425889;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ -1393425893)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						Array.Copy(AkuouGDCFrzxtxPhCzXMdhnwfnh, axes, 4);
						num = -1393425896;
						continue;
					case 5:
						goto IL_0046;
					case 0:
						return;
					case 4:
						IKJiOAMSHZnbUHdeusXcxGfhWbu();
						return;
					case 3:
						return;
					}
					break;
				}
				goto IL_0008;
				IL_0046:
				if (axes != null)
				{
					int num2;
					if (axes.Length >= 4)
					{
						num = -1393425894;
						num2 = num;
					}
					else
					{
						num = -1393425893;
						num2 = num;
					}
					goto IL_000d;
				}
			}

			private void pJXVeCFSfvkpjdkvhEampKTgKdG()
			{
				Array.Clear(duQdUwWCoAwHNtdgoIMHHlMkZKgA, 0, 7);
				Array.Clear(AkuouGDCFrzxtxPhCzXMdhnwfnh, 0, 4);
			}

			private void SzVBYfzbaWIKmEuGhrHZnyHUdDX()
			{
				RIOEggBrfhlmzlPUOaPwvvUkLkUy = 0;
				HkKELrDfFchTaWARHXuSMVOByeW = Vector3.zero;
				GbcafLemHYcqvJdxwOvTAZpwaRm = false;
			}

			private void hCZwVtUugOoPCFClZESLVuhOFBz()
			{
			}

			private void HBeqHMtvAGwqpbiOqjyYRVilhlzB()
			{
				pJXVeCFSfvkpjdkvhEampKTgKdG();
			}

			private void IKJiOAMSHZnbUHdeusXcxGfhWbu()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", requiredThreadSafety: true);
			}

			private void ipHorkQmjmMjoManjoBKwkuJBDi()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", requiredThreadSafety: true);
			}
		}

		private static Mouse ILOPPULFZrROUgmeChBPymtdPSU;

		private static Keyboard dCAeLYlUukbicKMNlNOFMHaTEeXf;

		public static Mouse mouse => ILOPPULFZrROUgmeChBPymtdPSU ?? (ILOPPULFZrROUgmeChBPymtdPSU = new Mouse());

		public static Keyboard keyboard => dCAeLYlUukbicKMNlNOFMHaTEeXf ?? (dCAeLYlUukbicKMNlNOFMHaTEeXf = new Keyboard());

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (dCAeLYlUukbicKMNlNOFMHaTEeXf != null)
			{
				dCAeLYlUukbicKMNlNOFMHaTEeXf.PostInitialize();
				goto IL_0011;
			}
			goto IL_002f;
			IL_002f:
			int num;
			if (ILOPPULFZrROUgmeChBPymtdPSU != null)
			{
				ILOPPULFZrROUgmeChBPymtdPSU.PostInitialize();
				num = 1506107031;
				goto IL_0016;
			}
			return;
			IL_0011:
			num = 1506107028;
			goto IL_0016;
			IL_0016:
			switch (num ^ 0x59C55E95)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_002f;
			case 2:
				return;
			}
			goto IL_0011;
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (dCAeLYlUukbicKMNlNOFMHaTEeXf != null)
			{
				dCAeLYlUukbicKMNlNOFMHaTEeXf = null;
				goto IL_000d;
			}
			goto IL_002b;
			IL_002b:
			int num;
			if (ILOPPULFZrROUgmeChBPymtdPSU != null)
			{
				ILOPPULFZrROUgmeChBPymtdPSU = null;
				num = -1570429353;
				goto IL_0012;
			}
			return;
			IL_000d:
			num = -1570429356;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1570429354)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_002b;
			case 1:
				return;
			}
			goto IL_000d;
		}

		public static void Update()
		{
			if (dCAeLYlUukbicKMNlNOFMHaTEeXf != null)
			{
				dCAeLYlUukbicKMNlNOFMHaTEeXf.enabled = ReInput.controllers.Keyboard.enabled;
				goto IL_0020;
			}
			goto IL_0068;
			IL_0068:
			int num;
			int num2;
			if (ILOPPULFZrROUgmeChBPymtdPSU != null)
			{
				num = 574056850;
				num2 = num;
			}
			else
			{
				num = 574056849;
				num2 = num;
			}
			goto IL_0025;
			IL_0020:
			num = 574056851;
			goto IL_0025;
			IL_0025:
			while (true)
			{
				switch (num ^ 0x22376992)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					dCAeLYlUukbicKMNlNOFMHaTEeXf.Update();
					num = 574056848;
					continue;
				case 0:
					ILOPPULFZrROUgmeChBPymtdPSU.Update();
					num = 574056849;
					continue;
				case 2:
					goto IL_0068;
				case 3:
					return;
				}
				break;
			}
			goto IL_0020;
		}
	}
}
