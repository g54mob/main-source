using UnityEngine;

[ExecuteAlways]
public class BuildingPipe2V2 : BuildingOutputV2
{
	public enum DirectionEnum
	{
		Up = 0,
		Down = 1,
		Right = 2,
		Left = 3
	}

	public DirectionEnum Direction;

	public BuildingOutputPartV2 Up;

	public BuildingOutputPartV2 Down;

	public BuildingOutputPartV2 Right;

	public BuildingOutputPartV2 Left;

	private void OnValidate()
	{
		switch (Direction)
		{
		case DirectionEnum.Up:
			CurrentPart = Up;
			break;
		case DirectionEnum.Down:
			CurrentPart = Down;
			break;
		case DirectionEnum.Right:
			CurrentPart = Right;
			break;
		case DirectionEnum.Left:
			CurrentPart = Left;
			break;
		}
		Up.gameObject.SetActive(value: false);
		Down.gameObject.SetActive(value: false);
		Right.gameObject.SetActive(value: false);
		Left.gameObject.SetActive(value: false);
		CurrentPart.gameObject.SetActive(value: true);
	}

	private void Start()
	{
		switch (Direction)
		{
		case DirectionEnum.Up:
			SetCanThrow(canThrow: true);
			break;
		case DirectionEnum.Down:
			SetCanThrow(canThrow: false);
			break;
		case DirectionEnum.Right:
			SetCanThrow(canThrow: true);
			break;
		case DirectionEnum.Left:
			SetCanThrow(canThrow: false);
			break;
		}
	}

	protected override Vector3 GetForce()
	{
		return Direction switch
		{
			DirectionEnum.Up => new Vector3(Random.Range(-1f, 1f), 6f, 0f), 
			DirectionEnum.Down => new Vector3(0f, 0f, 0f), 
			DirectionEnum.Right => new Vector3(Random.Range(0.5f, 3f), 0f, 0f), 
			DirectionEnum.Left => new Vector3(0f - Random.Range(0.5f, 3f), 0f, 0f), 
			_ => base.GetForce(), 
		};
	}

	private void Update()
	{
	}
}
