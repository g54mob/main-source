using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class MasterMemoDialog : BaseDialog
	{
		[SerializeField]
		private RectTransform contentsParent;

		[SerializeField]
		private GameObject touchButtonObj;

		[Header("AnimationObjects")]
		[SerializeField]
		private SkeletonGraphic minion;

		[SerializeField]
		private Image paper;

		[SerializeField]
		private float animationStartPosY;

		private int _openMemoIndex;

		private UnityAction callback;

		private bool isFinishedContents;

		private List<MasterMemoSheetCtrl> _masterMemoSheetCtrls;

		private Dictionary<GameObject, float> recordPositionY;

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void OpenInit()
		{
		}

		private void StartContents()
		{
		}

		private void PlayOpenAnimation(float duration, UnityAction callback = null)
		{
		}

		private void PlayCloseAnimation(float duration, UnityAction callback = null)
		{
		}

		private void SetAlpha(Graphic target, float alpha)
		{
		}

		private void SetPosition(RectTransform target, float posY)
		{
		}

		private void PlayContents()
		{
		}

		private void GetSheetCtrls(eMasterMemo[] memos)
		{
		}

		public override void PushEscape()
		{
		}

		public override void SetInFront()
		{
		}

		public void OnClickAnywhere()
		{
		}

		private void DisablePreviousContents()
		{
		}

		public void FinishReadMemo()
		{
		}

		public override void PlayOpenSound()
		{
		}
	}
}
