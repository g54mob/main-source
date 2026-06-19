using UnityEngine;

namespace Pug.Properties
{
	public static class Property
	{
		[PropertyIDGenerator(0)]
		public static int StringToHash(string propertyName)
		{
			return Animator.StringToHash(propertyName);
		}
	}
}
