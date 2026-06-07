using System.Collections.Generic;
using System.IO;
using System.Linq;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.UIFramework;
using DV.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.PresetEditors
{
	public class TrainEditorController : APresetEditorController<ITrain>
	{
		private const string LOC_DELETE_PROMPT_ONLY = "scenario/delete_train_prompt_only";

		private const string LOC_DELETE_PROMPT_MULTIPLE = "scenario/delete_train_prompt_multiple";

		private DVObjectModel dvOM;

		private IScenarioCRUD crud;

		private IScenario scenario;

		private HashSet<GeneralLicenseType_v2> unlockedLicenses = new HashSet<GeneralLicenseType_v2>();

		private HashSet<GarageType_v2> unlockedGarages = new HashSet<GarageType_v2>();

		private ObservableCollectionExt<ICar> gridViewModel = new ObservableCollectionExt<ICar>();

		private AudioClip keyboardSelectionSound;

		[Header("GUI Element References")]
		[NullCheck]
		public TrainEditorGridView gridView;

		[NullCheck]
		public TextMeshProUGUI carInfoTMPro;

		[NullCheck]
		public GameObject readOnlyBlocker;

		[NullCheck]
		public ButtonDV deleteCarButton;

		[NullCheck]
		public Selector moveCarSelector;

		[NullCheck]
		public Selector carTypeSelector;

		[NullCheck]
		public Selector liverySelector;

		[NullCheck]
		public Selector cargoSelector;

		[NullCheck]
		public ButtonDV flipCarButton;

		[NullCheck]
		public ButtonDV addCarButton;

		[NullCheck]
		public ButtonDV addLocoButton;

		[NullCheck]
		public ToggleDV excludeFromRandomizationCheckbox;

		[Header("Misc")]
		[NullCheck]
		public Sprite locoIcon;

		[NullCheck]
		public Sprite carIcon;

		private bool reentrancyCheck_RefreshData;

		private bool reentrancyCheck_RefreshInterface;

		private int MaxCarsInGridView => 60;

		protected override string LOC_RENAME_PROMPT => "scenario/rename_train_prompt";

		protected override string LOC_DELETE_PROMPT => "scenario/delete_train_prompt_one";

		protected override string LOC_SAVE_OR_REVERT_PROMPT => "scenario/save_or_revert_train";

		protected override bool HasSaveButton => true;

		protected override bool HasOpenFolderButton => true;

		protected override bool HasDoneButton => true;

		public override IScenarioCRUD CRUD => crud;

		public override ObservableCollectionExt<ITrain> Things => crud?.Trains;

		public override ITrain CurrentThing { get; protected set; }

		private bool IsSelectedCarIndexValid => IsCarIndexValid(gridView.SelectedModelIndex);

		private ICar SelectedCar
		{
			get
			{
				if (!IsSelectedCarIndexValid)
				{
					return null;
				}
				return gridViewModel[gridView.SelectedModelIndex];
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			UIEffectsReferences componentInParent = GetComponentInParent<UIEffectsReferences>();
			if ((bool)componentInParent)
			{
				keyboardSelectionSound = componentInParent.hoverSound;
			}
		}

		public void SetData(AScenarioProvider provider, IScenario scenario)
		{
			dvOM = provider.GetObjectModel();
			crud = provider.CRUD;
			isVR = provider.IsVR;
			unlockedLicenses = provider.GetUnlockedLicenses();
			unlockedGarages = provider.GetUnlockedGarages();
			this.scenario = scenario;
			CurrentThing = scenario.Train;
			base.IsInitialized = true;
			RefreshData();
		}

		public void FlipSelectedCar()
		{
			if (!CheckAndLogSelectionValidity())
			{
				ICar selectedCar = SelectedCar;
				selectedCar.Reversed = !selectedCar.Reversed;
				RefreshInterface();
			}
		}

		public void ChangeSelectedCarType(bool next)
		{
			if (!CheckAndLogSelectionValidity())
			{
				ICar selectedCar = SelectedCar;
				TrainCarLivery trainCarLivery = ((!selectedCar.IsValid()) ? dvOM.carTypes[0].liveries[0] : TrainEditor_Helpers.GetPreviousOrNextCarType(dvOM.carTypes, selectedCar.GetLivery().parentType, next).liveries[0]);
				selectedCar.Name = trainCarLivery.id;
				if (!TrainEditor_Helpers.CarAcceptsCargoType(selectedCar, selectedCar.CargoType, dvOM))
				{
					selectedCar.CargoType = null;
				}
				RefreshInterface();
			}
		}

		public void ChangeSelectedCarLivery(bool next)
		{
			if (!CheckAndLogSelectionValidity())
			{
				ICar selectedCar = SelectedCar;
				TrainCarLivery previousOrNextCarLivery = TrainEditor_Helpers.GetPreviousOrNextCarLivery(selectedCar.GetLivery(), next);
				selectedCar.Name = previousOrNextCarLivery.id;
				if (!TrainEditor_Helpers.CarAcceptsCargoType(selectedCar, selectedCar.CargoType, dvOM))
				{
					selectedCar.CargoType = null;
				}
				RefreshInterface();
			}
		}

		public void MoveSelectedCar(bool next)
		{
			if (!CheckAndLogSelectionValidity())
			{
				int num = gridView.SelectedModelIndex + (next ? 1 : (-1));
				num = (num + gridViewModel.Count) % gridViewModel.Count;
				if (!IsCarIndexValid(num))
				{
					Debug.Log($"Can't move to {num}");
					return;
				}
				gridViewModel.Move(gridView.SelectedModelIndex, num);
				RefreshInterface();
			}
		}

		public void DeleteSelectedCar()
		{
			if (!CheckAndLogSelectionValidity() && gridViewModel.Count != 1)
			{
				int selected = Mathf.Clamp(gridView.SelectedModelIndex, 0, gridViewModel.Count - 2);
				gridViewModel.RemoveAt(gridView.SelectedModelIndex);
				if (gridViewModel.Count > 0)
				{
					gridView.SetSelected(selected);
				}
				RefreshInterface();
			}
		}

		public void ChangeCargoOfSelectedCar(bool next)
		{
			if (!CheckAndLogSelectionValidity())
			{
				gridViewModel[gridView.SelectedModelIndex].CargoType = TrainEditor_Helpers.GetPreviousOrNextCargoForCarType(dvOM, SelectedCar, next)?.id ?? "";
				RefreshInterface();
			}
		}

		private void Update()
		{
			HandleKeyboardShortcuts();
		}

		private void HandleKeyboardShortcuts()
		{
			if (!gridView.allowHoveringAndSelecting)
			{
				return;
			}
			bool flag = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
			bool flag2 = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
			bool flag3 = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
			bool keyDown = Input.GetKeyDown(KeyCode.LeftArrow);
			bool keyDown2 = Input.GetKeyDown(KeyCode.RightArrow);
			bool keyDown3 = Input.GetKeyDown(KeyCode.UpArrow);
			bool keyDown4 = Input.GetKeyDown(KeyCode.DownArrow);
			bool keyDown5 = Input.GetKeyDown(KeyCode.Insert);
			bool keyDown6 = Input.GetKeyDown(KeyCode.Delete);
			bool keyDown7 = Input.GetKeyDown(KeyCode.Home);
			bool keyDown8 = Input.GetKeyDown(KeyCode.End);
			bool keyDown9 = Input.GetKeyDown(KeyCode.D);
			bool flag4 = false;
			if (keyDown7)
			{
				gridView.SetSelected(0);
				flag4 = true;
			}
			else if (keyDown8)
			{
				gridView.SetSelected(gridViewModel.Count - 1);
				flag4 = true;
			}
			else if (keyDown || keyDown2)
			{
				bool next = keyDown2;
				if (flag)
				{
					MoveSelectedCar(next);
				}
				else if (flag2)
				{
					ChangeSelectedCarType(next);
				}
				else if (flag3)
				{
					ChangeCargoOfSelectedCar(next);
				}
				else
				{
					int num = ((!keyDown) ? 1 : (-1));
					int num2 = gridView.SelectedModelIndex + num;
					if (num2 < 0)
					{
						num2 = gridViewModel.Count - 1;
					}
					else if (num2 >= gridViewModel.Count)
					{
						num2 = 0;
					}
					gridView.SetSelected(num2);
				}
				flag4 = true;
			}
			else if (keyDown3 || keyDown4)
			{
				bool next2 = keyDown4;
				if (flag)
				{
					FlipSelectedCar();
				}
				else if (flag2)
				{
					ChangeSelectedCarLivery(next2);
				}
				else
				{
					int num3 = ((!keyDown3) ? 1 : (-1));
					int value = gridView.SelectedModelIndex + num3 * gridView.GetComponent<GridLayoutGroup>().constraintCount;
					value = Mathf.Clamp(value, 0, gridViewModel.Count - 1);
					gridView.SetSelected(value);
				}
				flag4 = true;
			}
			else if (keyDown6)
			{
				DeleteSelectedCar();
				flag4 = true;
			}
			else if (keyDown5 || (flag2 && keyDown9))
			{
				if (SelectedCar.IsValid())
				{
					AddCar(SelectedCar.IsLocoOrTenderOrSlug());
				}
				else
				{
					OnAddLocoClicked();
				}
				flag4 = true;
			}
			if (flag4)
			{
				UISoundEffects.Play(keyboardSelectionSound);
			}
		}

		protected override void SetupListeners(bool on)
		{
			base.SetupListeners(on);
			if (on)
			{
				gridView.SelectedIndexChanged += RefreshInterface;
				deleteCarButton.onClick.AddListener(OnDeleteCarClicked);
				moveCarSelector.PreviousOrNextClicked += OnMoveCarClicked;
				carTypeSelector.PreviousOrNextClicked += OnCarTypeClicked;
				liverySelector.PreviousOrNextClicked += OnLiveryClicked;
				cargoSelector.PreviousOrNextClicked += OnCargoClicked;
				flipCarButton.onClick.AddListener(OnFlipCarClicked);
				addCarButton.onClick.AddListener(OnAddCarClicked);
				addLocoButton.onClick.AddListener(OnAddLocoClicked);
				excludeFromRandomizationCheckbox.onValueChanged.AddListener(OnExcludeFromRandomizationChanged);
			}
			else
			{
				gridView.SelectedIndexChanged -= RefreshInterface;
				deleteCarButton.onClick.RemoveListener(OnDeleteCarClicked);
				moveCarSelector.PreviousOrNextClicked -= OnMoveCarClicked;
				carTypeSelector.PreviousOrNextClicked -= OnCarTypeClicked;
				liverySelector.PreviousOrNextClicked -= OnLiveryClicked;
				cargoSelector.PreviousOrNextClicked -= OnCargoClicked;
				flipCarButton.onClick.RemoveListener(OnFlipCarClicked);
				addCarButton.onClick.RemoveListener(OnAddCarClicked);
				addLocoButton.onClick.RemoveListener(OnAddLocoClicked);
				excludeFromRandomizationCheckbox.onValueChanged.RemoveListener(OnExcludeFromRandomizationChanged);
			}
		}

		public override void RefreshData()
		{
			if (reentrancyCheck_RefreshData)
			{
				Debug.LogError(GetType().Name + " RefreshData reentrancy check fail!", this);
			}
			reentrancyCheck_RefreshData = true;
			base.RefreshData();
			if (base.IsInitialized)
			{
				gridViewModel = CurrentThing.Cars;
				while (gridViewModel.Count > MaxCarsInGridView)
				{
					gridViewModel.RemoveAt(gridViewModel.Count - 1);
				}
				gridView.IsLiveryUnlocked = IsLiveryUnlocked;
				gridView.SetModel(gridViewModel);
			}
			else
			{
				gridViewModel = new ObservableCollectionExt<ICar>();
				gridView.IsLiveryUnlocked = (TrainCarLivery _) => true;
				gridView.SetModel(gridViewModel);
			}
			RefreshInterface();
			reentrancyCheck_RefreshData = false;
		}

		public override void RefreshInterface()
		{
			if (reentrancyCheck_RefreshInterface)
			{
				Debug.LogError(GetType().Name + " RefreshInterface reentrancy check fail!", this);
			}
			reentrancyCheck_RefreshInterface = true;
			base.RefreshInterface();
			if (IsSelectedCarIndexValid)
			{
				deleteCarButton.ToggleInteractable(gridViewModel.Count > 1);
				moveCarSelector.ToggleInteractable(gridViewModel.Count > 1);
				carTypeSelector.ToggleInteractable(newInteractable: true);
				ICar selectedCar = SelectedCar;
				if (selectedCar.IsValid())
				{
					bool newInteractable = selectedCar.GetLivery().parentType.liveries.Count > 1;
					liverySelector.ToggleInteractable(newInteractable);
					cargoSelector.ToggleInteractable(TrainEditor_Helpers.CarAcceptsAnyCargo(selectedCar, dvOM));
					carTypeSelector.Icon.sprite = (selectedCar.IsLocoOrTenderOrSlug() ? locoIcon : carIcon);
					flipCarButton.ToggleInteractable(newInteractable: true);
					flipCarButton.GetGraphicsReferences().icon.rectTransform.localScale = new Vector3((!selectedCar.Reversed) ? 1 : (-1), 1f, 1f);
				}
				else
				{
					liverySelector.ToggleInteractable(newInteractable: false);
					flipCarButton.ToggleInteractable(newInteractable: false);
					cargoSelector.ToggleInteractable(newInteractable: false);
				}
				carInfoTMPro.text = selectedCar.LocalizedInfo();
			}
			else
			{
				deleteCarButton.ToggleInteractable(newInteractable: false);
				moveCarSelector.ToggleInteractable(newInteractable: false);
				carTypeSelector.ToggleInteractable(newInteractable: false);
				liverySelector.ToggleInteractable(newInteractable: false);
				cargoSelector.ToggleInteractable(newInteractable: false);
				flipCarButton.ToggleInteractable(newInteractable: false);
				excludeFromRandomizationCheckbox.SetIsOnWithoutNotify(value: false);
				excludeFromRandomizationCheckbox.ToggleInteractable(newInteractable: false);
				carInfoTMPro.text = "";
			}
			bool newInteractable2 = gridViewModel.Count < MaxCarsInGridView;
			addCarButton.ToggleInteractable(newInteractable2);
			addLocoButton.ToggleInteractable(newInteractable2);
			bool flag = CurrentThing != null && !CurrentThing.IsReadOnly;
			excludeFromRandomizationCheckbox.SetIsOnWithoutNotify(flag && CurrentThing.ExcludeFromRandomization);
			excludeFromRandomizationCheckbox.ToggleInteractable(flag);
			readOnlyBlocker.SetActive(!flag);
			gridView.allowHoveringAndSelecting = flag;
			reentrancyCheck_RefreshInterface = false;
		}

		private void RefreshInterface(AGridView<ICar> _)
		{
			RefreshInterface();
		}

		protected override (PopupLocalizationKeys keys, Dictionary<string, string> locParams) GetDeletePopupArgs()
		{
			int num = crud.Scenarios.Count((IScenario s) => s != scenario && s.Train == CurrentThing);
			PopupLocalizationKeys popupLocalizationKeys = new PopupLocalizationKeys
			{
				positiveKey = LOC_DELETE_CONFIRM,
				negativeKey = LOC_GENERIC_CANCEL
			};
			object labelKey;
			switch (num)
			{
			default:
				labelKey = "scenario/delete_train_prompt_multiple";
				break;
			case 1:
				labelKey = LOC_DELETE_PROMPT;
				break;
			case 0:
				labelKey = "scenario/delete_train_prompt_only";
				break;
			}
			popupLocalizationKeys.labelKey = (string)labelKey;
			PopupLocalizationKeys item = popupLocalizationKeys;
			Dictionary<string, string> item2 = new Dictionary<string, string>
			{
				{ "NAME", CurrentThing.Name },
				{
					"NUM",
					num.ToString()
				}
			};
			return (keys: item, locParams: item2);
		}

		protected override void DeleteImpl()
		{
			crud.DeleteTrain(CurrentThing);
		}

		protected override void FlushChanges()
		{
			CRUD.Flush();
		}

		protected override void OnSavePresetClicked()
		{
			crud.Flush();
			RefreshInterface();
		}

		protected override string GetSuggestedNameForNew()
		{
			return CRUD.GetAutoIncrementName(CurrentThing);
		}

		protected override void CreateNewImpl(string nameToUse)
		{
			CurrentThing = ((CurrentThing == null) ? crud.CreateTrain() : crud.CreateCopyOf(CurrentThing));
			CurrentThing.Name = nameToUse;
			CRUD.Flush();
		}

		protected override void OnPresetSelected(IClickable _, int selectedIndex)
		{
			CurrentThing = crud.Trains[selectedIndex];
			RefreshData();
		}

		private void AddCar(bool isLocoOrTenderOrSlug)
		{
			string cargo = null;
			string id;
			if (SelectedCar.IsValid() && SelectedCar.IsLocoOrTenderOrSlug() == isLocoOrTenderOrSlug)
			{
				id = SelectedCar.Name;
				cargo = (isLocoOrTenderOrSlug ? null : SelectedCar.CargoType);
			}
			else
			{
				id = dvOM.carTypes.First((TrainCarType_v2 c) => c.IsLocoOrTenderOrSlug() == isLocoOrTenderOrSlug).liveries[0].id;
			}
			Add(id, cargo);
		}

		private void OnAddLocoClicked()
		{
			AddCar(isLocoOrTenderOrSlug: true);
		}

		private void OnAddCarClicked()
		{
			AddCar(isLocoOrTenderOrSlug: false);
		}

		private void Add(string livery, string cargo = null)
		{
			if (gridViewModel.Count >= MaxCarsInGridView)
			{
				Debug.LogWarning($"Can't add more than {MaxCarsInGridView} cars, ignoring", this);
				return;
			}
			int num;
			bool reversed;
			if (IsSelectedCarIndexValid)
			{
				num = gridView.SelectedModelIndex + 1;
				reversed = SelectedCar.Reversed;
			}
			else
			{
				num = gridViewModel.Count;
				reversed = false;
			}
			ICar item = crud.CreateCar(livery, reversed, cargo);
			gridViewModel.Insert(num, item);
			gridView.SetSelected(num);
		}

		private void OnDeleteCarClicked()
		{
			DeleteSelectedCar();
		}

		private void OnFlipCarClicked()
		{
			FlipSelectedCar();
		}

		private void OnCargoClicked(ISelector _, bool nextClicked)
		{
			ChangeCargoOfSelectedCar(nextClicked);
		}

		private void OnLiveryClicked(ISelector _, bool nextClicked)
		{
			ChangeSelectedCarLivery(nextClicked);
		}

		private void OnCarTypeClicked(ISelector _, bool nextClicked)
		{
			ChangeSelectedCarType(nextClicked);
		}

		private void OnMoveCarClicked(ISelector _, bool nextClicked)
		{
			MoveSelectedCar(nextClicked);
		}

		private void OnExcludeFromRandomizationChanged(bool on)
		{
			if (CurrentThing != null)
			{
				CurrentThing.ExcludeFromRandomization = on;
			}
		}

		private bool IsCarIndexValid(int i)
		{
			if (gridViewModel.Count > 0 && i >= 0)
			{
				return i < gridViewModel.Count;
			}
			return false;
		}

		private bool CheckAndLogSelectionValidity()
		{
			if (!IsSelectedCarIndexValid)
			{
				Debug.Log($"Selected index {gridView.SelectedModelIndex} is not valid");
				return true;
			}
			return false;
		}

		protected override string GetTargetFilePath()
		{
			if (CurrentThing == null || string.IsNullOrEmpty(CurrentThing.FileName))
			{
				return crud.BaseStoragePath;
			}
			return crud.BaseStoragePath + Path.DirectorySeparatorChar + CurrentThing.FileName;
		}

		protected override bool IsDefaultPresetName(string name)
		{
			return false;
		}

		private bool IsLiveryUnlocked(TrainCarLivery livery)
		{
			return TrainEditor_Helpers.IsLiveryUnlocked(livery, unlockedLicenses, unlockedGarages);
		}
	}
}
