using DG.Tweening;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Product : MonoBehaviour, IStackable, ISensable, IOpenable
	{
		[Header("Product Infos")]
		[SerializeField]
		[ReadOnly(false, false)]
		private ProductData m_data;

		[SerializeField]
		protected Bounds m_bounds;

		[Header("Model")]
		[SerializeField]
		protected Rigidbody m_rigidbody;

		[SerializeField]
		protected Collider m_collider;

		[SerializeField]
		protected GameObject m_visualRoot;

		[SerializeField]
		protected Outline m_outline;

		[Header("State")]
		[SerializeField]
		private float m_price;

		[Header("Clipping")]
		[SerializeField]
		private ClippingObjectBehaviour m_clippingObjectBehaviour;

		[Header("Input hint")]
		[SerializeField]
		private InputHint m_inputHint;

		public ProductData ProductData => m_data;

		public bool IsOpen { get; private set; }

		public float Price
		{
			get
			{
				return m_price;
			}
			protected set
			{
				m_price = value;
			}
		}

		public ClippingObjectBehaviour ClippingObjectBehaviour => m_clippingObjectBehaviour;

		public InputHint InputHint => m_inputHint;

		public Bounds Bounds => m_bounds;

		public IStackableData StackableData => m_data;

		Transform IStackable.transform => base.transform;

		protected virtual void Start()
		{
			ClippingObjectBehaviour.ValidateRenderersLayer();
		}

		public virtual void Init(ProductData data)
		{
			m_data = data;
		}

		public virtual void Init(ProductData data, float price)
		{
			m_data = data;
			Price = price;
		}

		public void Buy()
		{
			OnBought();
		}

		protected virtual void OnBought()
		{
			Price = PriceManager.GetProductPrice(m_data.UID);
		}

		public virtual BoughtProductInfo GetBoughtProductInfo()
		{
			return new BoughtProductInfo(m_data, m_price);
		}

		public virtual void OnPreStackedIn(ObjectStack stack)
		{
			m_collider.enabled = false;
		}

		public virtual void OnStackedIn(ObjectStack stack)
		{
		}

		public virtual void OnUnstackedFrom(ObjectStack stack)
		{
		}

		public virtual bool CanBeSensed()
		{
			return World.PlayerController.Context == EControllerContext.REGISTER;
		}

		public virtual void OnSensed()
		{
			m_outline.enabled = true;
		}

		public virtual void OnUnsensed()
		{
			m_outline.enabled = false;
		}

		public virtual bool CanBeToggled()
		{
			return false;
		}

		public bool ToggleOpenState()
		{
			IsOpen = !IsOpen;
			if (IsOpen)
			{
				OnOpen();
			}
			else
			{
				OnClose();
			}
			return IsOpen;
		}

		protected virtual void OnOpen()
		{
		}

		protected virtual void OnClose()
		{
		}

		public virtual void Store(Transform anchor)
		{
			m_rigidbody.isKinematic = true;
			m_rigidbody.useGravity = false;
			m_collider.enabled = false;
			base.transform.SetParent(anchor, worldPositionStays: true);
			base.transform.DOLocalMove(Vector3.zero, 0.1f).OnComplete(delegate
			{
				m_visualRoot.SetActive(value: false);
			});
		}

		public virtual void MakeFallFrom(Transform anchor, Vector3 position)
		{
			base.transform.SetParent(anchor);
			base.transform.position = position;
			m_visualRoot.SetActive(value: true);
			m_rigidbody.isKinematic = false;
			m_rigidbody.useGravity = true;
			m_collider.enabled = true;
		}

		public static Product Create(ProductData data)
		{
			Product product = Object.Instantiate(data.Prefab);
			product.Init(data);
			return product;
		}
	}
}
