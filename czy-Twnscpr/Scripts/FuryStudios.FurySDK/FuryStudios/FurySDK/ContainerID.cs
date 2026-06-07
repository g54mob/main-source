using System;

namespace FuryStudios.FurySDK
{
	[Serializable]
	public struct ContainerID
	{
		public string id;

		public ContainerID(string id)
		{
			this.id = null;
		}

		public static explicit operator string(ContainerID container)
		{
			return null;
		}

		public static implicit operator ContainerID(string id)
		{
			return default(ContainerID);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
