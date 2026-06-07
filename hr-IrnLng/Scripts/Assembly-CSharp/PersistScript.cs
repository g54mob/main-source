using UnityEngine;
using UnityEngine.Audio;

public class PersistScript : MonoBehaviour
{
	public bool DoLoad;

	public string LoadName = "";

	public bool vsync;

	public int resx = 640;

	public int resy = 480;

	public float sensitivity = 1f;

	public bool invert;

	public int fov = 65;

	public float vol = 1f;

	public int fullscreen = 2;

	public int cap = 144;

	public AudioMixer Mixer;

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ApplySettings()
	{
		if (vsync)
		{
			QualitySettings.vSyncCount = 1;
		}
		else
		{
			QualitySettings.vSyncCount = 0;
		}
		FullScreenMode fullscreenMode = FullScreenMode.FullScreenWindow;
		if (fullscreen == 0)
		{
			fullscreenMode = FullScreenMode.Windowed;
		}
		if (fullscreen == 1)
		{
			fullscreenMode = FullScreenMode.ExclusiveFullScreen;
		}
		if (fullscreen == 2)
		{
			fullscreenMode = FullScreenMode.FullScreenWindow;
		}
		int num = resx;
		int num2 = resy;
		if (num == -1)
		{
			num = (resx = Display.main.systemWidth);
		}
		if (num2 == -1)
		{
			num2 = (resy = Display.main.systemHeight);
		}
		Screen.SetResolution(num, num2, fullscreenMode);
		Mixer.SetFloat("MasterVolume", TranslateVolume(vol));
		Application.targetFrameRate = cap;
	}

	public float TranslateVolume(float vol)
	{
		float num = vol;
		if (num < 0.001f)
		{
			num = 0.001f;
		}
		if (num > 1f)
		{
			num = 1f;
		}
		return Mathf.Log(num) * 20f;
	}
}
