using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ButtonMultiTransition : MonoBehaviour
	{
		private Button button;

		[SerializeField]
		private Animator[] animators;

		public void Start()
		{
			if (button == null)
			{
				button = base.gameObject.GetComponent<Button>();
			}
			button.onClick.AddListener(OnButtonClick);
		}

		public void OnButtonClick()
		{
			for (int i = 0; i < animators.Length; i++)
			{
				animators[i].Play("Transition", 0, 0f);
			}
		}
	}
}
