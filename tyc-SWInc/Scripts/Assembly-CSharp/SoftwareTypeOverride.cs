using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;

public class SoftwareTypeOverride
{
	public readonly string Name;

	public readonly string Description;

	public readonly string NameGenerator;

	public string[] Submarkets;

	public string[] OSLimit;

	public readonly float? RandomFactor;

	public readonly float? Popularity;

	public readonly bool? OneClient;

	public readonly bool? InHouse;

	public readonly bool? Hardware;

	public readonly FeatureBase[] Features;

	public readonly SoftwareCategory[] Categories;

	public readonly SoftwareAddOn[] AddOns;

	public readonly Dictionary<string, string> CategoryRngs;

	public readonly int? Unlock;

	public readonly float? IdealPrice;

	public readonly bool Delete;

	public readonly Manufacturing Manufacturing;

	public string ModName;

	public SoftwareTypeOverride(TydCollection node, string pathRoot)
	{
		SoftwareTypeOverride softwareTypeOverride = this;
		Delete = node.GetChildValue("Override", false, "").ToLower().Equals("delete");
		Name = node.GetChildValue("Name");
		Description = node.GetChildValue("Description", false);
		RandomFactor = node.GetChildValue<float?>("Random", false);
		Popularity = node.GetChildValue<float?>("Popularity", false);
		TydTable child = node.GetChild<TydTable>("Manufacturing");
		if (child != null)
		{
			Manufacturing = new Manufacturing(child, pathRoot);
		}
		TydNode child2 = node.GetChild("OSSupport");
		if (child2 != null)
		{
			OSLimit = child2.GetNodeValues().ToArray();
			if (OSLimit.Length == 1 && OSLimit[0] == null)
			{
				OSLimit = null;
			}
			else if (OSLimit.Length == 1 && OSLimit[0].ConvertToBoolDef(false))
			{
				OSLimit = new string[0];
			}
		}
		else
		{
			OSLimit = null;
		}
		TydCollection child3 = node.GetChild<TydCollection>("SubmarketNames");
		if (child3 != null)
		{
			Submarkets = child3.GetChildValues().ToArray();
			if (Submarkets.Length != 3)
			{
				throw new Exception("Incorrect number of submarket names supplied. Needs 3");
			}
		}
		OneClient = node.GetChildValue<bool?>("OneClient", false);
		InHouse = node.GetChildValue<bool?>("InHouse", false);
		Hardware = node.GetChildValue<bool?>("Hardware", false);
		IdealPrice = node.GetChildValue<float?>("IdealPrice", false);
		TydCollection child4 = node.GetChild<TydCollection>("Categories");
		if (child4 != null)
		{
			Categories = (from x in child4.Nodes.OfType<TydCollection>()
				select new SoftwareCategory(null, x, null, softwareTypeOverride.IdealPrice, softwareTypeOverride.Hardware, softwareTypeOverride.Manufacturing, pathRoot)).ToArray();
			if (Categories.Length == 0)
			{
				Categories = null;
			}
			else
			{
				CategoryRngs = child4.OfType<TydCollection>().ToDictionary((TydCollection x) => x.GetChildValue("Name"), (TydCollection x) => x.GetChildValue("NameGenerator", false));
			}
		}
		else
		{
			Categories = null;
		}
		TydCollection child5 = node.GetChild<TydCollection>("AddOns");
		if (child5 != null)
		{
			AddOns = (from x in child5.Nodes.OfType<TydCollection>()
				select new SoftwareAddOn(null, x, pathRoot, softwareTypeOverride.Name)).ToArray();
			if (AddOns.Length == 0)
			{
				AddOns = null;
			}
		}
		else
		{
			AddOns = null;
		}
		NameGenerator = node.GetChildValue("NameGenerator", false);
		TydCollection child6 = node.GetChild<TydCollection>("Features");
		if (child6 != null)
		{
			Dictionary<string, FeatureBase> dictionary = new Dictionary<string, FeatureBase>();
			foreach (TydCollection item in child6.Nodes.OfType<TydCollection>())
			{
				bool childValue = item.GetChildValue("Ignore", false, false);
				SpecFeature specFeature = (childValue ? new SpecFeature(item.GetChildValue("Spec"), Name) : new SpecFeature(item, Name));
				if (!childValue)
				{
					if (dictionary.ContainsKey(specFeature.Name))
					{
						throw new Exception("Can't re-use feature name: " + specFeature.Name);
					}
					dictionary[specFeature.Name] = specFeature;
				}
				TydCollection child7 = item.GetChild<TydCollection>("Features");
				if (child7 == null)
				{
					continue;
				}
				foreach (TydCollection item2 in child7.Nodes.OfType<TydCollection>())
				{
					SubFeature subFeature = new SubFeature(item2, specFeature, Name, pathRoot);
					if (dictionary.ContainsKey(subFeature.Name))
					{
						throw new Exception("Can't re-use feature name: " + subFeature.Name);
					}
					dictionary[subFeature.Name] = subFeature;
				}
			}
			Features = ((dictionary.Count == 0) ? null : dictionary.Values.ToArray());
		}
		else
		{
			Features = null;
		}
		Unlock = node.GetChildValue<int?>("Unlock", false);
	}
}
