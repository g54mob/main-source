using System.Collections.Generic;
using SQLite;
using Synty.SidekickCharacters.Enums;
using UnityEngine;

namespace Synty.SidekickCharacters.Database.DTO
{
	[Table("sk_part")]
	public class SidekickPart
	{
		private SidekickSpecies _species;

		private static readonly Dictionary<string, GameObject> s_globalModelCache;

		[PrimaryKey]
		[AutoIncrement]
		[Column("id")]
		public int ID { get; set; }

		[Column("ptr_species")]
		public int PtrSpecies { get; set; }

		[Column("type")]
		public CharacterPartType Type { get; set; }

		[Column("part_group")]
		public PartGroup PartGroup { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("part_file_name")]
		public string FileName { get; set; }

		[Column("part_location")]
		public string Location { get; set; }

		[Column("uses_wrap")]
		public bool UsesWrap { get; set; }

		[Column("file_exists")]
		public bool FileExists { get; set; }

		[Ignore]
		public SidekickSpecies Species
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static int CachedModelCount => 0;

		public static SidekickPart GetByID(DatabaseManager dbManager, int id)
		{
			return null;
		}

		public static List<SidekickPart> GetAll(DatabaseManager dbManager)
		{
			return null;
		}

		public static List<SidekickPart> GetAllForPartType(DatabaseManager dbManager, CharacterPartType partType)
		{
			return null;
		}

		public static List<SidekickPart> GetAllForSpecies(DatabaseManager dbManager, SidekickSpecies species, bool onlyPartsWithFile = true)
		{
			return null;
		}

		public static SidekickPart GetByPartFileName(DatabaseManager dbManager, string fileName)
		{
			return null;
		}

		public static List<SidekickPart> GetBaseParts(DatabaseManager dbManager)
		{
			return null;
		}

		public static SidekickPart SearchForByName(DatabaseManager dbManager, string partName)
		{
			return null;
		}

		public static bool IsPartNameUnique(DatabaseManager dbManager, string partName)
		{
			return false;
		}

		public static SidekickSpecies GetSpeciesForPart(List<SidekickSpecies> allSpecies, string partName)
		{
			return null;
		}

		public static void UpdateAll(DatabaseManager dbManager, List<SidekickPart> parts)
		{
		}

		private static void Decorate(DatabaseManager dbManager, SidekickPart part)
		{
		}

		public int Save(DatabaseManager dbManager)
		{
			return 0;
		}

		public SidekickPartImage GetImageForPart(DatabaseManager dbManager)
		{
			return null;
		}

		public void Delete(DatabaseManager dbManager)
		{
		}

		public GameObject GetPartModel()
		{
			return null;
		}

		public static void CacheModel(string assetName, GameObject model)
		{
		}

		public static bool IsModelCached(string assetName)
		{
			return false;
		}

		public string GetPartResourcePath()
		{
			return null;
		}

		public bool IsFileAvailable()
		{
			return false;
		}

		private string GetResourcePath(string fullPath)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
