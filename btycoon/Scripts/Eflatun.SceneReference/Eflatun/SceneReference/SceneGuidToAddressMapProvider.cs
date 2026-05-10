using System.Collections.Generic;
using System.Linq;
using Eflatun.SceneReference.Exceptions;
using Eflatun.SceneReference.Utility;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;

namespace Eflatun.SceneReference
{
	[PublicAPI]
	public static class SceneGuidToAddressMapProvider
	{
		private static Dictionary<string, string> _sceneGuidToAddressMap;

		public static IReadOnlyDictionary<string, string> SceneGuidToAddressMap
		{
			get
			{
				LoadIfNotAlready();
				return _sceneGuidToAddressMap;
			}
		}

		public static string GetGuidFromAddress(string address)
		{
			LoadIfNotAlready();
			KeyValuePair<string, string>[] array = _sceneGuidToAddressMap.Where((KeyValuePair<string, string> x) => x.Value == address).ToArray();
			if (array.Length < 1)
			{
				throw new AddressNotFoundException(address);
			}
			if (array.Length > 1)
			{
				throw new AddressNotUniqueException(address);
			}
			return array.First().Key;
		}

		[ContractAnnotation("=> true, guid:notnull; => false, guid:null")]
		public static bool TryGetGuidFromAddress(string address, out string guid)
		{
			try
			{
				guid = GetGuidFromAddress(address);
				return true;
			}
			catch
			{
				guid = null;
				return false;
			}
		}

		internal static void FillWith(Dictionary<string, string> sceneGuidToAddressMap)
		{
			_sceneGuidToAddressMap = sceneGuidToAddressMap;
		}

		[Preserve]
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void LoadIfNotAlready()
		{
			if (_sceneGuidToAddressMap == null)
			{
				string value = _LoadJson();
				if (string.IsNullOrWhiteSpace(value))
				{
					Logger.Error("Scene GUID to address map not found!");
					FillWith(new Dictionary<string, string>());
				}
				else
				{
					FillWith(JsonConvert.DeserializeObject<Dictionary<string, string>>(value));
				}
			}
			static string _LoadJson()
			{
				TextAsset textAsset = Resources.Load<TextAsset>(Paths.RelativeToResources.SceneGuidToAddressMapFile.WithoutExtension());
				if (!(textAsset == null))
				{
					return textAsset.text;
				}
				return null;
			}
		}
	}
}
