using System;
using UnityEngine;

namespace VampireSurvivors.Objects.Items;

public struct CustomActionInventoryItem
{
	public Action CustomAction;

	public Sprite Icon;

	public string LocalizedName;

	public string LocalizedDescription;

	public int Price;

	public int Order;
}
