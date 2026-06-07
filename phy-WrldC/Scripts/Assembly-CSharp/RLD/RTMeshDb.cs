using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class RTMeshDb : Singleton<RTMeshDb>
	{
		private Dictionary<Mesh, RTMesh> _meshes = new Dictionary<Mesh, RTMesh>();

		public bool Contains(RTMesh rtMesh)
		{
			if (rtMesh == null)
			{
				return false;
			}
			return _meshes.ContainsKey(rtMesh.UnityMesh);
		}

		public bool Contains(Mesh unityMesh)
		{
			if (unityMesh == null)
			{
				return false;
			}
			return _meshes.ContainsKey(unityMesh);
		}

		public RTMesh GetRTMesh(Mesh unityMesh)
		{
			if (unityMesh == null)
			{
				return null;
			}
			if (!_meshes.ContainsKey(unityMesh))
			{
				return CreateRTMesh(unityMesh);
			}
			return _meshes[unityMesh];
		}

		public void RemoveNullMeshEntries()
		{
			Dictionary<Mesh, RTMesh> dictionary = new Dictionary<Mesh, RTMesh>();
			foreach (KeyValuePair<Mesh, RTMesh> mesh in _meshes)
			{
				if (mesh.Key != null)
				{
					dictionary.Add(mesh.Key, mesh.Value);
				}
			}
			_meshes.Clear();
			_meshes = dictionary;
		}

		private RTMesh CreateRTMesh(Mesh unityMesh)
		{
			RTMesh rTMesh = RTMesh.Create(unityMesh);
			if (rTMesh != null)
			{
				_meshes.Add(unityMesh, rTMesh);
				return rTMesh;
			}
			return null;
		}
	}
}
