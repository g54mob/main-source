using Data.Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Player.Inventory.God.Categories
{
	[CreateAssetMenu(fileName = "GodInventoryCategoryData", menuName = "FRUKT/Inventory/CategoryData")]
	public class SerializedGodInventoryCategoryData : SerializedScriptableObject, bjk, bjm, bjl, bjp
	{
		[SerializeField]
		private SerializedObjectDescriptorWithIcon m_descriptor;

		[SerializeField]
		private string m_id;

		private SerializedObjectDescriptorWithIcon xok => null;

		public string tcf => null;

		public string tcg => null;

		public bjo tch => null;

		public string xoj => null;
	}
}
