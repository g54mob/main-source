using UnityEngine;

public class TeleportTriggerScript : MonoBehaviour, ISaveObject
{
	public struct TeleportTriggerData
	{
		public bool Did;
	}

	private TeleportTriggerData MyData;

	public Vector2 TeleportCoors;

	private GameObject FakeSub;

	private MyMouseLook Mouse;

	public AudioSource TeleportSound;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		MyData.Did = false;
		FakeSub = GameObject.Find("FakeSub");
		Mouse = GameObject.Find("PlayerCamera").GetComponent<MyMouseLook>();
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "FakeSubTag" && !MyData.Did)
		{
			FakeSub.transform.position = new Vector3(TeleportCoors.x, FakeSub.transform.position.y, TeleportCoors.y);
			Mouse.RumbleAmount = 10f;
			TeleportSound.Play();
			MyData.Did = true;
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (TeleportTriggerData)dataIn;
	}
}
