using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderVariableSetter : MonoBehaviour
{
	[Serializable]
	public abstract class ShaderVariableSetting
	{
		public string variableName = "_Intensity";

		public abstract void SetVariable(Material m);
	}

	[Serializable]
	public class FloatShaderVariableSetting : ShaderVariableSetting
	{
		public float value;

		public override void SetVariable(Material m)
		{
			m.SetFloat(variableName, value);
		}

		public FloatShaderVariableSetting(float val)
		{
			value = val;
		}
	}

	private MaterialPropertyBlock block;

	public Renderer theRenderer;

	public List<FloatShaderVariableSetting> floatShaderVariableSettings = new List<FloatShaderVariableSetting>();

	private void UpdateMaterialPropertyBlock(bool copyMaterial = false)
	{
		if (copyMaterial)
		{
			theRenderer.sharedMaterial = new Material(theRenderer.sharedMaterial);
		}
		block = new MaterialPropertyBlock();
		theRenderer.GetPropertyBlock(block);
		foreach (FloatShaderVariableSetting floatShaderVariableSetting in floatShaderVariableSettings)
		{
			block.SetFloat(floatShaderVariableSetting.variableName, floatShaderVariableSetting.value);
		}
	}

	private void UseMaterialPropertyBlock()
	{
		theRenderer.SetPropertyBlock(block);
	}

	private void Awake()
	{
		UpdateMaterialPropertyBlock(copyMaterial: true);
		UseMaterialPropertyBlock();
	}
}
