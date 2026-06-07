using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Objects
{
	[CreateAssetMenu(fileName = "SerializedObjectDescriptor", menuName = "FRUKT/Descriptors/ObjectDescriptor")]
	public class SerializedObjectDescriptor : SerializedScriptableObject, bjl
	{
		[SerializeField]
		private string m_objectName;

		[SerializeField]
		[TextArea]
		private string m_description;

		public string tcf => null;

		public string tcg => null;
	}
}
