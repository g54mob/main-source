using UnityEngine;

namespace Simulator.GameWorld
{
	public class StackableBox : BaseBox
	{
		[Header("Content")]
		[SerializeField]
		protected ObjectStack m_stack;

		[Header("Parameters")]
		[SerializeField]
		private float m_popPathOffset;

		[SerializeField]
		private Transform m_stackPathPoint;

		public ObjectStack ObjectStack => m_stack;

		public override bool IsEmpty => !m_stack.HasStackable();

		public override void Init(BaseShopBoxData data)
		{
			base.Init(data);
			ProductData product = (data as ProductShopBoxData).Product;
			FillStackable(product, data.Quantity);
		}

		protected virtual void FillStackable(ProductData data, int quantity)
		{
			m_stack.Fill(data, quantity);
		}

		protected override void Load(BaseShopBoxData data, BoxSaveState saveState)
		{
			base.Init(data);
			if (saveState.open)
			{
				ToggleOpenState();
			}
			if (saveState is StackableBoxSaveState { quantity: >0 } stackableBoxSaveState)
			{
				ProductData productData = ProductDatabase.Get(stackableBoxSaveState.productUID);
				m_stack.Fill(productData, stackableBoxSaveState.quantity);
			}
		}

		public bool HasStackable(out ProductData productData)
		{
			if (m_stack.HasStackable())
			{
				productData = m_stack.GetCurrentData() as ProductData;
				return productData != null;
			}
			productData = null;
			return false;
		}

		public bool InstantPop(out IStackable stackable)
		{
			if (base.IsOpen && m_stack.CanPop())
			{
				stackable = m_stack.Pop();
				return true;
			}
			stackable = null;
			return false;
		}

		public bool CanAnimatedPop()
		{
			if (!base.IsOpen)
			{
				return false;
			}
			if (!m_stack.CanPop())
			{
				return false;
			}
			return true;
		}

		public (IStackable, AnimationPath) AnimatedPop()
		{
			IStackable stackable = m_stack.Pop();
			AnimationPath item = new AnimationPath(stackable.transform.position + stackable.transform.up * m_popPathOffset);
			return (stackable, item);
		}

		public bool CanWelcome(ProductData productData)
		{
			if (base.IsOpen)
			{
				if (m_stack.CanWelcome(productData))
				{
					return m_stack.HasSpaceLeft();
				}
				return false;
			}
			return false;
		}

		public bool Stack(IStackable stackable)
		{
			if (base.IsOpen)
			{
				m_stack.Stack(stackable);
				return true;
			}
			return false;
		}

		public bool AnimatedStack(IStackable stackable, AnimationPath path)
		{
			if (base.IsOpen)
			{
				if (!path.IsValid)
				{
					path.Init();
				}
				path.Add(m_stackPathPoint.transform.position);
				m_stack.AnimatedStack(stackable, path);
				return true;
			}
			return false;
		}

		protected override void OnGrabbedBy(IGrabber grabber)
		{
			base.OnGrabbedBy(grabber);
			m_stack.ClippingLayer = grabber.ClippingLayerType;
		}

		protected override void OnDroppedBy(IGrabber grabber, Vector3 position)
		{
			base.OnDroppedBy(grabber, position);
			m_stack.ClippingLayer = ClippingObjectBehaviour.ELayerType.DEFAULT;
		}

		public override bool CanBeToggled()
		{
			if (base.CanBeToggled())
			{
				return !ReserveShelfInteractable.CurrentlyInspected;
			}
			return false;
		}

		protected override void OnOpen()
		{
			base.OnOpen();
		}

		protected override void OnClose()
		{
			base.OnClose();
		}

		public override BoxSaveState GetSaveState()
		{
			if (HasStackable(out var productData))
			{
				return new StackableBoxSaveState(m_data.UID, base.IsGrabbed, base.IsOpen, productData.UID, m_stack.ActualCount, base.transform.position, base.transform.rotation);
			}
			return new StackableBoxSaveState(m_data.UID, base.IsGrabbed, base.IsOpen, 0, 0, base.transform.position, base.transform.rotation);
		}
	}
}
