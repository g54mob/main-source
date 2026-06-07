using UnityEngine;

namespace Gh
{
	public class SoundEngineParameterControl<T>
	{
		public readonly string Name;

		public T CurrentValue { get; private set; }

		public GameObject TargetObject { get; private set; }

		internal SoundEngineParameterControl(string name, T value, GameObject obj = null)
		{
		}

		public void UpdateAndApply(T value)
		{
		}

		public void ApplyParameter()
		{
		}
	}
}
