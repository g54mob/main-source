namespace Ink.Runtime
{
	public class DivertTargetValue : Value<Path>
	{
		public Path targetPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override ValueType valueType => default(ValueType);

		public override bool isTruthy => false;

		public DivertTargetValue(Path targetPath)
			: base((Path)default(_00210))
		{
		}

		public DivertTargetValue()
			: base((Path)default(_00210))
		{
		}

		public override Value Cast(ValueType newType)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
