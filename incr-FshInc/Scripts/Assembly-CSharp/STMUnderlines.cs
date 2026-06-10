using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SuperTextMesh))]
public class STMUnderlines : MonoBehaviour
{
	public SuperTextMesh superTextMesh;

	[HideInInspector]
	public List<SpriteRenderer> allStrikethrus = new List<SpriteRenderer>();

	[HideInInspector]
	public List<SpriteRenderer> allUnderlines = new List<SpriteRenderer>();

	[Header("Underline & Strikethru")]
	public SpriteRenderer linePrefab;

	[Header("Underline")]
	public Vector3 underlineDistance = new Vector3(0.02f, -0.15f, 0f);

	public float underlineWidth = 0.666667f;

	public float underlineThickness = 0.1f;

	public Color underlineColor = Color.white;

	[Header("Strikethru")]
	[Range(0f, 1f)]
	public float strikethruHeight = 0.3f;

	public float strikethruWidth = 0.666667f;

	public float strikethruThickness = 0.1f;

	public Color strikethruColor = Color.white;

	private Vector3 pos;

	private Vector3 rawPos;

	private void Reset()
	{
		superTextMesh = GetComponent<SuperTextMesh>();
	}

	private void OnEnable()
	{
		superTextMesh.OnRebuildEvent += ClearUnderlines;
		superTextMesh.OnRebuildEvent += ClearStrikethrus;
		superTextMesh.OnCustomEvent += DoEvent;
	}

	private void OnDisable()
	{
		superTextMesh.OnRebuildEvent -= ClearUnderlines;
		superTextMesh.OnRebuildEvent -= ClearStrikethrus;
		superTextMesh.OnCustomEvent -= DoEvent;
	}

	[ContextMenu("DebugReset")]
	public void DebugReset()
	{
		allStrikethrus = new List<SpriteRenderer>();
		allUnderlines = new List<SpriteRenderer>();
	}

	public void DoEvent(string s, STMTextInfo info)
	{
		pos = info.Middle + base.transform.position;
		rawPos = info.BottomLeftVert + base.transform.position;
		switch (s)
		{
		case "underline":
		{
			Vector3 position2 = info.pos + base.transform.position + new Vector3((info.TopRightVert.x - info.pos.x) / 2f, 0f, -0.01f) + underlineDistance;
			SpriteRenderer spriteRenderer2 = Object.Instantiate(linePrefab, position2, linePrefab.transform.rotation);
			spriteRenderer2.transform.SetParent(base.transform);
			Vector3 localScale2 = new Vector3(underlineWidth, underlineThickness, 1f);
			spriteRenderer2.transform.localScale = localScale2;
			spriteRenderer2.color = underlineColor;
			allUnderlines.Add(spriteRenderer2);
			break;
		}
		case "strike":
		case "strikethrough":
		{
			Vector3 position = info.pos + base.transform.position + new Vector3((info.TopRightVert.x - info.pos.x) / 2f, info.size.y * strikethruHeight, -0.01f);
			SpriteRenderer spriteRenderer = Object.Instantiate(linePrefab, position, linePrefab.transform.rotation);
			spriteRenderer.transform.SetParent(base.transform);
			Vector3 localScale = new Vector3(strikethruWidth, strikethruThickness, 1f);
			spriteRenderer.transform.localScale = localScale;
			spriteRenderer.color = strikethruColor;
			allStrikethrus.Add(spriteRenderer);
			break;
		}
		}
	}

	public void ClearUnderlines()
	{
		for (int i = 0; i < allUnderlines.Count; i++)
		{
			Object.DestroyImmediate(allUnderlines[i].gameObject);
		}
		allUnderlines.Clear();
	}

	public void ClearStrikethrus()
	{
		for (int i = 0; i < allStrikethrus.Count; i++)
		{
			Object.DestroyImmediate(allStrikethrus[i].gameObject);
		}
		allStrikethrus.Clear();
	}
}
