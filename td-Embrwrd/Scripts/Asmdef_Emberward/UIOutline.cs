using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class UIOutline : MaskableGraphic
{
	[SerializeField]
	private Texture m_Texture;

	[Range(0f, 500f)]
	[SerializeField]
	private float _outlineWidth;

	[SerializeField]
	[Range(0f, 500f)]
	private float _cornerRadius;

	[Range(1f, 20f)]
	[SerializeField]
	private int _cornerSegments;

	[Range(0f, 1f)]
	[SerializeField]
	private float _mappingBias;

	[SerializeField]
	private bool _fillCenter;

	private Vector3[] _corners;

	private List<UIVertex> _verts;

	public override Texture mainTexture => null;

	protected override void OnRectTransformDimensionsChange()
	{
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
	}
}
