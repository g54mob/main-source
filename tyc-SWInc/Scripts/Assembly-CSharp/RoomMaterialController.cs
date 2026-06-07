using System;
using System.Collections.Generic;
using System.IO;
using DevConsole;
using UnityEngine;

public class RoomMaterialController : MonoBehaviour
{
	[Serializable]
	public class WallMaterial
	{
		[Serializable]
		public struct ColorPreset
		{
			public Color Color1;

			public Color Color2;
		}

		[NonSerialized]
		public int ID;

		public string Name;

		public string Category;

		public Texture Base;

		public Texture Bump;

		public Texture Extra;

		public bool AddSkirting;

		public Room.FloorType SFXType;

		[NonSerialized]
		public bool FromSteam;

		public bool SecondaryColorEnabled = true;

		public Color ForcedSecondaryColor;

		public List<ColorPreset> ColorPresets = new List<ColorPreset>();

		[NonSerialized]
		public string _baseTexFile;

		[NonSerialized]
		public string _bumpTexFile;

		[NonSerialized]
		public string _extraTexFile;

		[NonSerialized]
		private bool _shouldLoad;

		[NonSerialized]
		private bool _isLoaded;

		[NonSerialized]
		private bool _isMipped;

		[NonSerialized]
		public Texture MippedBase;

		[NonSerialized]
		public Texture MippedBump;

		[NonSerialized]
		public Texture MippedExtra;

		[NonSerialized]
		public RoomMaterialPack Parent;

		public WallMaterial()
		{
		}

		public WallMaterial(string name, string category, bool skirting, Room.FloorType sfxType)
		{
			Name = name;
			Category = category;
			AddSkirting = skirting;
			SFXType = sfxType;
		}

		public WallMaterial(string name, string category, string baseTex, string bumpTex, string extraTex, bool skirting, bool secondaryColorEnabled, Color forcedSecondaryColor, Room.FloorType sfxType, List<ColorPreset> presets, RoomMaterialPack parent)
		{
			_shouldLoad = true;
			Name = name;
			Category = category;
			_baseTexFile = baseTex;
			_bumpTexFile = bumpTex;
			_extraTexFile = extraTex;
			AddSkirting = skirting;
			SFXType = sfxType;
			SecondaryColorEnabled = secondaryColorEnabled;
			ForcedSecondaryColor = forcedSecondaryColor;
			ColorPresets = presets;
			Parent = parent;
		}

		public bool Load()
		{
			if (_shouldLoad && !_isLoaded)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				bool errors = false;
				Base = LoadTexture(_baseTexFile, "Base", ref errors);
				Bump = LoadTexture(_bumpTexFile, "Bump", ref errors);
				Extra = LoadTexture(_extraTexFile, "Extra", ref errors);
				_isLoaded = true;
				if (Parent != null)
				{
					Parent.LoadTime += Time.realtimeSinceStartup - realtimeSinceStartup;
				}
				return errors;
			}
			return false;
		}

		public void Unload()
		{
			if (!_shouldLoad || !_isLoaded)
			{
				return;
			}
			if (_isMipped)
			{
				Base = MippedBase;
				Bump = MippedBump;
				Extra = MippedExtra;
			}
			else
			{
				if (Base != null)
				{
					Downscale(ref Base);
				}
				if (Extra != null)
				{
					Downscale(ref Extra);
				}
				if (Bump != null)
				{
					Downscale(ref Bump);
				}
				MippedBase = Base;
				MippedBump = Bump;
				MippedExtra = Extra;
			}
			_isLoaded = false;
			_isMipped = true;
		}

		private static void Downscale(ref Texture tex)
		{
			Texture2D texture2D = new Texture2D(128, 128, TextureFormat.ARGB32, false);
			Graphics.CopyTexture(tex, 0, 1, texture2D, 0, 0);
			UnityEngine.Object.Destroy(tex);
			texture2D.Compress(true);
			tex = texture2D;
		}

		private Texture2D LoadTexture(string path, string type, ref bool errors)
		{
			if (path == null || !File.Exists(path))
			{
				return null;
			}
			try
			{
				Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, true);
				texture2D.LoadImage(File.ReadAllBytes(path));
				texture2D.wrapMode = TextureWrapMode.Clamp;
				if (texture2D.width != 256 || texture2D.height != 256)
				{
					throw new Exception(type + " texture size is " + texture2D.width + "x" + texture2D.height + ", should be: 256 x 256");
				}
				return texture2D;
			}
			catch (Exception ex)
			{
				errors = true;
				Debug.LogException(new Exception("Error loading texture for material " + Name + ":\n" + ex.ToString()));
				if (Options.ConsoleOnError && !DevConsole.Console.isOpen)
				{
					DevConsole.Console.Open();
				}
			}
			return null;
		}
	}

	public class ColorTexController
	{
		public class ColorChunk
		{
			public Color[] Chunk;

			public bool[] FreeChunk;

			public int Num;

			public int Free;

			public int LastFree;

			public bool Dirty;

			public ColorChunk(int size, int num)
			{
				int num2 = size * size;
				Chunk = new Color[num2];
				FreeChunk = new bool[num2];
				Num = num;
				Clear();
			}

			public int GetFree()
			{
				for (int i = LastFree; i < Chunk.Length; i++)
				{
					if (FreeChunk[i])
					{
						LastFree = i + 1;
						Write(i, new Color(1f, 1f, 1f, 1f));
						Free--;
						return i;
					}
				}
				throw new Exception("Tried to get color from filled color chunk");
			}

			public int Get2Free()
			{
				int num = LastFree;
				if ((LastFree & 1) == 1)
				{
					num++;
				}
				for (int i = num; i < Chunk.Length - 1; i += 2)
				{
					if (FreeChunk[i] && FreeChunk[i + 1])
					{
						LastFree = i + 2;
						Write(i, new Color(1f, 1f, 1f, 1f));
						Write(i + 1, new Color(1f, 1f, 1f, 1f));
						Free -= 2;
						return i;
					}
				}
				throw new Exception("Tried to get 2 colors from filled color chunk");
			}

			public void Write(int num, Color col)
			{
				Chunk[num] = col;
				FreeChunk[num] = false;
				Dirty = true;
			}

			public void FreeColor(int num)
			{
				LastFree = Mathf.Min(num, LastFree);
				Free++;
				Chunk[num] = new Color(0f, 0f, 0f, 0f);
				FreeChunk[num] = true;
			}

			public void Clear()
			{
				for (int i = 0; i < Chunk.Length; i++)
				{
					Chunk[i] = new Color(0f, 0f, 0f, 0f);
					FreeChunk[i] = true;
				}
				LastFree = 0;
				Free = Chunk.Length;
			}
		}

		public Texture2D MainTex;

		public int Size;

		public int ChunkSize;

		public ColorChunk[,] Chunks;

		public bool Dirty;

		public void Update()
		{
			if (!Dirty)
			{
				return;
			}
			for (int i = 0; i < Chunks.GetLength(0); i++)
			{
				for (int j = 0; j < Chunks.GetLength(1); j++)
				{
					ColorChunk colorChunk = Chunks[i, j];
					if (colorChunk.Dirty)
					{
						MainTex.SetPixels(i * ChunkSize, j * ChunkSize, ChunkSize, ChunkSize, colorChunk.Chunk, 0);
						colorChunk.Dirty = false;
					}
				}
			}
			MainTex.Apply(false);
			Dirty = false;
		}

		public ColorTexController(int size, int chunkSize)
		{
			Size = size;
			ChunkSize = chunkSize;
			MainTex = new Texture2D(size, size, TextureFormat.ARGB32, false);
			MainTex.filterMode = FilterMode.Point;
			int num = Size / ChunkSize;
			Chunks = new ColorChunk[num, num];
			for (int i = 0; i < Chunks.GetLength(0); i++)
			{
				for (int j = 0; j < Chunks.GetLength(1); j++)
				{
					Chunks[i, j] = new ColorChunk(ChunkSize, i + j * Chunks.GetLength(0));
				}
			}
		}

		public int TakeColor()
		{
			for (int i = 0; i < Chunks.GetLength(0); i++)
			{
				for (int j = 0; j < Chunks.GetLength(1); j++)
				{
					ColorChunk colorChunk = Chunks[i, j];
					if (colorChunk.Free > 0)
					{
						return colorChunk.Num * Chunks.Length + colorChunk.GetFree();
					}
				}
			}
			throw new Exception("No more color chunks left!");
		}

		public int Take2Colors()
		{
			for (int i = 0; i < Chunks.GetLength(0); i++)
			{
				for (int j = 0; j < Chunks.GetLength(1); j++)
				{
					ColorChunk colorChunk = Chunks[i, j];
					if (colorChunk.Free > 1)
					{
						return colorChunk.Num * Chunks.Length + colorChunk.Get2Free();
					}
				}
			}
			throw new Exception("No more color chunks left!");
		}

		public void WriteColor(int id, Color color)
		{
			int num = ChunkSize * ChunkSize;
			int num2 = id / num;
			int num3 = num2 % Chunks.GetLength(0);
			int num4 = num2 / Chunks.GetLength(0);
			Chunks[num3, num4].Write(id - num2 * num, color);
			Dirty = true;
		}

		public void FreeColor(int id)
		{
			int num = ChunkSize * ChunkSize;
			int num2 = id / num;
			int num3 = num2 % Chunks.GetLength(0);
			int num4 = num2 / Chunks.GetLength(0);
			Chunks[num3, num4].FreeColor(id - num2 * num);
		}

		public Color GetColor(int id)
		{
			int num = ChunkSize * ChunkSize;
			int num2 = id / num;
			int num3 = num2 % Chunks.GetLength(0);
			int num4 = num2 / Chunks.GetLength(0);
			return Chunks[num3, num4].Chunk[id - num2 * num];
		}

		public Vector2 GetColorUV(int id)
		{
			int num = ChunkSize * ChunkSize;
			int num2 = id / num;
			int num3 = num2 % Chunks.GetLength(0);
			int num4 = num2 / Chunks.GetLength(0);
			int num5 = num3 * ChunkSize;
			num4 *= ChunkSize;
			int num6 = id - num2 * num;
			return new Vector2(((float)(num5 + num6 % ChunkSize) + 0.5f) / (float)Size, ((float)(num4 + num6 / ChunkSize) + 0.5f) / (float)Size);
		}

		public void Clear()
		{
			for (int i = 0; i < Chunks.GetLength(0); i++)
			{
				for (int j = 0; j < Chunks.GetLength(1); j++)
				{
					Chunks[i, j].Clear();
				}
			}
		}
	}

	public static RoomMaterialController Instance;

	public RenderTexture BaseTex;

	public RenderTexture BumpTex;

	public RenderTexture ExtraTex;

	public Texture DefaultBase;

	public Texture DefaultBump;

	public Texture DefaultExtra;

	public Texture SkirtingBase;

	public Texture SkirtingNormal;

	public Texture SkirtingExtra;

	public WallMaterial[] RoomMaterials;

	public Material TextureRendMat;

	public Material TextureRendMat2;

	public Material MainMat;

	public Material MainCutMat;

	public Material TestMat;

	public Material StandardRoof;

	public Material StandardCeiling;

	public Material ShadowsOnly;

	public Material PreviewMat;

	[NonSerialized]
	public Dictionary<string, WallMaterial> AllMaterials;

	public int TexCells;

	[NonSerialized]
	public int GroundColorID = -1;

	[NonSerialized]
	public int BlackColorID = -1;

	[NonSerialized]
	public List<RoomMaterialPack> MaterialPacks = new List<RoomMaterialPack>();

	[NonSerialized]
	public ColorTexController ColorController;

	private static bool Initialized;

	public static bool ErrorsDuringLoad;

	public static int GetMaterialID(string mat)
	{
		if (Instance != null)
		{
			WallMaterial value;
			if (!Instance.AllMaterials.TryGetValue(mat, out value))
			{
				return 0;
			}
			return value.ID;
		}
		return 0;
	}

	public static ValueTuple<int, bool> GetMaterialIDAndSkirtBool(string mat, bool atrium)
	{
		if (Instance != null)
		{
			WallMaterial value;
			if (!Instance.AllMaterials.TryGetValue(mat, out value))
			{
				return new ValueTuple<int, bool>(0, false);
			}
			return new ValueTuple<int, bool>(value.ID, !atrium && value.AddSkirting);
		}
		return new ValueTuple<int, bool>(0, false);
	}

	public static float GetMaterialIDAndSkirt(string mat, bool atrium)
	{
		if (Instance != null)
		{
			WallMaterial value;
			if (!Instance.AllMaterials.TryGetValue(mat, out value))
			{
				return 0f;
			}
			return (float)value.ID + ((!atrium && value.AddSkirting) ? 0.8f : 0f);
		}
		return 0f;
	}

	public static bool AllowSecondaryRecolor(string mat)
	{
		if (Instance != null)
		{
			WallMaterial value;
			if (Instance.AllMaterials.TryGetValue(mat, out value))
			{
				return value.SecondaryColorEnabled;
			}
			return false;
		}
		return false;
	}

	public static Color? GetMaterialForcedSecondaryColor(string mat)
	{
		WallMaterial value;
		if (Instance != null && Instance.AllMaterials.TryGetValue(mat, out value) && !value.SecondaryColorEnabled)
		{
			return value.ForcedSecondaryColor;
		}
		return null;
	}

	public static bool GetMaterialForcedSecondaryColor(string mat, out Color c)
	{
		c = Color.clear;
		WallMaterial value;
		if (Instance != null && Instance.AllMaterials.TryGetValue(mat, out value) && !value.SecondaryColorEnabled)
		{
			c = value.ForcedSecondaryColor;
			return true;
		}
		return false;
	}

	public static bool GetMaterialForcedSecondarySVec(string mat, out SVector3 c)
	{
		c = Color.clear;
		WallMaterial value;
		if (Instance != null && Instance.AllMaterials.TryGetValue(mat, out value) && !value.SecondaryColorEnabled)
		{
			c = value.ForcedSecondaryColor;
			return true;
		}
		return false;
	}

	public static void UpdateCutoffMat()
	{
		if (Instance != null && !GameSettings.Instance.IsReferenceNull())
		{
			if (GameSettings.WallsDown == GameSettings.WallState.Back)
			{
				Instance.MainCutMat.SetFloat("_Cutoff", (float)GameSettings.Instance.ActiveFloor * 2f + 1.8f);
				Instance.MainCutMat.SetFloat("_CutoffTop", 1f);
			}
			else
			{
				Instance.MainCutMat.SetFloat("_Cutoff", (float)GameSettings.Instance.ActiveFloor * 2f + 0.2f);
				Instance.MainCutMat.SetFloat("_CutoffTop", 0f);
			}
		}
	}

	public void Init()
	{
		if (Initialized)
		{
			return;
		}
		MainMat = new Material(MainMat);
		MainCutMat = new Material(MainCutMat);
		StandardRoof = new Material(StandardRoof);
		PreviewMat = new Material(PreviewMat);
		Initialized = true;
		AllMaterials = new Dictionary<string, WallMaterial>();
		for (int i = 0; i < RoomMaterials.Length; i++)
		{
			WallMaterial wallMaterial = RoomMaterials[i];
			AllMaterials[wallMaterial.Name] = wallMaterial;
		}
		for (int j = 0; j < MaterialPacks.Count; j++)
		{
			RoomMaterialPack roomMaterialPack = MaterialPacks[j];
			for (int k = 0; k < roomMaterialPack.Materials.Length; k++)
			{
				WallMaterial wallMaterial2 = roomMaterialPack.Materials[k];
				AllMaterials[wallMaterial2.Name] = wallMaterial2;
			}
		}
		ColorController = new ColorTexController(256, 256);
		StandardRoof.mainTexture = ColorController.MainTex;
		InitializeTextures(true);
		LoadDebugger.AddInfo("Finished loading room materials");
	}

	public void InitializeTextures(bool withErrors)
	{
		int masterTextureLimit = QualitySettings.masterTextureLimit;
		QualitySettings.masterTextureLimit = 0;
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		int num = Mathf.NextPowerOfTwo(Mathf.CeilToInt(Mathf.Sqrt(AllMaterials.Count)) * 256);
		int maxTextureSize = SystemInfo.maxTextureSize;
		if (num > maxTextureSize && withErrors)
		{
			Debug.Log("Couldn't fit all room materials, max system texture size: " + maxTextureSize + ", needed: " + num);
			LoadDebugger.AddError("Too many room materals to fit graphics card");
		}
		maxTextureSize = Mathf.Min(maxTextureSize, num);
		int num2 = maxTextureSize / 256;
		num2 *= num2;
		if (BaseTex != null)
		{
			UnityEngine.Object.Destroy(BaseTex);
		}
		if (BumpTex != null)
		{
			UnityEngine.Object.Destroy(BumpTex);
		}
		if (ExtraTex != null)
		{
			UnityEngine.Object.Destroy(ExtraTex);
		}
		BaseTex = new RenderTexture(maxTextureSize, maxTextureSize, 0, RenderTextureFormat.ARGB32);
		BumpTex = new RenderTexture(maxTextureSize, maxTextureSize, 0, RenderTextureFormat.ARGB32);
		ExtraTex = new RenderTexture(maxTextureSize, maxTextureSize, 0, RenderTextureFormat.ARGB32);
		BaseTex.autoGenerateMips = false;
		BumpTex.autoGenerateMips = false;
		ExtraTex.autoGenerateMips = false;
		BaseTex.useMipMap = SystemInfo.supportsInstancing;
		BumpTex.useMipMap = SystemInfo.supportsInstancing;
		ExtraTex.useMipMap = SystemInfo.supportsInstancing;
		TextureRendMat = new Material(TextureRendMat);
		TextureRendMat.SetVector("_Offset", new Vector4(0f, 0f, 1f, 1f));
		Graphics.Blit(DefaultBase, BaseTex, TextureRendMat);
		Graphics.Blit(DefaultBump, BumpTex, TextureRendMat);
		Graphics.Blit(DefaultExtra, ExtraTex, TextureRendMat);
		if (SystemInfo.supportsInstancing)
		{
			MainMat.SetTexture("_MainTex", BaseTex);
			MainMat.SetTexture("_BumpTex", BumpTex);
			MainMat.SetTexture("_ExtraTex", ExtraTex);
			PreviewMat.SetTexture("_MainTex", BaseTex);
			PreviewMat.SetTexture("_BumpTex", BumpTex);
			PreviewMat.SetTexture("_ExtraTex", ExtraTex);
			MainCutMat.SetTexture("_MainTex", BaseTex);
			MainCutMat.SetTexture("_BumpTex", BumpTex);
			MainCutMat.SetTexture("_ExtraTex", ExtraTex);
		}
		MainMat.SetTexture("_ColorTex", ColorController.MainTex);
		MainCutMat.SetTexture("_ColorTex", ColorController.MainTex);
		TexCells = maxTextureSize / 256;
		MainMat.SetFloat("_TexSize", TexCells);
		MainMat.SetFloat("_ColorSize", 256f);
		PreviewMat.SetFloat("_TexSize", TexCells);
		PreviewMat.SetFloat("_ColorSize", 256f);
		MainCutMat.SetFloat("_TexSize", TexCells);
		MainCutMat.SetFloat("_ColorSize", 256f);
		MainMat.SetFloat("_Margin", 8f);
		PreviewMat.SetFloat("_Margin", 8f);
		MainCutMat.SetFloat("_Margin", 8f);
		TextureRendMat.SetFloat("_Margin", 1f / 32f);
		int num3 = 0;
		bool flag = ErrorsDuringLoad;
		foreach (WallMaterial value in AllMaterials.Values)
		{
			if (value.Load())
			{
				flag = true;
			}
			value.ID = num3;
			TextureRendMat.SetVector("_Offset", new Vector4(num3 % TexCells, num3 / TexCells, TexCells, TexCells));
			if (value.Base != null)
			{
				Graphics.Blit(value.Base, BaseTex, TextureRendMat);
			}
			if (value.Bump != null)
			{
				Graphics.Blit(value.Bump, BumpTex, TextureRendMat);
			}
			if (value.Extra != null)
			{
				RenderTexture.active = ExtraTex;
				GL.PushMatrix();
				GL.LoadPixelMatrix(0f, ExtraTex.width, ExtraTex.height, 0f);
				float num4 = 1f / 64f;
				Graphics.DrawTexture(new Rect(num3 % TexCells * 256, ExtraTex.height - num3 / TexCells * 256 - 256, value.Extra.width, value.Extra.height), value.Extra, new Rect(0f - num4, 0f - num4, 1f + num4 * 2f, 1f + num4 * 2f), 0, 0, 0, 0, TextureRendMat2);
				GL.PopMatrix();
				RenderTexture.active = null;
			}
			value.Unload();
			num3++;
			if (num3 >= num2)
			{
				break;
			}
		}
		if (SystemInfo.supportsInstancing)
		{
			BaseTex.GenerateMips();
			BumpTex.GenerateMips();
			ExtraTex.GenerateMips();
		}
		else
		{
			Texture2D texture2D = new Texture2D(BaseTex.width, BaseTex.height, TextureFormat.ARGB32, true);
			Texture2D texture2D2 = new Texture2D(BaseTex.width, BaseTex.height, TextureFormat.ARGB32, true);
			Texture2D texture2D3 = new Texture2D(BaseTex.width, BaseTex.height, TextureFormat.ARGB32, true);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = BaseTex;
			texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0, true);
			texture2D.Apply();
			RenderTexture.active = BumpTex;
			texture2D2.ReadPixels(new Rect(0f, 0f, texture2D2.width, texture2D2.height), 0, 0, true);
			texture2D2.Apply();
			RenderTexture.active = ExtraTex;
			texture2D3.ReadPixels(new Rect(0f, 0f, texture2D3.width, texture2D3.height), 0, 0, true);
			texture2D3.Apply();
			RenderTexture.active = active;
			MainMat.SetTexture("_MainTex", texture2D);
			MainMat.SetTexture("_BumpTex", texture2D2);
			MainMat.SetTexture("_ExtraTex", texture2D3);
			PreviewMat.SetTexture("_MainTex", texture2D);
			PreviewMat.SetTexture("_BumpTex", texture2D2);
			PreviewMat.SetTexture("_ExtraTex", texture2D3);
			MainCutMat.SetTexture("_MainTex", texture2D);
			MainCutMat.SetTexture("_BumpTex", texture2D2);
			MainCutMat.SetTexture("_ExtraTex", texture2D3);
		}
		QualitySettings.masterTextureLimit = masterTextureLimit;
		if (withErrors)
		{
			Debug.Log("material texture build time: " + (Time.realtimeSinceStartup - realtimeSinceStartup).SecondsToTime() + " for " + num3 + " textures");
			if (flag)
			{
				LoadDebugger.AddError("There were errors while loading materials");
			}
		}
	}

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		Instance = this;
		string path = Path.Combine(Utilities.GetRoot(), "Materials");
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
			return;
		}
		string[] directories = Directory.GetDirectories(path);
		for (int i = 0; i < directories.Length; i++)
		{
			RoomMaterialPack roomMaterialPack = RoomMaterialPack.LoadPack(directories[i], true, ref ErrorsDuringLoad) as RoomMaterialPack;
			if (roomMaterialPack != null)
			{
				MaterialPacks.Add(roomMaterialPack);
			}
		}
	}

	private void FixedUpdate()
	{
		if (Initialized)
		{
			ColorController.Update();
			if (SystemInfo.supportsInstancing && !BaseTex.IsCreated())
			{
				InitializeTextures(false);
				Debug.Log("Re-initialized building textures");
			}
		}
	}

	public static int TakeColor()
	{
		if (Instance != null)
		{
			return Instance.ColorController.TakeColor();
		}
		throw new Exception("Tried to reserve color without controller");
	}

	public static int Take2Colors()
	{
		if (Instance != null)
		{
			return Instance.ColorController.Take2Colors();
		}
		throw new Exception("Tried to reserve color without controller");
	}

	public static Color GetColor(int id)
	{
		if (id == -1)
		{
			return new Color(0f, 0f, 0f, 0f);
		}
		if (Instance != null)
		{
			return Instance.ColorController.GetColor(id);
		}
		throw new Exception("Tried to read color without controller");
	}

	public static void FreeColor(int id)
	{
		if (id != -1)
		{
			if (!(Instance != null))
			{
				throw new Exception("Tried to free color without controller");
			}
			Instance.ColorController.FreeColor(id);
		}
	}

	public static void Free2Colors(int id)
	{
		if (id != -1)
		{
			if (!(Instance != null))
			{
				throw new Exception("Tried to free color without controller");
			}
			Instance.ColorController.FreeColor(id);
			Instance.ColorController.FreeColor(id + 1);
		}
	}

	public static void WriteColor(int id, Color col)
	{
		if (id != -1)
		{
			if (!(Instance != null))
			{
				throw new Exception("Tried to write color without controller");
			}
			Instance.ColorController.WriteColor(id, col);
		}
	}

	public static void Clear()
	{
		if (Instance != null && Instance.ColorController != null)
		{
			Instance.ColorController.Clear();
			Instance.GroundColorID = Instance.ColorController.TakeColor();
			Instance.BlackColorID = Instance.ColorController.TakeColor();
			Instance.ColorController.WriteColor(Instance.BlackColorID, Color.black);
		}
	}

	private void CreateTestObject(int tex, int color, int size, Vector3 pos)
	{
		GameObject obj = new GameObject("TEST");
		obj.transform.position = pos;
		MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
		obj.AddComponent<MeshRenderer>().material = MainMat;
		Mesh mesh = new Mesh();
		mesh.vertices = new Vector3[4]
		{
			new Vector3(0f, 0f, 0f),
			new Vector3(size, 0f, 0f),
			new Vector3(size, 0f, size),
			new Vector3(0f, 0f, size)
		};
		mesh.uv = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(size, 0f),
			new Vector2(size, size),
			new Vector2(0f, size)
		};
		mesh.uv2 = new Vector2[4]
		{
			new Vector2(color, tex),
			new Vector2(color, tex),
			new Vector2(color, tex),
			new Vector2(color, tex)
		};
		mesh.normals = new Vector3[4]
		{
			Vector3.up,
			Vector3.up,
			Vector3.up,
			Vector3.up
		};
		mesh.triangles = new int[6] { 2, 1, 0, 0, 3, 2 };
		meshFilter.sharedMesh = mesh;
	}
}
