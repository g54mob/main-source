using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class TextSizer : MonoBehaviour
{
	public enum Mode
	{
		None = 0,
		Horizontal = 1,
		Vertical = 2,
		Both = 3
	}

	public TMP_Text Text;

	public bool ResizeTextObject;

	public Vector2 Padding;

	public Vector2 MaxSize;

	public Vector2 MinSize;

	public Mode ControlAxes;

	private string _lastText;

	private Mode _lastControlAxes;

	private Vector2 _lastSize;

	private bool _forceRefresh;

	private bool _isTextNull;

	private RectTransform _textRectTransform;

	private RectTransform _selfRectTransform;

	protected virtual float MinX => 0f;

	protected virtual float MinY => 0f;

	protected virtual float MaxX => 0f;

	protected virtual float MaxY => 0f;

	protected virtual void Update()
	{
	}

	public virtual void Refresh()
	{
	}

	private void OnValidate()
	{
	}
}
