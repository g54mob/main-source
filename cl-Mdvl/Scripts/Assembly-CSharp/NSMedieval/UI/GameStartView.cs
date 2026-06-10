using System.Collections;
using System.Text;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Sound;
using UnityEngine;

namespace NSMedieval.UI
{
	public class GameStartView : ClosableUIView
	{
		[Header("Linked Screens")]
		[SerializeField]
		private ClosableUIView previousScreen;

		[SerializeField]
		private ClosableUIView nextScreen;

		[SerializeField]
		private CanvasGroupFader[] canvasGroupFaders;

		[Header("Navigation Buttons")]
		[SerializeField]
		private SoundButton previousButton;

		[SerializeField]
		private SoundButton nextButton;

		[SerializeField]
		private MoreInfoPanel moreInfoPanel;

		private bool gameStartIsShowing;

		protected StringBuilder Sb = new StringBuilder();

		protected ClosableUIView NextScreen => nextScreen;

		protected ClosableUIView PreviousScreen => previousScreen;

		protected SoundButton PreviousButton => previousButton;

		protected SoundButton NextButton => nextButton;

		protected GameStartController StartController => MonoSingleton<GameStartController>.Instance;

		protected MoreInfoPanel MoreInfoPanel => moreInfoPanel;

		protected virtual void Awake()
		{
			previousButton.onClick.RemoveAllListeners();
			nextButton.onClick.RemoveAllListeners();
			previousButton.onClick.AddListener(OnClickPrevious);
			nextButton.onClick.AddListener(OnClickNext);
		}

		protected void ShowScreen(ClosableUIView screen)
		{
			base.SceneUIManager.ShowNewView(screen);
		}

		protected virtual void OnClickNext()
		{
			base.SceneUIManager.ShowNewView(nextScreen);
		}

		protected virtual void OnClickPrevious()
		{
			base.SceneUIManager.ShowNewView(previousScreen);
			if (this is ScenarioView)
			{
				gameStartIsShowing = false;
				MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.None);
			}
		}

		public override void Show()
		{
			base.Show();
			CanvasGroupFader[] array = canvasGroupFaders;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].FadeIn();
			}
			if (!gameStartIsShowing && this is ScenarioView)
			{
				gameStartIsShowing = true;
				MonoSingleton<MixerSnapshotManager>.Instance.ActivateSnapshot(Snapshot.NewGameSnapshot);
			}
		}

		public override void Hide()
		{
			StartCoroutine(HideCr());
		}

		private IEnumerator HideCr()
		{
			float num = 0f;
			CanvasGroupFader[] array = canvasGroupFaders;
			foreach (CanvasGroupFader canvasGroupFader in array)
			{
				if (canvasGroupFader.FadeOutDuration > num)
				{
					num = canvasGroupFader.FadeOutDuration;
				}
				canvasGroupFader.FadeOut();
			}
			yield return new WaitForSeconds(num);
			base.Hide();
		}

		public void ForceNext()
		{
			OnClickNext();
		}
	}
}
