using Assets.Scripts.GuiNew;
using Assets.Scripts.Tutorials;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.XR.UI
{
	public class RadialMenuButtonScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private Button _button;

		private ButtonColorScript _buttonColorScript;

		[SerializeField]
		private string _id;

		private ImageColorScript _imageColorScript;

		private bool _isBlinking;

		private bool _isSelected;

		[SerializeField]
		private string _tooltip;

		public string Id => _id;

		public bool IsBlinking
		{
			get
			{
				return _isBlinking;
			}
			set
			{
				_isBlinking = value;
				if ((object)_buttonColorScript != null)
				{
					_buttonColorScript.IsBlinking = value;
				}
				if ((object)_imageColorScript != null)
				{
					_imageColorScript.IsBlinking = value;
				}
			}
		}

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
				if ((object)_buttonColorScript != null)
				{
					_buttonColorScript.IsSelected = value;
				}
				if ((object)_imageColorScript != null)
				{
					_imageColorScript.IsSelected = value;
				}
			}
		}

		public string Tooltip => _tooltip;

		public RadialMenuTooltipScript TooltipScript { get; private set; }

		public void OnPointerEnter(PointerEventData eventData)
		{
			TooltipScript.SetHoveredButton((XRHandType)eventData.pointerId, this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			TooltipScript.SetHoveredButton((XRHandType)eventData.pointerId, null);
		}

		protected virtual void Awake()
		{
			_buttonColorScript = GetComponent<ButtonColorScript>();
			_imageColorScript = GetComponent<ImageColorScript>();
			if (_buttonColorScript == null && _imageColorScript == null)
			{
				Debug.LogError("Unable to find the button color script component for the radial menu button script. GameObject: " + base.name, this);
				base.enabled = false;
				return;
			}
			FlightMenuScript componentInParent = GetComponentInParent<FlightMenuScript>();
			TooltipScript = ((componentInParent == null) ? null : componentInParent.tooltipScript);
			if (TooltipScript == null)
			{
				Debug.LogError("Unable to find the tooltip script for the radial menu button script. GameObject: " + base.name, this);
				base.enabled = false;
				return;
			}
			_button = GetComponent<Button>();
			if (_button != null)
			{
				_button.onClick.AddListener(OnButtonClicked);
			}
			IsSelected = _isSelected;
			IsBlinking = _isBlinking;
		}

		private void OnButtonClicked()
		{
			TutorialScript.Current?.FocusedRequirement?.OnRadialMenuButtonClicked(this);
		}
	}
}
