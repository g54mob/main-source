using System;
using UnityEngine;

public class SniperShot : MonoBehaviour
{
	private const float startSize = 0.06f;

	private const float endSize = 0.03f;

	[NonSerialized]
	public Color32 beginColor;

	[NonSerialized]
	public Color finishColor;

	[NonSerialized]
	public Color32 beginColor2;

	[NonSerialized]
	public Color finishColor2;

	public const float FADE_TIME = 0.7f;

	private Mesh mesh;

	private Color32[] colors;

	public bool mverseSimulated;

	private float runningTime;

	public void Create(Vector3 start, Vector3 end)
	{
	}

	public void SetColors(Color32 c, Color32 c2)
	{
	}

	public void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
