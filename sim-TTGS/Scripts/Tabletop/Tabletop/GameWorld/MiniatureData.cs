using System;
using System.Collections.Generic;
using Dhs5.Utility.Databases;
using I2.Loc;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class MiniatureData : BaseDataContainerScriptableElement, IDataContainerPrefixableElement, IDataContainerTexturableElement
	{
		private const string MiniaturesTermCategory = "Miniatures";

		[SerializeField]
		[TermsPopup("")]
		[ExcelDatabase(0, specialDrawer = true, width = 200f)]
		private string m_name;

		[SerializeField]
		private ESeasonFlags m_season = ESeasonFlags.SEASON1;

		[SerializeField]
		[ExcelDatabase(2, readOnly = true, width = 70f)]
		private ELicense m_license;

		[SerializeField]
		[ExcelDatabase(4, readOnly = true, width = 80f)]
		private EMiniatureArmy m_army;

		[SerializeField]
		[ExcelDatabase(6, readOnly = true, width = 60f)]
		private EMiniatureSize m_size;

		[SerializeField]
		[ExcelDatabase(7, readOnly = true, width = 80f)]
		private float m_marketPrice;

		[SerializeField]
		[Range(1f, 10f)]
		[ExcelDatabase(8, specialDrawer = true, width = 200f, readOnly = true)]
		private int m_rarity;

		[SerializeField]
		[ExcelDatabase(9, readOnly = true, width = 70f)]
		private float m_buyCoeff;

		[SerializeField]
		[ExcelDatabase(1, overrideName = "Available", width = 70f)]
		private bool m_availableInPacks = true;

		[SerializeField]
		[ExcelDatabase(1, overrideName = "Demo", width = 50f)]
		private bool m_availableInDemo = true;

		[Header("Wargame")]
		[SerializeField]
		private MiniatureWargameSkill m_skill;

		[SerializeField]
		[ExcelDatabase(13, readOnly = true, width = 70f, overrideName = "Var 1")]
		private string m_skillVar1;

		[SerializeField]
		[ExcelDatabase(14, readOnly = true, width = 70f, overrideName = "Var 2")]
		private string m_skillVar2;

		[SerializeField]
		[ExcelDatabase(15, readOnly = true, width = 70f, overrideName = "Var 3")]
		private string m_skillVar3;

		[Header("Setup")]
		[SerializeField]
		[ExcelDatabase(5, width = 150f)]
		private GameObject m_prefab;

		[SerializeField]
		[ExcelDatabase(16, readOnly = true)]
		private GameObject m_product;

		[SerializeField]
		[ExcelDatabase(17, readOnly = true)]
		private GameObject m_preview3D;

		[SerializeField]
		[ExcelDatabase(18, readOnly = true)]
		private GameObject m_assembly;

		[SerializeField]
		[ExcelDatabase(19, readOnly = true)]
		private GameObject m_wargame;

		[SerializeField]
		private MiniaturePieceData m_piece0;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece0Override;

		[SerializeField]
		private MiniaturePieceData m_piece1;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece1Override;

		[SerializeField]
		private MiniaturePieceData m_piece2;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece2Override;

		[SerializeField]
		private MiniaturePieceData m_piece3;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece3Override;

		[SerializeField]
		private MiniaturePieceData m_piece4;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece4Override;

		[SerializeField]
		private MiniaturePieceData m_piece5;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece5Override;

		[SerializeField]
		private MiniaturePieceData m_piece6;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece6Override;

		[SerializeField]
		private MiniaturePieceData m_piece7;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece7Override;

		[SerializeField]
		private MiniaturePieceData m_piece8;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece8Override;

		[SerializeField]
		private MiniaturePieceData m_piece9;

		[SerializeField]
		private MiniaturePieceTransformOverride m_piece9Override;

		public int ProductUID => -m_uid;

		public string NameLocaKey => m_name;

		public ESeasonFlags Seasons => m_season;

		public ELicense License => m_license;

		public EMiniatureArmy Army => m_army;

		public EMiniatureType Type => MiniatureSettings.GetTypeFromRarity(Rarity);

		public EMiniatureSize Size => m_size;

		public int NecessaryPiecesCount => m_size.PiecesCount();

		public float MarketPrice => m_marketPrice;

		public int Rarity => m_rarity;

		public bool AvailableInPacks
		{
			get
			{
				if (GameStateSettings.Demo)
				{
					if (m_availableInPacks)
					{
						return m_availableInDemo;
					}
					return false;
				}
				return m_availableInPacks;
			}
		}

		public float BuyCoeff => m_buyCoeff;

		public MiniatureWargameSkill Skill => m_skill;

		public GameObject Preview3D => m_preview3D;

		public GameObject Product => m_product;

		public GameObject Assembly => m_assembly;

		public GameObject Wargame => m_wargame;

		public string DataNamePrefix
		{
			get
			{
				return License.ToString() + "/" + Army;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public Texture2D DataTexture
		{
			get
			{
				return null;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public string GetLocalizedName()
		{
			if (LocalizationManager.TryGetTranslation(m_name, out var Translation))
			{
				return Translation;
			}
			return base.name;
		}

		public string GetLocalizedArmy()
		{
			if (LocalizationManager.TryGetTranslation(string.Format("{0}/{1}", "Miniatures", m_army), out var Translation))
			{
				return Translation;
			}
			return m_army.ToString();
		}

		public IEnumerable<MiniaturePieceData> GetPieces()
		{
			switch (m_size)
			{
			case EMiniatureSize.SIMPLE:
				yield return new MiniaturePieceData(m_piece0, this, 0);
				yield return new MiniaturePieceData(m_piece1, this, 1);
				yield return new MiniaturePieceData(m_piece2, this, 2);
				yield return new MiniaturePieceData(m_piece3, this, 3);
				yield return new MiniaturePieceData(m_piece4, this, 4);
				break;
			case EMiniatureSize.LARGE:
				yield return new MiniaturePieceData(m_piece0, this, 0);
				yield return new MiniaturePieceData(m_piece1, this, 1);
				yield return new MiniaturePieceData(m_piece2, this, 2);
				yield return new MiniaturePieceData(m_piece3, this, 3);
				yield return new MiniaturePieceData(m_piece4, this, 4);
				yield return new MiniaturePieceData(m_piece5, this, 5);
				yield return new MiniaturePieceData(m_piece6, this, 6);
				yield return new MiniaturePieceData(m_piece7, this, 7);
				yield return new MiniaturePieceData(m_piece8, this, 8);
				yield return new MiniaturePieceData(m_piece9, this, 9);
				break;
			}
		}

		public void RegisterLocaVars()
		{
			if (!string.IsNullOrWhiteSpace(m_skillVar1))
			{
				LocaVariableDatabase.SetVariableValue(base.name + "_Var1", m_skillVar1);
			}
			if (!string.IsNullOrWhiteSpace(m_skillVar2))
			{
				LocaVariableDatabase.SetVariableValue(base.name + "_Var2", m_skillVar2);
			}
			if (!string.IsNullOrWhiteSpace(m_skillVar3))
			{
				LocaVariableDatabase.SetVariableValue(base.name + "_Var3", m_skillVar3);
			}
		}
	}
}
