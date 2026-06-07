using System;

namespace com.ootii.Actors.BoneControllers
{
	[AttributeUsage(AttributeTargets.Class)]
	public class IKNameAttribute : Attribute
	{
		public string Name;

		public IKNameAttribute(string rValue)
		{
		}
	}
}
