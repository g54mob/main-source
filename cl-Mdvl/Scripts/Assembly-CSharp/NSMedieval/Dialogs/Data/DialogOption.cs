using System;
using System.Collections.Generic;
using NSMedieval.Serialization;

namespace NSMedieval.Dialogs.Data
{
	[Serializable]
	[FVSerializableKey("DialogOption", "")]
	public class DialogOption : IFVSerializable
	{
		public string Text = "";

		public List<TooltipData> Tooltips = new List<TooltipData>();

		public bool Disabled;

		public string DisabledTooltip = "";

		[NonSerialized]
		public Action OnSelected;

		public DialogOption()
		{
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("text", Text);
			serializer.Write("tooltips", Tooltips);
			serializer.Write("disabled", Disabled);
			serializer.Write("disabledTooltip", DisabledTooltip);
		}

		public DialogOption(FVDeserializer deserializer)
		{
			Text = deserializer.ReadString("text");
			Tooltips = deserializer.ReadObjectList<TooltipData>("tooltips");
			Disabled = deserializer.ReadBool("disabled");
			DisabledTooltip = deserializer.ReadString("disabledTooltip");
		}
	}
}
