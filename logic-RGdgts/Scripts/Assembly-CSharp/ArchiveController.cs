using System;
using System.Collections.Generic;
using RetroLauncher;
using UnityEngine;

public class ArchiveController : Controller, ILogOrigin
{
	public interface IGadgetPreviewListener
	{
		void OnPreviewUpdate(GadgetPreview preview);
	}

	public class GadgetPreview
	{
		public Sprite sprite;

		public Texture2D normal;

		public Texture2D shaded;

		private HashSet<IGadgetPreviewListener> listeners;

		public void Setup(GadgetScreenshooter.Result previewResult)
		{
		}

		public void RegisterListener(IGadgetPreviewListener listener)
		{
		}

		public void UnregisterListener(IGadgetPreviewListener listener)
		{
		}

		public void Dispose()
		{
		}
	}

	[NonSerialized]
	[HideInInspector]
	public Action<uint> onGadgetAdded;

	[NonSerialized]
	[HideInInspector]
	public Action<uint> onGadgetDeleted;

	[NonSerialized]
	[HideInInspector]
	public Action<ulong, SerializedGadgetMetaData> onRemoteGadgetBecomeLocal;

	public const string sharedGadgetFileName = "gadget";

	private IniFile launcherConfigurationFile;

	private LauncherConfiguration launcherConfiguration;

	private Dictionary<uint, SerializedGadgetMetaData> gadgetMetadatasDictionary;

	private Dictionary<uint, Gadget> gadgetsDictionary;

	private Dictionary<ulong, SerializedGadgetMetaData> printedGadgetsMetadatas;

	private Dictionary<uint, GadgetPreview> gadgetPreviewsDictionary;

	private Queue<SerializedGadgetMetaData> installedGadgetToCheck;

	private bool waitingDetails;

	private string printedGadgetsListFile => null;

	public ICollection<SerializedGadgetMetaData> gadgets => null;

	private void InitGame()
	{
	}

	private void CleanMissingLauncherGadgets()
	{
	}

	public override void Init()
	{
	}

	public void OnQuit()
	{
	}

	public void OnWorkshopGadgetInstalled(ulong publishedFileId)
	{
	}

	private void LateUpdate()
	{
	}

	private void CheckRemoteInstalledGadget(SerializedGadgetMetaData metadata)
	{
	}

	private SerializedGadgetMetaData ReadRemoteInstalledGadgetMetadata(ulong publishedFileId, out bool persistentDataAvailable)
	{
		persistentDataAvailable = default(bool);
		return null;
	}

	private void RegisterGadget(SerializedGadgetMetaData metadata)
	{
	}

	private void UnregisterGadget(uint guid)
	{
	}

	public void RemoveRemotePrintedGadget(ulong publishedFileId)
	{
	}

	public SerializedGadgetMetaData GetRemotePrintedGadgetMetadata(ulong publishedFileId)
	{
		return null;
	}

	public Gadget GetGadget(SerializedGadgetMetaData metadata, bool instantiate = true)
	{
		return null;
	}

	public Tuple<SerializedGadgetMetaData.PersistentState, SerializedGadget.PersistentState> GetSerializedGadgetPersistentState(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public SerializedGadget GetSerializedGadget(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public GadgetPreview GetGadgetPreview(uint guid)
	{
		return null;
	}

	public void RefreshPreview(Gadget gadget)
	{
	}

	private void AddPreview(GadgetScreenshooter.Result previewResult, uint guid)
	{
	}

	private void RemovePreview(uint guid)
	{
	}

	public SerializedGadgetMetaData GetGadgetMetadata(uint guid)
	{
		return null;
	}

	public SerializedGadgetMetaData GetGadgetLocalMetadataFromPublishedFileId(ulong publishedFileId)
	{
		return null;
	}

	public SerializedGadgetMetaData GetLastViewedGadget()
	{
		return null;
	}

	private void SavePrintedGadget()
	{
	}

	public void Save(uint gadgetGuid)
	{
	}

	private void Save(SerializedGadgetMetaData metadata)
	{
	}

	private void Save(SerializedGadgetMetaData metadata, SerializedGadget serializedGadget)
	{
	}

	private void SavePersistentState(Gadget gadget)
	{
	}

	private SerializedGadgetMetaData CreateLocalMetadata(SerializedGadgetMetaData readFrom = null)
	{
		return null;
	}

	public SerializedGadgetMetaData CreateGadget(MotherboardShape motherboardShape)
	{
		return null;
	}

	public SerializedGadgetMetaData CreateGadget(MotherboardSection section)
	{
		return null;
	}

	public SerializedGadgetMetaData CreateGadget(MotherboardSectionEnum sectionEnum)
	{
		return null;
	}

	public void DeleteGadget(uint guid)
	{
	}

	public SerializedGadgetMetaData DuplicateGadget(SerializedGadgetMetaData sourceMetadata, Action<SerializedGadgetMetaData> populateMetadata = null)
	{
		return null;
	}

	public SerializedGadgetMetaData CreateLocalGadgetFromSample(SerializedGadgetMetaData sampleMetadata)
	{
		return null;
	}

	public virtual SerializedGadgetMetaData TransformPrintedGadgetIntoLocal(SerializedGadgetMetaData sourceMetadata)
	{
		return null;
	}

	public static string GetGadgetFilename(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public static string GetGadgetFilePath(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public static string GetGadgetPersistentStateFilename(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public static string GetGadgetPersistentStateFilePath(SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public void OnGadgetArchived(Gadget gadget)
	{
	}

	public void OnGadgetEndEdit(Gadget gadget)
	{
	}

	public void OnRemoteDownloadComplete(ulong fileId)
	{
	}

	private uint GenerateGuid()
	{
		return 0u;
	}

	public void OnGadgetDestroy(SerializedGadgetMetaData metadata)
	{
	}

	public void ShowInOSExplorer(SerializedGadgetMetaData metadata)
	{
	}

	public void OpenFolderInOSExplorer(string folderPath)
	{
	}

	private bool SaveLauncherConfiguration()
	{
		return false;
	}

	public bool AddGadgetToLauncher(SerializedGadgetMetaData metadata, GadgetConfiguration configuration)
	{
		return false;
	}

	public bool RemoveGadgetFromLauncher(SerializedGadgetMetaData metadata)
	{
		return false;
	}

	public bool IsGadgetInLauncher(SerializedGadgetMetaData metadata, out GadgetConfiguration configuration)
	{
		configuration = default(GadgetConfiguration);
		return false;
	}

	public List<SerializedGadgetMetaData> GetGadgetsFromLauncher()
	{
		return null;
	}
}
