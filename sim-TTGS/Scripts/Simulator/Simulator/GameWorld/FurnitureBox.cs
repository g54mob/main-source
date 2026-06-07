namespace Simulator.GameWorld
{
	public class FurnitureBox : BaseBox
	{
		private int m_furnitureUID;

		private Furniture m_furniture;

		public override bool IsEmpty
		{
			get
			{
				if (base.IsOpen)
				{
					return m_furniture == null;
				}
				return false;
			}
		}

		public Furniture Furniture => m_furniture;

		public override void Init(BaseShopBoxData data)
		{
			base.Init(data);
			m_furnitureUID = (data as FurnitureShopBoxData).Furniture.UID;
		}

		protected override void Load(BaseShopBoxData data, BoxSaveState saveState)
		{
			if (saveState.open)
			{
				base.IsOpen = true;
				base.OnOpen();
				m_furniture = null;
			}
			Init(data);
		}

		public override bool CanBeToggled()
		{
			return !base.IsOpen;
		}

		protected override void OnOpen()
		{
			base.OnOpen();
			World.ShopBuilding.PrepareNewFurniture(m_furnitureUID, out m_furniture);
			m_furniture.Initialized += OnFurnitureInitialized;
		}

		protected override void OnClose()
		{
			base.OnClose();
			if (m_furniture != null)
			{
				m_furniture.Initialized -= OnFurnitureInitialized;
				World.ShopBuilding.DestroyFurniture(m_furniture.GameID);
			}
		}

		private void OnFurnitureInitialized()
		{
			m_furniture.Initialized -= OnFurnitureInitialized;
			m_furniture = null;
		}

		public override BoxSaveState GetSaveState()
		{
			return new BoxSaveState(m_data.UID, base.IsGrabbed, IsEmpty, base.transform.position, base.transform.rotation);
		}
	}
}
