using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.GuiNew
{
	public class ButtonScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler
	{
		public delegate void ButtonClickDelegate(ButtonScript button);

		private Text _text;

		public string Text
		{
			get
			{
				return _text.text;
			}
			set
			{
				_text.text = value;
			}
		}

		public event ButtonClickDelegate Clicked;

		public void OnPointerClick(PointerEventData eventData)
		{
			Game.Instance.UserInterface.Sound.PlaySound(UISound.ButtonClick);
			if (this.Clicked != null)
			{
				this.Clicked(this);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		protected virtual void Awake()
		{
			Text[] componentsInChildren = GetComponentsInChildren<Text>(includeInactive: true);
			if (componentsInChildren.Length == 1)
			{
				_text = componentsInChildren[0];
			}
		}
	}
}
