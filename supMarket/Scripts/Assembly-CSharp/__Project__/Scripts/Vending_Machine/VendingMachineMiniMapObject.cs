using UnityEngine;

namespace __Project__.Scripts.Vending_Machine
{
	public class VendingMachineMiniMapObject : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer m_Renderer;

		[SerializeField]
		private float m_YPosition;

		private int m_UniqueID;

		private VendingMachine m_VendingMachine;

		public int UniqueID => 0;

		public VendingMachine VendingMachine
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Initialize(int uniqueID, Vector3 pos)
		{
		}

		public void UpdatePosition(Vector3 position)
		{
		}
	}
}
