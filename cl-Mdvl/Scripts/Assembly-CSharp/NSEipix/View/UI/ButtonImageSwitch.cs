using UnityEngine;

namespace NSEipix.View.UI
{
	[RequireComponent(typeof(SoundButton))]
	public class ButtonImageSwitch : MonoBehaviour
	{
		[SerializeField]
		private bool isOn;

		[SerializeField]
		private Sprite onImage;

		[SerializeField]
		private Sprite offImage;

		[SerializeField]
		private bool ignoreClick;

		private SoundButton button;

		public bool IsOn => isOn;

		public bool IgnoreClick
		{
			get
			{
				return ignoreClick;
			}
			set
			{
				ignoreClick = value;
			}
		}

		public void ShowOffGraphics()
		{
			if (!(button == null) && !(offImage == null))
			{
				button.image.sprite = offImage;
			}
		}

		public void ShowOnGraphics()
		{
			if (!(button == null) && !(onImage == null))
			{
				button.image.sprite = onImage;
			}
		}

		private void Awake()
		{
			button = GetComponent<SoundButton>();
		}

		private void Start()
		{
			button.PointerClickEvent += OnButtonClick;
		}

		private void OnButtonClick()
		{
			if (!ignoreClick)
			{
				isOn = !isOn;
				Sprite sprite = (isOn ? onImage : offImage);
				button.image.sprite = sprite;
			}
		}
	}
}
