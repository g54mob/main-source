using UnityEngine;

[ExecuteInEditMode]
public class WobbleTextMesh : MonoBehaviour
{
	public string text;

	public float offsetZ;

	public int characterSize;

	public float lineSpacing;

	public TextAnchor anchor;

	public TextAlignment alignment;

	public int tabSize = 4;

	public int fontSize = 84;

	public FontStyle fontStyle;

	public bool richText;

	public Font font;

	public Color color;

	private TextMesh textMesh;

	private void Awake()
	{
		UpdateMesh();
	}

	public void UpdateMesh()
	{
		TextMesh[] components = GetComponents<TextMesh>();
		for (int i = 0; i < components.Length; i++)
		{
			Object.DestroyImmediate(components[i]);
		}
		textMesh = base.gameObject.AddComponent<TextMesh>();
		textMesh.text = text;
		textMesh.offsetZ = offsetZ;
		textMesh.characterSize = characterSize;
		textMesh.lineSpacing = lineSpacing;
		textMesh.anchor = anchor;
		textMesh.alignment = alignment;
		textMesh.tabSize = tabSize;
		textMesh.fontSize = fontSize;
		textMesh.fontStyle = fontStyle;
		textMesh.richText = richText;
		textMesh.font = font;
		textMesh.color = color;
		base.gameObject.GetComponent<TextMesh>().hideFlags = HideFlags.HideInInspector;
	}
}
