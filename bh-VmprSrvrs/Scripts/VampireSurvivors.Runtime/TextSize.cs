using System.Collections;
using UnityEngine;

public class TextSize
{
	private Hashtable dict;

	private TextMesh textMesh;

	private Renderer renderer;

	public float width => 0f;

	public TextSize(TextMesh tm)
	{
	}

	private void getSpace()
	{
	}

	private float GetTextWidth(string s)
	{
		return 0f;
	}

	public void FitToWidth(float wantedWidth, int maxLines = -1)
	{
	}

	private string wrapLine(string s, float w, int maxLines = -1)
	{
		return null;
	}
}
