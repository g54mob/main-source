using UnityEngine;

public static class UnityLayerHelper
{
	public static int ToLayer(this LayerMask layer)
	{
		int num = layer.value;
		int num2 = ((num <= 0) ? 31 : 0);
		while (num > 1)
		{
			num >>= 1;
			num2++;
		}
		return num2;
	}
}
