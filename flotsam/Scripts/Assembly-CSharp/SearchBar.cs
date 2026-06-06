using TMPro;
using UnityEngine;

public class SearchBar : TMP_InputField
{
	[SerializeField]
	private GameObject _clearGameObject;

	private UIState _previousUIState;

	protected override void OnEnable()
	{
		base.OnEnable();
		base.onSelect.AddListener(OnSelect);
		base.onDeselect.AddListener(OnDeselect);
		base.onEndEdit.AddListener(OnDeselect);
		base.onValueChanged.AddListener(OnValueChanged);
		Clear();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		base.onSelect.RemoveListener(OnSelect);
		base.onDeselect.RemoveListener(OnDeselect);
		base.onEndEdit.RemoveListener(OnDeselect);
		base.onValueChanged.RemoveListener(OnValueChanged);
		Clear();
		OnDeselect(base.text);
	}

	private void OnValueChanged(string text)
	{
		_clearGameObject.SetActive(text.Length > 0);
	}

	private void OnSelect(string text)
	{
		_previousUIState = GameManager.UIManager.UIState;
		UIManager.SetState(UIState.Typing);
	}

	private void OnDeselect(string text)
	{
		UIManager.SetState(_previousUIState);
	}

	public void Clear()
	{
		base.text = "";
	}
}
