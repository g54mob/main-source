using UnityEngine;

public class SoundTriggerScript : MonoBehaviour, ISaveObject
{
	public struct SoundTriggerData
	{
		public bool DidSound;
	}

	public AudioSource MySound;

	private SoundTriggerData MyData;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
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
			MySound.Play();
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (SoundTriggerData)dataIn;
	}
}
