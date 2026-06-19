using UnityEngine;

public static class MaterialUtil
{
	private static MaterialPropertyBlock _block;

	public static readonly int MAIN_COLOR_ID = Shader.PropertyToID("_MainColor");

	[RuntimeInitializeOnLoadMethod]
	private static void Initialize()
	{
		_block = new MaterialPropertyBlock();
	}

	public static void SetPropertyBlockFloat(this Renderer meshRenderer, string name, float value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetFloat(name, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockFloat(this Renderer meshRenderer, int nameId, float value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetFloat(nameId, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockInt(this Renderer meshRenderer, string name, int value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetInt(name, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockInt(this Renderer meshRenderer, int nameId, int value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetInt(nameId, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockVector(this Renderer meshRenderer, string name, Vector3 value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetVector(name, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockVector(this Renderer meshRenderer, int nameId, Vector3 value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetVector(nameId, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockVectorArray(this Renderer meshRenderer, string name, Vector4[] value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetVectorArray(name, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockVectorArray(this Renderer meshRenderer, int nameId, Vector4[] value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetVectorArray(nameId, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockFloatArray(this Renderer meshRenderer, string name, float[] value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetFloatArray(name, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockFloatArray(this Renderer meshRenderer, int nameId, float[] value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetFloatArray(nameId, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockColor(this Renderer meshRenderer, string name, Color value)
	{
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetColor(name, value);
		meshRenderer.SetPropertyBlock(_block);
	}

	public static void SetPropertyBlockColor(this Renderer meshRenderer, int nameId, Color value)
	{
		if (_block == null)
		{
			_block = new MaterialPropertyBlock();
		}
		_block.Clear();
		meshRenderer.GetPropertyBlock(_block);
		_block.SetColor(nameId, value);
		meshRenderer.SetPropertyBlock(_block);
	}
}
