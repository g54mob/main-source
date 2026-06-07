using System.Collections.Generic;
using Data.Variables;
using UnityEngine;

public class ShowInHeatmap : MonoBehaviour
{
	private class MeshRendMaterials
	{
		public MeshRenderer MeshRenderer;

		public List<Material> BaseMaterials;

		public Material HeatmapMaterial;

		public MeshRendMaterials(MeshRenderer rend, Material[] rendSharedMaterials, Material instancedHeatmapMat)
		{
			MeshRenderer = rend;
			BaseMaterials = new List<Material>();
			foreach (Material item in rendSharedMaterials)
			{
				BaseMaterials.Add(item);
			}
			HeatmapMaterial = instancedHeatmapMat;
		}

		public void SetHeatmap(bool toggle)
		{
			if (toggle)
			{
				Material[] materials = MeshRenderer.materials;
				for (int i = 0; i < materials.Length; i++)
				{
					materials[i] = HeatmapMaterial;
				}
				MeshRenderer.materials = materials;
			}
			else
			{
				MeshRenderer.SetSharedMaterials(BaseMaterials);
			}
		}
	}

	[SerializeField]
	private MonoBehaviour _objectView;

	[Header("Heatmap")]
	[SerializeField]
	private List<MeshRenderer> _trackedMeshRenderers = new List<MeshRenderer>();

	[SerializeField]
	private Material _heatmapMaterial;

	[SerializeField]
	private BoolVariableSO _heatMapIsOn;

	private readonly Queue<bool> _lastActivities = new Queue<bool>(10);

	private readonly List<MeshRendMaterials> _meshRenderers = new List<MeshRendMaterials>();

	private const int TRACKED_ACTIVITIES_AMOUNT = 10;

	private static readonly int _baseMap = Shader.PropertyToID("_BaseMap");

	private static readonly int _heatmap = Shader.PropertyToID("_heatmap");

	private ITrackActivity _trackActivity;

	private void OnEnable()
	{
		ResetHeatmap();
		if (_objectView != null && _objectView is IHeatmapView heatmapView)
		{
			_trackActivity = heatmapView.GetTrackActivity();
			if (_trackActivity != null)
			{
				_trackActivity.OnActivityStart.RegisterMainThread(StartActivity);
				_trackActivity.OnActivityEnd.RegisterMainThread(EndActivity);
			}
			else
			{
				heatmapView.OnInit += OnHeatmapInit;
			}
		}
		_heatMapIsOn.ValueChanged += OnHeatmapToggle;
		foreach (MeshRenderer trackedMeshRenderer in _trackedMeshRenderers)
		{
			if (!(trackedMeshRenderer.sharedMaterial == null) && trackedMeshRenderer.sharedMaterial.HasProperty(_baseMap))
			{
				Material material = Object.Instantiate(_heatmapMaterial);
				material.SetTexture(_baseMap, trackedMeshRenderer.sharedMaterial.GetTexture(_baseMap));
				_meshRenderers.Add(new MeshRendMaterials(trackedMeshRenderer, trackedMeshRenderer.sharedMaterials, material));
			}
		}
		OnHeatmapToggle(_heatMapIsOn.Value);
	}

	private void OnHeatmapInit()
	{
		if (_objectView is IHeatmapView heatmapView)
		{
			heatmapView.OnInit -= OnHeatmapInit;
			OnEnable();
		}
	}

	private void OnDisable()
	{
		ResetHeatmap();
	}

	private void ResetHeatmap()
	{
		if (_trackActivity != null)
		{
			_trackActivity.OnActivityStart.UnRegisterMainThread(StartActivity);
			_trackActivity.OnActivityEnd.UnRegisterMainThread(EndActivity);
		}
		_heatMapIsOn.ValueChanged -= OnHeatmapToggle;
		OnHeatmapToggle(toggle: false);
	}

	private void OnHeatmapToggle(bool toggle)
	{
		foreach (MeshRendMaterials meshRenderer in _meshRenderers)
		{
			meshRenderer.SetHeatmap(toggle);
		}
		if (toggle && _trackActivity != null)
		{
			UpdateHeatmapColor();
		}
	}

	private void StartActivity()
	{
		UpdateActivity(success: true);
	}

	private void EndActivity()
	{
		UpdateActivity(success: false);
	}

	private void UpdateActivity(bool success)
	{
		if (_lastActivities.Count >= 10)
		{
			_lastActivities.Dequeue();
		}
		_lastActivities.Enqueue(success);
		if (_heatMapIsOn.Value)
		{
			UpdateHeatmapColor();
		}
	}

	private void UpdateHeatmapColor()
	{
		float num = 10f;
		foreach (bool lastActivity in _lastActivities)
		{
			if (!lastActivity)
			{
				num -= 1f;
			}
		}
		num /= 10f;
		foreach (MeshRendMaterials meshRenderer in _meshRenderers)
		{
			meshRenderer.HeatmapMaterial.SetFloat(_heatmap, num);
		}
	}
}
