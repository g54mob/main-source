using System.Collections.Generic;
using UnityEngine;

namespace ModApi.Craft.Parts.Styles.Editor
{
	public class PartStyleSetDefinition : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("A collection of keys that correspond to the data values associated with each part style of this style set.")]
		private List<string> _dataKeys;

		[SerializeField]
		[Tooltip("The part styles available within this part style set.")]
		private List<PartStyleDefinition> _styles;

		public List<string> DataKeys => _dataKeys;

		public List<PartStyleDefinition> Styles => _styles;

		public static PartStyleSetDefinition Create(GameObject parent)
		{
			PartStyleSetDefinition partStyleSetDefinition = parent.AddComponent<PartStyleSetDefinition>();
			partStyleSetDefinition._dataKeys = new List<string>();
			partStyleSetDefinition._styles = new List<PartStyleDefinition>();
			return partStyleSetDefinition;
		}
	}
}
