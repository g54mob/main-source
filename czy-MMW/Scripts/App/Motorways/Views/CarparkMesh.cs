using System;
using System.Collections.Generic;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class CarparkMesh : MonoBehaviour
	{
		[Serializable]
		public struct ThemedMesh
		{
			public MeshRenderer meshRenderer;

			public ThemedMaterialType themedMaterialType;
		}

		public List<ThemedMesh> meshes;
	}
}
