using System.Collections.Generic;
using UnityEngine;

public class DokoDemoPainterPaintable : MonoBehaviour
{
	private class TextureProcessor
	{
		private class PenData
		{
			public RenderTexture rtOldPos;

			public RenderTexture rtHist;

			public int lastDrawn;

			public float lastTime;

			private float lastOpacity;

			private float lastStrength;

			private Color lastColor;

			private bool lastSmoothTip;

			private float lastSmoothTipExp;

			public bool checkPrevPainted(float strength, float opacity, Color color, bool prevPainted, bool smoothTip, float smoothTipExp)
			{
				return false;
			}
		}

		private class DrawCommand
		{
			public int penId;

			public RenderTexture rtPos;

			public Color color;

			public float maxDist;

			public bool preserveAlpha;

			public bool smoothTip;

			public float smoothTipExp;

			public float width;

			public float strength;

			public float opacity;

			public float fade;

			public bool prevPainted;

			public bool historyDecay;

			public float historyDecayTime;

			public Texture2D stampTexture;

			public Vector2 stampPixelSize;

			public float stampAngle;

			public Vector2 stampScaleFactor;

			public float stampOpacity;

			public bool enableTint;

			public Color tintColor;

			public Vector4 tintStrength;
		}

		public int renderQueue;

		private int id;

		private Texture2D tex;

		private Material targetMaterial;

		private RenderTexture rtCurrent;

		private Texture rtOriginal;

		private Dictionary<int, PenData> pens;

		public TextureProcessor(Material mat, Texture2D persistingTexture, bool defer)
		{
		}

		~TextureProcessor()
		{
		}

		private bool ensureTextures(int penId)
		{
			return false;
		}

		private void runShader(DrawCommand dc)
		{
		}

		public void draw(int penId, RenderTexture rtPos, Color color, float maxDist, bool preserveAlpha, bool smoothTip, float smoothTipExp, float widthPx, float opacity, float fadeAmount, bool prevPainted, bool historyDecay, float historyDecayTime)
		{
		}

		public void Fade(float fadeAmount)
		{
		}

		public void erase(int penId, RenderTexture rtPos, float maxDist, bool smoothTip, float smoothTipExp, float widthPx, float strength, float fadeAmount, bool prevPainted, bool historyDecay, float historyDecayTime)
		{
		}

		public void stampAt(RenderTexture rtPos, bool preserveAlphaStamp, Vector2 stampScaleFactor, Texture2D stampTexture, Vector2 stampPixelSize, float stampAngle, float stampOpacity, bool enableTint, Color tintColor, Vector4 tintStrength, float fadeAmount)
		{
		}

		private void DiscardRenderTexture(RenderTexture rt)
		{
		}

		public void maintainPens()
		{
		}

		private Texture2D PrepareTextureForExport(Texture tex)
		{
			return null;
		}

		public byte[] ToPNG()
		{
			return null;
		}

		public byte[] ToJPG()
		{
			return null;
		}

		public byte[] origToPNG()
		{
			return null;
		}

		public int getID()
		{
			return 0;
		}
	}

	public const string PaintableLayerName = "Paintable";

	[Header("Pen settings")]
	[Tooltip("The pixel size of a pen is multiplied by this value. This can be used to adjust line thickness on surfaces with a different scale.")]
	public float radiusFactor;

	[Tooltip("Pen opacity is multiplied by this value. Values other than 1.0 might slightly reduce performance.")]
	public float penOpacityFactor;

	[Tooltip("The pixel size of a pen in eraser mode is multiplied by this value. This can be used to adjust line thickness on surfaces with a different scale.")]
	public float eraserRadiusFactor;

	[Tooltip("Pen opacity in eraser mode is multiplied by this value. Values other than 1.0 might slightly reduce performance.")]
	public float eraserOpacityFactor;

	[Tooltip("When this flag is enabled, the target texture's transparency value will be preserved. Otherwise the pen color's alpha value will be painted.")]
	public bool preserveAlphaPen;

	[Header("Stamp settings")]
	[Tooltip("Each dimension of the stamp's size will be multiplied by the corresponding scale factor.")]
	public Vector2 stampScaleFactor;

	[Tooltip("When this flag is enabled, the target texture's transparency value will be preserved. Otherwise the stamp color's alpha value will be painted. Alpha values from tints will still take precedence.")]
	public bool preserveAlphaStamp;

	[Header("Paint fading")]
	[Tooltip("This value sets much should paint should fade towards the original color over a given time. A value of 0 disables fading. A value of 1 would completely erase everything that was painted after fadeTimeSeconds.")]
	public float fadeFactor;

	[Tooltip("This value sets how much time needs to pass until colors fade by fadeFactor.")]
	public float fadeTimeSeconds;

	[Tooltip("This value sets how often fading should be applied. When fading small amounts over long times, making this value higher can prevent fades from being too small to actually change color values. If this value is below fadeTimeSeconds, the fading process will be applied in small steps. If this value is above fadeTimeSeconds, the texture will get faded less often but with values higher than fadeFactor.")]
	public float fadeIntervalSeconds;

	[Header("Texture saving")]
	[Tooltip("This field allows specifying a unique name of this object that will be included in saved texture filenames. This is useful when multiple DokoDemoPainterPaintable objects with the same GameObject name exist, as they would overwrite each others' textures.")]
	public string uniqueName;

	[Tooltip("This flag determines whether to load previously saved textures on initialization. The last fade time will also be loaded.")]
	public bool persistent;

	[Tooltip("If this flag is enabled, filenames will include a timestamp, which will lead to old copies being kept. When this flag is enabled, no timestamp is included and textures will be overwritten.")]
	public bool keepOld;

	[Tooltip("When this flag is enabled, Application.persistentDataPath will be prepended to the path set in savePath.")]
	public bool prependAppDir;

	[Tooltip("This path sets the directory to which textures should be written. If it is empty, no textures will be saved. If necessary, the directory will be created.")]
	public string savePath;

	[Header("Advanced settings")]
	[Tooltip("For every DokoDemoPainterPaintable object instance and every material on it, multiple textures need to be allocated. This can use a lot of VRAM. Enabling this flag will defer texture allocation for these materials on this object until this object comes within painting range. Texture allocation might lead to slight lag at that point in time.")]
	public bool deferTextureAllocation;

	[Tooltip("This value sets the maximum distance in pixels between the start and end points of line segments. If you encounter strange lines appearing on your texture while drawing quickly, lower this value. If you notice gaps in your line while drawing quickly, increase this value. If both happens, try to rearrange your UV map in such a way that line segments between connected parts of the texture will not pass through other parts of it.")]
	public float maxDistance;

	[Tooltip("When this list has a size of 0, all materials with a set main texture will be paintable. Otherwise only materials in slots corresponding to those given in this list will be paintable. This list is only processed at initialization. Use this to: 1) Protect certain materials from being painted or stamped. 2) Reduce the number of paintable materials to increase performance. 3) Set different settings for different materials by having multiple DokoDemoPainterPaintable components with non-overlapping whitelists.")]
	public List<int> materialIndexWhitelist;

	private bool historyDecay;

	private float historyDecayTime;

	private int id;

	private Renderer paintableRenderer;

	private Material[] materials;

	private Shader[] shaders;

	private TextureProcessor[] tps;

	private bool uvMode;

	private bool wasUV;

	private bool painted;

	private bool fadedNow;

	private int oldLayer;

	private int previouslyPainted;

	private double lastFadeTime;

	private static int layer;

	private static Material texProcMat;

	private static int lastTPId;

	private static Dictionary<int, TextureProcessor> tpIDMap;

	private static int lastId;

	private static Dictionary<int, DokoDemoPainterPaintable> idMap;

	private static bool ensureTextureProcessor()
	{
		return false;
	}

	private static int registerTP(TextureProcessor tp)
	{
		return 0;
	}

	private static void deregisterTP(int id)
	{
	}

	private static int registerPaintable(DokoDemoPainterPaintable p)
	{
		return 0;
	}

	private static void deregisterPaintable(int id)
	{
	}

	public static bool setGlobalUVMode(bool mode, Plane[] planes)
	{
		return false;
	}

	public static void globalPaintAt(int penId, RenderTexture rtPos, Color color, bool smoothTip, float smoothTipExp, float radius, float opacity, bool erase)
	{
	}

	public static void globalStampAt(RenderTexture rtPos, Texture2D stampTexture, Vector2 stampPixelSize, float stampAngle, float stampOpacity, bool enableTint, Color tintColor, Vector4 tintStrength)
	{
	}

	private double getTimestamp()
	{
		return 0.0;
	}

	private void OnEnable()
	{
	}

	public bool setUVMode(bool mode, Plane[] planes)
	{
		return false;
	}

	private float getFade()
	{
		return 0f;
	}

	public void paintAt(int penId, RenderTexture rtPos, Color color, bool smoothTip, float smoothTipExp, float radius, float opacity, bool erase)
	{
	}

	public void stampAt(RenderTexture rtPos, Texture2D stampTexture, Vector2 stampPixelSize, float stampAngle, float stampOpacity, bool enableTint, Color tintColor, Vector4 tintStrength)
	{
	}

	private void LateUpdate()
	{
	}

	public byte[] ToJPG()
	{
		return null;
	}

	public void ErasePainting()
	{
	}

	public void OnDestroy()
	{
	}

	public void OnApplicationQuit()
	{
	}
}
