using UnityEngine;

namespace FuryStudios.BuildSystem
{
	public class FieldValidatorAttribute : PropertyAttribute
	{
		public static implicit operator bool(FieldValidatorAttribute attr)
		{
			return false;
		}
	}
}
