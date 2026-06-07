using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EmployeeTermination
{
	public enum TerminationType
	{
		Dead = 0,
		Hospitalized = 1,
		Retired = 2,
		Quit = 3
	}

	public string Name;

	public string Team;

	public Employee.RoleBit Role;

	public float YearsHired;

	public float Payout;

	public TerminationType Termination;

	public SDateTime Date;

	public Dictionary<string, int>[] Specs;

	public float[] Skills;

	public EmployeeTermination()
	{
	}

	public EmployeeTermination(Actor actor, TerminationType type, float payout)
	{
		Name = actor.employee.ExtraName;
		Team = actor.Team;
		Role = actor.employee.CurrentRoleBit;
		YearsHired = Mathf.Round(SDateTime.GetMonths(actor.employee.Hired, SDateTime.Now()) / 12f * 4f) / 4f;
		Payout = payout;
		Termination = type;
		Date = SDateTime.Now();
		Specs = actor.employee.GetAllSpecializations();
		Skills = new float[5]
		{
			actor.employee.GetSkill(Employee.EmployeeRole.Lead),
			actor.employee.GetSkill(Employee.EmployeeRole.Designer),
			actor.employee.GetSkill(Employee.EmployeeRole.Programmer),
			actor.employee.GetSkill(Employee.EmployeeRole.Artist),
			actor.employee.GetSkill(Employee.EmployeeRole.Service)
		};
	}
}
