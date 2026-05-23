using Presentation.UI.Menus.HudPanelTabGroups;
using Presentation.UI.Menus.MenuEvents;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class ModuleButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		protected Image _iconImg;

		[SerializeField]
		private TextMeshProUGUI _amountTxt;

		[SerializeField]
		private Button _button;

		[SerializeField]
		protected ShowHudPanelEvent _showHudPanelEvent;

		[SerializeField]
		protected TabGroupPanelSO _moduleViewerPanelSo;

		[SerializeField]
		protected GameObject _hoverGO;

		protected ModuleViewerData _moduleViewerData;

		protected int _index;

		protected virtual void OnEnable()
		{
			_button.onClick.AddListener(HandleClick);
		}

		private void OnDisable()
		{
			if (_button.interactable)
			{
				_hoverGO.SetActive(value: false);
			}
			_button.onClick.RemoveAllListeners();
		}

		protected virtual void OnDestroy()
		{
			_button.onClick.RemoveAllListeners();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_button.interactable)
			{
				_hoverGO.SetActive(value: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (_button.interactable)
			{
				_hoverGO.SetActive(value: false);
			}
		}

		protected virtual void HandleClick()
		{
			if (_button.interactable)
			{
				_hoverGO.SetActive(value: false);
				_showHudPanelEvent.Fire(new ModuleViewerHudPanelData(_moduleViewerPanelSo, _moduleViewerData, _index));
			}
		}

		public void SetModuleIcon(Texture2D iconTexture, ModuleViewerData moduleViewerData, int index = 0)
		{
			_index = index;
			_moduleViewerData = moduleViewerData;
			_iconImg.sprite = Sprite.Create(iconTexture, new Rect(0f, 0f, iconTexture.width, iconTexture.height), new Vector2(0.5f, 0.5f));
		}

		public void SetModuleIcon(Sprite sprite, int index = 0)
		{
			_index = index;
			_iconImg.sprite = sprite;
		}

		public void SetAmount(int amount)
		{
			if (_amountTxt != null)
			{
				_amountTxt.SetText(amount.ToString());
			}
		}

		public void SetAmountColor(Color color)
		{
			_amountTxt.color = color;
		}

		public void ResetAmountColor()
		{
			_amountTxt.color = Color.white;
		}
	}
}
