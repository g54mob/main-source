using DG.Tweening;
using Restory.Data.ReadWriteServices;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_ReadWriteIndicationCanvas : MonoBehaviour, IInitializable
	{
		[SerializeField]
		private GameObject saveIcon;

		[SerializeField]
		private float showSaveIconDuration = 0.25f;

		[SerializeField]
		private float hideSaveIconDuration = 0.125f;

		private IReadWriteDataService saveLoadSystem;

		private Sequence mainSequence;

		private TweenSequencesService tweenSequencesService;

		[Inject]
		private void Construct(IReadWriteDataService saveLoadSystem, TweenSequencesService tweenSequencesService)
		{
			this.saveLoadSystem = saveLoadSystem;
			this.tweenSequencesService = tweenSequencesService;
		}

		public void Initialize()
		{
			saveLoadSystem.OnWriteBegin += ShowWriteIcon;
			saveLoadSystem.OnWriteFailed += HideWriteIcon;
			saveLoadSystem.OnWriteCompleted += HideWriteIcon;
			saveIcon.transform.localScale = Vector3.zero;
		}

		private void OnDestroy()
		{
			if (saveLoadSystem != null)
			{
				saveLoadSystem.OnWriteBegin -= ShowWriteIcon;
				saveLoadSystem.OnWriteFailed -= HideWriteIcon;
				saveLoadSystem.OnWriteCompleted -= HideWriteIcon;
			}
		}

		private void ShowWriteIcon(FileType fileType)
		{
			KillActiveTween();
			mainSequence = tweenSequencesService.Create();
			mainSequence.Append(saveIcon.transform.DOScale(1.1f, showSaveIconDuration * 0.8f));
			mainSequence.Append(saveIcon.transform.DOScale(1f, showSaveIconDuration * 0.2f));
			mainSequence.SetUpdate(isIndependentUpdate: true);
		}

		private void HideWriteIcon(FileType fileType)
		{
			KillActiveTween();
			mainSequence = DOTween.Sequence();
			mainSequence.Append(saveIcon.transform.DOScale(1.1f, hideSaveIconDuration * 0.5f));
			mainSequence.Append(saveIcon.transform.DOScale(0f, hideSaveIconDuration * 0.5f));
			mainSequence.SetUpdate(isIndependentUpdate: true);
		}

		private void KillActiveTween()
		{
			if (mainSequence != null && mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
		}
	}
}
