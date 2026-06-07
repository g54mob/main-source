using DG.Tweening;
using UnityEngine;

public class Sticker : MonoBehaviour, ILogOrigin
{
	public enum Position
	{
		Floating = 0,
		MultitoolPrinter = 1,
		MotherboardCover = 2
	}

	public enum InteractionMode
	{
		None = 0,
		Pickable = 1
	}

	public struct SplitData
	{
		public int[,] indexMap;

		public int[] indexCount;

		public BoundsInt[] indexBounds;

		public SplitData(int width, int height, int indicesCount)
		{
			indexMap = null;
			indexCount = null;
			indexBounds = null;
		}
	}

	public StickerData data;

	public int border;

	public int fixedDataHeight;

	public int rotation;

	public SpriteRenderer mainSpriteRenderer;

	public SpriteRenderer borderSpriteRenderer;

	public BoxCollider2D collider;

	public Interactable interactable;

	public AnimationCurve foldCurve;

	public AnimationCurve borderAlphaCurve;

	public float foldTime;

	public float unfoldTime;

	private static GameObject prefab;

	public const int defaultBorder = 6;

	public float fold;

	private Material mainMaterial;

	private Material borderMaterial;

	private Texture2D foldMap;

	private Sequence foldTween;

	public bool showBorder;

	private float borderAlpha;

	private float borderAlphaVel;

	private static Material blitDataMaterial;

	public Printer printer { get; private set; }

	public Motherboard motherboard { get; private set; }

	public Position position { get; private set; }

	public InteractionMode interactionMode { get; private set; }

	private int sortingLayerID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private string sortingLayerName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private int sortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private SpriteMaskInteraction maskInteraction
	{
		get
		{
			return default(SpriteMaskInteraction);
		}
		set
		{
		}
	}

	public int width { get; private set; }

	public int height { get; private set; }

	public Vector2 sceneSize => default(Vector2);

	public static Sticker Create(StickerData data, int rotation, int border, int fixedDataHeight = -1)
	{
		return null;
	}

	public static Sticker Create(Sticker sticker, SplitData splitData, int splitDataIndex)
	{
		return null;
	}

	private void Awake()
	{
	}

	public void StartPickInteraction()
	{
	}

	public void AppendBefore(StickerData dataToAppend)
	{
	}

	public Sticker Cut(MotherboardSide side, int distance, bool instantiateCuttedPart)
	{
		return null;
	}

	public void Destroy()
	{
	}

	private void Init(StickerData data, int rotation, int border, int fixedDataHeight = -1)
	{
	}

	private void Init()
	{
	}

	private void DisposeData()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetPosition(Position position)
	{
	}

	public void SetInteractionMode(InteractionMode interactionMode)
	{
	}

	public void SetPositionPrinter(Printer printer)
	{
	}

	public void DetachFromPrinter()
	{
	}

	public void SetPositionMotherboard(Motherboard motherboard, Vector2 position)
	{
	}

	public float[,] GenerateDistanceMatrix(Motherboard motherboard, bool normalize)
	{
		return null;
	}

	public SplitData GenerateSplitMatrix(params Motherboard[] motherboards)
	{
		return default(SplitData);
	}

	public void Fold(bool immediate)
	{
	}

	public void Unfold(bool immediate, bool willMoveImmediatly = false)
	{
	}

	public void Rotate()
	{
	}

	public void SetRotation(int rotation)
	{
	}

	public Vector2Int GetPosition(Vector2Int position, int rotation)
	{
		return default(Vector2Int);
	}

	public Vector2Int InverseGetPosition(Vector2Int position, int rotation)
	{
		return default(Vector2Int);
	}

	private void Update()
	{
	}

	public bool OverlapPoint(Vector2 point)
	{
		return false;
	}
}
