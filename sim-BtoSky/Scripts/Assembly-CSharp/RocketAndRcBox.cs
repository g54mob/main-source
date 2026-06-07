using System;

public class RocketAndRcBox : DeliveryBox
{
	public enum Type
	{
		RocketBox = 0,
		RcBox = 1
	}

	public Type type;

	public static event Action OnRocketBoxInteracted;

	public static event Action OnRcBoxInteracted;

	public override void Interact()
	{
		base.Interact();
		if (type == Type.RocketBox)
		{
			RocketAndRcBox.OnRocketBoxInteracted?.Invoke();
		}
		else
		{
			RocketAndRcBox.OnRcBoxInteracted?.Invoke();
		}
	}
}
