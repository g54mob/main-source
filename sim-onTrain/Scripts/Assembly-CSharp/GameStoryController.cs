using UnityEngine;

public class GameStoryController : MonoBehaviour
{
	public bool isStartedFirst = true;

	public Transform defaultStartPosition;

	public Transform trainStartPosition;

	private void Start()
	{
		Singleton<ES3SaveManager>.Instance.OnGameSave.AddListener(SaveData);
		Singleton<ES3SaveManager>.Instance.OnGameLoad.AddListener(LoadData);
		LoadData();
	}

	public void LoadData()
	{
		isStartedFirst = Singleton<ES3SaveManager>.Instance.LoadData("isStartedFirst", defaultValue: true);
	}

	public void SaveData()
	{
		Singleton<ES3SaveManager>.Instance.SaveData("isStartedFirst", isStartedFirst);
	}
}
