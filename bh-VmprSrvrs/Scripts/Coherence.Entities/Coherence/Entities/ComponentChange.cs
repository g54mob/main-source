namespace Coherence.Entities
{
	public struct ComponentChange
	{
		public uint ComponentSerializeType { get; private set; }

		public ICoherenceComponentData Data { get; private set; }

		public static ComponentChange New(ICoherenceComponentData data)
		{
			return default(ComponentChange);
		}

		public void SetSerializeType(uint compType)
		{
		}

		public ComponentChange Update(ComponentChange change)
		{
			return default(ComponentChange);
		}

		public ComponentChange ClearMask(uint mask)
		{
			return default(ComponentChange);
		}

		public ComponentChange ClearStoppedMask(uint mask)
		{
			return default(ComponentChange);
		}

		public ComponentChange Clone()
		{
			return default(ComponentChange);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
