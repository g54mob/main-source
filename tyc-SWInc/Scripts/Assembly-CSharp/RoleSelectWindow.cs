using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelectWindow : MonoBehaviour
{
	public ThreeStateCheck[] RoleToggles;

	public ThreeStateCheck[] SecondaryRoleToggles;

	public Toggle AnyRole;

	public ThreeStateCheck Mentor;

	public GUIWindow Window;

	private List<Actor> _actors;

	private bool _isChangingAnyRole;

	public void Show(IEnumerable<Actor> actors)
	{
		_actors = actors.ToList();
		if (_actors.Any((Actor x) => !x.employee.IsRole(Employee.EmployeeRole.Lead) && x.Team != null && x.GetTeam().CheckHRLevel(1) && x.GetTeam().HR.ControlRole))
		{
			Team[] hr = (from x in (from x in _actors
					where !x.employee.IsRole(Employee.EmployeeRole.Lead) && x.Team != null
					select x.GetTeam()).Distinct()
				where x.CheckHRLevel(1) && x.HR.ControlRole
				select x).ToArray();
			WindowManager.Instance.ShowMessageBox("HREmployeeRoleWarning".Loc(), true, DialogWindow.DialogType.Question, ActuallyOpen, "HRRoleChangeWarning", delegate
			{
				HUD.Instance.TeamWindow.autoWindow.Show(hr);
			});
		}
		else
		{
			ActuallyOpen();
		}
	}

	private void ActuallyOpen()
	{
		_isChangingAnyRole = true;
		RoleToggles[0].CurrentState = ThreeStateCheck.GetState(_actors, (Actor x) => x.employee.IsRole(Employee.EmployeeRole.Lead));
		for (int num = 1; num < RoleToggles.Length; num++)
		{
			int i1 = num;
			RoleToggles[num].CurrentState = ThreeStateCheck.GetState(_actors, (Actor x) => x.employee.IsRoleIndex(i1));
			SecondaryRoleToggles[num - 1].CurrentState = ThreeStateCheck.GetState(_actors, (Actor x) => x.employee.IsSecondaryRoleIndex(i1));
		}
		RoleToggles[0].interactable = _actors.Count != 1 || !_actors[0].employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead);
		Mentor.CurrentState = ThreeStateCheck.GetState(_actors, (Actor x) => x.IsMentor);
		_isChangingAnyRole = false;
		UpdateAnyRole(false);
		Window.Show();
	}

	public void SetRole(int i)
	{
		if (i == 0 && _actors.Count == 1 && _actors[0].employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
		{
			return;
		}
		foreach (Actor actor in _actors)
		{
			if (actor != null)
			{
				actor.ChangeRole((Employee.RoleBit)Employee.RoleToBit[i], Employee.RoleBit.None);
			}
		}
		Window.Close();
	}

	public void UpdateAnyRole(bool secondary)
	{
		if (_isChangingAnyRole)
		{
			return;
		}
		_isChangingAnyRole = true;
		if (secondary)
		{
			for (int i = 1; i < RoleToggles.Length; i++)
			{
				if (RoleToggles[i].CurrentState != ThreeStateCheck.State.Unknown && SecondaryRoleToggles[i - 1].CurrentState != ThreeStateCheck.State.Unknown)
				{
					RoleToggles[i].ForceState &= !SecondaryRoleToggles[i - 1].ForceState;
				}
			}
		}
		else
		{
			for (int j = 0; j < SecondaryRoleToggles.Length; j++)
			{
				if (RoleToggles[j + 1].CurrentState != ThreeStateCheck.State.Unknown && SecondaryRoleToggles[j].CurrentState != ThreeStateCheck.State.Unknown)
				{
					SecondaryRoleToggles[j].ForceState &= !RoleToggles[j + 1].ForceState;
				}
			}
		}
		AnyRole.isOn = RoleToggles.Skip(1).All((ThreeStateCheck x) => x.CurrentState == ThreeStateCheck.State.On);
		_isChangingAnyRole = false;
	}

	public void AutoRole()
	{
		foreach (Actor actor in _actors)
		{
			if (actor != null)
			{
				Employee.RoleBit roleBit = actor.employee.BestRoles();
				if (actor.employee.IsRole(Employee.RoleBit.Lead))
				{
					roleBit |= Employee.RoleBit.Lead;
				}
				actor.ChangeRole(roleBit, Employee.RoleBit.None);
			}
		}
		Window.Close();
	}

	public void AnyRoleChanged()
	{
		if (!_isChangingAnyRole)
		{
			_isChangingAnyRole = true;
			for (int i = 1; i < RoleToggles.Length; i++)
			{
				RoleToggles[i].ForceState = AnyRole.isOn;
			}
			for (int j = 0; j < SecondaryRoleToggles.Length; j++)
			{
				SecondaryRoleToggles[j].ForceState &= !RoleToggles[j + 1].ForceState;
			}
			_isChangingAnyRole = false;
		}
	}

	public void Apply()
	{
		int num = 0;
		int num2 = 0;
		for (int num3 = RoleToggles.Length - 1; num3 >= 0; num3--)
		{
			num <<= 1;
			num2 <<= 1;
			switch (RoleToggles[num3].CurrentState)
			{
			case ThreeStateCheck.State.Unknown:
				num2 |= 1;
				break;
			case ThreeStateCheck.State.On:
				num |= 1;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case ThreeStateCheck.State.Off:
				break;
			}
		}
		Employee.RoleBit roleBit = (Employee.RoleBit)num;
		Employee.RoleBit roleBit2 = (Employee.RoleBit)num2;
		num = 0;
		num2 = 0;
		for (int num4 = SecondaryRoleToggles.Length - 1; num4 >= 0; num4--)
		{
			num <<= 1;
			num2 <<= 1;
			switch (SecondaryRoleToggles[num4].CurrentState)
			{
			case ThreeStateCheck.State.Unknown:
				num2 |= 1;
				break;
			case ThreeStateCheck.State.On:
				num |= 1;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case ThreeStateCheck.State.Off:
				break;
			}
		}
		num <<= 1;
		num2 <<= 1;
		Employee.RoleBit roleBit3 = (Employee.RoleBit)num;
		Employee.RoleBit roleBit4 = (Employee.RoleBit)num2;
		foreach (Actor actor in _actors)
		{
			if (actor != null)
			{
				actor.ChangeRole(roleBit | (actor.employee.CurrentRoleBit & roleBit2), roleBit3 | (actor.employee.SecondaryRole & roleBit4));
				if (Mentor.CurrentState != ThreeStateCheck.State.Unknown)
				{
					actor.IsMentor = Mentor.CurrentState == ThreeStateCheck.State.On;
				}
			}
		}
		Window.Close();
	}
}
