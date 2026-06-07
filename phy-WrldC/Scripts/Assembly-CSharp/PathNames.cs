using UnityEngine;

public static class PathNames
{
	public static readonly string Data = Application.dataPath + "\\..\\Data\\";

	public static readonly string Schematics = Application.dataPath + "\\..\\Data\\Schematics\\";

	public static readonly string SchematicsInfos = Data + "schematics_infos.csv";

	public static readonly string SchematicsProperties = Data + "schematics_properties.csv";

	public static readonly string SchematicsPropertiesAES = Data + "schematics_properties.woc";

	public static readonly string MaterialsProperties = Data + "materials_properties.csv";

	public static readonly string MaterialsPropertiesAES = Data + "materials_properties.woc";

	public static readonly string Materials = Application.dataPath + "\\..\\Data\\Materials\\";

	public static readonly string Levels = Application.dataPath + "\\..\\Data\\Levels\\";

	public static readonly string Saves = Application.dataPath + "\\..\\Data\\Saves\\";

	public static readonly string QuickInventory = Saves + "quick_inventory.xml";

	public static readonly string DefaultQuickInventory = Data + "default_quick_inventory.xml";

	public static readonly string LEQuickInventory = Saves + "le_quick_inventory.xml";

	public static readonly string DefaultLEQuickInventory = Data + "default_le_quick_inventory.xml";

	public static readonly string Inventory = Data + "inventory.xml";

	public static readonly string UserProfile = Saves + "user_profile.xml";

	public static readonly string UserProfileAES = Saves + "user_profile.woc";

	public static readonly string UserCreations = Saves + "\\UserCreations\\";

	public static readonly string BestCreationsCampaign = Saves + "\\BestCreations\\Campaign\\";

	public static readonly string BestCreationsSandbox = Saves + "\\BestCreations\\Sandbox\\";

	public static readonly string UserParts = Saves + "\\UserParts\\";

	public static readonly string MenuCreations = Data + "\\MenuCreations\\";

	public static readonly string TemplateLevels = Levels + "\\Template\\";

	public static readonly string CampaignLevels = Levels + "\\Campaign\\";

	public static readonly string SandboxLevels = Levels + "\\Sandbox\\";

	public static readonly string TutorialLevels = Levels + "\\Tutorial\\";

	public static readonly string DefenderLevels = Saves + "\\DefenderLevels\\";

	public static readonly string UserLevels = Saves + "\\UserLevels\\";

	public static readonly string UserLevelParts = Saves + "\\UserLevelParts\\";

	public static readonly string UserGifs = Data + "\\Gifs\\";

	public static readonly string WorkshopTemp = Data + "\\WorkshopTemp\\";

	public static readonly string CampignLevelThumbnails = CampaignLevels + "\\Thumbs\\";

	public static readonly string FlagTextures = Data + "\\Flags\\";

	public static readonly string DevParts = Application.dataPath + "\\..\\Data\\Parts\\";

	public static readonly string CurrentCreationData = Saves + "current.xml";

	public static readonly string CurrentCreationDataAES = Saves + "current.sav";

	public static readonly string CustomLevelTemplateAES = Data + "custom_level_template.woc";

	public static readonly string UserLevelTemplates = Data + "\\UserLevelTemplates\\";

	public static readonly string Categories = Data + "categories.xml";

	public static readonly string LECategories = Data + "le_categories.xml";

	public static readonly string Languages = Data + "\\Languages\\";

	public static readonly string Options = Saves + "config.xml";

	public static readonly string LEOptions = Saves + "le_config.xml";

	public static readonly string HowToPlayPDF = Application.dataPath + "\\..\\HowToPlay.pdf";

	public const string ResourceComponentGizmosFolder = "Component Gizmos/";

	public static string LevelConfigXMLPath(string levelName)
	{
		return Levels + "\\" + levelName + "\\" + levelName + ".xml";
	}
}
