using System;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniatureProduct : TabletopProduct, IMainInteractable
	{
		[Header("Miniature")]
		[SerializeField]
		[ReadOnly(false, false)]
		private MeshRenderer[] m_renderers;

		private bool m_bought;

		private bool m_painted;

		private int m_rarity;

		public bool Painted => m_painted;

		public float PaintBonus { get; private set; }

		public event Action Interacted;

		public event Action OnSensedEvent;

		public event Action OnUnsensedEvent;

		public void Init(MiniatureProductData miniatureProductData, MiniatureData miniatureData, bool painted, float price = 0f)
		{
			Init(miniatureProductData, price);
			m_painted = painted;
			m_rarity = miniatureData.Rarity;
			if (painted)
			{
				int paintMaxScore = Collection.GetPaintMaxScore(-miniatureProductData.UID);
				Paint(paintMaxScore);
				float miniaturePrice = PaintingSettings.GetMiniaturePrice(paintMaxScore, base.ProductData.MarketPrice);
				PaintBonus = miniaturePrice / base.ProductData.MarketPrice - 1f;
			}
			else
			{
				Paint(0);
				PaintBonus = 0f;
			}
		}

		public virtual void OnPlacedOnStall()
		{
			Collection.PaintedMiniature += OnPaintedMiniature;
		}

		public virtual void OnRemovedFromStall()
		{
			Collection.PaintedMiniature -= OnPaintedMiniature;
		}

		protected override void OnBought()
		{
			m_bought = true;
			base.Price = TabletopPriceManager.GetMiniatureProductPrice(base.ProductData.UID, Painted);
		}

		public override BoughtProductInfo GetBoughtProductInfo()
		{
			return new BoughtProductInfo(base.ProductData, base.Price, Painted);
		}

		private void Paint(int score)
		{
			Material material;
			if (score > 0)
			{
				material = m_renderers[0].material;
				PaintingSettings.SetMaterialValuesByScore(material, score);
			}
			else
			{
				material = PaintingSettings.GetMiniaturesUnpaintedMat(m_rarity);
			}
			MeshRenderer[] renderers = m_renderers;
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers[i].material = material;
			}
		}

		public bool CanMainInteract(Character character)
		{
			return true;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			this.Interacted?.Invoke();
		}

		public override bool CanBeSensed()
		{
			if (!base.CanBeSensed())
			{
				if (!m_bought && World.PlayerController.Context == EControllerContext.CHARACTER)
				{
					return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
				}
				return false;
			}
			return true;
		}

		public override void OnSensed()
		{
			base.OnSensed();
			this.OnSensedEvent?.Invoke();
		}

		public override void OnUnsensed()
		{
			if (m_outline != null)
			{
				base.OnUnsensed();
			}
			this.OnUnsensedEvent?.Invoke();
		}

		private void OnPaintedMiniature(int miniatureUID, int paintScore)
		{
			if (Painted && base.ProductData.UID == -miniatureUID)
			{
				Paint(paintScore);
			}
		}
	}
}
