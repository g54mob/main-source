using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OpenCloseButton : MonoBehaviour
{
	[SerializeField]
	private GameObject _openState;

	[SerializeField]
	private GameObject _closedState;

	[SerializeField]
	private GameObject _filters;

	private Button _button;

	private void OnEnable()
	{
		if (_button == null)
		{
			_button = GetComponent<Button>();
		}
	}

	public void SetOpen(bool open)
	{
		_openState.SetActive(open);
		_closedState.SetActive(!open);
		_filters.SetActive(open);
	}
}
