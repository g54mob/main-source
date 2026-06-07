using System;
using DV.Utils;
using UnityEngine;

[ExecuteAfter(typeof(CameraSmoothing))]
public class NonVRLineRendererController : MonoBehaviour
{
	private const float DISTANCE_FROM_CAMERA = 3f;

	public float lineWidthStart = 0.005f;

	public float lineWidthEnd = 0.02f;

	public Material lineMaterial;

	[NonSerialized]
	public Transform attentionTransform;

	[NonSerialized]
	public Transform sourceTransform;

	[NonSerialized]
	public GameObject owner;

	[NonSerialized]
	public Canvas canvas;

	private LineRenderer line;

	private int hiddenFrames;

	private int frozenFrames;

	private Vector3 cachedPosition = Vector3.zero;

	public bool IsVisible => line.enabled;

	private void Start()
	{
		line = base.gameObject.AddComponent<LineRenderer>();
		line.startWidth = lineWidthStart;
		line.endWidth = lineWidthEnd;
		if (lineMaterial != null)
		{
			line.material = lineMaterial;
		}
	}

	public void FreezePosition(int frames)
	{
		frozenFrames = Mathf.Max(frames, frozenFrames);
	}

	public void ShowAfter(int frames)
	{
		hiddenFrames = Mathf.Max(frames, hiddenFrames);
	}

	private void LateUpdate()
	{
		if (PlayerManager.PlayerCamera == null)
		{
			return;
		}
		if (attentionTransform == null || sourceTransform == null || (owner != null && !owner.activeInHierarchy) || hiddenFrames > 0)
		{
			if (hiddenFrames > 0)
			{
				hiddenFrames--;
			}
			line.enabled = false;
			return;
		}
		line.enabled = true;
		Vector3 position = RectTransformUtility.PixelAdjustPoint((frozenFrames > 0) ? cachedPosition : sourceTransform.position, sourceTransform, canvas);
		position.z = 3f;
		position = PlayerManager.ActiveCamera.ScreenToWorldPoint(position);
		cachedPosition = sourceTransform.position;
		Vector3 position2 = (attentionTransform.position - PlayerManager.ActiveCamera.transform.position).normalized * 3f + PlayerManager.ActiveCamera.transform.position;
		line.SetPosition(0, position);
		line.SetPosition(1, position2);
		if (frozenFrames > 0)
		{
			frozenFrames--;
		}
	}
}
