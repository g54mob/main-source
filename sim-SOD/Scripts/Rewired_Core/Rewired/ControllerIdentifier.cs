using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int LvNigBeOHUHpbkESSgiOurkLsUwi;

		private ControllerType BUBbyESKvfplkrdvXFKZHEBGbit;

		private Guid kYGaYQCKfZFlKEWRAlzuFvTSafyH;

		private string guSambsVOwpMsFnjnqRvfdrqcWKE;

		private Guid dGfzYvXFDTMlsUuksdGZqgwhltj;

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

		internal ControllerIdentifier(Controller controller)
		{
			LvNigBeOHUHpbkESSgiOurkLsUwi = 0;
			BUBbyESKvfplkrdvXFKZHEBGbit = default(ControllerType);
			kYGaYQCKfZFlKEWRAlzuFvTSafyH = default(Guid);
			guSambsVOwpMsFnjnqRvfdrqcWKE = null;
			dGfzYvXFDTMlsUuksdGZqgwhltj = default(Guid);
		}
	}
}
