using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Product : MonoBehaviour, IInteractable
{
	[SerializeField]
	private ProductSO m_ProductSO;

	private Renderer[] m_Renderers;

	private Highlightable m_Highlightable;

	private float m_Price;

	private Checkout m_Checkout;

	private List<CheckoutBeltGrid> m_OccupiedGrids;

	private Vector2Int m_Size;

	[SerializeField]
	private Vector3Int m_CrateSize;

	private Vector2Int m_BaseGrid;

	private bool m_Visible;

	private NetworkProduct m_NetworkProduct;

	private List<ProductRenderable> m_Renderables;

	public bool IsDropped;

	public float Price
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Checkout Checkout
	{
		set
		{
		}
	}

	public List<CheckoutBeltGrid> OccupiedGrids => null;

	public Vector2Int Size
	{
		get
		{
			return default(Vector2Int);
		}
		set
		{
		}
	}

	public Vector3Int CrateSize
	{
		get
		{
			return default(Vector3Int);
		}
		set
		{
		}
	}

	public Vector2Int BaseGrid
	{
		get
		{
			return default(Vector2Int);
		}
		set
		{
		}
	}

	public bool Visible
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public ProductSO ProductSO
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public NetworkProduct NetworkProduct => null;

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	private void Awake()
	{
	}

	public void Setup(int id)
	{
	}

	public void AddOccupiedGrid(CheckoutBeltGrid grid)
	{
	}

	[ContextMenu("Scan")]
	public void Scan()
	{
	}

	public void ResetProduct()
	{
	}

	public void SpreadOn(int _productID, out Rigidbody _rb)
	{
		_rb = null;
	}

	public void SpreadOnNetwork(int _productID, out Rigidbody _rb)
	{
		_rb = null;
	}

	public void SpreadOff()
	{
	}

	public bool InstantInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool CustomInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public void ToggleInstanced(bool value)
	{
	}

	public void ToggleRenderer(bool b)
	{
	}

	public void UpdateInstancedMatrix()
	{
	}

	public void RegisterToBatch(SubRenderer.BatchedRegisterHandle opaqueBatch, SubRenderer.BatchedRegisterHandle transparentBatch)
	{
	}

	private void OnDestroy()
	{
	}
}
