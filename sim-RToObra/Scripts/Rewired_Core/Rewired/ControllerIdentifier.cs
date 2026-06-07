using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int ruGCBfCWNtGZeTUKxKBCHIMxrSyL;

		private ControllerType xRMUSowrwSVmfxjnqwQXevUgxsr;

		private Guid OtVFjwsBdyyNFQHLWfYqCKpUyfa;

		private string GOBLRLMGMTodnLnbSeKpQVQIQoK;

		private Guid JCeqfBzZTiKVlQwcFexVDYSXhtz;

		public int controllerId
		{
			get
			{
				return ruGCBfCWNtGZeTUKxKBCHIMxrSyL;
			}
			set
			{
				ruGCBfCWNtGZeTUKxKBCHIMxrSyL = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return xRMUSowrwSVmfxjnqwQXevUgxsr;
			}
			set
			{
				xRMUSowrwSVmfxjnqwQXevUgxsr = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return OtVFjwsBdyyNFQHLWfYqCKpUyfa;
			}
			set
			{
				OtVFjwsBdyyNFQHLWfYqCKpUyfa = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return GOBLRLMGMTodnLnbSeKpQVQIQoK;
			}
			set
			{
				GOBLRLMGMTodnLnbSeKpQVQIQoK = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return JCeqfBzZTiKVlQwcFexVDYSXhtz;
			}
			set
			{
				JCeqfBzZTiKVlQwcFexVDYSXhtz = value;
			}
		}

		internal ControllerIdentifier(Controller controller)
		{
			ruGCBfCWNtGZeTUKxKBCHIMxrSyL = controller.id;
			xRMUSowrwSVmfxjnqwQXevUgxsr = controller.type;
			OtVFjwsBdyyNFQHLWfYqCKpUyfa = controller.OtVFjwsBdyyNFQHLWfYqCKpUyfa;
			GOBLRLMGMTodnLnbSeKpQVQIQoK = controller.hardwareIdentifier;
			JCeqfBzZTiKVlQwcFexVDYSXhtz = controller.deviceInstanceGuid;
		}
	}
}
