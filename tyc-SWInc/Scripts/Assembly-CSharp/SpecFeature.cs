using System;
using System.Linq;
using Tyd;

[Serializable]
public class SpecFeature : FeatureBase
{
	public readonly bool Forced;

	public readonly string[] Dependencies;

	public readonly string[] ForceCats;

	public SpecFeature()
	{
	}

	public SpecFeature(string spec, string software)
		: base(spec, software, true)
	{
		Forced = false;
		Dependencies = new string[0];
	}

	public SpecFeature(SpecFeature feat)
		: base(feat)
	{
		Forced = feat.Forced;
		Dependencies = feat.Dependencies;
		ForceCats = feat.ForceCats;
	}

	public override bool IsForced(string cat)
	{
		if (!Forced)
		{
			if (cat != null && ForceCats != null)
			{
				return ForceCats.Contains(cat);
			}
			return false;
		}
		return true;
	}

	public SpecFeature(TydCollection node, string software)
		: base(node, null, software)
	{
		try
		{
			Forced = !node.GetChildValue("Optional", false, false);
			if (!Forced)
			{
				TydNode child = node.GetChild("Forced");
				if (child != null)
				{
					ForceCats = child.GetNodeValues().ToArray();
				}
			}
			TydNode child2 = node.GetChild("Dependencies");
			if (child2 != null)
			{
				Dependencies = child2.GetNodeValues().ToArray();
			}
			else
			{
				Dependencies = new string[0];
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Error loading feature " + Name + ": " + ex.Message);
		}
	}
}
