using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NSubstitute.Core.Arguments
{
	public class ArrayContentsArgumentMatcher : IArgumentMatcher, IArgumentFormatter
	{
		private readonly IArgumentSpecification[] _argumentSpecifications;

		public ArrayContentsArgumentMatcher(IEnumerable<IArgumentSpecification> argumentSpecifications)
		{
			_argumentSpecifications = argumentSpecifications.ToArray();
		}

		public bool IsSatisfiedBy(object? argument)
		{
			if (argument != null)
			{
				object[] argumentArray = ((IEnumerable)argument).Cast<object>().ToArray();
				if (argumentArray.Length == _argumentSpecifications.Length)
				{
					return _argumentSpecifications.Select((IArgumentSpecification spec, int index) => spec.IsSatisfiedBy(argumentArray[index])).All((bool x) => x);
				}
			}
			return false;
		}

		public override string ToString()
		{
			return string.Join(", ", _argumentSpecifications.Select((IArgumentSpecification x) => x.ToString()));
		}

		public string Format(object? argument, bool highlight)
		{
			object[] args = ((argument is IEnumerable source) ? source.Cast<object>().ToArray() : new object[0]);
			return Format(args, _argumentSpecifications).Join(", ");
		}

		private IEnumerable<string> Format(object[] args, IArgumentSpecification[] specs)
		{
			if (specs.Any() && !args.Any())
			{
				return new string[1] { "**" };
			}
			return args.Select((object arg, int index) => (index >= specs.Length) ? ArgumentFormatter.Default.Format(arg, highlight: true) : specs[index].FormatArgument(arg));
		}
	}
}
