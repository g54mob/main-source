using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal interface ICommandWrapper : IPropertyWrapper
	{
		void SetInvertCulling(bool invert);

		void DrawFullScreenTriangle(Material material, int pass, MaterialPropertyBlock block = null);

		void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int pass = -1, MaterialPropertyBlock block = null);
	}
}
