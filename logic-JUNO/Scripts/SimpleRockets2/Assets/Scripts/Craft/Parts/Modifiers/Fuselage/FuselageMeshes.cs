using System;
using System.Collections.Generic;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class FuselageMeshes
	{
		private Dictionary<string, Mesh> _colliderMeshes = new Dictionary<string, Mesh>();

		private Dictionary<string, MeshDefinitionScript> _prefabs = new Dictionary<string, MeshDefinitionScript>();

		public FuselageMeshes(IResourceLoader resourceLoader)
		{
			MeshDefinitionScript[] array = resourceLoader.LoadAll<MeshDefinitionScript>("Craft/Parts/Prefabs/Fuselage");
			foreach (MeshDefinitionScript meshDefinitionScript in array)
			{
				meshDefinitionScript.Id = meshDefinitionScript.gameObject.name;
				_prefabs[meshDefinitionScript.Id] = meshDefinitionScript;
			}
		}

		public bool Exists(string meshId)
		{
			return _prefabs.ContainsKey(meshId);
		}

		public Mesh GetColliderMesh(string name)
		{
			if (!_colliderMeshes.ContainsKey(name))
			{
				Mesh value = LoadColliderMesh(name);
				_colliderMeshes[name] = value;
			}
			return _colliderMeshes[name];
		}

		public List<string> GetMeshesForFuselageType(FuselageMeshType fuselageMeshType)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, MeshDefinitionScript> prefab in _prefabs)
			{
				if (prefab.Value.FuselageMeshType == fuselageMeshType)
				{
					list.Add(prefab.Key);
				}
			}
			return list;
		}

		public string GetMeshName(string meshId)
		{
			return _prefabs[meshId].Name;
		}

		public MeshDefinitionScript InstantiateMesh(string meshId)
		{
			if (Exists(meshId))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_prefabs[meshId].gameObject);
				Utilities.SetLayerRecursive(gameObject, 31);
				return gameObject.GetComponent<MeshDefinitionScript>();
			}
			throw new ArgumentException("Could not find mesh ID: " + meshId);
		}

		private Mesh LoadColliderMesh(string name)
		{
			return UnityEngine.Object.Instantiate((Resources.Load("Craft/Parts/Meshes/" + name) as GameObject).GetComponent<MeshFilter>().sharedMesh);
		}
	}
}
