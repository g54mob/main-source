using UnityEngine;
using UnityEngine.Rendering;

public abstract class WorldParameters : ScriptableObject
{
	public int globalSeed;

	public abstract void SetShaderProperties();

	public abstract void SetShaderProperties(CommandBuffer cmd);

	public abstract void SetShaderProperties(Material material);

	public abstract void SetShaderProperties(ComputeShader computeShader);
}
