using System.Collections.Generic;
using UnityEngine.Rendering;

public class SelectionOutlineSystem
{
	private static SelectionOutlineSystem m_Instance;

	private readonly List<SelectionOutlineObj> objectsToDraw;

	public static SelectionOutlineSystem Instance => null;

	public void Register(SelectionOutlineObj objToAdd)
	{
	}

	public void Deregister(SelectionOutlineObj objToRemove)
	{
	}

	public void PopulateCommandBuffer(CommandBuffer commandBuffer)
	{
	}
}
