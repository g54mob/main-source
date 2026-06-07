using UnityEngine;

public class FireTriggerScript : MonoBehaviour, ISaveObject
{
	public struct FireTriggerData
	{
		public bool DidFire;
	}

	public FireManagerScript Manager;

	private FireTriggerData MyData;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		MyData.DidFire = false;
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "FakeSubTag" && !MyData.DidFire)
		{
			MyData.DidFire = true;
			Manager.GrowFire = true;
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (FireTriggerData)dataIn;
	}
}
