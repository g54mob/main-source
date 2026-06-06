using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxCounter : CounterBase
{
	[SerializeField]
	private Button _leftButton;

	[SerializeField]
	private Button _rightButton;

	[SerializeField]
	[Tooltip("The textfield that displays the count.")]
	private TextMeshProUGUI _text;

	private bool _locked;

	public void Lock()
	{
		if (!_locked)
		{
			_leftButton.interactable = false;
			_rightButton.interactable = false;
			_locked = true;
		}
	}

	public void Unlock()
	{
		if (_locked)
		{
			_leftButton.interactable = true;
			_rightButton.interactable = true;
			_locked = false;
		}
	}

	protected override void SetCount(int count)
	{
		if (!_locked)
		{
			base.SetCount(count);
		}
	}

	protected override void UpdateState()
	{
		_text.text = base.Count.ToString();
	}
}
