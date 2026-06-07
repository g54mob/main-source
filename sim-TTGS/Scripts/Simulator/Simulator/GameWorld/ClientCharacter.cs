using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ClientCharacter : AICharacter
	{
		[Header("Model")]
		[SerializeField]
		private ClientCharacterModel m_model;

		private DelayedCallHandle m_activateCashCallHandle;

		protected override CharacterModel Model => m_model;

		public ShoppingBag ShoppingBag => m_model.ShoppingBag;

		protected override void OnDisable()
		{
			base.OnDisable();
			m_activateCashCallHandle.Kill();
		}

		public override bool CanHandleStackable(IStackable stackable)
		{
			return stackable is Product;
		}

		public override void OnHandleStackable(IStackable stackable)
		{
			if (stackable is Product product)
			{
				Buy(product);
			}
		}

		public override bool HasStackable(out IStackable stackable)
		{
			stackable = null;
			return false;
		}

		public override bool CanGiveStackable()
		{
			return false;
		}

		public override IStackable GiveStackable()
		{
			return null;
		}

		protected virtual void Buy(Product product)
		{
			product.Buy();
			AddToShoppingBag(product);
		}

		protected virtual void AddToShoppingBag(Product product)
		{
			ShoppingBag.AddProduct(product);
			if (ShoppingBag.ContentCount == 1)
			{
				ShoppingBag.Show();
			}
		}

		public void GetShoppingBagBack()
		{
			ShoppingBag.RemoveAddedConstraints();
			ShoppingBag.Open(open: false);
		}

		public void ShowCash(bool show)
		{
			m_model.Cash.gameObject.SetActive(show);
			m_model.ShowCash(show);
			if (show)
			{
				Updater.CallInXSeconds(AIModelSettings.ShowCashAnimDuration, ActivateCash, out m_activateCashCallHandle);
			}
		}

		private void ActivateCash()
		{
			m_model.Cash.Activate();
		}

		public void PickUpProduct()
		{
			m_model.PickUpProduct();
		}

		public void SetPainting(bool painting)
		{
			m_model.Painting(painting);
		}

		public void SetPlaying(bool playing)
		{
			m_model.Playing(playing);
		}
	}
}
