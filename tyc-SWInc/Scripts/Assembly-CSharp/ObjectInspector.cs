using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInspector : MonoBehaviour
{
	public const int MaxArrayElements = 128;

	public Text LabelPrefab;

	public Button ButtonPrefab;

	public RectTransform Content;

	public GUIWindow Window;

	public InputField SearchField;

	public DynamicGridLayout Layout;

	public ScrollRect ScrollRect;

	[NonSerialized]
	public GameObject Root;

	[NonSerialized]
	private List<ValueTuple<Text, object, MemberInfo>> _updateFields = new List<ValueTuple<Text, object, MemberInfo>>();

	[NonSerialized]
	private List<ValueTuple<bool, bool, bool>> _fieldStatus = new List<ValueTuple<bool, bool, bool>>();

	private static HashSet<Type> _simpleTypes = new HashSet<Type>
	{
		typeof(string),
		typeof(bool),
		typeof(byte),
		typeof(short),
		typeof(int),
		typeof(uint),
		typeof(double),
		typeof(float),
		typeof(Vector2),
		typeof(Vector3),
		typeof(Vector4),
		typeof(SVector3),
		typeof(Color),
		typeof(Color32),
		typeof(SDateTime)
	};

	public GUIWindow ActualWindow
	{
		get
		{
			if (!(Window != null))
			{
				InspectorWindow instance = InspectorWindow.Instance;
				if ((object)instance == null)
				{
					return null;
				}
				return instance.Window;
			}
			return Window;
		}
	}

	public void StatusUpdate()
	{
		int num = Content.childCount / 2;
		string value = SearchField.text.ToLower();
		bool flag = !string.IsNullOrWhiteSpace(value);
		for (int i = 0; i < num; i++)
		{
			if (!_fieldStatus[i].Item3)
			{
				bool flag2 = true;
				if (flag2 && flag)
				{
					flag2 = Content.GetChild(i * 2).GetComponent<Text>().text.ToLower().Contains(value);
				}
				Content.GetChild(i * 2).gameObject.SetActive(flag2);
				Content.GetChild(i * 2 + 1).gameObject.SetActive(flag2);
			}
		}
	}

	public void Show(GameObject root, GUIWindow from)
	{
		if (Window == null)
		{
			_updateFields.Clear();
			_fieldStatus.Clear();
			int childCount = Content.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = Content.GetChild(0);
				UnityEngine.Object.Destroy(child.gameObject);
				child.SetParent(null);
			}
			SearchField.text = "";
			ScrollRect.normalizedPosition = Vector2.one;
		}
		else
		{
			Window.SetParentWindow(from);
			Window.Show(true);
			Window.NonLocTitle = root.name + " inspection";
		}
		Root = root;
		Component[] components = Root.GetComponents<Component>();
		List<ValueTuple<string, string, Action, bool, MemberInfo>> fields = new List<ValueTuple<string, string, Action, bool, MemberInfo>>();
		foreach (Component component in components)
		{
			Type type = component.GetType();
			if (!(type == typeof(Transform)) && !(type == typeof(RectTransform)))
			{
				CreateHeader(type.Name);
				_fieldStatus.Add(new ValueTuple<bool, bool, bool>(false, false, true));
				PopulateFields(component, fields);
			}
		}
		StatusUpdate();
	}

	public void ShowClass(object root, GUIWindow from)
	{
		Type type = root.GetType();
		if (Window == null)
		{
			_updateFields.Clear();
			_fieldStatus.Clear();
			int childCount = Content.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = Content.GetChild(0);
				UnityEngine.Object.Destroy(child.gameObject);
				child.SetParent(null);
			}
			SearchField.text = "";
			ScrollRect.normalizedPosition = Vector2.one;
		}
		else
		{
			Window.SetParentWindow(from);
			Window.Show(true);
			Window.NonLocTitle = type.Name + " inspection";
		}
		if (type.IsArray)
		{
			Layout.Columns[0] = 0f;
			SearchField.gameObject.SetActive(false);
			Array array = (Array)root;
			int num = Mathf.Min(128, array.Length);
			Type elementType = type.GetElementType();
			bool flag = !IsSimpleType(elementType) && CanInspect(elementType);
			for (int j = 0; j < num; j++)
			{
				object o = array.GetValue(j);
				string printValue = GetPrintValue(o);
				if (flag)
				{
					CreateButton("", printValue, delegate
					{
						InspectItem(o);
					});
				}
				else
				{
					CreateLabels("", printValue);
				}
			}
			if (array.Length > 128)
			{
				CreateLabels(" + " + (array.Length - 128), "");
			}
		}
		else if (typeof(IEnumerable).IsAssignableFrom(type))
		{
			SearchField.gameObject.SetActive(false);
			IEnumerator enumerator = ((IEnumerable)root).GetEnumerator();
			int num2 = 0;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			PropertyInfo propertyInfo = null;
			PropertyInfo propertyInfo2 = null;
			while (enumerator.MoveNext())
			{
				if (num2 < 128)
				{
					object o2 = enumerator.Current;
					if (o2 == null)
					{
						CreateLabels("", GetPrintValue(o2));
					}
					else
					{
						if (!flag2)
						{
							Type type2 = o2.GetType();
							flag4 = type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(KeyValuePair<, >);
							if (flag4)
							{
								Type[] genericArguments = type2.GetGenericArguments();
								flag3 = !IsSimpleType(genericArguments[0]) && CanInspect(genericArguments[0]);
								flag5 = !IsSimpleType(genericArguments[1]) && CanInspect(genericArguments[1]);
								propertyInfo = type2.GetProperty("Key");
								propertyInfo2 = type2.GetProperty("Value");
							}
							else
							{
								Layout.Columns[0] = 0f;
								flag3 = !IsSimpleType(type2) && CanInspect(type2);
							}
							flag2 = true;
						}
						if (flag4)
						{
							object key = propertyInfo.GetValue(o2);
							object value = propertyInfo2.GetValue(o2);
							CreateButtons(GetPrintValue(key), GetPrintValue(value), flag3 ? ((Action)delegate
							{
								InspectItem(key);
							}) : null, flag5 ? ((Action)delegate
							{
								InspectItem(value);
							}) : null);
						}
						else if (flag3)
						{
							CreateButton("", GetPrintValue(o2), delegate
							{
								InspectItem(o2);
							});
						}
						else
						{
							CreateLabels("", GetPrintValue(o2));
						}
					}
				}
				num2++;
			}
			if (num2 > 128)
			{
				CreateLabels(" + " + (num2 - 128), "");
			}
		}
		else
		{
			List<ValueTuple<string, string, Action, bool, MemberInfo>> fields = new List<ValueTuple<string, string, Action, bool, MemberInfo>>();
			PopulateFields(root, fields);
			StatusUpdate();
		}
	}

	private ValueTuple<bool, bool, bool> StatusFromMember(MemberInfo info, Type t)
	{
		return new ValueTuple<bool, bool, bool>(false, false, false);
	}

	private void PopulateFields(object root, List<ValueTuple<string, string, Action, bool, MemberInfo>> fields)
	{
		Type type = root.GetType();
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
		FieldInfo[] fields2 = type.GetFields(bindingAttr);
		for (int i = 0; i < fields2.Length; i++)
		{
			if (fields2[i].GetCustomAttribute<ObsoleteAttribute>() == null)
			{
				fields.Add(InspectMember(fields2[i], root));
			}
		}
		PropertyInfo[] properties = type.GetProperties(bindingAttr);
		for (int j = 0; j < properties.Length; j++)
		{
			if (properties[j].GetCustomAttribute<ObsoleteAttribute>() == null)
			{
				fields.Add(InspectMember(properties[j], root));
			}
		}
		foreach (var item2 in fields.OrderBy((ValueTuple<string, string, Action, bool, MemberInfo> x) => x.Item1))
		{
			_fieldStatus.Add(StatusFromMember(item2.Item5, type));
			if (item2.Item3 != null)
			{
				CreateButton(item2.Item1, item2.Item2, item2.Item3);
				continue;
			}
			Text item = CreateLabels(item2.Item1, item2.Item2);
			if (item2.Item4)
			{
				_updateFields.Add(new ValueTuple<Text, object, MemberInfo>(item, root, item2.Item5));
			}
		}
		fields.Clear();
	}

	private static object GetValue(MemberInfo info, object o)
	{
		FieldInfo fieldInfo;
		if ((object)(fieldInfo = info as FieldInfo) != null)
		{
			return fieldInfo.GetValue(o);
		}
		PropertyInfo propertyInfo;
		if ((object)(propertyInfo = info as PropertyInfo) != null)
		{
			return propertyInfo.GetValue(o);
		}
		return null;
	}

	private static string GetPrintValue(MemberInfo info, object o, out bool error)
	{
		error = false;
		object result = null;
		try
		{
			FieldInfo fieldInfo;
			if ((object)(fieldInfo = info as FieldInfo) != null)
			{
				result = fieldInfo.GetValue(o);
			}
			PropertyInfo propertyInfo;
			if ((object)(propertyInfo = info as PropertyInfo) != null)
			{
				result = propertyInfo.GetValue(o);
			}
		}
		catch (Exception)
		{
			error = true;
			return "<color=#FF0000>ERROR</color>";
		}
		return GetPrintValue(result);
	}

	private static string GetPrintValue(object result)
	{
		if (result == null)
		{
			return "<color=#0000FF>NULL</color>";
		}
		Type type = result.GetType();
		if (type == typeof(Color))
		{
			return "<color=#" + ColorUtility.ToHtmlStringRGB((Color)result) + ">█</color>";
		}
		if (type == typeof(Color32))
		{
			return "<color=#" + ColorUtility.ToHtmlStringRGB((Color32)result) + ">█</color>";
		}
		if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			return GetPrintValue(type.GetProperty("Value").GetValue(result));
		}
		if (!IsSimpleType(type))
		{
			if (type.IsArray)
			{
				Array array = (Array)result;
				if (array.Rank == 1)
				{
					return "[ " + array.Length + " " + GetTypeName(type.GetElementType()) + " ]";
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("[ ");
				stringBuilder.Append(array.GetLength(0));
				for (int i = 1; i < array.Rank; i++)
				{
					stringBuilder.Append("x");
					stringBuilder.Append(array.GetLength(i));
				}
				stringBuilder.Append(" ");
				stringBuilder.Append(GetTypeName(type.GetElementType()));
				stringBuilder.Append(" ]");
				return stringBuilder.ToString();
			}
			if (typeof(IEnumerable).IsAssignableFrom(type))
			{
				IEnumerator enumerator = ((IEnumerable)result).GetEnumerator();
				bool flag = false;
				StringBuilder stringBuilder2 = null;
				int num = 0;
				while (enumerator.MoveNext())
				{
					if (num < 10)
					{
						if (!flag)
						{
							stringBuilder2 = new StringBuilder();
							stringBuilder2.Append("[ ");
						}
						else
						{
							stringBuilder2.Append(", ");
						}
						stringBuilder2.Append(GetPrintValue(enumerator.Current));
						flag = true;
					}
					num++;
				}
				if (!flag)
				{
					return "[ empty ]";
				}
				if (num > 10)
				{
					stringBuilder2.Append(" + " + (num - 10));
				}
				stringBuilder2.Append(" ]");
				return stringBuilder2.ToString();
			}
		}
		return result.ToString();
	}

	private static bool IsSimpleArrayType(Type type)
	{
		return false;
	}

	private static bool CanInspect(Type type)
	{
		if (type == typeof(GameObject) || type == typeof(Mesh) || type == typeof(Material))
		{
			return true;
		}
		if (typeof(Component).IsAssignableFrom(type))
		{
			return true;
		}
		if (typeof(Texture).IsAssignableFrom(type))
		{
			return true;
		}
		if (typeof(Sprite).IsAssignableFrom(type))
		{
			return true;
		}
		if (type.IsArray)
		{
			return type.GetArrayRank() == 1;
		}
		if (type.GetInterfaces().Any((Type i) => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
		{
			return true;
		}
		if (type.Namespace != null)
		{
			if (type.Namespace.StartsWith("System"))
			{
				return false;
			}
			if (type.Namespace.StartsWith("Unity"))
			{
				return false;
			}
		}
		return true;
	}

	private static bool IsSimpleType(Type type)
	{
		if (!type.IsEnum && !_simpleTypes.Contains(type))
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				return IsSimpleType(type.GetGenericArguments()[0]);
			}
			return false;
		}
		return true;
	}

	private static string GetTypeName(Type type)
	{
		if (type.IsArray)
		{
			int arrayRank = type.GetArrayRank();
			if (arrayRank == 1)
			{
				return GetTypeName(type.GetElementType()) + "[]";
			}
			StringBuilder stringBuilder = new StringBuilder(GetTypeName(type.GetElementType()) + "[");
			for (int i = 1; i < arrayRank; i++)
			{
				stringBuilder.Append(",");
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
		if (type.IsGenericType)
		{
			if (type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				return GetTypeName(type.GetGenericArguments()[0]) + "?";
			}
			StringBuilder stringBuilder2 = new StringBuilder(type.Name.Substring(0, type.Name.IndexOf("`")));
			Type[] genericArguments = type.GetGenericArguments();
			stringBuilder2.Append("<");
			for (int j = 0; j < genericArguments.Length; j++)
			{
				if (j > 0)
				{
					stringBuilder2.Append(", ");
				}
				stringBuilder2.Append(GetTypeName(genericArguments[j]));
			}
			stringBuilder2.Append(">");
			return stringBuilder2.ToString();
		}
		return type.Name;
	}

	public void InspectItem(MemberInfo info, object o)
	{
		InspectItem(GetValue(info, o));
	}

	public void InspectItem(object vv)
	{
		if (vv != null)
		{
			Sprite sp;
			if ((object)(sp = vv as Sprite) != null)
			{
				ImageInspector imageInspector = UnityEngine.Object.Instantiate(WindowManager.Instance.InspectorWindowPrefab.ImageInspectorPrefab);
				imageInspector.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
				imageInspector.Show(sp, ActualWindow);
				return;
			}
			Material material;
			if ((object)(material = vv as Material) != null)
			{
				if (material != null)
				{
					ImageInspector imageInspector2 = UnityEngine.Object.Instantiate(WindowManager.Instance.InspectorWindowPrefab.ImageInspectorPrefab);
					imageInspector2.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
					imageInspector2.Show(material, ActualWindow);
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("Null value", true, DialogWindow.DialogType.Warning, ActualWindow);
				}
				return;
			}
			Texture texture;
			if ((object)(texture = vv as Texture) != null)
			{
				if (texture != null)
				{
					ImageInspector imageInspector3 = UnityEngine.Object.Instantiate(WindowManager.Instance.InspectorWindowPrefab.ImageInspectorPrefab);
					imageInspector3.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
					imageInspector3.Show(texture, ActualWindow);
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("Null value", true, DialogWindow.DialogType.Warning, ActualWindow);
				}
				return;
			}
			Mesh mesh;
			if ((object)(mesh = vv as Mesh) != null)
			{
				if (mesh != null && mesh.vertexCount > 0)
				{
					ImageInspector imageInspector4 = UnityEngine.Object.Instantiate(WindowManager.Instance.InspectorWindowPrefab.ImageInspectorPrefab);
					imageInspector4.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
					imageInspector4.Show(mesh, ActualWindow);
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("Null value", true, DialogWindow.DialogType.Warning, ActualWindow);
				}
				return;
			}
			ObjectInspector objectInspector = UnityEngine.Object.Instantiate(WindowManager.Instance.InspectorWindowPrefab.ObjectInspectorPrefab);
			objectInspector.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
			GameObject gameObject;
			Component component;
			if ((object)(gameObject = vv as GameObject) != null)
			{
				if (gameObject != Root)
				{
					objectInspector.Show(gameObject, ActualWindow);
				}
				else
				{
					UnityEngine.Object.Destroy(objectInspector.gameObject);
				}
			}
			else if ((object)(component = vv as Component) != null)
			{
				if (component.gameObject != Root)
				{
					objectInspector.Show(component.gameObject, ActualWindow);
				}
				else
				{
					UnityEngine.Object.Destroy(objectInspector.gameObject);
				}
			}
			else
			{
				objectInspector.ShowClass(vv, ActualWindow);
			}
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("Null value", true, DialogWindow.DialogType.Warning, ActualWindow);
		}
	}

	private ValueTuple<string, string, Action, bool, MemberInfo> InspectMember(MemberInfo info, object o)
	{
		FieldInfo fieldInfo;
		if ((object)(fieldInfo = info as FieldInfo) != null)
		{
			if (IsSimpleType(fieldInfo.FieldType) || IsSimpleArrayType(fieldInfo.FieldType))
			{
				bool error;
				string printValue = GetPrintValue(info, o, out error);
				return new ValueTuple<string, string, Action, bool, MemberInfo>(fieldInfo.Name, printValue, null, !error, fieldInfo);
			}
			return new ValueTuple<string, string, Action, bool, MemberInfo>(fieldInfo.Name, GetTypeName(fieldInfo.FieldType), (!CanInspect(fieldInfo.FieldType)) ? null : ((Action)delegate
			{
				InspectItem(info, o);
			}), false, fieldInfo);
		}
		PropertyInfo propertyInfo;
		if ((object)(propertyInfo = info as PropertyInfo) != null)
		{
			if (IsSimpleType(propertyInfo.PropertyType) || IsSimpleArrayType(propertyInfo.PropertyType))
			{
				bool error2;
				string printValue2 = GetPrintValue(info, o, out error2);
				return new ValueTuple<string, string, Action, bool, MemberInfo>(propertyInfo.Name, printValue2, null, !error2, propertyInfo);
			}
			return new ValueTuple<string, string, Action, bool, MemberInfo>(propertyInfo.Name, GetTypeName(propertyInfo.PropertyType), (!CanInspect(propertyInfo.PropertyType)) ? null : ((Action)delegate
			{
				InspectItem(info, o);
			}), false, propertyInfo);
		}
		return new ValueTuple<string, string, Action, bool, MemberInfo>(info.Name, "N/A", null, false, null);
	}

	private void Update()
	{
		for (int i = 0; i < _updateFields.Count; i++)
		{
			ValueTuple<Text, object, MemberInfo> valueTuple = _updateFields[i];
			bool error;
			valueTuple.Item1.text = GetPrintValue(valueTuple.Item3, valueTuple.Item2, out error);
		}
	}

	public Text CreateHeader(string text)
	{
		Text text2 = UnityEngine.Object.Instantiate(LabelPrefab);
		text2.fontSize = 16;
		text2.fontStyle = FontStyle.Bold;
		text2.color = Color.blue;
		text2.text = text;
		text2.horizontalOverflow = HorizontalWrapMode.Overflow;
		text2.transform.SetParent(Content, false);
		GameObject obj = new GameObject("Filler");
		obj.AddComponent<RectTransform>();
		obj.transform.SetParent(Content, false);
		return text2;
	}

	public Text CreateLabels(string label, string value)
	{
		Text text = UnityEngine.Object.Instantiate(LabelPrefab);
		text.text = label;
		text.transform.SetParent(Content, false);
		Text text2 = UnityEngine.Object.Instantiate(LabelPrefab);
		text2.text = value;
		text2.transform.SetParent(Content, false);
		return text2;
	}

	public void CreateButton(string label, string value, Action action)
	{
		Text text = UnityEngine.Object.Instantiate(LabelPrefab);
		text.text = label;
		text.transform.SetParent(Content, false);
		Button button = UnityEngine.Object.Instantiate(ButtonPrefab);
		button.GetComponentInChildren<Text>().text = value;
		button.transform.SetParent(Content, false);
		button.onClick.AddListener(action.Invoke);
	}

	public void CreateButtons(string label, string value, Action action1, Action action2)
	{
		if (action1 != null)
		{
			Button button = UnityEngine.Object.Instantiate(ButtonPrefab);
			button.GetComponentInChildren<Text>().text = label;
			button.transform.SetParent(Content, false);
			button.onClick.AddListener(action1.Invoke);
		}
		else
		{
			Text text = UnityEngine.Object.Instantiate(LabelPrefab);
			text.text = label;
			text.transform.SetParent(Content, false);
		}
		if (action2 != null)
		{
			Button button2 = UnityEngine.Object.Instantiate(ButtonPrefab);
			button2.GetComponentInChildren<Text>().text = value;
			button2.transform.SetParent(Content, false);
			button2.onClick.AddListener(action2.Invoke);
		}
		else
		{
			Text text2 = UnityEngine.Object.Instantiate(LabelPrefab);
			text2.text = value;
			text2.transform.SetParent(Content, false);
		}
	}
}
