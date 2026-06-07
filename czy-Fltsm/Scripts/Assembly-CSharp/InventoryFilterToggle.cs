using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InventoryFilterToggle : MonoBehaviour
{
	private Button _button;

	private bool _active;

	[SerializeField]
	private GameObject _filters;

	private void OnEnable()
	{
		if (_button == null)
		{
			_button = GetComponent<Button>();
		}
		_button.onClick.AddListener(OnClick);
	}

	private void OnDisable()
	{
		if (_button != null)
		{
			_button.onClick.RemoveListener(OnClick);
		}
	}

	private void OnClick()
	{
		Transform transform = _filters.transform;
		_active = !_active;
		if (!transform.IsNull())
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(_active);
			}
		}
	}
}
