using UnityEngine;

public class LightControlScript : MonoBehaviour, ISaveObject
{
	public struct LightControlData
	{
		public bool LightOff;
	}

	private LightControlData MyData;

	public Material EmergencyMat;

	public GameObject MainLight;

	public Renderer Bulb;

	public GameObject EmergencyLight;

	public string MyID => base.gameObject.name + base.transform.position.ToString();

	private void Start()
	{
		MyData.LightOff = false;
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		if (MyData.LightOff)
		{
			MainLight.SetActive(value: false);
			EmergencyLight.SetActive(value: true);
			Bulb.material = EmergencyMat;
		}
	}

	public void Activate()
	{
		MyData.LightOff = true;
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (LightControlData)dataIn;
	}
}
