using ModApi.Audio;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class ButtonScript : MonoBehaviour
	{
		public enum ButtonClickSound
		{
			None = 0,
			DefaultClick = 1
		}

		private Button _button;

		[SerializeField]
		private ButtonClickSound _clickSound = ButtonClickSound.DefaultClick;

		private bool _selected;

		public bool Interactable
		{
			get
			{
				return _button.interactable;
			}
			set
			{
				_button.interactable = value;
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
				}
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				if (Visible != value)
				{
					base.gameObject.SetActive(value);
				}
			}
		}

		public void AddClickListener(UnityAction call)
		{
			GetComponent<Button>().onClick.AddListener(call);
		}

		protected virtual void Awake()
		{
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClicked);
		}

		protected virtual void OnClicked()
		{
			if (_clickSound == ButtonClickSound.DefaultClick)
			{
				Game.Instance.AudioPlayer.PlaySound(AudioLibrary.ButtonClicked);
			}
		}
	}
}
