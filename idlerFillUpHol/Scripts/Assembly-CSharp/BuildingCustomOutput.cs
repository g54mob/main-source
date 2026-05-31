public class BuildingCustomOutput : BuildingOutputV2
{
	public enum StateEnum
	{
		WithDust = 0,
		WithoutDust = 1
	}

	public StateEnum State;

	private void Start()
	{
		SetCanThrow(canThrow: true);
		SetIsThrowing(isThrowing: true);
		switch (State)
		{
		case StateEnum.WithDust:
			SetCanHaveDust(canHaveDust: true);
			break;
		case StateEnum.WithoutDust:
			SetCanHaveDust(canHaveDust: false);
			break;
		}
	}
}
