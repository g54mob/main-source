using UnityEngine;

public class IndicatorShaderValue : Indicator
{
	private static readonly int INDICATOR_VALUE = Shader.PropertyToID("_IndicatorValue");

	public MeshRenderer renderer;

	private MaterialPropertyBlock propertyBlock;

	private void Awake()
	{
		CheckInitialized();
	}

	private void CheckInitialized()
	{
		if (propertyBlock == null)
		{
			propertyBlock = new MaterialPropertyBlock();
		}
	}

	protected override void OnValueSet()
	{
		CheckInitialized();
		propertyBlock.SetFloat(INDICATOR_VALUE, GetNormalizedValue());
		renderer.SetPropertyBlock(propertyBlock);
	}
}
