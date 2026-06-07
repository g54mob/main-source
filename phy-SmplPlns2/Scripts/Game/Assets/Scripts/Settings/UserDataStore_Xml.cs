using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Rewired;
using Rewired.Data;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class UserDataStore_Xml : UserDataStore
	{
		private class ControllerAssignmentSaveInfo
		{
			public class JoystickInfo
			{
				public string hardwareIdentifier;

				public int id;

				public Guid instanceGuid;
			}

			public class PlayerInfo
			{
				public bool hasKeyboard;

				public bool hasMouse;

				public int id;

				public JoystickInfo[] joysticks;

				public int joystickCount
				{
					get
					{
						if (joysticks == null)
						{
							return 0;
						}
						return joysticks.Length;
					}
				}

				public bool ContainsJoystick(int joystickId)
				{
					return IndexOfJoystick(joystickId) >= 0;
				}

				public int IndexOfJoystick(int joystickId)
				{
					for (int i = 0; i < joystickCount; i++)
					{
						if (joysticks[i] != null && joysticks[i].id == joystickId)
						{
							return i;
						}
					}
					return -1;
				}
			}

			public PlayerInfo[] players;

			public int playerCount
			{
				get
				{
					if (players == null)
					{
						return 0;
					}
					return players.Length;
				}
			}

			public ControllerAssignmentSaveInfo()
			{
			}

			public ControllerAssignmentSaveInfo(int playerCount)
			{
				players = new PlayerInfo[playerCount];
				for (int i = 0; i < playerCount; i++)
				{
					players[i] = new PlayerInfo();
				}
			}

			public bool ContainsPlayer(int playerId)
			{
				return IndexOfPlayer(playerId) >= 0;
			}

			public int IndexOfPlayer(int playerId)
			{
				for (int i = 0; i < playerCount; i++)
				{
					if (players[i] != null && players[i].id == playerId)
					{
						return i;
					}
				}
				return -1;
			}
		}

		private class JoystickAssignmentHistoryInfo
		{
			public readonly Joystick joystick;

			public readonly int oldJoystickId;

			public JoystickAssignmentHistoryInfo(Joystick joystick, int oldJoystickId)
			{
				if (joystick == null)
				{
					throw new ArgumentNullException("joystick");
				}
				this.joystick = joystick;
				this.oldJoystickId = oldJoystickId;
			}
		}

		private class SavedControllerMapData
		{
			public List<int> knownActionIds;

			public string xml;

			public SavedControllerMapData(string xml, List<int> knownActionIds)
			{
				this.xml = xml;
				this.knownActionIds = knownActionIds;
			}

			public static List<string> GetXmlStringList(List<SavedControllerMapData> data)
			{
				List<string> list = new List<string>();
				if (data == null)
				{
					return list;
				}
				for (int i = 0; i < data.Count; i++)
				{
					if (data[i] != null && !string.IsNullOrEmpty(data[i].xml))
					{
						list.Add(data[i].xml);
					}
				}
				return list;
			}
		}

		private const string CalibrationMapsElementName = "CalibrationMaps";

		private const string CategoryElementName = "{http://guavaman.com/rewired}categoryId";

		private const string ControllerMapsElementName = "ControllerMaps";

		private const string editorLoadedMessage = "\nIf unexpected input issues occur, the loaded XML data may be outdated or invalid. Delete the ControlInputData.xml file in your game's app data folder.";

		private const string HardwareGuidName = "{http://guavaman.com/rewired}hardwareGuid";

		private const string InputBehaviorsElementName = "InputBehaviors";

		private const string KnownActionIdsElementName = "{http://guavaman.com/rewired}KnownActionIds";

		private const string RewiredNamespace = "{http://guavaman.com/rewired}";

		private const string thisScriptName = "UserDataStore_XML";

		private XDocument _cachedXmlDocument;

		private bool _loggingEnabled;

		private bool _saveIndividualChanges = true;

		private bool allowImpreciseJoystickAssignmentMatching = true;

		private bool deferredJoystickAssignmentLoadPending;

		[Tooltip("Should this script be used? If disabled, nothing will be saved or loaded.")]
		[SerializeField]
		private bool isEnabled = true;

		[Tooltip("Should saved data be loaded on start?")]
		[SerializeField]
		private bool loadDataOnStart = true;

		[Tooltip("Should Player Joystick assignments be saved and loaded? This is not totally reliable for all Joysticks on all platforms. Some platforms/input sources do not provide enough information to reliably save assignments from session to session and reboot to reboot.")]
		[SerializeField]
		private bool loadJoystickAssignments = true;

		[Tooltip("Should Player Keyboard assignments be saved and loaded?")]
		[SerializeField]
		private bool loadKeyboardAssignments = true;

		[Tooltip("Should Player Mouse assignments be saved and loaded?")]
		[SerializeField]
		private bool loadMouseAssignments = true;

		[Tooltip("The path to save XML data, local to Application.persistentDataPath")]
		[SerializeField]
		private string SaveFilePath = "ControlInputData.xml";

		private bool wasJoystickEverDetected;

		public bool IsEnabled
		{
			get
			{
				return isEnabled;
			}
			set
			{
				isEnabled = value;
			}
		}

		public bool LoadDataOnStart
		{
			get
			{
				return loadDataOnStart;
			}
			set
			{
				loadDataOnStart = value;
			}
		}

		public bool LoadJoystickAssignments
		{
			get
			{
				return loadJoystickAssignments;
			}
			set
			{
				loadJoystickAssignments = value;
			}
		}

		public bool LoadKeyboardAssignments
		{
			get
			{
				return loadKeyboardAssignments;
			}
			set
			{
				loadKeyboardAssignments = value;
			}
		}

		public bool LoadMouseAssignments
		{
			get
			{
				return loadMouseAssignments;
			}
			set
			{
				loadMouseAssignments = value;
			}
		}

		private string DataPath => Path.Combine(Application.persistentDataPath, SaveFilePath);

		private bool loadControllerAssignments
		{
			get
			{
				if (!loadKeyboardAssignments && !loadMouseAssignments)
				{
					return loadJoystickAssignments;
				}
				return true;
			}
		}

		public override void Load()
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not load any data.", this);
			}
			else
			{
				LoadAll();
			}
		}

		public override void LoadControllerData(int playerId, ControllerType controllerType, int controllerId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not load any data.", this);
			}
			else if (LoadControllerDataNow(playerId, controllerType, controllerId) > 0)
			{
				Log("Rewired: UserDataStore_XML loaded user data for " + controllerType.ToString() + " " + controllerId + " for Player " + playerId + " from XML. \nIf unexpected input issues occur, the loaded XML data may be outdated or invalid. Delete the ControlInputData.xml file in your game's app data folder.");
			}
		}

		public override void LoadControllerData(ControllerType controllerType, int controllerId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not load any data.", this);
			}
			else if (LoadControllerDataNow(controllerType, controllerId) > 0)
			{
				Log("Rewired: UserDataStore_XML loaded user data for " + controllerType.ToString() + " " + controllerId + " from XML. \nIf unexpected input issues occur, the loaded XML data may be outdated or invalid. Delete the ControlInputData.xml file in your game's app data folder.");
			}
		}

		public override void LoadInputBehavior(int playerId, int behaviorId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not load any data.", this);
			}
			else if (LoadInputBehaviorNow(playerId, behaviorId) > 0)
			{
				Log("Rewired: UserDataStore_XML loaded Player + " + playerId + " InputBehavior data from XML. \nIf unexpected input issues occur, the loaded XML data may be outdated or invalid. Delete the ControlInputData.xml file in your game's app data folder.");
			}
		}

		public override void LoadPlayerData(int playerId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not load any data.", this);
				return;
			}
			bool flag = _cachedXmlDocument != null;
			if (!flag)
			{
				_cachedXmlDocument = GetXmlDocument();
			}
			int num = LoadPlayerDataNow(playerId);
			if (!flag)
			{
				_cachedXmlDocument = null;
			}
			if (num > 0)
			{
				Log("Rewired: UserDataStore_XML loaded Player + " + playerId + " user data from XML. \nIf unexpected input issues occur, the loaded XML data may be outdated or invalid. Delete the ControlInputData.xml file in your game's app data folder.");
			}
		}

		public override void Save()
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not save any data.", this);
				return;
			}
			SaveAll();
			Log("Rewired: saved all user data to XML: " + DataPath);
		}

		public override void SaveControllerData(int playerId, ControllerType controllerType, int controllerId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not save any data.", this);
				return;
			}
			SaveControllerDataNow(playerId, controllerType, controllerId);
			Log("Rewired: UserDataStore_XML saved " + controllerType.ToString() + " " + controllerId + " data for Player " + playerId + " to XML.");
		}

		public override void SaveControllerData(ControllerType controllerType, int controllerId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not save any data.", this);
				return;
			}
			SaveControllerDataNow(controllerType, controllerId);
			Log("Rewired: UserDataStore_XML saved " + controllerType.ToString() + " " + controllerId + " data to XML.");
		}

		public override void SaveInputBehavior(int playerId, int behaviorId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not save any data.", this);
				return;
			}
			SaveInputBehaviorNow(playerId, behaviorId);
			Log("Rewired: UserDataStore_XML saved Input Behavior data for Player " + playerId + " to XML.");
		}

		public override void SavePlayerData(int playerId)
		{
			if (!isEnabled)
			{
				Debug.LogWarning("Rewired: UserDataStore_XML is disabled and will not save any data.", this);
				return;
			}
			SavePlayerDataNow(playerId);
			Log("Rewired: UserDataStore_XML saved all user data for Player " + playerId + " to XML.");
		}

		protected override void OnControllerConnected(ControllerStatusChangedEventArgs args)
		{
			if (isEnabled && args.controllerType == ControllerType.Joystick)
			{
				if (LoadJoystickData(args.controllerId) > 0)
				{
					Log("Rewired: UserDataStore_XML loaded Joystick " + args.controllerId + " (" + ReInput.controllers.GetJoystick(args.controllerId).hardwareName + ") data from XML. \nIf unexpected input issues occur, the loaded XML data may be outdated or invalid. Delete the ControlInputData.xml file in your game's app data folder.");
				}
				if (loadDataOnStart && loadJoystickAssignments && !wasJoystickEverDetected)
				{
					StartCoroutine(LoadJoystickAssignmentsDeferred());
				}
				if (loadJoystickAssignments && !deferredJoystickAssignmentLoadPending)
				{
					SaveControllerAssignments();
				}
				wasJoystickEverDetected = true;
			}
		}

		protected override void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
		{
			if (isEnabled && loadControllerAssignments)
			{
				SaveControllerAssignments();
			}
		}

		protected override void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
		{
			if (isEnabled && args.controllerType == ControllerType.Joystick)
			{
				SaveJoystickData(args.controllerId);
				Log("Rewired: UserDataStore_XML saved Joystick " + args.controllerId + " (" + ReInput.controllers.GetJoystick(args.controllerId).hardwareName + ") data to XML.");
			}
		}

		protected override void OnInitialize()
		{
			_loggingEnabled = !Application.isEditor;
			if (loadDataOnStart)
			{
				Load();
				if (loadControllerAssignments && ReInput.controllers.joystickCount > 0)
				{
					SaveControllerAssignments();
				}
			}
		}

		private void AddDefaultMappingsForNewActions(Player player, List<SavedControllerMapData> savedData, ControllerType controllerType, int controllerId)
		{
			if (player == null || savedData == null)
			{
				return;
			}
			List<int> allActionIds = GetAllActionIds();
			for (int i = 0; i < savedData.Count; i++)
			{
				SavedControllerMapData savedControllerMapData = savedData[i];
				if (savedControllerMapData == null || savedControllerMapData.knownActionIds == null || savedControllerMapData.knownActionIds.Count == 0)
				{
					continue;
				}
				ControllerMap controllerMap = ControllerMap.CreateFromXml(controllerType, savedData[i].xml);
				if (controllerMap == null)
				{
					continue;
				}
				ControllerMap map = player.controllers.maps.GetMap(controllerType, controllerId, controllerMap.categoryId, controllerMap.layoutId);
				if (map == null)
				{
					continue;
				}
				ControllerMap controllerMapInstance = ReInput.mapping.GetControllerMapInstance(ReInput.controllers.GetController(controllerType, controllerId), controllerMap.categoryId, controllerMap.layoutId);
				if (controllerMapInstance == null)
				{
					continue;
				}
				List<int> list = new List<int>();
				foreach (int item in allActionIds)
				{
					if (!savedControllerMapData.knownActionIds.Contains(item))
					{
						list.Add(item);
					}
				}
				if (list.Count == 0)
				{
					continue;
				}
				foreach (ActionElementMap allMap in controllerMapInstance.AllMaps)
				{
					if (list.Contains(allMap.actionId) && !map.DoesElementAssignmentConflict(allMap))
					{
						ElementAssignment elementAssignment = new ElementAssignment(controllerType, allMap.elementType, allMap.elementIdentifierId, allMap.axisRange, allMap.keyCode, allMap.modifierKeyFlags, allMap.actionId, allMap.axisContribution, allMap.invert);
						map.CreateElementMap(elementAssignment);
					}
				}
			}
		}

		private bool ControllerAssignmentSaveDataExists()
		{
			XElement xElement = GetXmlDocument().Root.Element("ControllerAssignments");
			if (xElement == null || string.IsNullOrEmpty(xElement.Value))
			{
				return false;
			}
			return true;
		}

		private Joystick FindJoystickPrecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo)
		{
			if (joystickInfo == null)
			{
				return null;
			}
			if (joystickInfo.instanceGuid == Guid.Empty)
			{
				return null;
			}
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (joysticks[i].deviceInstanceGuid == joystickInfo.instanceGuid)
				{
					return joysticks[i];
				}
			}
			return null;
		}

		private List<int> GetAllActionIds()
		{
			List<int> list = new List<int>();
			IList<InputAction> actions = ReInput.mapping.Actions;
			for (int i = 0; i < actions.Count; i++)
			{
				list.Add(actions[i].id);
			}
			return list;
		}

		private string GetAllActionIdsString()
		{
			string text = string.Empty;
			List<int> allActionIds = GetAllActionIds();
			for (int i = 0; i < allActionIds.Count; i++)
			{
				if (i > 0)
				{
					text += ",";
				}
				text += allActionIds[i];
			}
			return text;
		}

		private List<SavedControllerMapData> GetAllControllerMapsXml(Player player, bool userAssignableMapsOnly, Controller controller)
		{
			List<SavedControllerMapData> list = new List<SavedControllerMapData>();
			IList<InputMapCategory> mapCategories = ReInput.mapping.MapCategories;
			for (int i = 0; i < mapCategories.Count; i++)
			{
				InputMapCategory inputMapCategory = mapCategories[i];
				if (userAssignableMapsOnly && !inputMapCategory.userAssignable)
				{
					continue;
				}
				IList<InputLayout> list2 = ReInput.mapping.MapLayouts(controller.type);
				for (int j = 0; j < list2.Count; j++)
				{
					InputLayout inputLayout = list2[j];
					XElement controllerMapXml = GetControllerMapXml(player, controller, inputMapCategory.id, inputLayout.id);
					if (controllerMapXml != null)
					{
						controllerMapXml = XElement.Parse(controllerMapXml.ToString());
						XElement xElement = controllerMapXml.Element("{http://guavaman.com/rewired}KnownActionIds");
						List<int> controllerMapKnownActionIds = GetControllerMapKnownActionIds(xElement);
						xElement?.Remove();
						list.Add(new SavedControllerMapData(controllerMapXml.ToString(SaveOptions.DisableFormatting), controllerMapKnownActionIds));
					}
				}
			}
			return list;
		}

		private List<int> GetControllerMapKnownActionIds(XElement knownActionIdsXml)
		{
			List<int> list = new List<int>();
			string text = knownActionIdsXml?.Value;
			if (string.IsNullOrEmpty(text))
			{
				return list;
			}
			string[] array = text.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				if (!string.IsNullOrEmpty(array[i]) && int.TryParse(array[i], out var result))
				{
					list.Add(result);
				}
			}
			return list;
		}

		private XElement GetControllerMapXml(Player player, Controller controller, int categoryId, int layoutId)
		{
			XElement xElement = GetXmlDocument().Root.Element("ControllerMaps");
			if (xElement == null || !xElement.HasElements)
			{
				return null;
			}
			Guid hardwareTypeGuid = controller.hardwareTypeGuid;
			string text = controller.GetType().Name + "Map";
			foreach (XElement item in xElement.Elements())
			{
				if (!(item.Name.LocalName != text) && !(item.Element("{http://guavaman.com/rewired}hardwareGuid").Value != hardwareTypeGuid.ToString()))
				{
					XAttribute xAttribute = item.Attribute("hardwareIdentifier");
					XElement xElement2 = item.Element("{http://guavaman.com/rewired}categoryId");
					if (xAttribute != null && xAttribute.Value == controller.hardwareIdentifier && xElement2 != null && xElement2.Value == categoryId.ToString())
					{
						return item;
					}
				}
			}
			return null;
		}

		private string GetInputBehaviorXml(Player player, int id)
		{
			XElement xElement = GetXmlDocument().Root.Element("InputBehaviors");
			if (xElement == null || !xElement.HasElements)
			{
				return string.Empty;
			}
			XName xName = XName.Get("{http://guavaman.com/rewired}id");
			foreach (XElement item in xElement.Elements())
			{
				XElement xElement2 = item.Element(xName);
				if (xElement2 == null)
				{
					Debug.LogWarning("Something broke loading an input behavior.");
				}
				else if (xElement2.Value == id.ToString())
				{
					return item.ToString(SaveOptions.DisableFormatting);
				}
			}
			return string.Empty;
		}

		private string GetJoystickCalibrationMapXml(Joystick joystick)
		{
			XElement xElement = GetXmlDocument().Root.Element("CalibrationMaps");
			if (xElement == null || !xElement.HasElements)
			{
				return string.Empty;
			}
			foreach (XElement item in xElement.Elements())
			{
				XElement xElement2 = XElement.Parse(item.ToString());
				XAttribute xAttribute = xElement2.Attribute("hardwareIdentifier");
				XAttribute xAttribute2 = xElement2.Attribute("hardwareGuid");
				if (xAttribute == null || xAttribute2 == null)
				{
					Debug.LogWarning("Something broke with loading a calibration map.");
				}
				else if (xAttribute.Value == joystick.hardwareIdentifier && xAttribute2.Value == joystick.hardwareTypeGuid.ToString())
				{
					xAttribute.Remove();
					xAttribute2.Remove();
					return xElement2.ToString(SaveOptions.DisableFormatting);
				}
			}
			return string.Empty;
		}

		private XDocument GetXmlDocument()
		{
			if (_cachedXmlDocument != null)
			{
				return _cachedXmlDocument;
			}
			XDocument result = new XDocument(new XElement("Data"));
			if (File.Exists(DataPath))
			{
				result = XDocument.Load(DataPath);
			}
			return result;
		}

		private int LoadAll()
		{
			int num = 0;
			bool flag = _cachedXmlDocument != null;
			_cachedXmlDocument = GetXmlDocument();
			if (loadControllerAssignments && LoadControllerAssignmentsNow())
			{
				num++;
			}
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				num += LoadPlayerDataNow(allPlayers[i]);
			}
			num += LoadAllJoystickCalibrationData();
			_cachedXmlDocument = null;
			Log($"Rewired: loaded user data from XML. Count: {num}, Was cached: {flag}, Path: {DataPath}");
			return num;
		}

		private int LoadAllJoystickCalibrationData()
		{
			int num = 0;
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				num += LoadJoystickCalibrationData(joysticks[i]);
			}
			return num;
		}

		private ControllerAssignmentSaveInfo LoadControllerAssignmentData()
		{
			try
			{
				XElement xElement = GetXmlDocument().Root.Element("ControllerAssignments");
				if (xElement == null)
				{
					return null;
				}
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = JsonParser.FromJson<ControllerAssignmentSaveInfo>(xElement.Value);
				if (controllerAssignmentSaveInfo == null || controllerAssignmentSaveInfo.playerCount == 0)
				{
					return null;
				}
				return controllerAssignmentSaveInfo;
			}
			catch
			{
				return null;
			}
		}

		private bool LoadControllerAssignmentsNow()
		{
			try
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = LoadControllerAssignmentData();
				if (controllerAssignmentSaveInfo == null)
				{
					return false;
				}
				if (loadKeyboardAssignments || loadMouseAssignments)
				{
					LoadKeyboardAndMouseAssignmentsNow(controllerAssignmentSaveInfo);
				}
				if (loadJoystickAssignments)
				{
					LoadJoystickAssignmentsNow(controllerAssignmentSaveInfo);
				}
				Log("Rewired: UserDataStore_XML loaded controller assignments from XML.");
			}
			catch (Exception e)
			{
				LogException("Rewired: UserDataStore_XML encountered an error loading controller assignments from XML.", e);
			}
			return true;
		}

		private int LoadControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
		{
			return 0 + LoadControllerMaps(playerId, controllerType, controllerId) + LoadControllerDataNow(controllerType, controllerId);
		}

		private int LoadControllerDataNow(ControllerType controllerType, int controllerId)
		{
			int num = 0;
			if (controllerType == ControllerType.Joystick)
			{
				num += LoadJoystickCalibrationData(controllerId);
			}
			return num;
		}

		private int LoadControllerMaps(int playerId, ControllerType controllerType, int controllerId)
		{
			int num = 0;
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return num;
			}
			Controller controller = ReInput.controllers.GetController(controllerType, controllerId);
			if (controller == null)
			{
				return num;
			}
			List<SavedControllerMapData> allControllerMapsXml = GetAllControllerMapsXml(player, userAssignableMapsOnly: true, controller);
			if (allControllerMapsXml.Count == 0)
			{
				return num;
			}
			num += player.controllers.maps.AddMapsFromXml(controllerType, controllerId, SavedControllerMapData.GetXmlStringList(allControllerMapsXml));
			AddDefaultMappingsForNewActions(player, allControllerMapsXml, controllerType, controllerId);
			return num;
		}

		private int LoadInputBehaviorNow(int playerId, int behaviorId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			InputBehavior inputBehavior = ReInput.mapping.GetInputBehavior(playerId, behaviorId);
			if (inputBehavior == null)
			{
				return 0;
			}
			return LoadInputBehaviorNow(player, inputBehavior);
		}

		private int LoadInputBehaviorNow(Player player, InputBehavior inputBehavior)
		{
			if (player == null || inputBehavior == null)
			{
				return 0;
			}
			string inputBehaviorXml = GetInputBehaviorXml(player, inputBehavior.id);
			if (inputBehaviorXml == null || inputBehaviorXml == string.Empty)
			{
				return 0;
			}
			if (!inputBehavior.ImportXmlString(inputBehaviorXml))
			{
				return 0;
			}
			return 1;
		}

		private int LoadInputBehaviors(int playerId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null)
			{
				return 0;
			}
			int num = 0;
			IList<InputBehavior> inputBehaviors = ReInput.mapping.GetInputBehaviors(player.id);
			for (int i = 0; i < inputBehaviors.Count; i++)
			{
				num += LoadInputBehaviorNow(player, inputBehaviors[i]);
			}
			return num;
		}

		private IEnumerator LoadJoystickAssignmentsDeferred()
		{
			deferredJoystickAssignmentLoadPending = true;
			yield return new WaitForEndOfFrame();
			if (ReInput.isReady)
			{
				if (LoadJoystickAssignmentsNow(null))
				{
					Log("Rewired: UserDataStore_XML loaded joystick assignments from XML.");
				}
				SaveControllerAssignments();
				deferredJoystickAssignmentLoadPending = false;
			}
		}

		private bool LoadJoystickAssignmentsNow(ControllerAssignmentSaveInfo data)
		{
			try
			{
				if (ReInput.controllers.joystickCount == 0)
				{
					return false;
				}
				if (data == null && (data = LoadControllerAssignmentData()) == null)
				{
					return false;
				}
				foreach (Player allPlayer in ReInput.players.AllPlayers)
				{
					allPlayer.controllers.ClearControllersOfType(ControllerType.Joystick);
				}
				List<JoystickAssignmentHistoryInfo> list = (loadJoystickAssignments ? new List<JoystickAssignmentHistoryInfo>() : null);
				foreach (Player allPlayer2 in ReInput.players.AllPlayers)
				{
					if (!data.ContainsPlayer(allPlayer2.id))
					{
						continue;
					}
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo = data.players[data.IndexOfPlayer(allPlayer2.id)];
					for (int i = 0; i < playerInfo.joystickCount; i++)
					{
						ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = playerInfo.joysticks[i];
						if (joystickInfo == null)
						{
							continue;
						}
						Joystick joystick = FindJoystickPrecise(joystickInfo);
						if (joystick != null)
						{
							if (list.Find((JoystickAssignmentHistoryInfo x) => x.joystick == joystick) == null)
							{
								list.Add(new JoystickAssignmentHistoryInfo(joystick, joystickInfo.id));
							}
							allPlayer2.controllers.AddController(joystick, removeFromOtherPlayers: false);
						}
					}
				}
				if (allowImpreciseJoystickAssignmentMatching)
				{
					foreach (Player allPlayer3 in ReInput.players.AllPlayers)
					{
						if (!data.ContainsPlayer(allPlayer3.id))
						{
							continue;
						}
						ControllerAssignmentSaveInfo.PlayerInfo playerInfo2 = data.players[data.IndexOfPlayer(allPlayer3.id)];
						for (int num = 0; num < playerInfo2.joystickCount; num++)
						{
							ControllerAssignmentSaveInfo.JoystickInfo joystickInfo2 = playerInfo2.joysticks[num];
							if (joystickInfo2 == null)
							{
								continue;
							}
							Joystick joystick2 = null;
							int num2 = list.FindIndex((JoystickAssignmentHistoryInfo x) => x.oldJoystickId == joystickInfo2.id);
							if (num2 >= 0)
							{
								joystick2 = list[num2].joystick;
							}
							else
							{
								if (!TryFindJoysticksImprecise(joystickInfo2, out var matches))
								{
									continue;
								}
								foreach (Joystick match in matches)
								{
									if (list.Find((JoystickAssignmentHistoryInfo x) => x.joystick == match) == null)
									{
										joystick2 = match;
										break;
									}
								}
								if (joystick2 == null)
								{
									continue;
								}
								list.Add(new JoystickAssignmentHistoryInfo(joystick2, joystickInfo2.id));
							}
							allPlayer3.controllers.AddController(joystick2, removeFromOtherPlayers: false);
						}
					}
				}
			}
			catch (Exception e)
			{
				LogException("Rewired: UserDataStore_XML encountered an error loading joystick assignments from XML.", e);
			}
			if (ReInput.configuration.autoAssignJoysticks)
			{
				ReInput.controllers.AutoAssignJoysticks();
			}
			return true;
		}

		private int LoadJoystickCalibrationData(Joystick joystick)
		{
			if (joystick == null)
			{
				return 0;
			}
			if (!joystick.ImportCalibrationMapFromXmlString(GetJoystickCalibrationMapXml(joystick)))
			{
				return 0;
			}
			return 1;
		}

		private int LoadJoystickCalibrationData(int joystickId)
		{
			return LoadJoystickCalibrationData(ReInput.controllers.GetJoystick(joystickId));
		}

		private int LoadJoystickData(int joystickId)
		{
			int num = 0;
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				Player player = allPlayers[i];
				if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
				{
					num += LoadControllerMaps(player.id, ControllerType.Joystick, joystickId);
				}
			}
			return num + LoadJoystickCalibrationData(joystickId);
		}

		private bool LoadKeyboardAndMouseAssignmentsNow(ControllerAssignmentSaveInfo data)
		{
			try
			{
				if (data == null && (data = LoadControllerAssignmentData()) == null)
				{
					return false;
				}
				foreach (Player allPlayer in ReInput.players.AllPlayers)
				{
					if (data.ContainsPlayer(allPlayer.id))
					{
						ControllerAssignmentSaveInfo.PlayerInfo playerInfo = data.players[data.IndexOfPlayer(allPlayer.id)];
						if (loadKeyboardAssignments)
						{
							allPlayer.controllers.hasKeyboard = playerInfo.hasKeyboard;
						}
						if (loadMouseAssignments)
						{
							allPlayer.controllers.hasMouse = playerInfo.hasMouse;
						}
					}
				}
			}
			catch (Exception e)
			{
				LogException("Rewired: UserDataStore_XML encountered an error loading keyboard and/or mouse assignments from XML.", e);
			}
			return true;
		}

		private int LoadPlayerDataNow(int playerId)
		{
			return LoadPlayerDataNow(ReInput.players.GetPlayer(playerId));
		}

		private int LoadPlayerDataNow(Player player)
		{
			if (player == null)
			{
				return 0;
			}
			int num = 0;
			num += LoadInputBehaviors(player.id);
			num += LoadControllerMaps(player.id, ControllerType.Keyboard, 0);
			num += LoadControllerMaps(player.id, ControllerType.Mouse, 0);
			foreach (Joystick joystick in player.controllers.Joysticks)
			{
				num += LoadControllerMaps(player.id, ControllerType.Joystick, joystick.id);
			}
			return num;
		}

		private void Log(string message)
		{
			if (_loggingEnabled)
			{
				Debug.Log(message);
			}
		}

		private void LogException(string message, Exception e)
		{
			if (_loggingEnabled)
			{
				Debug.LogError(message);
				Debug.LogException(e);
			}
		}

		private void RequestSaveIndividualChangeToXmlDocument()
		{
			if (_saveIndividualChanges)
			{
				GetXmlDocument().Save(DataPath);
			}
		}

		private void SaveAll()
		{
			_cachedXmlDocument = GetXmlDocument();
			_saveIndividualChanges = false;
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				SavePlayerDataNow(allPlayers[i]);
			}
			SaveAllJoystickCalibrationData();
			if (loadControllerAssignments)
			{
				SaveControllerAssignments();
			}
			_cachedXmlDocument.Save(DataPath);
			_saveIndividualChanges = true;
			_cachedXmlDocument = null;
		}

		private void SaveAllJoystickCalibrationData()
		{
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				SaveJoystickCalibrationData(joysticks[i]);
			}
		}

		private bool SaveControllerAssignments()
		{
			try
			{
				ControllerAssignmentSaveInfo controllerAssignmentSaveInfo = new ControllerAssignmentSaveInfo(ReInput.players.allPlayerCount);
				for (int i = 0; i < ReInput.players.allPlayerCount; i++)
				{
					Player player = ReInput.players.AllPlayers[i];
					ControllerAssignmentSaveInfo.PlayerInfo playerInfo = new ControllerAssignmentSaveInfo.PlayerInfo();
					controllerAssignmentSaveInfo.players[i] = playerInfo;
					playerInfo.id = player.id;
					playerInfo.hasKeyboard = player.controllers.hasKeyboard;
					playerInfo.hasMouse = player.controllers.hasMouse;
					ControllerAssignmentSaveInfo.JoystickInfo[] array = (playerInfo.joysticks = new ControllerAssignmentSaveInfo.JoystickInfo[player.controllers.joystickCount]);
					for (int j = 0; j < player.controllers.joystickCount; j++)
					{
						Joystick joystick = player.controllers.Joysticks[j];
						ControllerAssignmentSaveInfo.JoystickInfo joystickInfo = new ControllerAssignmentSaveInfo.JoystickInfo();
						joystickInfo.instanceGuid = joystick.deviceInstanceGuid;
						joystickInfo.id = joystick.id;
						joystickInfo.hardwareIdentifier = joystick.hardwareIdentifier;
						array[j] = joystickInfo;
					}
				}
				XDocument xmlDocument = GetXmlDocument();
				XElement xElement = xmlDocument.Root.Element("ControllerAssignments");
				if (xElement == null)
				{
					xElement = new XElement("ControllerAssignments");
					xmlDocument.Root.Add(xElement);
				}
				xElement.RemoveAll();
				xElement.Add(JsonWriter.ToJson(controllerAssignmentSaveInfo));
				RequestSaveIndividualChangeToXmlDocument();
				Log("Rewired: UserDataStore_XML saved controller assignments to XML.");
			}
			catch (Exception e)
			{
				LogException("Rewired: UserDataStore_XML encountered an error saving controller assignments to XML.", e);
			}
			return true;
		}

		private void SaveControllerDataNow(int playerId, ControllerType controllerType, int controllerId)
		{
			SaveControllerMaps(playerId, controllerType, controllerId);
			SaveControllerDataNow(controllerType, controllerId);
		}

		private void SaveControllerDataNow(ControllerType controllerType, int controllerId)
		{
			if (controllerType == ControllerType.Joystick)
			{
				SaveJoystickCalibrationData(controllerId);
			}
		}

		private void SaveControllerMap(Player player, ControllerMapSaveData saveData)
		{
			XDocument xmlDocument = GetXmlDocument();
			XElement xElement = xmlDocument.Root.Element("ControllerMaps");
			if (xElement == null)
			{
				xElement = new XElement("ControllerMaps");
				xmlDocument.Root.Add(xElement);
			}
			XElement xElement2 = XElement.Parse(saveData.map.ToXmlString());
			xElement2.SetAttributeValue("hardwareIdentifier", saveData.controllerHardwareIdentifier);
			xElement2.Add(new XElement("{http://guavaman.com/rewired}KnownActionIds", GetAllActionIdsString()));
			bool flag = false;
			XName xName = XName.Get("{http://guavaman.com/rewired}hardwareGuid");
			XName xName2 = XName.Get("{http://guavaman.com/rewired}categoryId");
			foreach (XElement item in xElement.Elements())
			{
				if (!(item.Name != xElement2.Name) && !(item.Attribute("hardwareIdentifier").Value != saveData.controllerHardwareIdentifier) && !(item.Element(xName).Value != xElement2.Element(xName).Value))
				{
					XElement xElement3 = item.Element(xName2);
					if (xElement3 == null)
					{
						Debug.LogWarning("Something broke with a controller map.");
					}
					else if (xElement3.Value == xElement2.Element(xName2).Value)
					{
						item.ReplaceWith(xElement2);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				xElement.Add(xElement2);
			}
			RequestSaveIndividualChangeToXmlDocument();
		}

		private void SaveControllerMaps(Player player, PlayerSaveData playerSaveData)
		{
			foreach (ControllerMapSaveData allControllerMapSaveDatum in playerSaveData.AllControllerMapSaveData)
			{
				SaveControllerMap(player, allControllerMapSaveDatum);
			}
		}

		private void SaveControllerMaps(int playerId, ControllerType controllerType, int controllerId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player == null || !player.controllers.ContainsController(controllerType, controllerId))
			{
				return;
			}
			ControllerMapSaveData[] mapSaveData = player.controllers.maps.GetMapSaveData(controllerType, controllerId, userAssignableMapsOnly: true);
			if (mapSaveData != null)
			{
				for (int i = 0; i < mapSaveData.Length; i++)
				{
					SaveControllerMap(player, mapSaveData[i]);
				}
			}
		}

		private void SaveInputBehaviorNow(int playerId, int behaviorId)
		{
			Player player = ReInput.players.GetPlayer(playerId);
			if (player != null)
			{
				InputBehavior inputBehavior = ReInput.mapping.GetInputBehavior(playerId, behaviorId);
				if (inputBehavior != null)
				{
					SaveInputBehaviorNow(player, inputBehavior);
				}
			}
		}

		private void SaveInputBehaviorNow(Player player, InputBehavior inputBehavior)
		{
			if (player == null || inputBehavior == null)
			{
				return;
			}
			XDocument xmlDocument = GetXmlDocument();
			XElement xElement = xmlDocument.Root.Element("InputBehaviors");
			if (xElement == null)
			{
				xElement = new XElement("InputBehaviors");
				xmlDocument.Root.Add(xElement);
			}
			XElement xElement2 = XElement.Parse(inputBehavior.ToXmlString());
			bool flag = false;
			XName xName = XName.Get("{http://guavaman.com/rewired}id");
			foreach (XElement item in xElement.Elements())
			{
				XElement xElement3 = item.Element(xName);
				if (xElement3 == null)
				{
					Debug.LogWarning("Something broke with an input behavior.");
				}
				else if (xElement3.Value == xElement2.Element(xName).Value)
				{
					item.ReplaceWith(xElement2);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				xElement.Add(xElement2);
			}
			RequestSaveIndividualChangeToXmlDocument();
		}

		private void SaveInputBehaviors(Player player, PlayerSaveData playerSaveData)
		{
			if (player != null)
			{
				InputBehavior[] inputBehaviors = playerSaveData.inputBehaviors;
				for (int i = 0; i < inputBehaviors.Length; i++)
				{
					SaveInputBehaviorNow(player, inputBehaviors[i]);
				}
			}
		}

		private void SaveJoystickCalibrationData(int joystickId)
		{
			SaveJoystickCalibrationData(ReInput.controllers.GetJoystick(joystickId));
		}

		private void SaveJoystickCalibrationData(Joystick joystick)
		{
			if (joystick == null)
			{
				return;
			}
			JoystickCalibrationMapSaveData calibrationMapSaveData = joystick.GetCalibrationMapSaveData();
			XDocument xmlDocument = GetXmlDocument();
			XElement xElement = xmlDocument.Root.Element("CalibrationMaps");
			if (xElement == null)
			{
				xElement = new XElement("CalibrationMaps");
				xmlDocument.Root.Add(xElement);
			}
			XElement xElement2 = XElement.Parse(calibrationMapSaveData.map.ToXmlString());
			bool flag = false;
			string text = "hardwareIdentifier";
			string text2 = "hardwareGuid";
			xElement2.SetAttributeValue(text, joystick.hardwareIdentifier);
			xElement2.SetAttributeValue(text2, joystick.hardwareTypeGuid.ToString());
			foreach (XElement item in xElement.Elements())
			{
				XAttribute xAttribute = item.Attribute(text);
				XAttribute xAttribute2 = item.Attribute(text2);
				if (xAttribute == null || xAttribute2 == null)
				{
					Debug.LogWarning("Something broke with a calibration map.");
				}
				else if (xAttribute.Value == xElement2.Attribute(text).Value && xAttribute2.Value == xElement2.Attribute(text2).Value)
				{
					item.ReplaceWith(xElement2);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				xElement.Add(xElement2);
			}
			RequestSaveIndividualChangeToXmlDocument();
		}

		private void SaveJoystickData(int joystickId)
		{
			IList<Player> allPlayers = ReInput.players.AllPlayers;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				Player player = allPlayers[i];
				if (player.controllers.ContainsController(ControllerType.Joystick, joystickId))
				{
					SaveControllerMaps(player.id, ControllerType.Joystick, joystickId);
				}
			}
			SaveJoystickCalibrationData(joystickId);
		}

		private void SavePlayerDataNow(int playerId)
		{
			SavePlayerDataNow(ReInput.players.GetPlayer(playerId));
		}

		private void SavePlayerDataNow(Player player)
		{
			if (player != null)
			{
				PlayerSaveData saveData = player.GetSaveData(userAssignableMapsOnly: true);
				SaveInputBehaviors(player, saveData);
				SaveControllerMaps(player, saveData);
			}
		}

		private bool TryFindJoysticksImprecise(ControllerAssignmentSaveInfo.JoystickInfo joystickInfo, out List<Joystick> matches)
		{
			matches = null;
			if (joystickInfo == null)
			{
				return false;
			}
			if (string.IsNullOrEmpty(joystickInfo.hardwareIdentifier))
			{
				return false;
			}
			IList<Joystick> joysticks = ReInput.controllers.Joysticks;
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (string.Equals(joysticks[i].hardwareIdentifier, joystickInfo.hardwareIdentifier, StringComparison.OrdinalIgnoreCase))
				{
					if (matches == null)
					{
						matches = new List<Joystick>();
					}
					matches.Add(joysticks[i]);
				}
			}
			return matches != null;
		}
	}
}
