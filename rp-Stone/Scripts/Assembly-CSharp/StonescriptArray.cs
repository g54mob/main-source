using System.Collections;
using System.Collections.Generic;

public class StonescriptArray : StonescriptObject, IEnumerable<object>, IEnumerable
{
	private List<object> array = new List<object>();

	public int Length => array.Count;

	public object this[int i]
	{
		get
		{
			return array[i];
		}
		set
		{
			array[i] = value;
		}
	}

	public StonescriptArray()
		: this("array")
	{
	}

	public StonescriptArray(int capacity)
		: this("array")
	{
		array.Capacity = capacity;
	}

	public StonescriptArray(IEnumerable<object> list)
		: this("array")
	{
		array.AddRange(list);
	}

	public StonescriptArray(string name, StonescriptObject parent = null)
		: base(name, parent)
	{
		base.ObjectType = "Array";
		BindFunctions();
	}

	public void BindFunctions()
	{
		DeclareFunction(Add);
		DeclareFunction(AddRange, new List<string> { "list" });
		DeclareFunction(Clear, new List<string>());
		DeclareFunction(Contains, new List<string> { "value" });
		DeclareFunction("Count", GetLength, new List<string>());
		DeclareFunction(Emplace, new List<string> { "index", "value" });
		DeclareFunction(IndexOf, new List<string> { "value" });
		DeclareFunction(Insert, new List<string> { "index", "value" });
		DeclareFunction(RemoveAt, new List<string> { "index" });
		DeclareFunction(Sort, new List<string>());
	}

	protected override void Link(HashSet<StonescriptObject> processedObjects)
	{
		BindFunctions();
		base.Link(processedObjects);
	}

	private object GetLength(List<object> parameters, InvocationContext ctx)
	{
		return array.Count;
	}

	private object Clear(List<object> parameters, InvocationContext ctx)
	{
		array.Clear();
		return null;
	}

	private object RemoveAt(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid array index");
		}
		int num = (int)parameters[0];
		if (num < 0 || num >= array.Count)
		{
			throw new StonescriptRuntimeException("Array index out of bounds");
		}
		object result = array[num];
		array.RemoveAt(num);
		return result;
	}

	private object Sort(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count > 0)
		{
			throw new StonescriptRuntimeException("Invalid arguments");
		}
		array.Sort(delegate(object obj1, object obj2)
		{
			if (obj1 == null)
			{
				return 1;
			}
			return (obj2 == null) ? (-1) : obj1.ToString().CompareTo(obj2.ToString());
		});
		return this;
	}

	private object Contains(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 1)
		{
			throw new StonescriptRuntimeException("Invalid arguments");
		}
		object item = parameters[0];
		return array.Contains(item);
	}

	private object Emplace(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 2)
		{
			throw new StonescriptRuntimeException("Invalid arguments");
		}
		if (!(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid array index");
		}
		int num = (int)parameters[0];
		if (num < 0 || num >= array.Count)
		{
			throw new StonescriptRuntimeException("Array index out of bounds");
		}
		object value = parameters[1];
		array[num] = value;
		return this;
	}

	private object IndexOf(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count < 1)
		{
			throw new StonescriptRuntimeException("Insufficient arguments");
		}
		object item = parameters[0];
		if (parameters.Count > 1)
		{
			if (!(parameters[1] is int))
			{
				throw new StonescriptRuntimeException("Invalid array index");
			}
			int num = (int)parameters[1];
			if (num < 0 || num >= array.Count)
			{
				throw new StonescriptRuntimeException("Array index out of bounds");
			}
			return array.IndexOf(item, num);
		}
		return array.IndexOf(item);
	}

	private object Insert(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count != 2)
		{
			throw new StonescriptRuntimeException("Invalid arguments");
		}
		if (!(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("Invalid array index");
		}
		int num = (int)parameters[0];
		if (num < 0 || num >= array.Count)
		{
			throw new StonescriptRuntimeException("Array index out of bounds");
		}
		object item = parameters[1];
		array.Insert(num, item);
		return this;
	}

	private object Add(List<object> parameters, InvocationContext ctx)
	{
		array.AddRange(parameters);
		return this;
	}

	private object AddRange(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is IEnumerable<object>))
		{
			throw new StonescriptRuntimeException("Invalid parameter");
		}
		IEnumerable<object> collection = parameters[0] as IEnumerable<object>;
		array.AddRange(collection);
		return this;
	}

	public void Add(object o)
	{
		array.Add(o);
	}

	public void AddRange(IEnumerable<object> collection)
	{
		array.AddRange(collection);
	}

	public void Insert(int index, object o)
	{
		array.Insert(index, o);
	}

	public bool Remove(object o)
	{
		return array.Remove(o);
	}

	public void RemoveAt(int index)
	{
		array.RemoveAt(index);
	}

	public void Clear()
	{
		array.Clear();
	}

	public IEnumerator<object> GetEnumerator()
	{
		return array.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public List<T> ToList<T>()
	{
		List<T> list = new List<T>();
		foreach (object item in array)
		{
			list.Add((T)item);
		}
		return list;
	}

	public T[] ToArray<T>()
	{
		T[] array = new T[this.array.Count];
		for (int i = 0; i < this.array.Count; i++)
		{
			array[i] = (T)this.array[i];
		}
		return array;
	}

	public string SerializeSJSON()
	{
		string text = "[";
		bool flag = true;
		foreach (object item in array)
		{
			if (!flag)
			{
				text += ",";
			}
			text += item.ToString();
		}
		return text + "]";
	}
}
