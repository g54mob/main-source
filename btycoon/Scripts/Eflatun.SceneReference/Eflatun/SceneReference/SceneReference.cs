using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eflatun.SceneReference.Exceptions;
using Eflatun.SceneReference.Utility;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Eflatun.SceneReference
{
	[Serializable]
	[PublicAPI]
	[XmlRoot("Eflatun.SceneReference.SceneReference")]
	public class SceneReference : ISerializationCallbackReceiver, ISerializable, IXmlSerializable
	{
		internal const string XmlRootElementName = "Eflatun.SceneReference.SceneReference";

		internal const string CustomSerializationGuidKey = "sceneAssetGuidHex";

		[FormerlySerializedAs("sceneAsset")]
		[SerializeField]
		internal UnityEngine.Object asset;

		[FormerlySerializedAs("sceneAssetGuidHex")]
		[SerializeField]
		internal string guid;

		private bool HasValue
		{
			get
			{
				if (!Guid.IsValidGuid())
				{
					throw SceneReferenceInternalException.InvalidGuid("54783205", Guid);
				}
				return Guid != "00000000000000000000000000000000";
			}
		}

		public string Guid => guid.GuardGuidAgainstNullOrWhitespace();

		public string Path
		{
			get
			{
				if (!HasValue)
				{
					throw new EmptySceneReferenceException();
				}
				if (!SceneGuidToPathMapProvider.SceneGuidToPathMap.TryGetValue(Guid, out var value))
				{
					throw new InvalidSceneReferenceException();
				}
				return value;
			}
		}

		public int BuildIndex => SceneUtility.GetBuildIndexByScenePath(Path);

		public string Name => System.IO.Path.GetFileNameWithoutExtension(Path);

		public Scene LoadedScene => SceneManager.GetSceneByPath(Path);

		public string Address
		{
			get
			{
				if (!HasValue)
				{
					throw new EmptySceneReferenceException();
				}
				if (!SceneGuidToPathMapProvider.SceneGuidToPathMap.ContainsKey(Guid))
				{
					throw new InvalidSceneReferenceException();
				}
				if (!SceneGuidToAddressMapProvider.SceneGuidToAddressMap.TryGetValue(Guid, out var value))
				{
					throw new SceneNotAddressableException();
				}
				return value;
			}
		}

		public SceneReferenceState State
		{
			get
			{
				if (HasValue)
				{
					if (SceneGuidToPathMapProvider.SceneGuidToPathMap.TryGetValue(Guid, out var value) && SceneUtility.GetBuildIndexByScenePath(value) != -1)
					{
						return SceneReferenceState.Regular;
					}
					if (SceneGuidToAddressMapProvider.SceneGuidToAddressMap.ContainsKey(Guid))
					{
						return SceneReferenceState.Addressable;
					}
				}
				return SceneReferenceState.Unsafe;
			}
		}

		public SceneReferenceUnsafeReason UnsafeReason
		{
			get
			{
				if (!HasValue)
				{
					return SceneReferenceUnsafeReason.Empty;
				}
				if (SceneGuidToAddressMapProvider.SceneGuidToAddressMap.TryGetValue(Guid, out var _))
				{
					return SceneReferenceUnsafeReason.None;
				}
				if (!SceneGuidToPathMapProvider.SceneGuidToPathMap.TryGetValue(Guid, out var value2))
				{
					return SceneReferenceUnsafeReason.NotInMaps;
				}
				if (SceneUtility.GetBuildIndexByScenePath(value2) == -1)
				{
					return SceneReferenceUnsafeReason.NotInBuild;
				}
				return SceneReferenceUnsafeReason.None;
			}
		}

		public SceneReference()
		{
			guid = "00000000000000000000000000000000";
			asset = null;
		}

		public SceneReference(string guid)
		{
			if (string.IsNullOrWhiteSpace(guid))
			{
				throw new SceneReferenceCreationException("Given GUID is null or whitespace. GUID: '" + guid + "'.\nTo fix this, make sure you provide the GUID of a valid scene.");
			}
			if (!SceneGuidToPathMapProvider.SceneGuidToPathMap.TryGetValue(guid, out var _))
			{
				throw new SceneReferenceCreationException("Given GUID is not found in the scene GUID to path map. GUID: '" + guid + "'\nThis can happen for these reasons:\n1. The asset with the given GUID either doesn't exist or is not a scene. To fix this, make sure you provide the GUID of a valid scene.\n2. The scene GUID to path map is outdated. To fix this, you can either manually run the generator, or enable generation triggers. It is highly recommended to keep all the generation triggers enabled.");
			}
			this.guid = guid;
		}

		protected SceneReference(SerializationInfo info, StreamingContext context)
		{
			string deserializedGuid = info.GetString("sceneAssetGuidHex");
			FillWithDeserializedGuid(deserializedGuid);
		}

		public static SceneReference FromScenePath(string path)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				throw new SceneReferenceCreationException("Given path is null or whitespace. Path: '" + path + "'\nTo fix this, make sure you provide the path of a valid scene.");
			}
			if (!SceneGuidToPathMapProvider.ScenePathToGuidMap.TryGetValue(path, out var value))
			{
				throw new SceneReferenceCreationException("Given path is not found in the scene GUID to path map. Path: '" + path + "'\nThis can happen for these reasons:\n1. The asset at the given path either doesn't exist or is not a scene. To fix this, make sure you provide the path of a valid scene.\n2. The scene GUID to path map is outdated. To fix this, you can either manually run the generator, or enable generation triggers. It is highly recommended to keep all the generation triggers enabled.");
			}
			return new SceneReference(value);
		}

		public static SceneReference FromAddress(string address)
		{
			if (string.IsNullOrWhiteSpace(address))
			{
				throw new SceneReferenceCreationException("Given address is null or whitespace. Path: '" + address + "'\nTo fix this, make sure you provide the address of a valid addressable scene.");
			}
			try
			{
				return new SceneReference(SceneGuidToAddressMapProvider.GetGuidFromAddress(address));
			}
			catch (AddressNotFoundException inner)
			{
				throw new SceneReferenceCreationException("Given address is not found in the Scene GUID to Address Map. Address: " + address + ".\nThis can happen for these reasons:\n1. The asset with the given address either doesn't exist or is not a scene. To fix this, make sure you provide the address of a valid addressable scene.\n2. The Scene GUID to Address Map is outdated. To fix this, you can either manually run the generator, or enable generation triggers. It is highly recommended to keep all the generation triggers enabled.", inner);
			}
			catch (AddressNotUniqueException inner2)
			{
				throw new SceneReferenceCreationException("Given address matches multiple scenes in the Scene GUID to Address Map. Address: " + address + ".\nThrown if a given address matches multiple entries in the Scene GUID to Address Map. This can happen for these reasons:\n1. There are multiple addressable scenes with the same given address. To fix this, make sure there is only one addressable scene with the given address.\n2. The Scene GUID to Address Map is outdated. To fix this, you can either manually run the generator, or enable generation triggers. It is highly recommended to keep all the generation triggers enabled.", inner2);
			}
			catch (AddressablesSupportDisabledException exception)
			{
				throw SceneReferenceInternalException.ExceptionImpossible("48302749", exception);
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			GetObjectData(info, context);
		}

		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			string guidToSerialize = GetGuidToSerialize();
			info.AddValue("sceneAssetGuidHex", guidToSerialize);
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			OnBeforeSerialize();
		}

		protected virtual void OnBeforeSerialize()
		{
			guid = guid.GuardGuidAgainstNullOrWhitespace();
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			OnAfterDeserialize();
		}

		protected virtual void OnAfterDeserialize()
		{
			guid = guid.GuardGuidAgainstNullOrWhitespace();
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return GetSchema();
		}

		protected virtual XmlSchema GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			ReadXml(reader);
		}

		protected virtual void ReadXml(XmlReader reader)
		{
			string deserializedGuid = reader.ReadString();
			FillWithDeserializedGuid(deserializedGuid);
		}

		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			WriteXml(writer);
		}

		protected virtual void WriteXml(XmlWriter writer)
		{
			string guidToSerialize = GetGuidToSerialize();
			writer.WriteString(guidToSerialize);
		}

		private string GetGuidToSerialize()
		{
			return guid.GuardGuidAgainstNullOrWhitespace();
		}

		private void FillWithDeserializedGuid(string deserializedGuid)
		{
			deserializedGuid = deserializedGuid.GuardGuidAgainstNullOrWhitespace();
			guid = deserializedGuid;
		}
	}
}
