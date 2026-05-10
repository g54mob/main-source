using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CanvasInstance : LODInstance
{
	private Canvas m_Canvas;

	private void Awake()
	{
	}

	public override void SetAvailability(bool b)
	{
	}
}
