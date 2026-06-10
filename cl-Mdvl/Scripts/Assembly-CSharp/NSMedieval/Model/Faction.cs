using System;
using System.Collections.Generic;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Faction : TraderStockModifiersContainer
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private string factionType;

		[SerializeField]
		private List<string> prefabs;

		[SerializeField]
		private string placement;

		[SerializeField]
		private List<string> mapCellTypes;

		[SerializeField]
		private string color;

		[SerializeField]
		private string heraldryCrest;

		[SerializeField]
		private string heraldryBackground;

		[SerializeField]
		private float female;

		[SerializeField]
		private List<string> extortionStockModifiers;

		[SerializeField]
		private List<string> beggarStockModifiers;

		[SerializeField]
		private bool runawayEventWillTrade;

		[SerializeField]
		private bool raidWillNotSurrender;

		[SerializeField]
		private float addFriendlinessOnPrisonerDeath = -10f;

		[SerializeField]
		private float maxFriendlinessPrisoners = 40f;

		[SerializeField]
		private bool acceptPrisonersOfSameFaction = true;

		[SerializeField]
		private bool acceptPrisonersOfOtherFactions;

		[NonSerialized]
		private FactionType factionTypeCache;

		[NonSerialized]
		private VillagePlacementType placementCache;

		[NonSerialized]
		private bool colorInit;

		[NonSerialized]
		private Color colorCache;

		[NonSerialized]
		private bool crestImageInit;

		[NonSerialized]
		private bool backgroundImageInit;

		[NonSerialized]
		private Texture2D heraldryCrestTexture;

		[NonSerialized]
		private Sprite heraldryCrestSprite;

		[NonSerialized]
		private Texture2D heraldryBackgroundTexture;

		[NonSerialized]
		private Sprite heraldryBackgroundSprite;

		[NonSerialized]
		private bool spritesInit;

		[NonSerialized]
		private List<TraderStockModifier> extortionStockModifiersCache;

		[NonSerialized]
		private List<TraderStockModifier> beggarStockModifiersCache;

		public string Name => name;

		public string Description => LocKeyUtils.GetInfo(base.LocKeys);

		public FloatRange FriendlinessRange => Repository<FactionTypeRepository, FactionType>.Instance.GetByID(factionType).FriendlinessRange;

		public List<string> MapCellTypes => mapCellTypes;

		public string FactionTypeId => factionType;

		public FactionType FactionType
		{
			get
			{
				if (factionTypeCache == null)
				{
					factionTypeCache = Repository<FactionTypeRepository, FactionType>.Instance.GetByID(factionType);
				}
				return factionTypeCache;
			}
		}

		public List<string> Prefabs => prefabs;

		public VillagePlacementType Placement
		{
			get
			{
				if (placement == null || placement.Equals(string.Empty))
				{
					return VillagePlacementType.Random;
				}
				if (placementCache.Equals(VillagePlacementType.None))
				{
					Enum.TryParse<VillagePlacementType>(placement, out placementCache);
					if (placementCache.Equals(VillagePlacementType.None))
					{
						placementCache = VillagePlacementType.Random;
					}
				}
				return placementCache;
			}
		}

		public Color Color
		{
			get
			{
				if (!colorInit)
				{
					colorInit = true;
					ColorUtility.TryParseHtmlString(color, out colorCache);
				}
				return colorCache;
			}
		}

		public Texture2D HeraldryCrestTexture
		{
			get
			{
				if (!crestImageInit)
				{
					crestImageInit = true;
					string path = Path.Combine(Application.streamingAssetsPath, "FactionHeraldry", heraldryCrest).Replace("\\", "/");
					LoadImageOrDefault(path, "faction_heraldry_default_crest", "[loaded]" + heraldryCrest, ref heraldryCrestTexture);
				}
				return heraldryCrestTexture;
			}
		}

		public Sprite HeraldryCrestSprite
		{
			get
			{
				CheckSpritesInit();
				return heraldryCrestSprite;
			}
		}

		public Texture2D HeraldryBackgroundTexture
		{
			get
			{
				if (!backgroundImageInit)
				{
					backgroundImageInit = true;
					string path = Path.Combine(Application.streamingAssetsPath, "FactionHeraldry", heraldryBackground).Replace("\\", "/");
					LoadImageOrDefault(path, "church_of_third_coming_bg", "[loaded]" + heraldryBackground, ref heraldryBackgroundTexture);
				}
				return heraldryBackgroundTexture;
			}
		}

		public Sprite HeraldryBackgroundSprite
		{
			get
			{
				CheckSpritesInit();
				return heraldryBackgroundSprite;
			}
		}

		public float Female => female;

		public List<TraderStockModifier> ExtortionStockModifiers
		{
			get
			{
				if (extortionStockModifiersCache != null)
				{
					return extortionStockModifiersCache;
				}
				extortionStockModifiersCache = new List<TraderStockModifier>();
				if (extortionStockModifiers == null)
				{
					return extortionStockModifiersCache;
				}
				foreach (string extortionStockModifier in extortionStockModifiers)
				{
					TraderStockModifier byID = Repository<TraderStockModifierRepository, TraderStockModifier>.Instance.GetByID(extortionStockModifier);
					if (byID != null)
					{
						extortionStockModifiersCache.Add(byID);
					}
				}
				return extortionStockModifiersCache;
			}
		}

		public List<TraderStockModifier> BeggarStockModifiers
		{
			get
			{
				if (beggarStockModifiersCache != null)
				{
					return beggarStockModifiersCache;
				}
				beggarStockModifiersCache = new List<TraderStockModifier>();
				if (beggarStockModifiers == null)
				{
					return beggarStockModifiersCache;
				}
				foreach (string beggarStockModifier in beggarStockModifiers)
				{
					TraderStockModifier byID = Repository<TraderStockModifierRepository, TraderStockModifier>.Instance.GetByID(beggarStockModifier);
					if (byID != null)
					{
						beggarStockModifiersCache.Add(byID);
					}
				}
				return beggarStockModifiersCache;
			}
		}

		public bool RunawayEventWillTrade => runawayEventWillTrade;

		public bool RaidWillNotSurrender => raidWillNotSurrender;

		public float AddFriendlinessOnPrisonerDeath => addFriendlinessOnPrisonerDeath;

		public float MaxFriendlinessPrisoners => maxFriendlinessPrisoners;

		public bool AcceptPrisonersOfSameFaction => acceptPrisonersOfSameFaction;

		public bool AcceptPrisonersOfOtherFactions => acceptPrisonersOfOtherFactions;

		public Faction()
		{
			female = 0.5f;
			runawayEventWillTrade = true;
		}

		private void LoadImageOrDefault(string path, string defaultFallback, string newTextureName, ref Texture2D outTexture)
		{
			bool flag = true;
			bool isEnabled;
			try
			{
				if (File.Exists(path))
				{
					byte[] data = FileUtils.SafeReadAllBytes(path);
					outTexture = new Texture2D(256, 256);
					outTexture.LoadImage(data);
					outTexture.name = newTextureName;
					flag = false;
				}
			}
			catch (IOException ex)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\Faction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Could not load image: ");
					messageBuilder.AppendFormatted(ex.Message);
				}
				Log.Error(messageBuilder);
				flag = true;
			}
			catch (UnauthorizedAccessException ex2)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(38, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\Faction.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Could not load image (access denied): ");
					messageBuilder.AppendFormatted(ex2.Message);
				}
				Log.Error(messageBuilder);
				flag = true;
			}
			if (flag)
			{
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Models\\Faction\\Faction.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Loading default image instead of ");
					messageBuilder2.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Info(messageBuilder2);
				Texture2D texture2D = AssetUtils.GetTexture2D(defaultFallback);
				outTexture = texture2D;
			}
		}

		private void CheckSpritesInit()
		{
			if (!spritesInit)
			{
				spritesInit = true;
				Texture2D texture2D = HeraldryCrestTexture;
				heraldryCrestSprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
				Texture2D texture2D2 = HeraldryBackgroundTexture;
				heraldryBackgroundSprite = Sprite.Create(texture2D2, new Rect(0f, 0f, texture2D2.width, texture2D2.height), new Vector2(0.5f, 0.5f), 100f);
			}
		}
	}
}
