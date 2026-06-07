using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using SettingScripts;
using SimulationScripts;
using UnityEngine;

namespace ManagementScripts
{
	public class ProceduralSpriteManager : MonoBehaviour
	{
		public enum SizeTypes
		{
			PartSizes = 0,
			EggSizes = 1,
			PelletSizes = 2
		}

		public static ProceduralSpriteManager Instance;

		public const string ProceduralFolderPath = "ProceduralSprites/";

		public const string BibitesPath = "Bibites/";

		public const string ObjectsPath = "Objects/";

		public const string CustomPath = "Mods/";

		public float loadProgress;

		public bool done;

		private List<Sprite> Eggs = new List<Sprite>();

		private List<Sprite> Plants = new List<Sprite>();

		private List<Sprite> Meats = new List<Sprite>();

		public Sprite nonePellet;

		private List<List<List<Sprite>>> Mouths = new List<List<List<Sprite>>>();

		private List<List<List<Sprite>>> Bodies = new List<List<List<Sprite>>>();

		private List<List<List<Sprite>>> Eyes = new List<List<List<Sprite>>>();

		private List<List<List<Sprite>>> Arms = new List<List<List<Sprite>>>();

		private List<List<List<Sprite>>> Exoskeletons = new List<List<List<Sprite>>>();

		private List<SizeFormat> eggSizes = new List<SizeFormat>();

		private List<SizeFormat> pelletSizes = new List<SizeFormat>();

		private List<SizeFormat> partSizes = new List<SizeFormat>();

		private List<PartInfo> partInfos = new List<PartInfo>();

		private Vector2 centerPivot = new Vector2(0.5f, 0.5f);

		private Vector2 bodyPivot = new Vector2(1f, 0.5f);

		private Vector2 mouthPivot = new Vector2(0f, 0.5f);

		private Vector2 eyesPivot = new Vector2(0f, 0.5f);

		private Vector2 armsPivot = new Vector2(1f, 0f);

		private Vector2 exoskeletonPivot = new Vector2(1f, 0.5f);

		private Texture2D tempTexture2D;

		private PartInfo partInfo;

		private int mouthWidth;

		private static readonly int FromHue = Shader.PropertyToID("_FromHue");

		private static readonly int VminAtS0 = Shader.PropertyToID("_VminAtS0");

		private static readonly int VmaxAtS0 = Shader.PropertyToID("_VmaxAtS0");

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
			if (!Directory.Exists(Application.dataPath + "/Mods/"))
			{
				Directory.CreateDirectory(Application.dataPath + "/Mods/");
			}
		}

		public void StartLoadingSprites()
		{
			if (!done)
			{
				StartCoroutine(LoadSprites(firstRun: true));
			}
		}

		private IEnumerator LoadSprites(bool firstRun)
		{
			WaitForSecondsRealtime delay = new WaitForSecondsRealtime(0.05f);
			string path = GetModFolderPath();
			Eggs.Clear();
			Plants.Clear();
			Meats.Clear();
			Bodies.Clear();
			Mouths.Clear();
			Arms.Clear();
			Eyes.Clear();
			Exoskeletons.Clear();
			bool mod = true;
			if (path == "" || !firstRun)
			{
				mod = false;
				path = "ProceduralSprites/";
			}
			LoadParametersCSV(path + "parameters", mod);
			if (!LoadSizesCSV(path + "Objects/egg_sizes", eggSizes, mod) && firstRun)
			{
				if (mod)
				{
					PopupManager.DisplayError("Procedural Sprites", "There was a problem reading egg_sizes.csv from a mod, the default sprites will be used instead");
				}
				StartCoroutine(LoadSprites(firstRun: false));
				yield break;
			}
			loadProgress += 0.05f;
			yield return null;
			for (int i = 0; i < eggSizes.Count; i++)
			{
				float ppu = (float)eggSizes[i].pixelWidth / 11f;
				Sprite sprite = TryLoadSprite(path + "Objects/Sprites/", eggSizes[i].name + "_egg", centerPivot, ppu, mod);
				if (sprite == null && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + eggSizes[i].name + "_egg.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				Eggs.Add(sprite);
			}
			if (!LoadSizesCSV(path + "Objects/pellet_sizes", pelletSizes, mod) && firstRun)
			{
				if (mod)
				{
					PopupManager.DisplayError("Procedural Sprites", "There was a problem reading pellet_sizes.csv from a mod, the default sprites will be used instead");
				}
				StartCoroutine(LoadSprites(firstRun: false));
				yield break;
			}
			loadProgress += 0.05f;
			yield return null;
			for (int j = 0; j < pelletSizes.Count; j++)
			{
				float ppu2 = (float)pelletSizes[j].pixelWidth / 5f;
				Sprite sprite2 = TryLoadSprite(path + "Objects/Sprites/", pelletSizes[j].name + "_plant", centerPivot, ppu2, mod);
				if (sprite2 == null && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + pelletSizes[j].name + "_plant.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				Plants.Add(sprite2);
				sprite2 = TryLoadSprite(path + "Objects/Sprites/", pelletSizes[j].name + "_meat", centerPivot, ppu2, mod);
				if (sprite2 == null && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + pelletSizes[j].name + "_meat.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				Meats.Add(sprite2);
			}
			path += "Bibites/";
			if (!LoadSizesCSV(path + "sizes", partSizes, mod) && firstRun)
			{
				if (mod)
				{
					PopupManager.DisplayError("Procedural Sprites", "There was a problem reading sizes.csv from a mod, the default sprites will be used instead");
				}
				StartCoroutine(LoadSprites(firstRun: false));
				yield break;
			}
			loadProgress += 0.05f;
			yield return null;
			if (!LoadPartsCSV(path, mod) && firstRun)
			{
				if (mod)
				{
					PopupManager.DisplayError("Procedural Sprites", "There was a problem reading parts.csv from a mod, the default sprites will be used instead");
				}
				StartCoroutine(LoadSprites(firstRun: false));
				yield break;
			}
			loadProgress += 0.05f;
			yield return delay;
			path += "Parts/";
			for (int k = 0; k < partSizes.Count; k++)
			{
				float ppu3 = (float)partSizes[k].pixelWidth / 9f;
				Mouths.Add(new List<List<Sprite>>());
				if (!LoadPartInfoAndTexture(path, partSizes[k].name + "_mouth", mod) && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + partSizes[k].name + "_mouth.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				LoadAndSliceSpriteSheet(Mouths[k], partSizes[k].name + "_mouth", mouthPivot, ppu3);
				mouthWidth = partInfo.width;
				loadProgress += 0.8f / (float)partSizes.Count / 5f;
				yield return null;
				Bodies.Add(new List<List<Sprite>>());
				if (!LoadPartInfoAndTexture(path, partSizes[k].name + "_body", mod) && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + partSizes[k].name + "_body.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				LoadAndSliceSpriteSheet(Bodies[k], partSizes[k].name + "_body", bodyPivot, ppu3);
				loadProgress += 0.8f / (float)partSizes.Count / 5f;
				yield return null;
				Eyes.Add(new List<List<Sprite>>());
				if (!LoadPartInfoAndTexture(path, partSizes[k].name + "_eyes", mod) && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + partSizes[k].name + "_eyes.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				eyesPivot = new Vector2(1f - (float)mouthWidth / (float)partInfo.width, 0.5f);
				LoadAndSliceSpriteSheet(Eyes[k], partSizes[k].name + "_eyes", eyesPivot, ppu3);
				loadProgress += 0.8f / (float)partSizes.Count / 5f;
				yield return null;
				Arms.Add(new List<List<Sprite>>());
				if (!LoadPartInfoAndTexture(path, partSizes[k].name + "_arms", mod) && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + partSizes[k].name + "_arms.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				LoadAndSliceSpriteSheet(Arms[k], partSizes[k].name + "_arms", armsPivot, ppu3);
				loadProgress += 0.8f / (float)partSizes.Count / 5f;
				yield return null;
				Exoskeletons.Add(new List<List<Sprite>>());
				if (!LoadPartInfoAndTexture(path, partSizes[k].name + "_exoskeleton", mod) && firstRun)
				{
					if (mod)
					{
						PopupManager.DisplayError("Procedural Sprites", "There was a problem reading " + partSizes[k].name + "_exoskeleton.png from a mod, the default sprites will be used instead");
					}
					StartCoroutine(LoadSprites(firstRun: false));
					yield break;
				}
				exoskeletonPivot = new Vector2(1f - (float)mouthWidth / (float)partInfo.width, 0.5f);
				LoadAndSliceSpriteSheet(Exoskeletons[k], partSizes[k].name + "_exoskeleton", exoskeletonPivot, ppu3);
				loadProgress += 0.8f / (float)partSizes.Count / 5f;
				yield return delay;
			}
			loadProgress = 1f;
			done = true;
		}

		private string GetModFolderPath()
		{
			string[] array = (from path in Directory.GetDirectories(Application.dataPath + "/Mods/")
				where Directory.Exists(path + "/ProceduralSprites/")
				select path).ToArray();
			if (array.Length == 0)
			{
				return "";
			}
			if (array.Length > 1)
			{
				PopupManager.DisplayDialog("Warning: Procedural Sprites", "Multiple alternative folders have been found. The sprites contained in the folder\"" + array[0] + "\" have been used.");
			}
			return array[0] + "/ProceduralSprites/";
		}

		private void LoadParametersCSV(string path, bool mod = false)
		{
			Shader.SetGlobalFloat(FromHue, 0.55f);
			Shader.SetGlobalFloat(VminAtS0, 0f);
			Shader.SetGlobalFloat(VmaxAtS0, 1f);
			string text;
			if (!mod)
			{
				TextAsset textAsset = Resources.Load<TextAsset>(path);
				if (textAsset == null)
				{
					return;
				}
				text = textAsset.text;
			}
			else
			{
				if (!File.Exists(path + ".csv"))
				{
					return;
				}
				text = File.ReadAllText(path + ".csv");
			}
			List<string> list = text.Replace("\r", "").Split("\n"[0]).ToList();
			for (int i = 1; i < list.Count; i++)
			{
				try
				{
					string[] array = list[i].Split(";"[0]);
					if (!string.IsNullOrEmpty(array[0]) && !string.IsNullOrEmpty(array[1]) && float.TryParse(array[1].Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
					{
						switch (array[0])
						{
						case "InitialHue":
							Shader.SetGlobalFloat(FromHue, result);
							break;
						case "VminAtS0":
							Shader.SetGlobalFloat(VminAtS0, result);
							break;
						case "VmaxAtS0":
							Shader.SetGlobalFloat(VmaxAtS0, result);
							break;
						}
					}
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
					PopupManager.DisplayError("Resource Loader", "There was an error reading parameters.csv", Application.Quit);
					throw;
				}
			}
		}

		private bool LoadSizesCSV(string path, List<SizeFormat> sizes, bool mod = false)
		{
			sizes.Clear();
			string text;
			if (!mod)
			{
				TextAsset textAsset = Resources.Load<TextAsset>(path);
				if (textAsset == null)
				{
					return false;
				}
				text = textAsset.text;
			}
			else
			{
				if (!File.Exists(path + ".csv"))
				{
					return false;
				}
				text = File.ReadAllText(path + ".csv");
			}
			string[] array = text.Replace("\r", "").Split("\n"[0]);
			for (int i = 1; i < array.Length; i++)
			{
				try
				{
					string[] array2 = array[i].Split(";"[0]);
					if (!string.IsNullOrEmpty(array2[0]))
					{
						sizes.Add(new SizeFormat
						{
							name = array2[0],
							pixelWidth = int.Parse(array2[1], CultureInfo.InvariantCulture)
						});
					}
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
					PopupManager.DisplayError("Resource Loader", "There was an error reading sizes.csv", Application.Quit);
					throw;
				}
			}
			return true;
		}

		private bool LoadPartsCSV(string path, bool mod = false)
		{
			partInfos.Clear();
			string text;
			if (!mod)
			{
				TextAsset textAsset = Resources.Load<TextAsset>(path + "parts");
				if (textAsset == null)
				{
					return false;
				}
				text = textAsset.text;
			}
			else
			{
				if (!File.Exists(path + "parts.csv"))
				{
					return false;
				}
				text = File.ReadAllText(path + "parts.csv");
			}
			string[] array = text.Replace("\r", "").Split("\n"[0]);
			for (int i = 1; i < array.Length; i++)
			{
				try
				{
					string[] array2 = array[i].Split(";"[0]);
					if (!string.IsNullOrEmpty(array2[0]))
					{
						partInfos.Add(new PartInfo
						{
							name = array2[0],
							nRows = int.Parse(array2[1], CultureInfo.InvariantCulture),
							nColumns = int.Parse(array2[2], CultureInfo.InvariantCulture)
						});
					}
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
					PopupManager.DisplayError("Resource Loader", "There was an error reading parts.csv", Application.Quit);
					throw;
				}
			}
			return true;
		}

		private bool LoadAndSliceSpriteSheet(List<List<Sprite>> list, string spriteSheetName, Vector2 pivot, float ppu)
		{
			for (int i = 0; i < partInfo.nColumns; i++)
			{
				list.Add(new List<Sprite>());
				for (int j = 0; j < partInfo.nRows; j++)
				{
					list[i].Add(Sprite.Create(tempTexture2D, new Rect(partInfo.width * i, partInfo.height * j, partInfo.width, partInfo.height), pivot, ppu, 0u, SpriteMeshType.FullRect, Vector4.zero, generateFallbackPhysicsShape: false));
					list[i][j].name = spriteSheetName + "_" + i + j;
				}
			}
			return true;
		}

		private bool LoadPartInfoAndTexture(string path, string partName, bool mod = false)
		{
			partInfo = TryFindPartInfo(partName);
			tempTexture2D = TryLoadTexture2D(path, partInfo.name, mod);
			if (tempTexture2D == null)
			{
				return false;
			}
			tempTexture2D.filterMode = FilterMode.Point;
			partInfo.width = tempTexture2D.width / partInfo.nColumns;
			partInfo.height = tempTexture2D.height / partInfo.nRows;
			return true;
		}

		private static Texture2D TryLoadTexture2D(string path, string filename, bool mod = false)
		{
			if (mod)
			{
				if (!File.Exists(path + filename + ".png"))
				{
					return null;
				}
				byte[] data = File.ReadAllBytes(path + filename + ".png");
				Texture2D texture2D = new Texture2D(2, 2);
				if (texture2D.LoadImage(data))
				{
					return texture2D;
				}
				return null;
			}
			return Resources.Load<Texture2D>(path + filename);
		}

		private static Sprite TryLoadSprite(string path, string filename, Vector2 pivot, float ppu, bool mod = false)
		{
			Texture2D texture2D = TryLoadTexture2D(path, filename, mod);
			if (texture2D == null)
			{
				return null;
			}
			texture2D.filterMode = FilterMode.Point;
			return Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), pivot, ppu, 0u, SpriteMeshType.FullRect, Vector4.zero, generateFallbackPhysicsShape: false);
		}

		private PartInfo TryFindPartInfo(string partName)
		{
			PartInfo result = partInfos.SingleOrDefault((PartInfo p) => p.name == partName);
			if (result.name != partName)
			{
				PopupManager.DisplayError("Resource Loader", "Couldn't find parts info for " + partName + " in parts.csv", Application.Quit);
			}
			return result;
		}

		public Sprite RequestBodySprite(int sizeIndex, int inflateIndex)
		{
			return Bodies[sizeIndex][0][inflateIndex];
		}

		public Sprite RequestMouthSprite(int sizeIndex, float dietGene, float strengthGene)
		{
			int index = FindRepartitionIndex(dietGene, BibiteEditorSettings.diet.minValue, BibiteEditorSettings.diet.maxValue, Mouths[sizeIndex].Count);
			int index2 = FindRepartitionIndex(strengthGene, 0f, 0.6f, Mouths[sizeIndex][index].Count);
			return Mouths[sizeIndex][index][index2];
		}

		public Sprite RequestEyeSprite(int sizeIndex, float radiusGene, float angleGene)
		{
			int index = FindRepartitionIndex(angleGene, BibiteEditorSettings.viewAngle.minValue, BibiteEditorSettings.viewAngle.maxValue, Eyes[sizeIndex].Count);
			int index2 = FindRepartitionIndex(radiusGene, BibiteEditorSettings.viewRadius.minValue, BibiteEditorSettings.viewRadius.maxValue, Eyes[sizeIndex][index].Count);
			return Eyes[sizeIndex][index][index2];
		}

		public Sprite RequestArmSprite(int sizeIndex, float speedGene)
		{
			int index = FindRepartitionIndex(speedGene, BibiteEditorSettings.speedRatio.minValue, BibiteEditorSettings.speedRatio.maxValue, Arms[sizeIndex].Count);
			return Arms[sizeIndex][index][0];
		}

		public Sprite RequestExoskeletonSprite(int sizeIndex, int inflateIndex, float defenceProportion)
		{
			int index = FindRepartitionIndex(defenceProportion, 0f, 0.3f, Exoskeletons[sizeIndex].Count);
			return Exoskeletons[sizeIndex][index][inflateIndex];
		}

		public Sprite RequestEggSprite(int sizeIndex)
		{
			return Eggs[sizeIndex];
		}

		public Sprite RequestPelletSpriteOfMaterial(MatterMaterial material, int sizeIndex)
		{
			if (material == MatterMaterialManager.Plant)
			{
				return RequestPlantSprite(sizeIndex);
			}
			if (material == MatterMaterialManager.Meat)
			{
				return RequestMeatSprite(sizeIndex);
			}
			return nonePellet;
		}

		public Sprite RequestPlantSprite(int sizeIndex)
		{
			return Plants[sizeIndex];
		}

		public Sprite RequestMeatSprite(int sizeIndex)
		{
			return Meats[sizeIndex];
		}

		public int ClosestSizeIndex(float size, SizeTypes sizeTypes = SizeTypes.PartSizes)
		{
			int result = 0;
			float num = float.MaxValue;
			List<SizeFormat> list = sizeTypes switch
			{
				SizeTypes.PartSizes => partSizes, 
				SizeTypes.EggSizes => eggSizes, 
				SizeTypes.PelletSizes => pelletSizes, 
				_ => throw new ArgumentOutOfRangeException("sizeTypes", sizeTypes, null), 
			};
			for (int i = 0; i < list.Count; i++)
			{
				float num2 = Mathf.Abs(size - (float)list[i].pixelWidth / (float)list[0].pixelWidth);
				if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public Vector2 ClosestSizeBounds(float size, SizeTypes sizeTypes = SizeTypes.PartSizes)
		{
			float x = float.NegativeInfinity;
			float y = float.PositiveInfinity;
			List<SizeFormat> list = sizeTypes switch
			{
				SizeTypes.PartSizes => partSizes, 
				SizeTypes.EggSizes => eggSizes, 
				SizeTypes.PelletSizes => pelletSizes, 
				_ => throw new ArgumentOutOfRangeException("sizeTypes", sizeTypes, null), 
			};
			int pixelWidth = list[0].pixelWidth;
			list = list.OrderBy((SizeFormat s) => s.pixelWidth).ToList();
			int num = 0;
			float num2 = float.MaxValue;
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				float num4 = Mathf.Abs(size - (float)list[num3].pixelWidth / (float)pixelWidth);
				if (num4 < num2)
				{
					num = num3;
					num2 = num4;
				}
			}
			if (num > 0 && num < list.Count + 1)
			{
				x = (float)list[num - 1].pixelWidth / (float)pixelWidth;
			}
			if (num > 0 && num < list.Count - 1)
			{
				y = (float)list[num + 1].pixelWidth / (float)pixelWidth;
			}
			return new Vector2(x, y);
		}

		public float SizeRatioFromSizeIndex(int i)
		{
			return (float)partSizes[i].pixelWidth / (float)partSizes[0].pixelWidth;
		}

		public int ClosestInflateIndex(int sizeIndex, float inflateFactor)
		{
			int count = Bodies[sizeIndex][0].Count;
			return FindRepartitionIndex(inflateFactor, 0f, 1f, count);
		}

		private int FindRepartitionIndex(float v, float min, float max, int n)
		{
			return Math.Max(Math.Min(Mathf.FloorToInt((float)n * (v - min) / (max - min)), n - 1), 0);
		}
	}
}
