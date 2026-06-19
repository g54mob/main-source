using System.Collections.Generic;

public class Totem : BuildingBehaviour
{
	public enum TotemType
	{
		Fuel = 0,
		Click = 1,
		Growth = 2
	}

	public static List<Totem> Totems;

	public TotemType Type;

	public RadiusProvider RadiusProvider;

	public List<TotemListener> ListenersAffected;

	public bool InRange(TotemListener listener)
	{
		return false;
	}

	public override void OnMove()
	{
	}

	public void UpdateApplication()
	{
	}

	public static void RegisterTotemListener(TotemListener totemListener)
	{
	}

	public void TryAddTotemListener(TotemListener totemListener)
	{
	}

	public static void DeregisterTotemListener(TotemListener totemListener)
	{
	}

	public void TryRemoveTotemListener(TotemListener totemListener)
	{
	}

	public override void Initiate()
	{
	}

	public override void ClearForDestroy()
	{
	}

	public void OnTotemListenerMoved(TotemListener totemListener)
	{
	}

	public override List<BuildingSelectorData> GetSelectorTransforms()
	{
		return null;
	}
}
