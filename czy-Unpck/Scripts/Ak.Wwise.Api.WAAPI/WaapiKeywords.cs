using System.Collections.Generic;
using System.Collections.ObjectModel;

public class WaapiKeywords
{
	public const string ACTION = "action";

	public const string ANCESTORS = "ancestors";

	public const string AT = "@";

	public const string AUX_BUSSES = "auxBusses";

	public const string BACK_SLASH = "\\";

	public const string BANK_DATA = "bankData";

	public const string BANK_INFO = "bankInfo";

	public const string CHILD = "child";

	public const string CHILDREN = "children";

	public const string CHILDREN_COUNT = "childrenCount";

	public const string CLASSID = "classId";

	public const string COMMAND = "command";

	public const string DATA = "data";

	public const string DELETE_ITEMS = "Delete Items";

	public const string DESCENDANTS = "descendants";

	public const string DISPLAY_NAME = "displayName";

	public const string DRAG_DROP_ITEMS = "Drag Drop Items";

	public const string EVENT = "event";

	public const string EVENTS = "events";

	public const string FILEPATH = "filePath";

	public const string FIND_IN_PROJECT_EXPLORER = "FindInProjectExplorerSyncGroup1";

	public const string FOLDER = "Folder";

	public const string FROM = "from";

	public const string ID = "id";

	public const string INCLUSIONS = "inclusions";

	public const string INFO_FILE = "infoFile";

	public const string IS_CONNECTED = "isConnected";

	public const string LANGUAGE = "language";

	public const string LANGUAGES = "languages";

	public const string MAX = "max";

	public const string MAX_RADIUS_ATTENUATION = "audioSource:maxRadiusAttenuation";

	public const string MESSSAGE = "message";

	public const string MIN = "min";

	public const string NAME = "name";

	public const string NAMECONTAINS = "name:contains";

	public const string NEW = "new";

	public const string NEW_NAME = "newName";

	public const string NOTES = "notes";

	public const string OBJECT = "object";

	public const string OBJECTS = "objects";

	public const string OF_TYPE = "ofType";

	public const string OLD_NAME = "oldName";

	public const string PARENT = "parent";

	public const string PATH = "path";

	public const string PHYSICAL_FOLDER = "PhysicalFolder";

	public const string PLATFORM = "platform";

	public const string PLATFORMS = "platforms";

	public const string PLAY = "play";

	public const string PLAYING = "playing";

	public const string PLAYSTOP = "playStop";

	public const string PLUGININFO_OPTIONS = "pluginInfo";

	public const string PLUGININFO_RESPONSE = "PluginInfo";

	public const string PROJECT = "Project";

	public const string PROPERTY = "property";

	public const string RADIUS = "radius";

	public const string RANGE = "range";

	public const string REBUILD = "rebuild";

	public const string REDO = "Redo";

	public const string RESTRICTION = "restriction";

	public const string RETURN = "return";

	public const string SEARCH = "search";

	public const string SELECT = "select";

	public const string SIZE = "size";

	public const string SKIP_LANGUAGES = "skipLanguages";

	public const string SOUNDBANK = "soundbank";

	public const string SOUNDBANKS = "soundbanks";

	public const string STATE = "state";

	public const string STOP = "stop";

	public const string STOPPED = "stopped";

	public const string STRUCTURE = "structure";

	public const string TRANSFORM = "transform";

	public const string TRANSPORT = "transport";

	public const string TYPE = "type";

	public const string UI = "ui";

	public const string UNDO = "Undo";

	public const string VALUE = "value";

	public const string VOLUME = "Volume";

	public const string WHERE = "where";

	public const string WORKUNIT_TYPE = "workunit:type";

	public const string OPEN_SOUNDBANK_FOLDER = "OpenContainingFolderSoundbank";

	public const string OPEN_WORKUNIT_FOLDER = "OpenContainingFolderWorkUnit";

	public const string OPEN_WAV_FOLDER = "OpenContainingFolderWAV";

	public static ReadOnlyDictionary<WwiseObjectType, string> WwiseObjectTypeStrings = new ReadOnlyDictionary<WwiseObjectType, string>(new Dictionary<WwiseObjectType, string>
	{
		{
			WwiseObjectType.None,
			"None"
		},
		{
			WwiseObjectType.AuxBus,
			"AuxiliaryBus"
		},
		{
			WwiseObjectType.Bus,
			"Bus"
		},
		{
			WwiseObjectType.Event,
			"Event"
		},
		{
			WwiseObjectType.Folder,
			"Folder"
		},
		{
			WwiseObjectType.PhysicalFolder,
			"PhysicalFolder"
		},
		{
			WwiseObjectType.Project,
			"Project"
		},
		{
			WwiseObjectType.Soundbank,
			"SoundBank"
		},
		{
			WwiseObjectType.State,
			"State"
		},
		{
			WwiseObjectType.StateGroup,
			"StateGroup"
		},
		{
			WwiseObjectType.Switch,
			"Switch"
		},
		{
			WwiseObjectType.SwitchGroup,
			"SwitchGroup"
		},
		{
			WwiseObjectType.WorkUnit,
			"WorkUnit"
		},
		{
			WwiseObjectType.GameParameter,
			"Game Parametr"
		},
		{
			WwiseObjectType.Trigger,
			"Trigger"
		},
		{
			WwiseObjectType.AcousticTexture,
			"AcousticTexture"
		}
	});

	public static ReadOnlyDictionary<string, string> FolderDisplaynames = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>
	{
		{ "Master-Mixer Hierarchy", "Auxiliary Busses" },
		{ "Events", "Events" },
		{ "States", "States" },
		{ "SoundBanks", "SoundBanks" },
		{ "Switches", "Switches" },
		{ "Virtual Acoustics", "Virtual Acoustics" }
	});

	public static ReadOnlyDictionary<string, WwiseObjectType> typeStringDict = new ReadOnlyDictionary<string, WwiseObjectType>(new Dictionary<string, WwiseObjectType>
	{
		["auxbus"] = WwiseObjectType.AuxBus,
		["bus"] = WwiseObjectType.Bus,
		["event"] = WwiseObjectType.Event,
		["folder"] = WwiseObjectType.Folder,
		["physicalfolder"] = WwiseObjectType.PhysicalFolder,
		["soundbank"] = WwiseObjectType.Soundbank,
		["project"] = WwiseObjectType.Project,
		["state"] = WwiseObjectType.State,
		["stategroup"] = WwiseObjectType.StateGroup,
		["switch"] = WwiseObjectType.Switch,
		["switchgroup"] = WwiseObjectType.SwitchGroup,
		["workunit"] = WwiseObjectType.WorkUnit,
		["gameparameter"] = WwiseObjectType.GameParameter,
		["trigger"] = WwiseObjectType.Trigger,
		["acoustictexture"] = WwiseObjectType.AcousticTexture
	});
}
