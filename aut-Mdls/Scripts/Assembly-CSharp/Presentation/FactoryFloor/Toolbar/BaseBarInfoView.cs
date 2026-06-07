using Events;
using TMPro;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class BaseBarInfoView : MonoBehaviour
	{
		[SerializeField]
		protected TextMeshProUGUI _text;

		[Header("Events")]
		[SerializeField]
		private BaseEvent _hideBarInfoEvent;

		protected virtual void Awake()
		{
			_hideBarInfoEvent.Register(Hide);
			LocalizationUtility.OnLanguageUpdate += UpdateLocalization;
			base.gameObject.SetActive(value: false);
		}

		protected virtual void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= UpdateLocalization;
			_hideBarInfoEvent.UnRegister(Hide);
		}

		protected virtual void UpdateLocalization()
		{
		}

		public virtual void Hide()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
