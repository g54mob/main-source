using System;

namespace NAudio.Dmo
{
	internal struct DmoPartialMediaType
	{
		private Guid type;

		private Guid subtype;

		public Guid Type
		{
			get
			{
				return default(Guid);
			}
			internal set
			{
			}
		}

		public Guid Subtype
		{
			get
			{
				return default(Guid);
			}
			internal set
			{
			}
		}
	}
}
