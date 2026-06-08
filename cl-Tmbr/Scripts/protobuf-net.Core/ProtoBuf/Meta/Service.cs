using System.Collections.Generic;

namespace ProtoBuf.Meta
{
	public sealed class Service
	{
		public string Name { get; set; }

		public List<ServiceMethod> Methods { get; } = new List<ServiceMethod>();
	}
}
