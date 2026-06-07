using UnityEngine;

namespace Assets.SimpleLocalization.Scripts
{
	[ExecuteInEditMode]
	public class LocalizationSync : MonoBehaviour
	{
		public string TableId;

		public Sheet[] Sheets;

		public Object SaveFolder;

		private const string UrlPattern = "https://docs.google.com/spreadsheets/d/{0}/export?format=csv&gid={1}";
	}
}
