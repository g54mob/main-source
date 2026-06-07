using System;
using System.Collections.Generic;
using System.Reflection;
using SINetworking;
using UnityEngine;

public abstract class Writeable : MonoBehaviour, INetworkID
{
	public enum LoadType
	{
		Default = 0,
		NetworkClient = 1,
		NetworkHost = 2
	}

	public static uint IDCount = 1u;

	public static Dictionary<uint, object> DeserializedObjects = new Dictionary<uint, object>();

	public static Type SaveFieldType = typeof(SaveField);

	public static List<Writeable> MissingIDs = new List<Writeable>();

	[NonSerialized]
	public uint DID;

	[NonSerialized]
	public bool Deserialized;

	[NonSerialized]
	protected Dictionary<string, object> DLCData;

	[NonSerialized]
	protected List<KeyValuePair<string, uint>> DLCLoadFail;

	[NonSerialized]
	private bool _isGOActive = true;

	[NonSerialized]
	protected bool _networkRedundant;

	public static Dictionary<Type, List<KeyValuePair<MemberInfo, SaveField>>> _cachedFields = new Dictionary<Type, List<KeyValuePair<MemberInfo, SaveField>>>();

	public uint NetworkID { get; set; }

	public GameObject GO
	{
		get
		{
			return base.gameObject;
		}
	}

	public bool IsGOActive
	{
		get
		{
			lock (this)
			{
				return _isGOActive;
			}
		}
	}

	public void DestroyGO()
	{
		lock (this)
		{
			if (!_isGOActive)
			{
				return;
			}
			if (NetworkID != 0)
			{
				if (!IsNetworkIDLocal())
				{
					NetworkManager.Instance.UnregisterNetworkObject(NetworkID);
				}
				NetworkMessaging.SendDestroyNetworkObject(NetworkID, IsNetworkIDLocal(), NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				NetworkID = 0u;
			}
			_isGOActive = false;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public uint InitLocalNetworkID()
	{
		if (IsNetworkIDLocal())
		{
			if (NetworkID == 0)
			{
				NetworkID = GameSettings.Instance.GetLocalNetworkID();
			}
			return NetworkID;
		}
		throw new Exception("Tried to create local network ID for global object: " + GetType().Name + ": " + base.name);
	}

	public void InitNetworkID(Action<uint> callback)
	{
		if (NetworkID != 0)
		{
			callback(NetworkID);
		}
		else if (IsNetworkIDLocal())
		{
			NetworkID = GameSettings.Instance.GetLocalNetworkID();
			callback(NetworkID);
		}
		else
		{
			NetworkMessaging.GetGlobalNetworkID(this, callback);
		}
	}

	public void SaveDLCData(string key, object value)
	{
		if (DLCData == null)
		{
			DLCData = new Dictionary<string, object>();
		}
		DLCData[key] = value;
	}

	public void RemoveDLCData(string key)
	{
		if (DLCData != null && DLCData.Remove(key) && DLCData.Count == 0)
		{
			DLCData = null;
		}
	}

	public bool GetDLCData<T>(string key, out T value)
	{
		object value2;
		if (DLCData != null && DLCData.TryGetValue(key, out value2))
		{
			value = (T)value2;
			return true;
		}
		value = default(T);
		return false;
	}

	public T GetDLCDataDefault<T>(string key, T value)
	{
		object value2;
		if (DLCData == null || !DLCData.TryGetValue(key, out value2))
		{
			return value;
		}
		return (T)value2;
	}

	public object GetDeserializedObject(uint id)
	{
		if (id == 0)
		{
			return null;
		}
		object value = null;
		if (DeserializedObjects.TryGetValue(id, out value))
		{
			return value;
		}
		return null;
	}

	public static object STGetDeserializedObject(uint id)
	{
		if (id == 0)
		{
			return null;
		}
		object value = null;
		if (DeserializedObjects.TryGetValue(id, out value))
		{
			return value;
		}
		return null;
	}

	public static uint GetNextID()
	{
		uint iDCount = IDCount;
		IDCount++;
		return iDCount;
	}

	public void InitWritable()
	{
		if (DID == 0)
		{
			DID = GetNextID();
		}
	}

	public WriteDictionary SerializeThis(GameReader.NewLoadMode mode, bool checkDIDs)
	{
		return SerializeThis(mode, LoadType.Default, checkDIDs);
	}

	public WriteDictionary SerializeThis(GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		WriteDictionary writeDictionary = new WriteDictionary(WriteName());
		if (WriteDID())
		{
			if (checkDIDs && !GameReader.ForceWrite)
			{
				if (DID >= IDCount)
				{
					IDCount = DID + 1;
				}
				if (!GameReader.SerializedDIDs.Add(DID))
				{
					GameReader.DIDClash = DID + " - " + WriteName() + " - " + base.name;
					DID = GetNextID();
					GameReader.SerializedDIDs.Add(DID);
				}
				if (GameReader.DIDClash != null)
				{
					return writeDictionary;
				}
			}
			writeDictionary["WriteID"] = DID;
		}
		if (DLCData != null)
		{
			writeDictionary["DLCData"] = SanitizeDLCData();
		}
		if (NetworkID != 0)
		{
			writeDictionary["NetworkID"] = NetworkID;
		}
		SerializeSaveFields(this, writeDictionary, mode, networkMode);
		SerializeMe(writeDictionary, mode, networkMode, checkDIDs);
		return writeDictionary;
	}

	private static SaveField GetSaveFieldAtt(MemberInfo info)
	{
		object[] customAttributes = info.GetCustomAttributes(SaveFieldType, true);
		if (customAttributes.Length != 0)
		{
			return (SaveField)customAttributes[0];
		}
		return null;
	}

	public static void SerializeSaveFields(object target, WriteDictionary result, GameReader.NewLoadMode mode, LoadType networkMode)
	{
		Type type = target.GetType();
		List<KeyValuePair<MemberInfo, SaveField>> value;
		if (!_cachedFields.TryGetValue(type, out value))
		{
			value = CacheSaveFields(type);
		}
		for (int i = 0; i < value.Count; i++)
		{
			KeyValuePair<MemberInfo, SaveField> keyValuePair = value[i];
			if (CompatibleAtt(keyValuePair.Value, mode, networkMode))
			{
				FieldInfo fieldInfo = keyValuePair.Key as FieldInfo;
				if (fieldInfo != null)
				{
					result[keyValuePair.Value.SerializedAs ?? fieldInfo.Name] = fieldInfo.GetValue(target);
					continue;
				}
				PropertyInfo propertyInfo = (PropertyInfo)keyValuePair.Key;
				result[keyValuePair.Value.SerializedAs ?? propertyInfo.Name] = propertyInfo.GetValue(target, null);
			}
		}
	}

	public static void DeserializeSaveFields(object target, WriteDictionary dictionary, bool loading, LoadType networkClient)
	{
		Type type = target.GetType();
		List<KeyValuePair<MemberInfo, SaveField>> value;
		if (!_cachedFields.TryGetValue(type, out value))
		{
			value = CacheSaveFields(type);
		}
		for (int i = 0; i < value.Count; i++)
		{
			KeyValuePair<MemberInfo, SaveField> keyValuePair = value[i];
			if (CompatibleAtt(keyValuePair.Value, loading))
			{
				FieldInfo fieldInfo = keyValuePair.Key as FieldInfo;
				if (fieldInfo != null)
				{
					fieldInfo.SetValue(target, dictionary.Get(keyValuePair.Value.SerializedAs ?? fieldInfo.Name, GetDefaultValue(keyValuePair.Value, fieldInfo, target, networkClient)));
					continue;
				}
				PropertyInfo propertyInfo = (PropertyInfo)keyValuePair.Key;
				propertyInfo.SetValue(target, dictionary.Get(keyValuePair.Value.SerializedAs ?? propertyInfo.Name, GetDefaultValue(keyValuePair.Value, propertyInfo, target, networkClient)), null);
			}
		}
	}

	private static object GetDefaultValue(SaveField field, FieldInfo info, object target, LoadType networkMode)
	{
		if (field.HasDefault && (field.NetworkMode || networkMode != LoadType.NetworkHost))
		{
			return field.DefaultValue;
		}
		return info.GetValue(target);
	}

	private static object GetDefaultValue(SaveField field, PropertyInfo info, object target, LoadType networkMode)
	{
		if (field.HasDefault && (field.NetworkMode || networkMode != LoadType.NetworkHost))
		{
			return field.DefaultValue;
		}
		return info.GetValue(target, null);
	}

	private static List<KeyValuePair<MemberInfo, SaveField>> CacheSaveFields(Type t)
	{
		List<KeyValuePair<MemberInfo, SaveField>> list = new List<KeyValuePair<MemberInfo, SaveField>>();
		_cachedFields[t] = list;
		FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			SaveField saveFieldAtt = GetSaveFieldAtt(fieldInfo);
			if (saveFieldAtt != null)
			{
				list.Add(new KeyValuePair<MemberInfo, SaveField>(fieldInfo, saveFieldAtt));
			}
		}
		PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (PropertyInfo propertyInfo in properties)
		{
			SaveField saveFieldAtt2 = GetSaveFieldAtt(propertyInfo);
			if (saveFieldAtt2 != null)
			{
				list.Add(new KeyValuePair<MemberInfo, SaveField>(propertyInfo, saveFieldAtt2));
			}
		}
		return list;
	}

	private static bool CompatibleAtt(SaveField field, GameReader.NewLoadMode mode, LoadType networkMode)
	{
		if (field.NetworkMode || networkMode != LoadType.NetworkHost)
		{
			return (field.LoadFor & mode) > GameReader.NewLoadMode.None;
		}
		return false;
	}

	private static bool CompatibleAtt(SaveField field, bool loading)
	{
		if (!loading)
		{
			return field.Undo;
		}
		return true;
	}

	public void SerializeThis(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		if (WriteDID() && checkDIDs && !GameReader.ForceWrite)
		{
			if (DID >= IDCount)
			{
				IDCount = DID + 1;
			}
			if (!GameReader.SerializedDIDs.Add(DID))
			{
				GameReader.DIDClash = DID + " - " + WriteName() + " - " + base.name;
				DID = GetNextID();
				GameReader.SerializedDIDs.Add(DID);
			}
			if (GameReader.DIDClash != null)
			{
				return;
			}
		}
		if (DLCData != null)
		{
			dictionary["DLCData"] = SanitizeDLCData();
		}
		if (NetworkID != 0)
		{
			dictionary["NetworkID"] = NetworkID;
		}
		SerializeSaveFields(this, dictionary, mode, networkMode);
		SerializeMe(dictionary, mode, networkMode, checkDIDs);
	}

	private List<KeyValuePair<string, object>> SanitizeDLCData()
	{
		List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(DLCData.Count);
		foreach (KeyValuePair<string, object> dLCDatum in DLCData)
		{
			Writeable writeable = dLCDatum.Value as Writeable;
			if (writeable != null)
			{
				list.Add(new KeyValuePair<string, object>("Writeable" + dLCDatum.Key, writeable.DID));
			}
			else
			{
				list.Add(dLCDatum);
			}
		}
		return list;
	}

	public object DeserializeThis(WriteDictionary dictionary, bool loading, LoadType networkMode = LoadType.Default)
	{
		NetworkID = dictionary.Get("NetworkID", 0u);
		if (NetworkID != 0 && !IsNetworkIDLocal(dictionary))
		{
			if (NetworkManager.Instance.HasNetworkObject(NetworkID))
			{
				_networkRedundant = true;
				Debug.Log("Object of type " + dictionary.Name + " was already network registered " + NetworkID);
				DestroyGO();
				return null;
			}
			NetworkManager.Instance.RegisterNetworkObject(this);
		}
		if (WriteDID())
		{
			DID = (uint)dictionary["WriteID"];
			if (DID >= IDCount)
			{
				IDCount = DID + 1;
			}
		}
		Deserialized = true;
		object result = null;
		try
		{
			object value;
			if (!WriteDID())
			{
				DeserializeSaveFields(this, dictionary, loading, networkMode);
				result = DeserializeMe(dictionary, loading, networkMode);
			}
			else if (loading && DeserializedObjects.TryGetValue(DID, out value))
			{
				DeserializeSaveFields(this, dictionary, loading, networkMode);
				result = DeserializeMe(dictionary, loading, networkMode);
				MissingIDs.Add(this);
				Debug.Log("Found clashing DID " + DID + " for " + ToString() + " used by " + value.ToString());
				DID = 0u;
			}
			else
			{
				DeserializeSaveFields(this, dictionary, loading, networkMode);
				object obj = (DeserializedObjects[DID] = DeserializeMe(dictionary, loading, networkMode));
				result = obj;
			}
			List<KeyValuePair<string, object>> list = dictionary.Get<List<KeyValuePair<string, object>>>("DLCData", null);
			if (list != null)
			{
				DLCData = new Dictionary<string, object>();
				for (int i = 0; i < list.Count; i++)
				{
					KeyValuePair<string, object> keyValuePair = list[i];
					if (keyValuePair.Key.StartsWith("Writeable"))
					{
						uint num = (uint)keyValuePair.Value;
						object value2;
						if (DeserializedObjects.TryGetValue(num, out value2))
						{
							DLCData[keyValuePair.Key.Substring(9)] = value2;
							continue;
						}
						if (DLCLoadFail == null)
						{
							DLCLoadFail = new List<KeyValuePair<string, uint>>();
						}
						DLCLoadFail.Add(new KeyValuePair<string, uint>(keyValuePair.Key.Substring(9), num));
					}
					else
					{
						DLCData[keyValuePair.Key] = keyValuePair.Value;
					}
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return result;
	}

	public virtual string WriteName()
	{
		return "None";
	}

	protected virtual void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
	}

	public virtual void PostDeserialize()
	{
		if (DLCLoadFail != null)
		{
			for (int i = 0; i < DLCLoadFail.Count; i++)
			{
				KeyValuePair<string, uint> keyValuePair = DLCLoadFail[i];
				DLCData[keyValuePair.Key] = GetDeserializedObject(keyValuePair.Value);
			}
			DLCLoadFail = null;
		}
	}

	protected virtual object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		return null;
	}

	protected virtual bool WriteDID()
	{
		return true;
	}

	public virtual bool IsNetworkIDLocal()
	{
		return false;
	}

	public virtual bool IsNetworkIDLocal(WriteDictionary d)
	{
		return false;
	}

	public virtual void UpdateStyleNetwork()
	{
	}

	public virtual void ApplyNetworkStyle(string material, string material2, Color c, Color c2, Color c3, Color c4, int atlasIndex)
	{
	}
}
