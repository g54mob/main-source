using UnityEngine;

namespace Simulator
{
	[CreateAssetMenu(fileName = "GSRef_", menuName = "Tabletop/Excel Databases/Google Sheet Ref")]
	public class GoogleSheetRef : ScriptableObject
	{
		[SerializeField]
		private CSVImporter.GoogleSheetID m_id;

		[SerializeField]
		private CSVParseRules m_parseRules;

		[SerializeField]
		private TextAsset m_textAsset;

		[SerializeField]
		private bool m_useTextAsset;

		public CSVImporter.GoogleSheetID ID => m_id;

		public CSVParseRules ParseRules => m_parseRules;

		public bool UseTextAsset(out TextAsset textAsset)
		{
			textAsset = m_textAsset;
			if (m_useTextAsset)
			{
				return textAsset != null;
			}
			return false;
		}
	}
}
