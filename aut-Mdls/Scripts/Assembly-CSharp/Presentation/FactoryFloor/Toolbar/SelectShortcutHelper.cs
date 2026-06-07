using Events;
using Events.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class SelectShortcutHelper : MonoBehaviour
	{
		[SerializeField]
		private BaseEvent _actionCanceledEvent;

		[SerializeField]
		private BoolEvent _buildModeEvent;

		[SerializeField]
		private GameObject _shortcutIcon;

		private void Awake()
		{
			_shortcutIcon.SetActive(value: false);
			_actionCanceledEvent.Register(OnActionCanceled);
			_buildModeEvent.Register(OnBuildMode);
		}

		private void OnDestroy()
		{
			_actionCanceledEvent.UnRegister(OnActionCanceled);
			_buildModeEvent.UnRegister(OnBuildMode);
		}

		private void OnBuildMode(bool value)
		{
			if (value)
			{
				_shortcutIcon.SetActive(value: true);
			}
		}

		private void OnActionCanceled()
		{
			_shortcutIcon.SetActive(value: false);
		}
	}
}
