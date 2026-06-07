using UnityEngine;
using UnityEngine.UI;

public class InputFieldScroll : MonoBehaviour
{
	public Scrollbar Self;

	public InputField Field;

	private int _lines = 1;

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

	private void Start()
	{
		RefreshLines();
	}

	private void Update()
	{
		Self.size = 1f / ((float)_lines + 1f);
		Self.numberOfSteps = _lines + 1;
		Self.value = ((_lines == 0) ? 0f : ((float)CountNewlines(Field.caretPosition, Field.text) / (float)_lines));
	}

	public void ChangePos()
	{
	}

	public void RefreshLines()
	{
		_lines = Field.text.CountLetter('\n');
	}
}
