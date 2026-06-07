using System;
using System.Collections.Generic;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class IfDecisionButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private BasicAnimationEventObserver _animationObserver;

		[SerializeField]
		private TextBlock3DUIView _numberPart;

		[SerializeField]
		private TextBlock3DUIView _labelPart;

		[SerializeField]
		private GameObject _defaultNumberBacker;

		[SerializeField]
		private FateSpinnerChance3DUIView _fateSpinnerChance3DUIView;

		[SerializeField]
		private Animator _animator;

		private Action _onLanguageChanged;

		private List<ParticleCleanUp> _particleCleanUps;

		public TextBlock3DUIView GetLabelPart()
		{
			return null;
		}

		protected override void Start()
		{
		}

		private void LabelPartOnLanguageChanged(object sender, EventArgs e)
		{
		}

		public void SetDecision(int number, NotificationDecision decision)
		{
		}

		public void ShowFateInfo()
		{
		}

		protected override void OnHoveredChanged()
		{
		}

		protected override void OnSelectedChanged()
		{
		}

		public void SetAsNotChosen()
		{
		}

		private void DeSelectOtherButtons()
		{
		}

		private void _animationObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
