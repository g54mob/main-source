using System;
using System.Globalization;
using CTS.APITwitch;
using CTS.BBT.AI;
using CTS.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace CTS
{
	public class AgentIdentityPanel : AbsAgentPanel
	{
		[SerializeField]
		private TMP_Text _nameText;

		private LocalizeStringEvent _nameEvent;

		[SerializeField]
		private LocalizedString _localizedMoney;

		[SerializeField]
		private LocalizedString _localizedSalary;

		[SerializeField]
		private TMP_Text _moneyText;

		[SerializeField]
		private LocalizedString _localizedLevel;

		[SerializeField]
		private LocalizedString _localizedBlood;

		[SerializeField]
		private TMP_Text _levelText;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private PaletteData _vampirePaletColor;

		[SerializeField]
		private PaletteData _humanPaletColor;

		[SerializeField]
		private PaletteData _customerVampirePaletColor;

		[SerializeField]
		private GameObject _investigatorSprite;

		[SerializeField]
		private UI_ChangeNameWorker _changeNameWorker;

		[SerializeField]
		[Foldout("ToolTips")]
		private ToolTipsShower _toolTips;

		[SerializeField]
		[Foldout("ToolTips")]
		private LocalizedString _customerTitle;

		[SerializeField]
		[Foldout("ToolTips")]
		private LocalizedString _customerText;

		[SerializeField]
		[Foldout("ToolTips")]
		private LocalizedString _vampireTitle;

		[SerializeField]
		[Foldout("ToolTips")]
		private LocalizedString _vampireText;

		[SerializeField]
		private SubSpeciesSO _speciesSO;

		public static event Action<Worker> OnWorkerNameChange;

		public override void SetAgentInfo()
		{
			if (base._agent is Customer)
			{
				if (base._agent.IsHuman)
				{
					_backgroundImage.color = _humanPaletColor.GetColor();
				}
				else
				{
					_backgroundImage.color = _customerVampirePaletColor.GetColor();
				}
			}
			else if (base._agent is Worker)
			{
				_backgroundImage.color = _vampirePaletColor.GetColor();
			}
			if (base._agent is Customer)
			{
				if (((Customer)base._agent).IsInvestigator)
				{
					_investigatorSprite.SetActive(value: true);
				}
				else
				{
					_investigatorSprite.SetActive(value: false);
				}
			}
			else
			{
				_investigatorSprite.SetActive(value: false);
			}
			if (_nameEvent == null)
			{
				_nameEvent = _nameText.GetComponent<LocalizeStringEvent>();
				_nameEvent.StringReference = null;
			}
			if (!base._agent.AlreadyNameChanged && base._agent is Customer)
			{
				EventName eventName = CTS.APITwitch.APITwitch.GiveList();
				if ((object)eventName != null && eventName.ListHasName())
				{
					string theFirstName = eventName.GetTheFirstName();
					base._agent.SetName(theFirstName, theFirstName);
					base._agent.TwitchDeleteEvent();
				}
				base._agent.AlreadyNameChanged = true;
			}
			_nameText.text = base._agent.agentFirstName;
			SetLevelInfo();
			LocalizationChanged();
		}

		private void SetLevelInfo()
		{
			if (base._agent is Worker worker)
			{
				SetLevelText();
				worker.Level.LeveledUp += SetLevelText;
			}
		}

		public override void ClearAgentInfo()
		{
			_nameText.text = "";
			_moneyText.text = "";
			_levelText.text = "";
			if (base._agent is Worker worker)
			{
				worker.Level.LeveledUp -= SetLevelText;
			}
		}

		public void NeedToBeInteractable(bool worker)
		{
			GetComponent<UI_ChangeNameWorker>().NameCanBeChange(worker, base._agent.agentFirstName);
			_nameText.gameObject.SetActive(!worker);
		}

		public void ChangeName(string name)
		{
			base._agent.SetName(name, name);
			Worker obj = base._agent as Worker;
			AgentIdentityPanel.OnWorkerNameChange?.Invoke(obj);
		}

		protected override void LocalizationChanged()
		{
			UpdateMoneyText();
			SetLevelText();
		}

		private void SetLevelText()
		{
			if (base._agent is Worker)
			{
				_levelText.text = _localizedLevel.GetLocalizedString() + " " + ((Worker)base._agent).Level.CurrentLevel;
				_toolTips.enabled = false;
			}
			if (base._agent is Customer customer)
			{
				_toolTips.enabled = true;
				if (customer.IsHuman)
				{
					_levelText.text = _localizedBlood.GetLocalizedString() + " " + customer.BloodQuality;
					_toolTips.SetTootipsInfo(_customerTitle, _customerText);
				}
				else
				{
					string localizedString = _speciesSO.GetLocalizedString(customer.SpawnParameters.Type).GetLocalizedString();
					_levelText.text = localizedString;
					_toolTips.enabled = false;
				}
			}
		}

		private void UpdateMoneyText()
		{
			if (base._agent is Worker worker)
			{
				_moneyText.text = _localizedSalary.GetLocalizedString() + " " + worker.Salary.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			}
			else if (base._agent is Customer customer)
			{
				_moneyText.text = _localizedMoney.GetLocalizedString() + " " + customer.Money.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			}
		}

		public void SetName()
		{
			GetComponent<UI_ChangeNameWorker>().SetName(this);
		}
	}
}
