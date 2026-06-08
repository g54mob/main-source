using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using BoardEditor;
using UnityEngine;

public class GameEditorScript : MonoBehaviour
{
	public enum EditModeEnum
	{
		RandomMode = 0,
		DesignMode = 1,
		DesignModeView = 2
	}

	private const string defaultNewBoardName = "NewGameBoard";

	private const int LOAD_WINDOW_WIDTH = 300;

	private const int LOAD_WINDOW_HEIGHT = 300;

	public static readonly Color TerminalColor = new Color(0f, 1f, 1f);

	public static readonly Color DefenseColor = new Color(0f, 0.5f, 0.5f);

	public static readonly Color SubSystemColor = new Color(1f, 0.5f, 0f);

	public static readonly Color InletColor = Color.magenta;

	public static readonly Color FuelColor = Color.green;

	public static readonly Color DoorColorLight = new Color(0.5f, 0.25f, 0.25f);

	public static readonly Color DoorColorDark = new Color(0.4f, 0.15f, 0.15f);

	public static readonly Color AirlockColor = Color.yellow;

	public static GameEditorScript Instance = null;

	private DungeonGenerator dungeonGenerator;

	private string DeveloperResourcePath = string.Empty;

	private Table gameTable;

	private Rect rectFileInfo = new Rect(10f, 0f, 2000f, 100f);

	private IGEObject mouseOverGEObject;

	private TileData mouseOverTile;

	private GEShadow shadow;

	private bool isShowingPlacement;

	private GECorridorEdit corridorEdit;

	private bool detectingKB;

	private float timeElapsed;

	private float timeTillNextInput = 0.1f;

	private bool isDraggingObject;

	private int prevXDrag = -1;

	private int prevYDrag = -1;

	private bool isNew = true;

	private bool isDirty;

	private bool isResourcePath;

	private string lastBoardName;

	private bool showHelpWindow;

	private HelpWindow helpWindow = new HelpWindow();

	private GUIStyle listStyle = new GUIStyle();

	private ComboBox loadBoardCombo;

	private GUIStyle inputStyle;

	private GUIStyle inputSubStyle;

	private GUIStyle inputSub2Style;

	private GUIStyle commandHintStyle;

	private GUIStyle errorStyle;

	private List<DungeonConfigurationManager.DungeonHelper.DungeonDefinition> dungeonDefList;

	private List<string> validationErrorMsgs = new List<string>();

	private bool showValidationErrors;

	private float delayHideValidationErrors;

	public bool CanChangeActiveObject
	{
		get
		{
			return !isDraggingObject && !isShowingShadow;
		}
	}

	public IGEObject activeGEObject { get; private set; }

	public bool isShowingShadow { get; private set; }

	public EditModeEnum currentEditMode { get; private set; }

	private void Awake()
	{
		Instance = this;
		GlobalSettings.IsGameEditor = true;
		currentEditMode = EditModeEnum.DesignMode;
		lastBoardName = "NewGameBoard";
		listStyle.normal.textColor = Color.white;
		GUIStyleState onHover = listStyle.onHover;
		Texture2D background = new Texture2D(2, 2);
		listStyle.hover.background = background;
		onHover.background = background;
		RectOffset padding = listStyle.padding;
		int num = 4;
		listStyle.padding.bottom = num;
		num = num;
		listStyle.padding.top = num;
		num = num;
		listStyle.padding.right = num;
		padding.left = num;
		ConfigureHelpForDesignMode();
		DeveloperResourcePath = ConfigFile.GetSetting("ResPath");
		commandHintStyle = new GUIStyle();
		commandHintStyle.normal.textColor = Color.gray;
		commandHintStyle.fontSize = 10;
		errorStyle = new GUIStyle();
		errorStyle.normal.textColor = new Color(1f, 0.2f, 0.2f);
		errorStyle.fontSize = 12;
		inputStyle = new GUIStyle();
		inputStyle.normal.textColor = Color.white;
		inputStyle.fontSize = 12;
		inputSubStyle = new GUIStyle("Label");
		inputSubStyle.normal.textColor = Color.white;
		inputSubStyle.fontSize = 10;
		inputSub2Style = new GUIStyle("Label");
		inputSub2Style.normal.textColor = Color.white;
		inputSub2Style.fontSize = 8;
		DungeonConfigurationManager.DungeonHelper.Initialize();
		dungeonDefList = DungeonConfigurationManager.DungeonHelper.GetAllDungeonDefinition(DungeonTypeEnum.Derelict);
	}

	private void Start()
	{
		dungeonGenerator = DungeonGenerator.GetInstance();
		gameTable = (Table)base.gameObject.GetComponent(typeof(Table));
		if (gameTable == null)
		{
			Debug.LogError("'Table' component not found!");
			return;
		}
		gameTable.SetCurrentPlayer(0);
		Table.seeEmptyTiles = true;
		InitEmptyBoard();
		gameTable.StartNewBoard();
		ConfigureObjectsForEditor();
		isNew = true;
		ResourceManager.OneTimeDungeonResourceLoad();
	}

	private void InitEmptyBoard()
	{
		if (gameTable.tiles == null)
		{
			gameTable.InitEmptyBoard(HandleTileScriptMouseDownOnTileEvent, null, HandleTileScriptMouseEnterTileEvent, HandleTileScriptMouseExitTileEvent);
			return;
		}
		DeactivateCurrentObject();
		gameTable.InitEmptyBoard();
	}

	private bool SaveBoard()
	{
		return SaveBoard(gameTable.boardFilePath);
	}

	private bool SaveBoard(string file)
	{
		if (gameTable.boardObjects.Count == 0)
		{
			ModalWindow.ShowModalWindow("Unable to Save", "This board doesn't have any objects!");
			return false;
		}
		XmlDocument doc = new XmlDocument();
		XmlNode xmlNode = doc.CreateNode(XmlNodeType.Element, "Board", string.Empty);
		doc.AppendChild(xmlNode);
		XmlNode parentNode = doc.CreateNode(XmlNodeType.Element, "Objects", string.Empty);
		AddMetaData(ref doc, ref parentNode, gameTable.metaDataList);
		xmlNode.AppendChild(parentNode);
		XmlAttribute xmlAttribute = doc.CreateAttribute("width");
		XmlAttribute xmlAttribute2 = doc.CreateAttribute("height");
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			IEnumerable<IGEObject> enumerable = null;
			switch (i)
			{
			case 0:
				enumerable = gameTable.boardObjects.Where((IGEObject x) => (x != null && x.objectType != GEObjectTypeEnum.Corridor) || (x.linkedObjects[0] != null && x.linkedObjects[1] != null));
				break;
			case 1:
				enumerable = gameTable.boardObjects.Where((IGEObject x) => x != null && x.objectType == GEObjectTypeEnum.Corridor && (x.linkedObjects[0] == null || x.linkedObjects[1] == null));
				break;
			}
			foreach (IGEObject item in enumerable)
			{
				item.ID = num.ToString();
				num++;
				XmlNode parentNode2 = doc.CreateNode(XmlNodeType.Element, "Obj", string.Empty);
				XmlAttribute xmlAttribute3 = doc.CreateAttribute("type");
				XmlAttribute xmlAttribute4 = doc.CreateAttribute("id");
				XmlAttribute xmlAttribute5 = doc.CreateAttribute("posX");
				XmlAttribute xmlAttribute6 = doc.CreateAttribute("posY");
				xmlAttribute3.Value = item.objectType.ToString();
				xmlAttribute4.Value = item.ID;
				xmlAttribute5.Value = item.currentLLCorner.x.ToString();
				xmlAttribute6.Value = item.currentLLCorner.y.ToString();
				parentNode2.Attributes.Append(xmlAttribute3);
				parentNode2.Attributes.Append(xmlAttribute4);
				parentNode2.Attributes.Append(xmlAttribute5);
				parentNode2.Attributes.Append(xmlAttribute6);
				switch (item.objectType)
				{
				case GEObjectTypeEnum.Room:
				{
					XmlAttribute xmlAttribute18 = doc.CreateAttribute("sizeX");
					XmlAttribute xmlAttribute19 = doc.CreateAttribute("sizeY");
					XmlAttribute xmlAttribute20 = doc.CreateAttribute("powerInletIdx");
					xmlAttribute18.Value = ((GERoom)item).Width.ToString();
					xmlAttribute19.Value = ((GERoom)item).Height.ToString();
					xmlAttribute20.Value = ((GERoom)item).settingPowerInletIndex.ToString();
					parentNode2.Attributes.Append(xmlAttribute18);
					parentNode2.Attributes.Append(xmlAttribute19);
					parentNode2.Attributes.Append(xmlAttribute20);
					break;
				}
				case GEObjectTypeEnum.Corridor:
				{
					XmlAttribute xmlAttribute12 = doc.CreateAttribute("layout");
					XmlAttribute xmlAttribute13 = doc.CreateAttribute("length");
					xmlAttribute12.Value = ((GECorridor)item).corridorLayout.ToString();
					xmlAttribute13.Value = ((GECorridor)item).corridorLength.ToString();
					parentNode2.Attributes.Append(xmlAttribute12);
					parentNode2.Attributes.Append(xmlAttribute13);
					if (item.linkedObjects == null)
					{
						break;
					}
					XmlNode xmlNode4 = doc.CreateElement("Joins");
					int count2 = item.linkedObjects.Count;
					for (int num3 = 0; num3 < count2; num3++)
					{
						IGEObject iGEObject2 = item.linkedObjects[num3];
						if (iGEObject2 != null)
						{
							XmlNode xmlNode5 = doc.CreateElement("Obj");
							XmlAttribute xmlAttribute14 = doc.CreateAttribute("type");
							XmlAttribute xmlAttribute15 = doc.CreateAttribute("id");
							XmlAttribute xmlAttribute16 = doc.CreateAttribute("side");
							xmlAttribute14.Value = iGEObject2.objectType.ToString();
							xmlAttribute15.Value = iGEObject2.ID;
							xmlAttribute16.Value = num3.ToString();
							xmlNode5.Attributes.Append(xmlAttribute14);
							xmlNode5.Attributes.Append(xmlAttribute15);
							xmlNode5.Attributes.Append(xmlAttribute16);
							xmlNode4.AppendChild(xmlNode5);
						}
					}
					parentNode2.AppendChild(xmlNode4);
					if ((item.linkedObjects[0] == null || item.linkedObjects[1] == null) && ((GECorridor)item).isStartingAirlock)
					{
						XmlAttribute xmlAttribute17 = doc.CreateAttribute("isStartingAirlock");
						xmlAttribute17.Value = true.ToString();
						parentNode2.Attributes.Append(xmlAttribute17);
					}
					break;
				}
				case GEObjectTypeEnum.PowerInlet:
				case GEObjectTypeEnum.Defense:
				case GEObjectTypeEnum.Terminal:
				case GEObjectTypeEnum.Vent:
				case GEObjectTypeEnum.SubSystem:
				case GEObjectTypeEnum.FuelAccess:
				{
					if (item.objectType == GEObjectTypeEnum.Terminal || item.objectType == GEObjectTypeEnum.Vent)
					{
						XmlAttribute xmlAttribute7 = doc.CreateAttribute("sizeX");
						XmlAttribute xmlAttribute8 = doc.CreateAttribute("sizeY");
						if (item.objectType == GEObjectTypeEnum.Terminal)
						{
							xmlAttribute7.Value = ((GETerminal)item).Width.ToString();
							xmlAttribute8.Value = ((GETerminal)item).Height.ToString();
						}
						else if (item.objectType == GEObjectTypeEnum.Vent)
						{
							xmlAttribute7.Value = ((GEVent)item).Width.ToString();
							xmlAttribute8.Value = ((GEVent)item).Height.ToString();
						}
						parentNode2.Attributes.Append(xmlAttribute7);
						parentNode2.Attributes.Append(xmlAttribute8);
					}
					if (item.linkedObjects == null)
					{
						break;
					}
					XmlNode xmlNode2 = doc.CreateElement("Joins");
					int count = item.linkedObjects.Count;
					for (int num2 = 0; num2 < count; num2++)
					{
						IGEObject iGEObject = item.linkedObjects[num2];
						if (iGEObject != null)
						{
							XmlNode xmlNode3 = doc.CreateElement("Obj");
							XmlAttribute xmlAttribute9 = doc.CreateAttribute("type");
							XmlAttribute xmlAttribute10 = doc.CreateAttribute("id");
							XmlAttribute xmlAttribute11 = doc.CreateAttribute("side");
							xmlAttribute9.Value = iGEObject.objectType.ToString();
							xmlAttribute10.Value = iGEObject.ID;
							xmlAttribute11.Value = num2.ToString();
							xmlNode3.Attributes.Append(xmlAttribute9);
							xmlNode3.Attributes.Append(xmlAttribute10);
							xmlNode3.Attributes.Append(xmlAttribute11);
							xmlNode2.AppendChild(xmlNode3);
						}
					}
					parentNode2.AppendChild(xmlNode2);
					break;
				}
				}
				AddMetaData(ref doc, ref parentNode2, item.metaDataList);
				parentNode.AppendChild(parentNode2);
			}
		}
		doc.Save(file);
		Debug.Log("File: " + file);
		Validate();
		return true;
	}

	private void AddMetaData(ref XmlDocument doc, ref XmlNode parentNode, List<DesignedDungeonManager.MetaData> metaDataList)
	{
		if (metaDataList == null)
		{
			return;
		}
		XmlNode xmlNode = doc.CreateElement("Meta");
		foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
		{
			if (metaData != null)
			{
				XmlNode xmlNode2 = doc.CreateElement("Data");
				XmlAttribute xmlAttribute = doc.CreateAttribute("name");
				XmlAttribute xmlAttribute2 = doc.CreateAttribute("value");
				xmlAttribute.Value = metaData.name;
				xmlAttribute2.Value = metaData.value;
				xmlNode2.Attributes.Append(xmlAttribute);
				xmlNode2.Attributes.Append(xmlAttribute2);
				xmlNode.AppendChild(xmlNode2);
			}
		}
		parentNode.AppendChild(xmlNode);
	}

	private void Validate()
	{
		validationErrorMsgs.Clear();
		IEnumerable<IGEObject> enumerable = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GERoom));
		if (enumerable.Count() > 0)
		{
			int num = 0;
			foreach (IGEObject item in enumerable)
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				foreach (IGEObject linkedObject in item.linkedObjects)
				{
					if (linkedObject != null)
					{
						switch (linkedObject.objectType)
						{
						case GEObjectTypeEnum.Defense:
							num5++;
							break;
						case GEObjectTypeEnum.PowerInlet:
							num3++;
							num++;
							break;
						case GEObjectTypeEnum.Terminal:
							num4++;
							break;
						case GEObjectTypeEnum.Vent:
							num2++;
							break;
						case GEObjectTypeEnum.FuelAccess:
							num6++;
							break;
						}
					}
				}
				if (num5 > 1)
				{
					validationErrorMsgs.Add("Validation Error: More than 1 defense found in room!");
				}
				if (num3 > 1)
				{
					validationErrorMsgs.Add("Validation Error: More than 1 power inlet found in room!");
				}
				if (num4 > 1)
				{
					validationErrorMsgs.Add("Validation Error: More than 1 terminal found in room!");
				}
				if (num2 > 1)
				{
					validationErrorMsgs.Add("Validation Error: More than 1 vent found in room!");
				}
				if (num6 > 1)
				{
					validationErrorMsgs.Add("Validation Error: More than 1 fuel access point found in room!");
				}
				if (num5 > 1 && num4 > 1)
				{
					validationErrorMsgs.Add("Validation Error: There is a defense in the same room as a terminal!");
				}
			}
			if (num == 0)
			{
				validationErrorMsgs.Add("Validation Error: No power inlets found in ship!");
			}
		}
		else
		{
			validationErrorMsgs.Add("Validation Error: No rooms found!");
		}
		IEnumerable<IGEObject> enumerable2 = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GECorridor) && (((GECorridor)x).linkedObjects[0] == null || ((GECorridor)x).linkedObjects[1] == null));
		if (enumerable2.Count() > 0)
		{
			bool flag = false;
			foreach (IGEObject item2 in enumerable2)
			{
				if (((GECorridor)item2).isStartingAirlock)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				validationErrorMsgs.Add("A starting airlock was not found!");
			}
		}
		else
		{
			validationErrorMsgs.Add("Validation Error: No airlocks found!");
		}
		IEnumerable<IGEObject> source = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GEPowerInlet));
		if (source.Count() == 0)
		{
			validationErrorMsgs.Add("Validation Error: No power inlets found!");
		}
		foreach (IGEObject item3 in enumerable)
		{
			foreach (IGEObject linkedObject2 in item3.linkedObjects)
			{
				if (linkedObject2 == null || linkedObject2.objectType != GEObjectTypeEnum.Defense)
				{
					continue;
				}
				bool flag2 = false;
				foreach (IGEObject item4 in enumerable)
				{
					if (item4 == item3 || ((GERoom)item4).settingPowerInletIndex != ((GERoom)item3).settingPowerInletIndex)
					{
						continue;
					}
					foreach (IGEObject linkedObject3 in item4.linkedObjects)
					{
						if (linkedObject3.objectType == GEObjectTypeEnum.Terminal)
						{
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						break;
					}
				}
				if (!flag2)
				{
					validationErrorMsgs.Add("Validation Error: Defense not on the same power grid as a terminal, or no terminals in ship!");
				}
			}
		}
		if (validationErrorMsgs.Count <= 0)
		{
			return;
		}
		foreach (string validationErrorMsg in validationErrorMsgs)
		{
			Debug.LogError(validationErrorMsg);
		}
		delayHideValidationErrors = 10f;
		showValidationErrors = true;
	}

	private void ConfigureHelpForDesignMode()
	{
		helpWindow.Clear();
		helpWindow.AddHelpTopic("'M'", "Toggle Edit Mode");
		helpWindow.AddHelpTopic("'B'", "Build Objects for Board");
		helpWindow.AddHelpTopic("'N'", "New");
		helpWindow.AddHelpTopic("'S'", "Save (replaces loaded file)");
		helpWindow.AddHelpTopic("ALT + 'S'", "Save As (choose a new file)");
		helpWindow.AddHelpTopic("'L'", "Load (from pre-defined locations)");
		helpWindow.AddHelpTopic("ALT + 'L'", "Load (specify full path/file name)");
	}

	private void ConfigureHelpForRandomMode()
	{
		helpWindow.Clear();
		helpWindow.AddHelpTopic("'M'", "Toggle Edit Mode");
		helpWindow.AddHelpTopic("'G'", "Generate Random Board");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			switch (currentEditMode)
			{
			case EditModeEnum.RandomMode:
				currentEditMode = EditModeEnum.DesignMode;
				ConfigureHelpForDesignMode();
				break;
			case EditModeEnum.DesignMode:
				currentEditMode = EditModeEnum.RandomMode;
				ConfigureHelpForRandomMode();
				break;
			}
		}
		switch (currentEditMode)
		{
		case EditModeEnum.RandomMode:
			if (Input.GetKeyDown(KeyCode.G))
			{
				RemoveAllObjects();
				InitEmptyBoard();
				dungeonGenerator.GenerateDungeon(DungeonTypeEnum.Derelict, 36, 28, string.Empty);
				DungeonBoardToEditorBoard();
			}
			break;
		case EditModeEnum.DesignMode:
			if (Input.anyKeyDown)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					DeactivateCurrentObject();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Alpha8))
				{
					int paintBrush = 8;
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						paintBrush = 1;
					}
					if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						paintBrush = 2;
					}
					if (Input.GetKeyDown(KeyCode.Alpha3))
					{
						paintBrush = 3;
					}
					if (Input.GetKeyDown(KeyCode.Alpha4))
					{
						paintBrush = 4;
					}
					if (Input.GetKeyDown(KeyCode.Alpha5))
					{
						paintBrush = 5;
					}
					if (Input.GetKeyDown(KeyCode.Alpha6))
					{
						paintBrush = 6;
					}
					if (Input.GetKeyDown(KeyCode.Alpha7))
					{
						paintBrush = 7;
					}
					if (Input.GetKeyDown(KeyCode.Alpha8))
					{
						paintBrush = 8;
					}
					SetPaintBrush(paintBrush);
				}
				else if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyDown(KeyCode.V))
				{
					Validate();
				}
				else if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyDown(KeyCode.R))
				{
					IEnumerable<IGEObject> enumerable = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GERoom));
					foreach (IGEObject item in enumerable)
					{
						GERoom gERoom = (GERoom)item;
						gERoom.RefreshTileProperties();
						gERoom.RefreshLinkedProperties(null);
					}
				}
				else if (Input.GetKeyDown(KeyCode.R))
				{
					DeactivateCurrentObject();
					isShowingShadow = true;
					shadow = new GEShadow(GEObjectTypeEnum.Room, 8, 8);
					if (mouseOverTile != null)
					{
						shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
					}
					else
					{
						shadow.SetLLCorner(20, 20);
					}
					prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
					prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
				}
				else if (Input.GetKeyDown(KeyCode.C))
				{
					if (!isShowingPlacement)
					{
						DeactivateCurrentObject();
						corridorEdit = new GECorridorEdit(gameTable);
						if (!corridorEdit.InitPlacement())
						{
							Debug.LogWarning("Could not find a straight line between any of the rooms (only straight corridors currently suported)");
							corridorEdit = null;
						}
						else
						{
							corridorEdit.InitAirlockPlacement();
							isShowingPlacement = true;
							corridorEdit.CorriorRequestedEvent += HandleCorriorRequestedEvent;
						}
					}
				}
				else if (Input.GetKeyDown(KeyCode.P))
				{
					DeactivateCurrentObject();
					isShowingShadow = true;
					shadow = new GEShadow(GEObjectTypeEnum.PowerInlet, 2, 2);
					if (mouseOverTile != null)
					{
						shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
					}
					else
					{
						shadow.SetLLCorner(20, 20);
					}
					prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
					prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
				}
				else if (Input.GetKeyDown(KeyCode.F))
				{
					DeactivateCurrentObject();
					isShowingShadow = true;
					shadow = new GEShadow(GEObjectTypeEnum.FuelAccess, 2, 2);
					if (mouseOverTile != null)
					{
						shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
					}
					else
					{
						shadow.SetLLCorner(20, 20);
					}
					prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
					prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
				}
				else if (Input.GetKeyDown(KeyCode.T))
				{
					DeactivateCurrentObject();
					isShowingShadow = true;
					shadow = new GEShadow(GEObjectTypeEnum.Terminal, 2, 1);
					if (mouseOverTile != null)
					{
						shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
					}
					else
					{
						shadow.SetLLCorner(20, 20);
					}
					prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
					prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
				}
				else if (Input.GetKeyDown(KeyCode.V))
				{
					DeactivateCurrentObject();
					isShowingShadow = true;
					shadow = new GEShadow(GEObjectTypeEnum.Vent, 2, 1);
					if (mouseOverTile != null)
					{
						shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
					}
					else
					{
						shadow.SetLLCorner(20, 20);
					}
					prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
					prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
				}
				else if (Input.GetKeyDown(KeyCode.D))
				{
					DeactivateCurrentObject();
					isShowingShadow = true;
					shadow = new GEShadow(GEObjectTypeEnum.Defense, 1, 1);
					if (mouseOverTile != null)
					{
						shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
					}
					else
					{
						shadow.SetLLCorner(20, 20);
					}
					prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
					prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
				}
				else if (Input.GetKeyDown(KeyCode.U))
				{
					DeactivateCurrentObject();
					isShowingShadow = true;
					shadow = new GEShadow(GEObjectTypeEnum.SubSystem, 1, 1);
					if (mouseOverTile != null)
					{
						shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
					}
					else
					{
						shadow.SetLLCorner(20, 20);
					}
					prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
					prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
				}
				else if (Input.GetKeyDown(KeyCode.S) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
				{
					string empty = string.Empty;
					empty = (isResourcePath ? (Path.Combine(DeveloperResourcePath, lastBoardName) + ".xml") : GameFileHelper.GetBoardFullPath(lastBoardName));
					ModalWindow.ShowModalWindow("Save Board As", "Enter new board's file name and path:", ModalWindowType.OKCancel, true, empty, delegate(ModalWindowResult result, string inputString)
					{
						if (result == ModalWindowResult.OK)
						{
							Debug.Log("Save: " + inputString);
							if (!string.IsNullOrEmpty(inputString))
							{
								if (SaveBoard(inputString))
								{
									isNew = false;
									gameTable.boardFilePath = inputString;
								}
								else
								{
									ModalWindow.ShowModalWindow("Yikes", "There was an error while trying to save that file.\r\n\r\nPlease see the console for more information.");
								}
							}
						}
					}, Screen.width - 100, 60);
				}
				else if (Input.GetKeyDown(KeyCode.S))
				{
					if (isNew)
					{
						string text = string.Empty;
						if (isResourcePath)
						{
							text = "\r\n\r\nThis is a Resource File!";
						}
						ModalWindow.ShowModalWindow("Save Board", "Enter Board Name" + text, ModalWindowType.OKCancel, true, lastBoardName, delegate(ModalWindowResult result, string inputString)
						{
							if (result == ModalWindowResult.OK)
							{
								string empty2 = string.Empty;
								empty2 = (isResourcePath ? (Path.Combine(DeveloperResourcePath, inputString) + ".xml") : GameFileHelper.GetBoardFullPath(inputString));
								Debug.Log("Save: " + empty2);
								if (!string.IsNullOrEmpty(empty2))
								{
									if (SaveBoard(empty2))
									{
										isNew = false;
										gameTable.boardFilePath = empty2;
										lastBoardName = GameFileHelper.GetBoardNameFromPath(empty2);
									}
									else
									{
										ModalWindow.ShowModalWindow("Yikes", "There was an error while trying to save that file.\r\n\r\nPlease see the console for more information.");
									}
								}
							}
						});
					}
					else if (SaveBoard())
					{
						ModalWindow.ShowModalWindow("File Saved", "File Saved");
					}
					else
					{
						ModalWindow.ShowModalWindow("Yikes", "There was an error while trying to save that file.\r\n\r\nPlease see the console for more information.");
					}
				}
				else if (Input.GetKeyDown(KeyCode.L) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
				{
					if (!isDirty)
					{
						string boardFullPath = GameFileHelper.GetBoardFullPath(lastBoardName);
						ModalWindow.ShowModalWindow("Load Board", "Full Filename and Path of Board to Load", ModalWindowType.OKCancel, true, boardFullPath, delegate(ModalWindowResult result, string inputString)
						{
							if (result == ModalWindowResult.OK)
							{
								Debug.Log("Load: " + inputString);
								if (!string.IsNullOrEmpty(inputString))
								{
									InitEmptyBoard();
									List<DesignedDungeonManager.MetaData> metaDataList = null;
									if (!gameTable.LoadBoard(inputString, ref metaDataList))
									{
										ModalWindow.ShowModalWindow("Yeah, no", "There was an error while trying to load the file:\r\n\r\n" + inputString + "\r\n\r\nPlease see the console for more information.");
									}
									else
									{
										gameTable.metaDataList = metaDataList;
										ConfigureObjectsForEditor();
									}
								}
							}
						}, Screen.width - 100, 75);
					}
					else
					{
						Debug.LogWarning("Current board is dirty.  Save, first");
					}
				}
				else if (Input.GetKeyDown(KeyCode.L))
				{
					if (!isDirty)
					{
						GUIContent[] array = GameFileHelper.GetBoardFilesAsGuiContent();
						int num = 0;
						for (int num2 = 0; num2 < array.Length; num2++)
						{
							if (array[num2].text.ToUpper() == lastBoardName.ToUpper())
							{
								num = num2;
								break;
							}
						}
						if (!string.IsNullOrEmpty(DeveloperResourcePath) && Directory.Exists(DeveloperResourcePath))
						{
							string[] files = Directory.GetFiles(DeveloperResourcePath);
							string[] array2 = files;
							foreach (string text2 in array2)
							{
								if (text2.EndsWith(".xml"))
								{
									Array.Resize(ref array, array.Length + 1);
									string fileName = Path.GetFileName(text2);
									fileName = fileName.Replace(".xml", string.Empty);
									array[array.Length - 1] = new GUIContent(fileName + " [RES]");
								}
							}
						}
						loadBoardCombo = new ComboBox(new Rect(10f, 45f, 195f, 20f), array[num], array, "button", "box", listStyle, 250);
						ModalWindow.ShowModalWindowCustom("Load Board", 300, 300, DrawLoadBoardWindow);
					}
					else
					{
						Debug.LogWarning("Current board is dirty.  Save, first");
					}
				}
				else if (Input.GetKeyDown(KeyCode.N))
				{
					ModalWindow.ShowModalWindow("Start a New Board?", "Are you sure you want to start a new board?", ModalWindowType.YesNo, false, string.Empty, delegate(ModalWindowResult result, string inputString)
					{
						if (result == ModalWindowResult.Yes)
						{
							if (!isDirty)
							{
								InitEmptyBoard();
								gameTable.StartNewBoard();
								lastBoardName = "NewGameBoard";
							}
							else
							{
								Debug.LogWarning("Current board is dirty.  Save, first");
							}
							isNew = true;
						}
					});
				}
				else if (Input.GetKeyDown(KeyCode.B))
				{
					RemoveAllObjects();
					Validate();
					DesignedDungeonManager.BuildDesignedDungeon(gameTable.boardObjects, false, false);
					foreach (Room builtRoom in DungeonBuilder.Instance.builtRooms)
					{
						builtRoom.GetComponent<Renderer>().enabled = true;
					}
					UnityEngine.Object[] array3 = UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
					UnityEngine.Object[] array4 = array3;
					foreach (UnityEngine.Object obj in array4)
					{
						string text3 = obj.name.ToLower();
						if (text3.Contains("vent"))
						{
							((GameObject)obj).GetComponent<Renderer>().enabled = true;
						}
					}
					int length = DesignedDungeonManager.tiles.GetLength(0);
					int length2 = DesignedDungeonManager.tiles.GetLength(1);
					for (int num5 = 0; num5 < length; num5++)
					{
						for (int num6 = 0; num6 < length2; num6++)
						{
							DesignedDungeonManager.tiles[num5, num6].visualComponent.GetComponent<Renderer>().enabled = false;
						}
					}
					currentEditMode = EditModeEnum.DesignModeView;
				}
				else if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.KeypadEquals) || Input.GetKeyDown(KeyCode.Equals))
				{
					if (isShowingShadow)
					{
						shadow.Rotate();
					}
					else if (activeGEObject != null && activeGEObject.canRotate)
					{
						activeGEObject.Rotate();
					}
				}
			}
			if (showValidationErrors)
			{
				delayHideValidationErrors -= Time.deltaTime;
				if (delayHideValidationErrors <= 0f)
				{
					delayHideValidationErrors = 0f;
					showValidationErrors = false;
				}
			}
			break;
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			if (currentEditMode == EditModeEnum.DesignModeView)
			{
				RemoveAllObjects();
				int length3 = gameTable.tiles.GetLength(0);
				int length4 = gameTable.tiles.GetLength(1);
				for (int num7 = 0; num7 < length3; num7++)
				{
					for (int num8 = 0; num8 < length4; num8++)
					{
						gameTable.tiles[num7, num8].visualComponent.GetComponent<Renderer>().enabled = true;
					}
				}
				currentEditMode = EditModeEnum.DesignMode;
			}
			else
			{
				ModalWindow.ShowModalWindow("Quit Editor?", "Quit editor and return to the main menu?", ModalWindowType.YesNo, false, string.Empty, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.Yes)
					{
						Application.LoadLevel("NetworkMenuScene");
					}
				});
			}
		}
		if (IsHelpKeyPress())
		{
			showHelpWindow = !showHelpWindow;
		}
		if (activeGEObject == null)
		{
			return;
		}
		if (!InputState.ModifierKeyDown && Input.GetKeyDown(KeyCode.Delete) && (activeGEObject.objectType == GEObjectTypeEnum.Corridor || activeGEObject.objectType == GEObjectTypeEnum.PowerInlet || activeGEObject.objectType == GEObjectTypeEnum.FuelAccess || activeGEObject.objectType == GEObjectTypeEnum.Defense || activeGEObject.objectType == GEObjectTypeEnum.SubSystem || activeGEObject.objectType == GEObjectTypeEnum.Terminal || activeGEObject.objectType == GEObjectTypeEnum.Vent || activeGEObject.linkedObjects.Count == 0))
		{
			foreach (IGEObject linkedObject in activeGEObject.linkedObjects)
			{
				if (linkedObject != null)
				{
					linkedObject.BreakLinkToObject(activeGEObject);
				}
			}
			activeGEObject.Destroy();
			activeGEObject.DeActivate();
			int count = gameTable.boardObjects.Count;
			int num9 = -1;
			for (int num10 = 0; num10 < count; num10++)
			{
				if (gameTable.boardObjects[num10] == activeGEObject)
				{
					num9 = num10;
					break;
				}
			}
			if (num9 >= 0)
			{
				gameTable.boardObjects.RemoveAt(num9);
				Debug.Log("Killed Object");
			}
			activeGEObject = null;
		}
		if (InputState.shiftDown)
		{
			int num11 = 0;
			int num12 = 0;
			if (InputState.upArrowDown)
			{
				num12 = 1;
			}
			else if (InputState.downArrowDown)
			{
				num12 = -1;
			}
			if (InputState.rightArrowDown)
			{
				num11 = 1;
			}
			else if (InputState.leftArrowDown)
			{
				num11 = -1;
			}
			if (num11 != 0 || num12 != 0)
			{
				if (detectingKB)
				{
					timeElapsed += Time.deltaTime;
					if (timeElapsed >= timeTillNextInput)
					{
						timeElapsed = 0f;
					}
				}
				else
				{
					detectingKB = true;
					timeElapsed = 0f;
				}
				if (timeElapsed == 0f && CanMoveActive(num11, num12))
				{
					activeGEObject.Move(num11, num12);
				}
			}
			else
			{
				detectingKB = false;
			}
		}
		else
		{
			detectingKB = false;
		}
	}

	private void RemoveAllObjects()
	{
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
		UnityEngine.Object[] array2 = array;
		foreach (UnityEngine.Object obj in array2)
		{
			string text = obj.name.ToLower();
			if (text.Contains("prefab") || text.StartsWith("waypoint") || text.StartsWith("dungeonterminalinternal") || text.StartsWith("dungeonpowerinlet"))
			{
				UnityEngine.Object.Destroy(obj);
			}
		}
	}

	private void DrawLoadBoardWindow(int windowID)
	{
		loadBoardCombo.Show();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Select a game board to load");
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Space(200f);
		if (GUILayout.Button("OK"))
		{
			ModalWindow.CloseModalWindow();
			string empty = string.Empty;
			if (loadBoardCombo.SelectedItemText.Contains("[RES]"))
			{
				string path = loadBoardCombo.SelectedItemText.Replace("[RES]", string.Empty).Trim() + ".xml";
				empty = Path.Combine(DeveloperResourcePath, path);
				isResourcePath = true;
			}
			else
			{
				empty = GameFileHelper.GetBoardFullPath(loadBoardCombo.SelectedItemText);
				isResourcePath = false;
			}
			Debug.Log("Load: " + empty);
			if (!string.IsNullOrEmpty(empty))
			{
				InitEmptyBoard();
				List<DesignedDungeonManager.MetaData> metaDataList = null;
				if (!gameTable.LoadBoard(empty, ref metaDataList))
				{
					ModalWindow.ShowModalWindow("Yeah, no", "There was an error while trying to load the file:\r\n\r\n" + empty + "\r\n\r\nPlease see the console for more information.");
				}
				else
				{
					gameTable.metaDataList = metaDataList;
					ConfigureObjectsForEditor();
					lastBoardName = GameFileHelper.GetBoardNameFromPath(empty);
				}
			}
		}
		if (GUILayout.Button("Cancel"))
		{
			ModalWindow.CloseModalWindow();
		}
		GUILayout.EndHorizontal();
	}

	private bool IsHelpKeyPress()
	{
		return Input.GetKeyDown(KeyCode.Slash) || Input.GetKeyDown(KeyCode.Question);
	}

	private void DeactivateCurrentObject()
	{
		if (activeGEObject != null)
		{
			activeGEObject.DeActivate();
			activeGEObject = null;
		}
		if (isShowingShadow)
		{
			isShowingShadow = false;
			shadow.DeActivate();
			shadow = null;
		}
		if (isShowingPlacement)
		{
			isShowingPlacement = false;
			corridorEdit.DeActivate();
			corridorEdit.CorriorRequestedEvent -= HandleCorriorRequestedEvent;
			corridorEdit = null;
		}
	}

	public void OnGUI()
	{
		if (isNew)
		{
			GUI.Label(rectFileInfo, "NEW BOARD LAYOUT");
		}
		else
		{
			GUI.Label(rectFileInfo, "Current File Path: " + gameTable.boardFilePath);
		}
		string text = currentEditMode.ToString();
		string text2 = string.Empty;
		switch (currentEditMode)
		{
		case EditModeEnum.RandomMode:
			text = "Random";
			break;
		case EditModeEnum.DesignMode:
			text = "Design";
			break;
		case EditModeEnum.DesignModeView:
			text = "Design (View)";
			text2 = "Press 'X' to return to editor";
			break;
		}
		Rect position = new Rect(10f, 25f, 200f, 20f);
		if (text2 != string.Empty)
		{
			GUI.Label(position, text2);
			position.y += 25f;
		}
		if (currentEditMode == EditModeEnum.DesignMode)
		{
			position.height = 25f;
			GUI.Label(position, "Choose Hull Type -", inputStyle);
			position.y += 20f;
			string metaDataValue = gameTable.GetMetaDataValue("hulltype");
			if (metaDataValue == string.Empty)
			{
				gameTable.SetMetaData("hulltype", "0");
			}
			position.height -= 10f;
			for (int i = 0; i < 3; i++)
			{
				switch (i)
				{
				case 0:
					if (GUI.Button(position, string.Format("  [ {0} ] Good", (!(metaDataValue == "0")) ? " " : "X"), inputSubStyle))
					{
						gameTable.SetMetaData("hulltype", "0");
					}
					break;
				case 1:
					if (GUI.Button(position, string.Format("  [ {0} ] Medium", (!(metaDataValue == "1")) ? " " : "X"), inputSubStyle))
					{
						gameTable.SetMetaData("hulltype", "1");
					}
					break;
				case 2:
					if (GUI.Button(position, string.Format("  [ {0} ] Poor", (!(metaDataValue == "2")) ? " " : "X"), inputSubStyle))
					{
						gameTable.SetMetaData("hulltype", "2");
					}
					break;
				}
				position.y += 15f;
			}
			position.y += 15f;
			position.height += 10f;
			GUI.Label(position, "Choose Definition -", inputStyle);
			position.y += 20f;
			string metaDataValue2 = gameTable.GetMetaDataValue("duntype");
			if (metaDataValue2 == string.Empty)
			{
				gameTable.SetMetaData("duntype", "0");
			}
			int num = 1;
			position.height -= 10f;
			if (GUI.Button(position, string.Format("  [ {0} ] Random", (!(metaDataValue2 == "0")) ? " " : "X"), inputSubStyle))
			{
				gameTable.SetMetaData("duntype", "0");
			}
			position.y += 15f;
			foreach (DungeonConfigurationManager.DungeonHelper.DungeonDefinition dungeonDef in dungeonDefList)
			{
				if (GUI.Button(position, string.Format("  [ {0} ] {1}", (!(metaDataValue2 == dungeonDef.name)) ? " " : "X", dungeonDef.name), inputSubStyle))
				{
					gameTable.SetMetaData("duntype", dungeonDef.name);
				}
				position.y += 15f;
				if (metaDataValue2 == dungeonDef.name)
				{
					List<DungeonConfigurationManager.DungeonHelper.DungeonClassDefinition> classList = dungeonDef.GetClassList();
					string metaDataValue3 = gameTable.GetMetaDataValue("classtype");
					position.height -= 2f;
					foreach (DungeonConfigurationManager.DungeonHelper.DungeonClassDefinition item in classList)
					{
						if (GUI.Button(position, string.Format("          [ {0} ] {1}", (!(metaDataValue3 == item.name)) ? " " : "X", item.name), inputSub2Style))
						{
							gameTable.SetMetaData("classtype", item.name);
						}
						position.y += 10f;
					}
					position.height += 2f;
				}
				num++;
			}
			position.y += 15f;
			position.height += 10f;
			if (!isShowingPlacement)
			{
				position.height = 20f;
				position.y += 100f;
				GUI.Label(position, "'R' to add room", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'C' to add corridor (door/airlock)", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'P' to add power inlet", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'T' to add terminal", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'D' to add defense", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'V' to add vent", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'U' to add ship upgrade", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'F' to add fuel access", commandHintStyle);
				position.y += 10f;
				position.y += 10f;
				GUI.Label(position, "Click on object to see/set additional properties on right-side of screen", commandHintStyle);
				position.y += 20f;
				GUI.Label(position, "'B' to build (preview ship)", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "SHIFT+'V' to validate (errors displayed in console)", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "'S' to save", commandHintStyle);
				position.y += 10f;
				GUI.Label(position, "SHIFT+'R' to refresh colors (fixes colors when they get jumbled up)", commandHintStyle);
			}
		}
		if (showValidationErrors)
		{
			position.y = Screen.height - 25 * validationErrorMsgs.Count;
			foreach (string validationErrorMsg in validationErrorMsgs)
			{
				GUI.Label(position, validationErrorMsg, errorStyle);
				position.y += 15f;
			}
		}
		GUI.Label(new Rect(Screen.width - 150, 2f, 150f, 20f), "Mode: " + text);
		if (!showHelpWindow)
		{
			GUI.Label(new Rect(Screen.width - 150, 22f, 150f, 20f), "Press '?' For Help");
		}
		else
		{
			GUI.Label(new Rect(Screen.width - 150, 22f, 150f, 20f), "Press '?' To Close Help");
		}
		if (currentEditMode == EditModeEnum.DesignMode)
		{
			position = new Rect(Screen.width - 150, 100f, 150f, 25f);
			if (activeGEObject != null)
			{
				bool flag = false;
				if (activeGEObject.GetType() == typeof(GERoom))
				{
					string metaDataValue4 = activeGEObject.GetMetaDataValue("roomnum");
					if (metaDataValue4 == string.Empty)
					{
						activeGEObject.SetMetaData("roomnum", "0");
					}
					int num2 = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GERoom)).Count();
					GUI.Label(position, "Choose Room Number -", inputStyle);
					position.y += 20f;
					position.height -= 10f;
					if (GUI.Button(position, string.Format("  [ {0} ] System-Driven", (!(metaDataValue4 == "0")) ? " " : "X"), inputSubStyle))
					{
						activeGEObject.SetMetaData("roomnum", "0");
					}
					position.width = 60f;
					position.y += 15f;
					int num3 = 0;
					string arg = "  ";
					for (int num4 = 0; num4 < num2; num4++)
					{
						int num5 = num4 + 2;
						if (GUI.Button(position, string.Format("{0}[ {1} ] R{2}", arg, (!(metaDataValue4 == num5.ToString())) ? " " : "X", num5), inputSubStyle))
						{
							activeGEObject.SetMetaData("roomnum", num5.ToString());
						}
						num3++;
						if (num3 < 2)
						{
							position.x += 60f;
							arg = string.Empty;
							continue;
						}
						position.x = Screen.width - 150;
						position.y += 15f;
						num3 = 0;
						arg = "  ";
					}
					position.y += 15f;
					position.y += 15f;
					position.x = Screen.width - 150;
					position.width = 150f;
					position.height += 10f;
					flag = true;
					IEnumerable<IGEObject> source = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GEPowerInlet));
					int num6 = source.Count();
					if (num6 > 0)
					{
						GUI.Label(position, "Choose Inlet -", inputStyle);
						position.y += 20f;
						position.height -= 10f;
						for (int num7 = 0; num7 < num6; num7++)
						{
							if (GUI.Button(position, string.Format("  [ {0} ] Inlet #{1}", (((GERoom)activeGEObject).settingPowerInletIndex != num7) ? " " : "X", num7 + 1), inputSubStyle))
							{
								((GERoom)activeGEObject).settingPowerInletIndex = num7;
							}
							position.y += 15f;
						}
						position.y += 15f;
						position.height += 10f;
					}
					else
					{
						GUI.Label(position, "No power Inlets!", inputStyle);
						position.y += 15f;
					}
					GUI.Label(position, "Set Enemy Type -", inputStyle);
					position.y += 20f;
					position.height -= 10f;
					string metaDataValue5 = activeGEObject.GetMetaDataValue("enemy");
					if (metaDataValue5 == string.Empty)
					{
						activeGEObject.SetMetaData("enemy", "0");
					}
					for (int num8 = 0; num8 < 4; num8++)
					{
						switch (num8)
						{
						case 0:
							if (GUI.Button(position, string.Format("  [ {0} ] None", (!(metaDataValue5 == "0")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("enemy", "0");
							}
							break;
						case 1:
							if (GUI.Button(position, string.Format("  [ {0} ] Bot", (!(metaDataValue5 == "1")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("enemy", "1");
							}
							break;
						case 2:
							if (GUI.Button(position, string.Format("  [ {0} ] Swarm", (!(metaDataValue5 == "2")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("enemy", "2");
							}
							break;
						case 3:
							if (GUI.Button(position, string.Format("  [ {0} ] Brute", (!(metaDataValue5 == "3")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("enemy", "3");
							}
							break;
						case 4:
							if (GUI.Button(position, string.Format("  [ {0} ] Slime", (!(metaDataValue5 == "4")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("enemy", "4");
							}
							break;
						}
						position.y += 15f;
					}
					position.y += 15f;
					position.height += 10f;
					GUI.Label(position, "Lootable Drones in Room -", inputStyle);
					position.y += 20f;
					position.height -= 10f;
					string text3 = activeGEObject.GetMetaDataValue("lootabledrones");
					if (text3 == string.Empty)
					{
						activeGEObject.SetMetaData("lootabledrones", "0");
						text3 = "0";
					}
					if (GUI.Button(position, string.Format("  [ {0} ] Damaged", text3), inputSubStyle))
					{
						int result = 0;
						if (int.TryParse(text3, out result))
						{
							Event current4 = Event.current;
							result = (current4.shift ? (result - 1) : (result + 1));
							if (result < 0)
							{
								result = 0;
							}
						}
						activeGEObject.SetMetaData("lootabledrones", result.ToString());
					}
					position.y += 15f;
					text3 = activeGEObject.GetMetaDataValue("lootabledronesdead");
					if (text3 == string.Empty)
					{
						activeGEObject.SetMetaData("lootabledronesdead", "0");
						text3 = "0";
					}
					if (GUI.Button(position, string.Format("  [ {0} ] Dead", text3), inputSubStyle))
					{
						int result2 = 0;
						if (int.TryParse(text3, out result2))
						{
							Event current5 = Event.current;
							result2 = (current5.shift ? (result2 - 1) : (result2 + 1));
							if (result2 < 0)
							{
								result2 = 0;
							}
						}
						activeGEObject.SetMetaData("lootabledronesdead", result2.ToString());
					}
					position.y += 30f;
					position.height += 10f;
					GUI.Label(position, "Scrap in Room -", inputStyle);
					position.y += 20f;
					position.height -= 10f;
					string text4 = activeGEObject.GetMetaDataValue("rations");
					if (text4 == string.Empty)
					{
						activeGEObject.SetMetaData("rations", "0");
						text4 = "0";
					}
					if (GUI.Button(position, string.Format("  [ {0} ] Visible", text4), inputSubStyle))
					{
						int result3 = 0;
						if (int.TryParse(text4, out result3))
						{
							Event current6 = Event.current;
							result3 = (current6.shift ? (result3 - 1) : (result3 + 1));
							if (result3 < 0)
							{
								result3 = 0;
							}
						}
						activeGEObject.SetMetaData("rations", result3.ToString());
					}
					position.y += 15f;
					text4 = activeGEObject.GetMetaDataValue("rationshidden");
					if (text4 == string.Empty)
					{
						activeGEObject.SetMetaData("rationshidden", "0");
						text4 = "0";
					}
					if (GUI.Button(position, string.Format("  [ {0} ] Hidden", text4), inputSubStyle))
					{
						int result4 = 0;
						if (int.TryParse(text4, out result4))
						{
							Event current7 = Event.current;
							result4 = (current7.shift ? (result4 - 1) : (result4 + 1));
							if (result4 < 0)
							{
								result4 = 0;
							}
						}
						activeGEObject.SetMetaData("rationshidden", result4.ToString());
					}
					position.y += 30f;
					position.height += 10f;
					GUI.Label(position, "Motion -", inputStyle);
					position.y += 20f;
					position.height -= 10f;
					string text5 = activeGEObject.GetMetaDataValue("motionstatus");
					if (text5 == string.Empty)
					{
						activeGEObject.SetMetaData("motionstatus", "0");
						text5 = "0";
					}
					if (GUI.Button(position, string.Format("  [ {0} ] Broken", (!(text5 == "1")) ? " " : "X"), inputSubStyle))
					{
						text5 = ((!(text5 == "0")) ? "0" : "1");
						activeGEObject.SetMetaData("motionstatus", text5);
					}
					position.y += 15f;
					position.height += 10f;
				}
				else if (activeGEObject.GetType() == typeof(GEPowerInlet))
				{
					int num9 = 0;
					foreach (IGEObject boardObject in gameTable.boardObjects)
					{
						if (boardObject.GetType() == typeof(GEPowerInlet))
						{
							if (boardObject == activeGEObject)
							{
								GUI.Label(position, string.Format("Inlet #{0}", num9 + 1), inputStyle);
								position.y += 25f;
								break;
							}
							num9++;
						}
					}
				}
				else if (activeGEObject.GetType() == typeof(GEFuelAccess))
				{
					GUI.Label(position, "Fuel -", inputStyle);
					position.y += 20f;
					position.height -= 10f;
					string text6 = activeGEObject.GetMetaDataValue("fueljump");
					if (text6 == string.Empty)
					{
						activeGEObject.SetMetaData("fueljump", "0");
						text6 = "0";
					}
					if (GUI.Button(position, string.Format("  [ {0} ] Jump", text6), inputSubStyle))
					{
						int result5 = 0;
						if (int.TryParse(text6, out result5))
						{
							Event current9 = Event.current;
							result5 = (current9.shift ? (result5 - 1) : (result5 + 1));
							if (result5 < 0)
							{
								result5 = 0;
							}
						}
						activeGEObject.SetMetaData("fueljump", result5.ToString());
					}
					position.y += 15f;
					text6 = activeGEObject.GetMetaDataValue("fuelprop");
					if (text6 == string.Empty)
					{
						activeGEObject.SetMetaData("fuelprop", "0");
						text6 = "0";
					}
					if (GUI.Button(position, string.Format("  [ {0} ] Propulsion", text6), inputSubStyle))
					{
						int result6 = 0;
						if (int.TryParse(text6, out result6))
						{
							Event current10 = Event.current;
							result6 = (current10.shift ? (result6 - 1) : (result6 + 1));
							if (result6 < 0)
							{
								result6 = 0;
							}
						}
						activeGEObject.SetMetaData("fuelprop", result6.ToString());
					}
					position.y += 30f;
					position.height += 10f;
				}
				else if (activeGEObject.GetType() == typeof(GECorridor))
				{
					if (activeGEObject.linkedObjects[0] == null || activeGEObject.linkedObjects[1] == null)
					{
						if (GUI.Button(position, string.Format("[ {0} ] Starting Airlock", (!((GECorridor)activeGEObject).isStartingAirlock) ? " " : "X"), "Label"))
						{
							((GECorridor)activeGEObject).isStartingAirlock = !((GECorridor)activeGEObject).isStartingAirlock;
							if (((GECorridor)activeGEObject).isStartingAirlock)
							{
								foreach (IGEObject boardObject2 in gameTable.boardObjects)
								{
									if (boardObject2.GetType() == typeof(GECorridor) && boardObject2 != activeGEObject)
									{
										((GECorridor)boardObject2).isStartingAirlock = false;
									}
								}
							}
						}
						position.y += 25f;
					}
					else
					{
						GUI.Label(position, "Door Status -", inputStyle);
						position.y += 20f;
						position.height -= 10f;
						string metaDataValue6 = activeGEObject.GetMetaDataValue("doorstate");
						if (metaDataValue6 == string.Empty)
						{
							activeGEObject.SetMetaData("doorstate", "0");
						}
						for (int num10 = 0; num10 < 3; num10++)
						{
							switch (num10)
							{
							case 0:
								if (GUI.Button(position, string.Format("  [ {0} ] System-Driven", (!(metaDataValue6 == "0")) ? " " : "X"), inputStyle))
								{
									activeGEObject.SetMetaData("doorstate", "0");
								}
								break;
							case 1:
								if (GUI.Button(position, string.Format("  [ {0} ] Closed", (!(metaDataValue6 == "1")) ? " " : "X"), inputStyle))
								{
									activeGEObject.SetMetaData("doorstate", "1");
								}
								break;
							case 2:
								if (GUI.Button(position, string.Format("  [ {0} ] Open", (!(metaDataValue6 == "2")) ? " " : "X"), inputStyle))
								{
									activeGEObject.SetMetaData("doorstate", "2");
								}
								break;
							}
							position.y += 15f;
						}
						position.y += 15f;
						position.height += 10f;
					}
					position.y += 15f;
					if (!((GECorridor)activeGEObject).isStartingAirlock)
					{
						string metaDataValue7 = activeGEObject.GetMetaDataValue("doornum");
						if (metaDataValue7 == string.Empty)
						{
							activeGEObject.SetMetaData("doornum", "0");
						}
						int num11 = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GECorridor)).Count();
						GUI.Label(position, "Choose Door Number -", inputStyle);
						position.y += 20f;
						position.height -= 10f;
						if (GUI.Button(position, string.Format("  [ {0} ] System-Driven", (!(metaDataValue7 == "0")) ? " " : "X"), inputSubStyle))
						{
							activeGEObject.SetMetaData("doornum", "0");
						}
						position.width = 60f;
						position.y += 15f;
						int num12 = 0;
						string arg2 = "  ";
						for (int num13 = 0; num13 < num11; num13++)
						{
							int num14 = num13 + 2;
							if (GUI.Button(position, string.Format("{0}[ {1} ] D{2}", arg2, (!(metaDataValue7 == num14.ToString())) ? " " : "X", num14), inputSubStyle))
							{
								activeGEObject.SetMetaData("doornum", num14.ToString());
							}
							num12++;
							if (num12 < 2)
							{
								position.x += 60f;
								arg2 = string.Empty;
								continue;
							}
							position.x = Screen.width - 150;
							position.y += 15f;
							num12 = 0;
							arg2 = "  ";
						}
						position.y += 15f;
						position.y += 15f;
						position.x = Screen.width - 150;
						position.width = 150f;
						position.height += 10f;
					}
				}
				else if (activeGEObject.GetType() == typeof(GESubSystem))
				{
					GUI.Label(position, "Slot Type -", inputStyle);
					position.y += 20f;
					position.height -= 10f;
					string metaDataValue8 = activeGEObject.GetMetaDataValue("shipupgrade");
					if (metaDataValue8 == string.Empty)
					{
						activeGEObject.SetMetaData("shipupgrade", "0");
					}
					for (int num15 = 0; num15 < 5; num15++)
					{
						switch (num15)
						{
						case 0:
							if (GUI.Button(position, string.Format("  [ {0} ] Empty", (!(metaDataValue8 == "0")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("shipupgrade", "0");
							}
							break;
						case 1:
							if (GUI.Button(position, string.Format("  [ {0} ] Broken", (!(metaDataValue8 == "1")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("shipupgrade", "1");
							}
							break;
						case 2:
							if (GUI.Button(position, string.Format("  [ {0} ] Broken Loose", (!(metaDataValue8 == "2")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("shipupgrade", "2");
							}
							break;
						case 3:
							if (GUI.Button(position, string.Format("  [ {0} ] Working", (!(metaDataValue8 == "3")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("shipupgrade", "3");
							}
							break;
						case 4:
							if (GUI.Button(position, string.Format("  [ {0} ] Working Loose", (!(metaDataValue8 == "4")) ? " " : "X"), inputSubStyle))
							{
								activeGEObject.SetMetaData("shipupgrade", "4");
							}
							break;
						}
						position.y += 15f;
					}
					position.y += 15f;
					position.height += 10f;
					if (metaDataValue8 != string.Empty && metaDataValue8 != "0")
					{
						GUI.Label(position, "Set Installed Upgrade -", inputStyle);
						position.y += 20f;
						position.height -= 10f;
						string metaDataValue9 = activeGEObject.GetMetaDataValue("shipupgradetype");
						if (metaDataValue9 == string.Empty)
						{
							activeGEObject.SetMetaData("shipupgradetype", "0");
						}
						for (int num16 = 0; num16 < 6; num16++)
						{
							switch (num16)
							{
							case 0:
								if (GUI.Button(position, string.Format("  [ {0} ] Random", (!(metaDataValue9 == "0")) ? " " : "X"), inputSubStyle))
								{
									activeGEObject.SetMetaData("shipupgradetype", "0");
								}
								break;
							case 1:
								if (GUI.Button(position, string.Format("  [ {0} ] Surveyor", (!(metaDataValue9 == "1")) ? " " : "X"), inputSubStyle))
								{
									activeGEObject.SetMetaData("shipupgradetype", "1");
								}
								break;
							case 2:
								if (GUI.Button(position, string.Format("  [ {0} ] Power Manager", (!(metaDataValue9 == "2")) ? " " : "X"), inputSubStyle))
								{
									activeGEObject.SetMetaData("shipupgradetype", "2");
								}
								break;
							case 3:
								if (GUI.Button(position, string.Format("  [ {0} ] Report Power", (!(metaDataValue9 == "3")) ? " " : "X"), inputSubStyle))
								{
									activeGEObject.SetMetaData("shipupgradetype", "3");
								}
								break;
							case 4:
								if (GUI.Button(position, string.Format("  [ {0} ] Transporter", (!(metaDataValue9 == "4")) ? " " : "X"), inputSubStyle))
								{
									activeGEObject.SetMetaData("shipupgradetype", "4");
								}
								break;
							case 5:
								if (GUI.Button(position, string.Format("  [ {0} ] Long Range Scanner", (!(metaDataValue9 == "5")) ? " " : "X"), inputSubStyle))
								{
									activeGEObject.SetMetaData("shipupgradetype", "5");
								}
								break;
							}
							position.y += 15f;
						}
						position.height += 10f;
					}
				}
				position.y += 25f;
				if ((isShowingShadow && shadow.canRotate) || (activeGEObject != null && activeGEObject.canRotate))
				{
					GUI.Label(position, "'+' to rotate (while moving)", commandHintStyle);
					position.y += 10f;
				}
				GUI.Label(position, "<DELETE> to remove", commandHintStyle);
				position.y += 10f;
				if (flag)
				{
					GUI.Label(position, "LMB on edge to expand", commandHintStyle);
					position.y += 10f;
					GUI.Label(position, "SHIFT+LMB on edge to shrink", commandHintStyle);
				}
			}
			else if (isShowingShadow && shadow.canRotate)
			{
				GUI.Label(position, "'+' to rotate", commandHintStyle);
				position.y += 25f;
			}
		}
		if (showHelpWindow)
		{
			helpWindow.DrawHelpWindow();
		}
	}

	private void ConfigureObjectsForEditor()
	{
		foreach (IGEObject boardObject in gameTable.boardObjects)
		{
			boardObject.AttachEditor(this);
			boardObject.MouseEnterRoomEvent += HandleMouseEnterRoomEvent;
			boardObject.ObjectActivateChangedEvent += HandleObjectActivateChangedEvent;
			boardObject.MouseDownOnObjectEvent += HandleMouseDownOnObjectEvent;
			boardObject.MouseUpOnObjectEvent += HandleMouseUpOnObjectEvent;
		}
	}

	private bool CanMoveActive(int xDelta, int yDelta)
	{
		if (activeGEObject == null)
		{
			return false;
		}
		if (activeGEObject.GetType() == typeof(GEPowerInlet) || activeGEObject.GetType() == typeof(GEFuelAccess) || activeGEObject.GetType() == typeof(GEDefense) || activeGEObject.GetType() == typeof(GESubSystem) || activeGEObject.GetType() == typeof(GETerminal) || activeGEObject.GetType() == typeof(GEVent))
		{
			return true;
		}
		Rect rect;
		activeGEObject.GetBoundsAsRect(out rect);
		bool flag = true;
		int num = (int)rect.x;
		int num2 = (int)rect.y;
		int num3 = (int)rect.width - 1;
		int num4 = (int)rect.height - 1;
		int num5 = (int)(rect.x + (float)xDelta);
		int num6 = (int)(rect.y + (float)yDelta);
		int num7 = (int)(rect.width + (float)xDelta);
		int num8 = (int)(rect.height + (float)yDelta);
		if (num5 >= 0 && num6 >= 0)
		{
			for (int i = num5; i < num7; i++)
			{
				for (int j = num6; j < num8; j++)
				{
					if ((i > num3 || i < num || j > num4 || j < num2) && i < gameTable.tiles.GetLength(0) && j < gameTable.tiles.GetLength(1) && gameTable.tiles[i, j].currentTileType != TileData.TileTypeEnum.Undefined)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
		}
		return flag;
	}

	private int CountObjectType(GEObjectTypeEnum objectType)
	{
		int num = 0;
		foreach (IGEObject boardObject in gameTable.boardObjects)
		{
			if (boardObject.objectType == GEObjectTypeEnum.Room)
			{
				num++;
			}
		}
		return num;
	}

	public void SetPaintBrush(int brushSize)
	{
		DeactivateCurrentObject();
		isShowingShadow = true;
		shadow = new GEShadow(GEObjectTypeEnum.Undefined, brushSize, brushSize);
		shadow.isPaintbrush = true;
		if (mouseOverTile != null)
		{
			shadow.SetLLCorner(mouseOverTile.boardPosition.x, mouseOverTile.boardPosition.y);
		}
		if (shadow.roomTiles[0, 0] != null)
		{
			prevXDrag = shadow.roomTiles[0, 0].boardPosition.x;
			prevYDrag = shadow.roomTiles[0, 0].boardPosition.y;
		}
	}

	public static bool IsWhiteTile(int x, int y)
	{
		return (x % 2 != 1 || y % 2 != 0) && (x % 2 != 0 || y % 2 != 1);
	}

	public void DungeonBoardToEditorBoard()
	{
		Color[] array = new Color[6]
		{
			Color.red,
			Color.green,
			Color.blue,
			Color.yellow,
			Color.cyan,
			Color.magenta
		};
		for (int i = 0; i < 36; i++)
		{
			for (int j = 0; j < 28; j++)
			{
				TileData tileData = gameTable.tiles[i, j];
				switch (dungeonGenerator.tiles[i, j].type)
				{
				case BoardTileType.Room:
				{
					DungeonRoom dungeonRoom2 = (DungeonRoom)dungeonGenerator.tiles[i, j].boardItem;
					if (dungeonRoom2 != null && dungeonRoom2.airlock != null && dungeonRoom2.airlock.initialDockingAirlock)
					{
						tileData.visualComponent.SetColor(Color.white);
						break;
					}
					int num = dungeonRoom2.powerGrids[0];
					if (IsWhiteTile(tileData.BoardX, tileData.BoardY))
					{
						Color color = new Color(0f, 0.75f, 0.75f);
						if (dungeonRoom2.powerGrids.Count > 0)
						{
							color = array[num];
						}
						tileData.visualComponent.SetColor(color);
					}
					else if (dungeonRoom2.powerInlet != null)
					{
						tileData.visualComponent.SetColor(Color.white);
					}
					else
					{
						tileData.visualComponent.SetColor(Color.Lerp(array[num], Color.black, 0.5f));
					}
					break;
				}
				case BoardTileType.DeadSpace:
					tileData.visualComponent.SetColor(new Color(0.15f, 0f, 0f));
					break;
				case BoardTileType.Cursor:
					tileData.visualComponent.SetColor(new Color(0f, 0.75f, 0f));
					break;
				case BoardTileType.Door:
					if (IsWhiteTile(tileData.BoardX, tileData.BoardY))
					{
						tileData.visualComponent.SetColor(DoorColorLight);
					}
					else
					{
						tileData.visualComponent.SetColor(DoorColorDark);
					}
					break;
				case BoardTileType.Airlock:
				{
					DungeonRoom dungeonRoom = (DungeonRoom)dungeonGenerator.tiles[i, j].boardItem;
					if (dungeonRoom.airlock.initialDockingAirlock)
					{
						if (IsWhiteTile(tileData.BoardX, tileData.BoardY))
						{
							tileData.visualComponent.SetColor(AirlockColor);
						}
						else
						{
							tileData.visualComponent.SetColor(AirlockColor);
						}
					}
					else if (IsWhiteTile(tileData.BoardX, tileData.BoardY))
					{
						tileData.visualComponent.SetColor(AirlockColor);
					}
					else
					{
						tileData.visualComponent.SetColor(AirlockColor);
					}
					break;
				}
				default:
					tileData.visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
					tileData.visualComponent.GetComponent<Renderer>().material.color = GlobalSettings.editorUnusedTileColor;
					break;
				}
				switch (dungeonGenerator.tiles[i, j].roomItemType)
				{
				case BoardTileRoomItemType.PowerInlet:
					tileData.visualComponent.SetColor(InletColor);
					break;
				case BoardTileRoomItemType.FuelAccess:
					tileData.visualComponent.SetColor(FuelColor);
					break;
				case BoardTileRoomItemType.Terminal:
					tileData.visualComponent.SetColor(TerminalColor);
					break;
				case BoardTileRoomItemType.Defense:
					tileData.visualComponent.SetColor(DefenseColor);
					break;
				case BoardTileRoomItemType.SubSystem:
					tileData.visualComponent.SetColor(SubSystemColor);
					break;
				}
			}
		}
	}

	public void ActAsIfMouseReleasedOnObject(IGEObject obj)
	{
		HandleMouseUpOnObjectEvent(obj);
	}

	public void ActAsIfMouseDownOnTile(TileData tile)
	{
		HandleTileScriptMouseDownOnTileEvent(tile);
	}

	private void HandleCorriorRequestedEvent(List<Vector2> tilePositionList, IGEObject obj1, IGEObject obj2, GECorridor.CorridorLayoutEnum corridorLayout, int corridorLength)
	{
		Debug.Log("HandleCorriorRequestedEvent");
		DeactivateCurrentObject();
		GECorridor gECorridor = new GECorridor();
		gECorridor.AttachEditor(this);
		gECorridor.InitCorridor(tilePositionList, obj1, obj2, corridorLayout, corridorLength);
		gameTable.boardObjects.Add(gECorridor);
		gECorridor.MouseEnterRoomEvent += HandleMouseEnterRoomEvent;
		gECorridor.ObjectActivateChangedEvent += HandleObjectActivateChangedEvent;
		gECorridor.MouseDownOnObjectEvent += HandleMouseDownOnObjectEvent;
		gECorridor.MouseUpOnObjectEvent += HandleMouseUpOnObjectEvent;
	}

	private void HandleObjectActivateChangedEvent(IGEObject geobject, bool isNowActive)
	{
		if (isNowActive)
		{
			DeactivateCurrentObject();
			activeGEObject = geobject;
		}
		else
		{
			activeGEObject = null;
		}
	}

	private void HandleMouseEnterRoomEvent(IGEObject geobject)
	{
		if (!InputState.ModifierKeyDown && !isShowingShadow && !isDraggingObject)
		{
			if (mouseOverGEObject != null && mouseOverGEObject != geobject)
			{
				mouseOverGEObject.MouseNoLongerOver();
			}
			mouseOverGEObject = null;
			if (!geobject.isActive)
			{
				geobject.HighlightEdge(HighlightTypeEnum.MouseOver);
				mouseOverGEObject = geobject;
			}
		}
	}

	private void HandleMouseDownOnObjectEvent(IGEObject geobject, int tileX, int tileY)
	{
		if (!InputState.ModifierKeyDown && !isShowingPlacement && activeGEObject != null && activeGEObject == geobject)
		{
			isDraggingObject = true;
			prevXDrag = tileX;
			prevYDrag = tileY;
		}
	}

	private void HandleMouseUpOnObjectEvent(IGEObject geobject)
	{
		isDraggingObject = false;
		prevXDrag = -1;
		prevYDrag = -1;
	}

	private void HandleTileScriptMouseDownOnTileEvent(TileData tile)
	{
		if (InputState.altDown)
		{
			return;
		}
		if (isShowingShadow && !isShowingPlacement)
		{
			if (shadow.isPaintbrush)
			{
				if (InputState.ctrlDown || Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace))
				{
					gameTable.paintedTiles.RemoveShadowTiles(shadow);
				}
				else
				{
					gameTable.paintedTiles.AddShadowTiles(shadow);
				}
			}
			else
			{
				if (!shadow.isPlaceable)
				{
					return;
				}
				IGEObject iGEObject = null;
				switch (shadow.shadowType)
				{
				case GEObjectTypeEnum.Room:
				{
					GERoom gERoom = new GERoom(shadow.width, shadow.height);
					gERoom.AttachEditor(this);
					iGEObject = gERoom;
					gameTable.boardObjects.Add(gERoom);
					break;
				}
				case GEObjectTypeEnum.PowerInlet:
				{
					GEPowerInlet gEPowerInlet = new GEPowerInlet(shadow.width, shadow.height);
					gEPowerInlet.AttachEditor(this);
					iGEObject = gEPowerInlet;
					gameTable.boardObjects.Add(gEPowerInlet);
					break;
				}
				case GEObjectTypeEnum.FuelAccess:
				{
					GEFuelAccess gEFuelAccess = new GEFuelAccess(shadow.width, shadow.height);
					gEFuelAccess.AttachEditor(this);
					iGEObject = gEFuelAccess;
					gameTable.boardObjects.Add(gEFuelAccess);
					break;
				}
				case GEObjectTypeEnum.Defense:
				{
					GEDefense gEDefense = new GEDefense(shadow.width, shadow.height);
					gEDefense.AttachEditor(this);
					iGEObject = gEDefense;
					gameTable.boardObjects.Add(gEDefense);
					break;
				}
				case GEObjectTypeEnum.SubSystem:
				{
					GESubSystem gESubSystem = new GESubSystem(shadow.width, shadow.height);
					gESubSystem.AttachEditor(this);
					iGEObject = gESubSystem;
					gameTable.boardObjects.Add(gESubSystem);
					break;
				}
				case GEObjectTypeEnum.Terminal:
				{
					GETerminal gETerminal = new GETerminal(shadow.width, shadow.height);
					gETerminal.AttachEditor(this);
					iGEObject = gETerminal;
					gameTable.boardObjects.Add(gETerminal);
					break;
				}
				case GEObjectTypeEnum.Vent:
				{
					GEVent gEVent = new GEVent(shadow.width, shadow.height);
					gEVent.AttachEditor(this);
					iGEObject = gEVent;
					gameTable.boardObjects.Add(gEVent);
					break;
				}
				}
				int index = gameTable.boardObjects.Count - 1;
				gameTable.boardObjects[index].SetLLCorner(shadow.currentLLCorner);
				gameTable.boardObjects[index].MouseEnterRoomEvent += HandleMouseEnterRoomEvent;
				gameTable.boardObjects[index].ObjectActivateChangedEvent += HandleObjectActivateChangedEvent;
				gameTable.boardObjects[index].MouseDownOnObjectEvent += HandleMouseDownOnObjectEvent;
				gameTable.boardObjects[index].MouseUpOnObjectEvent += HandleMouseUpOnObjectEvent;
				switch (shadow.shadowType)
				{
				case GEObjectTypeEnum.PowerInlet:
				case GEObjectTypeEnum.Defense:
				case GEObjectTypeEnum.Terminal:
				case GEObjectTypeEnum.Vent:
				case GEObjectTypeEnum.SubSystem:
				case GEObjectTypeEnum.FuelAccess:
				{
					IEnumerable<IGEObject> source = gameTable.boardObjects.Where((IGEObject x) => x != null && x.GetType() == typeof(GERoom));
					int num = source.Count();
					Rect rect = iGEObject.GetRect();
					Vector2 point = new Vector2(rect.x, rect.y);
					for (int num2 = 0; num2 < num; num2++)
					{
						IGEObject iGEObject2 = source.ElementAt(num2);
						if (iGEObject2.GetRect().Contains(point))
						{
							iGEObject2.LinkToObject(iGEObject);
							iGEObject.LinkToObject(iGEObject2);
							break;
						}
					}
					break;
				}
				}
				isShowingShadow = false;
				shadow.DeActivate();
				shadow = null;
			}
		}
		else if (isDraggingObject && (tile.boardPosition.x != prevXDrag || tile.boardPosition.y != prevYDrag))
		{
			int num3 = tile.boardPosition.x - prevXDrag;
			int num4 = tile.boardPosition.y - prevYDrag;
			if (CanMoveActive(num3, num4))
			{
				activeGEObject.Move(num3, num4);
				prevXDrag = tile.boardPosition.x;
				prevYDrag = tile.boardPosition.y;
			}
		}
	}

	private void HandleTileScriptMouseEnterTileEvent(TileData tile)
	{
		tile.visualComponent.SetTileHighLightColor(Color.red, 0.4f, "board editor highlight");
		mouseOverTile = tile;
		if (isShowingShadow)
		{
			int cDelta = tile.boardPosition.x - prevXDrag;
			int rDelta = tile.boardPosition.y - prevYDrag;
			shadow.Move(cDelta, rDelta);
			prevXDrag = tile.boardPosition.x;
			prevYDrag = tile.boardPosition.y;
		}
		else if (!isDraggingObject && !InputState.altDown && tile.currentTileGroupType != TileData.TileGroupEnum.Room && mouseOverGEObject != null)
		{
			mouseOverGEObject.MouseNoLongerOver();
			mouseOverGEObject = null;
		}
	}

	private void HandleTileScriptMouseExitTileEvent(TileData tile)
	{
		tile.visualComponent.ClearTileHighLightColor("board editor highlight");
	}
}
