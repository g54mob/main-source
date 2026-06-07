using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
[DefaultExecutionOrder(100)]
public class TMPLineBreakStripper : MonoBehaviour
{
	private TMP_Text _textMesh;

	private string _originalText;

	private void Awake()
	{
		_textMesh = GetComponent<TMP_Text>();
	}

	private void OnEnable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
		ProcessText();
	}

	private void OnDisable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
	}

	private void OnTextChanged(Object obj)
	{
		if (obj == _textMesh)
		{
			ProcessText();
		}
	}

	public void ProcessText()
	{
		if (_textMesh == null || string.IsNullOrEmpty(_textMesh.text))
		{
			return;
		}
		string text = Application.systemLanguage.ToString();
		int num;
		object obj;
		if (!text.Contains("Japanese") && !text.Contains("Chinese"))
		{
			num = (text.Contains("Korean") ? 1 : 0);
			if (num == 0)
			{
				obj = " ";
				goto IL_006c;
			}
		}
		else
		{
			num = 1;
		}
		obj = "";
		goto IL_006c;
		IL_006c:
		string newValue = (string)obj;
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
		string text2 = _textMesh.text.Replace("<br>", newValue);
		if (num == 0)
		{
			text2 = text2.Replace("  ", " ");
		}
		_textMesh.text = text2;
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
	}
}
