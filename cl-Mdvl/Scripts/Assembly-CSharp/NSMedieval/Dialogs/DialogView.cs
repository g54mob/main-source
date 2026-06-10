using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Dialogs.Data;
using NSMedieval.Manager;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.Dialogs
{
	public class DialogView : PopupView
	{
		private const string ShowAnimation = "DialogCenterIn";

		private const string HideAnimation = "DialogCenterOut";

		[SerializeField]
		private GameObject dialog;

		[SerializeField]
		private List<DialogOptionButtonLayoutItemView> buttons;

		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private TMP_Text windowTitle;

		[SerializeField]
		private TMP_Text contentTitle;

		[SerializeField]
		private TMP_Text contentBody;

		[SerializeField]
		private Image contentBodyImage;

		[SerializeField]
		private Animator fadeAnimator;

		private void Start()
		{
			MainView = dialog;
		}

		private void SetContent(DialogContent content)
		{
			windowTitle.text = content.WindowTitle;
			contentTitle.text = content.ContentTitle;
			contentBody.text = content.ContentBodyText;
			contentBodyImage.sprite = AssetUtils.GetSprite(content.ContentBodyImagePath);
			buttons.SetAllActive(active: false);
			foreach (DialogOption option in content.Options)
			{
				DialogOptionButtonLayoutItemView next = buttons.GetNext();
				next.SetTooltipData(option.Tooltips);
				next.SetTextData(option.Text);
				next.Button.AddCleanListener(delegate
				{
					option.OnSelected?.Invoke();
				});
				next.Button.interactable = !option.Disabled;
				next.TooltipNew.SetEnabled(option.Disabled);
				if (option.Disabled)
				{
					next.TooltipNew.SetSingleLineTooltip(option.DisabledTooltip);
				}
			}
			if (!content.ShowCloseButton)
			{
				closeButton.gameObject.SetActive(value: false);
				MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: true);
			}
			else if (content.Options.Count > 0)
			{
				closeButton.gameObject.SetActive(value: true);
				closeButton.AddCleanListener(delegate
				{
					content.Options[0].OnSelected?.Invoke();
				});
				MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Hide, MainView);
			}
			LayoutRebuilder.MarkLayoutForRebuild(base.transform as RectTransform);
		}

		protected override void OnShow()
		{
			fadeAnimator.Play("DialogCenterIn");
		}

		protected override void OnHide()
		{
			base.OnHide();
			MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: false);
		}

		public override void Hide()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(5, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Dialog\\DialogView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(this);
				messageBuilder.AppendLiteral(" Hide");
			}
			Log.Debug(messageBuilder);
			fadeAnimator.Play("DialogCenterOut");
			float clipLenght = 0.2f;
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				clipLenght = fadeAnimator.GetCurrentAnimatorStateInfo(0).length;
				bool isEnabled2;
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(12, 1, out isEnabled2, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Dialog\\DialogView.cs");
				if (isEnabled2)
				{
					messageBuilder2.AppendLiteral("Waiting for ");
					messageBuilder2.AppendFormatted(clipLenght);
				}
				Log.Trace(messageBuilder2);
			}).ThenWaitFor(clipLenght, isUnscaled: true)
				.Then(base.Hide);
		}

		public void Open(DialogContent content)
		{
			Show();
			SetContent(content);
		}

		public void Close()
		{
			Hide();
		}
	}
}
