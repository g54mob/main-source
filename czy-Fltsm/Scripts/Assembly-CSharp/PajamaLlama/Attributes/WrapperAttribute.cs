using UnityEngine;

namespace PajamaLlama.Attributes
{
	public class WrapperAttribute : PropertyAttribute
	{
		public string RelativePropertyPath { get; private set; }

		public WrapperAttribute(string relativePropertyPath)
		{
			RelativePropertyPath = relativePropertyPath;
		}
	}
}
