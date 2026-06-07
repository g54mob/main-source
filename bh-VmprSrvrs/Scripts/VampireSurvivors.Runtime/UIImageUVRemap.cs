using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[ExecuteAlways]
public class UIImageUVRemap : BaseMeshEffect, IMaterialModifier
{
	private static readonly int UVRemapID;

	private static readonly int RainbowOffsetID;

	[SerializeField]
	private float Seed;

	private Vector4 uvRemap;

	private int rotMode;

	private Image _img;

	protected override void Awake()
	{
	}

	private void RegenerateSeed()
	{
	}

	private void TryUpdate()
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void OnDisable()
	{
	}

	public override void ModifyMesh(VertexHelper vh)
	{
	}

	public Material GetModifiedMaterial(Material baseMat)
	{
		return null;
	}
}
