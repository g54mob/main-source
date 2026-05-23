using System;

namespace Deform
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class DeformerAttribute : Attribute
	{
		public string Name;

		public string Description;

		public Category Category;

		public Type Type;

		public float XRotation;

		public float YRotation;

		public float ZRotation;
	}
}
