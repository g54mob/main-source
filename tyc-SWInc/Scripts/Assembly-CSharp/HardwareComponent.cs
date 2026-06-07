using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tyd;
using UnityEngine;

[Serializable]
[AltDeprecate("ActiveJob", typeof(PrintJob))]
[AltDeprecate("PrintAmount", typeof(int))]
public class HardwareComponent
{
	public readonly string Name;

	public readonly string BuiltInThumbnail;

	public readonly string DependsOn;

	public readonly float Price;

	public readonly int Time;

	public readonly int Index;

	public readonly int Mask;

	public readonly uint DependMin;

	public readonly uint DependMax = uint.MaxValue;

	public readonly Manufacturing Parent;

	public string Thumbnail;

	public ComponentProcess InputProcess;

	public ComponentProcess OutputProcess;

	[NonSerialized]
	public int AtlasIndex;

	[NonSerialized]
	public bool assembled;

	[NonSerialized]
	public string Texture;

	public int Recycled;

	public HardwareComponent()
	{
	}

	public HardwareComponent(HardwareComponent o, Manufacturing parent)
	{
		Name = o.Name;
		Thumbnail = o.Thumbnail;
		BuiltInThumbnail = o.BuiltInThumbnail;
		DependsOn = o.DependsOn;
		DependMin = o.DependMin;
		DependMax = o.DependMax;
		Price = o.Price;
		Time = o.Time;
		Index = o.Index;
		Mask = o.Mask;
		Parent = parent;
		Texture = o.Texture;
	}

	public bool Valid(IList<FeatureBase> features, IList<uint> factors)
	{
		if (DependsOn == null)
		{
			return true;
		}
		int num = features.FindIndex((FeatureBase x) => x.Name.Equals(DependsOn));
		if (num >= 0)
		{
			if (DependMin == 0 || factors == null)
			{
				return true;
			}
			uint num2 = factors[num];
			if (num2 >= DependMin)
			{
				return num2 <= DependMax;
			}
			return false;
		}
		return false;
	}

	public HardwareComponent(TydTable root, int index, Manufacturing parent, string modPath)
	{
		Parent = parent;
		Name = root.GetChildValue("Name");
		Thumbnail = root.GetChildValue("Thumbnail", false);
		BuiltInThumbnail = root.GetChildValue("BuiltInThumbnail", false, "Unknown");
		if (modPath != null && Thumbnail != null)
		{
			try
			{
				string text = Path.Combine(modPath, Thumbnail);
				if (File.Exists(text))
				{
					Texture = text;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
		DependsOn = root.GetChildValue("DependsOn", false);
		TydNode child = root.GetChild("DependencyFactor");
		if (child != null)
		{
			if (child is TydString)
			{
				int num = ((TydString)child).Value.ConvertToIntDef(0);
				if (num > 0)
				{
					DependMin = (DependMax = (uint)num);
				}
			}
			else
			{
				TydList tydList = child as TydList;
				if (tydList != null)
				{
					uint[] array = tydList.GetChildValues<uint>().ToArray();
					if (array.Length > 1 && array[0] != 0 && array[1] >= array[0])
					{
						DependMin = array[0];
						DependMax = array[1];
					}
				}
			}
		}
		Price = root.GetChildValue("Price", true, 0f);
		Time = root.GetChildValue("Time", true, 0);
		Index = index;
		Mask = 1 << Index;
	}

	public string GetBaseName()
	{
		return Localization.GetSoftwareComponent(Parent.Type, Name);
	}

	public string GetPrettyName()
	{
		return GetBaseName() + " (" + Parent.Category.GetPrettyName() + ")";
	}

	public override string ToString()
	{
		return Name + " (" + Parent.Category.ToString() + ")";
	}

	public string GetPath()
	{
		return Parent.Type.Name + "/" + Parent.Category.GetActualName() + "/" + Name;
	}
}
