using System;
using System.Collections.Generic;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RibbonHireRow : MonoBehaviour
	{
		[Serializable]
		public struct JobApplicantGUI
		{
			public RawImage ApplicantMugShotImage;

			public TMP_Text ApplicantName;

			public TMP_Text ApplicantSalary;

			public DynamicButton HireButton;

			public DynamicButton RejectButton;

			public StarIcons StarIcons;

			public QualificationIcons QualificationIcons;

			public GameObject PolaroidGameObject;

			public RectTransform PolaroidPivot;

			public IntCellComparable RankCellComparable;

			public IntCellComparable QualificationsCellComparable;

			public IntCellComparable SalaryCellComparable;
		}

		[Serializable]
		public struct PendingGUI
		{
			public GameObject Root;

			public ProgressBarMaskable ProgressBarMaskable;

			public TMP_Text TimeRemainingText;
		}

		[Serializable]
		public struct LockedGUI
		{
			public GameObject Root;

			public ProgressBarMaskable ProgressBarMaskable;

			public TMP_Text Text;
		}

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private ButtonAnimator _buttonAnimator;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private LocalisedString _lockedApplicantSlotString;

		[SerializeField]
		private JobApplicantGUI _jobApplicantGUI;

		[SerializeField]
		private PendingGUI _pendingGUI;

		[SerializeField]
		private LockedGUI _lockedGUI;

		[Header("Assets")]
		[SerializeField]
		private Sprite _selectedBackgroundSprite;

		[SerializeField]
		private Sprite _backgroundSpriteEven;

		[SerializeField]
		private Sprite _backgroundSpriteOdd;

		[SerializeField]
		private Sprite _selectedQualificatonSlotSprite;

		private int _unlockLevel;

		private PrestigeTracker _prestigeTracker;

		private JobApplicant _jobApplicant;

		private JobApplicantPool _jobApplicantPool;

		private GameObject _applicantVisual;

		private CharacterMugShot _characterMugShot;

		private List<CharModule.ModuleInstance> _moduleInstances;

		public DynamicButton Button => _button;

		public ButtonAnimator ButtonAnimator => _buttonAnimator;

		public DynamicButton HireButton => _jobApplicantGUI.HireButton;

		public DynamicButton RejectButton => _jobApplicantGUI.RejectButton;

		public JobApplicant JobApplicant => _jobApplicant;

		public void SetupAsJobApplicant(JobApplicant jobApplicant, HUD.MugshotConfig mugshotConfig, Level level)
		{
			_backgroundImage.enabled = true;
			RefreshAlternatingBackground();
			_jobApplicant = jobApplicant;
			_applicantVisual = new GameObject("Applicant Mugshot");
			_pendingGUI.ProgressBarMaskable.gameObject.SetActive(value: false);
			_lockedGUI.ProgressBarMaskable.gameObject.SetActive(value: false);
			GameObject gameObject = UnityEngine.Object.Instantiate(jobApplicant.Definition.RigPrefab, _applicantVisual.transform, worldPositionStays: false);
			gameObject.name = jobApplicant.Definition.RigPrefab.name;
			Transform transform = gameObject.transform.FindChildRecursively(CharacterVisual.HeadSocketName);
			Animator[] componentsInChildren = gameObject.GetComponentsInChildren<Animator>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.Destroy(componentsInChildren[i]);
			}
			_moduleInstances = new List<CharModule.ModuleInstance>(32);
			CharModuleUtils.BuildModularCharacterGameObject(_jobApplicant.CharModuleAssets, _applicantVisual.transform, gameObject.GetComponentsInChildren<Transform>(), instantiateMaterials: true, level.CharacterManager.GetDefaultSaffCustomisationOption(_jobApplicant.Definition._type)?.MeshMaterialBinding, _moduleInstances);
			_applicantVisual.SetLayerRecursively(LayerMask.NameToLayer("Metagame"));
			foreach (CharModule.ModuleInstance moduleInstance in _moduleInstances)
			{
				moduleInstance.Renderer.allowOcclusionWhenDynamic = false;
				moduleInstance.Renderer.gameObject.layer = LayerMask.NameToLayer("Metagame");
				Material[] originalMaterials = moduleInstance.OriginalMaterials;
				for (int i = 0; i < originalMaterials.Length; i++)
				{
					TH20Standard.EnableRoomLighting(originalMaterials[i]);
				}
			}
			Animator animator = _applicantVisual.AddComponent<Animator>();
			animator.avatar = jobApplicant.Definition._avatar;
			animator.updateMode = AnimatorUpdateMode.UnscaledTime;
			_characterMugShot = new CharacterMugShot(transform.position, Quaternion.AngleAxis(0f, Vector3.up), _moduleInstances, 256, 256, mugshotConfig);
			_jobApplicantGUI.ApplicantMugShotImage.texture = _characterMugShot.Texture;
			SetJobApplicantGUIEnabled(enabled: true);
			_pendingGUI.Root.SetActive(value: false);
			_lockedGUI.Root.SetActive(value: false);
			_jobApplicantGUI.ApplicantName.text = jobApplicant.Name.GetCharacterName();
			_jobApplicantGUI.StarIcons.SetLevel(jobApplicant.Rank, readyForPromotion: false);
			_jobApplicantGUI.QualificationIcons.UpdateFrom(_jobApplicant.Qualifications, _jobApplicant.MaxQualifications, level.CharacterManager.StaffMembers);
			_jobApplicantGUI.ApplicantSalary.text = StringUtils.FormatCurrency(_jobApplicant.Salary);
			_jobApplicantGUI.SalaryCellComparable.Value = _jobApplicant.Salary;
			_jobApplicantGUI.RankCellComparable.Value = _jobApplicant.Rank;
			_jobApplicantGUI.QualificationsCellComparable.Value = _jobApplicant.Qualifications.Count;
			float z = new System.Random(jobApplicant.Salary).NextFloat(-10f, 10f);
			_jobApplicantGUI.PolaroidPivot.localRotation = Quaternion.Euler(0f, 0f, z);
			_buttonAnimator.OnChangeState.AddListener(OnButtonAnimatorChangeState);
			_button.interactable = true;
		}

		protected void LateUpdate()
		{
			if (_jobApplicant != null)
			{
				RefreshAlternatingBackground();
			}
		}

		public void SetupAsPendingApplicant(JobApplicantPool jobApplicantPool)
		{
			_backgroundImage.enabled = true;
			_jobApplicantPool = jobApplicantPool;
			bool active = jobApplicantPool != null;
			SetJobApplicantGUIEnabled(enabled: false);
			_pendingGUI.Root.SetActive(active);
			_lockedGUI.Root.SetActive(value: false);
			_pendingGUI.ProgressBarMaskable.gameObject.SetActive(active);
			_lockedGUI.ProgressBarMaskable.gameObject.SetActive(value: false);
			_button.interactable = false;
			_buttonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
			if (_jobApplicantPool != null)
			{
				JobApplicantPool jobApplicantPool2 = _jobApplicantPool;
				jobApplicantPool2.OnNextApplicantProgressUpdated = (Action<float>)Delegate.Combine(jobApplicantPool2.OnNextApplicantProgressUpdated, new Action<float>(UpdatePendingProgress));
			}
			base.gameObject.AddComponent<UnsortedRow>();
		}

		public void SetupAsLockedEntry(PrestigeTracker prestigeTracker, int unlockLevel)
		{
			_backgroundImage.enabled = false;
			_prestigeTracker = prestigeTracker;
			_unlockLevel = unlockLevel;
			PrestigeTracker prestigeTracker2 = _prestigeTracker;
			prestigeTracker2.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Combine(prestigeTracker2.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedEvent));
			SetJobApplicantGUIEnabled(enabled: false);
			_pendingGUI.Root.SetActive(value: false);
			_lockedGUI.Root.SetActive(value: true);
			_button.interactable = false;
			_buttonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
			_pendingGUI.ProgressBarMaskable.gameObject.SetActive(value: false);
			_lockedGUI.ProgressBarMaskable.gameObject.SetActive(value: true);
			_lockedGUI.Text.text = _lockedApplicantSlotString.Translation.Replace("{[LEVEL]}", unlockLevel.ToString());
			RefreshPendingProgressBar();
			base.gameObject.AddComponent<UnsortedRow>();
		}

		public void SetCanHire(bool canHire)
		{
			if (HireButton != null)
			{
				HireButton.interactable = canHire;
				HireButton.GetComponent<ButtonAnimator>().CurrentState = ((!canHire) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
		}

		private void RefreshAlternatingBackground()
		{
			if (base.transform.GetSiblingIndex() % 2 == 0)
			{
				if (_backgroundImage.sprite != _backgroundSpriteEven)
				{
					_backgroundImage.sprite = _backgroundSpriteEven;
				}
			}
			else if (_backgroundImage.sprite != _backgroundSpriteOdd)
			{
				_backgroundImage.sprite = _backgroundSpriteOdd;
			}
		}

		private void OnPrestigeChangedEvent(PrestigeTracker prestigeTracker)
		{
			RefreshPendingProgressBar();
		}

		private void RefreshPendingProgressBar()
		{
			_lockedGUI.ProgressBarMaskable.SetProgressSmooth(((float)_prestigeTracker.Level + _prestigeTracker.Progress) / (float)_unlockLevel);
		}

		private void OnButtonAnimatorChangeState(ButtonAnimator.State state)
		{
			Image[] qualificationSlots = _jobApplicantGUI.QualificationIcons.QualificationSlots;
			foreach (Image image in qualificationSlots)
			{
				if (state == ButtonAnimator.State.Selected)
				{
					image.overrideSprite = _selectedQualificatonSlotSprite;
				}
				else
				{
					image.overrideSprite = null;
				}
			}
		}

		private void SetJobApplicantGUIEnabled(bool enabled)
		{
			_jobApplicantGUI.ApplicantName.gameObject.SetActive(enabled);
			_jobApplicantGUI.StarIcons.gameObject.SetActive(enabled);
			if (_jobApplicantGUI.HireButton != null)
			{
				_jobApplicantGUI.HireButton.gameObject.SetActive(enabled);
			}
			if (_jobApplicantGUI.RejectButton != null)
			{
				_jobApplicantGUI.RejectButton.gameObject.SetActive(enabled);
			}
			_jobApplicantGUI.QualificationIcons.gameObject.SetActive(enabled);
			_jobApplicantGUI.PolaroidGameObject.SetActive(enabled);
			_jobApplicantGUI.ApplicantSalary.gameObject.SetActive(enabled);
		}

		private void UpdatePendingProgress(float progress)
		{
			if (_pendingGUI.ProgressBarMaskable != null)
			{
				_pendingGUI.ProgressBarMaskable.SetProgressSmooth(progress);
			}
			if (_pendingGUI.TimeRemainingText != null)
			{
				int numberOfDays = Mathf.CeilToInt(_jobApplicantPool.NextApplicantProgressRemainingTime() / GameAlgorithms.Config.SecondsPerDay);
				_pendingGUI.TimeRemainingText.text = $"{GameStringUtils.GetDaysString(numberOfDays)}";
			}
		}

		private void OnDestroy()
		{
			if (_jobApplicantPool != null)
			{
				JobApplicantPool jobApplicantPool = _jobApplicantPool;
				jobApplicantPool.OnNextApplicantProgressUpdated = (Action<float>)Delegate.Remove(jobApplicantPool.OnNextApplicantProgressUpdated, new Action<float>(UpdatePendingProgress));
			}
			if (_characterMugShot != null)
			{
				_characterMugShot.Destroy();
			}
			if (_moduleInstances != null)
			{
				CharModuleUtils.DestroyModularInstances(_moduleInstances);
			}
			if (_prestigeTracker != null)
			{
				PrestigeTracker prestigeTracker = _prestigeTracker;
				prestigeTracker.OnPrestigeChangedEvent = (Action<PrestigeTracker>)Delegate.Remove(prestigeTracker.OnPrestigeChangedEvent, new Action<PrestigeTracker>(OnPrestigeChangedEvent));
			}
			if (_applicantVisual != null)
			{
				UnityEngine.Object.Destroy(_applicantVisual);
			}
		}
	}
}
