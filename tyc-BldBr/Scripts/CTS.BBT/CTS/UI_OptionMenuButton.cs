using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_OptionMenuButton : MonoBehaviour
	{
		private Button _thisButton;

		[SerializeField]
		private CanvasGroupController _canvasController;

		[SerializeField]
		private GameObject _clickImage;

		[SerializeField]
		private GameObject _noClickedImage;

		private bool _isParametersPanelActive;

		private void Awake()
		{
			_thisButton = GetComponent<Button>();
			_clickImage.SetActive(value: false);
			_thisButton.onClick.AddListener(delegate
			{
				On_OffPanel();
			});
		}

		private void Start()
		{
			UI_ParametersPanelReturnButton.Instance.ClosePanel += On_OffPanel;
			_canvasController.CanvasShowned += _canvasController_CanvasShowned;
		}

		private void _canvasController_CanvasShowned(bool obj)
		{
			if (!obj)
			{
				_clickImage.SetActive(obj);
				_noClickedImage.SetActive(!obj);
			}
		}

		private void OnDisable()
		{
			UI_ParametersPanelReturnButton.Instance.ClosePanel -= On_OffPanel;
		}

		private void On_OffPanel()
		{
			if (!_canvasController.IsShown)
			{
				_canvasController.QuickShow();
				_isParametersPanelActive = true;
				_clickImage.SetActive(_isParametersPanelActive);
				_noClickedImage.SetActive(!_isParametersPanelActive);
			}
			else
			{
				_canvasController.QuickHide();
				_isParametersPanelActive = false;
				_clickImage.SetActive(_isParametersPanelActive);
				_noClickedImage.SetActive(!_isParametersPanelActive);
			}
		}
	}
}
