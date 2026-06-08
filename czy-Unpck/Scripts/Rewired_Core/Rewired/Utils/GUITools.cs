using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	public static class GUITools
	{
		public static class Solid
		{
			private static bool KAFxwSUHqzWignSLgdNZFjSzMwt = false;

			private static Texture2D EnyFkzWQAFLqNFoItoPSIsQPmFF;

			private static Color QBQGhxhHOMjciQzzAYROlnIkNcIb;

			public static Color color
			{
				get
				{
					return GUI.color;
				}
				set
				{
					GUI.color = value;
				}
			}

			public static float colorR
			{
				get
				{
					return GUI.color.r;
				}
				set
				{
					Color color = GUI.color;
					color.r = value;
					Solid.color = color;
				}
			}

			public static float colorG
			{
				get
				{
					return GUI.color.g;
				}
				set
				{
					Color color = GUI.color;
					while (true)
					{
						int num = 1620968102;
						while (true)
						{
							switch (num ^ 0x609E02A4)
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
							color.g = value;
							Solid.color = color;
							num = 1620968101;
						}
					}
				}
			}

			public static float colorB
			{
				get
				{
					return GUI.color.b;
				}
				set
				{
					Color color = GUI.color;
					color.b = value;
					Solid.color = color;
				}
			}

			public static float colorA
			{
				get
				{
					return GUI.color.a;
				}
				set
				{
					Color color = GUI.color;
					color.a = value;
					Solid.color = color;
				}
			}

			public static void Draw(Rect rect)
			{
				if (EnyFkzWQAFLqNFoItoPSIsQPmFF == null)
				{
					EnyFkzWQAFLqNFoItoPSIsQPmFF = new Texture2D(1, 1);
					goto IL_0019;
				}
				goto IL_0069;
				IL_0069:
				GUI.DrawTexture(rect, EnyFkzWQAFLqNFoItoPSIsQPmFF, ScaleMode.StretchToFill);
				int num = -71352593;
				goto IL_001e;
				IL_0019:
				num = -71352594;
				goto IL_001e;
				IL_001e:
				while (true)
				{
					switch (num ^ -71352596)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						EnyFkzWQAFLqNFoItoPSIsQPmFF.SetPixel(0, 0, Color.white);
						EnyFkzWQAFLqNFoItoPSIsQPmFF.Apply();
						EnyFkzWQAFLqNFoItoPSIsQPmFF.hideFlags = HideFlags.DontSave;
						num = -71352595;
						continue;
					case 1:
						goto IL_0069;
					case 3:
						return;
					}
					break;
				}
				goto IL_0019;
			}

			public static void Draw(Rect rect, Color color)
			{
				if (KAFxwSUHqzWignSLgdNZFjSzMwt)
				{
					Solid.color = color;
					Draw(rect);
					return;
				}
				while (true)
				{
					BeginDrawSet();
					int num = 2100900916;
					while (true)
					{
						switch (num ^ 0x7D393435)
						{
						case 0:
							num = 2100900918;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							Solid.color = color;
							Draw(rect);
							EndDrawSet();
							num = 2100900919;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			public static void DrawRotated(Rect rect, float rotation)
			{
				bool flag = ((rotation != 0f) ? true : false);
				Matrix4x4 matrix = default(Matrix4x4);
				while (true)
				{
					int num = 1083531763;
					while (true)
					{
						switch (num ^ 0x409561F0)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (flag)
							{
								GUI.matrix = matrix;
								num = 1083531764;
								continue;
							}
							return;
						case 2:
							Draw(rect);
							num = 1083531761;
							continue;
						case 3:
							matrix = GUI.matrix;
							if (flag)
							{
								GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
								num = 1083531762;
								continue;
							}
							goto case 2;
						case 4:
							return;
						}
						break;
					}
				}
			}

			public static void DrawRotated(Rect rect, Color color, float rotation)
			{
				bool flag = ((rotation != 0f) ? true : false);
				Matrix4x4 matrix = default(Matrix4x4);
				while (true)
				{
					int num = -325848266;
					while (true)
					{
						switch (num ^ -325848268)
						{
						case 5:
							break;
						default:
							return;
						case 2:
						{
							matrix = GUI.matrix;
							int num3;
							if (flag)
							{
								num = -325848272;
								num3 = num;
							}
							else
							{
								num = -325848265;
								num3 = num;
							}
							continue;
						}
						case 4:
							GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
							num = -325848265;
							continue;
						case 3:
						{
							Draw(rect, color);
							int num2;
							if (flag)
							{
								num = -325848267;
								num2 = num;
							}
							else
							{
								num = -325848268;
								num2 = num;
							}
							continue;
						}
						case 1:
							GUI.matrix = matrix;
							num = -325848268;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}

			public static Texture2D DrawToTexture(Rect rect)
			{
				Texture2D texture2D = new Texture2D(1, 1);
				texture2D.SetPixel(0, 0, Color.white);
				texture2D.Resize((int)rect.width, (int)rect.height);
				texture2D.Apply();
				texture2D.hideFlags = HideFlags.DontSave;
				return texture2D;
			}

			public static void BeginDrawSet()
			{
				KAFxwSUHqzWignSLgdNZFjSzMwt = true;
				QBQGhxhHOMjciQzzAYROlnIkNcIb = GUI.color;
			}

			public static void EndDrawSet()
			{
				KAFxwSUHqzWignSLgdNZFjSzMwt = false;
				GUI.color = QBQGhxhHOMjciQzzAYROlnIkNcIb;
			}

			public static void DrawBox(Rect rect, Color color, float lineWidth = 1f)
			{
				if (KAFxwSUHqzWignSLgdNZFjSzMwt)
				{
					goto IL_0007;
				}
				goto IL_0031;
				IL_0007:
				int num = 1613602227;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x602D9DB6)
					{
					case 2:
						break;
					case 0:
						goto IL_0031;
					case 4:
						DrawBox(rect, lineWidth);
						num = 1613602229;
						continue;
					case 5:
						Solid.color = color;
						num = 1613602226;
						continue;
					case 3:
						return;
					default:
						EndDrawSet();
						return;
					}
					break;
				}
				goto IL_0007;
				IL_0031:
				BeginDrawSet();
				Solid.color = color;
				DrawBox(rect, lineWidth);
				num = 1613602231;
				goto IL_000c;
			}

			public static void DrawBox(Rect rect, float lineWidth = 1f)
			{
				Draw(new Rect(rect.x, rect.y, rect.width, lineWidth));
				Draw(new Rect(rect.x, rect.y + rect.height - lineWidth, rect.width, lineWidth));
				Draw(new Rect(rect.x, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
				Draw(new Rect(rect.x + rect.width - lineWidth, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
			}

			public static void DrawBoxRotated(Rect rect, float rotation, float lineWidth = 1f)
			{
				if (rotation == 0f)
				{
					goto IL_000b;
				}
				int num = 1;
				goto IL_00f7;
				IL_00f7:
				bool flag = (byte)num != 0;
				Matrix4x4 matrix = GUI.matrix;
				int num2 = -2114564550;
				goto IL_0010;
				IL_000b:
				num2 = -2114564546;
				goto IL_0010;
				IL_0010:
				while (true)
				{
					switch (num2 ^ -2114564545)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						Draw(new Rect(rect.x, rect.y + rect.height - lineWidth, rect.width, lineWidth));
						Draw(new Rect(rect.x, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
						Draw(new Rect(rect.x + rect.width - lineWidth, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
						if (flag)
						{
							GUI.matrix = matrix;
							num2 = -2114564549;
							continue;
						}
						return;
					case 5:
						if (flag)
						{
							GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
							num2 = -2114564545;
							continue;
						}
						goto case 0;
					case 1:
						goto IL_00f3;
					case 0:
						Draw(new Rect(rect.x, rect.y, rect.width, lineWidth));
						num2 = -2114564548;
						continue;
					case 4:
						return;
					}
					break;
				}
				goto IL_000b;
				IL_00f3:
				num = 0;
				goto IL_00f7;
			}
		}

		internal class DPQMMgoqtAFPmRJwcMzzmThxsjg
		{
			private kKTCjHWcLaMiaFTfGoBTaDupxKo oShsPjnaHyptoMyNHQbrYAeblvS;

			private Rect uxfmJpoDZrmBjKmMhkQbjyGPVjc;

			private float nVaSKRaIECLWjUrhFQCBdDQAaHjA;

			public DPQMMgoqtAFPmRJwcMzzmThxsjg()
			{
				oShsPjnaHyptoMyNHQbrYAeblvS = new kKTCjHWcLaMiaFTfGoBTaDupxKo();
			}

			public void CNXJWwWmortQRrFSlKQtjwKUrjH(Rect P_0, float P_1)
			{
				if (!(P_0 != uxfmJpoDZrmBjKmMhkQbjyGPVjc))
				{
					goto IL_000e;
				}
				goto IL_0050;
				IL_000e:
				int num = -1869513849;
				goto IL_0013;
				IL_0013:
				Rect position = default(Rect);
				Rect rect = default(Rect);
				while (true)
				{
					switch (num ^ -1869513856)
					{
					case 5:
						break;
					case 3:
						position = rect;
						num = -1869513854;
						continue;
					case 1:
						goto IL_0050;
					case 7:
						goto IL_0099;
					case 8:
						num = -1869513854;
						continue;
					case 4:
						rect = leGCMCGrihKYNeDmgIxzpkiwwrX(P_0, P_1);
						rect.center = P_0.center;
						num = -1869513853;
						continue;
					case 2:
						GUI.DrawTexture(position, oShsPjnaHyptoMyNHQbrYAeblvS.texture, ScaleMode.StretchToFill);
						num = -1869513856;
						continue;
					case 6:
						if (P_1 == 0f)
						{
							position = P_0;
							num = -1869513848;
							continue;
						}
						goto case 4;
					default:
						uxfmJpoDZrmBjKmMhkQbjyGPVjc = P_0;
						nVaSKRaIECLWjUrhFQCBdDQAaHjA = P_1;
						return;
					}
					break;
					IL_0099:
					int num2;
					if (nVaSKRaIECLWjUrhFQCBdDQAaHjA != P_1)
					{
						num = -1869513855;
						num2 = num;
					}
					else
					{
						num = -1869513850;
						num2 = num;
					}
				}
				goto IL_000e;
				IL_0050:
				float num3 = P_0.width / P_0.height;
				Texture2D texture2D = Solid.DrawToTexture(new Rect(0f, 0f, num3 * 100f, 100f));
				DMZZqSuAhajjKLtqpTleAQiUHim(texture2D);
				yYlwlFfgNwBihrcefjPyXUywDCvF(P_1);
				num = -1869513850;
				goto IL_0013;
			}

			private void DMZZqSuAhajjKLtqpTleAQiUHim(Texture2D P_0)
			{
				oShsPjnaHyptoMyNHQbrYAeblvS.vogfSkFFcCaKRLtlgxsEfQVqWQqj(true);
				oShsPjnaHyptoMyNHQbrYAeblvS.CHWDoIJFbUPiCCQqjvBLnPoSWjTy(P_0);
			}

			private void yYlwlFfgNwBihrcefjPyXUywDCvF(float P_0)
			{
				oShsPjnaHyptoMyNHQbrYAeblvS.yYlwlFfgNwBihrcefjPyXUywDCvF(P_0);
			}

			private Rect leGCMCGrihKYNeDmgIxzpkiwwrX(Rect P_0, float P_1)
			{
				float value = (float)Math.PI / 180f * P_1;
				int num = (int)P_0.height;
				int a = default(int);
				int a3 = default(int);
				int b = default(int);
				int num5 = default(int);
				int a2 = default(int);
				int a4 = default(int);
				int b2 = default(int);
				int num4 = default(int);
				int num6 = default(int);
				int num7 = default(int);
				float num9 = default(float);
				float num8 = default(float);
				while (true)
				{
					int num2 = 1998629903;
					while (true)
					{
						switch (num2 ^ 0x7720AC0A)
						{
						case 2:
							break;
						case 6:
						{
							int num10 = MathTools.Min(0, MathTools.Min(a, MathTools.Min(a3, b)));
							num5 = MathTools.Min(0, MathTools.Min(a2, MathTools.Min(a4, b2)));
							int num11 = MathTools.Max(0, MathTools.Max(a, MathTools.Max(a3, b)));
							num4 = MathTools.Max(0, MathTools.Max(a2, MathTools.Max(a4, b2)));
							num6 = num11 - num10 + 1;
							num2 = 1998629897;
							continue;
						}
						case 1:
							b2 = (int)((float)num7 * num9);
							num2 = 1998629900;
							continue;
						case 4:
							b = (int)((float)num7 * num8);
							num2 = 1998629899;
							continue;
						case 0:
							num8 = MathTools.Cos(value);
							num9 = MathTools.Sin(value);
							a = (int)((float)(-num) * num9);
							a2 = (int)((float)num * num8);
							a3 = (int)((float)num7 * num8 - (float)num * num9);
							a4 = (int)((float)num * num8 + (float)num7 * num9);
							num2 = 1998629902;
							continue;
						case 5:
							num7 = (int)P_0.width;
							num2 = 1998629898;
							continue;
						default:
						{
							int num3 = num4 - num5 + 1;
							return new Rect(0f, 0f, num6, num3);
						}
						}
						break;
					}
				}
			}

			public void vogfSkFFcCaKRLtlgxsEfQVqWQqj()
			{
				if (oShsPjnaHyptoMyNHQbrYAeblvS != null)
				{
					oShsPjnaHyptoMyNHQbrYAeblvS.vogfSkFFcCaKRLtlgxsEfQVqWQqj(true);
				}
			}
		}

		internal class kKTCjHWcLaMiaFTfGoBTaDupxKo
		{
			private Texture2D jVcXZwiFodNJPDJOoEhaXfsPNUl;

			private Texture2D OvOBxOiFskTsRatkXJYduJqYDRy;

			private bool TKePGmrWnCOgJjKwtUCWdkAamAJ;

			public Texture2D texture
			{
				get
				{
					if (TKePGmrWnCOgJjKwtUCWdkAamAJ)
					{
						return OvOBxOiFskTsRatkXJYduJqYDRy;
					}
					return jVcXZwiFodNJPDJOoEhaXfsPNUl;
				}
			}

			public Rect rect
			{
				get
				{
					if (TKePGmrWnCOgJjKwtUCWdkAamAJ)
					{
						if (OvOBxOiFskTsRatkXJYduJqYDRy != null)
						{
							return new Rect(0f, 0f, OvOBxOiFskTsRatkXJYduJqYDRy.width, OvOBxOiFskTsRatkXJYduJqYDRy.height);
						}
					}
					else if (jVcXZwiFodNJPDJOoEhaXfsPNUl != null)
					{
						return new Rect(0f, 0f, jVcXZwiFodNJPDJOoEhaXfsPNUl.width, jVcXZwiFodNJPDJOoEhaXfsPNUl.height);
					}
					return default(Rect);
				}
			}

			public kKTCjHWcLaMiaFTfGoBTaDupxKo()
			{
			}

			public kKTCjHWcLaMiaFTfGoBTaDupxKo(Texture2D texture)
			{
				CHWDoIJFbUPiCCQqjvBLnPoSWjTy(texture);
			}

			public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy(Texture2D P_0)
			{
				vogfSkFFcCaKRLtlgxsEfQVqWQqj();
				jVcXZwiFodNJPDJOoEhaXfsPNUl = P_0;
				CBEQAXvmEzUGZLrxTEYdqpmmIdZ();
				TKePGmrWnCOgJjKwtUCWdkAamAJ = false;
			}

			private void CBEQAXvmEzUGZLrxTEYdqpmmIdZ()
			{
				if (!(jVcXZwiFodNJPDJOoEhaXfsPNUl == null))
				{
					return;
				}
				while (true)
				{
					switch (-1528181828 ^ -1528181827)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						throw new Exception("Texture cannot be null!");
					case 0:
						return;
					}
				}
			}

			public void yYlwlFfgNwBihrcefjPyXUywDCvF(float P_0)
			{
				CBEQAXvmEzUGZLrxTEYdqpmmIdZ();
				while (true)
				{
					int num = 1799224637;
					while (true)
					{
						switch (num ^ 0x6B3DFD3E)
						{
						case 2:
							break;
						case 3:
							if (P_0 != 0f)
							{
								goto IL_003f;
							}
							TKePGmrWnCOgJjKwtUCWdkAamAJ = false;
							return;
						case 0:
							goto IL_003f;
						default:
							vogfSkFFcCaKRLtlgxsEfQVqWQqj();
							OvOBxOiFskTsRatkXJYduJqYDRy = GetRotatedTexture(jVcXZwiFodNJPDJOoEhaXfsPNUl, P_0, Color.clear);
							return;
						}
						break;
						IL_003f:
						TKePGmrWnCOgJjKwtUCWdkAamAJ = true;
						num = 1799224639;
					}
				}
			}

			public void vogfSkFFcCaKRLtlgxsEfQVqWQqj(bool P_0 = false)
			{
				if (OvOBxOiFskTsRatkXJYduJqYDRy != null)
				{
					UnityEngine.Object.DestroyImmediate(OvOBxOiFskTsRatkXJYduJqYDRy);
					goto IL_0019;
				}
				goto IL_003b;
				IL_003b:
				int num;
				int num2;
				if (P_0)
				{
					num = -966493300;
					num2 = num;
				}
				else
				{
					num = -966493299;
					num2 = num;
				}
				goto IL_001e;
				IL_0019:
				num = -966493297;
				goto IL_001e;
				IL_001e:
				while (true)
				{
					switch (num ^ -966493298)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_003b;
					case 2:
						if (jVcXZwiFodNJPDJOoEhaXfsPNUl != null)
						{
							UnityEngine.Object.DestroyImmediate(jVcXZwiFodNJPDJOoEhaXfsPNUl);
							num = -966493299;
							continue;
						}
						return;
					case 3:
						return;
					}
					break;
				}
				goto IL_0019;
			}
		}

		public static Texture2D GetRotatedTexture(Texture2D texture, float angle, Color backgroundColor)
		{
			float value = (float)Math.PI / 180f * angle;
			int height = texture.height;
			int width = texture.width;
			float num = MathTools.Cos(value);
			int num7 = default(int);
			Color[] array = default(Color[]);
			int num3 = default(int);
			float num10 = default(float);
			int num9 = default(int);
			int a = default(int);
			int a2 = default(int);
			int b2 = default(int);
			int num8 = default(int);
			int a3 = default(int);
			int a4 = default(int);
			int num15 = default(int);
			int num13 = default(int);
			int num14 = default(int);
			Color[] pixels = default(Color[]);
			Texture2D texture2D = default(Texture2D);
			int num5 = default(int);
			int num11 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num2 = -1157660551;
				while (true)
				{
					switch (num2 ^ -1157660555)
					{
					case 5:
						break;
					case 16:
						num7++;
						num2 = -1157660545;
						continue;
					case 6:
						num2 = -1157660570;
						continue;
					case 7:
						array[num3] = backgroundColor;
						num2 = -1157660570;
						continue;
					case 3:
					{
						int b = (int)((float)width * num10);
						num9 = MathTools.Min(0, MathTools.Min(a, MathTools.Min(a2, b2)));
						num8 = MathTools.Min(0, MathTools.Min(a3, MathTools.Min(a4, b)));
						int num18 = MathTools.Max(0, MathTools.Max(a, MathTools.Max(a2, b2)));
						num15 = MathTools.Max(0, MathTools.Max(a3, MathTools.Max(a4, b)));
						num13 = num18 - num9 + 1;
						num2 = -1157660569;
						continue;
					}
					case 10:
					{
						int num16;
						if (num7 >= num14)
						{
							num2 = -1157660546;
							num16 = num2;
						}
						else
						{
							num2 = -1157660547;
							num16 = num2;
						}
						continue;
					}
					case 18:
						num14 = num15 - num8 + 1;
						array = new Color[num13 * num14];
						pixels = texture.GetPixels();
						num7 = 0;
						num2 = -1157660545;
						continue;
					case 11:
						texture2D = new Texture2D(num13, num14);
						texture2D.SetPixels(array);
						num2 = -1157660555;
						continue;
					case 15:
						a3 = (int)((float)height * num);
						a2 = (int)((float)width * num - (float)height * num10);
						a4 = (int)((float)height * num + (float)width * num10);
						b2 = (int)((float)width * num);
						num2 = -1157660554;
						continue;
					case 12:
						num10 = MathTools.Sin(value);
						num2 = -1157660552;
						continue;
					case 8:
						num5 = 0;
						num2 = -1157660572;
						continue;
					case 17:
					{
						int num17;
						if (num5 < num13)
						{
							num2 = -1157660549;
							num17 = num2;
						}
						else
						{
							num2 = -1157660571;
							num17 = num2;
						}
						continue;
					}
					case 14:
						num3 = num7 * num13 + num5;
						num11 = (int)((float)(num5 + num9) * num + (float)(num7 + num8) * num10);
						num2 = -1157660553;
						continue;
					case 9:
						num4 = num6 * width + num11;
						if (num11 >= 0 && num11 < width && num6 >= 0)
						{
							int num12;
							if (num6 < height)
							{
								num2 = -1157660559;
								num12 = num2;
							}
							else
							{
								num2 = -1157660558;
								num12 = num2;
							}
							continue;
						}
						goto case 7;
					case 13:
						a = (int)((float)(-height) * num10);
						num2 = -1157660550;
						continue;
					case 2:
						num6 = (int)((float)(num7 + num8) * num - (float)(num5 + num9) * num10);
						num2 = -1157660548;
						continue;
					case 19:
						num5++;
						num2 = -1157660572;
						continue;
					case 4:
					{
						ref Color reference = ref array[num3];
						reference = pixels[num4];
						num2 = -1157660557;
						continue;
					}
					case 0:
						texture2D.Apply();
						texture2D.hideFlags = HideFlags.DontSave;
						num2 = -1157660556;
						continue;
					default:
						return texture2D;
					}
					break;
				}
			}
		}

		public static GUIContent[] ToGUIContentArray(string[] items)
		{
			if (items == null)
			{
				return null;
			}
			GUIContent[] array = new GUIContent[items.Length];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < items.Length)
				{
					num2 = 823005556;
					num3 = num2;
				}
				else
				{
					num2 = 823005559;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x310E1176)
					{
					case 0:
						num2 = 823005556;
						continue;
					case 2:
						array[num] = new GUIContent(items[num]);
						num++;
						num2 = 823005557;
						continue;
					case 3:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}

		public static GUIContent[] ToGUIContentArray(IList<string> items)
		{
			if (items == null)
			{
				return null;
			}
			GUIContent[] array = new GUIContent[items.Count];
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= items.Count)
				{
					num2 = 75239294;
					num3 = num2;
				}
				else
				{
					num2 = 75239292;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x47C0F7F)
					{
					case 2:
						num2 = 75239292;
						continue;
					case 3:
						array[num] = new GUIContent(items[num]);
						num++;
						num2 = 75239295;
						continue;
					case 0:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}
	}
}
