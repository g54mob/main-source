#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BehaviorDesigner.Runtime;
using FullInspector;
using FullSerializer;
using FullSerializer.Internal;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
using xxHashSharp;

namespace TH20
{
	public static class AssetIDMapping
	{
		public class ToVisit
		{
			public readonly object Obj;

			public readonly int ObjHashCodeCache;

			public readonly int OwningAssetID;

			public readonly string MemberPath;

			public readonly int ID;

			public ToVisit(object obj, int owningAssetID, string memberPath)
			{
				Obj = obj;
				ObjHashCodeCache = Obj.GetHashCode();
				OwningAssetID = owningAssetID;
				MemberPath = memberPath;
				ID = GenerateObjectID(Obj, OwningAssetID, MemberPath);
			}

			public ToVisit(object obj, int owningAssetID, string memberPath, int overrideID)
			{
				Obj = obj;
				ObjHashCodeCache = Obj.GetHashCode();
				OwningAssetID = owningAssetID;
				MemberPath = memberPath;
				ID = overrideID;
			}

			public override int GetHashCode()
			{
				return ID;
			}

			public override bool Equals(object otherAsObj)
			{
				ToVisit toVisit = otherAsObj as ToVisit;
				if (toVisit != null && Obj == toVisit.Obj && OwningAssetID == toVisit.OwningAssetID)
				{
					return MemberPath == toVisit.MemberPath;
				}
				return false;
			}

			public static bool operator ==(ToVisit x, ToVisit y)
			{
				if ((object)x != y)
				{
					return x?.Equals(y) ?? false;
				}
				return true;
			}

			public static bool operator !=(ToVisit x, ToVisit y)
			{
				return !(x == y);
			}
		}

		private class ToVisitObjectHashComparer : IComparer<ToVisit>
		{
			public static readonly ToVisitObjectHashComparer Instance = new ToVisitObjectHashComparer();

			public int Compare(ToVisit x, ToVisit y)
			{
				return x.ObjHashCodeCache.CompareTo(y.ObjHashCodeCache);
			}
		}

		private class CachedTypeInfo
		{
			public bool IsInterface;

			public bool IsClass;

			public bool IsValueType;

			public bool IsPrimitive;

			public bool IsEnum;

			public bool IsIgnoredForAssetIDs;

			public bool InternalsAreIgnoredForAssetIDs;
		}

		private static byte[] _byteBuffer = new byte[1024];

		private static readonly Dictionary<Type, CachedTypeInfo> TypeInfoCache = new Dictionary<Type, CachedTypeInfo>();

		public static BiDictionary<int, object> GenerateExternalReferencesList(object rootObject)
		{
			return GenerateExternalReferencesListInternal(new ToVisit(rootObject, -1, ""), null);
		}

		public static BiDictionary<int, object> GenerateExternalReferencesList(ISharedInstance rootObject)
		{
			return GenerateExternalReferencesListInternal(new ToVisit(rootObject, rootObject.GetID, "", rootObject.GetID), null);
		}

		public static BiDictionary<int, object> GenerateExternalReferencesListInternal(ToVisit firstVisited, List<ToVisit> visitedOut)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			BiDictionary<int, object> biDictionary = new BiDictionary<int, object>();
			Queue<ToVisit> queue = new Queue<ToVisit>();
			List<ToVisit> list = new List<ToVisit>();
			List<ToVisit> list2 = new List<ToVisit>();
			queue.Enqueue(firstVisited);
			list.Add(firstVisited);
			while (queue.Count > 0)
			{
				ToVisit toVisit = queue.Dequeue();
				int index = BinarySearchToVisitListForObject(list, toVisit.Obj);
				list.RemoveAt(index);
				Visit(toVisit, queue, list, list2, biDictionary);
			}
			Logging.Info(LogChannels.Save, "Found {0} instances in {1}s, visited {2} objects", biDictionary.Count, Time.realtimeSinceStartup - realtimeSinceStartup, list2.Count);
			visitedOut?.AddRange(list2);
			return biDictionary;
		}

		private static void Visit(ToVisit currentlyVisited, Queue<ToVisit> toVisit, List<ToVisit> toVisitSet, List<ToVisit> visited, BiDictionary<int, object> mapping)
		{
			object obj = currentlyVisited.Obj;
			Type type = obj.GetType();
			if (typeof(ISharedInstance).IsAssignableFrom(type))
			{
				VisitSharedInstance(toVisit, toVisitSet, visited, mapping, obj);
				return;
			}
			if (typeof(IObjectWithID).IsAssignableFrom(type))
			{
				VisitObjectWithID(toVisit, toVisitSet, visited, mapping, type, obj);
				return;
			}
			if (typeof(UnityEngine.Object).IsAssignableFrom(type))
			{
				VisitUnityObject(currentlyVisited, toVisit, toVisitSet, visited, mapping, obj, type);
				return;
			}
			if (IsClassOrStructOrInterface(type))
			{
				VisitClassWithReflection(currentlyVisited, toVisit, toVisitSet, visited, mapping, type, obj);
				return;
			}
			Logging.Error("Somehow visiting something we shouldn't be visiting. Type: {0}", type);
		}

		private static void VisitSharedInstance(Queue<ToVisit> toVisit, List<ToVisit> toVisitSet, List<ToVisit> visited, BiDictionary<int, object> mapping, object obj)
		{
			ISharedInstance sharedInstance = (ISharedInstance)obj;
			InsertIntoToVisitList(visited, new ToVisit(obj, sharedInstance.GetID, "", sharedInstance.GetID));
			if (mapping.ContainsValue(sharedInstance))
			{
				Logging.Error(sharedInstance as UnityEngine.Object, LogChannels.Save, "Mapping already contains object {0}. Already has ID {1}, trying to add with ID {2}", sharedInstance, mapping.SecondToFirst[sharedInstance], sharedInstance.GetID);
			}
			else if (mapping.ContainsKey(sharedInstance.GetID))
			{
				Logging.Error(sharedInstance as UnityEngine.Object, LogChannels.Save, "Mapping already contains entry for ID: {0}. This: {1}. Other: {2}", sharedInstance.GetID, sharedInstance, mapping[sharedInstance.GetID]);
			}
			else
			{
				mapping.Add(sharedInstance.GetID, obj);
			}
			if (sharedInstance == null || sharedInstance.GetInstance == null)
			{
				Logging.Error(sharedInstance as UnityEngine.Object, LogChannels.Save, "ObjectAsSharedInstance has no instance! ID = {0}, Type = {1}, Name = {2}.", sharedInstance.GetID, obj.GetType(), sharedInstance.ToString());
			}
			if (IsClassOrStructOrInterfaceWeWantToVisit(sharedInstance.GetInstance.GetType()))
			{
				object getInstance = sharedInstance.GetInstance;
				int num = sharedInstance.GetID - 1;
				ToVisit currentlyVisited = new ToVisit(getInstance, num, "", num);
				InsertIntoToVisitList(visited, currentlyVisited);
				if (mapping.ContainsValue(getInstance))
				{
					Logging.Error(LogChannels.Save, "Mapping already contains object {0}. Already has ID {1}, trying to add with ID {2}", getInstance, mapping.SecondToFirst[getInstance], num);
				}
				else if (mapping.ContainsKey(num))
				{
					Logging.Error(LogChannels.Save, "Mapping already contains entry for ID: {0}. This: {1}. Other: {2}", num, getInstance, mapping[num]);
				}
				else
				{
					mapping.Add(num, getInstance);
				}
				VisitClassInternals(currentlyVisited, toVisit, toVisitSet, visited, getInstance.GetType(), getInstance);
			}
		}

		private static void VisitObjectWithID(Queue<ToVisit> toVisit, List<ToVisit> toVisitSet, List<ToVisit> visited, BiDictionary<int, object> mapping, Type objType, object obj)
		{
			IObjectWithID objectWithID = (IObjectWithID)obj;
			ToVisit currentlyVisited = new ToVisit(obj, objectWithID.ID, "", objectWithID.ID);
			InsertIntoToVisitList(visited, currentlyVisited);
			if (mapping.ContainsValue(objectWithID))
			{
				Logging.Error(objectWithID as UnityEngine.Object, LogChannels.Save, "Mapping already contains object {0}. Already has ID {1}, trying to add with ID {2}", objectWithID, mapping.SecondToFirst[objectWithID], objectWithID.ID);
			}
			else if (mapping.ContainsKey(objectWithID.ID))
			{
				Logging.Error(objectWithID as UnityEngine.Object, LogChannels.Save, "Mapping already contains entry for ID: {0}. This: {1}. Other: {2}", objectWithID.ID, objectWithID, mapping[objectWithID.ID]);
			}
			else
			{
				mapping.Add(objectWithID.ID, obj);
			}
			VisitClassInternals(currentlyVisited, toVisit, toVisitSet, visited, objType, obj);
		}

		private static void VisitUnityObject(ToVisit currentlyVisited, Queue<ToVisit> toVisit, List<ToVisit> toVisitSet, List<ToVisit> visited, BiDictionary<int, object> mapping, object obj, Type objType)
		{
			if (IsTypeThatShouldUseAssetNameAsHash(objType))
			{
				UnityEngine.Object obj2 = obj as UnityEngine.Object;
				int num = GenerateHashFromString(PrefixForAssetNameOfType(objType) + obj2.name);
				currentlyVisited = new ToVisit(obj, num, "", num);
			}
			if (typeof(ScriptableObject).IsAssignableFrom(objType) || typeof(MonoBehaviour).IsAssignableFrom(objType))
			{
				VisitClassWithReflection(currentlyVisited, toVisit, toVisitSet, visited, mapping, objType, obj);
				return;
			}
			InsertIntoToVisitList(visited, currentlyVisited);
			if (mapping.ContainsValue(obj))
			{
				Logging.Error(obj as UnityEngine.Object, LogChannels.Save, "Mapping already contains object {0}. Already has ID {1}, trying to add with ID {2}. Path: {3}", obj, mapping.SecondToFirst[obj], currentlyVisited.ID, currentlyVisited.MemberPath);
			}
			else if (mapping.ContainsKey(currentlyVisited.ID))
			{
				Logging.Error(obj as UnityEngine.Object, LogChannels.Save, "Mapping already contains entry for ID: {0}. This: {1}. Other: {2}. New asset path {3}", currentlyVisited.ID, obj, mapping[currentlyVisited.ID], currentlyVisited.MemberPath);
			}
			else
			{
				try
				{
					mapping.Add(currentlyVisited.ID, obj);
				}
				catch (Exception ex)
				{
					Logging.Error(obj as UnityEngine.Object, LogChannels.Save, ex.Message);
				}
			}
			if (typeof(GameObject).IsAssignableFrom(objType))
			{
				Animator[] componentsInChildren = ((GameObject)obj).GetComponentsInChildren<Animator>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Animator animator = componentsInChildren[i];
					if (animator.runtimeAnimatorController != null)
					{
						EnqueueIfNew(animator.runtimeAnimatorController, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + "controllers" + i, toVisit, toVisitSet, visited);
					}
				}
			}
			if (typeof(RuntimeAnimatorController).IsAssignableFrom(objType))
			{
				RuntimeAnimatorController runtimeAnimatorController = (RuntimeAnimatorController)obj;
				for (int j = 0; j < runtimeAnimatorController.animationClips.Length; j++)
				{
					EnqueueIfNew(runtimeAnimatorController.animationClips[j], currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + "anims" + j, toVisit, toVisitSet, visited);
				}
			}
			if (!typeof(AnimationClip).IsAssignableFrom(objType))
			{
				return;
			}
			AnimationClip animationClip = (AnimationClip)obj;
			for (int k = 0; k < animationClip.events.Length; k++)
			{
				if (animationClip.events[k].objectReferenceParameter != null)
				{
					EnqueueIfNew(animationClip.events[k].objectReferenceParameter, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + "events" + k, toVisit, toVisitSet, visited);
				}
			}
		}

		private static bool IsTypeThatShouldUseAssetNameAsHash(Type objType)
		{
			if (!typeof(GameObject).IsAssignableFrom(objType) && !typeof(AudioClip).IsAssignableFrom(objType) && !typeof(Sprite).IsAssignableFrom(objType) && !typeof(Material).IsAssignableFrom(objType) && !typeof(Texture).IsAssignableFrom(objType) && !typeof(AnimationClip).IsAssignableFrom(objType) && !typeof(AnimatorOverrideController).IsAssignableFrom(objType) && !typeof(RuntimeAnimatorController).IsAssignableFrom(objType) && !typeof(VideoClip).IsAssignableFrom(objType) && !typeof(ExternalBehaviorTree).IsAssignableFrom(objType) && !typeof(AudioMixer).IsAssignableFrom(objType) && !typeof(AudioMixerGroup).IsAssignableFrom(objType) && !typeof(Avatar).IsAssignableFrom(objType) && !typeof(ParticleSystem).IsAssignableFrom(objType))
			{
				return typeof(TextAsset).IsAssignableFrom(objType);
			}
			return true;
		}

		private static string PrefixForAssetNameOfType(Type objType)
		{
			if (!typeof(GameObject).IsAssignableFrom(objType))
			{
				if (!typeof(AudioClip).IsAssignableFrom(objType))
				{
					if (!typeof(Sprite).IsAssignableFrom(objType))
					{
						if (!typeof(Material).IsAssignableFrom(objType))
						{
							if (!typeof(Texture).IsAssignableFrom(objType))
							{
								if (!typeof(AnimationClip).IsAssignableFrom(objType))
								{
									if (!typeof(AnimatorOverrideController).IsAssignableFrom(objType))
									{
										if (!typeof(RuntimeAnimatorController).IsAssignableFrom(objType))
										{
											if (!typeof(VideoClip).IsAssignableFrom(objType))
											{
												if (!typeof(ExternalBehaviorTree).IsAssignableFrom(objType))
												{
													if (!typeof(AudioMixer).IsAssignableFrom(objType))
													{
														if (!typeof(AudioMixerGroup).IsAssignableFrom(objType))
														{
															if (!typeof(Avatar).IsAssignableFrom(objType))
															{
																if (!typeof(ParticleSystem).IsAssignableFrom(objType))
																{
																	if (!typeof(TextAsset).IsAssignableFrom(objType))
																	{
																		return "";
																	}
																	return "e/";
																}
																return "p/";
															}
															return "z/";
														}
														return "r/";
													}
													return "x/";
												}
												return "b/";
											}
											return "v/";
										}
										return "c/";
									}
									return "o/";
								}
								return "n/";
							}
							return "t/";
						}
						return "m/";
					}
					return "s/";
				}
				return "a/";
			}
			return "g/";
		}

		private static void VisitClassWithReflection(ToVisit currentlyVisited, Queue<ToVisit> toVisit, List<ToVisit> toVisitSet, List<ToVisit> visited, BiDictionary<int, object> mapping, Type objType, object obj)
		{
			InsertIntoToVisitList(visited, currentlyVisited);
			if (mapping.ContainsValue(obj))
			{
				Logging.Error(obj as UnityEngine.Object, LogChannels.Save, "Mapping already contains object {0}. Already has ID {1}, trying to add with ID {2}. Path: {3}", obj, mapping.SecondToFirst[obj], currentlyVisited.ID, currentlyVisited.MemberPath);
			}
			else if (mapping.ContainsKey(currentlyVisited.ID))
			{
				Logging.Error(obj as UnityEngine.Object, LogChannels.Save, "Mapping already contains entry for ID: {0}. This: {1}. Other: {2}. New asset path {3}", currentlyVisited.ID, obj, mapping[currentlyVisited.ID], currentlyVisited.MemberPath);
			}
			else
			{
				try
				{
					mapping.Add(currentlyVisited.ID, obj);
				}
				catch (Exception ex)
				{
					Logging.Error(obj as UnityEngine.Object, LogChannels.Save, ex.Message);
				}
			}
			VisitClassInternals(currentlyVisited, toVisit, toVisitSet, visited, objType, obj);
		}

		private static void VisitClassInternals(ToVisit currentlyVisited, Queue<ToVisit> toVisit, List<ToVisit> toVisitSet, List<ToVisit> visited, Type objType, object obj)
		{
			if (GetCachedTypeInfo(objType).InternalsAreIgnoredForAssetIDs)
			{
				return;
			}
			fsMetaProperty[] properties = fsMetaType.Get(FullSerializerSerializer.SerializerInstance.Config, obj.GetType()).Properties;
			foreach (fsMetaProperty fsMetaProperty2 in properties)
			{
				if (!fsMetaProperty2.CanRead)
				{
					continue;
				}
				Type storageType = fsMetaProperty2.StorageType;
				object obj2 = fsMetaProperty2.Read(obj);
				if (obj2 == null)
				{
					continue;
				}
				if (storageType.IsArray)
				{
					if (storageType.GetArrayRank() == 1 && IsClassOrStructOrInterfaceWeWantToVisit(storageType.GetElementType()))
					{
						Array array = (Array)obj2;
						for (int j = 0; j < array.Length; j++)
						{
							EnqueueIfNew(array.GetValue(j), currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + fsMetaProperty2.JsonName + j, toVisit, toVisitSet, visited);
						}
					}
				}
				else if (typeof(IList).IsAssignableFrom(storageType))
				{
					Type[] genericArguments = storageType.GetGenericArguments();
					if (!storageType.IsGenericType || !IsClassOrStructOrInterfaceWeWantToVisit(genericArguments[0]))
					{
						continue;
					}
					int num = 0;
					foreach (object item in (IList)obj2)
					{
						EnqueueIfNew(item, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + fsMetaProperty2.JsonName + num, toVisit, toVisitSet, visited);
						num++;
					}
				}
				else if (typeof(IDictionary).IsAssignableFrom(storageType))
				{
					IDictionary dictionary = (IDictionary)obj2;
					Type[] genericArguments2 = storageType.GetGenericArguments();
					if (storageType.IsGenericType && IsClassOrStructOrInterfaceWeWantToVisit(genericArguments2[0]))
					{
						int num2 = 0;
						foreach (object key in dictionary.Keys)
						{
							EnqueueIfNew(key, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + fsMetaProperty2.JsonName + "K" + num2, toVisit, toVisitSet, visited);
							num2++;
						}
					}
					if (!storageType.IsGenericType || !IsClassOrStructOrInterfaceWeWantToVisit(genericArguments2[1]))
					{
						continue;
					}
					int num3 = 0;
					foreach (object value3 in dictionary.Values)
					{
						EnqueueIfNew(value3, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + fsMetaProperty2.JsonName + "V" + num3, toVisit, toVisitSet, visited);
						num3++;
					}
				}
				else if (objType.IsGenericType && objType.GetGenericTypeDefinition() == typeof(KeyValuePair<, >))
				{
					object value = objType.GetProperty("Key").GetValue(obj, null);
					object value2 = objType.GetProperty("Value").GetValue(obj, null);
					if (IsClassOrStructOrInterfaceWeWantToVisit(value.GetType()))
					{
						EnqueueIfNew(value, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + fsMetaProperty2.JsonName + "K_", toVisit, toVisitSet, visited);
					}
					if (IsClassOrStructOrInterfaceWeWantToVisit(value2.GetType()))
					{
						EnqueueIfNew(value2, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + fsMetaProperty2.JsonName + "V_", toVisit, toVisitSet, visited);
					}
				}
				else if (IsClassOrStructOrInterfaceWeWantToVisit(storageType))
				{
					EnqueueIfNew(obj2, currentlyVisited.OwningAssetID, currentlyVisited.MemberPath + fsMetaProperty2.JsonName, toVisit, toVisitSet, visited);
				}
			}
		}

		private static void InsertIntoToVisitList(List<ToVisit> list, ToVisit currentlyVisited)
		{
			int num = list.BinarySearch(currentlyVisited, ToVisitObjectHashComparer.Instance);
			if (num < 0)
			{
				num = ~num;
			}
			list.Insert(num, currentlyVisited);
		}

		private static int GenerateObjectID(object obj, int owningAssetID, string memberPath)
		{
			if (memberPath == null)
			{
				return 0;
			}
			int byteCount = Encoding.ASCII.GetByteCount(memberPath);
			if (byteCount + 4 > _byteBuffer.Length)
			{
				_byteBuffer = new byte[byteCount * 2 + 4];
			}
			_byteBuffer[0] = (byte)(owningAssetID >> 24);
			_byteBuffer[1] = (byte)(owningAssetID >> 16);
			_byteBuffer[2] = (byte)(owningAssetID >> 8);
			_byteBuffer[3] = (byte)owningAssetID;
			Encoding.ASCII.GetBytes(memberPath, 0, memberPath.Length, _byteBuffer, 4);
			return -Math.Abs((int)xxHash.CalculateHash(_byteBuffer, byteCount + 4));
		}

		private static int GenerateHashFromString(string str)
		{
			int byteCount = Encoding.ASCII.GetByteCount(str);
			if (byteCount > _byteBuffer.Length)
			{
				_byteBuffer = new byte[byteCount * 2];
			}
			Encoding.ASCII.GetBytes(str, 0, str.Length, _byteBuffer, 0);
			return -Math.Abs((int)xxHash.CalculateHash(_byteBuffer, byteCount));
		}

		private static CachedTypeInfo GetCachedTypeInfo(Type type)
		{
			if (!TypeInfoCache.TryGetValue(type, out var value))
			{
				value = new CachedTypeInfo
				{
					IsInterface = type.IsInterface,
					IsClass = type.IsClass,
					IsValueType = type.IsValueType,
					IsPrimitive = type.IsPrimitive,
					IsEnum = type.IsEnum,
					IsIgnoredForAssetIDs = type.IsDefined(typeof(DontSaveAssetReferenceAttribute), inherit: true),
					InternalsAreIgnoredForAssetIDs = type.IsDefined(typeof(DontVisitInternalsForAssetReferenceAttribute), inherit: true)
				};
				TypeInfoCache.Add(type, value);
			}
			return value;
		}

		private static bool IsClassOrStructOrInterface(Type type)
		{
			CachedTypeInfo cachedTypeInfo = GetCachedTypeInfo(type);
			if (!cachedTypeInfo.IsInterface && (!cachedTypeInfo.IsClass || !(type != typeof(string))))
			{
				if (cachedTypeInfo.IsValueType && !cachedTypeInfo.IsPrimitive && !cachedTypeInfo.IsEnum && type != typeof(Vector3))
				{
					return type != typeof(Vector2);
				}
				return false;
			}
			return true;
		}

		private static bool IsClassOrStructOrInterfaceWeWantToVisit(Type type)
		{
			CachedTypeInfo cachedTypeInfo = GetCachedTypeInfo(type);
			if (cachedTypeInfo.IsInterface || (cachedTypeInfo.IsClass && type != typeof(string) && type != typeof(AnimationCurve) && type != typeof(Gradient)) || (cachedTypeInfo.IsValueType && !cachedTypeInfo.IsPrimitive && !cachedTypeInfo.IsEnum && type != typeof(Bounds) && type != typeof(BoundsInt) && type != typeof(Color) && type != typeof(LayerMask) && type != typeof(Keyframe) && type != typeof(Rect) && type != typeof(Vector4) && type != typeof(Vector3) && type != typeof(Vector2) && type != typeof(Vector2Int) && type != typeof(Guid) && type != typeof(TimeSpan)))
			{
				return !cachedTypeInfo.IsIgnoredForAssetIDs;
			}
			return false;
		}

		private static bool HashSetContains(List<ToVisit> visited, object obj)
		{
			return BinarySearchToVisitListForObject(visited, obj) >= 0;
		}

		private static int BinarySearchToVisitListForObject(List<ToVisit> list, object obj)
		{
			int hashCode = obj.GetHashCode();
			int num = 0;
			int num2 = list.Count - 1;
			while (num <= num2)
			{
				int num3 = num + (num2 - num >> 1);
				int num4 = list[num3].ObjHashCodeCache.CompareTo(hashCode);
				if (num4 == 0)
				{
					if (list[num3].Obj.Equals(obj))
					{
						return num3;
					}
					for (int i = num3 + 1; i < list.Count && list[i].ObjHashCodeCache == hashCode; i++)
					{
						if (list[i].Obj.Equals(obj))
						{
							return i;
						}
					}
					int num5 = num3 - 1;
					while (num5 >= 0 && list[num5].ObjHashCodeCache == hashCode)
					{
						if (list[num5].Obj.Equals(obj))
						{
							return num5;
						}
						num5--;
					}
					return ~num3;
				}
				if (num4 < 0)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
			}
			return ~num;
		}

		private static bool QueueContains(Queue<ToVisit> toVisit, object obj)
		{
			bool result = false;
			foreach (ToVisit item in toVisit)
			{
				if (item.Obj.Equals(obj))
				{
					result = true;
					break;
				}
			}
			return result;
		}

		private static void EnqueueIfNew(object obj, int owningAssetID, string memberPath, Queue<ToVisit> toVisit, List<ToVisit> toVisitSet, List<ToVisit> visited)
		{
			if (obj != null && !HashSetContains(visited, obj) && !HashSetContains(toVisitSet, obj) && (!(obj is UnityEngine.Object) || !((UnityEngine.Object)obj == null)))
			{
				ToVisit toVisit2 = new ToVisit(obj, owningAssetID, memberPath);
				toVisit.Enqueue(toVisit2);
				InsertIntoToVisitList(toVisitSet, toVisit2);
			}
		}
	}
}
