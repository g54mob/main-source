using UnityEngine;

public class InteractionTool : ToolBase
{
	public Texture2D handCursor;

	private BaseComponent selectedComp;

	private readonly int compMask;

	private Ray ray;

	private RaycastHit hit;

	private bool interactDown;

	public override void ResetTool()
	{
	}

	public override void Update()
	{
	}
}
