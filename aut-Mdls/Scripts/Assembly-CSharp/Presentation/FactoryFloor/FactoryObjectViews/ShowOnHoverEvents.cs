using System.Collections;
using Data.FactoryFloor.Behaviours;
using Data.Operator;
using Events;
using Events.UI;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class ShowOnHoverEvents : FactoryBehaviorView<FactoryObjectBehaviour>
	{
		[SerializeField]
		private FactoryObjectUIData _objectUIData;

		[Header("Simple text infopanel")]
		[SerializeField]
		private ShowInfoPanelEvent _showInfoPanelEvent;

		[SerializeField]
		private BaseEvent _hideInfoPanelEvent;

		[Header("Operator UI")]
		[SerializeField]
		private UIMenuLocator _uiMenuLocator;

		private const float HOVER_DELAY_TIME = 0.3f;

		private bool _hasShown;

		private bool _hovering;

		private Coroutine _hoveringCoroutine;

		private void OnEnable()
		{
			_objectView.ObjectHovered += OnObjectHovered;
			_objectView.ObjectHoverStopped += OnObjectHoverStopped;
			_hasShown = false;
		}

		private void OnDisable()
		{
			_objectView.ObjectHovered -= OnObjectHovered;
			_objectView.ObjectHoverStopped -= OnObjectHoverStopped;
		}

		protected override void Init()
		{
			base.Init();
			_hasShown = false;
		}

		private void OnObjectHovered()
		{
			_hasShown = false;
			if (_hoveringCoroutine != null)
			{
				StopCoroutine(_hoveringCoroutine);
			}
			_hoveringCoroutine = StartCoroutine(HoverCoroutine());
		}

		private void OnObjectHoverStopped()
		{
			_hovering = false;
			if (!_hasShown)
			{
				return;
			}
			if (_uiMenuLocator != null)
			{
				if (!_uiMenuLocator.UIMenu.UIMenuIsStacked)
				{
					_uiMenuLocator.UIMenu.HideMenu();
				}
			}
			else if (_showInfoPanelEvent != null)
			{
				_hideInfoPanelEvent.Fire();
			}
			_hasShown = false;
		}

		private IEnumerator HoverCoroutine()
		{
			_hovering = true;
			for (float time = 0f; time < 0.3f; time += Time.deltaTime)
			{
				if (!_hovering)
				{
					yield break;
				}
				yield return null;
			}
			if (_hovering)
			{
				StartActualHover();
			}
			_hoveringCoroutine = null;
		}

		private void StartActualHover()
		{
			if (_uiMenuLocator != null)
			{
				if (!_uiMenuLocator.UIMenu.UIMenuIsStacked)
				{
					if (_objectView.FactoryObject == null && _objectUIData != null)
					{
						_uiMenuLocator.UIMenu.ShowMenu(_objectUIData);
					}
					else
					{
						_uiMenuLocator.UIMenu.ShowMenu(new UIMenuBehaviourData(_uiMenuLocator.UIMenu, _objectView.FactoryObject, AbstractUIMenuData.UIMenuState.InfoMode, _behaviour));
					}
				}
			}
			else if (_showInfoPanelEvent != null && _objectUIData != null)
			{
				TextInfoPanelDto textInfoPanelDto = new TextInfoPanelDto(_objectUIData.NameLocKey, enableWrapping: false);
				textInfoPanelDto.SetFontSize(30);
				_showInfoPanelEvent.Fire(textInfoPanelDto);
			}
			_hasShown = true;
		}
	}
}
