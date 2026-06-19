using System;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Modular Mesh and Material Bindings", order = 1026)]
	public class ModularMeshMaterialBindings : ScriptableObjectWithID
	{
		[Serializable]
		public class Binding
		{
			public GameObject Mesh;

			public Material Material;
		}

		public Binding[] Bindings = new Binding[0];

		public Material FallbackMaterial;

		private int[] _meshInstanceIDs;

		public Material GetMaterial(GameObject meshPrefab)
		{
			_ = meshPrefab == null;
			int instanceID = meshPrefab.GetInstanceID();
			for (int i = 0; i < _meshInstanceIDs.Length; i++)
			{
				if (_meshInstanceIDs[i] == instanceID)
				{
					return Bindings[i].Material;
				}
			}
			return FallbackMaterial;
		}

		public void OnEnable()
		{
			_meshInstanceIDs = new int[Bindings.Length];
			for (int i = 0; i < Bindings.Length; i++)
			{
				_meshInstanceIDs[i] = Bindings[i].Mesh.GetInstanceID();
			}
		}
	}
}
