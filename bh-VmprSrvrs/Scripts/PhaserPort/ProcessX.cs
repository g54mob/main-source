public class ProcessX
{
	private static BaseBody body1;

	private static BaseBody body2;

	private static bool body1Pushable;

	private static bool body2Pushable;

	private static float body1MassImpact;

	private static float body2MassImpact;

	private static float body1FullImpact;

	private static float body2FullImpact;

	private static bool body1MovingLeft;

	private static bool body1MovingRight;

	private static bool body1Stationary;

	private static bool body2MovingLeft;

	private static bool body2MovingRight;

	private static bool body2Stationary;

	private static bool body1OnLeft;

	private static bool body2OnLeft;

	private static float overlap;

	public static int Set(BaseBody b1, BaseBody b2, float ov)
	{
		return 0;
	}

	public static int BlockCheck()
	{
		return 0;
	}

	public static bool Check()
	{
		return false;
	}

	public static bool Run(int side)
	{
		return false;
	}

	public static void RunImmovableBody1(int blockedState)
	{
	}

	public static void RunImmovableBody2(int blockedState)
	{
	}
}
