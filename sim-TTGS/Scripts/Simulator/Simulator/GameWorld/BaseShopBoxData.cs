using System;
using Dhs5.Utility.Databases;
using I2.Loc;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class BaseShopBoxData : BaseDataContainerScriptableElement, IDataContainerPrefixableElement, IDataContainerTexturableElement
	{
		[Header("Shop Infos")]
		[SerializeField]
		[ExcelDatabase(2, readOnly = true, width = 70f)]
		protected int m_type;

		[SerializeField]
		[ExcelDatabase(1, specialDrawer = true)]
		protected Sprite m_sprite;

		[SerializeField]
		[TermsPopup("")]
		[ExcelDatabase(0, specialDrawer = true, width = 300f)]
		protected string m_name;

		[SerializeField]
		[ExcelDatabase(3, readOnly = true, width = 70f)]
		protected float m_price;

		[SerializeField]
		[ExcelDatabase(4, readOnly = true, width = 70f)]
		protected int m_quantity;

		[SerializeField]
		[TermsPopup("")]
		[ExcelDatabase(9, specialDrawer = true, width = 200f)]
		protected string m_tooltipTerm;

		[SerializeField]
		[ExcelDatabase(5, width = 70f)]
		protected bool m_sellable = true;

		[SerializeField]
		[ExcelDatabase(5, overrideName = "Demo", width = 50f)]
		protected bool m_availableInDemo = true;

		[Header("Unlock Infos")]
		[SerializeField]
		protected bool m_lockedByDefault = true;

		[SerializeField]
		[ExcelDatabase(6, readOnly = true, overrideName = "Unlock level", width = 70f)]
		protected int m_requiredShopLevel;

		[SerializeField]
		[Show("m_lockedByDefault", false)]
		protected float m_licensePrice;

		[SerializeField]
		[ExcelDatabase(7)]
		protected bool m_showOnUnlock = true;

		[SerializeField]
		[ExcelDatabase(8, specialDrawer = true)]
		protected GameObject m_prefab;

		public string NameTerm => m_name;

		public int Type => m_type;

		public Sprite Sprite => m_sprite;

		public int Quantity => m_quantity;

		public float Price => m_price;

		public string TooltipTerm => m_tooltipTerm;

		public bool Sellable
		{
			get
			{
				if (GameStateSettings.Demo)
				{
					if (m_sellable)
					{
						return m_availableInDemo;
					}
					return false;
				}
				return m_sellable;
			}
		}

		public bool LockedByDefault => m_lockedByDefault;

		public int RequiredShopLevel => m_requiredShopLevel;

		public float LicensePrice => m_licensePrice;

		public bool ShowOnUnlock => m_showOnUnlock;

		public GameObject Prefab => m_prefab;

		public string DataNamePrefix
		{
			get
			{
				return m_type.ToString();
			}
			set
			{
				throw new Exception("Can't set ShopBoxData prefix");
			}
		}

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
				throw new Exception("Can't set ShopBoxData texture");
			}
		}

		public virtual void RegisterLocaVars()
		{
		}
	}
}
