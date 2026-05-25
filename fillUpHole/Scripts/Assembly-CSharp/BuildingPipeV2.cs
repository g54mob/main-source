using UnityEngine;

[ExecuteAlways]
public class BuildingPipeV2 : BuildingOutputV2
{
	public enum DirectionEnum
	{
		RightDown = 0,
		RightUp = 1,
		LeftDown = 2,
		LeftUp = 3
	}

	public DirectionEnum Direction;

	public BuildingOutputPartV2 RightDown;

	public BuildingOutputPartV2 RightUp;

	public BuildingOutputPartV2 LeftDown;

	public BuildingOutputPartV2 LeftUp;

	private void OnValidate()
	{
		switch (Direction)
		{
		case DirectionEnum.RightDown:
			CurrentPart = RightDown;
			break;
		case DirectionEnum.RightUp:
			CurrentPart = RightUp;
			break;
		case DirectionEnum.LeftDown:
			CurrentPart = LeftDown;
			break;
		case DirectionEnum.LeftUp:
			CurrentPart = LeftUp;
			break;
		}
		RightDown.gameObject.SetActive(value: false);
		RightUp.gameObject.SetActive(value: false);
		LeftDown.gameObject.SetActive(value: false);
		LeftUp.gameObject.SetActive(value: false);
		CurrentPart.gameObject.SetActive(value: true);
	}

	private void Start()
	{
		switch (Direction)
		{
		case DirectionEnum.RightDown:
			SetCanThrow(canThrow: false);
			break;
		case DirectionEnum.RightUp:
			SetCanThrow(canThrow: true);
			break;
		case DirectionEnum.LeftDown:
			SetCanThrow(canThrow: false);
			break;
		case DirectionEnum.LeftUp:
			SetCanThrow(canThrow: true);
			break;
		}
	}

	protected override Vector3 GetForce()
	{
		return Direction switch
		{
			DirectionEnum.RightDown => new Vector3(0f, 0f, 0f), 
			DirectionEnum.RightUp => new Vector3(0f, 3f, 0f), 
			DirectionEnum.LeftDown => new Vector3(0f, 0f, 0f), 
			DirectionEnum.LeftUp => new Vector3(0f, 3f, 0f), 
			_ => base.GetForce(), 
		};
	}

	private void Update()
	{
	}
}
