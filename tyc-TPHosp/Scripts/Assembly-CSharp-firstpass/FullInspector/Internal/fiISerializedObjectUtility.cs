using System;
using System.Collections.Generic;
using FullSerializer;
using FullSerializer.Internal;
using UnityEngine;

namespace FullInspector.Internal
{
	public static class fiISerializedObjectUtility
	{
		private static Dictionary<string, ISerializedObject> _skipSerializationQueue = new Dictionary<string, ISerializedObject>();

		private static void SkipCloningValues(ISerializedObject obj)
		{
			lock (_skipSerializationQueue)
			{
				if (!_skipSerializationQueue.ContainsKey(obj.SharedStateGuid))
				{
					_skipSerializationQueue[obj.SharedStateGuid] = obj;
				}
			}
		}

		private static bool TryToCopyValues(ISerializedObject newInstance)
		{
			if (string.IsNullOrEmpty(newInstance.SharedStateGuid))
			{
				return false;
			}
			ISerializedObject value = null;
			lock (_skipSerializationQueue)
			{
				if (!_skipSerializationQueue.TryGetValue(newInstance.SharedStateGuid, out value))
				{
					return false;
				}
				_skipSerializationQueue.Remove(newInstance.SharedStateGuid);
			}
			if (newInstance == value)
			{
				return true;
			}
			InspectedType inspectedType = InspectedType.Get(value.GetType());
			for (int i = 0; i < value.SerializedStateKeys.Count; i++)
			{
				InspectedProperty inspectedProperty = inspectedType.GetPropertyByName(value.SerializedStateKeys[i]) ?? inspectedType.GetPropertyByFormerlySerializedName(value.SerializedStateKeys[i]);
				inspectedProperty.Write(newInstance, inspectedProperty.Read(value));
			}
			return true;
		}

		private static bool SaveStateForProperty(ISerializedObject obj, InspectedProperty property, BaseSerializer serializer, ISerializationOperator serializationOperator, out string serializedValue, ref bool success)
		{
			object obj2 = property.Read(obj);
			try
			{
				if (obj2 == null)
				{
					serializedValue = null;
				}
				else
				{
					serializedValue = serializer.Serialize(property.MemberInfo, obj2, serializationOperator);
				}
				return true;
			}
			catch (Exception ex)
			{
				success = false;
				serializedValue = null;
				Debug.LogError("Exception caught when serializing property <" + property.Name + "> in <" + obj?.ToString() + "> with value " + obj2?.ToString() + "\n" + ex);
				return false;
			}
		}

		public static bool SaveState<TSerializer>(ISerializedObject obj) where TSerializer : BaseSerializer
		{
			fiLog.Log(typeof(fiISerializedObjectUtility), "Serializing object of type {0}", obj.GetType());
			bool success = true;
			ISerializationCallbacks serializationCallbacks = obj as ISerializationCallbacks;
			serializationCallbacks?.OnBeforeSerialize();
			if (!string.IsNullOrEmpty(obj.SharedStateGuid))
			{
				SkipCloningValues(obj);
				serializationCallbacks?.OnAfterSerialize();
				return true;
			}
			TSerializer serializer = fiSingletons.Get<TSerializer>();
			ListSerializationOperator listSerializationOperator = fiSingletons.Get<ListSerializationOperator>();
			listSerializationOperator.SerializedObjects = new List<UnityEngine.Object>();
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			if (fiUtility.IsEditor || obj.SerializedStateKeys == null || obj.SerializedStateKeys.Count == 0)
			{
				List<InspectedProperty> properties = InspectedType.Get(obj.GetType()).GetProperties(InspectedMemberFilters.FullInspectorSerializedProperties);
				for (int i = 0; i < properties.Count; i++)
				{
					InspectedProperty inspectedProperty = properties[i];
					if (SaveStateForProperty(obj, inspectedProperty, serializer, listSerializationOperator, out var serializedValue, ref success))
					{
						list.Add(inspectedProperty.Name);
						list2.Add(serializedValue);
					}
				}
			}
			else
			{
				InspectedType inspectedType = InspectedType.Get(obj.GetType());
				for (int j = 0; j < obj.SerializedStateKeys.Count; j++)
				{
					InspectedProperty inspectedProperty2 = inspectedType.GetPropertyByName(obj.SerializedStateKeys[j]) ?? inspectedType.GetPropertyByFormerlySerializedName(obj.SerializedStateKeys[j]);
					if (inspectedProperty2 != null && SaveStateForProperty(obj, inspectedProperty2, serializer, listSerializationOperator, out var serializedValue2, ref success))
					{
						list.Add(inspectedProperty2.Name);
						list2.Add(serializedValue2);
					}
				}
			}
			bool flag = false;
			if (AreListsDifferent(obj.SerializedStateKeys, list))
			{
				obj.SerializedStateKeys = list;
				flag = true;
			}
			if (AreListsDifferent(obj.SerializedStateValues, list2))
			{
				obj.SerializedStateValues = list2;
				flag = true;
			}
			if (AreListsDifferent(obj.SerializedObjectReferences, listSerializationOperator.SerializedObjects))
			{
				obj.SerializedObjectReferences = listSerializationOperator.SerializedObjects;
				flag = true;
			}
			if (flag && fiUtility.IsEditor)
			{
				fiLateBindings.EditorApplication.InvokeOnEditorThread(delegate
				{
					UnityEngine.Object obj2 = (UnityEngine.Object)obj;
					if (obj2 != null)
					{
						fiLateBindings.EditorUtility.SetDirty(obj2);
					}
				});
			}
			serializationCallbacks?.OnAfterSerialize();
			return success;
		}

		private static bool AreListsDifferent(IList<string> a, IList<string> b)
		{
			if (a == null)
			{
				return true;
			}
			if (a.Count != b.Count)
			{
				return true;
			}
			int count = a.Count;
			for (int i = 0; i < count; i++)
			{
				if (a[i] != b[i])
				{
					return true;
				}
			}
			return false;
		}

		private static bool AreListsDifferent(IList<UnityEngine.Object> a, IList<UnityEngine.Object> b)
		{
			if (a == null)
			{
				return true;
			}
			if (a.Count != b.Count)
			{
				return true;
			}
			int count = a.Count;
			for (int i = 0; i < count; i++)
			{
				if ((object)a[i] != b[i])
				{
					return true;
				}
			}
			return false;
		}

		public static bool RestoreState<TSerializer>(ISerializedObject obj) where TSerializer : BaseSerializer
		{
			if (fiSerializationManager.IsInSaveOrLoad)
			{
				return true;
			}
			fiLog.Log(typeof(fiISerializedObjectUtility), "Deserializing object of type {0}", obj.GetType());
			ISerializationCallbacks serializationCallbacks = obj as ISerializationCallbacks;
			try
			{
				serializationCallbacks?.OnBeforeDeserialize();
				if (!string.IsNullOrEmpty(obj.SharedStateGuid))
				{
					if (obj.IsRestored)
					{
						return true;
					}
					if (TryToCopyValues(obj))
					{
						fiLog.Log(typeof(fiISerializedObjectUtility), "-- note: Used fast path when deserializing object of type {0}", obj.GetType());
						obj.IsRestored = true;
						serializationCallbacks?.OnAfterDeserialize();
						return true;
					}
					Debug.LogError("Shared state deserialization failed for object of type " + obj.GetType().CSharpName(), obj as UnityEngine.Object);
				}
				if (obj.SerializedStateKeys == null)
				{
					obj.SerializedStateKeys = new List<string>();
				}
				if (obj.SerializedStateValues == null)
				{
					obj.SerializedStateValues = new List<string>();
				}
				if (obj.SerializedObjectReferences == null)
				{
					obj.SerializedObjectReferences = new List<UnityEngine.Object>();
				}
				if (obj.SerializedStateKeys.Count != obj.SerializedStateValues.Count && fiSettings.EmitWarnings)
				{
					Debug.LogWarning("Serialized key count does not equal value count; possible data corruption / bad manual edit?", obj as UnityEngine.Object);
				}
				if (obj.SerializedStateKeys.Count == 0)
				{
					if (fiSettings.AutomaticReferenceInstantation)
					{
						InstantiateReferences(obj, null);
					}
					obj.IsRestored = true;
					return true;
				}
				TSerializer val = fiSingletons.Get<TSerializer>();
				ListSerializationOperator listSerializationOperator = fiSingletons.Get<ListSerializationOperator>();
				listSerializationOperator.SerializedObjects = obj.SerializedObjectReferences;
				InspectedType inspectedType = InspectedType.Get(obj.GetType());
				bool result = true;
				for (int i = 0; i < obj.SerializedStateKeys.Count; i++)
				{
					string text = obj.SerializedStateKeys[i];
					string text2 = obj.SerializedStateValues[i];
					InspectedProperty inspectedProperty = inspectedType.GetPropertyByName(text) ?? inspectedType.GetPropertyByFormerlySerializedName(text);
					if (inspectedProperty == null)
					{
						if (fiSettings.EmitWarnings)
						{
							Debug.LogWarning("Unable to find serialized property with name=" + text + " on type " + obj.GetType(), obj as UnityEngine.Object);
						}
						continue;
					}
					object value = null;
					if (!string.IsNullOrEmpty(text2))
					{
						try
						{
							value = val.Deserialize(inspectedProperty.MemberInfo, text2, listSerializationOperator);
						}
						catch (Exception ex)
						{
							result = false;
							Debug.LogError("Exception caught when deserializing property <" + text + "> with type <" + obj.GetType()?.ToString() + ">\n" + ex, obj as UnityEngine.Object);
						}
					}
					try
					{
						inspectedProperty.Write(obj, value);
					}
					catch (Exception message)
					{
						result = false;
						if (fiSettings.EmitWarnings)
						{
							Debug.LogWarning("Caught exception when updating property value; see next message for the exception", obj as UnityEngine.Object);
							Debug.LogError(message);
						}
					}
				}
				obj.IsRestored = true;
				return result;
			}
			finally
			{
				serializationCallbacks?.OnAfterDeserialize();
			}
		}

		private static void InstantiateReferences(object obj, InspectedType metadata)
		{
			if (metadata == null)
			{
				metadata = InspectedType.Get(obj.GetType());
			}
			if (metadata.IsCollection)
			{
				return;
			}
			List<InspectedProperty> properties = metadata.GetProperties(InspectedMemberFilters.InspectableMembers);
			for (int i = 0; i < properties.Count; i++)
			{
				InspectedProperty inspectedProperty = properties[i];
				if (inspectedProperty.StorageType.Resolve().IsClass && !inspectedProperty.StorageType.Resolve().IsAbstract && inspectedProperty.Read(obj) == null)
				{
					InspectedType inspectedType = InspectedType.Get(inspectedProperty.StorageType);
					if (inspectedType.HasDefaultConstructor)
					{
						object obj2 = inspectedType.CreateInstance();
						inspectedProperty.Write(obj, obj2);
						InstantiateReferences(obj2, inspectedType);
					}
				}
			}
		}
	}
}
