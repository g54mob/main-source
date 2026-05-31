using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.DevConsole
{
	public class LogObject : MonoBehaviour
	{
		private TextMeshProUGUI _logTextComponent;

		private Text _descriptionTextComponent;

		private GameObject _descButtonHolder;

		private Toggle _descCollapseButton;

		private Transform _descButtonVisual;

		private bool _containsDesc;

		private static readonly Vector3 OpenDesc = new Vector3(0f, 0f, -90f);

		private static readonly Vector3 ClosedDesc = new Vector3(0f, 0f, 0f);

		private void Awake()
		{
			_descCollapseButton = GetComponentInChildren<Toggle>(includeInactive: true);
			_descButtonHolder = _descCollapseButton.transform.parent.gameObject;
			_descButtonVisual = _descCollapseButton.transform.GetChild(0);
			_descriptionTextComponent = base.transform.GetChild(1).GetComponent<Text>();
			_logTextComponent = base.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
		}

		public void SetText(string text)
		{
			_containsDesc = false;
			UpdateLog(text);
			Enable();
		}

		public void SetTextWithStack(string text, string stack)
		{
			_containsDesc = true;
			_descriptionTextComponent.text = stack;
			UpdateLog(text);
			Enable();
		}

		private void UpdateLog(string text)
		{
			_logTextComponent.text = text;
		}

		private void Enable()
		{
			_descButtonHolder.gameObject.SetActive(_containsDesc);
			_descCollapseButton.isOn = false;
			OnCollapseButton(value: false);
			if (_containsDesc)
			{
				RectTransform obj = (RectTransform)_descCollapseButton.transform;
				Vector2 sizeDelta = obj.sizeDelta;
				sizeDelta.x = _logTextComponent.preferredWidth + 30f;
				obj.sizeDelta = sizeDelta;
				_descCollapseButton.onValueChanged.RemoveListener(OnCollapseButton);
				_descCollapseButton.onValueChanged.AddListener(OnCollapseButton);
			}
		}

		private void OnEnable()
		{
			Enable();
		}

		private void OnDisable()
		{
			_descCollapseButton.onValueChanged.RemoveListener(OnCollapseButton);
		}

		private void OnCollapseButton(bool value)
		{
			_descriptionTextComponent.gameObject.SetActive(value);
			_descButtonVisual.eulerAngles = (value ? OpenDesc : ClosedDesc);
		}

		public void SetToggleOn(bool value)
		{
			if (_containsDesc)
			{
				if (_descCollapseButton.isOn != value)
				{
					_descCollapseButton.isOn = value;
				}
				OnCollapseButton(value);
			}
		}
	}
}
