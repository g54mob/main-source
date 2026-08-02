using UnityEngine;

namespace Rhizomatic
{
	public abstract class NumberFieldParser : ScriptableObject
	{
		public abstract bool Parse(string value, out float result);
	}
}
