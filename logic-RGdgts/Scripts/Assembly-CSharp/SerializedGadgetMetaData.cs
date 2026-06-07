using System;
using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UnityEngine;

public class SerializedGadgetMetaData : ISerializationCallbackReceiver, IElementColoredButtonParameters
{
	[Serializable]
	public struct Preview
	{
		public byte[] colorMap;

		public byte[] normalMap;

		public byte[] shaded;

		public byte[] workshopPreview;

		public GadgetScreenshooter.Result? InstantiateTextures()
		{
			return null;
		}
	}

	public enum Type
	{
		Local = 0,
		Remote = 1,
		RemotePrinted = 2,
		Sample = 3
	}

	public class PersistentState
	{
		public DateTime gadgetUpdateDate;

		public DateTime lastViewDate;

		public int width;

		public int height;

		public Preview preview;

		public PersistentState()
		{
		}

		public PersistentState(SerializedGadgetMetaData metadata)
		{
		}

		public bool IsCompatible(SerializedGadgetMetaData metadata)
		{
			return false;
		}

		public void Apply(SerializedGadgetMetaData metadata)
		{
		}
	}

	[NonSerialized]
	public Type type;

	public uint guid;

	public string displayName;

	public string description;

	public DateTime creationDate;

	public DateTime lastEditDate;

	public DateTime lastSaveDate;

	public DateTime lastViewDate;

	public ulong authorSteamId;

	public ulong publishedFileId;

	public DateTime publishedDate;

	public DateTime updateDate;

	public int width;

	public int height;

	public Preview preview;

	public HashSet<string> tags;

	public uint voteUp;

	public uint voteDown;

	public float positiveVoteRatio;

	[NonSerialized]
	private GadgetPermissions _permissions;

	[NonSerialized]
	public Sprite workshopPreviewSprite;

	[NonSerialized]
	private bool _haveCompleteData;

	[NonSerialized]
	protected List<Tuple<UnityEngine.Object, Action<SerializedGadgetMetaData>>> onChangeAction;

	public GadgetPermissions permissions => null;

	public bool haveCompleteData
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool isLocal => false;

	public bool isSample => false;

	public bool isRemotePrinted => false;

	public bool isSubscribed => false;

	public bool needUpdate => false;

	public bool isPublished => false;

	public bool isDownloading => false;

	public bool isInstalled => false;

	void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
	}

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
	}

	public SerializedGadgetMetaData()
	{
	}

	public SerializedGadgetMetaData(SerializedGadgetMetaData metaData)
	{
	}

	public void ReadFrom(SerializedGadgetMetaData metaData)
	{
	}

	public void FillWorkshopVolatileData(WorkshopController.WorkshopItemDetails itemDetail)
	{
	}

	public void UpdateWorkshopState(Action<SerializedGadgetMetaData> onComplete)
	{
	}

	public void OnChange()
	{
	}

	public void AddOnButtonChangeAction(UnityEngine.Object owner, Action<IElementColoredButtonParameters> onChange)
	{
	}

	public void OnPreviewDataChange()
	{
	}

	private void CreateWorkshopPreviewSprite()
	{
	}

	public virtual void RequestCompleteData(Action<SerializedGadgetMetaData> onComplete)
	{
	}

	public string GetButtonName()
	{
		return null;
	}

	public Sprite GetButtonIcon()
	{
		return null;
	}

	public Sprite GetButtonSprite(ElementParameters name)
	{
		return null;
	}

	public string GetButtonString(ElementParameters name)
	{
		return null;
	}

	public bool IsSecondaryColor()
	{
		return false;
	}

	public void AddOnChangeAction(UnityEngine.Object owner, Action<SerializedGadgetMetaData> onChange)
	{
	}

	public void RemoveOnChangeAction(UnityEngine.Object owner)
	{
	}

	public virtual GadgetWorkshopStates GetWorkshopState()
	{
		return default(GadgetWorkshopStates);
	}

	private void DisposePreview()
	{
	}

	public void Dispose()
	{
	}
}
