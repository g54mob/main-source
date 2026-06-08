using System;

namespace NSubstitute.Core.Arguments
{
	public class ArgumentFormatter : IArgumentFormatter
	{
		internal static IArgumentFormatter Default { get; } = new ArgumentFormatter();

		public string Format(object? argument, bool highlight)
		{
			string text = Format(argument);
			if (!highlight)
			{
				return text;
			}
			return "*" + text + "*";
		}

		private string Format(object? arg)
		{
			if (arg != null)
			{
				if (arg is string text)
				{
					string text2 = text;
					return "\"" + text2 + "\"";
				}
				if (HasDefaultToString(arg))
				{
					return arg.GetType().GetNonMangledTypeName();
				}
				return arg.ToString() ?? string.Empty;
			}
			return "<null>";
			static bool HasDefaultToString(object obj)
			{
				return obj.GetType().GetMethod("ToString", Type.EmptyTypes).DeclaringType == typeof(object);
			}
		}
	}
}
