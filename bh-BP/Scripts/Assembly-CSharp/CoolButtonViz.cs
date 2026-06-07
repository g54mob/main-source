using UnityEngine;
using UnityEngine.UI;

public class CoolButtonViz : ScriptableObject
{
	public virtual void Init(Graphic g)
	{
	}

	public virtual void ApplyViz(CoolButtonState btnState, Graphic img)
	{
	}

	public virtual float GetDepth(CoolButtonState btnState)
	{
		return 0f;
	}
}
