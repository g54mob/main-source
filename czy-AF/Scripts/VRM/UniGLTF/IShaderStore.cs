using UnityEngine;

namespace UniGLTF
{
	public interface IShaderStore
	{
		Shader GetShader(glTFMaterial material);
	}
}
