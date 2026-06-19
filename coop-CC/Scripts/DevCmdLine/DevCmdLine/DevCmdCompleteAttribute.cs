using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DevCmdLine
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class DevCmdCompleteAttribute : Attribute
	{
		public readonly string name;

		public readonly int varIndex;

		public readonly string[] options;

		public readonly DevCmdCompleteFlags flags;

		public DevCmdCompleteAttribute(string name, params string[] options)
			: this(name, 0, DevCmdCompleteFlags.Default, options)
		{
		}

		public DevCmdCompleteAttribute(string name, int varIndex, params string[] options)
			: this(name, varIndex, DevCmdCompleteFlags.Default, options)
		{
		}

		public DevCmdCompleteAttribute(string name, DevCmdCompleteFlags flags, params string[] options)
			: this(name, 0, flags, options)
		{
		}

		public DevCmdCompleteAttribute(string name, int varIndex, DevCmdCompleteFlags flags, params string[] options)
		{
			this.name = name.ToLower();
			this.varIndex = varIndex;
			this.options = options;
			this.flags = flags | DevCmdCompleteFlags.Cache;
		}

		public DevCmdCompleteAttribute(string name, Type enumType)
			: this(name, 0, DevCmdCompleteFlags.Default, enumType)
		{
		}

		public DevCmdCompleteAttribute(string name, DevCmdCompleteFlags flags, Type enumType)
			: this(name, 0, flags, enumType)
		{
		}

		public DevCmdCompleteAttribute(string name, int varIndex, DevCmdCompleteFlags flags, Type enumType)
		{
			this.name = name.ToLower();
			this.varIndex = varIndex;
			this.flags = flags | DevCmdCompleteFlags.Cache;
			List<string> list = new List<string>();
			string[] names = Enum.GetNames(enumType);
			foreach (string item in names)
			{
				MemberInfo element = enumType.GetMember(item).FirstOrDefault((MemberInfo m) => m.DeclaringType == enumType);
				if (element.GetCustomAttribute<DevCmdHideAttribute>() == null)
				{
					DevCmdNameAttribute customAttribute = element.GetCustomAttribute<DevCmdNameAttribute>();
					if (customAttribute != null)
					{
						list.Add(customAttribute.name);
					}
					else
					{
						list.Add(item);
					}
				}
			}
			options = list.ToArray();
		}
	}
}
