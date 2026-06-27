using UnityEngine;

namespace Restory.Data.Profiles
{
	[CreateAssetMenu(fileName = "ProfileIcon", menuName = "Restory/Profiles/ProfileIcon")]
	public class ProfileIcon : ScriptableObject
	{
		[SerializeField]
		private Sprite icon;

		[SerializeField]
		private string id;

		public Sprite Icon => icon;

		public string Id => id;
	}
}
