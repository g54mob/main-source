using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OutlineRenderController : MonoBehaviour
{
	[Header("Outline GameObjects")]
	[Tooltip("If true, when the renderer has submeshes (meaning multiple materials), the submeshes will also be rendered to the outline buffer.")]
	public bool IncludeSubMeshes;

	[Tooltip("The list of gameobjects that we want to exclude from the outlines.")]
	public List<GameObject> OutlineExcludeObjects = new List<GameObject>();

	[Header("Outline State")]
	private bool _isOutlineEnabled;

	[ConditionalHide("IsOutlineEnabled")]
	private bool _isHighlightEnabled;

	[Header("Outline Rendering")]
	[Tooltip("Material used for rendering, if NULL the default rendering material is used.")]
	[SerializeField]
	private Material _renderingMaterial;

	public List<Renderer> OutlineRenderers { get; private set; } = new List<Renderer>();

	public bool IsOutlineEnabled { get; private set; }

	public bool IsHighlightEnabled { get; private set; }

	private void Awake()
	{
		SetupOutlineRenderingCommandBuffer();
		SetOutlineEnabled(_isOutlineEnabled);
		SetHighlightEnabled(_isHighlightEnabled);
	}

	private void OnEnable()
	{
		OutlineRenderManager.Instance.RegisterOutlineRenderController(this);
	}

	private void OnDisable()
	{
		OutlineRenderManager.Instance.UnregisterOutlineRenderController(this);
	}

	public void SetupOutlineRenderingCommandBuffer()
	{
		if (base.name.Contains("OUTLINED"))
		{
			return;
		}
		OutlineRenderers.Clear();
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
		foreach (Renderer renderer in componentsInChildren)
		{
			if (!OutlineRenderers.Contains(renderer) && !OutlineExcludeObjects.Contains(renderer.gameObject))
			{
				OutlineRenderers.Add(renderer);
			}
		}
		base.name += "_OUTLINED";
	}

	public void EnableOutline()
	{
		SetOutlineEnabled(enabled: true);
	}

	public void DisableOutline()
	{
		SetOutlineEnabled(enabled: false);
	}

	public void ToggleOutline()
	{
		SetOutlineEnabled(!IsOutlineEnabled);
	}

	public void SetOutlineEnabled(bool enabled)
	{
		IsOutlineEnabled = enabled;
	}

	public void EnableHighlightOutline()
	{
		SetHighlightEnabled(enabled: true);
	}

	public void DisableHighlightOutline()
	{
		SetHighlightEnabled(enabled: false);
	}

	public void ToggleHighlightOutline()
	{
		SetHighlightEnabled(!IsHighlightEnabled);
	}

	public void SetHighlightEnabled(bool enabled)
	{
		IsHighlightEnabled = enabled;
	}

	public void FillBuffer(OutlinePass outlinePass, bool isHighlight, RasterCommandBuffer targetCommandBuffer)
	{
		if (!IsOutlineEnabled || isHighlight != IsHighlightEnabled)
		{
			return;
		}
		Material material = ReturnRenderMaterial(outlinePass);
		foreach (Renderer outlineRenderer in OutlineRenderers)
		{
			if (!outlineRenderer.isVisible)
			{
				continue;
			}
			if (IncludeSubMeshes)
			{
				int num = outlineRenderer.sharedMaterials.Length;
				for (int i = 0; i < num; i++)
				{
					targetCommandBuffer.DrawRenderer(outlineRenderer, material, i);
				}
			}
			else
			{
				targetCommandBuffer.DrawRenderer(outlineRenderer, material);
			}
		}
	}

	private Material ReturnRenderMaterial(OutlinePass outlinePass)
	{
		Material material = outlinePass.ReturnRenderingMaterial(IsHighlightEnabled);
		if (_renderingMaterial == null)
		{
			return material;
		}
		_renderingMaterial.SetColor(outlinePass.OutlineColorMatId, material.GetColor(outlinePass.OutlineColorMatId));
		return _renderingMaterial;
	}

	public void ExcludeParticles()
	{
		ParticleSystem[] componentsInChildren = base.gameObject.GetComponentsInChildren<ParticleSystem>(includeInactive: true);
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			OutlineExcludeObjects.Add(particleSystem.gameObject);
		}
	}

	public void ExcludeBoundaries()
	{
		VisualBoundary[] componentsInChildren = base.gameObject.GetComponentsInChildren<VisualBoundary>(includeInactive: true);
		foreach (VisualBoundary visualBoundary in componentsInChildren)
		{
			OutlineExcludeObjects.Add(visualBoundary.gameObject);
		}
	}
}
