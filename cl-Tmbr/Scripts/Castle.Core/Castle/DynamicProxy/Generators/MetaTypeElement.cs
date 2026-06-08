using System;
using System.Reflection;
using System.Text;

namespace Castle.DynamicProxy.Generators
{
	internal abstract class MetaTypeElement
	{
		private readonly MemberInfo member;

		private string name;

		public bool CanBeImplementedExplicitly => member.DeclaringType?.IsInterface ?? false;

		public string Name => name;

		protected MemberInfo Member => member;

		protected MetaTypeElement(MemberInfo member)
		{
			this.member = member;
			name = member.Name;
		}

		public abstract void SwitchToExplicitImplementation();

		protected void SwitchToExplicitImplementationName()
		{
			string text = member.Name;
			Type declaringType = member.DeclaringType;
			string text2 = declaringType.Namespace;
			if (declaringType.IsGenericType)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (text2 != null)
				{
					stringBuilder.Append(text2);
					stringBuilder.Append('.');
				}
				AppendTypeName(stringBuilder, declaringType);
				stringBuilder.Append('.');
				stringBuilder.Append(text);
				name = stringBuilder.ToString();
			}
			else if (text2 != null)
			{
				name = text2 + "." + declaringType.Name + "." + text;
			}
			else
			{
				name = declaringType.Name + "." + text;
			}
			static void AppendTypeName(StringBuilder nameBuilder, Type type)
			{
				nameBuilder.Append(type.Name);
				if (type.IsGenericType)
				{
					nameBuilder.Append('[');
					Type[] genericArguments = type.GetGenericArguments();
					int i = 0;
					for (int num = genericArguments.Length; i < num; i++)
					{
						if (i > 0)
						{
							nameBuilder.Append(',');
						}
						AppendTypeName(nameBuilder, genericArguments[i]);
					}
					nameBuilder.Append(']');
				}
			}
		}
	}
}
