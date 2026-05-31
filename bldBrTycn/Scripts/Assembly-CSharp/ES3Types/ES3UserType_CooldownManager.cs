using System.Collections.Generic;
using CTS.Core;
using CTS.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_CooldownManager : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CooldownManager()
			: base(typeof(CooldownManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CooldownManager objectContainingField = (CooldownManager)obj;
			writer.WritePrivateField("_cooldownDictionary", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CooldownManager cooldownManager = (CooldownManager)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_cooldownDictionary")
				{
					reader.SetPrivateField("_cooldownDictionary", reader.Read<Dictionary<StringKey, CooldownManager.Cooldown>>(), cooldownManager);
				}
				else
				{
					reader.Skip();
				}
			}
			cooldownManager.SendEvents();
		}
	}
}
