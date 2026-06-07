using Document;
using UnityEngine;

public class DeskDocumentPage : MonoBehaviour
{
	public enum Side
	{
		Left = 0,
		Right = 1
	}

	public Material bookPageFrontMaterial;

	public Material bookPageBackMaterial;

	public Material shadowMaterial;

	private Side side;

	private Side nextSide;

	private Sprite frontBackground;

	private Sprite backBackground;

	private Texture textureContent;

	private int frontContentIndex;

	private int backContentIndex;

	private SpriteRenderer frontRenderer;

	private SpriteRenderer backRenderer;

	private DeskDocumentPageShadow shadow;

	private float flip;

	private float angle;

	private float aspect;

	private float flipVel;

	private float angleVel;

	private float minX;

	private bool isMoving;

	private bool canInteract;

	private DeskDocument deskDocument;

	private bool interacting;

	private Vector2 startOffset;

	private float angleMul;

	public int sortingLayerID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public string sortingLayerName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int sortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void Setup(DeskDocument deskDocument, Sprite frontBackground, Sprite backBackground, Texture textureContent, int frontContentIndex, int backContentIndex, Side side, bool canInteract, bool isFirst, bool isLast)
	{
	}

	private void OnDestroy()
	{
	}

	private bool SolveLineX(Vector2 point, Vector2 dir, float y, out float x)
	{
		x = default(float);
		return false;
	}

	private bool SolveLineY(Vector2 point, Vector2 dir, float x, out float y)
	{
		y = default(float);
		return false;
	}

	private void Solve(Vector2 unflipPos, Vector2 flipPos, out float angle, out float x)
	{
		angle = default(float);
		x = default(float);
	}

	private void Update()
	{
	}
}
