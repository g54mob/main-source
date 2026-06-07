using UnityEngine;
using UnityEngine.Rendering;

public class ShadowTest : MonoBehaviour
{
	private CommandBuffer cb;

	public RenderTexture m_ShadowmapCopy;

	[ContextMenu("Stop shadow thing")]
	public void Stop()
	{
		GetComponent<Light>().RemoveCommandBuffer(LightEvent.AfterShadowMap, cb);
	}

	private void Start()
	{
		cb = new CommandBuffer();
		RenderTargetIdentifier renderTargetIdentifier = BuiltinRenderTextureType.CurrentActive;
		m_ShadowmapCopy = new RenderTexture(128, 128, 16, RenderTextureFormat.R8);
		m_ShadowmapCopy.filterMode = FilterMode.Point;
		cb.SetShadowSamplingMode(renderTargetIdentifier, ShadowSamplingMode.RawDepth);
		RenderTargetIdentifier renderTargetIdentifier2 = new RenderTargetIdentifier(m_ShadowmapCopy);
		cb.Blit(renderTargetIdentifier, renderTargetIdentifier2);
		cb.SetGlobalTexture("m_ShadowmapCopy", renderTargetIdentifier2);
		GetComponent<Light>().AddCommandBuffer(LightEvent.AfterShadowMap, cb);
		CommandBuffer commandBuffer = new CommandBuffer();
		commandBuffer.SetShadowSamplingMode(renderTargetIdentifier, ShadowSamplingMode.RawDepth);
		commandBuffer.SetGlobalTexture("m_ShadowmapCopy", renderTargetIdentifier2);
		commandBuffer.Blit(renderTargetIdentifier2, renderTargetIdentifier);
		GetComponent<Light>().AddCommandBuffer(LightEvent.AfterShadowMapPass, commandBuffer);
	}
}
