using System;
using UnityEngine;

namespace LaundryBear.EditorAttributes
{
	public class EditableObjectListAttribute : PropertyAttribute
	{
		private string[] m_displayNames;

		private Func<ScriptableObject>[] m_factoryMethods;

		public string[] DisplayNames => m_displayNames;

		public Func<ScriptableObject>[] FactoryMethods => m_factoryMethods;
	}
}
