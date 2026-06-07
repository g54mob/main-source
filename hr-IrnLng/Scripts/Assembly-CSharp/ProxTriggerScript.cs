using UnityEngine;

public class ProxTriggerScript : MonoBehaviour, ISaveObject
{
	public struct ProxTriggerData
	{
		public bool DidSound;
	}

	private ProxTriggerData MyData;

	public int Sensor;

	public float ProxTime;

	private SubEffectsScript SubE;

	public RemoteSoundScript Sound;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		SubE = GameObject.Find("SubEffects").GetComponent<SubEffectsScript>();
		MyData.DidSound = false;
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "FakeSubTag" && !MyData.DidSound)
		{
			MyData.DidSound = true;
			SubE.SetProx(ProxTime, Sensor);
			if ((bool)Sound)
			{
				Sound.TriggerSound();
			}
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (ProxTriggerData)dataIn;
	}
}
