using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using UI.Xml.Tags;

namespace UI.Xml
{
	public class XmlLayoutViewModel : MarshalByRefObject
	{
		private static List<IObservableListTagHandler> _listTagHandlers;

		private ListTagHandler _listTagHandler;

		private DataTableTagHandler _dataTableTagHandler;

		internal XmlLayoutController controller { get; private set; }

		private List<PropertyInfo> calculatedProperties { get; set; }

		private static List<IObservableListTagHandler> listTagHandlers
		{
			get
			{
				if (_listTagHandlers == null)
				{
					_listTagHandlers = (from t in XmlLayoutUtilities.GetXmlTagHandlers()
						where t is IObservableListTagHandler
						select t).Cast<IObservableListTagHandler>().ToList();
				}
				return _listTagHandlers;
			}
		}

		private ListTagHandler listTagHandler
		{
			get
			{
				if (_listTagHandler == null)
				{
					_listTagHandler = (ListTagHandler)XmlLayoutUtilities.GetXmlTagHandler("List");
				}
				return _listTagHandler;
			}
		}

		private DataTableTagHandler dataTableTagHandler
		{
			get
			{
				if (_dataTableTagHandler == null)
				{
					_dataTableTagHandler = (DataTableTagHandler)XmlLayoutUtilities.GetXmlTagHandler("DataTable");
				}
				return _dataTableTagHandler;
			}
		}

		protected XmlLayoutViewModel()
		{
		}

		internal void Initialise(XmlLayoutController controller)
		{
			this.controller = controller;
			DetectCalculatedProperties();
			ObserveExistingLists();
		}

		private void ObserveExistingLists()
		{
			Type type = GetType();
			type.GetMembers().Where(delegate(MemberInfo m)
			{
				PropertyInfo property = type.GetProperty(m.Name);
				return (!(property != null) || !(property.GetSetMethod() == null)) ? true : false;
			}).ToList()
				.ForEach(delegate(MemberInfo m)
				{
					if (m.GetMemberDataType() != null && m.GetMemberDataType().GetInterface("IObservableList") != null)
					{
						IObservableList observableList = (IObservableList)m.GetMemberValue(this);
						if (observableList != null)
						{
							ObserveList(observableList, m.Name);
						}
					}
				});
		}

		private void DetectCalculatedProperties()
		{
			calculatedProperties = (from p in GetType().GetProperties()
				where !p.IsAutoProperty()
				select p).ToList();
		}

		public override string ToString()
		{
			Type type = GetType();
			Dictionary<string, object> source = (from m in type.GetMembers()
				where m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property
				select m).ToDictionary((MemberInfo k) => k.Name, (MemberInfo v) => v.GetMemberValue(this));
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(type.Name + " => { ");
			stringBuilder.Append(string.Join(", ", source.Select((KeyValuePair<string, object> f) => f.Key + ": " + ((f.Value != null) ? ("\"" + f.Value.ToString() + "\"") : "null")).ToArray()));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}

		internal void NotifyPropertyChanged(PropertyInfo property)
		{
			if (TypeIsObservableList(property.PropertyType))
			{
				ObserveList((IObservableList)property.GetValue(this, null), property.Name);
			}
			MemberChanged(property.Name);
		}

		internal void NotifyFieldChanged(FieldInfo field)
		{
			if (TypeIsObservableList(field.FieldType))
			{
				ObserveList((IObservableList)field.GetValue(this), field.Name);
			}
			MemberChanged(field.Name);
		}

		public virtual void MemberChanged(string propertyName, bool propogateToCalculatedProperties = true, bool ignoreMainProperty = false)
		{
			if (!ignoreMainProperty)
			{
				controller.ViewModelMemberChanged(propertyName);
			}
			if (!propogateToCalculatedProperties)
			{
				return;
			}
			foreach (PropertyInfo calculatedProperty in calculatedProperties)
			{
				PropertyInfo _property = calculatedProperty;
				if (calculatedProperty.PropertyType.GetInterface("IObservableList") != null)
				{
					XmlLayoutTimer.AtEndOfFrame(delegate
					{
						UpdateCalculatedListView(_property);
					}, controller);
				}
				else
				{
					MemberChanged(calculatedProperty.Name, propogateToCalculatedProperties: false);
				}
			}
		}

		private bool TypeIsObservableList(Type t)
		{
			if (t.IsGenericType)
			{
				return t.GetGenericTypeDefinition() == typeof(ObservableList<>);
			}
			return false;
		}

		private void ObserveList(IObservableList list, string listName)
		{
			list.itemChanged += delegate(int index, object item, string changedField)
			{
				ListItemUpdated(list, index, item, listName, changedField);
			};
			list.itemAdded += delegate(object item)
			{
				ListItemAdded(list, item, listName);
			};
			list.itemRemoved += delegate(object item)
			{
				ListItemRemoved(list, item, listName);
			};
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				MemberChanged(listName);
			}, controller);
		}

		private void ListItemAdded(IObservableList list, object item, string listName)
		{
			IObservableListTagHandler observableListTagHandler = listTagHandlers.FirstOrDefault((IObservableListTagHandler t) => t.IsHandlingList(list));
			if (observableListTagHandler != null)
			{
				observableListTagHandler.AddListItem(list, item, listName);
				MemberChanged(listName, propogateToCalculatedProperties: true, ignoreMainProperty: true);
			}
			else
			{
				MemberChanged(listName);
			}
		}

		private void ListItemRemoved(IObservableList list, object item, string listName)
		{
			IObservableListTagHandler observableListTagHandler = listTagHandlers.FirstOrDefault((IObservableListTagHandler t) => t.IsHandlingList(list));
			if (observableListTagHandler != null)
			{
				observableListTagHandler.RemoveListItem(list, item, listName);
				MemberChanged(listName, propogateToCalculatedProperties: true, ignoreMainProperty: true);
			}
			else
			{
				MemberChanged(listName);
			}
		}

		private void ListItemUpdated(IObservableList list, int index, object item, string listName, string changedField = null)
		{
			IObservableListTagHandler observableListTagHandler = listTagHandlers.FirstOrDefault((IObservableListTagHandler t) => t.IsHandlingList(list));
			if (observableListTagHandler != null)
			{
				observableListTagHandler.UpdateListItem(list, index, item, listName, changedField);
				MemberChanged(listName, propogateToCalculatedProperties: true, ignoreMainProperty: true);
			}
			else
			{
				MemberChanged(listName);
			}
		}

		public void NotifyListChanged(string listName)
		{
			PropertyInfo property = GetType().GetProperty(listName);
			if (property != null)
			{
				UpdateCalculatedListView(property);
			}
		}

		private void UpdateCalculatedListView(PropertyInfo property)
		{
			XmlLayoutList value = listTagHandler.ListElements.FirstOrDefault((KeyValuePair<string, XmlLayoutList> l) => l.Value.DataSource == property.Name).Value;
			if (value != null)
			{
				IObservableList updatedList = (IObservableList)property.GetValue(this, null);
				listTagHandler.SetInstance(value.rectTransform, value.listElement.xmlLayoutInstance);
				listTagHandler.ProcessCalculatedListUpdate(updatedList);
			}
		}

		public void SetValue(string memberName, object newValue)
		{
			MemberInfo memberInfo = GetType().GetMember(memberName).FirstOrDefault();
			if (memberInfo != null && GetValue(memberName) != newValue)
			{
				Type type = newValue.GetType();
				Type memberDataType = memberInfo.GetMemberDataType();
				if (type == typeof(string) && type != memberDataType)
				{
					memberInfo.SetMemberValue(this, ((string)newValue).ChangeToType(memberDataType, controller.xmlLayout));
				}
				else
				{
					memberInfo.SetMemberValue(this, newValue);
				}
			}
		}

		public void SetListItemValue(string listName, int index, string memberName, object newValue)
		{
			MemberInfo memberInfo = GetType().GetMember(listName).FirstOrDefault();
			if (!(memberInfo != null))
			{
				return;
			}
			object obj = ((IObservableList)memberInfo.GetMemberValue(this))[index];
			MemberInfo memberInfo2 = obj.GetType().GetMember(memberName).FirstOrDefault();
			if (memberInfo2 != null)
			{
				Type type = newValue.GetType();
				Type memberDataType = memberInfo2.GetMemberDataType();
				if (memberDataType.IsNumericType())
				{
					string text = (string)newValue;
					float result = 0f;
					if (string.IsNullOrEmpty(text) || text == "-" || !float.TryParse(text, out result))
					{
						return;
					}
				}
				if (type == typeof(string) && type != memberDataType)
				{
					memberInfo2.SetMemberValue(obj, ((string)newValue).ChangeToType(memberDataType, controller.xmlLayout));
				}
				else
				{
					memberInfo2.SetMemberValue(obj, newValue);
				}
			}
			MemberChanged(listName, propogateToCalculatedProperties: true, ignoreMainProperty: true);
		}

		public object GetValue(string memberName)
		{
			MemberInfo memberInfo = GetType().GetMember(memberName).FirstOrDefault();
			if (memberInfo != null)
			{
				return memberInfo.GetMemberValue(this);
			}
			return null;
		}
	}
	public class XmlLayoutViewModel<T> : RealProxy where T : XmlLayoutViewModel
	{
		private readonly XmlLayoutViewModel _instance;

		private Dictionary<PropertyInfo, string> calculatedListGUIDs = new Dictionary<PropertyInfo, string>();

		private XmlLayoutViewModel(T instance)
			: base(typeof(T))
		{
			_instance = instance;
		}

		public static T Create(T instance)
		{
			return (T)new XmlLayoutViewModel<T>(instance).GetTransparentProxy();
		}

		public override IMessage Invoke(IMessage msg)
		{
			IMethodCallMessage methodCallMessage = (IMethodCallMessage)msg;
			MethodInfo methodInfo = (MethodInfo)methodCallMessage.MethodBase;
			bool num = methodInfo.Name.StartsWith("set_");
			object obj = null;
			Type typeFromHandle = typeof(T);
			if (num)
			{
				string propertyName = methodInfo.Name.Replace("set_", string.Empty);
				PropertyInfo propertyInfo = typeFromHandle.GetProperties().First((PropertyInfo p) => p.Name == propertyName);
				object value = propertyInfo.GetValue(_instance, XmlLayoutUtilities.BindingFlags, null, null, null);
				obj = methodInfo.Invoke(_instance, methodCallMessage.InArgs);
				object value2 = propertyInfo.GetValue(_instance, XmlLayoutUtilities.BindingFlags, null, null, null);
				if (value != value2)
				{
					_instance.NotifyPropertyChanged(propertyInfo);
				}
			}
			else if (methodInfo.Name == "FieldSetter")
			{
				string fieldName = methodCallMessage.Args[1].ToString();
				object obj2 = methodCallMessage.Args[2];
				FieldInfo fieldInfo = typeFromHandle.GetFields().First((FieldInfo f) => f.Name == fieldName);
				object value3 = fieldInfo.GetValue(_instance);
				obj = methodInfo.Invoke(_instance, methodCallMessage.InArgs);
				fieldInfo.SetValue(_instance, obj2);
				if ((value3 == null && obj2 != null) || !value3.Equals(obj2))
				{
					_instance.NotifyFieldChanged(fieldInfo);
				}
			}
			else
			{
				if (methodInfo.Name.StartsWith("get_"))
				{
					string propertyName2 = methodInfo.Name.Replace("get_", string.Empty);
					PropertyInfo propertyInfo2 = typeFromHandle.GetProperties().First((PropertyInfo p) => p.Name == propertyName2);
					if (propertyInfo2.PropertyType.GetInterface("IObservableList") != null && !propertyInfo2.IsAutoProperty())
					{
						IObservableList observableList = (IObservableList)propertyInfo2.GetValue(_instance, XmlLayoutUtilities.BindingFlags, null, null, null);
						string text = (calculatedListGUIDs.ContainsKey(propertyInfo2) ? calculatedListGUIDs[propertyInfo2] : null);
						if (text == null)
						{
							string guid = observableList.guid;
							calculatedListGUIDs.Add(propertyInfo2, guid);
						}
						else
						{
							observableList.guid = text;
						}
						return new ReturnMessage(observableList, null, 0, methodCallMessage.LogicalCallContext, methodCallMessage);
					}
				}
				obj = methodInfo.Invoke(_instance, methodCallMessage.InArgs);
			}
			return new ReturnMessage(obj, null, 0, methodCallMessage.LogicalCallContext, methodCallMessage);
		}
	}
}
