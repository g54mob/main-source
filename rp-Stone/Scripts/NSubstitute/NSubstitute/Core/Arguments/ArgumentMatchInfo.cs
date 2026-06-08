namespace NSubstitute.Core.Arguments
{
	public class ArgumentMatchInfo
	{
		private readonly object? _argument;

		private readonly IArgumentSpecification _specification;

		public int Index { get; }

		public bool IsMatch => _specification.IsSatisfiedBy(_argument);

		public ArgumentMatchInfo(int index, object? argument, IArgumentSpecification specification)
		{
			Index = index;
			_argument = argument;
			_specification = specification;
		}

		public string DescribeNonMatch()
		{
			string text = _specification.DescribeNonMatch(_argument);
			if (string.IsNullOrEmpty(text))
			{
				return string.Empty;
			}
			string text2 = "arg[" + Index + "]: ";
			return string.Format("{0}{1}", text2, text.Replace("\n", "\n".PadRight(text2.Length + 1)));
		}

		public bool Equals(ArgumentMatchInfo? other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (other.Index == Index && object.Equals(other._argument, _argument))
			{
				return object.Equals(other._specification, _specification);
			}
			return false;
		}

		public override bool Equals(object? obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != typeof(ArgumentMatchInfo))
			{
				return false;
			}
			return Equals((ArgumentMatchInfo)obj);
		}

		public override int GetHashCode()
		{
			return (((Index * 397) ^ ((_argument != null) ? _argument.GetHashCode() : 0)) * 397) ^ _specification.GetHashCode();
		}
	}
}
