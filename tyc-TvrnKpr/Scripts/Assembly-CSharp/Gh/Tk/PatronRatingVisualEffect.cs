using System;
using DG.Tweening;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class PatronRatingVisualEffect : MonoBehaviour, IPersistable, ICustomSaveState, ILateRestoreState
	{
		public static PrefabObjectPool _patronRatingPool;

		[SerializeField]
		private GameObject _positiveRatingVisual;

		[SerializeField]
		private Color _positiveRatingColor;

		[SerializeField]
		private GameObject _middleRatingVisual;

		[SerializeField]
		private Color _middleRatingColor;

		[SerializeField]
		private GameObject _negativeRatingVisual;

		[SerializeField]
		private Color _negativeRatingColor;

		[SerializeField]
		private GameObject _numberBacker;

		[SerializeField]
		private TextMeshProI18n _ratingText;

		[PersistenceOptIn]
		private int _rating;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int _displayRating;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private Patron _followPatron;

		private const float DEFAULT_DISPLAY_TIME = 4f;

		[PersistenceOptIn]
		private float _remainingDisplayTime;

		private bool _shouldBeVisible;

		private Transform _cachedPelvis;

		private float _cachedHeight;

		[SerializeField]
		private Transform _scalerTransform;

		private Tween _transitionTween;

		[SerializeField]
		private float _introTransitionDuration;

		[SerializeField]
		private float _outroTransitionDuration;

		[SerializeField]
		private Ease _introTransitionEase;

		[SerializeField]
		private Ease _outroTransitionEase;

		[PersistenceOptIn]
		private bool _introAnimationPlayed;

		private Ease _ratingEase;

		private Tween _textTween;

		[PersistenceOptIn]
		private bool _textAnimationPlayed;

		public static void TriggerRatingEffect(Patron patron, int rating)
		{
		}

		private void ResetTransform()
		{
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Handback(object sender, EventArgs e)
		{
		}

		private void Handback()
		{
		}

		private void OnActorDespawned(object sender, EventArgs<Actor> e)
		{
		}

		private void UpdateRatingVisual()
		{
		}

		private void SetFollowPatron(Patron patron)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private bool ShouldBeVisible()
		{
			return false;
		}

		private void UpdateFollowPatron()
		{
		}

		private void PrepareIntro()
		{
		}

		private void PlayIntroAnimation()
		{
		}

		private void PlayTextTween()
		{
		}

		private void PlayOutroAnimation()
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}

		public void LateRestoreState(IDataStore data)
		{
		}
	}
}
