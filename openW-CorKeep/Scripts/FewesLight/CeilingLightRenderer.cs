using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CeilingLightRenderer : MonoBehaviour
{
	[ClearOnReload(true)]
	public static readonly HashSet<CeilingLightRenderer> instancesBottom = new HashSet<CeilingLightRenderer>();

	[ClearOnReload(true)]
	public static readonly HashSet<CeilingLightRenderer> instancesMid = new HashSet<CeilingLightRenderer>();

	[ClearOnReload(true)]
	public static readonly HashSet<CeilingLightRenderer> instancesTop = new HashSet<CeilingLightRenderer>();

	public CeilingLightRenderOrderPass renderOrderPass;

	private Renderer m_renderer;

	public void Draw(CommandBuffer cmd)
	{
		cmd.DrawRenderer(m_renderer, m_renderer.material);
	}

	private void Awake()
	{
		m_renderer = GetComponent<Renderer>();
	}

	public void SetRenderOrderPass(CeilingLightRenderOrderPass ceilingLightRenderOrderPass)
	{
		RemoveCeilingLight();
		renderOrderPass = ceilingLightRenderOrderPass;
		AddCeilingLight();
	}

	private void OnEnable()
	{
		AddCeilingLight();
	}

	private void OnDisable()
	{
		RemoveCeilingLight();
	}

	private void RemoveCeilingLight()
	{
		switch (renderOrderPass)
		{
		case CeilingLightRenderOrderPass.BOTTOM:
			instancesBottom.Remove(this);
			break;
		case CeilingLightRenderOrderPass.MIDDLE:
			instancesMid.Remove(this);
			break;
		case CeilingLightRenderOrderPass.TOP:
			instancesTop.Remove(this);
			break;
		}
	}

	private void AddCeilingLight()
	{
		switch (renderOrderPass)
		{
		case CeilingLightRenderOrderPass.BOTTOM:
			instancesBottom.Add(this);
			break;
		case CeilingLightRenderOrderPass.MIDDLE:
			instancesMid.Add(this);
			break;
		case CeilingLightRenderOrderPass.TOP:
			instancesTop.Add(this);
			break;
		}
	}
}
