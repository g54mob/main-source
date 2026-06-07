using UnityEngine;

namespace ModApi.Craft.Parts.Editor
{
	public class PartDefinitionPrefabReference : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The path of the stock prefab to use for this part.")]
		private string _prefabPath;

		public string PrefabPath
		{
			get
			{
				return _prefabPath;
			}
			set
			{
				_prefabPath = value;
			}
		}
	}
}
