using System;
using System.Collections.Generic;
using Simulator;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[CreateAssetMenu(fileName = "Miniature Database", menuName = "Tabletop/Excel Databases/Figurines")]
	public class MiniatureDatabase : ExcelDatabase
	{
		public const string SetupButtonMemberName = "SetupButton";

		[Header("Miniature Database")]
		[SerializeField]
		private List<MiniatureData> m_datas;

		private static MiniatureDatabase _instance;

		private Dictionary<int, MiniatureData> m_runtimeMiniatures = new Dictionary<int, MiniatureData>();

		public override EExcelDatabase Type => EExcelDatabase.FIGURINES;

		public override Type ContentType => typeof(MiniatureData);

		private static MiniatureDatabase Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = ExcelDatabaseSettings.GetDatabase(EExcelDatabase.FIGURINES) as MiniatureDatabase;
					_instance.SetupMiniaturesDico();
				}
				return _instance;
			}
		}

		private void SetupMiniaturesDico()
		{
			m_runtimeMiniatures.Clear();
			foreach (MiniatureData data in m_datas)
			{
				if (data.AvailableInPacks)
				{
					m_runtimeMiniatures.Add(data.UID, data);
					data.RegisterLocaVars();
				}
			}
		}

		public static MiniatureData Get(int uid)
		{
			if (Instance.m_runtimeMiniatures.TryGetValue(uid, out var value))
			{
				return value;
			}
			return null;
		}

		public static IEnumerable<MiniatureData> Enumerate()
		{
			foreach (MiniatureData value in Instance.m_runtimeMiniatures.Values)
			{
				yield return value;
			}
		}

		public static int GetCount()
		{
			return Instance.m_datas.Count;
		}

		public static int GetCount(ELicense license)
		{
			int num = 0;
			foreach (MiniatureData data in Instance.m_datas)
			{
				if (data.License == license)
				{
					num++;
				}
			}
			return num;
		}

		public static int GetCount(EMiniatureArmy army)
		{
			int num = 0;
			foreach (MiniatureData data in Instance.m_datas)
			{
				if (data.Army == army)
				{
					num++;
				}
			}
			return num;
		}

		public static int GetCount(ELicense license, EMiniatureArmy army)
		{
			int num = 0;
			foreach (MiniatureData data in Instance.m_datas)
			{
				if (data.License == license && data.Army == army)
				{
					num++;
				}
			}
			return num;
		}

		public static int GetHeroCount()
		{
			int num = 0;
			foreach (MiniatureData data in Instance.m_datas)
			{
				if (data.Type != EMiniatureType.COMMON)
				{
					num++;
				}
			}
			return num;
		}

		public static int GetHeroCount(ELicense license)
		{
			int num = 0;
			foreach (MiniatureData data in Instance.m_datas)
			{
				if (data.License == license && data.Type != EMiniatureType.COMMON)
				{
					num++;
				}
			}
			return num;
		}

		public static List<MiniaturePieceData> ComputeMiniaturePiecePool(ELicense license, MiniatureRarityModifier rarityModifier, EMiniatureArmy army)
		{
			List<MiniaturePieceData> list = new List<MiniaturePieceData>();
			foreach (MiniatureData data in Instance.m_datas)
			{
				if (!data.AvailableInPacks || !rarityModifier.IsPossible(data.Rarity) || data.License != license || (army != EMiniatureArmy.NONE && data.Army != army))
				{
					continue;
				}
				foreach (MiniaturePieceData piece in data.GetPieces())
				{
					for (int i = 0; i < rarityModifier.GetWeight(data.Rarity); i++)
					{
						list.Add(piece);
					}
				}
			}
			return list;
		}
	}
}
