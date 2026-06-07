using System;
using Dhs5.Utility.Databases;
using I2.Loc;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class ProductData : BaseDataContainerScriptableElement, IDataContainerTexturableElement, IDataContainerPrefixableElement, IStackableData
	{
		[Header("Product Infos")]
		[SerializeField]
		[ExcelDatabase(4, readOnly = true, width = 70f)]
		protected float m_marketPrice;

		[SerializeField]
		[TermsPopup("")]
		[ExcelDatabase(0, specialDrawer = true, width = 300f)]
		protected string m_name;

		[SerializeField]
		[ExcelDatabase(1, specialDrawer = true)]
		private Sprite m_sprite;

		[SerializeField]
		[ExcelDatabase(5, readOnly = true, width = 70f)]
		protected float m_buyCoeff = 1f;

		[SerializeField]
		[ExcelDatabase(6, readOnly = true, width = 70f)]
		protected bool m_buyOnce;

		[SerializeField]
		[ExcelDatabase(7, width = 250f, specialDrawer = true)]
		private Product m_prefab;

		public string NameTerm => m_name;

		public Sprite Sprite => m_sprite;

		public float MarketPrice => m_marketPrice;

		public float BuyCoeff => m_buyCoeff;

		public bool BuyOnce => m_buyOnce;

		public Product Prefab => m_prefab;

		public Texture2D DataTexture
		{
			get
			{
				if (!(m_sprite != null))
				{
					return null;
				}
				return m_sprite.texture;
			}
			set
			{
				throw new Exception("Can't set Product Data texture");
			}
		}

		public virtual string DataNamePrefix
		{
			get
			{
				return "";
			}
			set
			{
				throw new Exception("Can't set Product Data prefix");
			}
		}

		public IStackable.EType StackableType => IStackable.EType.PRODUCT;

		public Bounds Bounds
		{
			get
			{
				if (!(Prefab != null))
				{
					return default(Bounds);
				}
				return Prefab.Bounds;
			}
		}
	}
}
