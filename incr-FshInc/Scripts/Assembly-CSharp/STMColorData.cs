using UnityEngine;

[CreateAssetMenu(fileName = "New Color Data", menuName = "Super Text Mesh/Color Data", order = 1)]
public class STMColorData : ScriptableObject
{
	public Color color = Color.white;

	public STMColorData()
	{
		color = Color.white;
	}

	public STMColorData(Color color)
	{
		this.color = color;
	}
}
