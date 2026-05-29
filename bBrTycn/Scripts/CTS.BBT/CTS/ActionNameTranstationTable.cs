using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "ActionNameTranstationTable", menuName = "Action/TranstationTable")]
	public class ActionNameTranstationTable : ScriptableObject
	{
		[field: SerializeField]
		public ActionTranstationElement[] TranstationElement { get; private set; }
	}
}
