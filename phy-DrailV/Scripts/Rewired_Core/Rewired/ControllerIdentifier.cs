using System;

namespace Rewired
{
	public struct ControllerIdentifier
	{
		private int iaZAeHIptgfYnzhUoKmpmEkRtvpO;

		private ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

		private Guid FZUSYXsTFrKCEfDGTdZDqHMyUGhC;

		private string HAGHopIAmOlnmogjJDRAbaxiFtLmA;

		private Guid AIzKFppczrKwcfHsGKZydmrnUHsF;

		public int controllerId
		{
			get
			{
				return iaZAeHIptgfYnzhUoKmpmEkRtvpO;
			}
			set
			{
				iaZAeHIptgfYnzhUoKmpmEkRtvpO = value;
			}
		}

		public ControllerType controllerType
		{
			get
			{
				return ueTsfWyPNTdEyAOjfZNcYrBGNSmq;
			}
			set
			{
				ueTsfWyPNTdEyAOjfZNcYrBGNSmq = value;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				return FZUSYXsTFrKCEfDGTdZDqHMyUGhC;
			}
			set
			{
				FZUSYXsTFrKCEfDGTdZDqHMyUGhC = value;
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				return HAGHopIAmOlnmogjJDRAbaxiFtLmA;
			}
			set
			{
				HAGHopIAmOlnmogjJDRAbaxiFtLmA = value;
			}
		}

		public Guid deviceInstanceGuid
		{
			get
			{
				return AIzKFppczrKwcfHsGKZydmrnUHsF;
			}
			set
			{
				AIzKFppczrKwcfHsGKZydmrnUHsF = value;
			}
		}

		public static ControllerIdentifier Blank => new ControllerIdentifier
		{
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = -1
		};

		internal ControllerIdentifier(Controller P_0)
		{
			iaZAeHIptgfYnzhUoKmpmEkRtvpO = P_0.id;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_0.type;
			FZUSYXsTFrKCEfDGTdZDqHMyUGhC = P_0.FZUSYXsTFrKCEfDGTdZDqHMyUGhC;
			HAGHopIAmOlnmogjJDRAbaxiFtLmA = P_0.hardwareIdentifier;
			AIzKFppczrKwcfHsGKZydmrnUHsF = P_0.deviceInstanceGuid;
		}
	}
}
