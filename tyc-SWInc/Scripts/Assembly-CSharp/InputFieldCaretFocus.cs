using UnityEngine;
using UnityEngine.UI;

public class InputFieldCaretFocus : MonoBehaviour
{
	public InputField Input;

	public RectTransform Text;

	private RectTransform _caret;

	public float LineHeight = 24f;

	private int LastPos;

	public Text DuplicateText;

	private void Start()
	{
		Input.onValueChanged.AddListener(delegate(string s)
		{
			DuplicateText.text = s;
		});
	}

	private void Update()
	{
		if (Input.caretPosition == LastPos)
		{
			return;
		}
		if (SetCaret())
		{
			float num = Mathf.Floor(Input.GetComponent<RectTransform>().rect.height / LineHeight);
			float num2 = Mathf.Ceil((Text.offsetMax.y + 2f) / LineHeight);
			int num3 = CountNewlines(Input.caretPosition, Input.text);
			if ((float)num3 <= num2)
			{
				float num4 = (float)num3 * LineHeight;
				Text.offsetMax = new Vector2(Text.offsetMax.x, num4 - 2f);
				_caret.offsetMax = new Vector2(_caret.offsetMax.x, num4 - 2f);
				int caretPosition = Input.caretPosition;
				Input.caretPosition = Input.text.Length;
				Input.caretPosition = caretPosition;
			}
			else if ((float)num3 >= num2 + num)
			{
				float num5 = ((float)num3 - num + 1f) * LineHeight;
				Text.offsetMax = new Vector2(Text.offsetMax.x, num5 - 2f);
				_caret.offsetMax = new Vector2(_caret.offsetMax.x, num5 - 2f);
			}
		}
		LastPos = Input.caretPosition;
	}

	private bool SetCaret()
	{
		if (_caret == null)
		{
			_caret = Input.transform.GetChild(0).GetComponent<RectTransform>();
			_caret.pivot = Text.pivot;
			return _caret != null;
		}
		return true;
	}

	private static int CountNewlines(int p, string s)
	{
		int num = 0;
		for (int i = 0; i < Mathf.Min(s.Length, p); i++)
		{
			if (s[i] == '\n')
			{
				num++;
			}
		}
		return num;
	}
}
