using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;
using UnityEngine;

[Serializable]
public class FeatureBase
{
	public const int MaxSpecPoints = 3;

	public static float[] SpecLevelImpact = new float[4] { 0.5f, 1.5f, 3f, 0f };

	public readonly string Name;

	public readonly string Description;

	public readonly string Spec;

	public readonly string Software;

	public readonly float CodeArtRatio;

	public readonly float ServerRequirement;

	[AltWasFloat(0)]
	public readonly double[] Submarkets;

	public readonly float DevTime;

	public readonly float? HardwareFactor;

	public readonly int? Unlock;

	public readonly float RelativeServer = -1f;

	public uint ID = 1u;

	public readonly Dictionary<string, int> SoftwareCategories;

	public float SpecDevTime
	{
		get
		{
			return DevTime * SpecLevelImpact[Level];
		}
	}

	public virtual int Level
	{
		get
		{
			return 0;
		}
	}

	public virtual bool IsForced(string cat)
	{
		return false;
	}

	public FeatureBase()
	{
	}

	public FeatureBase(string OS, string sw)
	{
		Name = OS;
		Spec = "System";
		Software = sw;
		CodeArtRatio = 1f;
		ServerRequirement = 0f;
		Submarkets = new double[3];
		DevTime = 1f;
	}

	public FeatureBase(FeatureBase feat)
	{
		Name = feat.Name;
		Description = feat.Description;
		Spec = feat.Spec;
		CodeArtRatio = feat.CodeArtRatio;
		ServerRequirement = feat.ServerRequirement;
		RelativeServer = feat.RelativeServer;
		Submarkets = feat.Submarkets;
		DevTime = feat.DevTime;
		Unlock = feat.Unlock;
		SoftwareCategories = feat.SoftwareCategories;
		Software = feat.Software;
		HardwareFactor = feat.HardwareFactor;
	}

	public FeatureBase(string spec, string sw, bool specs)
	{
		Name = "NULL";
		Spec = spec;
		CodeArtRatio = 0f;
		ServerRequirement = 0f;
		RelativeServer = -1f;
		Submarkets = new double[3];
		Unlock = null;
		Software = sw;
		DevTime = 1f;
		HardwareFactor = null;
	}

	public static FeatureBase Clone(FeatureBase feat)
	{
		SpecFeature specFeature = feat as SpecFeature;
		if (specFeature != null)
		{
			return new SpecFeature(specFeature);
		}
		SubFeature subFeature = feat as SubFeature;
		if (subFeature != null)
		{
			return new SubFeature(subFeature);
		}
		return new AddOnFeature((AddOnFeature)feat);
	}

	private Dictionary<string, int> GetCategories(TydCollection node)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < node.Nodes.Count; i++)
		{
			TydNode tydNode = node.Nodes[i];
			TydCollection tydCollection = tydNode as TydCollection;
			if (tydCollection != null)
			{
				dictionary[tydCollection.GetChildValue(0)] = tydCollection.GetChildValue<int>(1);
				continue;
			}
			TydString tydString = tydNode as TydString;
			if (tydString != null)
			{
				dictionary[tydString.Value] = 0;
			}
		}
		return dictionary;
	}

	public FeatureBase(TydCollection node, string spec, string software, int? unlockOverride = null, Dictionary<string, int> categoryOverride = null)
	{
		try
		{
			Name = node.GetChildValue("Name");
			Description = node.GetChildValue("Description", false);
			Spec = spec ?? node.GetChildValue("Spec");
			HardwareFactor = node.GetChildValue<float?>("HardwareFactor", false);
			Unlock = node.GetChildValue<int?>("Unlock", false);
			Software = software;
			TydCollection child = node.GetChild<TydCollection>("SoftwareCategories");
			if (child != null)
			{
				SoftwareCategories = GetCategories(child);
				if (categoryOverride != null && categoryOverride.Count > 0)
				{
					foreach (KeyValuePair<string, int> item in categoryOverride)
					{
						int value;
						if (SoftwareCategories.TryGetValue(item.Key, out value) && item.Value > value)
						{
							SoftwareCategories[item.Key] = item.Value;
						}
					}
				}
				int num = SoftwareCategories.Min((KeyValuePair<string, int> x) => x.Value);
				Unlock = (Unlock.HasValue ? Mathf.Max(Unlock.Value, num) : num);
			}
			else if (categoryOverride != null && categoryOverride.Count > 0)
			{
				SoftwareCategories = categoryOverride;
				int num2 = SoftwareCategories.Min((KeyValuePair<string, int> x) => x.Value);
				Unlock = (Unlock.HasValue ? Mathf.Max(Unlock.Value, num2) : num2);
			}
			if (unlockOverride.HasValue && (!Unlock.HasValue || unlockOverride.Value > Unlock.Value))
			{
				Unlock = unlockOverride;
			}
			if (Unlock.HasValue && Unlock.Value == 0)
			{
				Unlock = null;
			}
			Submarkets = SoftwareType.GetSoftwareEq(node.GetChild("Submarkets", true), true);
			CodeArtRatio = Mathf.Clamp01(node.GetChildValue("CodeArt", true, 0f));
			DevTime = Mathf.Abs(node.GetChildValue("DevTime", true, 0f));
			TydString child2 = node.GetChild<TydString>("RelativeServer");
			if (child2 != null)
			{
				RelativeServer = child2.Value.ConvertToFloatDef(-1f);
			}
			ServerRequirement = Mathf.Clamp01(node.GetChildValue("Server", false, 0f));
		}
		catch (Exception ex)
		{
			throw new Exception("Error loading feature " + Name + ": " + ex.Message);
		}
	}

	public bool IsCompatible(string softwareCategory)
	{
		if (SoftwareCategories == null || softwareCategory == null)
		{
			return true;
		}
		return SoftwareCategories.ContainsKey(softwareCategory);
	}

	public bool IsUnlocked(int year)
	{
		if (Unlock.HasValue)
		{
			return year >= Unlock.Value - 1900;
		}
		return true;
	}

	public bool IsUnlocked(Dictionary<string, TechLevel> techs, SoftwareCategory cat)
	{
		return IsUnlocked(techs.GetOrDefault(Spec), cat);
	}

	public bool IsUnlocked(TechLevel tech, SoftwareCategory cat)
	{
		if (tech == null)
		{
			return false;
		}
		if (cat != null && SoftwareCategories != null)
		{
			int value = 0;
			if (SoftwareCategories.TryGetValue(cat.Name, out value))
			{
				if (tech.Year >= value - 1900)
				{
					return tech.Year >= (Unlock ?? 0) - 1900;
				}
				return false;
			}
			return false;
		}
		if (Unlock.HasValue)
		{
			return tech.Year >= Unlock.Value - 1900;
		}
		return true;
	}

	public int GetUnlock(SoftwareCategory cat)
	{
		if (cat != null)
		{
			if (SoftwareCategories != null)
			{
				int orDefault = SoftwareCategories.GetOrDefault(cat.Name, 0);
				return (Unlock.HasValue ? Mathf.Max(orDefault, Unlock.Value) : orDefault) + (cat.LagBehind ?? 0);
			}
			return (Unlock ?? 0) + (cat.LagBehind ?? 0);
		}
		return Unlock ?? 0;
	}

	public override string ToString()
	{
		return Name;
	}

	public bool RelevantFor(Employee.EmployeeRole role)
	{
		switch (role)
		{
		case Employee.EmployeeRole.Designer:
			return true;
		case Employee.EmployeeRole.Artist:
			return CodeArtRatio < 1f;
		case Employee.EmployeeRole.Programmer:
			return CodeArtRatio > 0f;
		default:
			return false;
		}
	}

	public double[] GetSubAdd(SoftwareCategory parent, TechLevel tech, double[] sub, bool add = false)
	{
		return GetSubAdd(parent, tech, -1.0, sub, add);
	}

	public double[] GetSubAdd(SoftwareCategory parent, TechLevel tech, double quality, double[] sub, bool add = false)
	{
		double[] array = sub ?? new double[3];
		if (Level == 3)
		{
			if (!add)
			{
				for (int i = 0; i < 3; i++)
				{
					array[i] = 0.0;
				}
			}
			return array;
		}
		double subAdd = GetSubAdd(parent, tech, quality);
		for (int j = 0; j < 3; j++)
		{
			double num = Submarkets[j] * subAdd;
			if (add)
			{
				array[j] += num;
			}
			else
			{
				array[j] = num;
			}
		}
		return array;
	}

	public double GetSubAdd(SoftwareCategory parent, TechLevel tech)
	{
		if (Level == 3)
		{
			return 0.0;
		}
		return GetSubScale(tech, parent, -1.0) * (double)(SpecDevTime * GetHardwareScale(parent, 0u) / parent.Parent.OptimalDevTime);
	}

	public double GetSubAdd(SoftwareCategory parent, TechLevel tech, double quality)
	{
		if (Level == 3)
		{
			return 0.0;
		}
		return GetSubScale(tech, parent, quality) * (double)(SpecDevTime * GetHardwareScale(parent, 0u) / parent.Parent.OptimalDevTime);
	}

	protected float GetHardwareScale(IManufacturable parent, uint factor)
	{
		if (!parent.IsHardware() || !parent.GetManufacturing().IsDependency(Name, factor))
		{
			return 1f;
		}
		return HardwareFactor ?? 6f;
	}

	public static double GetSubScale(TechLevel tech, SoftwareCategory cat, double quality)
	{
		if (tech == null)
		{
			if (!(quality < 0.0))
			{
				return quality;
			}
			return 1.0;
		}
		float relevancy = tech.GetRelevancy(cat);
		if (!(quality < 0.0))
		{
			return Utilities.Lerp((double)relevancy * quality * 0.5, Math.Max(relevancy, quality * 0.5), quality, true);
		}
		return relevancy;
	}

	public float GetDevTime(SoftwareCategory cat, Company c, Dictionary<string, TechLevel> techs, SoftwareProduct sequelTo, SoftwareFramework framework, bool newFramework, bool boosts = true)
	{
		float num = DevTime;
		if (cat != null)
		{
			num *= cat.TimeScale;
		}
		int num2 = 0;
		TechLevel value = null;
		if (techs != null && techs.TryGetValue(Spec, out value))
		{
			num *= value.GetDevTime();
			num2 = value.Year;
			if (boosts && c != null && c.GetLatestResearch(Spec, -1) >= num2)
			{
				num *= 0.9f;
			}
		}
		if (sequelTo != null && sequelTo.Features.Contains(this))
		{
			num *= Mathf.Lerp(1f, SoftwareType.SequelBoost, (float)sequelTo.RealQuality);
		}
		TechLevel value2;
		double value3;
		if (newFramework)
		{
			num *= 1.25f;
		}
		else if (framework != null && framework.TechLevels.TryGetValue(Spec, out value2) && framework.Features.TryGetValue(this, out value3))
		{
			if (value != null)
			{
				value3 *= (double)SoftwareFramework.SpeedBoost(value2, value);
			}
			num *= (float)value3.MapRange(0.0, 1.0, 1.0, 0.75);
		}
		return num;
	}

	public string GetLocalizedName()
	{
		return Localization.GetFeature(this)[0];
	}
}
