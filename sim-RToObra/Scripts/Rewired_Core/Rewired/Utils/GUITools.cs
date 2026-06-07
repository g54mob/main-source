using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	public static class GUITools
	{
		public static class Solid
		{
			private static bool OFNyZEIVJrhoMaxnRFQAqeieoYF = false;

			private static Texture2D AquvbxMVzLMbnOGEGNTJvOWQOqj;

			private static Color ClEPHjZzuGOSYyPyzySXIgkboty;

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
						int num = -916418367;
						while (true)
						{
							switch (num ^ -916418368)
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
							color.g = value;
							Solid.color = color;
							num = -916418366;
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
					while (true)
					{
						int num = 1787412090;
						while (true)
						{
							switch (num ^ 0x6A89BE78)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								Solid.color = color;
								return;
							}
							break;
							IL_0024:
							color.b = value;
							num = 1787412089;
						}
					}
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
				if (AquvbxMVzLMbnOGEGNTJvOWQOqj == null)
				{
					AquvbxMVzLMbnOGEGNTJvOWQOqj = new Texture2D(1, 1);
					AquvbxMVzLMbnOGEGNTJvOWQOqj.SetPixel(0, 0, Color.white);
					AquvbxMVzLMbnOGEGNTJvOWQOqj.Apply();
					AquvbxMVzLMbnOGEGNTJvOWQOqj.hideFlags = HideFlags.DontSave;
				}
				GUI.DrawTexture(rect, AquvbxMVzLMbnOGEGNTJvOWQOqj, ScaleMode.StretchToFill);
			}

			public static void Draw(Rect rect, Color color)
			{
				if (OFNyZEIVJrhoMaxnRFQAqeieoYF)
				{
					while (true)
					{
						switch (-1248001193 ^ -1248001195)
						{
						case 0:
							continue;
						case 2:
							Solid.color = color;
							Draw(rect);
							return;
						}
						break;
					}
				}
				BeginDrawSet();
				Solid.color = color;
				Draw(rect);
				EndDrawSet();
			}

			public static void DrawRotated(Rect rect, float rotation)
			{
				bool flag = ((rotation != 0f) ? true : false);
				Matrix4x4 matrix = default(Matrix4x4);
				while (true)
				{
					int num = 831078028;
					while (true)
					{
						switch (num ^ 0x31893E8E)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							matrix = GUI.matrix;
							if (flag)
							{
								GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
								num = 831078031;
								continue;
							}
							goto case 1;
						case 1:
							Draw(rect);
							if (flag)
							{
								GUI.matrix = matrix;
								num = 831078029;
								continue;
							}
							return;
						case 3:
							return;
						}
						break;
					}
				}
			}

			public static void DrawRotated(Rect rect, Color color, float rotation)
			{
				bool flag = ((rotation != 0f) ? true : false);
				Matrix4x4 matrix = GUI.matrix;
				if (flag)
				{
					GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
					goto IL_0029;
				}
				goto IL_004b;
				IL_002e:
				int num;
				while (true)
				{
					switch (num ^ -946460057)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						goto IL_004b;
					case 1:
						GUI.matrix = matrix;
						num = -946460059;
						continue;
					case 2:
						return;
					}
					break;
				}
				goto IL_0029;
				IL_0029:
				num = -946460060;
				goto IL_002e;
				IL_004b:
				Draw(rect, color);
				int num2;
				if (flag)
				{
					num = -946460058;
					num2 = num;
				}
				else
				{
					num = -946460059;
					num2 = num;
				}
				goto IL_002e;
			}

			public static Texture2D DrawToTexture(Rect rect)
			{
				Texture2D texture2D = new Texture2D(1, 1);
				while (true)
				{
					int num = -678201239;
					while (true)
					{
						switch (num ^ -678201240)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						default:
							texture2D.Resize((int)rect.width, (int)rect.height);
							texture2D.Apply();
							texture2D.hideFlags = HideFlags.DontSave;
							return texture2D;
						}
						break;
						IL_0026:
						texture2D.SetPixel(0, 0, Color.white);
						num = -678201238;
					}
				}
			}

			public static void BeginDrawSet()
			{
				OFNyZEIVJrhoMaxnRFQAqeieoYF = true;
				ClEPHjZzuGOSYyPyzySXIgkboty = GUI.color;
			}

			public static void EndDrawSet()
			{
				OFNyZEIVJrhoMaxnRFQAqeieoYF = false;
				GUI.color = ClEPHjZzuGOSYyPyzySXIgkboty;
			}

			public static void DrawBox(Rect rect, Color color, float lineWidth = 1f)
			{
				if (OFNyZEIVJrhoMaxnRFQAqeieoYF)
				{
					Solid.color = color;
					goto IL_000d;
				}
				goto IL_0055;
				IL_0055:
				BeginDrawSet();
				Solid.color = color;
				int num = 1948257404;
				goto IL_0012;
				IL_000d:
				num = 1948257401;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x74200C78)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						DrawBox(rect, lineWidth);
						return;
					case 4:
						DrawBox(rect, lineWidth);
						EndDrawSet();
						num = 1948257403;
						continue;
					case 0:
						goto IL_0055;
					case 3:
						return;
					}
					break;
				}
				goto IL_000d;
			}

			public static void DrawBox(Rect rect, float lineWidth = 1f)
			{
				Draw(new Rect(rect.x, rect.y, rect.width, lineWidth));
				while (true)
				{
					int num = -1342462850;
					while (true)
					{
						switch (num ^ -1342462852)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0041;
						case 1:
							return;
						}
						break;
						IL_0041:
						Draw(new Rect(rect.x, rect.y + rect.height - lineWidth, rect.width, lineWidth));
						Draw(new Rect(rect.x, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
						Draw(new Rect(rect.x + rect.width - lineWidth, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
						num = -1342462851;
					}
				}
			}

			public static void DrawBoxRotated(Rect rect, float rotation, float lineWidth = 1f)
			{
				bool flag = ((rotation != 0f) ? true : false);
				Matrix4x4 matrix = default(Matrix4x4);
				while (true)
				{
					int num = 1187069402;
					while (true)
					{
						switch (num ^ 0x46C13DDE)
						{
						case 2:
							break;
						default:
							return;
						case 4:
						{
							matrix = GUI.matrix;
							int num2;
							if (!flag)
							{
								num = 1187069406;
								num2 = num;
							}
							else
							{
								num = 1187069405;
								num2 = num;
							}
							continue;
						}
						case 0:
							Draw(new Rect(rect.x, rect.y, rect.width, lineWidth));
							Draw(new Rect(rect.x, rect.y + rect.height - lineWidth, rect.width, lineWidth));
							Draw(new Rect(rect.x, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
							Draw(new Rect(rect.x + rect.width - lineWidth, rect.y + lineWidth, lineWidth, rect.height - lineWidth * 2f));
							if (flag)
							{
								GUI.matrix = matrix;
								num = 1187069407;
								continue;
							}
							return;
						case 3:
							GUIUtility.RotateAroundPivot(360f - rotation, rect.center);
							num = 1187069406;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		internal class RmEoncmTGOtTEKUWTKSyREPavkM
		{
			private ixRiFVCcgsLYQQoDdBuEXyCeSYK qPYCODJtPVmFFnZSgTriWryxTvJf;

			private Rect ujlpInwUahnMDFjsIpPeOIgGErA;

			private float lgmabJmdrGieJBCPkhkUKJoLNhZ;

			public RmEoncmTGOtTEKUWTKSyREPavkM()
			{
				qPYCODJtPVmFFnZSgTriWryxTvJf = new ixRiFVCcgsLYQQoDdBuEXyCeSYK();
			}

			public void KRVFzSAGLbzTcEyxGHvVNUMJQtBd(Rect P_0, float P_1)
			{
				if (!(P_0 != ujlpInwUahnMDFjsIpPeOIgGErA))
				{
					goto IL_000e;
				}
				goto IL_007f;
				IL_000e:
				int num = 4407697;
				goto IL_0013;
				IL_0013:
				Rect position = default(Rect);
				Texture2D texture2D = default(Texture2D);
				while (true)
				{
					switch (num ^ 0x434190)
					{
					case 3:
						break;
					case 1:
						goto IL_003f;
					case 0:
						if (P_1 == 0f)
						{
							position = P_0;
							num = 4407698;
							continue;
						}
						goto case 6;
					case 4:
						ZbXzdMkgYqzPsGJKKDqjdsILDJG(texture2D);
						aKvDMDvnukbQLjwWUEgfPoMriGHA(P_1);
						num = 4407696;
						continue;
					case 5:
						goto IL_007f;
					case 6:
					{
						Rect rect = nHGlqEEYZvOuvjuGPgdyWoGlxgp(P_0, P_1);
						rect.center = P_0.center;
						position = rect;
						num = 4407698;
						continue;
					}
					default:
						GUI.DrawTexture(position, qPYCODJtPVmFFnZSgTriWryxTvJf.texture, ScaleMode.StretchToFill);
						ujlpInwUahnMDFjsIpPeOIgGErA = P_0;
						lgmabJmdrGieJBCPkhkUKJoLNhZ = P_1;
						return;
					}
					break;
					IL_003f:
					int num2;
					if (lgmabJmdrGieJBCPkhkUKJoLNhZ == P_1)
					{
						num = 4407696;
						num2 = num;
					}
					else
					{
						num = 4407701;
						num2 = num;
					}
				}
				goto IL_000e;
				IL_007f:
				float num3 = P_0.width / P_0.height;
				texture2D = Solid.DrawToTexture(new Rect(0f, 0f, num3 * 100f, 100f));
				num = 4407700;
				goto IL_0013;
			}

			private void ZbXzdMkgYqzPsGJKKDqjdsILDJG(Texture2D P_0)
			{
				qPYCODJtPVmFFnZSgTriWryxTvJf.lUimyOVVoCmlMyRITFVQtnBhIFW(true);
				qPYCODJtPVmFFnZSgTriWryxTvJf.EEGiMNPSMElaPgKQdmScoWLedfb(P_0);
			}

			private void aKvDMDvnukbQLjwWUEgfPoMriGHA(float P_0)
			{
				qPYCODJtPVmFFnZSgTriWryxTvJf.aKvDMDvnukbQLjwWUEgfPoMriGHA(P_0);
			}

			private Rect nHGlqEEYZvOuvjuGPgdyWoGlxgp(Rect P_0, float P_1)
			{
				float value = (float)Math.PI / 180f * P_1;
				int num = (int)P_0.height;
				int num3 = default(int);
				int a3 = default(int);
				float num4 = default(float);
				int a2 = default(int);
				float num5 = default(float);
				int a4 = default(int);
				int a = default(int);
				while (true)
				{
					int num2 = -122223550;
					while (true)
					{
						switch (num2 ^ -122223549)
						{
						case 3:
							break;
						case 1:
							num3 = (int)P_0.width;
							num2 = -122223551;
							continue;
						case 4:
							a3 = (int)((float)num * num4);
							a2 = (int)((float)num3 * num4 - (float)num * num5);
							a4 = (int)((float)num * num4 + (float)num3 * num5);
							num2 = -122223549;
							continue;
						case 2:
							num4 = MathTools.Cos(value);
							num5 = MathTools.Sin(value);
							a = (int)((float)(-num) * num5);
							num2 = -122223545;
							continue;
						default:
						{
							int b = (int)((float)num3 * num4);
							int b2 = (int)((float)num3 * num5);
							int num6 = MathTools.Min(0, MathTools.Min(a, MathTools.Min(a2, b)));
							int num7 = MathTools.Min(0, MathTools.Min(a3, MathTools.Min(a4, b2)));
							int num8 = MathTools.Max(0, MathTools.Max(a, MathTools.Max(a2, b)));
							int num9 = MathTools.Max(0, MathTools.Max(a3, MathTools.Max(a4, b2)));
							int num10 = num8 - num6 + 1;
							int num11 = num9 - num7 + 1;
							return new Rect(0f, 0f, num10, num11);
						}
						}
						break;
					}
				}
			}

			public void lUimyOVVoCmlMyRITFVQtnBhIFW()
			{
				if (qPYCODJtPVmFFnZSgTriWryxTvJf == null)
				{
					return;
				}
				while (true)
				{
					int num = -1124274898;
					while (true)
					{
						switch (num ^ -1124274897)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0026;
						case 2:
							return;
						}
						break;
						IL_0026:
						qPYCODJtPVmFFnZSgTriWryxTvJf.lUimyOVVoCmlMyRITFVQtnBhIFW(true);
						num = -1124274899;
					}
				}
			}
		}

		internal class ixRiFVCcgsLYQQoDdBuEXyCeSYK
		{
			private Texture2D nOmxhagKelIxpWbhDzlfwJXIFDB;

			private Texture2D WhYiBEcuNeVUfjZGiKtsZAWZIJY;

			private bool XBqGpadnfKoerViMAzhFuUuvNyzt;

			public Texture2D texture
			{
				get
				{
					if (XBqGpadnfKoerViMAzhFuUuvNyzt)
					{
						return WhYiBEcuNeVUfjZGiKtsZAWZIJY;
					}
					return nOmxhagKelIxpWbhDzlfwJXIFDB;
				}
			}

			public Rect rect
			{
				get
				{
					if (XBqGpadnfKoerViMAzhFuUuvNyzt)
					{
						goto IL_0008;
					}
					int num;
					if (nOmxhagKelIxpWbhDzlfwJXIFDB != null)
					{
						num = 190011073;
						goto IL_000d;
					}
					goto IL_00a0;
					IL_002d:
					if (WhYiBEcuNeVUfjZGiKtsZAWZIJY != null)
					{
						return new Rect(0f, 0f, WhYiBEcuNeVUfjZGiKtsZAWZIJY.width, WhYiBEcuNeVUfjZGiKtsZAWZIJY.height);
					}
					goto IL_00a0;
					IL_00a0:
					Rect result = default(Rect);
					num = 190011074;
					goto IL_000d;
					IL_0008:
					num = 190011075;
					goto IL_000d;
					IL_000d:
					switch (num ^ 0xB5356C2)
					{
					case 2:
						break;
					case 1:
						goto IL_002d;
					case 3:
						return new Rect(0f, 0f, nOmxhagKelIxpWbhDzlfwJXIFDB.width, nOmxhagKelIxpWbhDzlfwJXIFDB.height);
					default:
						return result;
					}
					goto IL_0008;
				}
			}

			public ixRiFVCcgsLYQQoDdBuEXyCeSYK()
			{
			}

			public ixRiFVCcgsLYQQoDdBuEXyCeSYK(Texture2D texture)
			{
				EEGiMNPSMElaPgKQdmScoWLedfb(texture);
			}

			public void EEGiMNPSMElaPgKQdmScoWLedfb(Texture2D P_0)
			{
				lUimyOVVoCmlMyRITFVQtnBhIFW();
				nOmxhagKelIxpWbhDzlfwJXIFDB = P_0;
				WCMpeFnljldyhGLRcgteLGOlzGp();
				while (true)
				{
					int num = -1201715269;
					while (true)
					{
						switch (num ^ -1201715271)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0032;
						case 1:
							return;
						}
						break;
						IL_0032:
						XBqGpadnfKoerViMAzhFuUuvNyzt = false;
						num = -1201715272;
					}
				}
			}

			private void WCMpeFnljldyhGLRcgteLGOlzGp()
			{
				if (nOmxhagKelIxpWbhDzlfwJXIFDB == null)
				{
					throw new Exception("Texture cannot be null!");
				}
			}

			public void aKvDMDvnukbQLjwWUEgfPoMriGHA(float P_0)
			{
				WCMpeFnljldyhGLRcgteLGOlzGp();
				if (P_0 == 0f)
				{
					XBqGpadnfKoerViMAzhFuUuvNyzt = false;
					return;
				}
				while (true)
				{
					XBqGpadnfKoerViMAzhFuUuvNyzt = true;
					lUimyOVVoCmlMyRITFVQtnBhIFW();
					int num = -286273620;
					while (true)
					{
						switch (num ^ -286273618)
						{
						case 0:
							goto IL_0016;
						case 1:
							break;
						default:
							WhYiBEcuNeVUfjZGiKtsZAWZIJY = GetRotatedTexture(nOmxhagKelIxpWbhDzlfwJXIFDB, P_0, Color.clear);
							return;
						}
						break;
						IL_0016:
						num = -286273617;
					}
				}
			}

			public void lUimyOVVoCmlMyRITFVQtnBhIFW(bool P_0 = false)
			{
				if (WhYiBEcuNeVUfjZGiKtsZAWZIJY != null)
				{
					UnityEngine.Object.DestroyImmediate(WhYiBEcuNeVUfjZGiKtsZAWZIJY);
					goto IL_0019;
				}
				goto IL_003b;
				IL_003b:
				int num;
				int num2;
				if (P_0)
				{
					num = 1532404887;
					num2 = num;
				}
				else
				{
					num = 1532404886;
					num2 = num;
				}
				goto IL_001e;
				IL_0019:
				num = 1532404884;
				goto IL_001e;
				IL_001e:
				while (true)
				{
					switch (num ^ 0x5B56A497)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						goto IL_003b;
					case 0:
						if (nOmxhagKelIxpWbhDzlfwJXIFDB != null)
						{
							UnityEngine.Object.DestroyImmediate(nOmxhagKelIxpWbhDzlfwJXIFDB);
							num = 1532404886;
							continue;
						}
						return;
					case 1:
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
			int num5 = default(int);
			int num8 = default(int);
			int num7 = default(int);
			int num6 = default(int);
			int num3 = default(int);
			float num10 = default(float);
			int num4 = default(int);
			float num2 = default(float);
			int num11 = default(int);
			int num12 = default(int);
			int width = default(int);
			int a = default(int);
			int a2 = default(int);
			int b2 = default(int);
			int a3 = default(int);
			int a4 = default(int);
			int b = default(int);
			int num14 = default(int);
			int height = default(int);
			Color[] array = default(Color[]);
			Color[] pixels = default(Color[]);
			Texture2D texture2D = default(Texture2D);
			while (true)
			{
				int num = 937491885;
				while (true)
				{
					switch (num ^ 0x37E0FDA9)
					{
					case 6:
						break;
					case 0:
						num5 = 0;
						num = 937491882;
						continue;
					case 15:
					{
						num8 = num7 * num6 + num5;
						int num9 = (int)((float)(num5 + num3) * num10 + (float)(num7 + num4) * num2);
						num11 = (int)((float)(num7 + num4) * num10 - (float)(num5 + num3) * num2);
						num12 = num11 * width + num9;
						if (num9 >= 0 && num9 < width)
						{
							int num13;
							if (num11 < 0)
							{
								num = 937491884;
								num13 = num;
							}
							else
							{
								num = 937491880;
								num13 = num;
							}
							continue;
						}
						goto case 5;
					}
					case 8:
					{
						int num15 = MathTools.Max(0, MathTools.Max(a, MathTools.Max(a2, b2)));
						int num16 = MathTools.Max(0, MathTools.Max(a3, MathTools.Max(a4, b)));
						num6 = num15 - num3 + 1;
						num14 = num16 - num4 + 1;
						num = 937491872;
						continue;
					}
					case 1:
						if (num11 < height)
						{
							array[num8] = pixels[num12];
							num = 937491896;
							continue;
						}
						goto case 5;
					case 5:
						array[num8] = backgroundColor;
						num = 937491896;
						continue;
					case 2:
						a = (int)((float)(-height) * num2);
						a3 = (int)((float)height * num10);
						num = 937491877;
						continue;
					case 9:
						array = new Color[num6 * num14];
						pixels = texture.GetPixels();
						num = 937491876;
						continue;
					case 4:
						height = texture.height;
						num = 937491897;
						continue;
					case 16:
						width = texture.width;
						num10 = MathTools.Cos(value);
						num2 = MathTools.Sin(value);
						num = 937491883;
						continue;
					case 17:
						num5++;
						num = 937491882;
						continue;
					case 18:
						if (num7 >= num14)
						{
							texture2D = new Texture2D(num6, num14);
							num = 937491875;
							continue;
						}
						goto case 0;
					case 13:
						num7 = 0;
						num = 937491879;
						continue;
					case 14:
						num = 937491899;
						continue;
					case 12:
						a2 = (int)((float)width * num10 - (float)height * num2);
						a4 = (int)((float)height * num10 + (float)width * num2);
						b2 = (int)((float)width * num10);
						num = 937491874;
						continue;
					case 3:
						if (num5 >= num6)
						{
							num7++;
							num = 937491899;
							continue;
						}
						goto case 15;
					case 10:
						texture2D.SetPixels(array);
						texture2D.Apply();
						texture2D.hideFlags = HideFlags.DontSave;
						num = 937491886;
						continue;
					case 11:
						b = (int)((float)width * num2);
						num3 = MathTools.Min(0, MathTools.Min(a, MathTools.Min(a2, b2)));
						num4 = MathTools.Min(0, MathTools.Min(a3, MathTools.Min(a4, b)));
						num = 937491873;
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
			while (num < items.Length)
			{
				while (true)
				{
					array[num] = new GUIContent(items[num]);
					int num2 = -305756737;
					while (true)
					{
						switch (num2 ^ -305756739)
						{
						case 0:
							num2 = -305756740;
							continue;
						case 1:
							break;
						case 2:
							num++;
							num2 = -305756738;
							continue;
						default:
							goto end_IL_0034;
						}
						break;
					}
					continue;
					end_IL_0034:
					break;
				}
			}
			return array;
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
					int num2 = -806915959;
					while (true)
					{
						switch (num2 ^ -806915960)
						{
						case 0:
							num2 = -806915957;
							continue;
						case 3:
							break;
						case 1:
							num++;
							num2 = -806915958;
							continue;
						default:
							goto end_IL_0037;
						}
						break;
					}
					continue;
					end_IL_0037:
					break;
				}
			}
			return array;
		}
	}
}
