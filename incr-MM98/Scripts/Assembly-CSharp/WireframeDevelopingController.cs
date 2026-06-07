using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshBarycentricBaker))]
public class WireframeDevelopingController : MonoBehaviour
{
	private const string WireframeShaderName = "MMO98/WireframeDeveloping";

	private static readonly int FillProgressId = Shader.PropertyToID("_FillProgress");

	private static readonly int FillYMinId = Shader.PropertyToID("_FillYMin");

	private static readonly int FillYMaxId = Shader.PropertyToID("_FillYMax");

	private static readonly int WireColorId = Shader.PropertyToID("_WireColor");

	private static readonly int FillColorId = Shader.PropertyToID("_FillColor");

	private static readonly int WireThicknessId = Shader.PropertyToID("_WireThickness");

	[SerializeField]
	[Range(0f, 1f)]
	private float fillProgress;

	[SerializeField]
	[ColorUsage(true, true)]
	private Color wireColor = new Color(0f, 1f, 0.2f, 1f);

	[SerializeField]
	[ColorUsage(true, true)]
	private Color fillColor = new Color(0f, 0.4f, 0.1f, 0.85f);

	[SerializeField]
	[Range(0.001f, 0.15f)]
	private float wireThickness = 0.008f;

	private Material _sharedMaterial;

	private List<Renderer> _renderers = new List<Renderer>();

	private Bounds _localBounds;

	private void Awake()
	{
		CollectRenderers();
		BuildSharedMaterial();
		ApplyMaterialToRenderers();
		RecalculateBounds();
		UpdateBoundsOnMaterial();
		_sharedMaterial?.SetFloat(FillProgressId, fillProgress);
	}

	public void SetFillProgress(float progress)
	{
		fillProgress = Mathf.Clamp01(progress);
		_sharedMaterial?.SetFloat(FillProgressId, fillProgress);
	}

	public float GetFillProgress()
	{
		return fillProgress;
	}

	public void RefreshAfterMeshChange()
	{
		GetComponent<MeshBarycentricBaker>().BakeMeshes();
		CollectRenderers();
		ApplyMaterialToRenderers();
		RecalculateBounds();
		UpdateBoundsOnMaterial();
		_sharedMaterial?.SetFloat(FillProgressId, fillProgress);
	}

	private void CollectRenderers()
	{
		_renderers.Clear();
		GetComponentsInChildren(includeInactive: true, _renderers);
	}

	private void BuildSharedMaterial()
	{
		Shader shader = Shader.Find("MMO98/WireframeDeveloping");
		if (shader == null)
		{
			Debug.LogError("[WireframeDevelopingController] Shader 'MMO98/WireframeDeveloping' not found.", this);
			return;
		}
		_sharedMaterial = new Material(shader)
		{
			name = "WireframeDeveloping_Instance"
		};
		ApplyInspectorSettingsToMaterial();
	}

	private void ApplyMaterialToRenderers()
	{
		if (_sharedMaterial == null)
		{
			return;
		}
		foreach (Renderer renderer in _renderers)
		{
			Material[] array = new Material[renderer.sharedMaterials.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _sharedMaterial;
			}
			renderer.sharedMaterials = array;
		}
	}

	private void ApplyInspectorSettingsToMaterial()
	{
		if (!(_sharedMaterial == null))
		{
			_sharedMaterial.SetColor(WireColorId, wireColor);
			_sharedMaterial.SetColor(FillColorId, fillColor);
			_sharedMaterial.SetFloat(WireThicknessId, wireThickness);
		}
	}

	private void RecalculateBounds()
	{
		if (_renderers.Count != 0)
		{
			Bounds localBounds = new Bounds(_renderers[0].bounds.center, _renderers[0].bounds.size);
			for (int i = 1; i < _renderers.Count; i++)
			{
				localBounds.Encapsulate(_renderers[i].bounds);
			}
			_localBounds = localBounds;
		}
	}

	private void UpdateBoundsOnMaterial()
	{
		if (!(_sharedMaterial == null))
		{
			_sharedMaterial.SetFloat(FillYMinId, _localBounds.min.y);
			_sharedMaterial.SetFloat(FillYMaxId, _localBounds.max.y);
		}
	}

	private void OnDestroy()
	{
		if (_sharedMaterial != null)
		{
			Object.Destroy(_sharedMaterial);
		}
	}
}
