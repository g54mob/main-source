using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public class PartDefinitionConfig : Config
	{
		public string title;

		[TextArea]
		public string tooltip;

		public PartCategoryConfig category;

		public PartConfigEntry part;

		public Vector3 rotation;

		public bool copySelected;

		[TextArea(2, 10)]
		public string data;
	}
}
