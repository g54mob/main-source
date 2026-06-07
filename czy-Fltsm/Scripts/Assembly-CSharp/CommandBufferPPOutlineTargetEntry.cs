using System;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
public class CommandBufferPPOutlineTargetEntry
{
	public bool IsHighlighted;

	public CommandBuffer TargetCommandBuffer;

	public RenderTargetIdentifier TargetRenderTargetIdentifier;

	public RenderTexture TargetRenderTexture;

	public RenderTargetIdentifier BasicShapeRenderTargetIdentifier;

	public RenderTexture BasicShapeRenderTexture;

	public CommandBufferPPOutlineTargetEntry(bool isHighlighted)
	{
		IsHighlighted = isHighlighted;
		if (TargetCommandBuffer == null)
		{
			TargetCommandBuffer = new CommandBuffer();
			TargetCommandBuffer.name = "OutlineCommandBuffer_" + (isHighlighted ? "Highlighted" : "Standard");
		}
	}
}
