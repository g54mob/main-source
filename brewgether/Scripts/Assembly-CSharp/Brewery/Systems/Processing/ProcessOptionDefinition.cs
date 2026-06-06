using Unity.Collections;

namespace Brewery.Systems.Processing
{
	public readonly struct ProcessOptionDefinition
	{
		public FixedString64Bytes Key { get; }

		public ProcessOptionDefinition(FixedString64Bytes key)
		{
			Key = default(FixedString64Bytes);
		}
	}
}
