using System;
using PajamaLlama.Generic;
using UnityEngine;

public class RecipeShaderVisual : RecipeVisual
{
	[Serializable]
	public struct ShaderFloatParameter
	{
		public string Name;

		public RangedFloat Limits;

		public void SetParameter(Material material, float percentualAmount)
		{
			material.SetFloat(Name, Limits.Evaluate(percentualAmount));
		}
	}

	[SerializeField]
	private ShaderFloatParameter[] _shaderFloatParameters;

	[SerializeField]
	private Renderer _renderer;

	private Material _instancedMaterial;

	public override void Initialize(QueuedRecipe queuedRecipe)
	{
		base.Initialize(queuedRecipe);
		_instancedMaterial = _renderer.material;
	}

	public override void StartRecipe(float startProgress)
	{
		UpdateRecipe(startProgress);
	}

	public override void UpdateRecipe(float progress)
	{
		progress /= _recipeProperties.ProductionTime;
		for (int i = 0; i < _shaderFloatParameters.Length; i++)
		{
			_shaderFloatParameters[i].SetParameter(_instancedMaterial, Mathf.Clamp(progress, 0f, 1f));
		}
	}

	public override void FinishRecipe()
	{
		for (int i = 0; i < _shaderFloatParameters.Length; i++)
		{
			_shaderFloatParameters[i].SetParameter(_instancedMaterial, 1f);
		}
	}
}
