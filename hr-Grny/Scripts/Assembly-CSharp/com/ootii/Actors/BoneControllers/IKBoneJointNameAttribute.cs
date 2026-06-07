using System;

namespace com.ootii.Actors.BoneControllers
{
	public class IKBoneJointNameAttribute : Attribute
	{
		protected string mValue;

		public string Value => null;

		public IKBoneJointNameAttribute(string rValue)
		{
		}
	}
}
