using System.Collections;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CTS
{
	public class UI_ScrollCredit : MonoBehaviour
	{
		[Foldout("Devs")]
		[SerializeField]
		private TMP_Text _textMeshPro;

		[Foldout("Devs")]
		[SerializeField]
		private RectTransform _textCreditsContents;

		[Foldout("Devs")]
		[SerializeField]
		private ScrollRect _scrollRectView;

		private Coroutine _creditScroll;

		[Foldout("Devs")]
		[SerializeField]
		private RectTransform _content;

		[Foldout("Devs")]
		[SerializeField]
		private GameObject _creditMenu;

		[Foldout("Devs")]
		[SerializeField]
		private RectTransform _panelImage;

		[Header("Modification for the animation Credits")]
		[SerializeField]
		[Min(1.1f)]
		private float _scrollingSpeed;

		[SerializeField]
		[Tooltip("Time before launch the Scrolling")]
		private float _breakTimeBeforeScroll;

		[SerializeField]
		[Tooltip("Multiply scrolling Speed By This")]
		[Min(1.1f)]
		private float _boostScrollingSpeed;

		[SerializeField]
		private bool _quitCreditAfterTheEnd;

		private float _speedAccel;

		private RectTransform _scrollRect;

		private Vector2 _tMPValue;

		private bool _isAccel;

		private float _ySizeTextContent;

		private UI_CreditsManager _creditsManager;

		private PanelCreditManager _scriptLaunchScrolling;

		private float _stopScroll;

		[SerializeField]
		private InputActionReference _clickSpeed;

		[SerializeField]
		private InputActionReference _spaceBarSpeed;

		[SerializeField]
		private InputActionReference _clickPause;

		[SerializeField]
		private InputActionReference _leavePanel;

		private void Awake()
		{
			_creditsManager = GetComponent<UI_CreditsManager>();
			_scrollRectView.verticalNormalizedPosition = 1f;
			_scrollRectView.movementType = ScrollRect.MovementType.Unrestricted;
			_scrollRect = _scrollRectView.GetComponent<RectTransform>();
			_speedAccel = 1f;
			_scrollingSpeed /= 0.1f;
			_stopScroll = 1f;
			_clickSpeed.action.performed += SpeedAccelerate;
			_spaceBarSpeed.action.performed += SpeedAccelerate;
			_clickSpeed.action.canceled += StopAccelerate;
			_spaceBarSpeed.action.canceled += StopAccelerate;
			_clickPause.action.performed += StopSpeed;
			_clickPause.action.canceled += CancelStop;
		}

		private void OnDestroy()
		{
			_clickSpeed.action.performed -= SpeedAccelerate;
			_spaceBarSpeed.action.performed -= SpeedAccelerate;
			_clickSpeed.action.canceled -= StopAccelerate;
			_spaceBarSpeed.action.canceled -= StopAccelerate;
			_clickPause.action.performed -= StopSpeed;
			_clickPause.action.canceled -= CancelStop;
		}

		private void SpeedAccelerate(InputAction.CallbackContext obj)
		{
			if (_creditMenu.gameObject.activeSelf && !_isAccel)
			{
				On_OffSpeedAccel();
			}
		}

		private void StopAccelerate(InputAction.CallbackContext obj)
		{
			if (_creditMenu.gameObject.activeSelf && _isAccel)
			{
				On_OffSpeedAccel();
			}
		}

		private void CancelStop(InputAction.CallbackContext obj)
		{
			if (_creditMenu.gameObject.activeSelf)
			{
				_stopScroll = 1f;
			}
		}

		private void StopSpeed(InputAction.CallbackContext obj)
		{
			if (_creditMenu.gameObject.activeSelf)
			{
				_stopScroll = 0f;
			}
		}

		public void GetRefChild(PanelCreditManager thisScript)
		{
			_scriptLaunchScrolling = thisScript;
		}

		public Coroutine LaunchCoroutine(Coroutine coroutine)
		{
			coroutine = StartCoroutine(ScrollingCoroutine());
			_creditScroll = coroutine;
			return coroutine;
		}

		public Coroutine StopThecoroutine(Coroutine coroutine)
		{
			StopCoroutine(coroutine);
			coroutine = null;
			_creditScroll = coroutine;
			return coroutine;
		}

		[Button(null, EButtonEnableMode.Always)]
		public void ResetScrolling()
		{
			_content.sizeDelta = new Vector2(0f, _textCreditsContents.sizeDelta.y);
			_content.anchoredPosition = new Vector2(0f, 0f - _textCreditsContents.sizeDelta.y);
		}

		private IEnumerator ScrollingCoroutine()
		{
			_content.sizeDelta = new Vector2(_content.sizeDelta.x, _textCreditsContents.sizeDelta.y);
			_scrollRectView.verticalNormalizedPosition = 1f;
			_speedAccel = 1f;
			_isAccel = false;
			_stopScroll = 1f;
			yield return new WaitForSeconds(_breakTimeBeforeScroll);
			float marginError = _panelImage.sizeDelta.y;
			while (_content.localPosition.y < marginError)
			{
				_content.localPosition += new Vector3(0f, Time.deltaTime * _scrollingSpeed * _speedAccel * _stopScroll, 0f);
				yield return null;
			}
			_creditScroll = null;
			if (_quitCreditAfterTheEnd)
			{
				_creditsManager.CloseCreditsPanel();
			}
			_scriptLaunchScrolling.NullCoroutine();
		}

		public void On_OffSpeedAccel()
		{
			if (_creditScroll != null)
			{
				if (!_isAccel)
				{
					_speedAccel = _boostScrollingSpeed;
					_isAccel = true;
				}
				else
				{
					_speedAccel = 1f;
					_isAccel = false;
				}
			}
		}
	}
}
