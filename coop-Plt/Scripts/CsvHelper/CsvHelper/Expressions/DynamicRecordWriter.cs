using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;

namespace CsvHelper.Expressions
{
	public class DynamicRecordWriter : RecordWriter
	{
		private readonly Hashtable getters = new Hashtable();

		public DynamicRecordWriter(CsvWriter writer)
			: base(writer)
		{
		}

		protected override Action<T> CreateWriteDelegate<T>(T record)
		{
			return delegate(T r)
			{
				IDynamicMetaObjectProvider dynamicMetaObjectProvider = (IDynamicMetaObjectProvider)(object)r;
				dynamicMetaObjectProvider.GetType();
				ParameterExpression parameter = Expression.Parameter(typeof(T), "record");
				IEnumerable<string> enumerable = dynamicMetaObjectProvider.GetMetaObject(parameter).GetDynamicMemberNames();
				if (base.Writer.Configuration.DynamicPropertySort != null)
				{
					enumerable = enumerable.OrderBy((string name) => name, base.Writer.Configuration.DynamicPropertySort);
				}
				foreach (string item in enumerable)
				{
					object value = GetValue(item, dynamicMetaObjectProvider);
					base.Writer.WriteField(value);
				}
			};
		}

		private object GetValue(string name, IDynamicMetaObjectProvider target)
		{
			CallSite<Func<CallSite, IDynamicMetaObjectProvider, object>> callSite = (CallSite<Func<CallSite, IDynamicMetaObjectProvider, object>>)getters[name];
			if (callSite == null)
			{
				CallSiteBinder member = Binder.GetMember(CSharpBinderFlags.None, name, typeof(DynamicRecordWriter), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
				callSite = (CallSite<Func<CallSite, IDynamicMetaObjectProvider, object>>)(getters[name] = CallSite<Func<CallSite, IDynamicMetaObjectProvider, object>>.Create(member));
			}
			return callSite.Target(callSite, target);
		}
	}
}
