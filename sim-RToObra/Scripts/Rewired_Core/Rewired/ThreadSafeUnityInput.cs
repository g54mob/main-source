using System;
using Rewired.Utils;
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
			private const int pIunZPkSJnFMXKFbWbNaMjfyJdX = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] OlzszxbGukhNJiPARpFCWvZOzXm;

			private readonly int ZhpCoNIbFrOEGERIBMIsWWnMrxBp;

			private readonly int[] TvOEEWhWYopkmuOVyKYYItfBlCrH;

			private readonly bool[] PczZmwlKZffAWXLQaVTRvCWjchW;

			private bool PAfqntGWZaNgzmZFIOyQPuJGOCq;

			private int JSOKBmvUpnAJPKktfkTtGyofmxm;

			private readonly bool BjfWKlABcPvhleltMQUKTCBPPhO;

			public bool enabled
			{
				get
				{
					return PAfqntGWZaNgzmZFIOyQPuJGOCq;
				}
				set
				{
					if (value == PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						return;
					}
					while (true)
					{
						PAfqntGWZaNgzmZFIOyQPuJGOCq = value;
						int num = 1508502101;
						while (true)
						{
							switch (num ^ 0x59E9EA51)
							{
							case 2:
								num = 1508502096;
								continue;
							default:
								return;
							case 1:
								break;
							case 0:
								Clear();
								num = 1508502098;
								continue;
							case 4:
							{
								int num2;
								if (PAfqntGWZaNgzmZFIOyQPuJGOCq)
								{
									num = 1508502098;
									num2 = num;
								}
								else
								{
									num = 1508502097;
									num2 = num;
								}
								continue;
							}
							case 3:
								return;
							}
							break;
						}
					}
				}
			}

			public bool monitoring
			{
				get
				{
					return JSOKBmvUpnAJPKktfkTtGyofmxm > 0;
				}
			}

			public int keyCount
			{
				get
				{
					return 132;
				}
			}

			static Keyboard()
			{
				if (!UnityTools.isAndroidPlatform)
				{
					return;
				}
				int[] array = default(int[]);
				int[] keyboardKeyValues = default(int[]);
				while (true)
				{
					int num = -1800577897;
					while (true)
					{
						switch (num ^ -1800577899)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							array[0] = (keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27));
							array[1] = (keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319));
							array[2] = (keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283));
							array[3] = (keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273));
							array[4] = (keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275));
							array[5] = (keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274));
							array[6] = (keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276));
							OlzszxbGukhNJiPARpFCWvZOzXm = array;
							num = -1800577898;
							continue;
						case 4:
							array = new int[7];
							num = -1800577900;
							continue;
						case 2:
							keyboardKeyValues = Consts._keyboardKeyValues;
							num = -1800577903;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			public Keyboard()
			{
				PczZmwlKZffAWXLQaVTRvCWjchW = new bool[132];
				int[] keyboardKeyValues = Consts._keyboardKeyValues;
				int num = keyboardKeyValues.Length;
				for (int i = 0; i < num; i++)
				{
					if (keyboardKeyValues[i] > ZhpCoNIbFrOEGERIBMIsWWnMrxBp)
					{
						ZhpCoNIbFrOEGERIBMIsWWnMrxBp = keyboardKeyValues[i];
					}
				}
				TvOEEWhWYopkmuOVyKYYItfBlCrH = new int[ZhpCoNIbFrOEGERIBMIsWWnMrxBp + 1];
				ArrayTools.Fill(TvOEEWhWYopkmuOVyKYYItfBlCrH, -1);
				for (int j = 0; j < num; j++)
				{
					TvOEEWhWYopkmuOVyKYYItfBlCrH[keyboardKeyValues[j]] = j;
				}
			}

			public void Initialize()
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm != 0)
				{
					bbBpdCFNUtLARgPYWgfbIajvpEs();
				}
				CbNIcrvnFQKuUFKiCEsYAUrFeFbZ();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					return;
				}
				int[] keyboardKeyValues = default(int[]);
				int num2 = default(int);
				while (true)
				{
					int num;
					if (PAfqntGWZaNgzmZFIOyQPuJGOCq)
					{
						keyboardKeyValues = Consts._keyboardKeyValues;
						num = -176663768;
						goto IL_0011;
					}
					goto IL_012f;
					IL_0011:
					while (true)
					{
						switch (num ^ -176663765)
						{
						case 9:
							num = -176663761;
							continue;
						default:
							return;
						case 5:
							break;
						case 7:
							PczZmwlKZffAWXLQaVTRvCWjchW[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
							PczZmwlKZffAWXLQaVTRvCWjchW[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
							PczZmwlKZffAWXLQaVTRvCWjchW[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
							PczZmwlKZffAWXLQaVTRvCWjchW[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
							num = -176663765;
							continue;
						case 2:
							return;
						case 1:
							PczZmwlKZffAWXLQaVTRvCWjchW[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
							PczZmwlKZffAWXLQaVTRvCWjchW[keyValueIndex_F2] = GetKey(KeyCode.F2);
							num = -176663764;
							continue;
						case 3:
							num2 = 0;
							num = -176663762;
							continue;
						case 4:
							goto end_IL_0011;
						case 6:
							goto IL_012f;
						case 8:
							PczZmwlKZffAWXLQaVTRvCWjchW[num2] = Input.GetKey((KeyCode)keyboardKeyValues[num2]);
							num2++;
							num = -176663762;
							continue;
						case 0:
							return;
						}
						int num3;
						if (num2 >= 132)
						{
							num = -176663767;
							num3 = num;
						}
						else
						{
							num = -176663773;
							num3 = num;
						}
						continue;
						end_IL_0011:
						break;
					}
					continue;
					IL_012f:
					if (BjfWKlABcPvhleltMQUKTCBPPhO)
					{
						PczZmwlKZffAWXLQaVTRvCWjchW[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
						num = -176663766;
						goto IL_0011;
					}
					break;
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					JSOKBmvUpnAJPKktfkTtGyofmxm++;
					goto IL_0014;
				}
				goto IL_00c5;
				IL_00c5:
				JSOKBmvUpnAJPKktfkTtGyofmxm--;
				int num = -397818958;
				goto IL_0019;
				IL_0014:
				num = -397818957;
				goto IL_0019;
				IL_0019:
				while (true)
				{
					switch (num ^ -397818958)
					{
					case 4:
						break;
					default:
						return;
					case 6:
						JSOKBmvUpnAJPKktfkTtGyofmxm = 0;
						oRLWYqCIZqSkWRoIWDJZVWMUWBI();
						num = -397818955;
						continue;
					case 8:
						ZxydwIdmjSEINiGoVJNNowUobfJ();
						num = -397818960;
						continue;
					case 5:
						return;
					case 0:
						goto IL_0076;
					case 1:
						if (JSOKBmvUpnAJPKktfkTtGyofmxm == 1)
						{
							biZSCzGNZSOIcWekqYfQgNGXSHT();
							num = -397818953;
							continue;
						}
						return;
					case 7:
						goto IL_00a9;
					case 3:
						goto IL_00c5;
					case 2:
						return;
					}
					break;
					IL_00a9:
					int num2;
					if (JSOKBmvUpnAJPKktfkTtGyofmxm != 0)
					{
						num = -397818960;
						num2 = num;
					}
					else
					{
						num = -397818950;
						num2 = num;
					}
					continue;
					IL_0076:
					int num3;
					if (JSOKBmvUpnAJPKktfkTtGyofmxm >= 0)
					{
						num = -397818955;
						num3 = num;
					}
					else
					{
						num = -397818956;
						num3 = num;
					}
				}
				goto IL_0014;
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					WDbACmColGboMlDwNGwQepcmeVhc();
					return false;
				}
				if ((uint)keyCode > (uint)ZhpCoNIbFrOEGERIBMIsWWnMrxBp)
				{
					return false;
				}
				return PczZmwlKZffAWXLQaVTRvCWjchW[TvOEEWhWYopkmuOVyKYYItfBlCrH[(int)keyCode]];
			}

			public void GetKeyValues(bool[] values)
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					WDbACmColGboMlDwNGwQepcmeVhc();
					goto IL_000e;
				}
				goto IL_0040;
				IL_0040:
				if (values == null)
				{
					return;
				}
				int num;
				int num2;
				if (values.Length >= 132)
				{
					num = 772207425;
					num2 = num;
				}
				else
				{
					num = 772207431;
					num2 = num;
				}
				goto IL_0013;
				IL_000e:
				num = 772207430;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ 0x2E06F344)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						return;
					case 4:
						goto IL_0040;
					case 5:
						Array.Copy(PczZmwlKZffAWXLQaVTRvCWjchW, values, 132);
						num = 772207429;
						continue;
					case 2:
						return;
					case 1:
						return;
					}
					break;
				}
				goto IL_000e;
			}

			public void Clear()
			{
				if (BjfWKlABcPvhleltMQUKTCBPPhO)
				{
					int num = 0;
					while (true)
					{
						int num2;
						int num3;
						if (num < 132)
						{
							num2 = 1116661650;
							num3 = num2;
						}
						else
						{
							num2 = 1116661651;
							num3 = num2;
						}
						while (true)
						{
							switch (num2 ^ 0x428EE793)
							{
							case 6:
								num2 = 1116661650;
								continue;
							case 0:
								return;
							case 5:
								PczZmwlKZffAWXLQaVTRvCWjchW[num] = false;
								num2 = 1116661649;
								continue;
							case 4:
								break;
							case 1:
								goto IL_006e;
							case 2:
								num++;
								num2 = 1116661655;
								continue;
							default:
								goto end_IL_0055;
							}
							break;
							IL_006e:
							int num4;
							if (Array.IndexOf(OlzszxbGukhNJiPARpFCWvZOzXm, num) < 0)
							{
								num2 = 1116661654;
								num4 = num2;
							}
							else
							{
								num2 = 1116661649;
								num4 = num2;
							}
						}
						continue;
						end_IL_0055:
						break;
					}
				}
				Array.Clear(PczZmwlKZffAWXLQaVTRvCWjchW, 0, 132);
			}

			private void bbBpdCFNUtLARgPYWgfbIajvpEs()
			{
				Array.Clear(PczZmwlKZffAWXLQaVTRvCWjchW, 0, 132);
			}

			private void CbNIcrvnFQKuUFKiCEsYAUrFeFbZ()
			{
				JSOKBmvUpnAJPKktfkTtGyofmxm = 0;
				while (true)
				{
					int num = -1266467939;
					while (true)
					{
						switch (num ^ -1266467940)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0025;
						case 0:
							return;
						}
						break;
						IL_0025:
						PAfqntGWZaNgzmZFIOyQPuJGOCq = true;
						num = -1266467940;
					}
				}
			}

			private void biZSCzGNZSOIcWekqYfQgNGXSHT()
			{
			}

			private void ZxydwIdmjSEINiGoVJNNowUobfJ()
			{
				bbBpdCFNUtLARgPYWgfbIajvpEs();
			}

			private void WDbACmColGboMlDwNGwQepcmeVhc()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", true);
			}

			private void oRLWYqCIZqSkWRoIWDJZVWMUWBI()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", true);
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public sealed class Mouse
		{
			private const int uoEjKyevFzzSGFeoHwcdjcYUdf = 7;

			private const int gkdLJJjRJqOiqMcTEZgPsjDThEz = 3;

			private readonly bool[] lgAkyeKCNYSjxkICDjzKgIcrtWEL;

			private readonly float[] EteKXKVjofLKPeANfYKFAFNxxsR;

			private int JSOKBmvUpnAJPKktfkTtGyofmxm;

			private Vector3 NQYagDGTCeiDlLRmkNwtBxjbOsEo;

			private bool WdiFBZqmaSeGNKlVLdCOjRHfHFG;

			public bool monitoring
			{
				get
				{
					return JSOKBmvUpnAJPKktfkTtGyofmxm > 0;
				}
			}

			public Vector3 mousePosition
			{
				get
				{
					return NQYagDGTCeiDlLRmkNwtBxjbOsEo;
				}
			}

			public bool mousePresent
			{
				get
				{
					return WdiFBZqmaSeGNKlVLdCOjRHfHFG;
				}
			}

			public Mouse()
			{
				lgAkyeKCNYSjxkICDjzKgIcrtWEL = new bool[7];
				EteKXKVjofLKPeANfYKFAFNxxsR = new float[3];
				CbNIcrvnFQKuUFKiCEsYAUrFeFbZ();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					int num = 0;
					int num2 = 1999656391;
					while (true)
					{
						switch (num2 ^ 0x773055C3)
						{
						case 7:
							num2 = 1999656386;
							continue;
						case 1:
							break;
						case 5:
						{
							int num4;
							if (num >= 7)
							{
								num2 = 1999656385;
								num4 = num2;
							}
							else
							{
								num2 = 1999656389;
								num4 = num2;
							}
							continue;
						}
						case 2:
							num3 = 0;
							num2 = 1999656384;
							continue;
						case 0:
							EteKXKVjofLKPeANfYKFAFNxxsR[num3] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[num3]);
							num3++;
							num2 = 1999656384;
							continue;
						case 6:
							lgAkyeKCNYSjxkICDjzKgIcrtWEL[num] = Input.GetButton(Consts.mouseButtonUnityNames[num]);
							num++;
							num2 = 1999656390;
							continue;
						case 4:
							num2 = 1999656390;
							continue;
						default:
							if (num3 >= 3)
							{
								NQYagDGTCeiDlLRmkNwtBxjbOsEo = Input.mousePosition;
								WdiFBZqmaSeGNKlVLdCOjRHfHFG = Input.mousePresent;
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					JSOKBmvUpnAJPKktfkTtGyofmxm++;
					if (JSOKBmvUpnAJPKktfkTtGyofmxm != 1)
					{
						return;
					}
					goto IL_001a;
				}
				goto IL_0051;
				IL_0051:
				JSOKBmvUpnAJPKktfkTtGyofmxm--;
				int num;
				if (JSOKBmvUpnAJPKktfkTtGyofmxm < 0)
				{
					JSOKBmvUpnAJPKktfkTtGyofmxm = 0;
					num = 1110411888;
					goto IL_001f;
				}
				goto IL_0076;
				IL_001a:
				num = 1110411892;
				goto IL_001f;
				IL_001f:
				while (true)
				{
					switch (num ^ 0x422F8A70)
					{
					case 2:
						break;
					default:
						return;
					case 0:
						oRLWYqCIZqSkWRoIWDJZVWMUWBI();
						num = 1110411893;
						continue;
					case 3:
						goto IL_0051;
					case 5:
						goto IL_0076;
					case 4:
						biZSCzGNZSOIcWekqYfQgNGXSHT();
						return;
					case 1:
						return;
					}
					break;
				}
				goto IL_001a;
				IL_0076:
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					ZxydwIdmjSEINiGoVJNNowUobfJ();
					num = 1110411889;
					goto IL_001f;
				}
			}

			public bool GetButton(int index)
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					YUPwMOEFcBFDiKJIXtefKNBgFpC();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return lgAkyeKCNYSjxkICDjzKgIcrtWEL[index];
			}

			public float GetAxisRaw(int index)
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					YUPwMOEFcBFDiKJIXtefKNBgFpC();
					return 0f;
				}
				if ((uint)index >= 3u)
				{
					return 0f;
				}
				return EteKXKVjofLKPeANfYKFAFNxxsR[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					YUPwMOEFcBFDiKJIXtefKNBgFpC();
					return;
				}
				while (buttons != null)
				{
					int num;
					int num2;
					if (buttons.Length < 7)
					{
						num = -2136134486;
						num2 = num;
					}
					else
					{
						num = -2136134487;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -2136134488)
						{
						case 0:
							goto IL_000f;
						case 3:
							break;
						case 2:
							return;
						default:
							Array.Copy(lgAkyeKCNYSjxkICDjzKgIcrtWEL, buttons, 7);
							return;
						}
						break;
						IL_000f:
						num = -2136134485;
					}
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (JSOKBmvUpnAJPKktfkTtGyofmxm == 0)
				{
					YUPwMOEFcBFDiKJIXtefKNBgFpC();
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (axes != null)
					{
						num = -635200835;
						num2 = num;
					}
					else
					{
						num = -635200836;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -635200834)
						{
						case 4:
							num = -635200833;
							continue;
						case 1:
							break;
						case 3:
						{
							int num3;
							if (axes.Length >= 3)
							{
								num = -635200834;
								num3 = num;
							}
							else
							{
								num = -635200836;
								num3 = num;
							}
							continue;
						}
						case 2:
							return;
						default:
							Array.Copy(EteKXKVjofLKPeANfYKFAFNxxsR, axes, 3);
							return;
						}
						break;
					}
				}
			}

			private void bbBpdCFNUtLARgPYWgfbIajvpEs()
			{
				Array.Clear(lgAkyeKCNYSjxkICDjzKgIcrtWEL, 0, 7);
				Array.Clear(EteKXKVjofLKPeANfYKFAFNxxsR, 0, 3);
			}

			private void CbNIcrvnFQKuUFKiCEsYAUrFeFbZ()
			{
				JSOKBmvUpnAJPKktfkTtGyofmxm = 0;
				NQYagDGTCeiDlLRmkNwtBxjbOsEo = Vector3.zero;
				WdiFBZqmaSeGNKlVLdCOjRHfHFG = false;
			}

			private void biZSCzGNZSOIcWekqYfQgNGXSHT()
			{
			}

			private void ZxydwIdmjSEINiGoVJNNowUobfJ()
			{
				bbBpdCFNUtLARgPYWgfbIajvpEs();
			}

			private void YUPwMOEFcBFDiKJIXtefKNBgFpC()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", true);
			}

			private void oRLWYqCIZqSkWRoIWDJZVWMUWBI()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", true);
			}
		}

		private static Mouse GuYbcURlyrkGmhVCtcsUHUPcMSc;

		private static Keyboard jfGJhMvxRadYQPslYBxGvNWWKsd;

		public static Mouse mouse
		{
			get
			{
				return GuYbcURlyrkGmhVCtcsUHUPcMSc ?? (GuYbcURlyrkGmhVCtcsUHUPcMSc = new Mouse());
			}
		}

		public static Keyboard keyboard
		{
			get
			{
				return jfGJhMvxRadYQPslYBxGvNWWKsd ?? (jfGJhMvxRadYQPslYBxGvNWWKsd = new Keyboard());
			}
		}

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (jfGJhMvxRadYQPslYBxGvNWWKsd != null)
			{
				jfGJhMvxRadYQPslYBxGvNWWKsd.PostInitialize();
				goto IL_0011;
			}
			goto IL_002f;
			IL_002f:
			int num;
			if (GuYbcURlyrkGmhVCtcsUHUPcMSc != null)
			{
				GuYbcURlyrkGmhVCtcsUHUPcMSc.PostInitialize();
				num = 1063495999;
				goto IL_0016;
			}
			return;
			IL_0011:
			num = 1063495996;
			goto IL_0016;
			IL_0016:
			switch (num ^ 0x3F63A93E)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_002f;
			case 1:
				return;
			}
			goto IL_0011;
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (jfGJhMvxRadYQPslYBxGvNWWKsd != null)
			{
				goto IL_0007;
			}
			goto IL_0047;
			IL_0007:
			int num = 1235958824;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ 0x49AB3C29)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					jfGJhMvxRadYQPslYBxGvNWWKsd = null;
					num = 1235958826;
					continue;
				case 0:
					GuYbcURlyrkGmhVCtcsUHUPcMSc = null;
					num = 1235958827;
					continue;
				case 3:
					goto IL_0047;
				case 2:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0047:
			int num2;
			if (GuYbcURlyrkGmhVCtcsUHUPcMSc != null)
			{
				num = 1235958825;
				num2 = num;
			}
			else
			{
				num = 1235958827;
				num2 = num;
			}
			goto IL_000c;
		}

		public static void Update()
		{
			if (jfGJhMvxRadYQPslYBxGvNWWKsd != null)
			{
				jfGJhMvxRadYQPslYBxGvNWWKsd.enabled = ReInput.controllers.Keyboard.enabled;
				goto IL_0020;
			}
			goto IL_0053;
			IL_0053:
			int num;
			if (GuYbcURlyrkGmhVCtcsUHUPcMSc != null)
			{
				GuYbcURlyrkGmhVCtcsUHUPcMSc.Update();
				num = 1094009077;
				goto IL_0025;
			}
			return;
			IL_0020:
			num = 1094009078;
			goto IL_0025;
			IL_0025:
			while (true)
			{
				switch (num ^ 0x413540F7)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					jfGJhMvxRadYQPslYBxGvNWWKsd.Update();
					num = 1094009076;
					continue;
				case 3:
					goto IL_0053;
				case 2:
					return;
				}
				break;
			}
			goto IL_0020;
		}
	}
}
