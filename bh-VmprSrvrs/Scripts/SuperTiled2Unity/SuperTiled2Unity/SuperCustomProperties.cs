using System.Collections.Generic;
using UnityEngine;

namespace SuperTiled2Unity
{
	public class SuperCustomProperties : MonoBehaviour
	{
		public List<CustomProperty> m_Properties;

		public bool TryGetCustomProperty(string name, out CustomProperty property)
		{
			property = null;
			return false;
		}

		public void RemoveCustomProperty(string name)
		{
		}
	}
}
