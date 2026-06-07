using UnityEngine;

public static class DelegateUtl
{
	public delegate void NoArgsEvent();

	public delegate void FloatChangedEvent(float prevValue, float newValue);

	public delegate void IntChangedEvent(int prevValue, int newValue);

	public delegate void IntEvent(int val);

	public delegate void LongEvent(long val);

	public delegate void ColorEvent(Color c);

	public delegate void ResourceEvent(ResourceType rt);

	public delegate CoolSelectable DirEvent(CardinalDir dir);

	public delegate void CoolButtonEvent(CoolButton btn);

	public delegate void CoolButtonChangedEvent(CoolButton btn1, CoolButton btn2);

	public delegate bool BoolReturnEvent();

	public delegate bool BuildingBoolReturnEvent(BuildingInst b);

	public delegate bool BoolReturnEventPos(int x, int y);
}
