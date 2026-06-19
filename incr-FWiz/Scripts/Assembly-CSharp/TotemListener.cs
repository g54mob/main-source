using System.Collections.Generic;
using OUSystems.Basics.DataStructures;

public class TotemListener : BuildingBehaviour
{
	public static List<TotemListener> TotemListeners;

	public Totem.TotemType TotemType;

	public int TotemsApplied;

	public BoolContainer Powered;

	public void OnAddTotem()
	{
	}

	public void OnRemoveTotem()
	{
	}

	public override void OnMove()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
