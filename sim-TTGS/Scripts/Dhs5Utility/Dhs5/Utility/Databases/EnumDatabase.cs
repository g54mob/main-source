using UnityEngine;

namespace Dhs5.Utility.Databases
{
	public abstract class EnumDatabase : ScriptableDataContainer
	{
		[SerializeField]
		private string m_enumName;

		[SerializeField]
		private string m_enumNamespace;

		[SerializeField]
		[TextArea]
		private string m_usings;

		[SerializeField]
		[FolderPicker]
		private string m_scriptFolder;

		[SerializeField]
		private TextAsset m_textAsset;
	}
}
