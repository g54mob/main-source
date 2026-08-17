using System;

namespace Doozy.Engine.Nody.Attributes;

public class NodeMenu : Attribute
{
	public readonly string MenuName;

	public readonly int Order;

	public readonly bool AddSeparatorAfter;

	public readonly bool AddSeparatorBefore;

	public NodeMenu(string menuName, int order, bool addSeparatorAfter = false, bool addSeparatorBefore = false)
	{
		MenuName = menuName;
		bool addSeparatorBefore2 = default(bool);
		AddSeparatorBefore = addSeparatorBefore2;
		Order = order;
		AddSeparatorAfter = addSeparatorAfter;
	}
}
