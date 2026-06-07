using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace UI.Xml
{
	public class ObservableListItemProxy<T> : RealProxy
	{
		private readonly object _instance;

		private readonly IObservableList _list;

		private ObservableListItemProxy(T instance, IObservableList list)
			: base(typeof(T))
		{
			_instance = instance;
			_list = list;
		}

		public static T Create(T instance, IObservableList list)
		{
			return (T)new ObservableListItemProxy<T>(instance, list).GetTransparentProxy();
		}

		public override IMessage Invoke(IMessage msg)
		{
			IMethodCallMessage methodCallMessage = (IMethodCallMessage)msg;
			MethodInfo methodInfo = (MethodInfo)methodCallMessage.MethodBase;
			bool num = methodInfo.Name.StartsWith("set_");
			object obj = null;
			if (num)
			{
				string propertyName = methodInfo.Name.Replace("set_", string.Empty);
				PropertyInfo propertyInfo = typeof(T).GetProperties().First((PropertyInfo p) => p.Name == propertyName);
				object value = propertyInfo.GetValue(_instance, XmlLayoutUtilities.BindingFlags, null, null, null);
				obj = methodInfo.Invoke(_instance, methodCallMessage.InArgs);
				object value2 = propertyInfo.GetValue(_instance, XmlLayoutUtilities.BindingFlags, null, null, null);
				if (value != value2)
				{
					_list.NotifyItemChanged(_instance, propertyName);
				}
			}
			else if (methodInfo.Name == "FieldSetter")
			{
				string fieldName = methodCallMessage.Args[1].ToString();
				object obj2 = methodCallMessage.Args[2];
				FieldInfo fieldInfo = typeof(T).GetFields().First((FieldInfo f) => f.Name == fieldName);
				object value3 = fieldInfo.GetValue(_instance);
				obj = methodInfo.Invoke(_instance, methodCallMessage.InArgs);
				fieldInfo.SetValue(_instance, obj2);
				if ((value3 == null && obj2 != null) || !value3.Equals(obj2))
				{
					_list.NotifyItemChanged(_instance, fieldName);
				}
			}
			else
			{
				obj = methodInfo.Invoke(_instance, methodCallMessage.InArgs);
			}
			return new ReturnMessage(obj, null, 0, methodCallMessage.LogicalCallContext, methodCallMessage);
		}
	}
}
