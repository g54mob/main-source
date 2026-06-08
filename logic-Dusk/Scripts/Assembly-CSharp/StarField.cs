using System.IO;
using UnityEngine;

public class StarField : MonoBehaviour
{
	public static StarField Instance;

	private static Texture2D dynamicCutoutWorkspaceTexture;

	private static bool hasGeneratedRevealBackground;

	public Material BaseMaterial;

	public Color GalaxyViewColor = Color.black;

	public Color StarSystemViewColor = Color.gray;

	public Color GalaxyBackgroundStarBaseColor = new Color(56f / 85f, 0f, 1f);

	public Color outpostColor = new Color(0.8980392f, 0.6901961f, 16f / 85f);

	public Color shipColor = new Color(6f / 85f, 0.8980392f, 0.75686276f);

	public Texture2D GalaxyViewTexture;

	public Texture2D StarSystemViewTexture;

	public Texture2D cutoutTexture;

	public Texture2D cutoutWorkspaceTexture;

	public Texture2D dynamicOutpostWorkspaceTexture;

	public Texture2D dynamicDerelictWorkspaceTexture;

	public Texture2D dynamicTradingPostWorkspaceTexture;

	public Texture2D dynamicOtherWorkspaceTexture;

	public Texture2D starDenseTexture;

	public float denseStarLevel = 0.5f;

	public Texture2D starMedTexture;

	public float medStarLevel = 0.3f;

	public Texture2D starThinTexture;

	public Texture2D giantStarTexture;

	public int maxGiantStarCount = 10;

	public int starSourceImageSize = 32;

	public float typeDensityVisibilityFactor = 0.5f;

	private Color[] cutoutColors;

	public static void ClearOnMapChange()
	{
		dynamicCutoutWorkspaceTexture = null;
		hasGeneratedRevealBackground = false;
	}

	public static void ClearOnReset()
	{
		dynamicCutoutWorkspaceTexture = null;
		hasGeneratedRevealBackground = false;
		string text = GameSaveFile.Get<string>("GALAXY_ID");
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		string path = Path.Combine(GameFileHelper.GetDataGalaxyLocation(), text);
		if (Directory.Exists(path))
		{
			string[] files = Directory.GetFiles(path, "_d*.png");
			if (files.Length > 0)
			{
				string[] array = files;
				foreach (string path2 in array)
				{
					File.Delete(path2);
				}
			}
		}
		GalaxySaveFile.ClearStarSystemPath();
	}

	private void Start()
	{
		Instance = this;
		Initialize();
	}

	private void OnDestroy()
	{
		GalaxyViewTexture = null;
		StarSystemViewTexture = null;
		cutoutTexture = null;
		cutoutWorkspaceTexture = null;
		dynamicOutpostWorkspaceTexture = null;
		dynamicDerelictWorkspaceTexture = null;
		dynamicTradingPostWorkspaceTexture = null;
		dynamicOtherWorkspaceTexture = null;
		starDenseTexture = null;
		starMedTexture = null;
		starThinTexture = null;
		giantStarTexture = null;
		cutoutColors = null;
		Instance = null;
	}

	public void Initialize()
	{
		if (GlobalSettings.GenerateGalaxyMapFromImage)
		{
			if (!hasGeneratedRevealBackground)
			{
				GenerateRevealTexture();
				hasGeneratedRevealBackground = true;
			}
			if (dynamicCutoutWorkspaceTexture == null)
			{
				dynamicCutoutWorkspaceTexture = new Texture2D(1024, 512, TextureFormat.ARGB32, false);
				ClearImage(ref dynamicCutoutWorkspaceTexture, Color.black);
				ClearImage(ref cutoutWorkspaceTexture, Color.black);
			}
			else
			{
				cutoutWorkspaceTexture.SetPixels(dynamicCutoutWorkspaceTexture.GetPixels());
				cutoutWorkspaceTexture.Apply();
			}
			if (cutoutTexture != null)
			{
				cutoutColors = cutoutTexture.GetPixels();
			}
		}
	}

	private Color[] ClearImage(ref Texture2D image, Color clearColor)
	{
		Color[] pixels = image.GetPixels();
		for (int i = 0; i < image.width; i++)
		{
			for (int j = 0; j < image.height; j++)
			{
				pixels[i + j * image.width] = clearColor;
			}
		}
		image.SetPixels(pixels);
		image.Apply();
		return pixels;
	}

	public void GalaxyView()
	{
		if (GalaxyViewTexture != null)
		{
			BaseMaterial.SetTexture("_MainTex", GalaxyViewTexture);
		}
		BaseMaterial.color = GalaxyViewColor;
	}

	public void StarSystemView()
	{
		if (StarSystemViewTexture != null)
		{
			BaseMaterial.SetTexture("_MainTex", StarSystemViewTexture);
		}
		BaseMaterial.color = StarSystemViewColor;
	}

	public void SetGalaxyViewTexture(Texture2D texture, Color color)
	{
		if (!(texture != null))
		{
			Debug.LogWarning("Provided GalaxyView texture was null - ignored");
		}
	}

	public void ResetGalaxyViewTexture()
	{
		GalaxyView();
	}

	public void GenerateRevealTexture()
	{
		string empty = string.Empty;
		empty = GameSaveFile.Get<string>("GALAXY_ID");
		if (string.IsNullOrEmpty(empty))
		{
			empty = GalaxyMapManager.Instance.densityMapName;
			if (dynamicOutpostWorkspaceTexture == null)
			{
				dynamicOutpostWorkspaceTexture = new Texture2D(1024, 512, TextureFormat.ARGB32, false);
			}
			if (dynamicDerelictWorkspaceTexture == null)
			{
				dynamicDerelictWorkspaceTexture = new Texture2D(1024, 512, TextureFormat.ARGB32, false);
			}
			if (dynamicTradingPostWorkspaceTexture == null)
			{
				dynamicTradingPostWorkspaceTexture = new Texture2D(1024, 512, TextureFormat.ARGB32, false);
			}
			if (dynamicOtherWorkspaceTexture == null)
			{
				dynamicOtherWorkspaceTexture = new Texture2D(1024, 512, TextureFormat.ARGB32, false);
			}
		}
		else if (Directory.Exists(Path.Combine(GameFileHelper.GetDataGalaxyLocation(), empty)))
		{
			string text = Path.Combine(GameFileHelper.GetDataGalaxyLocation(), empty);
			if (File.Exists(Path.Combine(text, "_dOutWork.png")) && File.Exists(Path.Combine(text, "_dDerWork.png")) && File.Exists(Path.Combine(text, "_dTPWork.png")) && File.Exists(Path.Combine(text, "_dGSWork.png")))
			{
				byte[] data = File.ReadAllBytes(Path.Combine(text, "_dOutWork.png"));
				dynamicOutpostWorkspaceTexture.LoadImage(data);
				data = File.ReadAllBytes(Path.Combine(text, "_dDerWork.png"));
				dynamicDerelictWorkspaceTexture.LoadImage(data);
				data = File.ReadAllBytes(Path.Combine(text, "_dTPWork.png"));
				dynamicTradingPostWorkspaceTexture.LoadImage(data);
				data = File.ReadAllBytes(Path.Combine(text, "_dGSWork.png"));
				dynamicOtherWorkspaceTexture.LoadImage(data);
				Debug.Log(string.Format("*** Loaded galaxy Data Images from user data: {0}", text));
				return;
			}
		}
		GameFileHelper.CreateDirectory(Path.Combine(GameFileHelper.GetDataGalaxyLocation(), empty));
		int width = GalaxyMapManager.depthMapSourceTexture.width;
		int height = GalaxyMapManager.depthMapSourceTexture.height;
		Color[] pixels = GalaxyMapManager.depthMapSourceTexture.GetPixels();
		Color[] array = null;
		Color[] array2 = null;
		if (GalaxyMapManager.typeMapSourceTexture != null)
		{
			array = GalaxyMapManager.typeMapSourceTexture.GetPixels();
		}
		if (GalaxyMapManager.typeDensityMapSourceTexture != null)
		{
			array2 = GalaxyMapManager.typeDensityMapSourceTexture.GetPixels();
		}
		Color[] pixels2 = starDenseTexture.GetPixels();
		Color[] pixels3 = starMedTexture.GetPixels();
		Color[] pixels4 = starThinTexture.GetPixels();
		Color[] pixels5 = giantStarTexture.GetPixels();
		Color black = Color.black;
		black.b = 0f;
		black.a = 0f;
		Color[] array3 = ClearImage(ref dynamicOutpostWorkspaceTexture, black);
		Color[] array4 = ClearImage(ref dynamicDerelictWorkspaceTexture, black);
		Color[] array5 = ClearImage(ref dynamicTradingPostWorkspaceTexture, black);
		Color[] array6 = ClearImage(ref dynamicOtherWorkspaceTexture, black);
		bool[] array7 = new bool[width * height];
		int num = 0;
		float num2 = 32f;
		float num3 = num2 / 2f;
		float num4 = num2 / 2f;
		float num5 = num3 / 1024f;
		float num6 = num4 / 512f;
		if (array != null)
		{
			foreach (StarSystemInfo starSystem in GlobalSettings.GameState.StarSystems)
			{
				for (int i = 0; i < 94; i++)
				{
					int num7 = Random.Range(0, 94);
					float x = Random.Range(-1f, 1f);
					float y = Random.Range(-1f, 1f);
					Vector2 vector = new Vector2(x, y);
					vector.Normalize();
					Vector2 vector2 = starSystem.TrueImageCoords + vector * num7;
					int num8 = Mathf.CeilToInt(vector2.x);
					int num9 = Mathf.CeilToInt(vector2.y);
					if (num8 <= 0 || num8 >= width || num9 <= 0 || num9 >= height || array7[num8 + num9 * width])
					{
						continue;
					}
					Color color = pixels[num8 + num9 * width];
					float r = color.r;
					if (!(r >= 0.01f))
					{
						continue;
					}
					int num10 = (int)(25f * r);
					for (int j = 0; j < num10; j++)
					{
						int max = 15 + (int)(75f * (1f - r));
						num7 = Random.Range(0, max);
						x = Random.Range(-1f, 1f);
						y = Random.Range(-1f, 1f);
						vector = new Vector2(x, y);
						vector.Normalize();
						Vector2 vector3 = vector2 + vector * num7;
						int num11 = Mathf.CeilToInt(vector3.x);
						int num12 = Mathf.CeilToInt(vector3.y);
						if (num11 <= 0 || num11 >= width || num12 <= 0 || num12 >= height || array7[num11 + num12 * width])
						{
							continue;
						}
						array7[num11 + num12 * width] = true;
						Color color2 = pixels[num11 + num12 * width];
						if (!(color2.r > 0.1f))
						{
							continue;
						}
						Color black2 = Color.black;
						black2.a = 0f;
						Color color3 = array[num11 + num12 * width];
						float num13 = color3.r + color3.g + color3.b;
						float num14 = 1f;
						if (array2 != null)
						{
							num14 = array2[num11 + num12 * width].r;
							num14 += typeDensityVisibilityFactor;
						}
						if (color3.r > 0f)
						{
							array5[num11 + num12 * width].r = (int)(byte)num5;
							array5[num11 + num12 * width].g = (int)(byte)num6;
							if (color2.r > denseStarLevel)
							{
								array5[num11 + num12 * width].b = 0f;
							}
							else if (color2.r > medStarLevel)
							{
								array5[num11 + num12 * width].b = 1f;
							}
							else
							{
								array5[num11 + num12 * width].b = 2f;
							}
							array3[num11 + num12 * width].a = (int)(byte)(color3.r / num13 * num14);
							int num15 = num11;
							int num16 = num12;
							int num17 = num15 - Mathf.CeilToInt(num3);
							int num18 = num15 + Mathf.CeilToInt(num3);
							int num19 = num16 - Mathf.CeilToInt(num4);
							int num20 = num16 + Mathf.CeilToInt(num4);
							for (int k = num17; k < num18; k++)
							{
								for (int l = num19; l < num20; l++)
								{
									int num21 = k - num15;
									int num22 = l - num16;
									int num23 = num11 + num21;
									int num24 = num12 + num22;
									if (num23 <= 0 || num23 >= width || num24 <= 0 || num24 >= height)
									{
										continue;
									}
									float num25 = (float)num21 / num2 + 0.5f;
									float num26 = (float)num22 / num2 + 0.5f;
									Color white = Color.white;
									white = ((color2.r > denseStarLevel) ? pixels2[k - num17 + (l - num19) * starSourceImageSize] : ((!(color2.r > medStarLevel)) ? pixels4[k - num17 + (l - num19) * starSourceImageSize] : pixels3[k - num17 + (l - num19) * starSourceImageSize]));
									if (white.r > 0f && array3[num23 + num24 * width].r < white.r)
									{
										array5[num23 + num24 * width].r = (int)(byte)num25;
										array5[num23 + num24 * width].g = (int)(byte)num26;
										if (color2.r > denseStarLevel)
										{
											array5[num23 + num24 * width].b = 0f;
										}
										else if (color2.r > medStarLevel)
										{
											array5[num23 + num24 * width].b = 1f;
										}
										else
										{
											array5[num23 + num24 * width].b = 2f;
										}
										array5[num23 + num24 * width].a = (int)(byte)(color3.r / num13 * num14);
									}
								}
							}
						}
						if (color3.g > 0f)
						{
							array3[num11 + num12 * width].r = (int)(byte)num5;
							array3[num11 + num12 * width].g = (int)(byte)num6;
							if (color2.r > denseStarLevel)
							{
								array3[num11 + num12 * width].b = 0f;
							}
							else if (color2.r > medStarLevel)
							{
								array3[num11 + num12 * width].b = 1f;
							}
							else
							{
								array3[num11 + num12 * width].b = 2f;
							}
							array3[num11 + num12 * width].a = (int)(byte)(color3.g / num13 * num14);
							int num27 = num11;
							int num28 = num12;
							int num29 = num27 - Mathf.CeilToInt(num3);
							int num30 = num27 + Mathf.CeilToInt(num3);
							int num31 = num28 - Mathf.CeilToInt(num4);
							int num32 = num28 + Mathf.CeilToInt(num4);
							for (int m = num29; m < num30; m++)
							{
								for (int n = num31; n < num32; n++)
								{
									int num33 = m - num27;
									int num34 = n - num28;
									int num35 = num11 + num33;
									int num36 = num12 + num34;
									if (num35 <= 0 || num35 >= width || num36 <= 0 || num36 >= height)
									{
										continue;
									}
									float num37 = (float)num33 / num2 + 0.5f;
									float num38 = (float)num34 / num2 + 0.5f;
									Color white2 = Color.white;
									white2 = ((color2.r > denseStarLevel) ? pixels2[m - num29 + (n - num31) * starSourceImageSize] : ((!(color2.r > medStarLevel)) ? pixels4[m - num29 + (n - num31) * starSourceImageSize] : pixels3[m - num29 + (n - num31) * starSourceImageSize]));
									if (white2.r > 0f && array3[num35 + num36 * width].r < white2.r)
									{
										array3[num35 + num36 * width].r = (int)(byte)num37;
										array3[num35 + num36 * width].g = (int)(byte)num38;
										if (color2.r > denseStarLevel)
										{
											array3[num35 + num36 * width].b = 0f;
										}
										else if (color2.r > medStarLevel)
										{
											array3[num35 + num36 * width].b = 1f;
										}
										else
										{
											array3[num35 + num36 * width].b = 2f;
										}
										array3[num35 + num36 * width].a = (int)(byte)(color3.g / num13 * num14);
									}
								}
							}
						}
						if (!(color3.b > 0f))
						{
							continue;
						}
						array4[num11 + num12 * width].r = (int)(byte)num5;
						array4[num11 + num12 * width].g = (int)(byte)num6;
						if (color2.r > denseStarLevel)
						{
							array4[num11 + num12 * width].b = 0f;
						}
						else if (color2.r > medStarLevel)
						{
							array4[num11 + num12 * width].b = 1f;
						}
						else
						{
							array4[num11 + num12 * width].b = 2f;
						}
						array4[num11 + num12 * width].a = (int)(byte)(color3.b / num13 * num14);
						int num39 = num11;
						int num40 = num12;
						int num41 = num39 - Mathf.CeilToInt(num3);
						int num42 = num39 + Mathf.CeilToInt((int)num3);
						int num43 = num40 - Mathf.CeilToInt(num4);
						int num44 = num40 + Mathf.CeilToInt(num4);
						for (int num45 = num41; num45 < num42; num45++)
						{
							for (int num46 = num43; num46 < num44; num46++)
							{
								int num47 = num45 - num39;
								int num48 = num46 - num40;
								int num49 = num11 + num47;
								int num50 = num12 + num48;
								if (num49 <= 0 || num49 >= width || num50 <= 0 || num50 >= height)
								{
									continue;
								}
								float num51 = (float)num47 / num2 + 0.5f;
								float num52 = (float)num48 / num2 + 0.5f;
								Color white3 = Color.white;
								white3 = ((color2.r > denseStarLevel) ? pixels2[num45 - num41 + (num46 - num43) * starSourceImageSize] : ((!(color2.r > medStarLevel)) ? pixels4[num45 - num41 + (num46 - num43) * starSourceImageSize] : pixels3[num45 - num41 + (num46 - num43) * starSourceImageSize]));
								if (white3.r > 0f && array4[num49 + num50 * width].r < white3.r)
								{
									array4[num49 + num50 * width].r = (int)(byte)num51;
									array4[num49 + num50 * width].g = (int)(byte)num52;
									if (color2.r > denseStarLevel)
									{
										array4[num49 + num50 * width].b = 0f;
									}
									else if (color2.r > medStarLevel)
									{
										array4[num49 + num50 * width].b = 1f;
									}
									else
									{
										array4[num49 + num50 * width].b = 2f;
									}
									array4[num49 + num50 * width].a = (int)(byte)(color3.b / num13 * num14);
								}
							}
						}
					}
				}
			}
		}
		for (int num53 = 0; num53 < 500; num53++)
		{
			int num54 = Random.Range(0, width);
			int num55 = Random.Range(0, height);
			Color color4 = pixels[num54 + num55 * width];
			float r2 = color4.r;
			if (!(r2 > 0.4f) || num >= maxGiantStarCount || Random.Range(0, 3) != 0)
			{
				continue;
			}
			array6[num54 + num55 * width].r = (int)(byte)num5;
			array6[num54 + num55 * width].g = (int)(byte)num6;
			array6[num54 + num55 * width].b = 0f;
			array6[num54 + num55 * width].a = 1f;
			int num56 = num54;
			int num57 = num55;
			int num58 = num56 - Mathf.CeilToInt(num3);
			int num59 = num56 + Mathf.CeilToInt(num3);
			int num60 = num57 - Mathf.CeilToInt(num4);
			int num61 = num57 + Mathf.CeilToInt(num4);
			for (int num62 = num58; num62 < num59; num62++)
			{
				for (int num63 = num60; num63 < num61; num63++)
				{
					int num64 = num62 - num56;
					int num65 = num63 - num57;
					int num66 = num54 + num64;
					int num67 = num55 + num65;
					if (num66 > 0 && num66 < width && num67 > 0 && num67 < height)
					{
						float num68 = (float)num64 / num2 + 0.5f;
						float num69 = (float)num65 / num2 + 0.5f;
						Color color5 = pixels5[num62 - num58 + (num63 - num60) * starSourceImageSize];
						if (array6[num66 + num67 * width].a < color5.a)
						{
							array6[num66 + num67 * width].r = (int)(byte)num68;
							array6[num66 + num67 * width].g = (int)(byte)num69;
							array6[num66 + num67 * width].b = 0f;
							array6[num66 + num67 * width].a = (int)(byte)color5.a;
						}
					}
				}
			}
			num++;
			if (num >= maxGiantStarCount)
			{
				break;
			}
		}
		dynamicOutpostWorkspaceTexture.SetPixels(array3);
		dynamicOutpostWorkspaceTexture.Apply();
		dynamicDerelictWorkspaceTexture.SetPixels(array4);
		dynamicDerelictWorkspaceTexture.Apply();
		dynamicTradingPostWorkspaceTexture.SetPixels(array5);
		dynamicTradingPostWorkspaceTexture.Apply();
		dynamicOtherWorkspaceTexture.SetPixels(array6);
		dynamicOtherWorkspaceTexture.Apply();
		string path = Path.Combine(GameFileHelper.GetDataGalaxyLocation(), empty);
		byte[] array8 = dynamicOutpostWorkspaceTexture.EncodeToPNG();
		FileStream fileStream = File.Create(Path.Combine(path, "_dOutWork.png"));
		fileStream.Write(array8, 0, array8.Length);
		fileStream.Close();
		array8 = dynamicDerelictWorkspaceTexture.EncodeToPNG();
		fileStream = File.Create(Path.Combine(path, "_dDerWork.png"));
		fileStream.Write(array8, 0, array8.Length);
		fileStream.Close();
		array8 = dynamicTradingPostWorkspaceTexture.EncodeToPNG();
		fileStream = File.Create(Path.Combine(path, "_dTPWork.png"));
		fileStream.Write(array8, 0, array8.Length);
		fileStream.Close();
		array8 = dynamicTradingPostWorkspaceTexture.EncodeToPNG();
		fileStream = File.Create(Path.Combine(path, "_dGSWork.png"));
		fileStream.Write(array8, 0, array8.Length);
		fileStream.Close();
	}

	public void RevealBackground(Vector2 point, bool longRangeScanner)
	{
		int width = cutoutWorkspaceTexture.width;
		int height = cutoutWorkspaceTexture.height;
		if (longRangeScanner)
		{
			point.x *= 0.99f;
			point.y *= 0.99f;
		}
		else
		{
			point.y *= 0.99f;
		}
		if (cutoutColors == null)
		{
			return;
		}
		Color[] pixels = cutoutWorkspaceTexture.GetPixels();
		int width2 = cutoutTexture.width;
		int height2 = cutoutTexture.height;
		float num = 1f;
		float num2 = 1f;
		if (longRangeScanner)
		{
			num = 26f / 99f;
			num2 = 26f / 105f;
		}
		else
		{
			num = 9f / 70f;
			num2 = 0.1125f;
		}
		for (int i = 0; i < width2; i++)
		{
			for (int j = 0; j < height2; j++)
			{
				Color color = cutoutColors[i + j * width2];
				if (color.a > 0f)
				{
					float x = point.x;
					float y = point.y;
					x += (float)i * num;
					y += (float)j * num2;
					x -= (float)(width2 / 2) * num;
					y -= (float)(height2 / 2) * num2;
					int num3 = Mathf.CeilToInt(x);
					int num4 = Mathf.CeilToInt(y);
					if (num3 > 0 && num3 < width && num4 > 0 && num4 < height)
					{
						float num5 = 1f - color.a;
						Color color2 = pixels[num3 + num4 * width];
						float a = ((!(num5 < color2.a)) ? color2.a : num5);
						color2.a = a;
						pixels[num3 + num4 * width] = color2;
					}
				}
			}
		}
		cutoutWorkspaceTexture.SetPixels(pixels);
		cutoutWorkspaceTexture.Apply();
		dynamicCutoutWorkspaceTexture.SetPixels(pixels);
		dynamicCutoutWorkspaceTexture.Apply();
	}

	public void RevealBackground()
	{
		Color black = Color.black;
		black.a = 0f;
		ClearImage(ref cutoutWorkspaceTexture, black);
	}
}
