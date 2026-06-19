using ClockStone;
using UnityEngine;

public class GUIManagerTitleScreen : GUIManagerBase
{
	public GameObject fileSelectGUI;

	protected override void Initialize()
	{
		base.Initialize();
	}

	public void Preload(SceneManagerBase.PreloadCallback callback)
	{
		callback();
	}

	public void OnLoadingScreenLifted()
	{
	}

	public void ShowFileSelectGUI()
	{
		Object.Instantiate(fileSelectGUI);
		SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>().OnEnterFileSelect();
	}

	protected override void UpdateFunctionality()
	{
		base.UpdateFunctionality();
	}
}
