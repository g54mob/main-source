using System.Collections.Generic;
using UnityEngine;

namespace Linework.Common
{
	[RequireComponent(typeof(Renderer))]
	public class OutlineOverride : MonoBehaviour
	{
		public List<ShaderPropertyOverride> overrides;

		private MaterialPropertyBlock propertyBlock;

		public void AddFloatOverride(string propertyName, float value)
		{
		}

		public void AddIntOverride(string propertyName, int value)
		{
		}

		public void AddColorOverride(string propertyName, Color color)
		{
		}

		public void AddVectorOverride(string propertyName, Vector4 value)
		{
		}

		private void Start()
		{
		}

		private void OnValidate()
		{
		}

		private void SetOverrides()
		{
		}
	}
}
