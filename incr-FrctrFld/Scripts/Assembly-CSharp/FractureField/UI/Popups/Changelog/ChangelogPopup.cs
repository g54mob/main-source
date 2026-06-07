using UnityEngine;

namespace FractureField.UI.Popups.Changelog
{
	public class ChangelogPopup : Popup
	{
		[Header("References")]
		[SerializeField]
		private Transform _contentContainer;

		[SerializeField]
		private ChangelogEntry _pfChangelogEntry;

		public override void Open()
		{
		}

		public void Setup()
		{
		}
	}
}
