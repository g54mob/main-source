using NSEipix.Base;
using NSEipix.View.UI;
using UnityEngine;

namespace NSMedieval.UI
{
	public class OptionsMainView : ClosableUIView
	{
		[SerializeField]
		private SoundButton doneButton;

		[SerializeField]
		private SoundButton[] sectionButtons;

		[SerializeField]
		private OptionsView[] optionsViews;

		private const int twitchButton = 6;

		private void Start()
		{
			for (int i = 0; i < sectionButtons.Length; i++)
			{
				int index = i;
				sectionButtons[index].onClick.AddListener(delegate
				{
					OnChangeView(index);
				});
			}
			doneButton.onClick.AddListener(CloseSelf);
		}

		public override void Hide()
		{
			MonoSingleton<GlobalSaveController>.Instance.Serialize();
			base.Hide();
		}

		private void OnChangeView(int index)
		{
			if (index < optionsViews.Length)
			{
				for (int i = 0; i < optionsViews.Length; i++)
				{
					if (i == index)
					{
						optionsViews[i].Show();
					}
					else
					{
						optionsViews[i].Hide();
					}
				}
			}
			else
			{
				OptionsView[] array = optionsViews;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Hide();
				}
			}
		}
	}
}
