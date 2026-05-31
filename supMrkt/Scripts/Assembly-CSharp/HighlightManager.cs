using EPOOutline;
using UnityEngine;

public class HighlightManager : NoktaSingleton<HighlightManager>
{
	[SerializeField]
	[ColorUsage(true, true)]
	private Color m_OutlineColor;

	private Highlightable m_CurrentHighligtedObject;

	public Highlightable CurrentHighligtedObject => null;

	public void SetHighlight(Highlightable highlightable, PlayerInstance playerInstance)
	{
	}

	public void SetHighlight(Highlightable highlightable, float alpha)
	{
	}

	public void AddOrRemoveRenderer(Renderer renderer, bool add)
	{
	}

	public void AddOrRemoveRenderer(Renderer[] renderers, bool add)
	{
	}

	private void AddRendererTarget(Outlinable outline, Renderer renderer)
	{
	}

	private void AddRendererTarget(Outlinable outline, Renderer renderer, float alpha)
	{
	}

	private void ModifyRendererTarget(Outlinable outline, Renderer renderer, float alpha)
	{
	}
}
