using XNode;

public class ResearchableNode : Node
{
	[Output(ShowBackingValue.Never, ConnectionType.Multiple, false)]
	public float unlocks;

	[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false, backingValue = ShowBackingValue.Never)]
	public float requirements;

	public static string inputPortName = "requirements";

	public bool startUnlocked;

	public bool mystery;

	public float time;

	public ResearchTrigger trigger;

	public InventoryItem inventoryItemUnlock;

	public RoomCustomizationObject roomCustomizationObjectUnlock;

	public AdventureDestinationType unlockLocation;

	public override object GetValue(NodePort port)
	{
		return GetInputValue(inputPortName, requirements);
	}

	public string GetHeaderName()
	{
		string text = "";
		if (roomCustomizationObjectUnlock != null)
		{
			text += roomCustomizationObjectUnlock.GetName();
		}
		if (inventoryItemUnlock != null)
		{
			if (text.Length > 0)
			{
				text += " & ";
			}
			text += inventoryItemUnlock.itemNameLocalized;
		}
		return text;
	}

	public string GetResearchableObjectName()
	{
		return GetHeaderName().Replace(" ", string.Empty).Replace("&", string.Empty).Replace("\r", string.Empty) + "_Researchable";
	}
}
