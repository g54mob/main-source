using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UI.Xml
{
	public class ObservableListItem : MarshalByRefObject
	{
		private static Dictionary<Type, List<MemberInfo>> _members = new Dictionary<Type, List<MemberInfo>>();

		private string _guid;

		private string guid
		{
			get
			{
				if (_guid == null)
				{
					_guid = Guid.NewGuid().ToString();
				}
				return _guid;
			}
		}

		private static List<MemberInfo> GetMembers(Type type)
		{
			if (!_members.ContainsKey(type))
			{
				_members.Add(type, (from m in type.GetMembers()
					where m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property
					select m).ToList());
			}
			return _members[type];
		}

		public override bool Equals(object obj)
		{
			if (GetHashCode() == obj.GetHashCode())
			{
				return true;
			}
			ObservableListItem observableListItem = (ObservableListItem)obj;
			if (observableListItem == null)
			{
				return false;
			}
			return guid == observableListItem.guid;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
