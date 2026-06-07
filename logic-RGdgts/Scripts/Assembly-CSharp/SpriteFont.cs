using UnityEngine;

[CreateAssetMenu]
public class SpriteFont : ScriptableObject
{
	public int charWidth;

	public int charHeight;

	public char initialChar;

	public char endChar;

	public Sprite[] sprites;

	public string chars;

	public bool forceLowerCase;

	public Sprite Get(char c)
	{
		return null;
	}
}
