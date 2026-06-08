using System;

namespace ProtoBuf
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = true, Inherited = false)]
	public sealed class ProtoReservedAttribute : Attribute
	{
		public int From { get; }

		public int To { get; }

		public string Name { get; }

		public string Comment { get; }

		public ProtoReservedAttribute(int field, string comment = null)
			: this(field, field, comment)
		{
		}

		public ProtoReservedAttribute(int from, int to, string comment = null)
		{
			From = from;
			To = to;
			Comment = comment;
		}

		public ProtoReservedAttribute(string field, string comment = null)
		{
			Name = field;
			Comment = comment;
		}

		internal void Verify()
		{
			if (string.IsNullOrWhiteSpace(Name))
			{
				if (From <= 0)
				{
					throw new ArgumentOutOfRangeException("From", "Invalid reservation definition");
				}
				if (To < From)
				{
					throw new ArgumentOutOfRangeException("To", "Invalid reservation definition");
				}
			}
		}
	}
}
