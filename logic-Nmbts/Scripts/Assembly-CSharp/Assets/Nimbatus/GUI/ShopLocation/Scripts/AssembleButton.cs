using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.GUI.ShopLocation.Scripts
{
	public class AssembleButton : MonoBehaviour
	{
		private UIButton[] _buttons;

		public UIButtonScale ButtonScale;

		private bool _hover;

		public void Awake()
		{
			_buttons = GetComponents<UIButton>();
		}

		public void Update()
		{
			if (BaseSingleton<ScrapyardManager>.Instance.CanAssemble())
			{
				ButtonScale.enabled = true;
				if (_hover)
				{
					_buttons.ForEach(delegate(UIButton b)
					{
						b.SetState(UIButtonColor.State.Hover, true);
					});
				}
				else
				{
					_buttons.ForEach(delegate(UIButton b)
					{
						b.SetState(UIButtonColor.State.Normal, true);
					});
				}
			}
			else
			{
				ButtonScale.enabled = false;
				_buttons.ForEach(delegate(UIButton b)
				{
					b.SetState(UIButtonColor.State.Disabled, true);
				});
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}

		public void OnClick()
		{
			BaseSingleton<ScrapyardManager>.Instance.AssembleNewItem();
		}
	}
}
