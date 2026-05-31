using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS.UI
{
	[RequireComponent(typeof(Image))]
	public class FeatureIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image _image;

		[SerializeField]
		private Transform _transformToResize;

		[SerializeField]
		private float _onHoverScale = 1.1f;

		private LocalizedString _title;

		private LocalizedString _description;

		private float _currentScale = 1f;

		private Coroutine _transitionCoroutine;

		public bool Interactable = true;

		[SerializeField]
		private bool _disableIconOnStart = true;

		private ToolTipsShower _toolTips;

		private void Awake()
		{
			if (_image == null)
			{
				_image = GetComponent<Image>();
			}
			if (_transformToResize == null)
			{
				_transformToResize = base.transform;
			}
			if (_disableIconOnStart)
			{
				_image.enabled = false;
			}
			_toolTips = GetComponent<ToolTipsShower>();
		}

		public void ResetIcon()
		{
			if (_image == null)
			{
				_image = GetComponent<Image>();
			}
			_image.enabled = false;
			_image.sprite = null;
			_description = null;
			_title = null;
		}

		public void SetImageAndDescription(Sprite p_sprite, LocalizedString p_desc, LocalizedString p_title)
		{
			_image.sprite = p_sprite;
			_description = p_desc;
			_image.enabled = true;
			_title = p_title;
			_toolTips?.SetTootipsInfo(_title, _description);
		}

		public void SetDescription(LocalizedString p_desc, LocalizedString p_title)
		{
			_description = p_desc;
			_image.enabled = true;
			_title = p_title;
			_toolTips?.SetTootipsInfo(_title, _description);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (Interactable)
			{
				if (_transitionCoroutine != null)
				{
					StopCoroutine(_transitionCoroutine);
				}
				_transitionCoroutine = StartCoroutine(ResizeIconScale(_onHoverScale));
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (Interactable)
			{
				if (_transitionCoroutine != null)
				{
					StopCoroutine(_transitionCoroutine);
				}
				_transitionCoroutine = StartCoroutine(ResizeIconScale(1f));
			}
		}

		private IEnumerator ResizeIconScale(float p_newScale)
		{
			float scaleTransitionValue = 0f;
			float startValue = _currentScale;
			while (scaleTransitionValue < 1f)
			{
				yield return null;
				scaleTransitionValue += Time.unscaledDeltaTime * 8f;
				_currentScale = Mathf.Lerp(startValue, p_newScale, scaleTransitionValue);
				_transformToResize.localScale = Vector3.one * _currentScale;
			}
			_currentScale = p_newScale;
			_transformToResize.localScale = Vector3.one * _currentScale;
			_transitionCoroutine = null;
		}
	}
}
