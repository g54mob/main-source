using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class StarRevealDialog3DUIView : BaseDialog3DUIView
	{
		[Serializable]
		public class StarRevealConfig
		{
			public GameLevel level;

			public List<BaseStarReveal3DUIView> reveals;
		}

		[SerializeField]
		private Transform _starRevealParent;

		public Animator[] stars;

		private List<BaseStarReveal3DUIView> _starReveals;

		public List<StarRevealConfig> levelReveals;

		public BaseStarReveal3DUIView fallbackReveal;

		[SerializeField]
		private Button3DUIView _skipButton;

		private bool _isStarAdded;

		private BaseStarReveal3DUIView _currentReveal;

		private static readonly int AddStar;

		[SerializeField]
		private GameObject _backgroundObj;

		public bool IsStarAddPending => false;

		public string PreferStarRevealWithNameOnce { get; set; }

		protected override void Awake()
		{
		}

		private List<BaseStarReveal3DUIView> GetStarRevealsForLevel()
		{
			return null;
		}

		private void Start()
		{
		}

		public override void Open(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		protected override void OnAnimEventInternal(object sender, AnimationEventArgs e)
		{
		}

		public bool IsAnimating()
		{
			return false;
		}

		public void AnimEventAddStar()
		{
		}

		public void ShowBackground()
		{
		}

		public void HideBackground()
		{
		}

		private void HideAllStarReveals()
		{
		}

		public void IncreaseStars()
		{
		}

		public override void BackOrClose()
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		public override void Back()
		{
		}
	}
}
