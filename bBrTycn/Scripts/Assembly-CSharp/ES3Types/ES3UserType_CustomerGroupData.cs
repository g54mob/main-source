using System.Collections.Generic;
using System.Linq;
using CTS;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "LeavePoint", "CanEnterBar", "Members", "AssignedTable" })]
	public class ES3UserType_CustomerGroupData : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerGroupData()
			: base(typeof(CustomerGroupData))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CustomerGroupData customerGroupData = (CustomerGroupData)obj;
			List<Customer> list = customerGroupData.Members.ToList();
			for (int num = list.Count - 1; num >= 0; num--)
			{
				if (!SaveCustomers.CanCustomerBeSaved(list[num]))
				{
					list.RemoveAt(num);
				}
			}
			writer.WritePropertyByRef("LeavePoint", customerGroupData.LeavePoint);
			writer.WriteProperty("CanEnterBar", customerGroupData.CanEnterBar, ES3Type_bool.Instance);
			writer.WriteProperty("Members", list, ES3.ReferenceMode.ByRef);
			writer.WritePrivatePropertyByRef("AssignedTable", customerGroupData);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CustomerGroupData customerGroupData = (CustomerGroupData)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "LeavePoint":
					customerGroupData.LeavePoint = reader.Read<MoveTarget>();
					break;
				case "CanEnterBar":
					customerGroupData.CanEnterBar = reader.Read<bool>(ES3Type_bool.Instance);
					break;
				case "Members":
					customerGroupData.Members = reader.Read<List<Customer>>().ToArray();
					break;
				case "AssignedTable":
					reader.SetPrivateProperty("AssignedTable", reader.Read<Table>(), customerGroupData);
					if ((bool)customerGroupData.AssignedTable)
					{
						customerGroupData.AssignedTable.AddGroup(customerGroupData);
					}
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
