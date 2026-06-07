using System;

namespace VolFx
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public class ShaderNameAttribute : Attribute
	{
		public string _name;

		public ShaderNameAttribute(string name)
		{
			_name = name;
		}
	}
}
