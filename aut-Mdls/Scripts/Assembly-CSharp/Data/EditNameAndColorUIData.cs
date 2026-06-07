using UnityEngine;

namespace Data
{
	[CreateAssetMenu(menuName = "UI/EditNameAndColorUIData", fileName = "EditNameAndColorUIData", order = 0)]
	public class EditNameAndColorUIData : ScriptableObject
	{
		[SerializeField]
		[LocaKey]
		private string _titleCreate;

		[SerializeField]
		[LocaKey]
		private string _titleEdit;

		public string TitleCreate => _titleCreate;

		public string TitleEdit => _titleEdit;
	}
}
