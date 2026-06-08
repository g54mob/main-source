using System;
using ProtoBuf.Internal;

namespace ProtoBuf.Meta
{
	public class TypeFormatEventArgs : EventArgs
	{
		private Type type;

		private string formattedName;

		private readonly bool typeFixed;

		public Type Type
		{
			get
			{
				return type;
			}
			set
			{
				if (type != value)
				{
					if (typeFixed)
					{
						ThrowHelper.ThrowInvalidOperationException("The type is fixed and cannot be changed");
					}
					type = value;
				}
			}
		}

		public string FormattedName
		{
			get
			{
				return formattedName;
			}
			set
			{
				if (formattedName != value)
				{
					if (!typeFixed)
					{
						ThrowHelper.ThrowInvalidOperationException("The formatted-name is fixed and cannot be changed");
					}
					formattedName = value;
				}
			}
		}

		internal TypeFormatEventArgs(string formattedName)
		{
			if (string.IsNullOrEmpty(formattedName))
			{
				ThrowHelper.ThrowArgumentNullException("formattedName");
			}
			this.formattedName = formattedName;
		}

		internal TypeFormatEventArgs(Type type)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException("type");
			}
			this.type = type;
			typeFixed = true;
		}
	}
}
