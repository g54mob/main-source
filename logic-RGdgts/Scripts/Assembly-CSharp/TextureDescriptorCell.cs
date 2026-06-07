using UnityEngine;

public abstract class TextureDescriptorCell
{
	public Vector2Int position;

	public string name;

	public void Parse(string descriptorValue)
	{
	}

	public abstract void ParseProperty(string key, string value);

	protected abstract void OnParseComplete();
}
