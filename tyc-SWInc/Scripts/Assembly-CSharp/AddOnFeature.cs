using System;
using System.Collections.Generic;
using StatementParser;
using Tyd;

[Serializable]
public class AddOnFeature : FeatureBase
{
	private readonly int _level;

	public readonly string FeatureDependency;

	public readonly uint MaxFactor = 1u;

	public readonly bool IsBase;

	public new readonly bool IsForced;

	private readonly string _amountScript;

	[NonSerialized]
	private LineParse.TreeNode _amountCompiled;

	public override int Level
	{
		get
		{
			return _level;
		}
	}

	public string GetAmount(uint a)
	{
		if (_amountScript == null)
		{
			return a.ToString("N0");
		}
		if (_amountCompiled == null)
		{
			_amountCompiled = LineParse.Parse(_amountScript);
		}
		return LineParse.Execute(_amountCompiled, ScriptSystem.AddOnAmount.GetTemp(a)).ToString();
	}

	public AddOnFeature()
	{
	}

	public AddOnFeature(AddOnFeature feat)
		: base(feat)
	{
		_level = feat.Level;
		MaxFactor = feat.MaxFactor;
		FeatureDependency = feat.FeatureDependency;
		_amountScript = feat._amountScript;
		_amountCompiled = feat._amountCompiled;
		IsBase = feat.IsBase;
		IsForced = feat.IsForced;
	}

	public AddOnFeature(TydCollection node, string spec, string software, bool isBase)
		: base(node, spec, software)
	{
		try
		{
			if (isBase)
			{
				_level = 0;
				MaxFactor = 1u;
				FeatureDependency = null;
				IsBase = true;
				IsForced = true;
				return;
			}
			_level = node.GetChildValue("Level", true, 0);
			MaxFactor = node.GetChildValue("MaxFactor", false, 1u);
			_amountScript = node.GetChildValue("AmountScript", false);
			IsForced = node.GetChildValue("Forced", false, false);
			if (_amountScript != null)
			{
				_amountCompiled = LineParse.Parse(_amountScript);
				LineParse.GetType(_amountCompiled, ScriptSystem.AddOnAmount.GetTemp(0u));
			}
			if (MaxFactor < 1)
			{
				MaxFactor = 1u;
			}
			FeatureDependency = node.GetChildValue("DependsOn", false);
			if (_level >= 0 && _level <= 2)
			{
				return;
			}
			throw new Exception("Feature level has to be between 0 and 2, inclusive");
		}
		catch (Exception ex)
		{
			throw new Exception("Error loading feature " + Name + ": " + ex.Message);
		}
	}

	public double[] GetSubAdd(SoftwareAddOn parent, SoftwareCategory category, TechLevel tech, double[] sub, uint factor, bool add = false)
	{
		return GetSubAdd(parent, category, tech, -1.0, sub, factor, add);
	}

	public double[] GetSubAdd(SoftwareAddOn parent, SoftwareCategory category, TechLevel tech, double quality, double[] sub, uint factor, bool add = false)
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
		double subAdd = GetSubAdd(parent, category, tech, quality, factor);
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

	public double GetSubAdd(SoftwareAddOn parent, SoftwareCategory category, TechLevel tech, uint factor)
	{
		if (Level == 3)
		{
			return 0.0;
		}
		return (double)factor * FeatureBase.GetSubScale(tech, category, -1.0) * (double)(base.SpecDevTime * GetHardwareScale(parent, factor) / parent.OptimalDevTime);
	}

	public double GetSubAdd(SoftwareAddOn parent, SoftwareCategory category, TechLevel tech, double quality, uint factor)
	{
		if (Level == 3)
		{
			return 0.0;
		}
		return (double)factor * FeatureBase.GetSubScale(tech, category, quality) * (double)(base.SpecDevTime * GetHardwareScale(parent, factor) / parent.OptimalDevTime);
	}

	public float GetDevTime(SoftwareCategory cat, Company c, Dictionary<string, TechLevel> techs, uint factor)
	{
		return GetDevTime(cat, c, techs, null, null, false) * (float)factor;
	}
}
