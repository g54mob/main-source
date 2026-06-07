using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockBodyModel
{
	private readonly List<FixedJointModel> fixedJointModelList;

	private readonly List<HingeJointModel> hingeJointModelList;

	private readonly List<FixedJointModel> outsideFixedJointModelList;

	private readonly List<HingeJointModel> outsideHingeJointModelList;

	private readonly Dictionary<string, ComponentModel> componentModelMap;

	private readonly Dictionary<string, DefaultKeyIO> defaultKeyIOs;

	private readonly Dictionary<string, OverridablePropertyModel> overridableProperties;

	public BlockModel ParentBlockModel { get; set; }

	public int Index { get; set; }

	public BodySchematic BodySchematic { get; set; }

	public TwoPointBlockModel TwoPointBlockModel { get; set; }

	public BlockBodyModel()
	{
		Index = 0;
		fixedJointModelList = new List<FixedJointModel>();
		hingeJointModelList = new List<HingeJointModel>();
		outsideFixedJointModelList = new List<FixedJointModel>();
		outsideHingeJointModelList = new List<HingeJointModel>();
		componentModelMap = new Dictionary<string, ComponentModel>();
		defaultKeyIOs = new Dictionary<string, DefaultKeyIO>();
		overridableProperties = new Dictionary<string, OverridablePropertyModel>();
		BodySchematic = null;
	}

	public void AddFixedJointModel(FixedJointModel fixedJointModel)
	{
		fixedJointModel.ParentBlockBodyModel = this;
		fixedJointModel.Index = fixedJointModelList.Count;
		fixedJointModelList.Add(fixedJointModel);
	}

	public void RemoveFixedJointModel(FixedJointModel fixedJointModel)
	{
		if (fixedJointModelList.Contains(fixedJointModel))
		{
			fixedJointModelList.Remove(fixedJointModel);
		}
		for (int i = 0; i < fixedJointModelList.Count; i++)
		{
			fixedJointModelList[i].Index = i;
		}
	}

	public FixedJointModel GetFixedJointModel(int index)
	{
		return fixedJointModelList[index];
	}

	public ICollection<FixedJointModel> GetAllFixedJointModel()
	{
		return fixedJointModelList.ToArray();
	}

	public void AddHingeJointModel(HingeJointModel hingeJointModel)
	{
		hingeJointModel.ParentBlockBodyModel = this;
		hingeJointModel.Index = hingeJointModelList.Count;
		hingeJointModelList.Add(hingeJointModel);
	}

	public void RemoveHingeJointModel(HingeJointModel hingeJointModel)
	{
		if (hingeJointModelList.Contains(hingeJointModel))
		{
			hingeJointModel.DetachHingeOnMotorBlock();
			hingeJointModelList.Remove(hingeJointModel);
			for (int i = 0; i < hingeJointModelList.Count; i++)
			{
				hingeJointModelList[i].Index = i;
			}
		}
	}

	public HingeJointModel GetHingeJointModel(int index)
	{
		return hingeJointModelList[index];
	}

	public ICollection<HingeJointModel> GetAllHingeJointModel()
	{
		return hingeJointModelList.ToArray();
	}

	public void AddComponentModel(ComponentModel componentModel)
	{
		componentModel.ParentBlockBodyModel = this;
		componentModel.Initialize();
		componentModelMap.Add(componentModel.Name, componentModel);
	}

	public ComponentModel GetComponentModel(string name)
	{
		if (componentModelMap.ContainsKey(name))
		{
			return componentModelMap[name];
		}
		return null;
	}

	public ComponentModel GetComponentModel(ComponentType Type)
	{
		return componentModelMap.Values.Where((ComponentModel component) => component.Type == Type).FirstOrDefault();
	}

	public ICollection<ComponentModel> GetAllComponentModel()
	{
		return componentModelMap.Values;
	}

	public bool HasComponentModel()
	{
		return componentModelMap.Count > 0;
	}

	public void AddOutsideFixedJointModel(FixedJointModel fixedJointModel)
	{
		outsideFixedJointModelList.Add(fixedJointModel);
	}

	public void RemoveOutsideFixedJointModel(FixedJointModel fixedJointModel)
	{
		outsideFixedJointModelList.Remove(fixedJointModel);
	}

	public ICollection<FixedJointModel> GetAllOutsideFixedJointModel()
	{
		return outsideFixedJointModelList.ToArray();
	}

	public void AddOutsideHingeJointModel(HingeJointModel hingeJointModel)
	{
		outsideHingeJointModelList.Add(hingeJointModel);
	}

	public void RemoveOutsideHingeJointModel(HingeJointModel hingeJointModel)
	{
		outsideHingeJointModelList.Remove(hingeJointModel);
	}

	public ICollection<HingeJointModel> GetAllOutsideHingeJointModel()
	{
		return outsideHingeJointModelList.ToArray();
	}

	public DefaultKeyIO AddDefaultKeyIO(DefaultKeyIO defaultKey)
	{
		if (!defaultKeyIOs.ContainsKey(defaultKey.Name))
		{
			defaultKey.ParentBlockBodyModel = this;
			defaultKeyIOs.Add(defaultKey.Name, defaultKey);
		}
		return defaultKey;
	}

	public void SetDefaultKeyIO(string name, KeyCode keyValue, AxisCode axisValue)
	{
		if (defaultKeyIOs.ContainsKey(name))
		{
			defaultKeyIOs[name].KeyValue = keyValue;
			defaultKeyIOs[name].AxisValue = axisValue;
		}
		else
		{
			AddDefaultKeyIO(new DefaultKeyIO(name, keyValue));
		}
	}

	public DefaultKeyIO GetDefaultKeyIO(string name)
	{
		if (defaultKeyIOs.ContainsKey(name))
		{
			return defaultKeyIOs[name];
		}
		return AddDefaultKeyIO(new DefaultKeyIO(name, KeyCode.None));
	}

	public void RemoveDefaultKeyIO(string name)
	{
		if (defaultKeyIOs.ContainsKey(name))
		{
			defaultKeyIOs[name].ParentBlockBodyModel = null;
			defaultKeyIOs.Remove(name);
		}
	}

	public ICollection<DefaultKeyIO> GetAllDefaultKeyIOs()
	{
		return defaultKeyIOs.Values;
	}

	public void CopyAllDefaultKeyIOs(BlockBodyModel originalBlockBodyModel)
	{
		defaultKeyIOs.Clear();
		foreach (DefaultKeyIO allDefaultKeyIO in originalBlockBodyModel.GetAllDefaultKeyIOs())
		{
			if (allDefaultKeyIO.Place != DefaultKeyIOPlace.HingeJoint)
			{
				string name = allDefaultKeyIO.Name;
				KeyCode keyValue = allDefaultKeyIO.KeyValue;
				AxisCode axisValue = allDefaultKeyIO.AxisValue;
				SetDefaultKeyIO(name, keyValue, axisValue);
			}
		}
	}

	public bool HasDefaultKeyIO()
	{
		return defaultKeyIOs.Count > 0;
	}

	public bool HasOnlyOutputDefaultKeyIOs()
	{
		return !defaultKeyIOs.Values.Any((DefaultKeyIO defaultKeyIOs) => defaultKeyIOs.Direction == DefaultKeyIODirection.Input && !defaultKeyIOs.IsInputWithoutKey);
	}

	public bool HasOnlyHiddenDefaultKeyIOs()
	{
		if (defaultKeyIOs.Count > 0)
		{
			return defaultKeyIOs.Values.All((DefaultKeyIO key) => key.IsHiddenInLogic);
		}
		return false;
	}

	public bool HasOnlyHingeJointIOs()
	{
		bool result = false;
		foreach (DefaultKeyIO value in defaultKeyIOs.Values)
		{
			if (value.Place == DefaultKeyIOPlace.HingeJoint)
			{
				result = true;
				continue;
			}
			return false;
		}
		return result;
	}

	public T AddOverridableProperty<T>(T property) where T : OverridablePropertyModel
	{
		property.ParentBlockBodyModel = this;
		overridableProperties.Add(property.Key, property);
		return property;
	}

	public void SetOverridableProperty(string key, string value)
	{
		if (overridableProperties.ContainsKey(key))
		{
			overridableProperties[key].Value = value;
		}
		else
		{
			overridableProperties.Add(key, new OverridablePropertyModel(key, value));
		}
	}

	public OverridablePropertyModel GetOverridableProperty(string key)
	{
		if (!overridableProperties.ContainsKey(key))
		{
			return null;
		}
		return overridableProperties[key];
	}

	public ICollection<OverridablePropertyModel> GetAllOverridableProperties()
	{
		return overridableProperties.Values;
	}

	public void CopyAllOverridableProperties(BlockBodyModel originalBlockBodyModel)
	{
		overridableProperties.Clear();
		foreach (OverridablePropertyModel allOverridableProperty in originalBlockBodyModel.GetAllOverridableProperties())
		{
			string key = allOverridableProperty.Key;
			string value = allOverridableProperty.Value;
			overridableProperties.Add(key, new OverridablePropertyModel(key, value));
		}
	}

	public bool HasOverridableProperty()
	{
		return overridableProperties.Count > 0;
	}

	public bool HasMotorComponent()
	{
		return GetComponentModel(ComponentType.Motor) != null;
	}
}
