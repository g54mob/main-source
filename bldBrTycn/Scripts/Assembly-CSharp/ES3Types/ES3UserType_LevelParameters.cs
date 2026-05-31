using CTS.BBT;
using CTS.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "Furnitures", "IsOpen" })]
	public class ES3UserType_LevelParameters : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelParameters()
			: base(typeof(LevelParameters))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			LevelParameters levelParameters = (LevelParameters)obj;
			writer.WritePrivateProperty("IsOpen", levelParameters);
			writer.WriteProperty("Cooldowns", levelParameters.GlobalCooldowns, ES3.ReferenceMode.ByValue);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			LevelParameters levelParameters = (LevelParameters)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "IsOpen"))
				{
					if (property == "Cooldowns")
					{
						reader.ReadInto<CooldownManager>(levelParameters.GlobalCooldowns);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					levelParameters = (LevelParameters)reader.SetPrivateProperty("IsOpen", reader.Read<bool>(), levelParameters);
				}
			}
		}
	}
}
