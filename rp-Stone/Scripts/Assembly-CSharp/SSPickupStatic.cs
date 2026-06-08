using System.Collections.Generic;

public class SSPickupStatic : StonescriptObject
{
	public SSPickupStatic()
	{
		SSScriptableObject.Bind(this, this);
	}

	[StonescriptNativeMethod]
	public object NewTreasure(List<object> parameters, InvocationContext ctx)
	{
		string text = parameters[0] as string;
		TreasurePickup component = Utils.InstantiatePrefab("Treasure/" + text).GetComponent<TreasurePickup>();
		GameStates.Singleton.level.AddCharacter(component);
		StonescriptArray obj = parameters[1] as StonescriptArray;
		List<Data.ItemInTreasure> list = new List<Data.ItemInTreasure>();
		foreach (object item2 in obj)
		{
			Data.ItemInTreasure item = Data.ItemInTreasure.FromStonescriptObject(item2 as StonescriptObject);
			list.Add(item);
		}
		component.itemsInTreasure = list.ToArray();
		component.tags.Add("quest");
		return component.ssObject;
	}
}
