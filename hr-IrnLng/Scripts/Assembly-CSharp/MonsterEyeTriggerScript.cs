using UnityEngine;

public class MonsterEyeTriggerScript : MonoBehaviour, ISaveObject
{
	public struct EyeTriggerData
	{
		public bool DidEye;
	}

	private EyeTriggerData MyData;

	private SubController Cont;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		MyData.DidEye = false;
		Cont = GameObject.Find("FakeSub").GetComponent<SubController>();
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "FakeSubTag" && !MyData.DidEye)
		{
			MyData.DidEye = true;
			Cont.DoingEye = true;
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (EyeTriggerData)dataIn;
	}
}
