using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScrollRectInitializerContext : InitializerContext<ScrollRect>
{
	public ScrollRectInitializerContext OnValueChanged(UnityAction<Vector2> callback)
	{
		Target.onValueChanged.AddListener(callback);
		return this;
	}
}
