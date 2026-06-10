using UnityEngine;

[CreateAssetMenu(fileName = "New Auto Clip Data", menuName = "Super Text Mesh/Audo Clip Data", order = 1)]
public class STMAutoClipData : ScriptableObject
{
	public enum Type
	{
		Character = 0,
		Quad = 1
	}

	public Type type;

	public char character;

	public string quadName;

	public AudioClip clip;
}
