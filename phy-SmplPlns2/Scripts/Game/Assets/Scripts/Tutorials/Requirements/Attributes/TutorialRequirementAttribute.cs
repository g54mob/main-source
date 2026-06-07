using System;

namespace Assets.Scripts.Tutorials.Requirements.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class TutorialRequirementAttribute : Attribute
	{
		public string Id { get; }

		public TutorialRequirementAttribute(string id)
		{
			Id = id;
		}
	}
}
