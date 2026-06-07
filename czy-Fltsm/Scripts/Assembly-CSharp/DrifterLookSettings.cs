using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Looks/Settings")]
public class DrifterLookSettings : ScriptableObject
{
	public DrifterLookProperties[] MaleProperties;

	public DrifterLookProperties[] FemaleProperties;

	public DrifterLookProperties ReturnRandomLookProperties(Agent.EGender gender)
	{
		return gender switch
		{
			Agent.EGender.Female => FlotsamGame.Random(FemaleProperties), 
			Agent.EGender.Male => FlotsamGame.Random(MaleProperties), 
			_ => throw new NotImplementedException($"No look properties set for {gender.ToString()}."), 
		};
	}
}
