using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	[RequireComponent(typeof(UIDragScrollView))]
	public class WeaponListItem : MonoBehaviour
	{
		public UITexture Icon;

		public UITexture ColoredIcon;

		public UITexture Background;

		public Texture2D DefaultIcon;

		public Color NormalColor;

		public Color SelectedColor;

		public Color HoverColor;

		private bool _hover;

		private WeaponPresetList _presetList;

		private WeaponPreset _preset;

		private UIDragScrollView _uiDragPanelContents;

		public void Awake()
		{
			_uiDragPanelContents = GetComponent<UIDragScrollView>();
		}

		public void Init(WeaponPresetList presetList, WeaponPreset preset, UIScrollView itemPanel)
		{
			_presetList = presetList;
			_preset = preset;
			_uiDragPanelContents.scrollView = itemPanel;
		}

		public void OnTooltip(bool show)
		{
			if (_preset != null)
			{
				NimbatusToolTip.Show(_preset.GetTooltip());
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}

		public void OnClick()
		{
			_presetList.SelectedItem = _preset;
		}

		public void Update()
		{
			if (_presetList.SelectedItem == _preset)
			{
				Background.color = (_hover ? HoverColor : SelectedColor);
			}
			else
			{
				Background.color = (_hover ? HoverColor : NormalColor);
			}
			if (_preset.Ammunition != null && _preset.Emitter != null)
			{
				Icon.mainTexture = _preset.Emitter.Icon;
				ColoredIcon.mainTexture = _preset.Emitter.AmmunitionTexture;
				ColoredIcon.color = _preset.Ammunition.IconColorModifier;
				ColoredIcon.enabled = true;
			}
			else
			{
				ColoredIcon.enabled = false;
				Icon.mainTexture = DefaultIcon;
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
