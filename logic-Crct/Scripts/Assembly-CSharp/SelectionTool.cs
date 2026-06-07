using UnityEngine;

public class SelectionTool : ToolBase
{
	private BaseComponent selectedComp;

	private readonly int compMask;

	private Ray ray;

	private RaycastHit hit;

	public override void ResetTool()
	{
	}

	public override void Update()
	{
	}
}
