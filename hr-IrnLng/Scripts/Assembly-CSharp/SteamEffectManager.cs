using UnityEngine;

public class SteamEffectManager : MonoBehaviour, ISaveObject
{
	public struct SteamManagerData
	{
		public bool[] Active;
	}

	private SteamManagerData MyData;

	public GameObject[] Steam;

	public AudioSource[] Burst;

	public string MyID => "Steam_Manager";

	private void Start()
	{
		MyData.Active = new bool[Steam.Length];
	}

	private void Update()
	{
	}

	public void ActivateSteam(int i)
	{
		MyData.Active[i] = true;
		Steam[i].SetActive(value: true);
		Burst[i].Play();
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (SteamManagerData)dataIn;
	}
}
