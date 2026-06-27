using UnityEngine;

namespace Helpers.Attributes
{
	public class SceneAttribute : PropertyAttribute
	{
		public bool CheckBuildListOnly { get; protected set; }

		public SceneAttribute()
		{
			CheckBuildListOnly = false;
		}

		public SceneAttribute(bool includedInBuildOnly)
		{
			CheckBuildListOnly = includedInBuildOnly;
		}
	}
}
