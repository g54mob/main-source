using UnityEngine;

public abstract class UITooltipContent : MonoBehaviour
{
	public virtual float Spacing => 0f;

	public abstract float Height { get; }
}
