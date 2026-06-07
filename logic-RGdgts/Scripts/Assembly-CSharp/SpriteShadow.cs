using UnityEngine;

public class SpriteShadow : MonoBehaviour
{
	public bool overrideSortingLayer;

	[SortingLayer]
	public int overrideSortingLayerID;

	public int overrideSortingLayerOrder;

	public int sortingOrderOffset;

	public Vector2 transformPivotPosition;

	public Transform overrideTransform;

	public SpriteShadow anchorToOtherShadow;

	public Vector2 anchorToOtherShadowOffset;

	public Material customMaterial;

	[HideInInspector]
	public Transform shadowTransform;

	private SpriteRenderer spriteRenderer;

	[HideInInspector]
	public SpriteRenderer shadowRenderer;

	private bool init;

	public float offset;

	public float multiplier;

	public float angle;

	public Vector2 positionOffset;

	private bool isVisible;

	private static float _intensity;

	public bool IsVisible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static float intensity
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	public void Init()
	{
	}

	public void Init(SpriteRenderer renderer)
	{
	}

	public Material GetMaterial()
	{
		return null;
	}

	public Vector3 GetOffset()
	{
		return default(Vector3);
	}

	public float GetAngle()
	{
		return 0f;
	}

	public void RefreshSprite()
	{
	}

	public void Refresh()
	{
	}

	private Vector3 Floor(Vector3 p)
	{
		return default(Vector3);
	}

	private Vector3 Ceil(Vector3 p)
	{
		return default(Vector3);
	}

	private Vector3 Round(Vector3 p)
	{
		return default(Vector3);
	}

	private void LateUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
