using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ModApi
{
	public static class AssetDatabase
	{
		private static MethodInfo _methodFindAssets;

		private static MethodInfo _methodFindAssetsInFolders;

		private static MethodInfo _methodGetAssetPath;

		private static MethodInfo _methodGuidToAssetPath;

		private static MethodInfo _methodLoadAssetAtPath;

		private static Type _type;

		public static bool IsAvailable => Application.isEditor;

		public static Type Type
		{
			get
			{
				if (!IsAvailable)
				{
					throw new InvalidOperationException("The AssetDatabase cannot be accessed from outside the Unity Editor.");
				}
				if (_type == null)
				{
					Assembly assembly = (from x in AppDomain.CurrentDomain.GetAssemblies()
						where x.FullName.StartsWith("UnityEditor,")
						select x).FirstOrDefault();
					if (assembly == null)
					{
						throw new Exception("Could not find the UnityEditor assembly.");
					}
					_type = assembly.GetType("UnityEditor.AssetDatabase", throwOnError: true);
				}
				return _type;
			}
		}

		public static string[] FindAssetGuids(string filter, params string[] searchInFolders)
		{
			if (searchInFolders == null || searchInFolders.Length == 0)
			{
				if (_methodFindAssets == null)
				{
					_methodFindAssets = Type.GetMethod("FindAssets", new Type[1] { typeof(string) });
					if (_methodFindAssets == null)
					{
						throw new Exception("Could not find the 'FindAssets' method via reflection for the AssetDatabase.");
					}
				}
				return (string[])_methodFindAssets.Invoke(null, new object[1] { filter });
			}
			if (_methodFindAssetsInFolders == null)
			{
				_methodFindAssetsInFolders = Type.GetMethod("FindAssets", new Type[2]
				{
					typeof(string),
					typeof(string[])
				});
				if (_methodFindAssetsInFolders == null)
				{
					throw new Exception("Could not find the 'FindAssets' method via reflection for the AssetDatabase.");
				}
			}
			searchInFolders = (from x in searchInFolders
				where x != null
				select x.TrimEnd('/')).ToArray();
			return (string[])_methodFindAssetsInFolders.Invoke(null, new object[2] { filter, searchInFolders });
		}

		public static T[] FindAssets<T>(params string[] searchInFolders) where T : UnityEngine.Object
		{
			return (from x in FindAssetGuids("t:" + typeof(T).Name, searchInFolders)
				select GuidToAssetPath(x) into x
				select LoadAssetAtPath<T>(x)).ToArray();
		}

		public static UnityEngine.Object[] FindAssets(string filter, params string[] searchInFolders)
		{
			return (from x in FindAssetGuids(filter, searchInFolders)
				select GuidToAssetPath(x) into x
				select LoadAssetAtPath(x, typeof(UnityEngine.Object))).ToArray();
		}

		public static string GetAssetPath(UnityEngine.Object obj)
		{
			if (_methodGetAssetPath == null)
			{
				_methodGetAssetPath = Type.GetMethod("GetAssetPath", new Type[1] { typeof(UnityEngine.Object) });
				if (_methodGetAssetPath == null)
				{
					throw new Exception("Could not find the 'GetAssetPath' method via reflection for the AssetDatabase.");
				}
			}
			return (string)_methodGetAssetPath.Invoke(null, new object[1] { obj });
		}

		public static string GetAssetResourcesPath(UnityEngine.Object obj, bool removeExtension = true)
		{
			string text = GetAssetPath(obj) ?? string.Empty;
			int num = text.LastIndexOf('.');
			if (num > 0)
			{
				text = text.Remove(num);
			}
			if (!text.StartsWith("Assets/Resources/"))
			{
				return null;
			}
			return text.Substring("Assets/Resources/".Length);
		}

		public static string GuidToAssetPath(string guid)
		{
			if (_methodGuidToAssetPath == null)
			{
				_methodGuidToAssetPath = Type.GetMethod("GUIDToAssetPath", new Type[1] { typeof(string) });
				if (_methodGuidToAssetPath == null)
				{
					throw new Exception("Could not find the 'GUIDToAssetPath' method via reflection for the AssetDatabase.");
				}
			}
			return (string)_methodGuidToAssetPath.Invoke(null, new object[1] { guid });
		}

		public static T LoadAssetAtPath<T>(string path) where T : UnityEngine.Object
		{
			return (T)LoadAssetAtPath(path, typeof(T));
		}

		public static UnityEngine.Object LoadAssetAtPath(string path, Type type)
		{
			if (_methodLoadAssetAtPath == null)
			{
				_methodLoadAssetAtPath = Type.GetMethod("LoadAssetAtPath", new Type[2]
				{
					typeof(string),
					typeof(Type)
				});
				if (_methodLoadAssetAtPath == null)
				{
					throw new Exception("Could not find the 'LoadAssetAtPath' method via reflection for the AssetDatabase.");
				}
			}
			return (UnityEngine.Object)_methodLoadAssetAtPath.Invoke(null, new object[2] { path, type });
		}
	}
}
