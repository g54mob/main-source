using UnityEngine;

namespace Data.ResourceTypes
{
	[CreateAssetMenu(menuName = "ResourceTypes/ResourceTypeBase", fileName = "ResourceTypeBase", order = 0)]
	public class ResourceType : ScriptableObject
	{
		[SerializeField]
		private Sprite _icon;

		public Sprite Icon => _icon;
	}
}
