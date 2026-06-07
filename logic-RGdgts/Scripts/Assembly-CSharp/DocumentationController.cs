using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DocumentationController : Controller
{
	[Serializable]
	public abstract class Element
	{
		public string name;

		public string documentationSymbol;

		public string GetDocumentationText(string locale = null)
		{
			return null;
		}
	}

	[Serializable]
	public class Gadget : Element
	{
	}

	[Serializable]
	public class MethodParameter : Element
	{
		public DocumentationType documentationType;

		public MethodParameter(string name, Type type)
		{
		}
	}

	[Serializable]
	public class Method : Element
	{
		public List<MethodParameter> parameters;

		public DocumentationType? returnType;

		public bool isStatic;

		public Method()
		{
		}

		public Method(string name, DocumentationType? returnType, bool isStatic, IEnumerable<MethodParameter> parameters, string documentationSymbol)
		{
		}
	}

	[Serializable]
	public class Property : Element
	{
		public DocumentationType documentationType;

		public bool isReadonly;

		public Property()
		{
		}

		public Property(string name, DocumentationType documentationType, bool isReadonly, string documentationSymbol)
		{
		}
	}

	[Serializable]
	public class ModuleProperty : Property
	{
		public string table;

		public int documentationOrder;
	}

	[Serializable]
	public class ModuleVariation
	{
		public ModuleGestaltVariationEnum id;

		public ModuleVariation()
		{
		}

		public ModuleVariation(ModuleGestaltVariationEnum id)
		{
		}
	}

	[Serializable]
	public class Module : Element
	{
		public ModuleGestaltEnum id;

		public ModuleGestalt.ModuleCategory category;

		public Dictionary<string, ModuleProperty> properties;

		public Dictionary<string, Method> methods;

		public Dictionary<string, ModuleEvent> events;

		public List<string> inputNames;

		public Dictionary<string, ModuleVariation> variations;
	}

	[Serializable]
	public class EventField : Element
	{
		public DocumentationType documentationType;

		public EventField(string name, Type type)
		{
		}
	}

	[Serializable]
	public class ModuleEvent : Element
	{
		[JsonIgnore]
		public Module module;

		public List<EventField> fields;

		public string moduleType => null;
	}

	[Serializable]
	public class Asset : Element
	{
		public AssetType id;

		public Dictionary<string, Property> properties;

		public Dictionary<string, Method> methods;
	}

	[Serializable]
	public class DataSelectionValue : Element
	{
		public DataSelectionValue()
		{
		}

		public DataSelectionValue(string name, string documentationSymbol)
		{
		}
	}

	[Serializable]
	public class DataSelection : Element
	{
		public DataSelectionGestaltEnum id;

		public Dictionary<string, DataSelectionValue> values;
	}

	[Serializable]
	public class MiscLuaType : Element
	{
		public Dictionary<string, Property> properties;

		public Dictionary<string, Method> staticMethods;

		public Dictionary<string, Method> methods;

		public MiscLuaType()
		{
		}

		public MiscLuaType(string name)
		{
		}
	}

	[Serializable]
	public class Documentation
	{
		public Gadget gadget;

		public Dictionary<string, Property> globalVars;

		public Dictionary<string, Module> modules;

		public Dictionary<string, ModuleEvent> moduleEvents;

		public Asset asset;

		public Dictionary<string, Asset> assets;

		public Dictionary<string, Dictionary<string, Method>> globalMethods;

		public Dictionary<string, DataSelection> dataSelections;

		public Dictionary<string, MiscLuaType> miscLuaTypes;

		public void Generate()
		{
		}

		private void GenerateModules()
		{
		}

		private void GenerateGlobalMethods()
		{
		}

		private void GenerateAssets()
		{
		}

		private void GenerateSelections()
		{
		}

		private void GenerateMiscLuaTypes()
		{
		}

		public Element GetElement(string documentationSymbol)
		{
			return null;
		}
	}

	private Documentation documentation;

	public override void Init()
	{
	}

	public Element GetDocumentationElement(string documentationSymbol)
	{
		return null;
	}
}
