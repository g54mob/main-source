using System.Collections.Generic;
using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_Customer : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_Customer()
			: base(typeof(Customer))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			Customer customer = (Customer)obj;
			writer.WritePrivateFieldByRef("<GroupData>k__BackingField", customer);
			writer.WritePrivateField("<GroupIndex>k__BackingField", customer);
			if ((bool)customer.AssignedSeat)
			{
				writer.WritePropertyByRef("AssignedSeat", customer.AssignedSeat);
			}
			if (customer.CurrentOrder != null)
			{
				writer.WriteClassRefProperty("CurrentOrder", (customer.CurrentOrder == null || customer.CurrentOrder.IsDestroyed) ? null : customer.CurrentOrder);
			}
			writer.WritePrivateField("<Money>k__BackingField", customer);
			writer.WritePrivateField("<agentName>k__BackingField", customer);
			writer.WritePrivateField("<agentFirstName>k__BackingField", customer);
			writer.WriteAssetReference("Parameters", customer.SpawnParameters);
			if ((bool)customer.ControllingVampire)
			{
				writer.WriteProperty("ControllingVampire", customer.ControllingVampire, ES3.ReferenceMode.ByRef);
			}
			writer.WritePrivateProperty("BloodQuality", customer);
			writer.WriteProperty("Tags", customer.Tags, ES3UserType_AgentTags.Instance);
			writer.WriteProperty("Skin", customer.Skin, ES3TypeMgr.GetOrCreateES3Type(typeof(CharacterData)));
			writer.WriteProperty("IsActive", customer.ContextualFSM.enabled);
			writer.WriteProperty("IsVisualActive", customer.AgentVisual.activeSelf);
			writer.WriteProperty("CurrentDrinkCount", customer.CurrentDrinks);
			if (customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
			{
				writer.WriteProperty("Panicking", true);
			}
			List<StringKey> list = customer.GetTags().FilterNotSave();
			if (list.Count > 0)
			{
				writer.WriteProperty("ObjectTags", list);
			}
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			Customer customer = (Customer)obj;
			SaveCustomers.SaveData saveData = SaveCustomers.Get(customer);
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "<GroupData>k__BackingField":
					customer = (Customer)reader.SetPrivateField("<GroupData>k__BackingField", reader.Read<CustomerGroupData>(), customer);
					break;
				case "<GroupIndex>k__BackingField":
					customer = (Customer)reader.SetPrivateField("<GroupIndex>k__BackingField", reader.Read<int>(), customer);
					break;
				case "AssignedSeat":
				{
					Seat seat = reader.Read<Seat>();
					if ((bool)seat)
					{
						reader.SetPrivateField("AssignedSeat".ToBackingField(), seat, customer);
						seat.StartUsing(customer);
					}
					break;
				}
				case "CurrentOrder":
					customer.CurrentOrder = reader.ReadClassRef<CustomerOrder>();
					break;
				case "<Money>k__BackingField":
					customer = (Customer)reader.SetPrivateField("<Money>k__BackingField", reader.Read<int>(), customer);
					break;
				case "<agentName>k__BackingField":
					customer = (Customer)reader.SetPrivateField("<agentName>k__BackingField", reader.Read<string>(), customer);
					break;
				case "<agentFirstName>k__BackingField":
					customer = (Customer)reader.SetPrivateField("<agentFirstName>k__BackingField", reader.Read<string>(), customer);
					break;
				case "Parameters":
					customer.SpawnParameters = reader.ReadAssetReference<CustomerParameters>();
					break;
				case "ControllingVampire":
				{
					Worker worker = reader.Read<Worker>();
					if ((bool)worker)
					{
						customer.SetControllingVampire(worker);
					}
					break;
				}
				case "BloodQuality":
					customer = (Customer)reader.SetPrivateProperty("BloodQuality", reader.Read<int>(), customer);
					break;
				case "Tags":
					customer.Tags = reader.Read<AgentTags>(ES3UserType_AgentTags.Instance);
					break;
				case "ObjectTags":
					customer.RemoveAllTags();
					customer.AddTags(reader.Read<List<StringKey>>());
					break;
				case "Skin":
					customer.Skin = reader.Read<CharacterData>();
					break;
				case "IsActive":
					customer.SetActive(reader.Read<bool>());
					break;
				case "IsVisualActive":
					customer.SetVisualActive(reader.Read<bool>());
					break;
				case "_panicCooldown":
					customer.Cooldowns.StartCooldown(BBTAgentTags.StartedPanicking, reader.Read<float>());
					break;
				case "CurrentDrinkCount":
					reader.SetPrivateField("CurrentDrinks".ToBackingField(), reader.Read<int>(), customer);
					break;
				case "Panicking":
					if (!customer.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>())
					{
						customer.ContextualFSM.SetStatePanicking();
					}
					reader.Skip();
					break;
				default:
					reader.Skip();
					break;
				}
			}
			if (customer.IsVampire)
			{
				customer.Movement.OverrideDefaultArea(customer.VampireAreaMask);
			}
			SaveCustomers.Set(customer, saveData);
		}
	}
}
