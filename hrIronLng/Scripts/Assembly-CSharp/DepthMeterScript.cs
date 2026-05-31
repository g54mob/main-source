using UnityEngine;

public class DepthMeterScript : MonoBehaviour, ISaveObject
{
	public struct DepthData
	{
		public float CurrentLerp;
	}

	private DepthData MyData;

	public Vector2 Positions;

	public Transform Indicator;

	public string MyID => "Depth_Meter";

	private void Start()
	{
		MyData.CurrentLerp = 0f;
	}

	private void Update()
	{
	}

	public void IncreaseLerp(float f)
	{
		MyData.CurrentLerp += f;
		if (MyData.CurrentLerp > 1f)
		{
			MyData.CurrentLerp = 1f;
		}
		if (MyData.CurrentLerp < 0f)
		{
			MyData.CurrentLerp = 0f;
		}
	}

	private void FixedUpdate()
	{
		Indicator.localPosition = new Vector3(Indicator.localPosition.x, Mathf.Lerp(Positions.x, Positions.y, MyData.CurrentLerp), Indicator.localPosition.z);
	}

	public object SaveData()
	{
		return MyData;
	}

	public void LoadData(object dataIn)
	{
		MyData = (DepthData)dataIn;
	}
}
