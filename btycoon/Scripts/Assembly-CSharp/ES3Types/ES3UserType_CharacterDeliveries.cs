using System.Collections.Generic;
using CTS;
using CTS.Core;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_CharacterDeliveries : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CharacterDeliveries()
			: base(typeof(CharacterDeliveries))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			CharacterDeliveries objectContainingField = (CharacterDeliveries)obj;
			writer.WritePrivateField("_currentMissions", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			CharacterDeliveries characterDeliveries = (CharacterDeliveries)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "_currentMissions")
				{
					characterDeliveries.SetCurrentMission(reader.Read<Dictionary<MissionBasket, StringKey<MainCharacterData>>>());
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
