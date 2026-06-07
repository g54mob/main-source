using System;

[AttributeUsage(AttributeTargets.Field)]
public class FurnModAttr : Attribute
{
	public enum VariableType
	{
		String = 0,
		BigString = 1,
		Integer = 2,
		Float = 3,
		PercentSlider = 4,
		TransformPosition = 5,
		TransformRotation = 6,
		TransformScale = 7,
		TransformParent = 8,
		Mesh = 9,
		Material = 10,
		Combo = 11,
		Color = 12,
		Bool = 13,
		SubComponent = 14,
		ExternalComponent = 15,
		ExternalMeta = 16,
		Enum = 17,
		Vector2 = 18,
		Vector3 = 19,
		FurnitureStyle = 20
	}

	[Flags]
	public enum ItemType
	{
		None = 0,
		Furniture = 1,
		RoomSegment = 2,
		Everything = 3
	}

	public string VarName;

	public string Desc;

	public string ReflectProp;

	public string CallMethod;

	public string Dependency;

	public string FetchList;

	public string WriteDirectParent;

	public object DependencyValue;

	public bool Hidden;

	public bool ReflectTarget;

	public bool IsArray;

	public bool IsList;

	public bool CanDisableComp = true;

	public bool ReverseDependency;

	public bool CanInstantiate;

	public bool MetaLocal;

	public float LowerBound;

	public float UpperBound = 1f;

	public int ArrayIndex = -1;

	public Type ComponentType;

	public Type MetaType;

	public VariableType Type;

	public ItemType ValidFor = ItemType.Everything;

	public FurnModAttr(string varName, VariableType type)
	{
		VarName = varName;
		Type = type;
	}

	public FurnModAttr(string varName, Type componentType)
	{
		VarName = varName;
		Type = VariableType.SubComponent;
		ComponentType = componentType;
	}
}
