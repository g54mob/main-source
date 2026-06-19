using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffJobToggle : MonoBehaviour
	{
		[SerializeField]
		private ButtonAnimator _buttonAnimator;

		[SerializeField]
		private TooltipSpawner _tooltip;

		[SerializeField]
		private TooltipSpawner _nonToggleTooltip;

		[SerializeField]
		private Action _toggledFunc;

		[SerializeField]
		private Image _nonToggleImage;

		private Staff _staff;

		public JobDescription Job { get; private set; }

		public void Setup(JobDescription job, Staff staff, bool interactable, Action toggledFunc)
		{
			Job = job;
			_staff = staff;
			_toggledFunc = toggledFunc;
			_buttonAnimator.Button.onPrimaryDown.RemoveListener(OnToggled);
			if (_staff.Definition._cantReassignJobs)
			{
				if (job.IsSuitable(staff))
				{
					GameObjectUtils.SetActive(_nonToggleImage.gameObject, isActive: true);
					GameObjectUtils.SetActive(_buttonAnimator.gameObject, isActive: false);
					if ((bool)_nonToggleTooltip)
					{
						_nonToggleTooltip.SetDataProvider(TooltipLogic);
					}
				}
				else
				{
					GameObjectUtils.SetActive(_nonToggleImage.gameObject, isActive: false);
					GameObjectUtils.SetActive(_buttonAnimator.gameObject, isActive: true);
					_buttonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
					_tooltip.SetDataProvider(TooltipLogic);
				}
			}
			else
			{
				GameObjectUtils.SetActive(_nonToggleImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_buttonAnimator.gameObject, isActive: true);
				if (interactable && job.IsSuitable(staff))
				{
					_buttonAnimator.CurrentState = ((!staff.JobExclusions.Contains(job)) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
					_buttonAnimator.Button.onPrimaryDown.AddListener(OnToggled);
				}
				else
				{
					_buttonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
				}
				if (_buttonAnimator.CurrentState == ButtonAnimator.State.Selectable)
				{
					toggledFunc.InvokeSafe();
				}
				_tooltip.SetDataProvider(TooltipLogic);
			}
		}

		private void TooltipLogic(Tooltip tooltip)
		{
			string text = Job.RequiredQualificationString();
			bool flag = text != string.Empty;
			string term = ((!_staff.Definition._cantReassignJobs) ? ((!Job.IsSuitable(_staff)) ? ScriptLocalization.Menu_Staff_Menu_JobToggle.Unqualified_CS : ((_buttonAnimator.CurrentState != ButtonAnimator.State.Selected) ? (flag ? ScriptLocalization.Menu_Staff_Menu_JobToggle.NotAllowedQualification_CS : ScriptLocalization.Menu_Staff_Menu_JobToggle.NotAllowed_CS) : (flag ? ScriptLocalization.Menu_Staff_Menu_JobToggle.AllowedQualification_CS : ScriptLocalization.Menu_Staff_Menu_JobToggle.Allowed_CS))) : (_staff.Definition.IsUniqueVehicularMechanic ? (Job.IsSuitable(_staff) ? ScriptLocalization.Menu_Staff_Menu_JobToggle.AllowedQualification_CS : ScriptLocalization.Menu_Staff_Menu_JobToggle.NotAllowed_CS) : ((!Job.IsSuitable(_staff)) ? ScriptLocalization.Menu_Staff_Menu_JobToggle.Unqualified_CS : (flag ? ScriptLocalization.Menu_Staff_Menu_JobToggle.LockedQualification_CS : ScriptLocalization.Menu_Staff_Menu_JobToggle.LockedAllowed_CS))));
			term = LocalisedString.Replace(term, new SubPair[2]
			{
				new SubPair("{[JOB]}", Job.GetJobAssignmentTooltipString()),
				new SubPair("{[QUALIFICATION]}", text)
			});
			tooltip.Text = term;
		}

		public void OnToggled()
		{
			if (_buttonAnimator.CurrentState == ButtonAnimator.State.Selectable)
			{
				_staff.JobExclusions.Remove(Job);
				_buttonAnimator.CurrentState = ButtonAnimator.State.Selected;
			}
			else
			{
				_staff.JobExclusions.AddUnique(Job);
				_buttonAnimator.CurrentState = ButtonAnimator.State.Selectable;
			}
			_toggledFunc.InvokeSafe();
		}
	}
}
