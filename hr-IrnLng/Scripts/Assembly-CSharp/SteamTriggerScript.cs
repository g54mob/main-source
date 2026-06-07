using UnityEngine;

public class SteamTriggerScript : MonoBehaviour, ISaveObject
{
	public struct SteamTriggerData
	{
		public bool DidSteam;
	}

	public SteamEffectManager Manager;

	private SteamTriggerData MyData;

	public int MySteam;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		MyData.DidSteam = false;
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "FakeSubTag" && !MyData.DidSteam)
		{
			MyData.DidSteam = true;
			Manager.ActivateSteam(MySteam);
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (SteamTriggerData)dataIn;
	}
}
