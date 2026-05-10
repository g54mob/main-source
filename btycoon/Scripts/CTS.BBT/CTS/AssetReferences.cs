using System;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Asset Save References")]
	public class AssetReferences : ScriptableObject
	{
		private static readonly string _resourcePath = "Assets/Resources/Asset References.asset";

		private static readonly string _resourceFolder = "/Resources/";

		private static System.Random _rng;

		private static readonly HideFlags[] _invalidHideFlags = new HideFlags[4]
		{
			HideFlags.DontSave,
			HideFlags.DontSaveInBuild,
			HideFlags.DontSaveInEditor,
			HideFlags.HideAndDontSave
		};

		[SerializeField]
		private SerializableDictionary<long, UnityEngine.Object> _objects = new SerializableDictionary<long, UnityEngine.Object>();

		private static Dictionary<long, UnityEngine.Object> _objectsCache = new Dictionary<long, UnityEngine.Object>();

		[field: SerializeField]
		public bool AllowRegistering { get; private set; }

		public static bool AllowRegister
		{
			get
			{
				return Instance.AllowRegistering;
			}
			set
			{
				Instance.AllowRegistering = value;
			}
		}

		private static AssetReferences Instance
		{
			get
			{
				if (!CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance))
				{
					return null;
				}
				return outInstance.AssetReferences;
			}
		}

		public static void Add(AssetReferences references)
		{
			foreach (var (key, value) in references._objects)
			{
				_objectsCache[key] = value;
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void RegisterAllResources()
		{
			bool allowRegistering = AllowRegistering;
			AllowRegistering = true;
			UnityEngine.Object[] array = Resources.LoadAll("");
			foreach (UnityEngine.Object obj in array)
			{
				GetOrCreateReferenceId_Instance(obj);
			}
			AllowRegistering = allowRegistering;
		}

		[Button(null, EButtonEnableMode.Always)]
		private void Optimize()
		{
			List<long> list = new List<long>();
			foreach (var (item, obj2) in _objects)
			{
				if (obj2 == null || obj2 == Instance || !CanBeSaved(obj2))
				{
					list.Add(item);
					_ = obj2 != null;
				}
			}
			foreach (long item2 in list)
			{
				_objects.Remove(item2);
			}
		}

		public static long GetOrCreateReferenceId(UnityEngine.Object obj)
		{
			return Instance.GetOrCreateReferenceId_Instance(obj);
		}

		public static bool TryGetOrCreateReferenceId(UnityEngine.Object obj, out long outId)
		{
			long orCreateReferenceId_Instance = Instance.GetOrCreateReferenceId_Instance(obj);
			if (orCreateReferenceId_Instance != 0L)
			{
				outId = orCreateReferenceId_Instance;
				return true;
			}
			outId = 0L;
			return false;
		}

		public long GetOrCreateReferenceId_Instance(UnityEngine.Object obj)
		{
			if ((object)obj == null)
			{
				Debug.LogException(new NullReferenceException("Couldn't get reference for item as it is null"));
				return 0L;
			}
			foreach (var (result, obj3) in _objectsCache)
			{
				if (obj3 == obj)
				{
					return result;
				}
			}
			long num2 = 0L;
			if (num2 == 0L)
			{
				if (AllowRegistering)
				{
					Debug.LogException(new Exception("Couldn't find a possible ID for an asset " + obj.name));
					return num2;
				}
				Debug.LogException(new Exception("Couldn't register a new asset " + obj.name + " since this is a build"));
			}
			return num2;
		}

		public static bool TryGetReference(long id, out UnityEngine.Object outObject)
		{
			UnityEngine.Object reference = GetReference(id);
			if ((bool)reference)
			{
				outObject = reference;
				return true;
			}
			outObject = null;
			return false;
		}

		public static bool TryGetReference<TObject>(long id, out TObject outObject) where TObject : UnityEngine.Object
		{
			TObject reference = GetReference<TObject>(id);
			if ((bool)reference)
			{
				outObject = reference;
				return true;
			}
			outObject = null;
			return false;
		}

		public static UnityEngine.Object GetReference(long id)
		{
			return Instance.GetReference_Instance(id);
		}

		private UnityEngine.Object GetReference_Instance(long id)
		{
			if (id == 0L)
			{
				Debug.LogException(new ArgumentException("Can't find an asset with id 0, is the object missing from the manager?"));
				return null;
			}
			if (!_objectsCache.TryGetValue(id, out var value))
			{
				Debug.LogException(new NullReferenceException($"Couldn't find asset reference with id {id}, was the object removed from the manager?"));
				return null;
			}
			return value;
		}

		public static TObject GetReference<TObject>(long id) where TObject : UnityEngine.Object
		{
			return Instance.GetReference_Instance<TObject>(id);
		}

		private TObject GetReference_Instance<TObject>(long id) where TObject : UnityEngine.Object
		{
			return GetReference_Instance(id) as TObject;
		}

		private static long GetNewRefID()
		{
			if (_rng == null)
			{
				_rng = new System.Random();
			}
			byte[] array = new byte[8];
			_rng.NextBytes(array);
			return Math.Abs(BitConverter.ToInt64(array, 0) % long.MaxValue);
		}

		public static bool CanBeSaved(UnityEngine.Object obj)
		{
			if (!(obj is GameObject gameObject))
			{
				if (obj is Mesh || obj is ScriptableObject || obj is AudioClip || obj is Shader || obj is Texture || obj is Sprite || obj is AudioMixer || obj is Material)
				{
					return true;
				}
				return false;
			}
			if ((object)gameObject.transform.root != null)
			{
				return gameObject.transform.root == gameObject.transform;
			}
			return true;
		}
	}
}
