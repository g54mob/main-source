using Assets.Nimbatus.Scripts.DroneSkins;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class DroneSkinItem : MonoBehaviour
	{
		public UITexture Icon;

		public UITexture Background;

		public Color SelectColor;

		public Color HoverColor;

		public Color NormalColor;

		private DroneSkinSelector _selector;

		private UIDragScrollView _drag;

		private bool _hover;

		public DroneSkin Skin { get; private set; }

		public void Awake()
		{
			_drag = base.gameObject.AddMissingComponent<UIDragScrollView>();
		}

		public void Init(DroneSkinSelector selector, DroneSkin skin)
		{
			_selector = selector;
			Skin = skin;
			_drag.scrollView = selector.ScrollView;
			Icon.mainTexture = skin.SkinTexture.texture;
		}

		public void OnClick()
		{
			_selector.Select(this);
		}

		public void Update()
		{
			if (_selector != null && _selector.SelectedItem == this)
			{
				Background.color = SelectColor;
			}
			else
			{
				Background.color = (_hover ? HoverColor : NormalColor);
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
