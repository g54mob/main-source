using System;

namespace TriLib
{
	public class MaterialProperty<T> : IMaterialProperty
	{
		public string Name { get; private set; }

		public Type Type => null;

		public uint Index { get; private set; }

		public uint Semantic { get; private set; }

		public T Data { get; private set; }

		public MaterialProperty(string name, T data, uint index, uint semantic)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
