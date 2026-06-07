using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Scenes.Events;
using Assets.Scripts.Storage;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	public class CraftDecalManager : MonoBehaviour
	{
		private static class Profile
		{
			public const string Prefix = "CraftDecalManager";

			public static readonly ProfilerMarker LoadDecalData = new ProfilerMarker("CraftDecalManager.LoadDecalData");

			public static readonly ProfilerMarker LoadDecalTexture = new ProfilerMarker("CraftDecalManager.LoadDecalTexture");

			public static readonly ProfilerMarker ReleaseDecalProjector = new ProfilerMarker("CraftDecalManager.ReleaseDecalProjector");

			public static readonly ProfilerMarker ReleaseDecalText = new ProfilerMarker("CraftDecalManager.ReleaseDecalText");

			public static readonly ProfilerMarker RequestDecalProjector = new ProfilerMarker("CraftDecalManager.RequestDecalProjector");

			public static readonly ProfilerMarker RequestDecalText = new ProfilerMarker("CraftDecalManager.RequestDecalText");
		}

		public const string GlobalDecalProfilingPrefix = "";

		private static int _totalDecalProjectorCount;

		private static int _totalDecalTextCount;

		private bool _applicationIsClosing;

		private Stack<uint> _availableDecalTargetIds;

		private Dictionary<string, CraftDecalData> _decals;

		private uint _decalTargetMaxId;

		private Dictionary<string, Texture2D> _decalTextures;

		private Stack<PartMeshDecalProjector> _pooledDecalProjectors;

		private Transform _pooledDecalProjectorsParentObject;

		private Stack<PartMeshDecalText> _pooledDecalTexts;

		private Transform _pooledDecalTextsParentObject;

		public IReadOnlyCollection<CraftDecalData> CraftDecals => _decals.Values;

		public static void CopyCraftDecalsExampleXml()
		{
			FileInfo fileInfo = new FileInfo(GameData.GetPath("CraftDecals/CraftDecals.xml"));
			if (!fileInfo.Exists)
			{
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				string contents = Game.Instance.ResourceLoader.LoadText("Craft/CraftDecals/CraftDecalsAppData");
				File.WriteAllText(fileInfo.FullName, contents);
			}
		}

		public static CraftDecalManager Create(GameObject parent)
		{
			CraftDecalManager craftDecalManager = new GameObject("CraftDecalManager").AddComponent<CraftDecalManager>();
			craftDecalManager.transform.SetParent(parent.transform);
			craftDecalManager.Initialize();
			return craftDecalManager;
		}

		public CraftDecalData GetDecalData(string decalId)
		{
			if (!_decals.TryGetValue(decalId ?? string.Empty, out var value))
			{
				return null;
			}
			return value;
		}

		public Texture2D GetDecalTexture(string decalId)
		{
			if (!_decalTextures.TryGetValue(decalId ?? string.Empty, out var value))
			{
				return null;
			}
			return value;
		}

		public void ReleaseDecalProjector(PartMeshDecalProjector partMeshDecalProjector)
		{
			using (Profile.ReleaseDecalProjector.Auto())
			{
				if (!_applicationIsClosing)
				{
					partMeshDecalProjector.ResetPooledObject();
					partMeshDecalProjector.Transform.SetParent(_pooledDecalProjectorsParentObject, worldPositionStays: false);
					partMeshDecalProjector.Transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
					partMeshDecalProjector.GameObject.SetActive(value: false);
					_pooledDecalProjectors.Push(partMeshDecalProjector);
				}
			}
		}

		public void ReleaseDecalTargetID(uint decalTargetId)
		{
			_availableDecalTargetIds.Push(decalTargetId);
		}

		public void ReleaseDecalText(PartMeshDecalText partMeshDecalText)
		{
			using (Profile.ReleaseDecalText.Auto())
			{
				if (!_applicationIsClosing)
				{
					partMeshDecalText.ResetPooledObject();
					partMeshDecalText.Transform.SetParent(_pooledDecalTextsParentObject, worldPositionStays: false);
					partMeshDecalText.Transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
					partMeshDecalText.GameObject.SetActive(value: false);
					_pooledDecalTexts.Push(partMeshDecalText);
				}
			}
		}

		public PartMeshDecalProjector RequestDecalProjector(ICraftTextureDecal decal, DecalTargetScript target)
		{
			using (Profile.RequestDecalProjector.Auto())
			{
				if (_pooledDecalProjectors.Count == 0)
				{
					for (int i = 0; i < 10; i++)
					{
						PartMeshDecalProjector partMeshDecalProjector = PartMeshDecalProjector.Create();
						ReleaseDecalProjector(partMeshDecalProjector);
						partMeshDecalProjector.gameObject.name = $"PartMeshDecalProjector_{_totalDecalProjectorCount++}";
					}
				}
				PartMeshDecalProjector partMeshDecalProjector2 = _pooledDecalProjectors.Pop();
				if (partMeshDecalProjector2 == null || partMeshDecalProjector2.GameObject == null)
				{
					Debug.LogError("An invalid PartMeshDecalProjector was retrieved from the pool");
					return RequestDecalProjector(decal, target);
				}
				partMeshDecalProjector2.InitializePooledObject(decal, target);
				return partMeshDecalProjector2;
			}
		}

		public uint RequestDecalTargetID()
		{
			if (_availableDecalTargetIds.Count > 0)
			{
				return _availableDecalTargetIds.Pop();
			}
			return _decalTargetMaxId++;
		}

		public PartMeshDecalText RequestDecalText(ICraftTextDecal decal, DecalTargetScript target)
		{
			using (Profile.RequestDecalText.Auto())
			{
				if (_pooledDecalTexts.Count == 0)
				{
					for (int i = 0; i < 10; i++)
					{
						PartMeshDecalText partMeshDecalText = PartMeshDecalText.Create();
						ReleaseDecalText(partMeshDecalText);
						partMeshDecalText.gameObject.name = $"PartMeshDecalText_{_totalDecalTextCount++}";
					}
				}
				PartMeshDecalText partMeshDecalText2 = _pooledDecalTexts.Pop();
				if (partMeshDecalText2 == null || partMeshDecalText2.GameObject == null)
				{
					Debug.LogError("An invalid PartMeshDecalText was retrieved from the pool");
					return RequestDecalText(decal, target);
				}
				partMeshDecalText2.InitializePooledObject(decal, target);
				return partMeshDecalText2;
			}
		}

		protected virtual void OnApplicationQuit()
		{
			_applicationIsClosing = true;
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.SceneManager.SceneLoading -= OnSceneLoading;
		}

		protected virtual void Start()
		{
			Game.Instance.SceneManager.SceneLoading += OnSceneLoading;
		}

		private static Texture2D LoadDecalTexture(CraftDecalLocationType locationType, string path)
		{
			using (Profile.LoadDecalTexture.Auto())
			{
				switch (locationType)
				{
				case CraftDecalLocationType.Resource:
					return Game.Instance.ResourceLoader.LoadTexture(path);
				case CraftDecalLocationType.LocalFileSystem:
				{
					Texture2D texture2D = GameData.LoadTexture(GameData.GetPath(path));
					if (texture2D != null)
					{
						texture2D.Compress(highQuality: false);
					}
					return texture2D;
				}
				default:
					throw new NotSupportedException($"Craft decal texture location type of '{locationType}' is not currently supported");
				}
			}
		}

		private void Initialize()
		{
			_pooledDecalProjectors = new Stack<PartMeshDecalProjector>();
			_pooledDecalTexts = new Stack<PartMeshDecalText>();
			_availableDecalTargetIds = new Stack<uint>();
			_decals = new Dictionary<string, CraftDecalData>();
			_decalTextures = new Dictionary<string, Texture2D>();
			_decalTargetMaxId = 1u;
			_pooledDecalProjectorsParentObject = new GameObject("PooledDecalProjectors").transform;
			_pooledDecalProjectorsParentObject.SetParent(base.transform, worldPositionStays: false);
			_pooledDecalProjectorsParentObject.gameObject.SetActive(value: false);
			_pooledDecalTextsParentObject = new GameObject("PooledDecalTexts").transform;
			_pooledDecalTextsParentObject.SetParent(base.transform, worldPositionStays: false);
			_pooledDecalTextsParentObject.gameObject.SetActive(value: false);
			LoadDecalData();
			LoadDecalTextures();
		}

		private void LoadDecalData()
		{
			_decals.Add(CraftDecalData.Default.Id, CraftDecalData.Default);
			XDocument xDocument = Game.Instance.ResourceLoader.LoadXml("Craft/CraftDecals/CraftDecals");
			LoadDecalData(xDocument.Root, "Craft/CraftDecals/Textures/", CraftDecalLocationType.Resource);
			string path = GameData.GetPath("CraftDecals/CraftDecals.xml");
			try
			{
				xDocument = GameData.LoadXml(path, throwFileNotFoundException: false);
				if (xDocument != null)
				{
					LoadDecalData(xDocument.Root, "CraftDecals/", CraftDecalLocationType.LocalFileSystem);
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to load CraftDecals.xml from '" + path + "'.");
				Debug.LogException(exception);
			}
		}

		private void LoadDecalData(XElement xml, string rootPath, CraftDecalLocationType locationType)
		{
			using (Profile.LoadDecalData.Auto())
			{
				CraftDecalData craftDecalData = null;
				foreach (XElement item in xml.Elements("CraftDecal"))
				{
					try
					{
						craftDecalData = new CraftDecalData(item, rootPath, locationType);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					if (craftDecalData == null)
					{
						Debug.LogError($"Unable to load craft decal data from XML: {item}");
					}
					else if (string.IsNullOrEmpty(craftDecalData.Id))
					{
						Debug.LogError($"Craft decal data does not have a valid ID: {item}");
					}
					else if (_decals.ContainsKey(craftDecalData.Id))
					{
						Debug.LogError("Encountered duplicate craft decal with id '" + craftDecalData.Id + "'.");
					}
					else
					{
						_decals.Add(craftDecalData.Id, craftDecalData);
					}
				}
			}
		}

		private void LoadDecalTextures()
		{
			foreach (CraftDecalData value in _decals.Values)
			{
				try
				{
					Texture2D texture2D = LoadDecalTexture(value.LocationType, value.LocationPath);
					if (texture2D == null)
					{
						Debug.LogError($"Failed to load craft decal texture: {value}");
						continue;
					}
					texture2D.name = value.DisplayName;
					_decalTextures.Add(value.Id, texture2D);
				}
				catch (Exception exception)
				{
					Debug.LogError($"Failed to load craft decal texture: {value}");
					Debug.LogException(exception);
				}
			}
		}

		private void OnSceneLoading(object sender, SceneEventArgs e)
		{
			_availableDecalTargetIds.Clear();
			_decalTargetMaxId = 1u;
		}
	}
}
