using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_Drink : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Drink()
			: base(typeof(Drink))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Drink drink = (Drink)obj;
			writer.WriteAssetReference("DrinkData", drink.DrinkData);
			if (drink.ClearChore != null && !drink.ClearChore.Destroyed)
			{
				writer.WriteProperty("CleaningChore", drink.ClearChore.CreationTime);
			}
			writer.WritePrivateField("_maxFill", drink);
			writer.WritePrivateField("_fillAmount", drink);
			writer.WriteProperty("Quality", drink.Quality);
			if (drink.Order != null)
			{
				writer.WriteClassRefProperty("CustomerOrder", drink.Order);
			}
			if ((bool)drink.CurrentHolder)
			{
				writer.WritePropertyByRef("Holder", drink.CurrentHolder);
			}
			if (!drink.InSlot)
			{
				return;
			}
			ItemSlot inSlot = drink.InSlot;
			if (!(inSlot is DrinkSlot))
			{
				if (inSlot is PlateSlot)
				{
					writer.WritePropertyByRef("PlateSlot", drink.InSlot);
				}
				else
				{
					writer.WritePropertyByRef("PumpSlot", drink.InSlot);
				}
			}
			else
			{
				writer.WritePropertyByRef("TableSlot", drink.InSlot);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Drink drink = (Drink)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "DrinkData":
					reader.SetPrivateField("DrinkData".ToBackingField(), reader.ReadAssetReference<DrinkSO>(), drink);
					break;
				case "CleaningChore":
					if (drink.ClearChore == null || drink.ClearChore.Destroyed)
					{
						drink.CreateClearingChore();
						reader.SetPrivateField("CreationTime".ToBackingField(), reader.Read<GameTime>(), drink.ClearChore);
					}
					else
					{
						reader.Skip();
					}
					break;
				case "_maxFill":
					reader.SetPrivateField("_maxFill", reader.Read<int>(), drink);
					break;
				case "_fillAmount":
					reader.SetPrivateField("_fillAmount", reader.Read<int>(), drink);
					break;
				case "Quality":
					reader.SetPrivateField("Quality".ToBackingField(), reader.Read<int>(), drink);
					break;
				case "CustomerOrder":
					reader.SetPrivateField("Order".ToBackingField(), reader.ReadClassRef<CustomerOrder>(), drink);
					break;
				case "Holder":
				{
					Agent agent = reader.Read<Agent>();
					if (!drink.CurrentHolder && (bool)agent)
					{
						agent.ObjectHolding.TryGrabObject(drink);
					}
					break;
				}
				case "TableSlot":
				case "PlateSlot":
				case "PumpSlot":
				{
					ItemSlot itemSlot = reader.Read<ItemSlot>();
					if ((bool)itemSlot)
					{
						drink.Place(itemSlot);
					}
					break;
				}
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
