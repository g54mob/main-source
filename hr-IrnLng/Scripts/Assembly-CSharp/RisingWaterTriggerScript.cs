using UnityEngine;

public class RisingWaterTriggerScript : MonoBehaviour, ISaveObject
{
	public struct RiseTriggerData
	{
		public bool Did;
	}

	public RisingWaterScript Rise;

	private RiseTriggerData MyData;

	public int MyGoal;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
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
			Rise.TriggerWater(MyGoal);
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (RiseTriggerData)dataIn;
	}
}
