using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Stonescript;

public class StonescriptObject
{
	[Flags]
	public enum Modifiers
	{
		None = 0,
		NoObjects = 2,
		Constant = 4,
		All = -1
	}

	private class Wrapper
	{
		public object value;

		public Modifiers modifiers;

		public Wrapper(object value, Modifiers modifiers)
		{
			this.value = value;
			this.modifiers = modifiers;
		}

		public Wrapper(Dictionary<string, object> dict)
		{
			value = dict["value"];
			if (dict.ContainsKey("modifiers"))
			{
				modifiers = (Modifiers)dict["modifiers"];
			}
		}

		public object Serialize()
		{
			return new Dictionary<string, object>
			{
				{ "value", value },
				{
					"modifiers",
					(int)modifiers
				}
			};
		}

		public bool AreEqual(object obj)
		{
			HashSet<StonescriptObject> processedObjects = new HashSet<StonescriptObject>();
			return AreEqual(obj, processedObjects);
		}

		public bool AreEqual(object obj, HashSet<StonescriptObject> processedObjects)
		{
			if (!(obj is Wrapper))
			{
				return false;
			}
			Wrapper wrapper = obj as Wrapper;
			if (value is StonescriptObject || (wrapper != null && wrapper.value is StonescriptObject))
			{
				if (value is StonescriptObject)
				{
					if (!(value as StonescriptObject).AreEqual(wrapper.value, processedObjects))
					{
						return false;
					}
				}
				else if (!(wrapper.value as StonescriptObject).AreEqual(value, processedObjects))
				{
					return false;
				}
			}
			else if ((value == null || !value.Equals(wrapper.value)) && (value != null || wrapper.value != null))
			{
				return false;
			}
			return modifiers == wrapper.modifiers;
		}
	}

	public delegate object Getter();

	public delegate void Setter(object value);

	private Dictionary<string, Wrapper> objects = new Dictionary<string, Wrapper>();

	private Dictionary<string, Setter> setters = new Dictionary<string, Setter>();

	private Dictionary<string, object> nativeObjects;

	protected StonescriptObject parent;

	private static Regex validVarNameRegex = new Regex("^[_A-Za-z][_A-Za-z0-9]*$", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

	private static int counter = 0;

	private int uniqueId = -1;

	public bool destroyed;

	public List<string> Variables => new List<string>(objects.Keys);

	public string Name { get; set; }

	public string ObjectType { get; set; }

	public StonescriptObject RootObject
	{
		get
		{
			if (parent == null)
			{
				return this;
			}
			return parent.RootObject;
		}
	}

	public StonescriptObject Container
	{
		get
		{
			if (objects.ContainsKey("this") || parent == null)
			{
				return this;
			}
			return parent.Container;
		}
	}

	public StonescriptObject Parent => parent;

	public SSScriptableObject Scriptable => GetNative<SSScriptableObject>("scriptable");

	public StonescriptObject()
	{
		Init();
		uniqueId = counter;
	}

	public StonescriptObject(StonescriptObject parent)
	{
		Init(parent);
		uniqueId = counter;
	}

	public StonescriptObject(string name, StonescriptObject parent = null)
	{
		Init(name, parent);
		uniqueId = counter;
	}

	public StonescriptObject Init()
	{
		counter++;
		Name = $"object{counter}";
		parent = null;
		return this;
	}

	public StonescriptObject Init(StonescriptObject parent)
	{
		counter++;
		Name = $"object{counter}";
		this.parent = parent;
		return this;
	}

	public StonescriptObject Init(string name, StonescriptObject parent = null)
	{
		counter++;
		Name = name;
		this.parent = parent;
		return this;
	}

	public static string ValidateVariableId(string varId)
	{
		if (!validVarNameRegex.IsMatch(varId))
		{
			return "\"" + varId + "\" is not a valid variable name";
		}
		return null;
	}

	private string ValidateVariableId_Object(string varId)
	{
		if (objects.ContainsKey(varId))
		{
			return "Variable \"" + varId + "\" is already declared in this scope";
		}
		return ValidateVariableId(varId);
	}

	public void DeclareFunction(string funcName, NativeFunction.Callback func, List<string> paramNames = null)
	{
		DeclareFunction(new NativeFunction(this, funcName, func, paramNames));
	}

	public void DeclareFunction(NativeFunction.Callback func, List<string> paramNames = null)
	{
		DeclareFunction(new NativeFunction(this, func, paramNames));
	}

	public void DeclareFunction(IFunction function, bool allowOverwrite = true)
	{
		if (function is NativeFunction)
		{
			((NativeFunction)function).Owner = this;
		}
		if (allowOverwrite && IsVariable(function.Name))
		{
			object variable = GetVariable(function.Name);
			if (!(variable is NativeFunction.Callback) && !(variable is IFunction))
			{
				throw new StonescriptRuntimeException("Attempting to redeclare a variable that is not a function as a function");
			}
			SetVariable(function.Name, function);
		}
		else
		{
			DeclareVariable(function.Name, function);
		}
	}

	public void DeclareGetter(string varId, Getter getter)
	{
		Modifiers modifiers = Modifiers.None;
		string text = ValidateVariableId_Object(varId);
		if (text != null)
		{
			throw new StonescriptRuntimeException(text);
		}
		objects.Add(varId, new Wrapper(getter, modifiers));
	}

	public void DeclareSetter(string varId, Setter setter)
	{
		string text = ValidateVariableId(varId);
		if (text != null)
		{
			throw new StonescriptRuntimeException(text);
		}
		setters.Add(varId, setter);
	}

	public void DeclareVariable(string varId, object val, Modifiers modifiers = Modifiers.None, bool allowCreateAncestors = false)
	{
		int num = varId.IndexOf('.');
		if (num < 0)
		{
			string text = ValidateVariableId_Object(varId);
			if (text != null)
			{
				throw new StonescriptRuntimeException(text);
			}
			objects.Add(varId, new Wrapper(val, modifiers));
			return;
		}
		string text2 = varId.Substring(0, num);
		string varId2 = varId.Substring(num + 1);
		if (objects.ContainsKey(text2))
		{
			object variable = GetVariable(text2);
			if (variable == null)
			{
				variable = parent.GetVariable(text2);
			}
			if (variable == null)
			{
				if (!allowCreateAncestors)
				{
					throw new StonescriptRuntimeException("Unable to resolve variable \"" + text2 + "\"");
				}
				StonescriptObject stonescriptObject = new StonescriptObject(text2);
				SetVariable(text2, stonescriptObject);
				stonescriptObject.DeclareVariable(varId2, val, modifiers, allowCreateAncestors: true);
			}
			else
			{
				if (!(variable is StonescriptObject))
				{
					throw new StonescriptRuntimeException($"\"{text2}\" is {variable.GetType()}, not an object");
				}
				(variable as StonescriptObject).DeclareVariable(varId2, val, modifiers);
			}
		}
		else
		{
			if (!allowCreateAncestors)
			{
				throw new StonescriptRuntimeException("Unable to resolve variable \"" + text2 + "\"");
			}
			StonescriptObject stonescriptObject2 = new StonescriptObject(text2);
			DeclareVariable(text2, stonescriptObject2);
			stonescriptObject2.DeclareVariable(varId2, val, modifiers, allowCreateAncestors: true);
		}
	}

	public void UndeclareVariable(string varId)
	{
		if (!objects.ContainsKey(varId))
		{
			throw new StonescriptRuntimeException("Variable \"" + varId + "\" is does not exist in this scope");
		}
		objects.Remove(varId);
	}

	public virtual object GetVariable(string varId)
	{
		StonescriptObject container = null;
		return GetVariable(varId, out container);
	}

	public virtual object GetVariable(string varId, out StonescriptObject container)
	{
		int num = varId.IndexOf('.');
		if (num < 0)
		{
			if (objects.ContainsKey(varId))
			{
				container = Container;
				object obj = objects[varId].value;
				if (obj is Getter)
				{
					obj = (obj as Getter)();
				}
				return obj;
			}
			if (parent != null)
			{
				return parent.GetVariable(varId, out container);
			}
			throw new StonescriptRuntimeException("Unable to resolve variable \"" + varId + "\"");
		}
		string text = varId.Substring(0, num);
		string varId2 = varId.Substring(num + 1);
		if (objects.ContainsKey(text))
		{
			object obj2 = null;
			obj2 = ((!IsVariable(text, allowParentChaining: false)) ? parent.GetVariable(text, out container) : GetVariable(text));
			if (obj2 == null)
			{
				throw new StonescriptRuntimeException("Unable to access member variable on null object \"" + text + "\".");
			}
			if (obj2 is StonescriptObject)
			{
				return (obj2 as StonescriptObject).GetVariable(varId2, out container);
			}
			throw new StonescriptRuntimeException($"\"{text}\" is {obj2.GetType()}, not an object");
		}
		if (parent != null)
		{
			return parent.GetVariable(varId, out container);
		}
		throw new StonescriptRuntimeException("Unable to resolve variable \"" + text + "\"");
	}

	public virtual void SetVariable(string varId, object val)
	{
		int num = varId.IndexOf('.');
		if (num < 0)
		{
			if (setters.ContainsKey(varId))
			{
				setters[varId](val);
				return;
			}
			if (objects.ContainsKey(varId))
			{
				if (objects[varId].value is Getter)
				{
					throw new StonescriptRuntimeException("Variable \"" + varId + "\" is read only.");
				}
				objects[varId].value = val;
				return;
			}
			if (parent != null)
			{
				parent.SetVariable(varId, val);
				return;
			}
		}
		else
		{
			string text = varId.Substring(0, num);
			string varId2 = varId.Substring(num + 1);
			if (objects.ContainsKey(text))
			{
				object value = objects[text].value;
				if (value is StonescriptObject)
				{
					(value as StonescriptObject).SetVariable(varId2, val);
					return;
				}
				throw new StonescriptRuntimeException($"\"{text}\" is {value.GetType()}, not an object");
			}
			if (parent != null)
			{
				parent.SetVariable(varId, val);
				return;
			}
		}
		throw new StonescriptRuntimeException("Unable to resolve variable \"" + varId + "\"");
	}

	public virtual bool HasFunction(string varId, bool allowParentChaining = true)
	{
		if (!IsVariable(varId, allowParentChaining))
		{
			return false;
		}
		return GetVariable(varId) is IFunction;
	}

	public virtual IFunction GetFunction(string varId, bool allowParentChaining = true)
	{
		if (!IsVariable(varId, allowParentChaining))
		{
			throw new InvalidCastException("\"" + varId + "\" is not a function.");
		}
		object variable = GetVariable(varId);
		if (!(variable is IFunction))
		{
			throw new InvalidCastException("\"" + varId + "\" is not a function.");
		}
		if (variable == null)
		{
			throw new MissingMethodException("Unknown", varId);
		}
		return variable as IFunction;
	}

	public virtual bool IsVariable(string varId, bool allowParentChaining = true)
	{
		int num = varId.IndexOf('.');
		if (num < 0)
		{
			if (objects.ContainsKey(varId))
			{
				return true;
			}
			if (allowParentChaining && parent != null)
			{
				return parent.IsVariable(varId, allowParentChaining);
			}
		}
		else
		{
			string text = varId.Substring(0, num);
			string varId2 = varId.Substring(num + 1);
			if (objects.ContainsKey(text))
			{
				object value = objects[text].value;
				if (value is StonescriptObject)
				{
					return (value as StonescriptObject).IsVariable(varId2, allowParentChaining);
				}
				throw new StonescriptRuntimeException($"\"{text}\" is {value.GetType()}, not an object");
			}
			if (allowParentChaining && parent != null)
			{
				return parent.IsVariable(varId, allowParentChaining);
			}
		}
		return false;
	}

	public Dictionary<string, object> GetVariables()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (KeyValuePair<string, Wrapper> @object in objects)
		{
			if (@object.Value.value is StonescriptArray)
			{
				StonescriptArray stonescriptArray = @object.Value.value as StonescriptArray;
				dictionary.Add(@object.Key, stonescriptArray.ToArray<object>());
			}
			else if (!(@object.Value.value is IFunction) && !(@object.Value.value is StonescriptObject) && @object.Value.modifiers != Modifiers.Constant)
			{
				dictionary.Add(@object.Key, @object.Value.value);
			}
		}
		return dictionary;
	}

	public void SetVariables(Dictionary<string, object> variables)
	{
		foreach (KeyValuePair<string, object> variable in variables)
		{
			if (IsVariable(variable.Key))
			{
				SetVariable(variable.Key, variable.Value);
			}
			else
			{
				DeclareVariable(variable.Key, variable.Value);
			}
		}
	}

	public Modifiers GetModifiers(string varId)
	{
		int num = varId.IndexOf('.');
		if (num < 0)
		{
			if (objects.ContainsKey(varId))
			{
				return objects[varId].modifiers;
			}
			if (parent != null)
			{
				return parent.GetModifiers(varId);
			}
			return Modifiers.None;
		}
		string text = varId.Substring(0, num);
		string varId2 = varId.Substring(num + 1);
		if (objects.ContainsKey(text))
		{
			object variable = GetVariable(text);
			if (variable == null)
			{
				variable = parent.GetVariable(text);
			}
			if (variable == null)
			{
				throw new StonescriptRuntimeException("Unable to resolve variable \"" + text + "\"");
			}
			if (variable is StonescriptObject)
			{
				return ((StonescriptObject)variable).GetModifiers(varId2);
			}
			throw new StonescriptRuntimeException($"\"{text}\" is {variable.GetType()}, not an object");
		}
		throw new StonescriptRuntimeException("Unable to resolve variable \"" + varId + "\"");
	}

	public void SetModifiers(string varId, Modifiers modifiers)
	{
		int num = varId.IndexOf('.');
		if (num < 0)
		{
			if (objects.ContainsKey(varId))
			{
				objects[varId].modifiers = modifiers;
				return;
			}
			if (parent != null)
			{
				parent.SetModifiers(varId, modifiers);
				return;
			}
		}
		else
		{
			string text = varId.Substring(0, num);
			string varId2 = varId.Substring(num + 1);
			if (objects.ContainsKey(text))
			{
				object value = objects[text].value;
				if (value is StonescriptObject)
				{
					(value as StonescriptObject).SetModifiers(varId2, modifiers);
					return;
				}
				throw new StonescriptRuntimeException($"\"{text}\" is {value.GetType()}, not an object");
			}
			if (parent != null)
			{
				parent.SetModifiers(varId, modifiers);
				return;
			}
		}
		throw new StonescriptRuntimeException("Unable to resolve variable \"" + varId + "\"");
	}

	public override bool Equals(object obj)
	{
		if (destroyed)
		{
			return object.Equals(null, obj);
		}
		if (Has("Equals"))
		{
			Wrapper wrapper = objects["Equals"];
			if (wrapper.value is Getter)
			{
				return object.Equals((wrapper.value as Getter)(), obj);
			}
		}
		return base.Equals(obj);
	}

	public override string ToString()
	{
		if (Has("ToString"))
		{
			Wrapper wrapper = objects["ToString"];
			if (wrapper.value is Getter)
			{
				return (wrapper.value as Getter)().ToString();
			}
		}
		return Name;
	}

	public Dictionary<string, object> GetData(Modifiers filter = Modifiers.All)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (KeyValuePair<string, Wrapper> @object in objects)
		{
			string key = @object.Key;
			object value = @object.Value.value;
			if (!(value is IFunction))
			{
				if (value is StonescriptObject)
				{
					StonescriptObject stonescriptObject = value as StonescriptObject;
					dictionary.Add(key, stonescriptObject.GetData(filter));
				}
				else
				{
					dictionary.Add(key, @object.Value.Serialize());
				}
			}
		}
		return dictionary;
	}

	public void LoadData(Dictionary<string, object> data)
	{
		foreach (KeyValuePair<string, object> datum in data)
		{
			if (datum.Key == "__type")
			{
				ObjectType = datum.Value as string;
				continue;
			}
			string key = datum.Key;
			object value = datum.Value;
			if (IsWrapper(value))
			{
				Wrapper value2 = new Wrapper(value as Dictionary<string, object>);
				objects[key] = value2;
			}
			else
			{
				if (!IsObject(value))
				{
					continue;
				}
				if (objects.ContainsKey(key))
				{
					if (!(objects[key].value is StonescriptObject))
					{
						throw new StonescriptCompileException("Unable to bind data", "bind", 0);
					}
					(objects[key].value as StonescriptObject).LoadData(value as Dictionary<string, object>);
				}
				else
				{
					StonescriptObject stonescriptObject = new StonescriptObject(Name + "." + key);
					objects.Add(key, new Wrapper(stonescriptObject, Modifiers.None));
					stonescriptObject.LoadData(value as Dictionary<string, object>);
				}
			}
		}
	}

	private bool IsWrapper(object o)
	{
		if (o is Dictionary<string, object>)
		{
			Dictionary<string, object> dictionary = o as Dictionary<string, object>;
			if (dictionary.Count == 2 && dictionary.ContainsKey("value") && (dictionary["value"] == null || dictionary["value"] is string || dictionary["value"] is int || dictionary["value"] is bool) && dictionary.ContainsKey("modifiers"))
			{
				return dictionary["modifiers"] is int;
			}
			return false;
		}
		return false;
	}

	private bool IsObject(object o)
	{
		return o is Dictionary<string, object>;
	}

	public bool AreEqual(object obj)
	{
		HashSet<StonescriptObject> processedObjects = new HashSet<StonescriptObject>();
		return AreEqual(obj, processedObjects);
	}

	private bool AreEqual(object obj, HashSet<StonescriptObject> processedObjects)
	{
		if (!(obj is StonescriptObject))
		{
			return false;
		}
		StonescriptObject stonescriptObject = obj as StonescriptObject;
		if (processedObjects.Contains(this))
		{
			return true;
		}
		processedObjects.Add(this);
		if (!string.Equals(Name, stonescriptObject.Name))
		{
			return false;
		}
		if ((parent != null && !AreEqual(stonescriptObject.parent, processedObjects)) || (stonescriptObject.parent != null && !AreEqual(parent, processedObjects)))
		{
			return false;
		}
		foreach (KeyValuePair<string, Wrapper> @object in objects)
		{
			string key = @object.Key;
			if (!stonescriptObject.objects.ContainsKey(key))
			{
				return false;
			}
		}
		foreach (KeyValuePair<string, Wrapper> object2 in stonescriptObject.objects)
		{
			string key2 = object2.Key;
			if (!objects.ContainsKey(key2))
			{
				return false;
			}
		}
		foreach (KeyValuePair<string, Wrapper> object3 in objects)
		{
			string key3 = object3.Key;
			Wrapper wrapper = objects[key3];
			Wrapper obj2 = stonescriptObject.objects[key3];
			if (!wrapper.AreEqual(obj2, processedObjects))
			{
				return false;
			}
		}
		return true;
	}

	public void ClearVariables()
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<string, Wrapper> @object in objects)
		{
			string key = @object.Key;
			Wrapper value = @object.Value;
			if (value.value is StonescriptObject)
			{
				(value.value as StonescriptObject).ClearVariables();
			}
			else if (!(value.value is IFunction))
			{
				hashSet.Add(key);
			}
		}
		foreach (string item in hashSet)
		{
			UndeclareVariable(item);
		}
	}

	public virtual void Link()
	{
		HashSet<StonescriptObject> processedObjects = new HashSet<StonescriptObject>();
		Link(processedObjects);
	}

	protected virtual void Link(HashSet<StonescriptObject> processedObjects)
	{
		if (processedObjects.Contains(this))
		{
			return;
		}
		processedObjects.Add(this);
		foreach (KeyValuePair<string, Wrapper> @object in objects)
		{
			_ = @object.Key;
			Wrapper value = @object.Value;
			if (value.value is StonescriptObject)
			{
				(value.value as StonescriptObject).Link(processedObjects);
			}
		}
	}

	public virtual void ClearData()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Wrapper> @object in objects)
		{
			string key = @object.Key;
			if (!(@object.Value.value is IFunction) && !(key == "this"))
			{
				list.Add(key);
			}
		}
		foreach (string item in list)
		{
			UndeclareVariable(item);
		}
	}

	public virtual void Unlink()
	{
		HashSet<StonescriptObject> processedObjects = new HashSet<StonescriptObject>();
		Unlink(processedObjects);
	}

	protected virtual void Unlink(HashSet<StonescriptObject> processedObjects)
	{
		if (processedObjects.Contains(this))
		{
			return;
		}
		processedObjects.Add(this);
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, Wrapper> @object in objects)
		{
			string key = @object.Key;
			if (@object.Value.value is IFunction)
			{
				list.Add(key);
			}
		}
		foreach (string item in list)
		{
			UndeclareVariable(item);
		}
		foreach (KeyValuePair<string, Wrapper> object2 in objects)
		{
			_ = object2.Key;
			Wrapper value = object2.Value;
			if (value.value is StonescriptObject)
			{
				(value.value as StonescriptObject).Unlink(processedObjects);
			}
		}
	}

	public T GetNative<T>()
	{
		if (nativeObjects == null)
		{
			return default(T);
		}
		foreach (KeyValuePair<string, object> nativeObject in nativeObjects)
		{
			if (nativeObject.Value is T)
			{
				return (T)nativeObject.Value;
			}
		}
		return default(T);
	}

	public T GetNative<T>(string varId)
	{
		if (nativeObjects == null || !nativeObjects.ContainsKey(varId))
		{
			return default(T);
		}
		return (T)nativeObjects[varId];
	}

	public void SetNative(string varId, object o)
	{
		if (nativeObjects == null)
		{
			nativeObjects = new Dictionary<string, object>();
		}
		if (nativeObjects.ContainsKey(varId))
		{
			nativeObjects[varId] = o;
		}
		else
		{
			nativeObjects.Add(varId, o);
		}
	}

	public bool Has(string varId)
	{
		return IsVariable(varId);
	}

	public bool Has<T>(string varId, bool allowNull = true)
	{
		if (!IsVariable(varId))
		{
			return false;
		}
		object obj = Get(varId);
		if (allowNull && obj == null)
		{
			return true;
		}
		return obj is T;
	}

	public void Declare(string varId, object value = null)
	{
		DeclareVariable(varId, value);
	}

	public object Get(string varId)
	{
		return GetVariable(varId);
	}

	public T Get<T>(string varId)
	{
		object variable = GetVariable(varId);
		if (!(variable is T))
		{
			string name = typeof(T).Name;
			string name2 = variable.GetType().Name;
			throw new StonescriptRuntimeException("Expected \"" + varId + "\" to be " + name + " but it was " + name2 + ".");
		}
		return (T)variable;
	}

	public void Set(string varId, object value)
	{
		SetVariable(varId, value);
	}

	public void Reset()
	{
		objects.Clear();
		setters.Clear();
		nativeObjects = null;
		Name = null;
		ObjectType = null;
		parent = null;
		destroyed = false;
	}
}
