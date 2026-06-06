using UnityEngine;

public class EnumFlagAttribute : PropertyAttribute
{
	public int FirstValueIndex;

	public EnumFlagAttribute(int firstValueIndex = 0)
	{
		FirstValueIndex = firstValueIndex;
	}
}
