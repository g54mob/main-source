using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using Achievements;
using DG.Tweening;
using DevConsole;
using MadGoat_SSAA;
using SINetworking;
using Steamworks;
using Twitter;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.CinematicEffects;
using UnityStandardAssets.ImageEffects;

public class MainMenuController : MonoBehaviour
{
	private struct WebVersion
	{
		public bool Public;

		public int Type;

		public int Major;

		public int Minor;

		public int Rev;

		public WebVersion(string[] sp, int off)
		{
			Public = sp[off] == "1";
			Type = sp[off + 1].ConvertToIntDef(0);
			Major = sp[off + 2].ConvertToIntDef(0);
			Minor = sp[off + 3].ConvertToIntDef(0);
			Rev = sp[off + 4].ConvertToIntDef(0);
		}

		public int IsNewer(Versioning.Version v)
		{
			if (Type > v.TypeInt)
			{
				return 2;
			}
			if (Type == v.TypeInt)
			{
				if (Major > v.Major)
				{
					return 2;
				}
				if (Major == v.Major)
				{
					if (Minor > v.Minor)
					{
						return 2;
					}
					if (Minor == v.Minor)
					{
						if (Rev > v.Revision)
						{
							return 2;
						}
						if (Rev == v.Revision)
						{
							return 1;
						}
					}
				}
			}
			return 0;
		}
	}

	public static MainMenuController Instance;

	public Transform MapTransform;

	public GameObject MapObj;

	public SSAOPro SSAO;

	public TiltShift TiltScript;

	public Antialiasing AntiAlias;

	public BloomOptimized Bloom;

	public MadGoatSSAA SSAAScript;

	public AntiAliasing SMAA;

	public ScreenSpaceReflection SSR;

	public Camera SnapshotCamera;

	public MonoBehaviour[] CamEffects;

	private bool PictureMode;

	public GameObject MainPanel;

	public GameObject PicturePanel;

	public GameObject LoadController;

	public GameObject SavePanel;

	public GameObject TweetPanel;

	public GameObject WaitPanel;

	public GameObject LanguageCombo;

	public RawImage PictureShow;

	private Texture2D PictureTex;

	private Texture2D Tweetable;

	private int CurrentSave;

	private SaveGame[] MainMenuSaves;

	public Text SaveName;

	private Color defaultColor;

	private float lastX;

	private float lastRot;

	public InputField PinField;

	public InputField TweetField;

	public InputField ResWidth;

	public InputField ResHeight;

	public ScreenSpaceReflection ssr;

	public Toggle SSRToggle;

	public Slider SunSlider;

	public Light Sun;

	public Light Extra;

	public GameObject LoadingWait;

	public GUIProgressBar pBar;

	public GameObject pBarGO;

	public Text pBarText;

	public GammaSaturation GSat;

	public Transform MapPlane;

	public List<Furniture> SceneFurns;

	public Transform[] FurnSpawn;

	public Renderer Walls;

	public Renderer Floor;

	public Button ContinueButton;

	public Renderer ScreenImage;

	public GameObject NewVersionObject;

	public GameObject MultiplayerButton;

	public NetworkStartWindow NetworkWindow;

	public MenuItemScript MainMenu;

	public ComputeTest ScreenSaver;

	public float ScreenSaverTimeout = 5f;

	private float _screenSaverRunTime;

	[NonSerialized]
	public bool HaltScreen;

	private static string ConsumerKey = "UQb6TaTAXNyy5FomBebwxqqqz";

	private static string ConsumerSecret = "uBHWlowMe2bxTmli0Qctj1RSP8bRG27m4xkmthSCe7sgxstQDy";

	private static AccessTokenResponse AccessToken;

	private static RequestTokenResponse RequestToken;

	private static bool _firstRun = true;

	[NonSerialized]
	public static bool IsUploading = false;

	public SaveGame CurrentSaveGame
	{
		get
		{
			if (MainMenuSaves.Length == 0)
			{
				return null;
			}
			return MainMenuSaves[CurrentSave];
		}
	}

	public void ClearScreenSaver()
	{
		if (ScreenSaver != null)
		{
			ScreenSaver.gameObject.SetActive(false);
			_screenSaverRunTime = ScreenSaverTimeout;
		}
	}

	public void ToggleScreenImage(Texture2D tex)
	{
		if (HaltScreen)
		{
			return;
		}
		if (tex == null)
		{
			if (ScreenImage != null)
			{
				ScreenImage.gameObject.SetActive(false);
			}
			if (MapObj != null)
			{
				MapObj.SetActive(true);
			}
			return;
		}
		if (ScreenImage != null)
		{
			ScreenImage.material.mainTexture = tex;
			ScreenImage.gameObject.SetActive(true);
		}
		if (MapObj != null)
		{
			MapObj.SetActive(false);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void UpdateSunSlider()
	{
		Sun.intensity = SunSlider.value;
	}

	public void TogglePictureMode()
	{
		PictureMode = !PictureMode;
		Extra.enabled = !PictureMode;
		LanguageCombo.SetActive(!PictureMode);
		SnapshotCamera.enabled = PictureMode;
		if (PictureMode)
		{
			MapObj.transform.rotation = Quaternion.identity;
			PicturePanel.SetActive(true);
			MainPanel.SetActive(false);
		}
		else
		{
			PicturePanel.SetActive(false);
			MainPanel.SetActive(true);
			SunSlider.value = 1.4f;
		}
	}

	public void Tweet()
	{
		if (PinField.gameObject.activeSelf)
		{
			WaitPanel.gameObject.SetActive(true);
			StartCoroutine(API.GetAccessToken(ConsumerKey, ConsumerSecret, RequestToken.Token, PinField.text, AccessTokenCallback));
			PinField.gameObject.SetActive(false);
		}
		else if (AccessToken == null)
		{
			WaitPanel.gameObject.SetActive(true);
			StartCoroutine(API.GetRequestToken(ConsumerKey, ConsumerSecret, RequestTokenCallback));
		}
		else
		{
			PostPic();
		}
	}

	private void RequestTokenCallback(bool success, RequestTokenResponse response)
	{
		if (success)
		{
			API.OpenAuthorizationPage(response.Token);
			PinField.gameObject.SetActive(true);
			RequestToken = response;
		}
		else
		{
			TwitterError();
		}
		WaitPanel.gameObject.SetActive(false);
	}

	private void PostPic()
	{
		TweetField.text = "DefaultTweet".Loc();
		SavePanel.gameObject.SetActive(false);
		TweetPanel.gameObject.SetActive(true);
	}

	public void CancelTweet()
	{
		SavePanel.gameObject.SetActive(true);
		TweetPanel.gameObject.SetActive(false);
	}

	public void TweetNow()
	{
		RealPostPic();
		CancelTweet();
	}

	private void RealPostPic()
	{
		WaitPanel.gameObject.SetActive(true);
		StartCoroutine(API.PostMedia(Tweetable, ConsumerKey, ConsumerSecret, AccessToken, PostMediaCallback));
	}

	private void AccessTokenCallback(bool success, AccessTokenResponse response)
	{
		if (success)
		{
			AccessToken = response;
			PostPic();
		}
		else
		{
			TwitterError();
		}
		WaitPanel.gameObject.SetActive(false);
	}

	private void TwitterError()
	{
		DialogWindow d = WindowManager.SpawnDialog();
		d.Show("TweetError".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
		{
			d.Window.Close();
		}));
	}

	private void PostMediaCallback(bool success, string mediaId)
	{
		if (success)
		{
			StartCoroutine(API.PostTweet(TweetField.text, mediaId, ConsumerKey, ConsumerSecret, AccessToken, PostTweetCallback));
		}
		else
		{
			TwitterError();
		}
	}

	private void PostTweetCallback(bool success)
	{
		if (!success)
		{
			TwitterError();
		}
		WaitPanel.gameObject.SetActive(false);
	}

	public void Spin(float degrees)
	{
		MapObj.transform.rotation = Quaternion.Euler(0f, MapObj.transform.rotation.eulerAngles.y + degrees, 0f);
	}

	public void ApplyOptions()
	{
		Bloom.enabled = Options.Bloom;
		TiltScript.enabled = Options.TiltShift;
		TiltScript.blurArea = 5f * CameraScript.ScreenUpscale;
		SSAAScript.multiplier = (float)Options.SSAA / 10f;
		SSAAScript.enabled = Options.SSAA > 10;
		SSAO.enabled = Options.AmbientOcclusion;
		AntiAlias.enabled = Options.FXAA;
		SMAA.enabled = Options.SMAA;
		SSR.enabled = Options.SSR;
		GSat.Gamma = Options.Gamma;
	}

	private IEnumerator CheckVersion()
	{
		UnityWebRequest web = UnityWebRequest.Get("https://SoftwareInc.Coredumping.com/SwincVersion.php");
		web.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return web.SendWebRequest();
		try
		{
			if (!string.IsNullOrEmpty(web.error))
			{
				yield break;
			}
			string[] array = web.downloadHandler.text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 10)
			{
				yield break;
			}
			WebVersion webVersion = new WebVersion(array, 0);
			WebVersion webVersion2 = new WebVersion(array, 5);
			if (!webVersion.Public)
			{
				WebVersion webVersion3 = webVersion;
				webVersion = webVersion2;
				webVersion2 = webVersion3;
			}
			switch (webVersion.IsNewer(Versioning.CurrentVersion))
			{
			case 0:
				if (webVersion2.IsNewer(Versioning.CurrentVersion) != 2)
				{
					break;
				}
				goto case 2;
			case 2:
				NewVersionObject.SetActive(true);
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	private void Start()
	{
		PipLight.ForceWhite = false;
		AchievementController.Init();
		Encoding.UTF8.GetBytes("");
		MultiplayerButton.SetActive(NetworkManager.Ready);
		Employee.ResetFriendships();
		Shader.SetGlobalFloat("_SupportHeightCutoff", 1000f);
		Writeable.IDCount = 1u;
		ModController.Initialize(true);
		GameSettings.ResetForcePause();
		GameSettings.HasQuitSaved = false;
		GameData.LoadBackup = false;
		GameData.EditMode = false;
		GameData.RestartCompany = false;
		GameData.MultiplayerMode = false;
		GameData.NetworkData = null;
		GameData.NetworkSettings = null;
		GameData.LoadFile = null;
		GameData.LoanAmount = 0;
		GameSettings.IsQuitting = false;
		try
		{
			for (int i = 0; i < SaveGameManager.SaveGames.Count; i++)
			{
				SaveGame saveGame = SaveGameManager.SaveGames[i];
				if (saveGame.NetworkData != null && saveGame.NetworkData.PlayerIDs[saveGame.NetworkData.LocalUniqueID] == byte.MaxValue)
				{
					try
					{
						File.Delete(saveGame.FileName);
						SaveGameManager.Instance.RemoveSaveItem(saveGame);
						NetworkStartWindow.Dirty = true;
						Debug.Log("Save file " + saveGame.ActualName + " had network ID 255, deleting to avoid corruption");
					}
					catch (Exception)
					{
					}
				}
			}
		}
		catch (Exception ex2)
		{
			Debug.Log(ex2.ToString());
		}
		if (NetworkManager.Ready)
		{
			NetworkManager.Self.ID = 1;
		}
		if (_firstRun)
		{
			ErrorHandling();
			string value;
			if (Localization.CurrentTranslation.MetaData.TryGetCustomData("DownloadLink", out value) && Localization.CurrentTranslation.MetaData.TryGetCustomData("Version", out value) && Localization.CurrentTranslation.MetaData.TryGetCustomData("VersionLink", out value))
			{
				StartCoroutine(CheckLanguageUpdate(Localization.CurrentTranslation));
			}
			_firstRun = false;
		}
		defaultColor = SnapshotCamera.backgroundColor;
		MainMenuSaves = (from x in SaveGameManager.SaveGames
			where !x.Legacy && !x.Broken && !x.BuildingOnly && x.NetworkData == null
			orderby x.RealTime descending
			select x).ToArray();
		CamEffects = (from x in SnapshotCamera.transform.GetComponentsInChildren<MonoBehaviour>()
			where !x.enabled
			select x).ToArray();
		ApplyOptions();
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		if (MainMenuSaves.Length != 0)
		{
			MapObj = CreateMap(MainMenuSaves[0].Map);
			MapObj.transform.localPosition = new Vector3(0f, 0f, 30f);
			MapObj.transform.DOLocalMoveZ(0f, 0.4f).SetEase(Ease.OutCubic);
			SaveName.text = MainMenuSaves[0].ActualName + "(1/" + MainMenuSaves.Length + ")";
		}
		else
		{
			LoadController.SetActive(false);
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (MemoryStream serializationStream = new MemoryStream((Resources.Load("StartMap") as TextAsset).bytes))
			{
				MiniMapMaker.MapDescriptor desc = (MiniMapMaker.MapDescriptor)binaryFormatter.Deserialize(serializationStream);
				MapObj = CreateMap(desc);
				MapObj.transform.localPosition = new Vector3(0f, 0f, 30f);
				MapObj.transform.DOLocalMoveZ(0f, 0.4f).SetEase(Ease.OutCubic);
			}
			ContinueButton.interactable = false;
		}
		List<Furniture> l = (from x in ObjectDatabase.Instance.GetAllFurniture().SelectNotNull((GameObject x) => x.GetComponent<Furniture>())
			where x.FileName == null && x.ValidIndoors
			select x).ToList();
		for (int num = 0; num < FurnSpawn.Length; num++)
		{
			Transform transform = FurnSpawn[num];
			string type = transform.name;
			int num2 = type.IndexOf("|");
			string uTo = null;
			if (num2 >= 0)
			{
				type = transform.name.Substring(0, num2);
				uTo = transform.name.Substring(num2 + 1);
			}
			Furniture furniture = UnityEngine.Object.Instantiate(l.Where((Furniture x) => x.Type.Equals(type) && (uTo == null || (x.UpgradeTo != null && x.UpgradeTo.Equals(uTo)))).GetRandom());
			furniture.isTemporary = true;
			furniture.transform.SetParent(transform, false);
			furniture.gameObject.SetActive(true);
			SceneFurns.Add(furniture);
		}
		for (int num3 = 0; num3 < SceneFurns.Count; num3++)
		{
			Furniture furniture2 = SceneFurns[num3];
			furniture2.AtlasIndex = UnityEngine.Random.Range(0, furniture2.AtlasCount);
			if (UnityEngine.Random.Range(0, furniture2.AltStyles.Count + 1) != 0)
			{
				furniture2.AltStyles.GetRandom().Apply(furniture2, null);
				furniture2.Deserialized = true;
			}
		}
		SetStyle(ObjectDatabase.Instance.MainMenuRoomStyles.GetRandom());
		StartCoroutine(CheckVersion());
		if (Options.SteamJoinLobby != null)
		{
			string steamJoinLobby = Options.SteamJoinLobby;
			Options.SteamJoinLobby = null;
			SteamLayer steamLayer;
			ulong result;
			if (NetworkManager.Ready && (object)(steamLayer = NetworkLayer.Active as SteamLayer) != null && ulong.TryParse(steamJoinLobby, out result))
			{
				steamLayer.JoinLobbyNow(new CSteamID(result));
			}
		}
	}

	private IEnumerator CheckLanguageUpdate(Localization.Translation t)
	{
		int lv = t.MetaData.GetCustomData("Version").ConvertToIntDef(-1);
		if (lv <= -1)
		{
			yield break;
		}
		string versionLink = t.MetaData.GetCustomData("VersionLink");
		UnityWebRequest versionReq = UnityWebRequest.Get(versionLink);
		versionReq.SetRequestHeader("User-Agent", "Swinc User Agent");
		yield return versionReq.SendWebRequest();
		if (versionReq.error != null)
		{
			yield break;
		}
		int v = versionReq.downloadHandler.text.ConvertToIntDef(-1);
		if (v >= 0 && lv < v)
		{
			Debug.Log("New update for language " + t.ItemTitle);
			WindowManager.Instance.ShowMessageBox("TranslationUpdate".Loc(), true, DialogWindow.DialogType.Question, delegate
			{
				StartCoroutine(LocalizorButton.DownloadLanguage(t.MetaData.GetCustomData("DownloadLink"), t.ItemTitle, versionLink, v, null, null));
			}, "TranslationUpdate");
		}
		else
		{
			Debug.Log("No new update for language " + t.ItemTitle);
		}
	}

	public void SetStyle(RoomStyle style)
	{
		RoomMaterialController.WallMaterial wallMaterial = RoomMaterialController.Instance.AllMaterials[style.FloorMat];
		Floor.material = RoomMaterialController.Instance.PreviewMat;
		Floor.material.SetColor("_Color", style.FloorColor);
		Floor.material.SetColor("_Color2", wallMaterial.SecondaryColorEnabled ? style.FloorColor2.ToColor() : wallMaterial.ForcedSecondaryColor);
		Floor.material.SetInt("_TexIdx", wallMaterial.ID);
		wallMaterial = RoomMaterialController.Instance.AllMaterials[style.InsideMat];
		Walls.material = RoomMaterialController.Instance.PreviewMat;
		Walls.material.SetColor("_Color", style.InsideColor);
		Walls.material.SetColor("_Color2", wallMaterial.SecondaryColorEnabled ? style.InsideColor2.ToColor() : wallMaterial.ForcedSecondaryColor);
		Walls.material.SetInt("_TexIdx", wallMaterial.ID);
	}

	public void InitRoomMat(Renderer rend, bool floor)
	{
	}

	public GameObject CreateMap(MiniMapMaker.MapDescriptor desc)
	{
		GameObject gameObject = MinimapThumbnailMaker.Instance.MinimapMaker.CreateMap(desc, true);
		gameObject.transform.localScale = gameObject.transform.localScale * 10f;
		gameObject.transform.SetParent(MapTransform);
		return gameObject;
	}

	private void ErrorHandling()
	{
		if (Directory.Exists("BugReports"))
		{
			string[] directories = Directory.GetDirectories("BugReports");
			foreach (string dir in directories)
			{
				try
				{
					string path = Path.Combine(dir, "Report.xml");
					if (File.Exists(path))
					{
						XMLParser.XMLNode xMLNode = XMLParser.ParseXML(File.ReadAllText(path));
						IsUploading = true;
						FeedbackWindow.Instance.Window.Show();
						StartCoroutine(FeedbackWindow.Instance.UploadSpecial(xMLNode.GetNode("Mail").Value, xMLNode.GetNode("Message").Value, xMLNode.GetNode("Type").Value, xMLNode.GetNode("Version").Value, xMLNode.GetNode("Files").Children.Select((XMLParser.XMLNode x) => Path.GetFullPath(Path.Combine(dir, x.Value))).ToArray(), dir));
					}
				}
				catch (Exception ex)
				{
					DevConsole.Console.LogError(ex.ToString());
					continue;
				}
				break;
			}
		}
		string crashFolder = FeedbackWindow.GetCrashFolder();
		if (!Options.AskReporting || !Directory.Exists(crashFolder))
		{
			return;
		}
		foreach (string item in Directory.GetDirectories(crashFolder).OrderByDescending(Path.GetFileName))
		{
			string dir2 = item;
			string fileName = Path.GetFileName(item);
			if (!Regex.IsMatch(fileName, "Crash_\\d\\d\\d\\d\\-\\d\\d\\-\\d\\d_\\d\\d\\d\\d\\d\\d") || File.Exists(Path.Combine(item, "Checked.txt")))
			{
				continue;
			}
			int num = Convert.ToInt32(fileName.Substring(6, 4));
			int num2 = Convert.ToInt32(fileName.Substring(11, 2));
			int num3 = Convert.ToInt32(fileName.Substring(14, 2));
			if (num < 2016 && num2 < 6 && num3 < 13)
			{
				continue;
			}
			string[] files = Directory.GetFiles(dir2).SelectInPlace((string x) => Path.GetFullPath(x));
			string text = files.FirstOrDefault((string x) => x.EndsWith("Player.log") || x.EndsWith("output_log.txt"));
			if (text != null)
			{
				string text2;
				try
				{
					text2 = File.ReadAllText(text);
				}
				catch (Exception ex2)
				{
					Debug.Log(ex2.ToString());
					try
					{
						File.Create(Path.Combine(item, "Checked.txt"));
					}
					catch (Exception)
					{
					}
					continue;
				}
				if (!text2.Contains("(UnityPlayer) DoQuit"))
				{
					string versionOverride = null;
					try
					{
						Match match = Regex.Match(text2, "Software Inc\\. (.+ \\d+.\\d+.\\d+,[^\\n]+)");
						if (match.Success)
						{
							versionOverride = match.Groups[1].Value;
						}
					}
					catch (Exception)
					{
					}
					DialogWindow d = WindowManager.SpawnDialog();
					d.Show("CrashMessage".Loc(), false, DialogWindow.DialogType.Information, new KeyValuePair<string, Action>("Yes", delegate
					{
						FeedbackWindow.Instance.Show(FeedbackWindow.ReportTypes.Crash, null, false, false, versionOverride, files);
						File.Create(Path.Combine(dir2, "Checked.txt"));
						d.Window.Close();
					}), new KeyValuePair<string, Action>("No", delegate
					{
						File.Create(Path.Combine(dir2, "Checked.txt"));
						d.Window.Close();
					}), new KeyValuePair<string, Action>("Never", delegate
					{
						Options.SetAndSave("AskReporting", false);
						d.Window.Close();
					}));
					break;
				}
				File.Create(Path.Combine(dir2, "Checked.txt"));
			}
			else
			{
				File.Create(Path.Combine(dir2, "Checked.txt"));
			}
		}
	}

	public void OffsetSave(int offset)
	{
		if (MainMenuSaves.Length == 0)
		{
			CurrentSave = 0;
			return;
		}
		CurrentSave += offset;
		while (CurrentSave < 0)
		{
			CurrentSave = MainMenuSaves.Length + CurrentSave;
		}
		if (CurrentSave >= MainMenuSaves.Length)
		{
			CurrentSave %= MainMenuSaves.Length;
		}
		SaveGame saveGame = MainMenuSaves[CurrentSave];
		GameObject oldMap = MapObj;
		oldMap.transform.DOLocalMoveZ(-30 * offset, 0.2f).SetEase(Ease.InCubic).OnComplete(delegate
		{
			oldMap.GetComponentsInChildren<MeshFilter>().ForEachEnum(delegate(MeshFilter x)
			{
				if (x.sharedMesh.isReadable)
				{
					UnityEngine.Object.Destroy(x.sharedMesh);
				}
			});
			UnityEngine.Object.Destroy(oldMap);
		});
		MapObj = CreateMap(saveGame.Map);
		MapObj.transform.localPosition = new Vector3(0f, 0f, 30 * offset);
		MapObj.transform.DOLocalMoveZ(0f, 0.4f).SetEase(Ease.OutCubic);
		SaveName.text = saveGame.ActualName + "(" + (CurrentSave + 1) + "/" + MainMenuSaves.Length + ")";
	}

	public void TakePic()
	{
		StartCoroutine(SnapRoutine());
	}

	private IEnumerator SnapRoutine()
	{
		LoadingWait.SetActive(true);
		Canvas.ForceUpdateCanvases();
		SnapshotCamera.Render();
		yield return null;
		if (PictureTex != null)
		{
			UnityEngine.Object.Destroy(PictureTex);
		}
		int width = 1920;
		int height = 1080;
		try
		{
			width = Convert.ToInt32(ResWidth.text);
			height = Convert.ToInt32(ResHeight.text);
		}
		catch (Exception)
		{
		}
		if (!CheckSize(width, height))
		{
			LoadingWait.SetActive(false);
			WindowManager.SpawnDialog("PicTakingError".Loc(), true, DialogWindow.DialogType.Error);
			yield break;
		}
		PictureTex = new Texture2D(width, height, TextureFormat.RGB24, false);
		if (!SnapNow(PictureTex))
		{
			LoadingWait.SetActive(false);
			WindowManager.SpawnDialog("PicTakingError".Loc(), true, DialogWindow.DialogType.Error);
			yield break;
		}
		yield return null;
		if (Tweetable != null)
		{
			UnityEngine.Object.Destroy(Tweetable);
		}
		Tweetable = new Texture2D(1024, 512, TextureFormat.RGB24, false);
		if (!SnapNow(Tweetable))
		{
			LoadingWait.SetActive(false);
			WindowManager.SpawnDialog("PicTakingError".Loc(), true, DialogWindow.DialogType.Error);
		}
		else
		{
			LoadingWait.SetActive(false);
			ToggleImageSave();
		}
	}

	public void ChangeColor()
	{
		WindowManager.SpawnColorDialog(delegate(Color c)
		{
			SnapshotCamera.backgroundColor = c;
		}, SnapshotCamera.backgroundColor, new HashSet<Color> { SnapshotCamera.backgroundColor, defaultColor });
	}

	public void EndEditRes(bool main)
	{
		string value = (main ? ResWidth.text : ResHeight.text);
		int num = (main ? 1920 : 1080);
		try
		{
			num = Convert.ToInt32(value);
		}
		catch (Exception)
		{
		}
		if (main)
		{
			ResWidth.text = num.ToString();
		}
		else
		{
			ResHeight.text = num.ToString();
		}
	}

	private bool CheckSize(int width, int height)
	{
		int num = Mathf.Max(width, height);
		int num2 = width * height / 1024 * 32 / 1024;
		if (num2 < 0 || num > SystemInfo.maxTextureSize || num2 > SystemInfo.graphicsMemorySize - 256)
		{
			return false;
		}
		return true;
	}

	private bool SnapNow(Texture2D outputTex)
	{
		for (int i = 0; i < CamEffects.Length; i++)
		{
			CamEffects[i].enabled = true;
		}
		int num;
		for (num = 1; num <= 8; num *= 2)
		{
			int num2 = Mathf.Max(outputTex.width, outputTex.height) * num;
			int num3 = (outputTex.width * outputTex.height / 1024 * 32 * num * num * 2 + outputTex.width * outputTex.height / 1024 * 32) / 1024;
			if (num3 < 0 || num2 > SystemInfo.maxTextureSize || (float)num3 > (float)SystemInfo.graphicsMemorySize * 0.75f - 256f)
			{
				num /= 2;
				break;
			}
		}
		if (num < 1)
		{
			return false;
		}
		num = Mathf.Min(8, num);
		Debug.Log("Screenshot upscaling by " + num);
		ssr.enabled = SSRToggle.isOn;
		RenderTexture renderTexture = new RenderTexture(outputTex.width * num, outputTex.height * num, 24);
		renderTexture.Create();
		SnapshotCamera.targetTexture = renderTexture;
		SnapshotCamera.Render();
		SnapshotCamera.targetTexture = null;
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = renderTexture;
		Texture2D texture2D = new Texture2D(outputTex.width * num, outputTex.height * num, TextureFormat.RGB24, true);
		texture2D.ReadPixels(new Rect(0f, 0f, outputTex.width * num, outputTex.height * num), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		outputTex.SetPixels(texture2D.GetPixels(Mathf.RoundToInt(Mathf.Log(num, 2f))));
		outputTex.Apply();
		renderTexture.Release();
		UnityEngine.Object.Destroy(texture2D);
		for (int j = 0; j < CamEffects.Length; j++)
		{
			CamEffects[j].enabled = false;
		}
		return true;
	}

	public void SaveImage()
	{
		int num = 1;
		string text = Path.Combine(Utilities.GetRoot(), "Snaps");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		else
		{
			string[] files = Directory.GetFiles(text, "*.png");
			if (files.Length != 0)
			{
				num = files.Select(delegate(string x)
				{
					try
					{
						return Convert.ToInt32(Path.GetFileNameWithoutExtension(x).Replace("Pic", ""));
					}
					catch (Exception)
					{
						return 0;
					}
				}).Max() + 1;
			}
		}
		string file = Path.GetFullPath(Path.Combine(text, "Pic" + num + ".png"));
		File.WriteAllBytes(file, PictureTex.EncodeToPNG());
		if (SteamManager.Initialized)
		{
			DialogWindow diag = WindowManager.SpawnDialog();
			diag.Show("SteamImgQ".Loc(), false, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
			{
				SteamScreenshots.AddScreenshotToLibrary(file, null, PictureTex.width, PictureTex.height);
				diag.Window.Close();
			}), new KeyValuePair<string, Action>("No", delegate
			{
				diag.Window.Close();
			}));
		}
		ToggleImageSave();
	}

	public void ToggleImageSave()
	{
		SavePanel.SetActive(!SavePanel.activeSelf);
		if (SavePanel.activeSelf)
		{
			PictureShow.texture = PictureTex;
		}
	}

	private IEnumerator ChangeDisp()
	{
		int screenWidth = Screen.width;
		int screenHeight = Screen.height;
		int refresh = Screen.currentResolution.refreshRate;
		int num = (PlayerPrefs.HasKey("UnitySelectMonitor") ? PlayerPrefs.GetInt("UnitySelectMonitor") : 0);
		num = (num + 1) % Display.displays.Length;
		PlayerPrefs.SetInt("UnitySelectMonitor", num);
		Screen.SetResolution(800, 600, Screen.fullScreen, refresh);
		yield return null;
		Screen.SetResolution(screenWidth, screenHeight, Screen.fullScreen, refresh);
	}

	private void Update()
	{
		if (ScreenSaver.Valid && _screenSaverRunTime > 0f)
		{
			_screenSaverRunTime -= Time.deltaTime;
			if (_screenSaverRunTime <= 0f)
			{
				ScreenSaver.gameObject.SetActive(true);
				ScreenSaver.Reset();
			}
		}
		if (!PictureMode)
		{
			MapObj.transform.Rotate(0f, Time.deltaTime * 10f, 0f);
			Extra.shadows = (Options.MoreShadow ? LightShadows.Hard : LightShadows.None);
			return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			lastX = Input.mousePosition.x;
			lastRot = MapObj.transform.rotation.eulerAngles.y;
		}
		if (!GUICheck.OverGUI && Input.GetMouseButton(0))
		{
			MapObj.transform.rotation = Quaternion.Euler(0f, lastRot - (Input.mousePosition.x - lastX), 0f);
		}
	}
}
