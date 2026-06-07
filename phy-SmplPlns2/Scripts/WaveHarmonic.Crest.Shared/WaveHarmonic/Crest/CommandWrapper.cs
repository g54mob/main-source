using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal readonly struct CommandWrapper : ICommandWrapper, IPropertyWrapper
	{
		public CommandBuffer Commands { get; }

		public CommandWrapper(CommandBuffer commands)
		{
			Commands = commands;
		}

		public void SetFloat(int param, float value)
		{
			Commands.SetGlobalFloat(param, value);
		}

		public void SetFloatArray(int param, float[] value)
		{
			Commands.SetGlobalFloatArray(param, value);
		}

		public void SetTexture(int param, Texture value)
		{
			Commands.SetGlobalTexture(param, value);
		}

		public void SetVector(int param, Vector4 value)
		{
			Commands.SetGlobalVector(param, value);
		}

		public void SetVectorArray(int param, Vector4[] value)
		{
			Commands.SetGlobalVectorArray(param, value);
		}

		public void SetMatrix(int param, Matrix4x4 value)
		{
			Commands.SetGlobalMatrix(param, value);
		}

		public void SetInteger(int param, int value)
		{
			Commands.SetGlobalInteger(param, value);
		}

		public void SetBoolean(int param, bool value)
		{
			Commands.SetGlobalFloat(param, value ? 1f : 0f);
		}

		public void GetBlock()
		{
		}

		public void SetBlock()
		{
		}

		public void SetInvertCulling(bool invert)
		{
			Commands.SetInvertCulling(invert);
		}

		public void DrawFullScreenTriangle(Material material, int pass = -1, MaterialPropertyBlock block = null)
		{
			Commands.DrawProcedural(Matrix4x4.identity, material, pass, MeshTopology.Triangles, 3, 1, block);
		}

		public void DrawMesh(Mesh mesh, Matrix4x4 matrix, Material material, int pass = -1, MaterialPropertyBlock block = null)
		{
			Commands.DrawMesh(mesh, matrix, material, 0, pass, block);
		}
	}
}
