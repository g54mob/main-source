using System;
using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class DialogueObjective : CTSSingleton<DialogueObjective>, ILockable
	{
		[SerializeField]
		private Image _characterImage;

		[SerializeField]
		private Image _countdownFill;

		[SerializeField]
		private CTSButton _button;

		[SerializeField]
		private float _countdownDuration = 30f;

		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private QuestTrackerQuestHandler _questHandler;

		private string _dialogueToStart;

		private Coroutine _currentRoutine;

		private LockToggle _visibilityLock = new LockToggle();

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public static event Action ObjectiveCompleted;

		protected override void SingletonAwake()
		{
			base.gameObject.SetActive(value: false);
			_visibilityLock.Add(this);
			_button.onClick.AddListener(OnButtonClicked);
			QuestTrackerManager.CurrentQuestChanged += OnCurrentQuestChanged;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_questHandler.InvertColors(invert: true);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_questHandler.InvertColors(invert: false);
		}

		protected override void OnSingletonDestroy()
		{
			QuestTrackerManager.CurrentQuestChanged -= OnCurrentQuestChanged;
		}

		private void OnCurrentQuestChanged(Quest obj)
		{
			if ((object)obj != null)
			{
				_visibilityLock.SetLock(!obj.QuestName.Contains("Main"));
			}
		}

		public void SetObjective(MainCharacterData character, string dialogue, float startTime)
		{
			_characterImage.overrideSprite = character.SquareIcon;
			_dialogueToStart = dialogue;
			_currentRoutine = base.gameObject.scene.StartCoroutine(Countdown(startTime));
			SetActive(value: true);
		}

		private void OnButtonClicked()
		{
			if (_currentRoutine != null)
			{
				base.gameObject.scene.StopCoroutine(_currentRoutine);
			}
			_currentRoutine = base.gameObject.scene.StartCoroutine(DialogueRoutine());
		}

		private IEnumerator Countdown(float startTime)
		{
			float endTime = startTime + _countdownDuration;
			while (Time.unscaledTime < endTime)
			{
				_countdownFill.fillAmount = Time.unscaledTime.Remap(startTime, endTime, 0f, 1f);
				yield return null;
			}
			_countdownFill.fillAmount = 1f;
			CanvasGroupManager canvasManager = MonoSingleton<CanvasGroupManager>.Instance;
			while (canvasManager.OpenedControllers.Count > 0 || Time.timeScale <= 0f)
			{
				yield return null;
			}
			_currentRoutine = null;
			OnButtonClicked();
		}

		private IEnumerator DialogueRoutine()
		{
			yield return DialogueHelper.DialogueCoroutine(_dialogueToStart);
			DialogueObjective.ObjectiveCompleted?.Invoke();
			_currentRoutine = null;
			SetActive(value: false);
		}

		private void SetActive(bool value)
		{
			bool flag = !ObjectLock && value && _currentRoutine != null;
			if (flag != base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(flag);
			}
		}

		void ILockable.OnLocked()
		{
			SetActive(value: false);
		}

		void ILockable.OnUnlocked()
		{
			SetActive(value: true);
		}
	}
}
