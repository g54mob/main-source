using System.Collections.Generic;
using UnityEngine;

namespace Restory.Data.Profiles
{
	[CreateAssetMenu(fileName = "ProfilesInfo", menuName = "Restory/Profiles/ProfilesInfo")]
	public class ProfilesInfo : ScriptableObject
	{
		[SerializeField]
		private List<ProfileIcon> profilesIcons;

		public IReadOnlyCollection<ProfileIcon> ProfilesIcons => profilesIcons;
	}
}
