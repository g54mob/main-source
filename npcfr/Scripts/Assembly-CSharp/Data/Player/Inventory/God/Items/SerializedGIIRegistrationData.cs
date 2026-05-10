using Data.Objects;
using Data.Player.Inventory.God.Categories;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Player.Inventory.God.Items
{
	[CreateAssetMenu(fileName = "SerializedGIIRegistrationData", menuName = "FRUKT/GodInventory/ItemRegistrationData")]
	public class SerializedGIIRegistrationData : SerializedScriptableObject, bjj
	{
		[SerializeField]
		private SerializedObjectDescriptorWithIcon m_objectDescriptor;

		[SerializeField]
		private SerializedGodInventoryCategoryData m_category;

		[SerializeField]
		private kf m_prefab;

		private SerializedObjectDescriptorWithIcon xod => null;

		public string xnz => null;

		public string xoa => null;

		public bjo xob => null;

		public Sprite xoe => null;

		public Vector2 xof => default(Vector2);

		public Vector2 xog => default(Vector2);

		public Color xoh => default(Color);

		public bjk xoc => null;

		public kf xoi => null;
	}
}
