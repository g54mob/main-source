using System;
using UnityEngine;

[RequireComponent(typeof(SuperTextMesh))]
public class STMSketchify : MonoBehaviour
{
	public SuperTextMesh stm;

	[Range(0.001f, 8f)]
	public float sketchDelay = 0.25f;

	private float sketchLastTime = -1f;

	public float sketchAmount = 0.025f;

	private Vector3[] storedOffsets = new Vector3[0];

	public bool unscaledTime = true;

	public void Reset()
	{
		stm = GetComponent<SuperTextMesh>();
	}

	private void Awake()
	{
		sketchLastTime = -1f;
	}

	private void OnEnable()
	{
		stm.OnVertexMod += SketchifyVerts;
	}

	private void OnDisable()
	{
		stm.OnVertexMod -= SketchifyVerts;
	}

	public void SketchifyVerts(Vector3[] verts, Vector3[] middles, Vector3[] positions)
	{
		if (storedOffsets.Length != verts.Length)
		{
			Array.Resize(ref storedOffsets, verts.Length);
			int i = 0;
			for (int num = verts.Length; i < num; i++)
			{
				storedOffsets[i].x = UnityEngine.Random.Range(0f - sketchAmount, sketchAmount);
				storedOffsets[i].y = UnityEngine.Random.Range(0f - sketchAmount, sketchAmount);
				storedOffsets[i].z = UnityEngine.Random.Range(0f - sketchAmount, sketchAmount);
			}
		}
		float num2 = Mathf.Floor((unscaledTime ? Time.unscaledTime : Time.time) / sketchDelay) * sketchDelay;
		if (num2 != sketchLastTime)
		{
			sketchLastTime = num2;
			if (storedOffsets.Length != verts.Length)
			{
				Array.Resize(ref storedOffsets, verts.Length);
			}
			int j = 0;
			for (int num3 = verts.Length; j < num3; j++)
			{
				storedOffsets[j].x = UnityEngine.Random.Range(0f - sketchAmount, sketchAmount);
				storedOffsets[j].y = UnityEngine.Random.Range(0f - sketchAmount, sketchAmount);
				storedOffsets[j].z = UnityEngine.Random.Range(0f - sketchAmount, sketchAmount);
			}
		}
		int k = 0;
		for (int num4 = verts.Length; k < num4; k++)
		{
			verts[k].x += storedOffsets[k].x;
			verts[k].y += storedOffsets[k].y;
			verts[k].z += storedOffsets[k].z;
		}
	}
}
