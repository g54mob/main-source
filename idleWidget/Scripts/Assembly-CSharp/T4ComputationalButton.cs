using TMPro;
using UnityEngine;

public class T4ComputationalButton : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _questionText;

	private FrameButton _btn;

	private void Awake()
	{
		_btn = GetComponent<FrameButton>();
	}

	public void SetAnswer(int v)
	{
		if (v < 0)
		{
			_questionText.text = "";
			_btn.SetActive(active: false);
		}
		else
		{
			_questionText.text = v.ToString();
			_btn.SetActive(active: true);
		}
	}
}
