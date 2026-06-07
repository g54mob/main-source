using System;

[Serializable]
public class Complaint
{
	public Employee Target;

	public float Demand;

	public float Severity;

	public SDateTime Date;

	public string[] Complaints;

	public Complaint()
	{
	}

	public Complaint(Employee target, float demand, float severity, SDateTime date, string[] complaints)
	{
		Target = target;
		Demand = demand;
		Severity = severity;
		Date = date;
		Complaints = complaints;
	}
}
