using UnityEngine;

namespace MalbersAnimations
{
	public class CreateMonoAttribute : PropertyAttribute
	{
		public string name;

		public CreateMonoAttribute(string name)
		{
			this.name = name;
		}

		public CreateMonoAttribute()
		{
			name = string.Empty;
		}
	}
}
