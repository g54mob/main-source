using System;
using System.Collections.Generic;
using Moments.Encoder;
using UTJ.FrameCapturer;
using UnityEngine;
using UnityEngine.UI;

public class GameRecorderViewer : MonoBehaviour
{
	private class IFrame
	{
		public int frameNumber;

		public byte[] cellData;

		public GameRecorderViewerUnit.Vault[] units;
	}

	public GameObject unitPrefab;

	public Camera cam;

	public GIFExportPanel gifExportPanel;

	public RectTransform markImage;

	public GameObject autoPlayImagePlaying;

	public GameObject autoPlayImagePaused;

	public Slider slider;

	public Toggle lowSpeedToggle;

	public Toggle medSpeedToggle;

	public Toggle hiSpeedToggle;

	public Text timeText;

	public Text pausedTime;

	public Text commandScore;

	public Text energyStore;

	public Text energyDeficit;

	public Text energyStoreDeficitTitleText;

	public Image energyStoreDeficitImage;

	public Text ultracStore;

	public Text anticreeperStore;

	public Text argStore;

	public Text lifticStore;

	public Texture2DArray unitsTextureArray;

	public Material unitMaterial;

	private Mesh mesh;

	private MeshFilter meshFilter;

	[NonSerialized]
	public GameRecorder recorder;

	private byte[] cellData;

	private Vector2[] uv;

	private Color32[] colors;

	private float manualScale;

	private float pad;

	private Dictionary<int, GameRecorderViewerUnit> units;

	private HashSet<GameRecorderViewerUnit> deathUnits;

	private int _currentFrame;

	[NonSerialized]
	public Dictionary<string, int> unitTAPositions;

	private int iframeInterval;

	private List<IFrame> iframes;

	public static int textureArrayDepth;

	public static int textureArraySize;

	private bool _autoPlay;

	private bool ignoreSlider;

	private bool suspendAutoPlay;

	private int frameCount;

	private Vector3 panMouseDown;

	private Vector3 panMouseDownStartPos;

	private float keydownTime;

	private const float KEYREPEAT = 0.5f;

	private bool _makingGif;

	private bool initialized;

	[NonSerialized]
	public int markLeftPos;

	[NonSerialized]
	public int markRightPos;

	private float posToSet;

	public Color landColor;

	public Color[] creeperColor;

	public Color[] acColor;

	public Color crimsonColor;

	private Color32 SPECIAL_COLOR_BREEDER;

	private Color32 SPECIAL_COLOR_ACBREEDER;

	private Color32 SPECIAL_COLOR_FLIPBREEDER;

	private Color32 SPECIAL_COLOR_ABSORBER;

	private Color32 SPECIAL_COLOR_MESH_OFF;

	private Color32 SPECIAL_COLOR_MESH_ON;

	private Color32 SPECIAL_COLOR_SHATTEREDLAND;

	private Color32 SPECIAL_COLOR_CONTAMINANT;

	private Color32 SPECIAL_COLOR_CORRUPTION;

	private Color32 SPECIAL_COLOR_RESOURCE;

	private int customUnitPos;

	public int[] char0;

	public int[] char1;

	public int[] char2;

	public int[] char3;

	public int[] char4;

	public int[] char5;

	public int[] char6;

	public int[] char7;

	public int[] char8;

	public int[] char9;

	public int[] charC;

	public int[] charUnknown;

	private int CHAR_WIDTH;

	private int CHAR_HEIGHT;

	private Color32 CHAR_ON_COLOR;

	private Color32 CHAR_OFF_COLOR;

	private int totalGifCounter;

	private Moments.Encoder.GifEncoder gif_encoder;

	private Camera gif_renderCam;

	private RenderTexture gif_renderTexture;

	private Texture2D gif_tex;

	private int gif_w;

	private int gif_h;

	private Transform gif_tmpParent;

	private int gif_tmpLayer;

	private Vector3 gif_tmpPos;

	private int gifFrameCount;

	private MovieEncoder m_encoder;

	private int currentFrame
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private bool autoPlay
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool makingGif
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private static void AddToTextureArray(Texture2DArray ta, int i, Transform model, bool setIsBuilding = false)
	{
	}

	private static void AddDualToTextureArray(Texture2DArray ta, int i, Transform model, Transform model2, bool setIsBuilding = false)
	{
	}

	private static void AddToTextureArrayTexture(Texture2DArray ta, int i, Texture2D tex)
	{
	}

	public static void CreateTextureArray()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void ReStart()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	private void EnforcePositionBounds()
	{
	}

	private void FrameAdvance()
	{
	}

	private void FrameRewind()
	{
	}

	public void LateUpdate()
	{
	}

	private void DestroyDeathUnits(bool force = false)
	{
	}

	private void Init()
	{
	}

	public void LoadCustomImagesFromRecorder()
	{
	}

	public void OnMarkLeft()
	{
	}

	public void OnMarkRight()
	{
	}

	public void OnResetMarks()
	{
	}

	private void DrawMarkBar()
	{
	}

	public void OnResetView()
	{
	}

	public void OnPlay()
	{
	}

	public void OnSliderDown()
	{
	}

	public void OnSliderUp()
	{
	}

	public void OnSlider(float pos)
	{
	}

	private void SetPosition()
	{
	}

	private void SeekToFrame(int frame)
	{
	}

	private float GetCellDataUVX(byte val)
	{
		return 0f;
	}

	private Color32 GetCellDataColor(byte cellData)
	{
		return default(Color32);
	}

	private void SetCellDataColor(int loc, byte val)
	{
	}

	private void SetUnitImage(GameRecorderViewerUnit grvu, string unitType)
	{
	}

	private void SetUnitImage(GameRecorderViewerUnit grvu, int unitTypePos)
	{
	}

	private void Reset()
	{
	}

	private void ResetToIFrame(IFrame iframe)
	{
	}

	public bool ApplyFrame()
	{
		return false;
	}

	private void ApplyCellRecords(List<GameRecorder.CellRecord> cellRecords)
	{
	}

	private void ApplyUnitRecords(List<GameRecorder.UnitRecord> unitRecords)
	{
	}

	private void CreateIFrame(int currentFrame)
	{
	}

	public void AddCustomUnitImage(string unitType, Texture2D texture)
	{
	}

	private int[] GetChar(char c)
	{
		return null;
	}

	private void WriteTimeString(int frame, Color32[] pixels, int pixelsWidth)
	{
	}

	private void DrawChar(int[] data, int posX, Color32[] pixels, int pixelsWidth)
	{
	}

	private void WriteTimeStringRaw(int frame, byte[] data, int pixelsWidth)
	{
	}

	private void DrawCharRaw(int[] charData, int posX, byte[] data, int pixelsWidth)
	{
	}

	private bool CreateGifFrame()
	{
		return false;
	}

	private void FinishGIF()
	{
	}

	public void OnCreateGIF(string filename)
	{
	}

	public void OnAbortGif()
	{
	}

	public static string GetTimeString(float sec, bool onlySec = false)
	{
		return null;
	}

	public static string GetTimeStringNoFrac(float sec)
	{
		return null;
	}
}
