using UnityEngine;

[CreateAssetMenu(fileName = "New Gradient Data", menuName = "Super Text Mesh/Gradient Data", order = 1)]
public class STMGradientData : ScriptableObject
{
	public enum GradientDirection
	{
		Horizontal = 0,
		Vertical = 1
	}

	public Gradient gradient;

	public float gradientSpread = 0.1f;

	public float scrollSpeed;

	public GradientDirection direction;

	public bool smoothGradient = true;
}
