using System;

namespace com.ootii.Actors.BoneControllers
{
	public class IKDescriptionAttribute : Attribute
	{
		public string Description;

		public IKDescriptionAttribute(string rValue)
		{
		}
	}
}
