using System;
using System.IO;
using System.Xml.Linq;
using EncryptString;
using UnityEngine;

public static class LevelModelBuilder
{
	private const string TAG_LEVEL = "level";

	private const string ATTR_LEVEL_ID = "id";

	private const string ATTR_SCENE_NAME = "scene_name";

	private const string ATTR_IS_BRAIN_GOAL = "brain";

	private const string ATTR_HAS_DEFENDER_ZONE = "defender";

	private const string ATTR_IS_HIDDEN = "hidden";

	private const string ATTR_SANDBOX_GOAL = "sandbox_goal";

	private const string ATTR_GRAVITY = "gravity";

	private const string ATTR_RESTRICTED_BLOCKS = "restricted";

	private const string ATTR_COLLECTABLES = "collectables";

	private const string TAG_ID = "id";

	private const string TAG_NAME = "name";

	private const string TAG_DESCRIPTION = "description";

	private const string TAG_CREATION = "creation";

	private const string TAG_CUSTOM_OBJECTS = "customObjects";

	private const string TAG_OBJECT = "object";

	private const string ATTR_OBJECT_ID = "id";

	private const string ATTR_OBJECT_NAME = "name";

	private const string ATTR_OBJECT_TYPE = "type";

	private const string ATTR_OBJECT_POSITION = "pos";

	private const string ATTR_OBJECT_ROTATION = "rot";

	private const string ATTR_OBJECT_SCALE = "scl";

	private const string ATTR_OBJECT_PHYSICS = "phy";

	private const string ATTR_OBJECT_MASS = "mass";

	private const string ATTR_OBJECT_COLOR = "color";

	private const string ATTR_OBJECT_GRID_TEX = "grid";

	private const string ATTR_OBJECT_ALT_TEX_OFFSET = "alt";

	private const string ATTR_OBJECT_LOGIC = "logic";

	private const string ATTR_OBJECT_OUTPUT_ID = "oid";

	private const string ATTR_OBJECT_INVERTED_LOGIC = "il";

	private const string ATTR_OBJECT_PRESS_ONCE = "po";

	private const string TAG_ROTATOR = "rotator";

	private const string ATTR_ROTATOR_SPEED = "spd";

	private const string ATTR_ROTATOR_LOCAL_SPACE = "ls";

	public static XElement SaveXml(LevelModel levelModel, string directoryPath = null, bool isFileEncrypted = false)
	{
		return SaveXml(levelModel, directoryPath, isFileEncrypted, GameManager.LevelTypeState.None);
	}

	public static XElement SaveXml(LevelModel levelModel, string directoryPath, bool isFileEncrypted, GameManager.LevelTypeState levelType = GameManager.LevelTypeState.None)
	{
		XElement xElement = new XElement("level");
		xElement.Add(new XAttribute("id", levelModel.Id));
		xElement.Add(new XAttribute("scene_name", levelModel.SceneName));
		xElement.Add(new XAttribute("brain", levelModel.IsBrainDestroyedGoal));
		xElement.Add(new XAttribute("defender", levelModel.HasDefenderZone));
		xElement.Add(new XAttribute("hidden", levelModel.IsHidden));
		xElement.Add(new XAttribute("sandbox_goal", levelModel.IsSandboxWithGoal));
		xElement.Add(new XAttribute("gravity", levelModel.Gravity.PrintFullValues()));
		xElement.Add(new XAttribute("restricted", levelModel.RestrictedBlocksEnum.ToString()));
		xElement.Add(new XAttribute("collectables", levelModel.IsThereCollectables));
		XElement content = new XElement("name")
		{
			Value = levelModel.Name
		};
		XElement content2 = new XElement("description")
		{
			Value = levelModel.Description
		};
		xElement.Add(content);
		xElement.Add(content2);
		XElement content3 = CreationModelBuilder.SaveXml(levelModel.DefenderCreationModel);
		xElement.Add(content3);
		if (levelModel.CustomLevelObjectsModel.LevelObjectModelsCount() > 0)
		{
			XElement content4 = SaveCustomLevelObjectsXml(levelModel.CustomLevelObjectsModel);
			xElement.Add(content4);
		}
		if (!string.IsNullOrEmpty(directoryPath))
		{
			string fileName = GetFileName(levelModel, isFileEncrypted, levelType);
			string text = (levelModel.FilePath = directoryPath + fileName);
			XDocument xDocument = new XDocument();
			xDocument.Add(xElement);
			if (isFileEncrypted)
			{
				string contents = StringCipher.Encrypt(xDocument.ToString(), Util.PassPhrase);
				File.WriteAllText(text, contents);
			}
			else
			{
				xDocument.Save(text);
			}
		}
		return xElement;
	}

	public static XElement SaveCustomLevelObjectsXml(CustomLevelObjectsModel customLevelObjectsModel, string filePath = null)
	{
		XElement xElement = new XElement("customObjects");
		string value = ((customLevelObjectsModel.Id == null) ? "" : customLevelObjectsModel.Id);
		string value2 = ((customLevelObjectsModel.Name == null) ? "" : customLevelObjectsModel.Name);
		string value3 = ((customLevelObjectsModel.Description == null) ? "" : customLevelObjectsModel.Description);
		XElement content = new XElement("id")
		{
			Value = value
		};
		XElement content2 = new XElement("name")
		{
			Value = value2
		};
		XElement content3 = new XElement("description")
		{
			Value = value3
		};
		xElement.Add(content);
		xElement.Add(content2);
		xElement.Add(content3);
		LevelObjectModel[] allLevelObjectModels = customLevelObjectsModel.GetAllLevelObjectModels();
		foreach (LevelObjectModel levelObjectModel in allLevelObjectModels)
		{
			XElement xElement2 = new XElement("object");
			xElement2.Add(new XAttribute("id", levelObjectModel.Id));
			xElement2.Add(new XAttribute("name", levelObjectModel.Name));
			xElement2.Add(new XAttribute("type", levelObjectModel.LevelObjectType));
			xElement2.Add(new XAttribute("pos", levelObjectModel.Position.PrintFullValues()));
			xElement2.Add(new XAttribute("rot", levelObjectModel.Rotation.PrintFullValues()));
			xElement2.Add(new XAttribute("scl", levelObjectModel.Scale.PrintFullValues()));
			xElement2.Add(new XAttribute("phy", levelObjectModel.IsAffectedByPhysics));
			xElement2.Add(new XAttribute("mass", levelObjectModel.Mass));
			xElement2.Add(new XAttribute("color", "#" + ColorUtility.ToHtmlStringRGB(levelObjectModel.Color)));
			xElement2.Add(new XAttribute("grid", levelObjectModel.IsWithGrid));
			xElement2.Add(new XAttribute("alt", levelObjectModel.IsAltTexOffset));
			xElement2.Add(new XAttribute("logic", levelObjectModel.LogicType));
			xElement2.Add(new XAttribute("oid", levelObjectModel.LevelObjectOutputId));
			xElement2.Add(new XAttribute("il", levelObjectModel.IsInvertedLogic));
			xElement2.Add(new XAttribute("po", levelObjectModel.IsPressOnce));
			if (levelObjectModel.RotatorModel != null)
			{
				XElement xElement3 = new XElement("rotator");
				xElement3.Add(new XAttribute("spd", levelObjectModel.RotatorModel.Speed.PrintFullValues()));
				xElement3.Add(new XAttribute("ls", levelObjectModel.RotatorModel.IsLocalSpace));
				xElement2.Add(xElement3);
			}
			xElement.Add(xElement2);
		}
		if (!string.IsNullOrEmpty(filePath))
		{
			customLevelObjectsModel.FilePath = filePath;
			XDocument xDocument = new XDocument();
			xDocument.Add(xElement);
			xDocument.Save(filePath);
		}
		return xElement;
	}

	public static string GetFileName(LevelModel levelModel, bool isFileEncrypted, GameManager.LevelTypeState levelType = GameManager.LevelTypeState.None)
	{
		string text = levelModel.SceneName.Replace(' ', '_');
		string text2 = levelModel.Id.Replace(' ', '_');
		string text3 = levelModel.Name.Replace(' ', '_');
		string text4;
		switch (levelType)
		{
		case GameManager.LevelTypeState.Defender:
			text4 = text + "_" + text2 + "_" + text3;
			break;
		case GameManager.LevelTypeState.User:
			text4 = levelModel.Id;
			break;
		default:
			text4 = text + "_" + text2;
			break;
		}
		string text5 = (isFileEncrypted ? ".sav" : ".xml");
		return "lvl_" + text4 + text5;
	}

	public static LevelModel LoadXml(string filePath, bool isFileEncrypted)
	{
		XDocument xDocument = ((!isFileEncrypted) ? XDocument.Load(filePath) : XDocument.Parse(StringCipher.Decrypt(File.ReadAllText(filePath), Util.PassPhrase)));
		LevelModel levelModel = LoadXml(xDocument.Element("level"), filePath);
		levelModel.HashSHA256 = Util.GetHashSHA256(xDocument.ToString());
		return levelModel;
	}

	public static LevelModel LoadXml(XElement xLevel, string filePath = null)
	{
		XElement xElement = xLevel.Element("name");
		XElement xElement2 = xLevel.Element("description");
		string attributeAsString = xLevel.GetAttributeAsString("id", Util.RandomString(4));
		string attributeAsString2 = xLevel.GetAttributeAsString("scene_name");
		string value = xElement.Value;
		string value2 = xElement2.Value;
		bool attributeAsBool = xLevel.GetAttributeAsBool("brain");
		bool attributeAsBool2 = xLevel.GetAttributeAsBool("defender");
		bool attributeAsBool3 = xLevel.GetAttributeAsBool("hidden");
		bool attributeAsBool4 = xLevel.GetAttributeAsBool("sandbox_goal");
		Vector3 attributeAsVector = xLevel.GetAttributeAsVector3("gravity", Util.DefaultGravity);
		LevelModel.RestrictedBlocks attributeAsEnum = xLevel.GetAttributeAsEnum("restricted", LevelModel.RestrictedBlocks.None);
		bool attributeAsBool5 = xLevel.GetAttributeAsBool("collectables");
		LevelModel levelModel = new LevelModel
		{
			Id = attributeAsString,
			SceneName = attributeAsString2,
			Description = value2,
			Name = value,
			IsBrainDestroyedGoal = attributeAsBool,
			HasDefenderZone = attributeAsBool2,
			IsHidden = attributeAsBool3,
			IsSandboxWithGoal = attributeAsBool4,
			Gravity = attributeAsVector,
			RestrictedBlocksEnum = attributeAsEnum,
			IsThereCollectables = attributeAsBool5,
			FilePath = filePath
		};
		XElement xCreation = xLevel.Element("creation");
		if (GameManager.Exist)
		{
			CreationModel defenderCreationModel = CreationModelBuilder.LoadXml(xCreation, GameManager.Instance.SchematicCollection);
			levelModel.DefenderCreationModel = defenderCreationModel;
		}
		CustomLevelObjectsModel customLevelObjectsModel = LoadCustomLevelObjectsXml(xLevel.Element("customObjects"));
		if (customLevelObjectsModel != null)
		{
			LevelObjectModel[] allLevelObjectModels = customLevelObjectsModel.GetAllLevelObjectModels();
			foreach (LevelObjectModel levelObjectModel in allLevelObjectModels)
			{
				levelModel.CustomLevelObjectsModel.AddLevelObjectModel(levelObjectModel);
			}
		}
		return levelModel;
	}

	public static CustomLevelObjectsModel LoadCustomLevelObject(string filePath)
	{
		return LoadCustomLevelObjectsXml(XDocument.Load(filePath).Element("customObjects"), filePath);
	}

	public static CustomLevelObjectsModel LoadCustomLevelObjectsXml(XElement xCustomLevelObjects, string filePath = null)
	{
		if (xCustomLevelObjects == null)
		{
			return null;
		}
		string childTagValueAsString = xCustomLevelObjects.GetChildTagValueAsString("name");
		string childTagValueAsString2 = xCustomLevelObjects.GetChildTagValueAsString("description");
		string childTagValueAsString3 = xCustomLevelObjects.GetChildTagValueAsString("id", childTagValueAsString);
		CustomLevelObjectsModel customLevelObjectsModel = new CustomLevelObjectsModel
		{
			Id = childTagValueAsString3,
			Name = childTagValueAsString,
			Description = childTagValueAsString2,
			FilePath = filePath
		};
		foreach (XElement item in xCustomLevelObjects.Elements("object"))
		{
			LevelObjectModel levelObjectModel = new LevelObjectModel
			{
				Id = item.GetAttributeAsInt("id"),
				Name = item.GetAttributeAsString("name"),
				LevelObjectType = (LevelObjectType)Enum.Parse(typeof(LevelObjectType), item.GetAttributeAsString("type")),
				Position = Util.Vector3Parser(item.GetAttributeAsString("pos")),
				Rotation = Util.QuaternionParser(item.GetAttributeAsString("rot")),
				Scale = Util.Vector3Parser(item.GetAttributeAsString("scl")),
				IsAffectedByPhysics = item.GetAttributeAsBool("phy"),
				Mass = item.GetAttributeAsFloat("mass", 1f),
				Color = item.GetAttributeAsColor("color", Color.white),
				IsWithGrid = item.GetAttributeAsBool("grid", defaultValue: true),
				IsAltTexOffset = item.GetAttributeAsBool("alt"),
				LogicType = item.GetAttributeAsEnum("logic", LevelObjectLogicType.None),
				LevelObjectOutputId = item.GetAttributeAsInt("oid", -1),
				IsInvertedLogic = item.GetAttributeAsBool("il"),
				IsPressOnce = item.GetAttributeAsBool("po")
			};
			XElement xElement = item.Element("rotator");
			if (xElement != null)
			{
				levelObjectModel.RotatorModel = new LORotatorModel
				{
					Speed = Util.Vector3Parser(xElement.GetAttributeAsString("spd")),
					IsLocalSpace = xElement.GetAttributeAsBool("ls")
				};
			}
			customLevelObjectsModel.AddLevelObjectModel(levelObjectModel);
		}
		return customLevelObjectsModel;
	}

	public static LevelModel Clone(LevelModel levelModel, bool shouldGiveNewId = false)
	{
		LevelModel levelModel2 = LoadXml(SaveXml(levelModel));
		levelModel2.FilePath = levelModel.FilePath;
		if (shouldGiveNewId)
		{
			levelModel2.Id = Util.RandomString(4);
		}
		return levelModel2;
	}

	public static CustomLevelObjectsModel Clone(CustomLevelObjectsModel customLevelObjectsModel)
	{
		CustomLevelObjectsModel customLevelObjectsModel2 = LoadCustomLevelObjectsXml(SaveCustomLevelObjectsXml(customLevelObjectsModel));
		customLevelObjectsModel2.FilePath = customLevelObjectsModel.FilePath;
		return customLevelObjectsModel2;
	}
}
