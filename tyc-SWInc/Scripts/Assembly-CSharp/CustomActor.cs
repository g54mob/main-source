using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CustomActor
{
	public bool Female;

	public ActorBodyItem.BodyItemObject[] BodyItems;

	public string[] Personality;

	public Employee.Trait[] Traits;

	public float[] Skills;

	public Dictionary<string, int>[] Specs;

	public CustomActor()
	{
	}

	public CustomActor(Employee employee)
	{
		Female = employee.Female;
		BodyItems = employee.StyleGen;
		Personality = employee.PersonalityTraits;
		Traits = Employee.EnumTraits(employee.Traits).ToArray();
		Skills = new float[5];
		for (int i = 0; i < Skills.Length; i++)
		{
			Skills[i] = employee.GetSkillI(i);
		}
		Specs = employee.GetAllSpecializations();
	}

	public CustomActor(bool female, ActorBodyItem.BodyItemObject[] bodyItems, string[] personality, Employee.Trait[] traits, float[] skills, Dictionary<string, int>[] specs)
	{
		Female = female;
		BodyItems = bodyItems;
		Personality = personality;
		Traits = traits;
		Skills = skills;
		Specs = specs;
	}

	public CustomActor(XMLParser.XMLNode root, bool forceTraits = false)
	{
		Female = root.Name.Equals("Female");
		BodyItems = (from x in root.Children
			where !x.Name.Equals("AccessoryWatch") && !x.Name.Equals("Stats")
			select new ActorBodyItem.BodyItemObject(x)).ToArray();
		XMLParser.XMLNode node = root.GetNode("Stats", false);
		if (node == null)
		{
			return;
		}
		XMLParser.XMLNode node2 = node.GetNode("Skills", false);
		if (node2 != null)
		{
			Skills = node2.Value.Split(',').SelectInPlace((string x) => Mathf.Clamp01(x.ConvertToFloatDef(1f)));
		}
		XMLParser.XMLNode node3 = node.GetNode("Specs", false);
		if (node3 != null)
		{
			Specs = new Dictionary<string, int>[5];
			for (int num = 0; num < node3.Children.Count; num++)
			{
				Specs[num] = new Dictionary<string, int>();
				foreach (XMLParser.XMLNode child in node3.Children[num].Children)
				{
					Specs[num][child.Name] = Mathf.Clamp(child.Value.ConvertToIntDef(0), 0, 3);
				}
			}
		}
		XMLParser.XMLNode node4 = node.GetNode("Personality", false);
		if (node4 != null)
		{
			Personality = node4.Value.Split(',');
		}
		XMLParser.XMLNode node5 = node.GetNode("Traits", false);
		if (node5 == null)
		{
			return;
		}
		Traits = node5.Value.Split(',').SelectInPlace((string x) => x.ToEnum<Employee.Trait>());
		int good = 0;
		int bad = 0;
		int neutral = 0;
		for (int num2 = 0; num2 < Traits.Length; num2++)
		{
			Employee.IncTraitType(Employee.TraitOrder(Traits[num2]), ref good, ref neutral, ref bad);
		}
		bool flag = good <= 2 && bad <= 2 && neutral <= 1;
		if (flag)
		{
			if ((good == 2 || bad == 2) && neutral > 0)
			{
				flag = false;
			}
			else if (neutral == 1 && good > 1 && bad > 1)
			{
				flag = false;
			}
		}
		if (!forceTraits && !flag)
		{
			Traits = null;
		}
	}

	public XMLParser.XMLNode Serialize()
	{
		XMLParser.XMLNode xMLNode = new XMLParser.XMLNode(Female ? "Female" : "Male");
		xMLNode.Children.AddRange(BodyItems.Select((ActorBodyItem.BodyItemObject x) => x.Serialize()));
		XMLParser.XMLNode xMLNode2 = new XMLParser.XMLNode("Stats");
		xMLNode.Children.Add(xMLNode2);
		xMLNode2.Children.Add(new XMLParser.XMLNode("Skills", string.Join(",", Skills.Select((float x) => x.ToString()))));
		xMLNode2.Children.Add(new XMLParser.XMLNode("Specs", Specs.SelectInPlace((Dictionary<string, int> x) => new XMLParser.XMLNode("Spec", x.Select((KeyValuePair<string, int> z) => new XMLParser.XMLNode(z.Key, z.Value.ToString())).ToArray()))));
		xMLNode2.Children.Add(new XMLParser.XMLNode("Personality", string.Join(",", Personality)));
		xMLNode2.Children.Add(new XMLParser.XMLNode("Traits", string.Join(",", Traits.Select((Employee.Trait x) => x.ToString()))));
		return xMLNode;
	}
}
