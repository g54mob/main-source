using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int geiFrJCKClSdmONIywDTURjYPJnTA;

		private ControllerType jWEHFBYpJqUErvsQFOkVsnBjEAQe;

		private Guid RKtQsXAZcumTLjWzMqyhDpcCPQTx;

		private string WqKxtyoOHIsKgjtDISLXKYcsazCQ;

		private Guid GJgdWGVVIcKdNIXnufUhLdsqTUZH;

		public int controllerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return default(ControllerType);
			}
			set
			{
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public static ControllerIdentifier Blank => default(ControllerIdentifier);

		internal ControllerIdentifier(Controller P_0)
		{
			geiFrJCKClSdmONIywDTURjYPJnTA = 0;
			jWEHFBYpJqUErvsQFOkVsnBjEAQe = default(ControllerType);
			RKtQsXAZcumTLjWzMqyhDpcCPQTx = default(Guid);
			WqKxtyoOHIsKgjtDISLXKYcsazCQ = null;
			GJgdWGVVIcKdNIXnufUhLdsqTUZH = default(Guid);
		}
	}
}
