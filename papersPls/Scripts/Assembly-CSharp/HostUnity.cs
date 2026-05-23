using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.U2D;
using app;
using app.ent;
using app.plat;
using app.vis;
using haxe.io;
using haxe.lang;

public class HostUnity : MonoBehaviour
{
	private class CachedTexture
	{
		public Texture2D texture;

		public Image image;

		public uint imageGeneration;

		public int lastUsedFrame;
	}

	public class TextureStats
	{
		public int added;

		public int removed;

		public int updated;

		public void Clear()
		{
		}
	}

	private class Monitor
	{
		public int width;

		public int height;

		public float dpi;

		public float deviceWidthInInches;

		public float deviceHeightInInches;

		public float aspect;

		public int aspectNum;

		public int aspectDen;

		public int refreshRate;

		public Resolution nativeRes;

		public override string ToString()
		{
			return null;
		}

		private PlatformKind getSuggestedHandheldPlatformKind()
		{
			return null;
		}

		public PlatformKind detectPlatformKind()
		{
			return null;
		}
	}

	private class UnityPlatformDisk : PlatformDisk
	{
		private TextAsset artAsset;

		private string saveDir;

		private Array availableLanguageCodes;

		public UnityPlatformDisk(TextAsset artAsset_, CommandLine commandLine)
			: base(default(EmptyObject))
		{
		}

		public override Bytes getAssetBytes(string name)
		{
			return null;
		}

		public override Array getAvailableLanguageCodes()
		{
			return null;
		}

		private string ToSaveFilepath(string name)
		{
			return null;
		}

		public override string getPersistentString(string name)
		{
			return null;
		}

		public override void setPersistentString(string name, string value)
		{
		}

		public override string getDocumentsDirectory()
		{
			return null;
		}
	}

	private class UnityPlatformSys : PlatformSys
	{
		public override void log(string text)
		{
		}

		public override double memUsage()
		{
			return 0.0;
		}

		public override void memFlush()
		{
		}

		public override void openUrl(string url)
		{
		}

		public override void setFullscreen(bool fullscreen)
		{
		}

		public override bool getFullscreen()
		{
			return false;
		}

		public override bool canExit()
		{
			return false;
		}

		public override string osName()
		{
			return null;
		}

		public override string defaultLanguageISO639_1()
		{
			return null;
		}

		public UnityPlatformSys()
			: base(default(EmptyObject))
		{
		}
	}

	private enum PauseState
	{
		None = 0,
		PausedByGame = 1,
		PausedByAppLostFocus = 2
	}

	private class UnityPlatformAudio : PlatformAudio
	{
		private GameObject go;

		private AudioMixer audioMixer;

		private AudioMixerGroup musicMixerGroup;

		private AudioMixerGroup effectsMixerGroup;

		private Dictionary<string, AudioClip> audioClipDict;

		private bool _canVibrate;

		private Queue<AudioSource> freeSources;

		private Dictionary<int, AudioSource> playingSources;

		private Dictionary<int, PauseState> playingPauseStates;

		public UnityPlatformAudio(AudioMixer audioMixer_, List<string> audioPaths, List<AudioClip> audioClips)
			: base(default(EmptyObject))
		{
		}

		public void Update()
		{
		}

		private PauseState GetPauseState(KeyValuePair<int, AudioSource> kvp)
		{
			return default(PauseState);
		}

		private void SetPauseState(KeyValuePair<int, AudioSource> kvp, PauseState pauseState)
		{
		}

		public void SetPauseForAppLostFocus(bool pauseForAppLostFocus)
		{
		}

		private void StopAndFree(AudioSource audioSource)
		{
		}

		private static bool IsPlayingOrPaused(AudioSource audioSource)
		{
			return false;
		}

		private static float ConvertVolume(float volume)
		{
			return 0f;
		}

		private AudioMixerGroup ToMixerGroup(int category)
		{
			return null;
		}

		public override void start(int playId, int category, string filename, bool loop, float volume)
		{
		}

		private AudioSource GetAudioSource(int playId)
		{
			return null;
		}

		public override void setVolume(int playId, float volume)
		{
		}

		public override float getPlayPosition(int playId)
		{
			return 0f;
		}

		public override void stop(int playId)
		{
		}

		public override void setCategoryPause(int category, bool pause)
		{
		}

		public override void setCategoryVolume(int category, float volume)
		{
		}

		public override void vibrate(int vibration)
		{
		}

		public override bool canVibrate()
		{
			return false;
		}
	}

	public MeshRenderer screenQuad;

	public Shader screenShader;

	public Shader screenPausedShader;

	public Shader quadShader;

	public TextAsset artAsset;

	public AudioMixer audioMixer;

	public List<string> audioPaths;

	public List<AudioClip> audioClips;

	public PixelPerfectCamera pixelPerfectCamera;

	public MeshRenderer phantomCursor;

	private IGame game;

	private app.ent.Input input;

	private HostState inputHostState;

	private RenderTexture target;

	private CommandBuffer commandBuffer;

	private Dictionary<uint, CachedTexture> textureCache;

	private Material quadMaterial;

	private UnityPlatformSys platformSys;

	private PlatformSocial platformSocial;

	private UnityPlatformAudio platformAudio;

	private UnityPlatformDisk platformDisk;

	private Platform platform;

	private QuadBatcher quadBatcher;

	private InputWrapper inputWrapper;

	private TextureStats textureStats;

	private CommandLine commandLine;

	private Texture phantomCursorTexture;

	private GameParams gameParams;

	private bool curFullscreen;

	private Monitor monitor;

	private Texture2D blankCursorTexture;

	private void Start()
	{
	}

	private void CreateGame(PlatformKind platformKind)
	{
	}

	private void setStretchFill(bool stretchFill)
	{
	}

	private bool getDeviceIsIpad()
	{
		return false;
	}

	private static PlatformKind detectPlatformKind(Monitor monitor)
	{
		return null;
	}

	private static bool findResolution(int wantW, int wantH, int wantRefreshRate, ref Resolution result)
	{
		return false;
	}

	private void applyDesktopScreenResolution()
	{
	}

	private void applyFrameSync()
	{
	}

	private void Update()
	{
	}

	private Texture2D getTexture(Image image)
	{
		return null;
	}

	public static Texture2D convertImageToTexture(Image image)
	{
		return null;
	}

	private static void adjustCommandLineForPlatform(CommandLine commandLine)
	{
	}
}
