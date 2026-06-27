using System;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;
using Reflectify;

namespace FluentAssertions.Formatting
{
	public class DefaultValueFormatter : IValueFormatter
	{
		public virtual bool CanHandle(object value)
		{
			return true;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			if (value.GetType() == typeof(object))
			{
				formattedGraph.AddFragment($"System.Object (HashCode={value.GetHashCode()})");
			}
			else if (HasCompilerGeneratedToStringImplementation(value))
			{
				WriteTypeAndMemberValues(value, formattedGraph, formatChild);
			}
			else if (context.UseLineBreaks)
			{
				formattedGraph.AddFragmentOnNewLine(value.ToString());
			}
			else
			{
				formattedGraph.AddFragment(value.ToString());
			}
		}

		protected virtual MemberInfo[] GetMembers(Type type)
		{
			return type.GetMembers(MemberKind.Public);
		}

		private static bool HasCompilerGeneratedToStringImplementation(object value)
		{
			Type type = value.GetType();
			if (!HasDefaultToStringImplementation(value))
			{
				return type.IsCompilerGenerated();
			}
			return true;
		}

		private static bool HasDefaultToStringImplementation(object value)
		{
			string text = value.ToString();
			if (text != null)
			{
				return text == value.GetType().ToString();
			}
			return true;
		}

		private void WriteTypeAndMemberValues(object obj, FormattedObjectGraph formattedGraph, FormatChild formatChild)
		{
			Type type = obj.GetType();
			WriteTypeName(formattedGraph, type);
			WriteTypeValue(obj, formattedGraph, formatChild, type);
		}

		private void WriteTypeName(FormattedObjectGraph formattedGraph, Type type)
		{
			if (type.HasFriendlyName())
			{
				formattedGraph.AddFragment(TypeDisplayName(type));
			}
		}

		private void WriteTypeValue(object obj, FormattedObjectGraph formattedGraph, FormatChild formatChild, Type type)
		{
			MemberInfo[] members = GetMembers(type);
			if (members.Length == 0)
			{
				formattedGraph.AddFragment("{ }");
				return;
			}
			formattedGraph.AddLine("{");
			WriteMemberValues(obj, members, formattedGraph, formatChild);
			formattedGraph.AddFragmentOnNewLine("}");
		}

		private static void WriteMemberValues(object obj, MemberInfo[] members, FormattedObjectGraph formattedGraph, FormatChild formatChild)
		{
			using Iterator<MemberInfo> iterator = new Iterator<MemberInfo>(members.OrderBy((MemberInfo mi) => mi.Name, StringComparer.Ordinal));
			while (iterator.MoveNext())
			{
				WriteMemberValueTextFor(obj, iterator.Current, formattedGraph, formatChild);
				if (!iterator.IsLast)
				{
					formattedGraph.AddFragment(", ");
				}
			}
		}

		protected virtual string TypeDisplayName(Type type)
		{
			return type.FullName;
		}

		private static void WriteMemberValueTextFor(object value, MemberInfo member, FormattedObjectGraph formattedGraph, FormatChild formatChild)
		{
			object value3;
			try
			{
				object value2;
				if (!(member is FieldInfo fieldInfo))
				{
					if (!(member is PropertyInfo propertyInfo))
					{
						throw new InvalidOperationException();
					}
					value2 = propertyInfo.GetValue(value);
				}
				else
				{
					value2 = fieldInfo.GetValue(value);
				}
				value3 = value2;
			}
			catch (Exception ex)
			{
				Exception ex2 = (ex as TargetInvocationException)?.InnerException ?? ex;
				value3 = "[Member '" + member.Name + "' threw an exception: '" + ex2.Message + "']";
			}
			formattedGraph.AddFragmentOnNewLine(new string(' ', FormattedObjectGraph.SpacesPerIndentation) + member.Name + " = ");
			formatChild(member.Name, value3, formattedGraph);
		}
	}
}
