using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "isOpen", "attachedModule" })]
	public class ES3UserType_ModuleSlot : ES3ObjectType
	{
		public static ES3Type Instance;

		public ES3UserType_ModuleSlot()
			: base(typeof(ModuleSlot))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			ModuleSlot moduleSlot = (ModuleSlot)obj;
			writer.WriteProperty("isOpen", moduleSlot.isOpen, ES3Type_bool.Instance);
			writer.WritePropertyByRef("attachedModule", moduleSlot.attachedModule);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			ModuleSlot moduleSlot = (ModuleSlot)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "isOpen"))
				{
					if (property == "attachedModule")
					{
						moduleSlot.attachedModule = reader.Read<Chips>();
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					moduleSlot.isOpen = reader.Read<bool>(ES3Type_bool.Instance);
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			ModuleSlot moduleSlot = new ModuleSlot();
			ReadObject<T>(reader, moduleSlot);
			return moduleSlot;
		}
	}
}
