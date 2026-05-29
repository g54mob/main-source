using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	public static class GUITools
	{
		public static class Solid
		{
			private static bool zCLiYHakPtBXzoYsdQICOLislXCp = false;

			private static Texture2D bPeAeeGqbJkMKBuBiJTLQKIKZvi;

			private static Color pUCSgoritCfmrYeCDyJJrBshkvn;

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
					color.g = value;
					Solid.color = color;
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
					while (true)
					{
						int num = -1169765167;
						while (true)
						{
							switch (num ^ -1169765166)
							{
							case 0:
								break;
							default:
								return;
							case 3:
								color.a = value;
								num = -1169765168;
								continue;
							case 2:
								Solid.color = color;
								num = -1169765165;
								continue;
							case 1:
								return;
							}
							break;
						}
					}
				}
			}

			public static void Draw(Rect rect)
			{
				if (bPeAeeGqbJkMKBuBiJTLQKIKZvi == null)
				{
					bPeAeeGqbJkMKBuBiJTLQKIKZvi = new Texture2D(1, 1);
					while (true)
					{
						int num = -1604825308;
						while (true)
						{
							switch (num ^ -1604825307)
							{
							case 4:
								break;
							case 3:
								bPeAeeGqbJkMKBuBiJTLQKIKZvi.hideFlags = HideFlags.DontSave;
								num = -1604825305;
								continue;
							case 0:
								bPeAeeGqbJkMKBuBiJTLQKIKZvi.Apply();
								num = -1604825306;
								continue;
							case 1:
								bPeAeeGqbJkMKBuBiJTLQKIKZvi.SetPixel(0, 0, Color.white);
								num = -1604825307;
								continue;
							default:
								goto end_IL_0019;
							}
							break;
						}
						continue;
						end_IL_0019:
						break;
					}
				}
				GUI.DrawTexture(rect, bPeAeeGqbJkMKBuBiJTLQKIKZvi, ScaleMode.StretchToFill);
			}

			public static void Draw(Rect rect, Color color)
			{
				if (zCLiYHakPtBXzoYsdQICOLislXCp)
				{
					goto IL_0007;
				}
				goto IL_003a;
				IL_0007:
				int num = 74857729;
				goto IL_000c;
				IL_000c:
				while (true)
				{
					switch (num ^ 0x4763D05)
					{
					case 0:
						break;
					case 3:
						Solid.color = color;
						num = 74857735;
						continue;
					case 1:
						goto IL_003a;
					case 4:
						Solid.color = color;
						Draw(rect);
						return;
					default:
						Draw(rect);
						EndDrawSet();
						return;
					}
					break;
				}
				goto IL_0007;
				IL_003a:
				BeginDrawSet();
				num = 74857734;
				goto IL_000c;
			}

			public static void DrawRotated(Rect rect, float rotation)
			{
				bool flag = ((rotation != 0f) ? true : false);
				Matrix4x4 matrix = GUI.matrix;
				while (true)
				{
					int num = -1271945189;
					while (true)
					{
						switch (num ^ -1271945190)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							if (flag)
							{
								GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
								num = -1271945192;
								continue;
							}
							goto case 2;
						case 2:
							Draw(rect);
							if (flag)
							{
								GUI.matrix = matrix;
								num = -1271945190;
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

			public static void DrawRotated(Rect rect, Color color, float rotation)
			{
				bool flag = ((rotation != 0f) ? true : false);
				Matrix4x4 matrix = default(Matrix4x4);
				while (true)
				{
					int num = 1613188017;
					while (true)
					{
						switch (num ^ 0x60274BB5)
						{
						case 0:
							break;
						default:
							return;
						case 4:
						{
							matrix = GUI.matrix;
							int num2;
							if (!flag)
							{
								num = 1613188020;
								num2 = num;
							}
							else
							{
								num = 1613188016;
								num2 = num;
							}
							continue;
						}
						case 5:
							GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
							num = 1613188020;
							continue;
						case 3:
							if (flag)
							{
								GUI.matrix = matrix;
								num = 1613188023;
								continue;
							}
							return;
						case 1:
							Draw(rect, color);
							num = 1613188022;
							continue;
						case 2:
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
				zCLiYHakPtBXzoYsdQICOLislXCp = true;
				pUCSgoritCfmrYeCDyJJrBshkvn = GUI.color;
			}

			public static void EndDrawSet()
			{
				zCLiYHakPtBXzoYsdQICOLislXCp = false;
				GUI.color = pUCSgoritCfmrYeCDyJJrBshkvn;
			}

			public static void DrawBox(Rect rect, Color color, float lineWidth = 1f)
			{
				if (zCLiYHakPtBXzoYsdQICOLislXCp)
				{
					while (true)
					{
						int num = -199823575;
						while (true)
						{
							switch (num ^ -199823574)
							{
							case 2:
								break;
							case 3:
								Solid.color = color;
								num = -199823574;
								continue;
							case 0:
								DrawBox(rect, lineWidth);
								return;
							default:
								goto end_IL_0007;
							}
							break;
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				BeginDrawSet();
				Solid.color = color;
				DrawBox(rect, lineWidth);
				EndDrawSet();
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
					goto IL_0008;
				}
				int num = 1;
				goto IL_0039;
				IL_0039:
				bool flag = (byte)num != 0;
				Matrix4x4 matrix = GUI.matrix;
				int num2;
				if (flag)
				{
					GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
					num2 = 1070023913;
					goto IL_000d;
				}
				goto IL_0070;
				IL_0008:
				num2 = 1070023918;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num2 ^ 0x3FC744EA)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						goto IL_0035;
					case 5:
						if (flag)
						{
							GUI.matrix = matrix;
							num2 = 1070023915;
							continue;
						}
						return;
					case 3:
						goto IL_0070;
					case 2:
						Draw(new Rect(rect.x + rect.width - lineWidth, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
						num2 = 1070023919;
						continue;
					case 1:
						return;
					}
					break;
				}
				goto IL_0008;
				IL_0070:
				Draw(new Rect(rect.x, rect.y, rect.width, lineWidth));
				Draw(new Rect(rect.x, rect.y + rect.height - lineWidth, rect.width, lineWidth));
				Draw(new Rect(rect.x, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
				num2 = 1070023912;
				goto IL_000d;
				IL_0035:
				num = 0;
				goto IL_0039;
			}
		}

		internal class mQCxLzGfKSFSzwoRzaGcheVsFaBt
		{
			private ROHsKSeDsumflmJGTaqEwaSucVHD FtAtTIPEBRasiazZYJpcIEcdvuOo;

			private Rect TtfaHgSDspaEmjOdgtbcfvgAOeR;

			private float YiqjSQGnKtHuUdSOrpOudeHqMCu;

			public mQCxLzGfKSFSzwoRzaGcheVsFaBt()
			{
				while (true)
				{
					int num = 465768290;
					while (true)
					{
						switch (num ^ 0x1BC30F63)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 2:
							return;
						}
						break;
						IL_0024:
						FtAtTIPEBRasiazZYJpcIEcdvuOo = new ROHsKSeDsumflmJGTaqEwaSucVHD();
						num = 465768289;
					}
				}
			}

			public void fUNwyPiQHpCgFGVagovJrHYBssQ(Rect P_0, float P_1)
			{
				if (!(P_0 != TtfaHgSDspaEmjOdgtbcfvgAOeR))
				{
					goto IL_0011;
				}
				goto IL_009f;
				IL_0011:
				int num = -1058984925;
				goto IL_0016;
				IL_0016:
				Rect position = default(Rect);
				Rect rect = default(Rect);
				Texture2D texture2D = default(Texture2D);
				float num2 = default(float);
				while (true)
				{
					switch (num ^ -1058984921)
					{
					case 9:
						break;
					default:
						return;
					case 1:
						GUI.DrawTexture(position, FtAtTIPEBRasiazZYJpcIEcdvuOo.texture, ScaleMode.StretchToFill);
						TtfaHgSDspaEmjOdgtbcfvgAOeR = P_0;
						YiqjSQGnKtHuUdSOrpOudeHqMCu = P_1;
						num = -1058984921;
						continue;
					case 8:
						rect.center = P_0.center;
						position = rect;
						num = -1058984922;
						continue;
					case 2:
						rect = YdEgxHeUNtoRADaFnwhurLYlUhc(P_0, P_1);
						num = -1058984913;
						continue;
					case 6:
						goto IL_009f;
					case 7:
						texture2D = Solid.DrawToTexture(new Rect(0f, 0f, num2 * 100f, 100f));
						num = -1058984926;
						continue;
					case 5:
						qOBhyJhWOgYiPqXTcgsnURCREKBG(texture2D);
						XXzlHQRoaiApggKZyncpNZYtwBG(P_1);
						num = -1058984924;
						continue;
					case 3:
						if (P_1 == 0f)
						{
							position = P_0;
							num = -1058984922;
							continue;
						}
						goto case 2;
					case 4:
						goto IL_0110;
					case 0:
						return;
					}
					break;
					IL_0110:
					int num3;
					if (YiqjSQGnKtHuUdSOrpOudeHqMCu == P_1)
					{
						num = -1058984924;
						num3 = num;
					}
					else
					{
						num = -1058984927;
						num3 = num;
					}
				}
				goto IL_0011;
				IL_009f:
				num2 = P_0.width / P_0.height;
				num = -1058984928;
				goto IL_0016;
			}

			private void qOBhyJhWOgYiPqXTcgsnURCREKBG(Texture2D P_0)
			{
				FtAtTIPEBRasiazZYJpcIEcdvuOo.SmmvnjxHFEDBSGsCxZMVOTjrJJV(true);
				FtAtTIPEBRasiazZYJpcIEcdvuOo.xaGVjRxEvIdELjjBskoGFDUNmrm(P_0);
			}

			private void XXzlHQRoaiApggKZyncpNZYtwBG(float P_0)
			{
				FtAtTIPEBRasiazZYJpcIEcdvuOo.XXzlHQRoaiApggKZyncpNZYtwBG(P_0);
			}

			private Rect YdEgxHeUNtoRADaFnwhurLYlUhc(Rect P_0, float P_1)
			{
				float value = (float)Math.PI / 180f * P_1;
				int num4 = default(int);
				int num6 = default(int);
				float num5 = default(float);
				float num7 = default(float);
				int a4 = default(int);
				int num11 = default(int);
				int a = default(int);
				int a3 = default(int);
				int b = default(int);
				int b2 = default(int);
				int num3 = default(int);
				int num9 = default(int);
				int num2 = default(int);
				int num10 = default(int);
				int num8 = default(int);
				int a2 = default(int);
				while (true)
				{
					int num = 780735312;
					while (true)
					{
						switch (num ^ 0x2E891352)
						{
						case 7:
							break;
						case 2:
							num4 = (int)P_0.height;
							num6 = (int)P_0.width;
							num5 = MathTools.Cos(value);
							num7 = MathTools.Sin(value);
							a4 = (int)((float)(-num4) * num7);
							num = 780735313;
							continue;
						case 5:
							num11 = MathTools.Max(0, MathTools.Max(a, MathTools.Max(a3, b)));
							num = 780735316;
							continue;
						case 1:
							b2 = (int)((float)num6 * num5);
							num = 780735322;
							continue;
						case 0:
							num3 = num11 - num9 + 1;
							num = 780735318;
							continue;
						case 6:
							num2 = num10 - num8 + 1;
							num = 780735314;
							continue;
						case 8:
							b = (int)((float)num6 * num7);
							num8 = MathTools.Min(0, MathTools.Min(a4, MathTools.Min(a2, b2)));
							num9 = MathTools.Min(0, MathTools.Min(a, MathTools.Min(a3, b)));
							num10 = MathTools.Max(0, MathTools.Max(a4, MathTools.Max(a2, b2)));
							num = 780735319;
							continue;
						case 3:
							a = (int)((float)num4 * num5);
							a2 = (int)((float)num6 * num5 - (float)num4 * num7);
							a3 = (int)((float)num4 * num5 + (float)num6 * num7);
							num = 780735315;
							continue;
						default:
							return new Rect(0f, 0f, num2, num3);
						}
						break;
					}
				}
			}

			public void SmmvnjxHFEDBSGsCxZMVOTjrJJV()
			{
				if (FtAtTIPEBRasiazZYJpcIEcdvuOo != null)
				{
					FtAtTIPEBRasiazZYJpcIEcdvuOo.SmmvnjxHFEDBSGsCxZMVOTjrJJV(true);
				}
			}
		}

		internal class ROHsKSeDsumflmJGTaqEwaSucVHD
		{
			private Texture2D SXwckfCXopGOIKwadMfhADRONMUy;

			private Texture2D jzGqUDUBBwwrYVuHWGpoaAUVlIB;

			private bool gngZodFDzKrFEEHVgypRvXuhQti;

			public Texture2D texture
			{
				get
				{
					if (gngZodFDzKrFEEHVgypRvXuhQti)
					{
						return jzGqUDUBBwwrYVuHWGpoaAUVlIB;
					}
					return SXwckfCXopGOIKwadMfhADRONMUy;
				}
			}

			public Rect rect
			{
				get
				{
					if (gngZodFDzKrFEEHVgypRvXuhQti)
					{
						if (jzGqUDUBBwwrYVuHWGpoaAUVlIB != null)
						{
							return new Rect(0f, 0f, jzGqUDUBBwwrYVuHWGpoaAUVlIB.width, jzGqUDUBBwwrYVuHWGpoaAUVlIB.height);
						}
					}
					else if (SXwckfCXopGOIKwadMfhADRONMUy != null)
					{
						goto IL_004c;
					}
					Rect result = default(Rect);
					int num = 1436659867;
					goto IL_0051;
					IL_004c:
					num = 1436659864;
					goto IL_0051;
					IL_0051:
					switch (num ^ 0x55A1B09A)
					{
					case 0:
						break;
					case 2:
						return new Rect(0f, 0f, SXwckfCXopGOIKwadMfhADRONMUy.width, SXwckfCXopGOIKwadMfhADRONMUy.height);
					default:
						return result;
					}
					goto IL_004c;
				}
			}

			public ROHsKSeDsumflmJGTaqEwaSucVHD()
			{
			}

			public ROHsKSeDsumflmJGTaqEwaSucVHD(Texture2D texture)
			{
				xaGVjRxEvIdELjjBskoGFDUNmrm(texture);
			}

			public void xaGVjRxEvIdELjjBskoGFDUNmrm(Texture2D P_0)
			{
				SmmvnjxHFEDBSGsCxZMVOTjrJJV();
				SXwckfCXopGOIKwadMfhADRONMUy = P_0;
				rFIFzUTZxhZVSiBSYfMualMnRRs();
				gngZodFDzKrFEEHVgypRvXuhQti = false;
			}

			private void rFIFzUTZxhZVSiBSYfMualMnRRs()
			{
				if (SXwckfCXopGOIKwadMfhADRONMUy == null)
				{
					throw new Exception("Texture cannot be null!");
				}
			}

			public void XXzlHQRoaiApggKZyncpNZYtwBG(float P_0)
			{
				rFIFzUTZxhZVSiBSYfMualMnRRs();
				if (P_0 == 0f)
				{
					gngZodFDzKrFEEHVgypRvXuhQti = false;
					return;
				}
				while (true)
				{
					gngZodFDzKrFEEHVgypRvXuhQti = true;
					SmmvnjxHFEDBSGsCxZMVOTjrJJV();
					jzGqUDUBBwwrYVuHWGpoaAUVlIB = GetRotatedTexture(SXwckfCXopGOIKwadMfhADRONMUy, P_0, Color.clear);
					int num = -1869169173;
					while (true)
					{
						switch (num ^ -1869169175)
						{
						case 0:
							goto IL_0016;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0016:
						num = -1869169176;
					}
				}
			}

			public void SmmvnjxHFEDBSGsCxZMVOTjrJJV(bool P_0 = false)
			{
				if (jzGqUDUBBwwrYVuHWGpoaAUVlIB != null)
				{
					UnityEngine.Object.DestroyImmediate(jzGqUDUBBwwrYVuHWGpoaAUVlIB);
					goto IL_0019;
				}
				goto IL_0037;
				IL_0037:
				int num;
				if (P_0 && SXwckfCXopGOIKwadMfhADRONMUy != null)
				{
					UnityEngine.Object.DestroyImmediate(SXwckfCXopGOIKwadMfhADRONMUy);
					num = 1799211529;
					goto IL_001e;
				}
				return;
				IL_0019:
				num = 1799211530;
				goto IL_001e;
				IL_001e:
				switch (num ^ 0x6B3DCA0B)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_0037;
				case 2:
					return;
				}
				goto IL_0019;
			}
		}

		public static Texture2D GetRotatedTexture(Texture2D texture, float angle, Color backgroundColor)
		{
			float value = (float)Math.PI / 180f * angle;
			int height = texture.height;
			Color[] array = default(Color[]);
			int num4 = default(int);
			int num6 = default(int);
			int num12 = default(int);
			int width = default(int);
			float num8 = default(float);
			float num11 = default(float);
			int a = default(int);
			int a2 = default(int);
			int num2 = default(int);
			int num7 = default(int);
			int num9 = default(int);
			int num10 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			int a3 = default(int);
			int b = default(int);
			int a4 = default(int);
			int b2 = default(int);
			int num14 = default(int);
			Color[] pixels = default(Color[]);
			Texture2D texture2D = default(Texture2D);
			while (true)
			{
				int num = 1084631016;
				while (true)
				{
					switch (num ^ 0x40A627E9)
					{
					case 12:
						break;
					case 10:
						array[num4] = backgroundColor;
						num = 1084631008;
						continue;
					case 2:
						num6 = 0;
						num = 1084631018;
						continue;
					case 3:
					{
						int num13;
						if (num6 >= num12)
						{
							num = 1084631014;
							num13 = num;
						}
						else
						{
							num = 1084631023;
							num13 = num;
						}
						continue;
					}
					case 1:
						width = texture.width;
						num8 = MathTools.Cos(value);
						num11 = MathTools.Sin(value);
						a = (int)((float)(-height) * num11);
						a2 = (int)((float)height * num8);
						num = 1084631015;
						continue;
					case 8:
						num2 = (int)((float)(num6 + num7) * num8 + (float)(num9 + num10) * num11);
						num3 = (int)((float)(num9 + num10) * num8 - (float)(num6 + num7) * num11);
						num5 = num3 * width + num2;
						num = 1084631012;
						continue;
					case 15:
						num9++;
						num = 1084631017;
						continue;
					case 9:
						num6++;
						num = 1084631018;
						continue;
					case 16:
						num7 = MathTools.Min(0, MathTools.Min(a, MathTools.Min(a3, b)));
						num = 1084631022;
						continue;
					case 5:
						num = 1084631017;
						continue;
					case 7:
					{
						num10 = MathTools.Min(0, MathTools.Min(a2, MathTools.Min(a4, b2)));
						int num15 = MathTools.Max(0, MathTools.Max(a, MathTools.Max(a3, b)));
						int num16 = MathTools.Max(0, MathTools.Max(a2, MathTools.Max(a4, b2)));
						num12 = num15 - num7 + 1;
						num14 = num16 - num10 + 1;
						array = new Color[num12 * num14];
						pixels = texture.GetPixels();
						num9 = 0;
						num = 1084631020;
						continue;
					}
					case 6:
						num4 = num9 * num12 + num6;
						num = 1084631009;
						continue;
					case 11:
						b = (int)((float)width * num8);
						b2 = (int)((float)width * num11);
						num = 1084631033;
						continue;
					case 14:
						a3 = (int)((float)width * num8 - (float)height * num11);
						a4 = (int)((float)height * num8 + (float)width * num11);
						num = 1084631010;
						continue;
					case 0:
						if (num9 >= num14)
						{
							texture2D = new Texture2D(num12, num14);
							texture2D.SetPixels(array);
							num = 1084631021;
							continue;
						}
						goto case 2;
					case 13:
						if (num2 >= 0 && num2 < width && num3 >= 0 && num3 < height)
						{
							array[num4] = pixels[num5];
							num = 1084631008;
							continue;
						}
						goto case 10;
					default:
						texture2D.Apply();
						texture2D.hideFlags = HideFlags.DontSave;
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
				goto IL_0003;
			}
			GUIContent[] array = new GUIContent[items.Length];
			int num = 0;
			int num2 = 1264563517;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num2 ^ 0x4B5FB53C)
				{
				case 3:
					break;
				case 4:
					return null;
				case 0:
					array[num] = new GUIContent(items[num]);
					num++;
					num2 = 1264563518;
					continue;
				case 1:
					num2 = 1264563518;
					continue;
				default:
					if (num >= items.Length)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = 1264563512;
			goto IL_0008;
		}

		public static GUIContent[] ToGUIContentArray(IList<string> items)
		{
			if (items == null)
			{
				return null;
			}
			GUIContent[] array = new GUIContent[items.Count];
			int num = 0;
			while (num < items.Count)
			{
				while (true)
				{
					array[num] = new GUIContent(items[num]);
					num++;
					int num2 = 1885479918;
					while (true)
					{
						switch (num2 ^ 0x706223EE)
						{
						case 2:
							num2 = 1885479919;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0033;
						}
						break;
					}
					continue;
					end_IL_0033:
					break;
				}
			}
			return array;
		}
	}
}
