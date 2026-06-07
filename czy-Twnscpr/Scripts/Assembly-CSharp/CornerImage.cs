using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class CornerImage : MaskableGraphic
{
	[SerializeField]
	private Sprite _sprite;

	[SerializeField]
	private float innerSize;

	[SerializeField]
	private bool3x3 quadrants;

	[SerializeField]
	public int uOffset;

	[SerializeField]
	private float _progress;

	public Sprite sprite
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float progress
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
	}

	protected override void UpdateMaterial()
	{
	}
}
