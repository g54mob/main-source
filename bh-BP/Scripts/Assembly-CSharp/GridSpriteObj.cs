using AllIn1SpriteShader;
using UnityEngine;
using UnityEngine.Rendering;

public class GridSpriteObj : MonoBehaviour
{
	public SpriteAnimator SprAnimator;

	public SpriteRenderer Rend;

	public SortingGroup SortGrp;

	public SetAtlasUvs AtlasUvSetter;

	public MeshFilter MeshFilt;

	public MeshRenderer MeshRend;

	public bool IgnoreMats;

	private void OnValidate()
	{
	}

	private void Awake()
	{
	}

	public void SetSortLayer(SortLayerType st)
	{
	}

	public void SetSortLayer(int sl)
	{
	}

	public int GetSortLayerID()
	{
		return 0;
	}

	public void SetSortOrder(int ord)
	{
	}

	public int GetSortOrder()
	{
		return 0;
	}

	public void SetSprite(Sprite spr)
	{
	}

	public void SetMat(Material mat)
	{
	}

	public void LayerRightInFrontOf(GridSpriteObj other)
	{
	}

	public void SetPos(Vector3 pos)
	{
	}

	public void RefreshSortOrder()
	{
	}

	public void RefreshSortOrder(Vector3 pos)
	{
	}

	public void SetRendEnabled(bool isOn)
	{
	}

	public void SetColor(Color c)
	{
	}

	public Material GetMat()
	{
		return null;
	}
}
