using UnityEngine;

public class SettingsMenu : Menu
{
	public UIButton resButton;

	public Checkbox checkboxFullscreen;

	public Checkbox checkboxScreenShake;

	public Checkbox checkboxStretch;

	public SettingsSlider sfxVol;

	public SettingsSlider musicVol;

	public SpriteRenderer items;

	public SaveManager.GameSave saveData => Dungeon.Instance.saveManager.saveData;

	public SaveManager.VideoPrefs videoPrefs => Dungeon.Instance.saveManager.saveData.videoPrefs;

	public void ReadSliders(SettingsSlider slider)
	{
		if (slider == sfxVol)
		{
			saveData.sfxScale = sfxVol.val;
			Dungeon.Instance.audioManager.sfxScale = saveData.sfxScale * 10f;
		}
		if (slider == musicVol)
		{
			saveData.musicScale = musicVol.val;
			Dungeon.Instance.audioManager.musicScale = saveData.musicScale * 10f;
		}
		Dungeon.Instance.saveManager.SaveGame();
	}

	public override void BounceButton(UIButton b, int f = 2, bool silent = false)
	{
		if (f == 1)
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f, 0.8f);
		}
		else
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.9f, 0.5f);
		}
		base.BounceButton(b, f, silent);
	}

	private void Start()
	{
		Dungeon.Instance.audioManager.sfxScale = saveData.sfxScale * 10f;
		Dungeon.Instance.audioManager.musicScale = saveData.musicScale * 10f;
		items.sprite = Dungeon.Instance.currentLocale.settingsItems;
		sfxVol.Preset(saveData.sfxScale);
		musicVol.Preset(saveData.musicScale);
		resButton.GetComponent<SpriteRenderer>().sprite = Dungeon.Instance.currentLocale.resolutionText[videoPrefs.resolution];
		checkboxFullscreen.Set(videoPrefs.fullscreen, silent: true);
		checkboxScreenShake.Set(saveData.screenshake, silent: true);
		checkboxStretch.Set(videoPrefs.stretch, silent: true);
	}

	public void SetFullscreen(bool x)
	{
		videoPrefs.fullscreen = x;
		Dungeon.Instance.saveManager.SetScreen();
		Dungeon.Instance.saveManager.SaveGame();
	}

	public void SetScreenshake(bool x)
	{
		saveData.screenshake = x;
		Dungeon.Instance.saveManager.SaveGame();
	}

	public void SetStretch(bool x)
	{
		videoPrefs.stretch = x;
		Dungeon.Instance.saveManager.SetScreen();
		Dungeon.Instance.saveManager.SaveGame();
	}

	public void IncrementResolution(int x)
	{
		int resolution = videoPrefs.resolution;
		videoPrefs.resolution = Mathf.Clamp(videoPrefs.resolution + x, -1, SaveManager.resList.Length);
		if (videoPrefs.resolution == -1)
		{
			videoPrefs.resolution = SaveManager.resList.Length - 1;
		}
		if (videoPrefs.resolution == SaveManager.resList.Length)
		{
			videoPrefs.resolution = 0;
		}
		resButton.GetComponent<SpriteRenderer>().sprite = Dungeon.Instance.currentLocale.resolutionText[videoPrefs.resolution];
		Dungeon.Instance.mainmenu.ShowResolutionConfirm(resolution);
		Dungeon.Instance.saveManager.SetScreen();
	}
}
