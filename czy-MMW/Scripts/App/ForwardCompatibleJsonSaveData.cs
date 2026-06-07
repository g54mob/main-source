using System;
using System.Collections.Generic;
using System.Globalization;
using Factory;

public abstract class ForwardCompatibleJsonSaveData : IJsonSerializableSaveData, IStorable
{
	private bool _isMerging;

	private bool _changedDuringMerge;

	private bool _hasUnstoredChanges;

	private JSON.Dictionary _sourceDictionary;

	private bool _isSourceAuthoritative;

	[Dependency]
	private IPersistentStorageService _storage;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("JsonStorable");

	private const string TimestampLowKey = "_utcSaveTime_low";

	private const string TimestampHighKey = "_utcSaveTime_high";

	public DateTime UtcTimestamp { get; set; } = DateTime.MinValue;

	public bool IsAuthoritative { get; set; }

	public event Action DataChanged;

	public void InitializeWithJson(JSON.Dictionary jsonDictionary)
	{
		UtcTimestamp = DateTimeExtensions.FromInts(jsonDictionary.GetInt("_utcSaveTime_low"), jsonDictionary.GetInt("_utcSaveTime_high"));
		LoadFromJson(jsonDictionary);
		_sourceDictionary = jsonDictionary.Clone();
	}

	public Dictionary<string, object> SerializeToJson()
	{
		Dictionary<string, object> dictionary = ((_sourceDictionary == null) ? new Dictionary<string, object>() : _sourceDictionary.Clone().RawDictionary);
		UtcTimestamp.ToInts(out var lowBits, out var highBits);
		dictionary["_utcSaveTime_low"] = lowBits;
		dictionary["_utcSaveTime_high"] = highBits;
		SaveToJson(dictionary);
		return dictionary;
	}

	public void Merge(IJsonSerializableSaveData otherData, bool autosave = true)
	{
		Log.Info("Merging {0} with {1}.", this, otherData);
		if (!(otherData is ForwardCompatibleJsonSaveData forwardCompatibleJsonSaveData))
		{
			return;
		}
		if (!_isSourceAuthoritative || forwardCompatibleJsonSaveData.IsAuthoritative)
		{
			_sourceDictionary = forwardCompatibleJsonSaveData._sourceDictionary?.Clone();
			_isSourceAuthoritative = forwardCompatibleJsonSaveData.IsAuthoritative;
		}
		_isMerging = true;
		_changedDuringMerge = false;
		MergeValues(forwardCompatibleJsonSaveData);
		_isMerging = false;
		if (_changedDuringMerge)
		{
			_changedDuringMerge = false;
			if (forwardCompatibleJsonSaveData.UtcTimestamp > UtcTimestamp)
			{
				Log.Info("Data changed on merge, updating timestamp from {0} to {1}.", UtcTimestamp.ToString(CultureInfo.InvariantCulture), forwardCompatibleJsonSaveData.UtcTimestamp.ToString(CultureInfo.InvariantCulture));
				UtcTimestamp = forwardCompatibleJsonSaveData.UtcTimestamp;
			}
			if ((_hasUnstoredChanges || !otherData.IsAuthoritative) && autosave)
			{
				Log.Info("Rescheduling a store to persist the merged changes.");
				_storage.Store(this, OnStoreCompleted);
			}
			this.DataChanged?.Invoke();
		}
	}

	public override string ToString()
	{
		return $"[{GetType().Name} UtcTimestamp={UtcTimestamp.ToString(CultureInfo.InvariantCulture)}]";
	}

	protected void OnValueChanged()
	{
		if (_isMerging)
		{
			_changedDuringMerge = true;
			return;
		}
		UtcTimestamp = DateTime.UtcNow;
		_hasUnstoredChanges = true;
		_storage.Store(this, OnStoreCompleted);
		Log.Info("Data changed on {0}, updating timestamp and scheduling a store.", this);
		this.DataChanged?.Invoke();
	}

	protected T ChooseMax<T>(T ours, T theirs) where T : IComparable
	{
		if (ours.CompareTo(theirs) < 0)
		{
			return theirs;
		}
		return ours;
	}

	protected T ChooseLatest<T>(T ours, T theirs, DateTime theirTimestamp)
	{
		if (!(UtcTimestamp >= theirTimestamp))
		{
			return theirs;
		}
		return ours;
	}

	private void OnStoreCompleted(StoreOperationResult result)
	{
		if (result != StoreOperationResult.Failed)
		{
			_hasUnstoredChanges = false;
		}
	}

	protected abstract void LoadFromJson(JSON.Dictionary jsonDictionary);

	protected abstract void SaveToJson(Dictionary<string, object> jsonDictionary);

	protected abstract void MergeValues(ForwardCompatibleJsonSaveData otherSaveData);
}
