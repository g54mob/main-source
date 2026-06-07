using System.Collections.Generic;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;

public abstract class BuildablePreview
{
	private Buildable _buildable;

	private VisualPrefabPreviewSettings _previewSettings;

	public int VisualIndex { get; private set; }

	public Transform Transform { get; private set; }

	public VisualPrefab Visual { get; private set; }

	public List<Transform> OutlineCorners { get; private set; }

	public Polygon Polygon { get; private set; }

	public BuildablePreview(Buildable buildable, VisualPrefabPreviewSettings previewSettings, int visualIndex)
	{
		Transform = new GameObject("Buildable Preview").transform;
		VisualIndex = buildable.ReturnVisualIndex(visualIndex);
		OutlineCorners = ListPool<Transform>.Get(buildable.Properties.Outline.Length);
		_buildable = buildable;
		_previewSettings = previewSettings;
		Visual = _previewSettings.InstantiatePreview(buildable.ReturnVisual(VisualIndex));
		Visual.transform.SetParent(Transform.transform, worldPositionStays: true);
		Visual.transform.Reset();
		for (int i = 0; i < buildable.Properties.Outline.Length; i++)
		{
			AddOutlineCorner(buildable.Properties.Outline[i].Vector3TopDown(), i);
		}
		Polygon = new Polygon();
		Polygon.Initialize(Transform.transform, OutlineCorners);
		Polygon.FastUpdate();
	}

	public void SetValid(bool isValid)
	{
		_previewSettings.SetValid(Visual, isValid);
		if (_buildable.Properties.VisualMatchesTownheartOrientation)
		{
			Visual.transform.forward = Community.PlayerCommunity.Engine.transform.forward;
		}
	}

	public virtual void Destroy()
	{
		Object.Destroy(Transform.gameObject);
	}

	private void AddOutlineCorner(Vector3 localPosition, int index)
	{
		GameObject gameObject = new GameObject("PreviewCorner_" + index);
		gameObject.transform.SetParent(Transform);
		gameObject.transform.Reset();
		gameObject.transform.localPosition = localPosition;
		OutlineCorners.Add(gameObject.transform);
	}
}
