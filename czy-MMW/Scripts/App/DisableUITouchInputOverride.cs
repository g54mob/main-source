using UnityEngine;

public class DisableUITouchInputOverride : BaseInputOverride
{
	public override int touchCount => 0;

	public override Touch GetTouch(int index)
	{
		return default(Touch);
	}
}
