using UnityEngine;

namespace Simulator.GameWorld
{
	public class FurnitureShopBoxData : BaseShopBoxData
	{
		[SerializeField]
		protected FurniturePicker m_furniture;

		[SerializeField]
		private string m_var1;

		[SerializeField]
		private string m_var2;

		[SerializeField]
		private string m_var3;

		public Furniture Furniture => m_furniture.Get();

		public override void RegisterLocaVars()
		{
			if (!string.IsNullOrWhiteSpace(m_var1))
			{
				LocaVariableDatabase.SetVariableValue(base.name + "_Var1", m_var1);
			}
			if (!string.IsNullOrWhiteSpace(m_var2))
			{
				LocaVariableDatabase.SetVariableValue(base.name + "_Var2", m_var2);
			}
			if (!string.IsNullOrWhiteSpace(m_var3))
			{
				LocaVariableDatabase.SetVariableValue(base.name + "_Var3", m_var3);
			}
		}
	}
}
