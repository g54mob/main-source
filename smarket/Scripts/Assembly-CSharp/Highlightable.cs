using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
	[SerializeField]
	private List<Renderer> m_RenderersToHighlight;

	private bool m_Highlighted;

	public List<Renderer> RenderersToHighlight => null;

	public bool Highlighted
	{
		set
		{
		}
	}

	public void ClearRenderers()
	{
	}

	public void AddOrRemoveRenderer(Renderer[] renderers, bool add)
	{
	}
}
