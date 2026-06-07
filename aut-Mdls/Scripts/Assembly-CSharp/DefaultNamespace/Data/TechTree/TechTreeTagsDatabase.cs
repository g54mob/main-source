using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Data.TechTree
{
	[CreateAssetMenu(menuName = "Tech Tree/TechTreeTagsDatabase", fileName = "TechTreeTagsDatabase", order = 0)]
	public class TechTreeTagsDatabase : ScriptableObject
	{
		[SerializeField]
		private List<TagLocalization> _tagsLocalization = new List<TagLocalization>();

		public List<TagLocalization> TagsLocalization => _tagsLocalization;
	}
}
