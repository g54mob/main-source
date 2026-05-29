using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using MyBox;
using UnityEngine;

public class Box : MonoBehaviour, IInteractable, IPlacementAreaObject, IPlacementAreaPhysicsBody
{
	[CompilerGenerated]
	private sealed class _003CDestroyWhenTransferComplete_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Box _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDestroyWhenTransferComplete_003Ed__110(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private const float m_ClosingBoxTime = 0.88f;

	protected const float m_AnimationTransitionTime = 0.7f;

	[Separator("Components", false)]
	[SerializeField]
	private int m_ID;

	[SerializeField]
	private MeshRenderer m_ProductIconImage;

	[SerializeField]
	private GameObject m_IconUI;

	[SerializeField]
	protected Animation m_Animation;

	[SerializeField]
	private Transform m_ProductsParent;

	[SerializeField]
	private BoxSO m_BoxSO;

	[SerializeField]
	private Renderer[] m_RenderersToHighlight;

	private List<Product> m_Products;

	private BoxData m_Data;

	protected bool m_SpawnedProducts;

	private bool m_InAnimationTransition;

	private bool m_Racked;

	[SerializeField]
	private bool m_IsBoxOccupied;

	private Transform m_OccupyOwner;

	private BoxPlacingMode m_BoxPlacingMode;

	private Rigidbody m_RigidBody;

	private Collider m_MainCollider;

	[SerializeField]
	private MeshRenderer m_StaticRenderer;

	private SortableBox m_SortableBox;

	protected Tween m_CloseDelayedCall;

	private Tween m_InstancingTween;

	private Coroutine m_InstancingCoroutine;

	[HideInInspector]
	public NetworkBox NetworkBox;

	private StaticBoxRenderable m_StaticBoxRenderable;

	public Bounds Bounds => default(Bounds);

	public Bounds LocalBounds => default(Bounds);

	public BoxSO BoxSO => null;

	public BoxSize Size => default(BoxSize);

	public InteractactableType Type => default(InteractactableType);

	public bool IsOpen => false;

	public GameObject IconUI => null;

	public bool InAnimationTransition => false;

	public bool ContinousInteraction => false;

	public ProductSO Product => null;

	public virtual bool Full => false;

	public int MaxProductCount => 0;

	public BoxData Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string InstantInteractionHint => null;

	public string HoldingInteractionHint => null;

	public string SecondInteractionHint => null;

	public string RepairInteractionHint => null;

	public bool NeedRepair { get; set; }

	public InteractionType InteractionType => default(InteractionType);

	public int BoxID => 0;

	public bool Racked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool OnPlacementArea { get; private set; }

	public virtual bool HasProducts => false;

	public Renderer[] RenderersToHighlight => null;

	public bool IsBoxOccupied
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int ProductCount => 0;

	public Transform OccupyOwner => null;

	public Rigidbody RigidBody => null;

	Transform IPlacementAreaObject.transform => null;

	GameObject IPlacementAreaObject.gameObject => null;

	protected virtual void Initialize()
	{
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnSave()
	{
	}

	private void OnDisable()
	{
	}

	public virtual void Setup(int productID, bool newBox = false)
	{
	}

	public void SetOccupy(bool isOccupy, Transform occupyOwner)
	{
	}

	public virtual void OpenBox()
	{
	}

	public virtual void OpenBox(PlayerInstance pickedPlayer)
	{
	}

	public void CloseBox(bool force = false)
	{
	}

	public void CloseBox(PlayerInstance pickedPlayer, bool force = false)
	{
	}

	public void FrezeeBox()
	{
	}

	public void PickUp()
	{
	}

	public void PickUp(PlayerInstance pickedPlayer)
	{
	}

	public bool RemoteInteract(string userId)
	{
		return false;
	}

	public virtual bool InstantInteract()
	{
		return false;
	}

	public bool HoldingInteract()
	{
		return false;
	}

	public bool RepairInteract(bool isHold, PlayerInstance playerInstance)
	{
		return false;
	}

	public virtual Product GetProductFromBox(bool fromPlayer)
	{
		return null;
	}

	public (int, bool) WholesaleOrderRemoveProductFromBox(int count)
	{
		return default((int, bool));
	}

	[IteratorStateMachine(typeof(_003CDestroyWhenTransferComplete_003Ed__110))]
	private IEnumerator DestroyWhenTransferComplete()
	{
		return null;
	}

	public void AddProduct(int productID, Product item)
	{
	}

	public void AddProductData(int productID, int count, out int addedProductCount)
	{
		addedProductCount = default(int);
	}

	public void AddProductOnlyAnimate(int productID, Product item, int productIndex)
	{
	}

	public void ResetBox()
	{
	}

	public void DropBox()
	{
	}

	public void OnPlacedOnPlacementArea()
	{
	}

	public void OnRemovedFromPlacementArea()
	{
	}

	private Vector3 GetPositionFor(int index)
	{
		return default(Vector3);
	}

	private Quaternion GetRotationFor(int index)
	{
		return default(Quaternion);
	}

	public virtual void NetworkInitialize()
	{
	}

	public virtual void SpawnProducts(bool loadFromData = false)
	{
	}

	public void DespawnProducts()
	{
	}

	private void SetIdle()
	{
	}

	protected void SetInAnimationTransition()
	{
	}

	public bool CustomInteract()
	{
		return false;
	}

	public void SetStatic(bool b)
	{
	}

	public void RegisterToBatch(SubRenderer.BatchedRegisterHandle handle)
	{
	}

	public void ToggleInstanced(bool value)
	{
	}

	private void OnDestroy()
	{
	}

	public Renderer GetStaticRenderer()
	{
		return null;
	}

	public static BoxData CreateBoxData(int productID)
	{
		return null;
	}

	public void RefreshSpawnedProducts()
	{
	}

	public void SetInstancingTween(Tween tween)
	{
	}

	public void KillInstancingTween()
	{
	}

	public void KillAllInstancingAnimations()
	{
	}

	public void KillInstancingCoroutine()
	{
	}

	public void SetInstancingCoroutine(Coroutine coroutine)
	{
	}
}
