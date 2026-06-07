using UnityEngine;

public class CheckpointTriggerScript : MonoBehaviour
{
	public struct CheckpointTriggerData
	{
		public bool Did;
	}

	private CheckpointTriggerData MyData;

	private SaveLoadManagerScript Save;

	private float SaveDelay = 1f;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		MyData.Did = false;
		Save = GameObject.Find("GameManager").GetComponent<SaveLoadManagerScript>();
	}

	private void Update()
	{
		SaveDelay -= Time.deltaTime;
		if (SaveDelay < 0f)
		{
			SaveDelay = 0f;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "FakeSubTag" && !MyData.Did && SaveDelay <= 0f)
		{
			MyData.Did = true;
			other.GetComponent<SubController>().LastCheckpointPosition = base.transform.position;
			Save.ActivateCheckpoint();
		}
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (CheckpointTriggerData)dataIn;
	}
}
