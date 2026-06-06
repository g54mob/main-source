using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.SurvivalGuide
{
	public class PageIndex : MonoBehaviour
	{
		[SerializeField]
		private Selectable _selectable;

		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private GameEventType _selectedEvent = GameEventType.OpenSurvivalGuidePage;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private string _activePageIndexParameter = "ActivePageIndex";

		private bool _active;

		internal IPage Page { get; private set; }

		internal CategoryPageIndex Parent { get; set; }

		internal Selectable Selectable => _selectable;

		protected Animator Animator => _animator;

		protected virtual void OnEnable()
		{
			UpdateAnimatorState();
		}

		internal virtual void Initialize(IPage page)
		{
			Page = page;
			Page.SetIndex(this);
			_label.text = page.Name;
			if ((bool)_icon)
			{
				if ((bool)page.Icon)
				{
					_icon.overrideSprite = page.Icon;
				}
				else
				{
					_icon.gameObject.SetActive(value: false);
				}
			}
		}

		public void Select()
		{
			PageEvent.Dispatch(_selectedEvent, this);
		}

		public void SetActivePageIndex(bool active)
		{
			_active = active;
			UpdateAnimatorState();
		}

		protected virtual void UpdateAnimatorState()
		{
			if ((bool)_animator)
			{
				_animator.SetBool(_activePageIndexParameter, _active);
			}
		}
	}
}
