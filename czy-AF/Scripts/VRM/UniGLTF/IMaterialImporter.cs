using UnityEngine;

namespace UniGLTF
{
	public interface IMaterialImporter
	{
		Material CreateMaterial(int i, glTFMaterial src, bool hasVertexColor);
	}
}
