using System.Collections.Generic;
using System.Diagnostics.Internal;
using System.Text;

namespace System.Diagnostics
{
	internal class ValueTupleResolvedParameter : ResolvedParameter
	{
		public IList<string?> TupleNames { get; }

		public ValueTupleResolvedParameter(Type resolvedType, IList<string?> tupleNames)
			: base(resolvedType)
		{
			TupleNames = tupleNames;
		}

		protected override void AppendTypeName(StringBuilder sb)
		{
			if ((object)base.ResolvedType != null)
			{
				if (base.ResolvedType.IsValueTuple())
				{
					AppendValueTupleParameterName(sb, base.ResolvedType);
					return;
				}
				sb.Append(TypeNameHelper.GetTypeNameForGenericType(base.ResolvedType));
				sb.Append("<");
				AppendValueTupleParameterName(sb, base.ResolvedType.GetGenericArguments()[0]);
				sb.Append(">");
			}
		}

		private void AppendValueTupleParameterName(StringBuilder sb, Type parameterType)
		{
			sb.Append("(");
			Type[] genericArguments = parameterType.GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
				}
				sb.AppendTypeDisplayName(genericArguments[i], fullName: false, includeGenericParameterNames: true);
				if (i < TupleNames.Count)
				{
					string text = TupleNames[i];
					if (text != null)
					{
						sb.Append(" ");
						sb.Append(text);
					}
				}
			}
			sb.Append(")");
		}
	}
}
