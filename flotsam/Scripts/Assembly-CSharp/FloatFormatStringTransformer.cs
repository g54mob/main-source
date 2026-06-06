using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/String Transformer/Float Format")]
public class FloatFormatStringTransformer : FloatStringTransformer
{
	[Header("Settings")]
	[SerializeField]
	private string _format = "F0";

	public override string ReturnString(float input)
	{
		return input.ToString(_format);
	}
}
