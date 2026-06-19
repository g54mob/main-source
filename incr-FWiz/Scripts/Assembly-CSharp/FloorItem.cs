using OUSystems.Basics.UI;
using UnityEngine;

public class FloorItem : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	[SerializeField]
	private Transform _bodyGraphicTransform;

	private float _baseGraphicHeight;

	public float StartScale;

	public float GrowthDuration;

	[SerializeField]
	private Collider2D _collider;

	private bool Collectable;

	[SerializeField]
	private HoverListener _hoverListener;

	private const float TransferZ = -3f;

	public const int FloorItemLayer = 13;

	public const string Tag = "FloorItem";

	[field: SerializeField]
	public ItemType Type { get; private set; }

	[field: SerializeField]
	public Rigidbody2D RigidBody { get; private set; }

	public bool Passing { get; private set; }

	public Vector2Int CurrentChunk { get; set; }

	public void SetType(ItemType type)
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHover()
	{
	}

	public void OnHoverEnd()
	{
	}

	public void OnGrown()
	{
	}

	public void UpdateBobHeight(float bobHeight)
	{
	}

	public void SetCollectable(bool collectable)
	{
	}

	public void FloatTo(Vector2 position, float passDuration)
	{
	}

	public void Move(Vector3 position)
	{
	}

	public void OnUpdatePosition()
	{
	}
}
