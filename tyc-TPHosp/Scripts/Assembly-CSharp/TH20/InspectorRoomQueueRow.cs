using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorRoomQueueRow : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
	{
		[SerializeField]
		private TMP_Text _positionLabel;

		[SerializeField]
		private TMP_Text _nameLabel;

		[SerializeField]
		private Image _backingImage;

		[SerializeField]
		private TMP_Text _illnessLabel;

		[SerializeField]
		private ProgressBarMaskable _cureProgressBar;

		[SerializeField]
		private TooltipSpawner _cureTooltip;

		[SerializeField]
		private ProgressBarMaskable _healthProgressBar;

		[SerializeField]
		private TooltipSpawner _healthTooltip;

		[SerializeField]
		private ProgressBarMaskable _happinessProgressBar;

		[SerializeField]
		private TooltipSpawner _happinessTooltip;

		[SerializeField]
		private RawImage _mugshotImage;

		[SerializeField]
		private bool _patientInfoInspectorMode;

		private Character _character;

		private CharacterMugShot _characterMugShot;

		private Patient _patient;

		public bool Draggable = true;

		public bool Clickable = true;

		private bool _wasRecentlyDragged;

		private InspectorSubItemRoomQueue _owner;

		public Character Character => _character;

		public void EnableRaycast(bool isEnabled)
		{
			_backingImage.raycastTarget = isEnabled;
		}

		public void SetBackingColor(Color color)
		{
			_backingImage.color = color;
		}

		private bool IsIllnessDiagnosed()
		{
			if (!_patient.IsGoingForTreatment() && !_patient.IsInTreatmentRoom())
			{
				return _patient.FullyDiagnosed();
			}
			return true;
		}

		public void Setup(InspectorSubItemRoomQueue owner, Character character, Sprite backingImage)
		{
			if (_mugshotImage != null && character != _character)
			{
				if (_characterMugShot != null)
				{
					_characterMugShot.Destroy();
				}
				_characterMugShot = CharacterMugShot.FromCharacterVisual(character.Visual, 128, 128, character.Level.HUD.GetConfig().MugshotConfig);
				if (_characterMugShot != null)
				{
					_mugshotImage.texture = _characterMugShot.Texture;
				}
			}
			_owner = owner;
			_character = character;
			_patient = character as Patient;
			if (_positionLabel != null)
			{
				int queuePosition = _character.GetQueuePosition();
				_positionLabel.text = ((queuePosition < 0) ? string.Empty : $"{queuePosition + 1}.");
			}
			if (_nameLabel != null)
			{
				_nameLabel.text = _character.Name;
			}
			_backingImage.color = Color.white;
			if (backingImage != null)
			{
				_backingImage.overrideSprite = backingImage;
			}
			if (_patientInfoInspectorMode)
			{
				if (_patient != null)
				{
					_illnessLabel.text = (IsIllnessDiagnosed() ? _patient.Illness.Name.Translation : ScriptLocalization.Misc.DiagnosisRequired_CS);
					GameObjectUtils.SetActive(_illnessLabel.gameObject, isActive: true);
					_cureProgressBar.Progress = _patient.DiagnosisCertainty / 100f;
					GameObjectUtils.SetActive(_cureProgressBar.gameObject, isActive: true);
					_healthProgressBar.Progress = _patient.Health.Value() / 100f;
					GameObjectUtils.SetActive(_healthProgressBar.gameObject, isActive: true);
					_happinessProgressBar.Progress = ((character.Happiness != null) ? (character.Happiness.Value() / 100f) : 0f);
					GameObjectUtils.SetActive(_happinessProgressBar.gameObject, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(_illnessLabel.gameObject, isActive: false);
					GameObjectUtils.SetActive(_cureProgressBar.gameObject, isActive: false);
					GameObjectUtils.SetActive(_healthProgressBar.gameObject, isActive: false);
					GameObjectUtils.SetActive(_happinessProgressBar.gameObject, isActive: false);
				}
			}
			else if (_patient != null)
			{
				_illnessLabel.text = _patient.Illness.Name.Translation;
				GameObjectUtils.SetActive(_illnessLabel.gameObject, IsIllnessDiagnosed());
				_cureProgressBar.Progress = _patient.DiagnosisCertainty / 100f;
				GameObjectUtils.SetActive(_cureProgressBar.gameObject, !IsIllnessDiagnosed());
				_healthProgressBar.Progress = _patient.Health.Value() / 100f;
				GameObjectUtils.SetActive(_healthProgressBar.gameObject, isActive: true);
				_happinessProgressBar.Progress = ((character.Happiness != null) ? (character.Happiness.Value() / 100f) : 0f);
				GameObjectUtils.SetActive(_happinessProgressBar.gameObject, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_illnessLabel.gameObject, isActive: false);
				GameObjectUtils.SetActive(_cureProgressBar.gameObject, isActive: false);
				GameObjectUtils.SetActive(_healthProgressBar.gameObject, isActive: false);
				GameObjectUtils.SetActive(_happinessProgressBar.gameObject, isActive: false);
			}
			_cureTooltip.SetDataProvider(SetCureTooltip);
			_healthTooltip.SetDataProvider(SetHealthTooltip);
			_happinessTooltip.SetDataProvider(SetHappinessTooltip);
		}

		public void SetupDummy(InspectorSubItemRoomQueue owner, Character character, Sprite backingImage)
		{
			_owner = owner;
			_character = character;
			_patient = character as Patient;
			if (_nameLabel != null)
			{
				_nameLabel.text = character.Name;
			}
			if (_positionLabel != null)
			{
				_positionLabel.text = string.Empty;
			}
			_backingImage.color = Color.white;
			_backingImage.overrideSprite = backingImage;
			if (_patient != null)
			{
				GameObjectUtils.SetActive(_illnessLabel.gameObject, isActive: false);
				_cureProgressBar.Progress = 0.5f;
				GameObjectUtils.SetActive(_cureProgressBar.gameObject, isActive: true);
				_healthProgressBar.Progress = _patient.Health.Value() / 100f;
				GameObjectUtils.SetActive(_healthProgressBar.gameObject, isActive: true);
				_happinessProgressBar.Progress = ((character.Happiness != null) ? (character.Happiness.Value() / 100f) : 0f);
				GameObjectUtils.SetActive(_happinessProgressBar.gameObject, isActive: true);
			}
			else
			{
				GameObjectUtils.SetActive(_illnessLabel.gameObject, isActive: false);
				GameObjectUtils.SetActive(_cureProgressBar.gameObject, isActive: false);
				GameObjectUtils.SetActive(_healthProgressBar.gameObject, isActive: false);
				GameObjectUtils.SetActive(_happinessProgressBar.gameObject, isActive: false);
			}
		}

		public void SetupBlank(InspectorSubItemRoomQueue owner, Sprite backingImage)
		{
			_owner = owner;
			_character = null;
			_patient = null;
			if (_nameLabel != null)
			{
				_nameLabel.text = string.Empty;
			}
			if (_positionLabel != null)
			{
				_positionLabel.text = string.Empty;
			}
			_backingImage.overrideSprite = backingImage;
			_backingImage.color = Color.white;
			GameObjectUtils.SetActive(_illnessLabel.gameObject, isActive: false);
			GameObjectUtils.SetActive(_cureProgressBar.gameObject, isActive: false);
			GameObjectUtils.SetActive(_happinessProgressBar.gameObject, isActive: false);
			GameObjectUtils.SetActive(_healthProgressBar.gameObject, isActive: false);
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (Draggable && !(_owner == null) && _character != null)
			{
				_wasRecentlyDragged = true;
				Vector3 vector = base.transform.InverseTransformPoint(eventData.pressPosition);
				_owner.OnQueueItemDragBegin(this, vector);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			_ = Draggable;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (Draggable && !(_owner == null))
			{
				_owner.OnQueueItemDragEnd();
			}
		}

		private void SetHappinessTooltip(Tooltip tooltip)
		{
			if (_character != null && _character.Happiness != null)
			{
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Happiness_CS, StringUtils.FormatPercentageValue(_character.Happiness.Value() / 100f));
			}
		}

		private void SetCureTooltip(Tooltip tooltip)
		{
			if (_patient != null)
			{
				if (IsIllnessDiagnosed())
				{
					tooltip.Text = $"<size=130%><b>{_patient.Illness.Name.Translation}</b></size>\n{_patient.Illness.Description.Translation}";
				}
				else
				{
					tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_DiagnosisCertainty_CS, StringUtils.FormatPercentageValue(_patient.DiagnosisCertainty / 100f));
				}
			}
		}

		private void SetHealthTooltip(Tooltip tooltip)
		{
			if (_patient != null)
			{
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Health_CS, StringUtils.FormatPercentageValue(_patient.Health.Value() / 100f));
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!Clickable)
			{
				return;
			}
			if (_wasRecentlyDragged)
			{
				_wasRecentlyDragged = false;
				return;
			}
			switch (eventData.button)
			{
			case PointerEventData.InputButton.Left:
				if (_character.GetCameraTrackObject() != null)
				{
					_character.Level.BuildEvents.OnCursorSelectObject.InvokeSafe(_character);
				}
				break;
			case PointerEventData.InputButton.Right:
				if (_character.GetComponent<StaffPickedUpState>() == null)
				{
					_character.Level.CameraLogic.TrackObject(_character.GetCameraTrackObject().transform);
				}
				else
				{
					_character.Level.CameraLogic.TrackObject(null);
				}
				break;
			}
		}

		private void OnDestroy()
		{
			if (_characterMugShot != null)
			{
				_characterMugShot.Destroy();
			}
		}
	}
}
