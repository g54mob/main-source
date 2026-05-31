using UnityEngine;

[ExecuteAlways]
public class BuildingPipe3V2 : BuildingOutputV2
{
	public enum DirectionEnum
	{
		TopRight = 0,
		TopLeft = 1,
		BottomRight = 2,
		BottomLeft = 3
	}

	public DirectionEnum Direction;

	public BuildingOutputPartV2 TopRight;

	public BuildingOutputPartV2 TopLeft;

	public BuildingOutputPartV2 BottomRight;

	public BuildingOutputPartV2 BottomLeft;

	private void OnValidate()
	{
		switch (Direction)
		{
		case DirectionEnum.TopRight:
			CurrentPart = TopRight;
			break;
		case DirectionEnum.TopLeft:
			CurrentPart = TopLeft;
			break;
		case DirectionEnum.BottomRight:
			CurrentPart = BottomRight;
			break;
		case DirectionEnum.BottomLeft:
			CurrentPart = BottomLeft;
			break;
		}
		TopRight.gameObject.SetActive(value: false);
		TopLeft.gameObject.SetActive(value: false);
		BottomRight.gameObject.SetActive(value: false);
		BottomLeft.gameObject.SetActive(value: false);
		CurrentPart.gameObject.SetActive(value: true);
	}

	private void Start()
	{
		switch (Direction)
		{
		case DirectionEnum.TopRight:
			SetCanThrow(canThrow: true);
			break;
		case DirectionEnum.TopLeft:
			SetCanThrow(canThrow: false);
			break;
		case DirectionEnum.BottomRight:
			SetCanThrow(canThrow: true);
			break;
		case DirectionEnum.BottomLeft:
			SetCanThrow(canThrow: false);
			break;
		}
	}

	protected override Vector3 GetForce()
	{
		return Direction switch
		{
			DirectionEnum.TopRight => new Vector3(Random.Range(0.5f, 3f), 0f, 0f), 
			DirectionEnum.TopLeft => new Vector3(0f - Random.Range(0.5f, 3f), 0f, 0f), 
			DirectionEnum.BottomRight => new Vector3(Random.Range(0.5f, 3f), 0f, 0f), 
			DirectionEnum.BottomLeft => new Vector3(0f - Random.Range(0.5f, 3f), 0f, 0f), 
			_ => base.GetForce(), 
		};
	}

	private void Update()
	{
	}
}
