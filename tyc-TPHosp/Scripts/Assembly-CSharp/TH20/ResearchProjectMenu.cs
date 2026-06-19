using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchProjectMenu : AnimatedMenuBase, IPauseTimeMenu
	{
		[InspectorMargin(8)]
		[InspectorHeader("Selection")]
		[SerializeField]
		private Table _table;

		[SerializeField]
		private GameObject _rowPrefab;

		[SerializeField]
		private DynamicButton _buttonStart;

		[SerializeField]
		private ButtonAnimator _buttonStartAnimator;

		[SerializeField]
		private Image _buttonStartImage;

		[SerializeField]
		private TMP_Text _buttonStartText;

		[InspectorMargin(8)]
		[InspectorHeader("Project Panel")]
		[SerializeField]
		private Image _projectIcon;

		[SerializeField]
		private TMP_Text _projectName;

		[SerializeField]
		private TMP_Text _projectDescription;

		[SerializeField]
		private TMP_Text _projectRewards;

		[SerializeField]
		private TMP_Text _projectPrerequisites;

		[SerializeField]
		private ProgressBarMaskable _projectProgressBar;

		[SerializeField]
		private TMP_Text _projectProgressText;

		[SerializeField]
		private TMP_Text _projectGreenlightFee;

		[SerializeField]
		private Color _projectGreenlightFeeAffordable = Color.white;

		[SerializeField]
		private Color _projectGreenlightFeeUnaffordable = Color.red;

		private Level _level;

		private RoomItem _roomItem;

		private ResearchProject _project;

		private readonly List<GameObject> _listRows = new List<GameObject>();

		public void Setup(Level level, RoomItem roomItem)
		{
			_level = level;
			_roomItem = roomItem;
			_buttonStart.onPrimaryDown.AddListener(OnStart);
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Combine(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			_level.HospitalHUDManager.HideRibbonMenu();
			_level.HospitalHUDManager.HideAllInfoMenus();
			BuildListRows();
			LocalizationManager.OnLocalizeEvent += OnLocalize;
		}

		public override void Destroy()
		{
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Remove(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		private void BuildListRows()
		{
			List<ResearchProject> allProjectsForLevel = _level.ResearchManager.GetAllProjectsForLevel(_level);
			_listRows.ClearAndDestroy();
			if (allProjectsForLevel.Count == 0)
			{
				SetStartButtonState(buttonEnabled: false);
				return;
			}
			foreach (ResearchProject item in allProjectsForLevel)
			{
				GameObject gameObject = _table.InstantiateAsRow(_rowPrefab);
				gameObject.GetComponent<ResearchProjectListItem>().Initialise(item, SelectProject);
				_listRows.Add(gameObject);
			}
			SelectProject(allProjectsForLevel[0]);
		}

		private void OnRibbonMenuEnterMode(RibbonMenu.Mode mode)
		{
			CloseMenu();
		}

		private void OnMenuOpen(MenuBase menuBase)
		{
			if (menuBase != this)
			{
				if (base.isActiveAndEnabled)
				{
					CloseMenu();
				}
				else
				{
					CloseMenuImmediately();
				}
			}
		}

		public void OnLocalize()
		{
			string text = "";
			if (_project != null)
			{
				text = _project.Definition.NameLocalised.Term;
			}
			BuildListRows();
			foreach (GameObject listRow in _listRows)
			{
				ResearchProjectListItem component = listRow.GetComponent<ResearchProjectListItem>();
				if (component != null && component.GetProject().Definition.NameLocalised.Term == text)
				{
					SelectProject(component.GetProject());
					break;
				}
			}
		}

		private void SelectProject(ResearchProject researchProject)
		{
			ResearchProjectDefinition definition = researchProject.Definition;
			bool flag = _level.FinanceManager.CanAfford(definition.GreenlightCost);
			_project = researchProject;
			_projectIcon.sprite = definition.Icon;
			_projectName.text = definition.NameLocalised.Translation;
			_projectDescription.text = definition.DescriptionLocalised.Translation;
			_projectRewards.text = ScriptLocalization.Menu_Research.Output_CS + ": " + RewardUtils.GetFullRewardString(null, definition.Rewards);
			_projectProgressBar.Progress = _project.ResearchedPoints / _project.Definition.ResearchPoints;
			_projectProgressText.text = $"{(int)_project.ResearchedPoints} / {(int)_project.Definition.ResearchPoints}";
			_projectGreenlightFee.text = StringUtils.FormatCurrency(definition.GreenlightCost);
			_projectGreenlightFee.color = (flag ? _projectGreenlightFeeAffordable : _projectGreenlightFeeUnaffordable);
			SetStartButtonState(flag);
			foreach (GameObject listRow in _listRows)
			{
				ResearchProjectListItem component = listRow.GetComponent<ResearchProjectListItem>();
				if (component != null)
				{
					component.OnSelected(component.GetProject() == researchProject);
				}
			}
		}

		private void SetStartButtonState(bool buttonEnabled)
		{
			if (_buttonStart.interactable != buttonEnabled)
			{
				_buttonStart.interactable = buttonEnabled;
				_buttonStartAnimator.CurrentState = ((!buttonEnabled) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				if (buttonEnabled)
				{
					_buttonStartText.alpha = 1f;
				}
				else
				{
					_buttonStartText.alpha = 0.5f;
				}
			}
		}

		private void OnStart()
		{
			if (!IsClosing())
			{
				_level.ResearchManager.AssignProject(_project, _roomItem);
				OnExit();
			}
		}

		private void OnExit()
		{
			CloseMenu();
		}
	}
}
