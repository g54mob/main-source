using UnityEngine;

public class OxygenTriggerScript : MonoBehaviour, ISaveObject
{
	public struct SteamTriggerData
	{
		public bool Did;
	}

	private OxIndicatorScript Ox;

	private SteamTriggerData MyData;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		Ox = GameObject.Find("OxygenIndicator").GetComponent<OxIndicatorScript>();
		MyData.Did = false;
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "FakeSubTag" && !MyData.Did)
		{
			MyData.Did = true;
			Ox.SetIndicator();
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
