using System;

namespace LitJson
{
	internal struct ArrayMetadata
	{
		private Type elemType;

		public bool IsArray { get; set; }

		public bool IsList { get; set; }

		public Type ElementType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
