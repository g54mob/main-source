using System;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_WorkerMgr_WorkerInfo : UI_WorkerMgr_WorkerInfoBase
	{
		[SerializeField]
		private Image _powerImageContainer;

		[SerializeField]
		private TMP_Text _nameTextContainer;

		[SerializeField]
		private TMP_Text _levelTextContainer;

		[SerializeField]
		private TMP_Text _salaryTextContainer;

		private ToolTipsShower _powerTooltip;

		protected override void OnAwake()
		{
			base.OnAwake();
			_powerTooltip = _powerImageContainer.GetComponentInParent<ToolTipsShower>(includeInactive: true);
		}

		protected override void OnEnabled()
		{
			base._worker.Level.LeveledUp += OnWorkerLevelUp;
			base.OnEnabled();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			base._worker.Level.LeveledUp -= OnWorkerLevelUp;
		}

		private void OnWorkerLevelUp()
		{
			RepaintLevel();
			RepaintSalary();
		}

		public override void Repaint()
		{
			if ((object)base._worker != null)
			{
				RepaintName();
				RepaintPower();
				RepaintLevel();
				RepaintSalary();
			}
		}

		private void RepaintPower()
		{
			if ((object)_powerImageContainer != null)
			{
				if (CTSSingleton<UI_WorkerManager>.Instance.PowerDatas.TryGetValue(base._worker.PowerFeatures.GetPower(), out var value))
				{
					_powerImageContainer.overrideSprite = value.Icon;
					_powerTooltip.SetTootipsInfo(value.Name, value.Description, _powerTooltip.gameObject);
				}
				else
				{
					Debug.LogException(new NullReferenceException("Couldn't find power for UI"));
				}
			}
		}

		private void RepaintName()
		{
			if ((object)_nameTextContainer != null)
			{
				_nameTextContainer.text = base._worker.agentFirstName;
			}
		}

		private void RepaintLevel()
		{
			if ((object)_levelTextContainer != null)
			{
				_levelTextContainer.text = base._worker.Level.CurrentLevel.ToString();
			}
		}

		private void RepaintSalary()
		{
			if ((object)_salaryTextContainer != null)
			{
				_salaryTextContainer.text = base._worker.Salary + "$/M";
			}
		}
	}
}
