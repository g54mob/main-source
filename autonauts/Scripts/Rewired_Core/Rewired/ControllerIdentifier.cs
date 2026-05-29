using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int WuIXWewTRtkXNcGHNDHMpyChWRj;

		private ControllerType CiEHnIGrjScHYHuMEoDVXvEgwiy;

		private Guid hLHPojWAxuyakcKOieCsahbSjqfw;

		private string vQVAnCuAxTJwWbkeakefzbPARyJ;

		private Guid kCyKkSZVZogqQsalnMbBoRILLqc;

		public int controllerId
		{
			get
			{
				return WuIXWewTRtkXNcGHNDHMpyChWRj;
			}
			set
			{
				WuIXWewTRtkXNcGHNDHMpyChWRj = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return CiEHnIGrjScHYHuMEoDVXvEgwiy;
			}
			set
			{
				CiEHnIGrjScHYHuMEoDVXvEgwiy = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return hLHPojWAxuyakcKOieCsahbSjqfw;
			}
			set
			{
				hLHPojWAxuyakcKOieCsahbSjqfw = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return vQVAnCuAxTJwWbkeakefzbPARyJ;
			}
			set
			{
				vQVAnCuAxTJwWbkeakefzbPARyJ = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return kCyKkSZVZogqQsalnMbBoRILLqc;
			}
			set
			{
				kCyKkSZVZogqQsalnMbBoRILLqc = value;
			}
		}

		public static ControllerIdentifier Blank
		{
			get
			{
				return new ControllerIdentifier
				{
					WuIXWewTRtkXNcGHNDHMpyChWRj = -1
				};
			}
		}

		internal ControllerIdentifier(Controller controller)
		{
			WuIXWewTRtkXNcGHNDHMpyChWRj = controller.id;
			CiEHnIGrjScHYHuMEoDVXvEgwiy = controller.type;
			hLHPojWAxuyakcKOieCsahbSjqfw = controller.hLHPojWAxuyakcKOieCsahbSjqfw;
			vQVAnCuAxTJwWbkeakefzbPARyJ = controller.hardwareIdentifier;
			kCyKkSZVZogqQsalnMbBoRILLqc = controller.deviceInstanceGuid;
		}
	}
}
