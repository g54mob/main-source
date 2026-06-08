using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace HandlebarsDotNet
{
	public class DynamicViewModel : DynamicObject
	{
		private readonly object[] _objects;

		private static readonly BindingFlags BindingFlags = BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public;

		public DynamicViewModel(params object[] objects)
		{
			_objects = objects;
		}

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return from m in _objects.Select((object o) => o.GetType()).SelectMany((Type t) => t.GetMembers(BindingFlags))
				select m.Name;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = null;
			object[] objects = _objects;
			foreach (object obj in objects)
			{
				MemberInfo[] member = obj.GetType().GetMember(binder.Name, BindingFlags);
				if (member.Length != 0)
				{
					if (member[0] is PropertyInfo)
					{
						result = ((PropertyInfo)member[0]).GetValue(obj, null);
						return true;
					}
					if (member[0] is FieldInfo)
					{
						result = ((FieldInfo)member[0]).GetValue(obj);
						return true;
					}
				}
			}
			return false;
		}
	}
}
