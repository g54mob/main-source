using System;

namespace WaveHarmonic.Crest
{
	[AttributeUsage(AttributeTargets.Class)]
	internal sealed class ForLodInput : Attribute
	{
		public readonly Type _Type;

		public readonly LodInputMode _Mode;

		public ForLodInput(Type type, LodInputMode mode)
		{
			_Type = type;
			_Mode = mode;
		}
	}
}
