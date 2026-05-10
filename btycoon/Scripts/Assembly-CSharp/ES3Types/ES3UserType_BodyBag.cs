using CTS;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_BodyBag : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_BodyBag()
			: base(typeof(BodyBag))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			BodyBag bodyBag = (BodyBag)obj;
			writer.WriteProperty("BodyData", bodyBag.BodyData);
			writer.WriteProperty("CurrentChoreType", bodyBag.CurrentChoreType);
			writer.WritePropertyByRef("Holder", bodyBag.CurrentHolder);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			BodyBag bodyBag = (BodyBag)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "BodyData":
					reader.SetPrivateField("BodyData".ToBackingField(), reader.Read<DeadBodyData>(), bodyBag);
					break;
				case "Body":
				{
					Customer customer = reader.Read<Customer>();
					if ((bool)customer)
					{
						reader.SetPrivateField("BodyData".ToBackingField(), new DeadBodyData(customer), bodyBag);
						SaveBodyBags.LinkedCustomers.Add(customer);
					}
					break;
				}
				case "CurrentChoreType":
					reader.SetPrivateField("CurrentChoreType".ToBackingField(), reader.Read<EDeathChore>(), bodyBag);
					break;
				case "Holder":
				{
					Agent agent = reader.Read<Agent>();
					if ((bool)agent)
					{
						agent.ObjectHolding.TryGrabObject(bodyBag);
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
