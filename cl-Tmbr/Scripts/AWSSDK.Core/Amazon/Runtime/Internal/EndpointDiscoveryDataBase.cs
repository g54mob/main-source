using System.Collections.Generic;

namespace Amazon.Runtime.Internal
{
	public abstract class EndpointDiscoveryDataBase
	{
		private bool _required;

		private SortedDictionary<string, string> _identifiers;

		public virtual bool Required
		{
			get
			{
				return _required;
			}
			protected set
			{
				_required = value;
			}
		}

		public virtual SortedDictionary<string, string> Identifiers
		{
			get
			{
				return _identifiers;
			}
			protected set
			{
				_identifiers = value;
			}
		}

		protected EndpointDiscoveryDataBase(bool required)
		{
			_required = required;
			_identifiers = new SortedDictionary<string, string>();
		}
	}
}
