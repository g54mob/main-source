using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LandmarkPanelButton : MonoBehaviour
{
	[Header("Settings")]
	[Tooltip("Should the GameObject be deactivated when this component is disabled?")]
	[SerializeField]
	private bool _deactivateOnDisable = true;

	[Header("References")]
	[Tooltip("The text component of this button.")]
	[SerializeField]
	private Text _label;

	[Tooltip("The image component of this button.")]
	[SerializeField]
	private Image _icon;

	private Button _button;

	private UnityAction _onClickCallback;

	private PanelContainer _panelToCloseOnClick;

	protected void Awake()
	{
		_button = GetComponent<Button>();
		_button.onClick.AddListener(OnClickHandler);
	}

	public void Enable(UnityAction onClickCallback)
	{
		_onClickCallback = onClickCallback;
		base.gameObject.SetActive(value: true);
	}

	public void Enable(UnityAction onClickCallback, string label, Sprite icon = null, PanelContainer panelToCloseOnClick = null)
	{
		Enable(onClickCallback);
		_label.text = label;
		_icon.enabled = icon != null;
		if (_icon.enabled)
		{
			_icon.sprite = icon;
		}
		_panelToCloseOnClick = panelToCloseOnClick;
	}

	private void OnDisable()
	{
		if (_deactivateOnDisable)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		_button.onClick.RemoveListener(OnClickHandler);
	}

	private void OnClickHandler()
	{
		if (_onClickCallback != null)
		{
			_onClickCallback();
		}
		if (_panelToCloseOnClick != null)
		{
			_panelToCloseOnClick.Close();
		}
	}
}
