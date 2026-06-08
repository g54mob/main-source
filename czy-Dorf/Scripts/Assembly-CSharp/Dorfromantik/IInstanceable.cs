using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public interface IInstanceable
	{
		RecyclableType RecyclableId { get; }

		Mesh Mesh { get; }

		bool IsDecoration { get; }

		List<CustomInstanceTexture> CustomTextures { get; }

		MeshRenderer MeshRenderer { get; }

		Material InstancedMaterial { get; }

		Instanceable ReferenceInstanceable { get; }
	}
}
