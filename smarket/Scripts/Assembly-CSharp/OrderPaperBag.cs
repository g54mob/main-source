using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Lean.Pool;
using MyBox;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class OrderPaperBag : MonoBehaviour, IInteractable, IPlacementAreaObject, IPoolable, IAimHint, IPunInstantiateMagicCallback
{
	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private Vector3 m_DisablePosition;

	[SerializeField]
	private Transform m_OrderPaperBag;

	[SerializeField]
	private Renderer m_Renderer;

	[SerializeField]
	private GameObject m_OrderTag;

	[SerializeField]
	private TextMeshPro m_NameText;

	[SerializeField]
	private GameObject m_Indicator;

	[SerializeField]
	private Transform m_ProductSpawnPoint;

	private SortableBox m_SortableBox;

	private Renderer[] m_Renderers;

	private OrderListData m_OrderData;

	private bool m_IsOpen;

	public bool isOpened;

	private List<PaperBagProductInstance> m_SortedProducts;

	[SerializeField]
	private OrderPaperBagAnimation m_Animation;

	private Collider m_Collider;

	public LocalizedString localizedString;

	private NetworkOrderPaperBag m_NetworkOrderPaperBag;

	private static int[] m_SpreadViewIDCache;

	private static int[] m_SpreadProductIDCache;

	public Vector3 ProductSpawnPosition => default(Vector3);

	public bool IsOpen
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public OrderListData OrderData => null;

	public InteractactableType Type => default(InteractactableType);

	public bool ContinousInteraction => false;

	public InteractionType InteractionType => default(InteractionType);

	public bool NeedRepair
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public IReadOnlyCollection<PaperBagProductInstance> Instances => null;

	public bool OnPlacementArea { get; private set; }

	public Bounds Bounds => default(Bounds);

	public Bounds LocalBounds => default(Bounds);

	public bool HasProduct => false;

	public int ProductCount => 0;

	public PaperBagProductInstance LastProductData => null;

	public IEnumerable<PaperBagProductInstance> Entries => null;

	public bool IsTagAttached { get; private set; }

	public OrderPaperBagData Data { get; private set; }

	public string Hint => null;

	public NetworkOrderPaperBag NetworkOrderPaperBag => null;

	Transform IPlacementAreaObject.transform => null;

	GameObject IPlacementAreaObject.gameObject => null;

	public event Action Opened
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<int> ProductAdded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<int> ProductRemoved
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	private void playAnimate()
	{
	}

	private void Awake()
	{
	}

	public void Open()
	{
	}

	public void Close()
	{
	}

	public void Animate(bool isOpen)
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

	public void SpreadAllProduct()
	{
	}

	public void SpreadSingle()
	{
	}

	private PaperBagProductInstance GetProductInstanceById(int id)
	{
		return null;
	}

	public void RemoveProductById(int productId)
	{
	}

	public PaperBagProductInstance RemoveLast()
	{
		return null;
	}

	public bool IsTargetProductExist(DisplaySlot targetDisplaySlot)
	{
		return false;
	}

	public void AddProduct(int productId)
	{
	}

	public void AddProduct(Product item)
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void OnPlacedOnPlacementArea()
	{
	}

	public void OnRemovedFromPlacementArea()
	{
	}

	public void SetLayer(string layerName)
	{
	}

	public void OnAttachTag(OrderListData OrderData)
	{
	}

	public void OnDetachTag()
	{
	}

	public void OnHeld()
	{
	}

	public void OnDropped()
	{
	}

	public void SetActiveIndicator(bool isOpen)
	{
	}

	public float CalculateMatchingIncome(IEnumerable<OrderData> orderedItems)
	{
		return 0f;
	}

	public void SetInstances(PaperBagProductInstance[] instances)
	{
	}

	public void SetData(OrderPaperBagData data)
	{
	}

	public void OnPlacementModeStarted()
	{
	}

	public void OnPlacementModeEnded()
	{
	}

	public void Clear()
	{
	}

	public PaperBagProductInstance[] CreateInstanceDataCopy()
	{
		return null;
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	public void OnScroll(float f)
	{
	}
}
