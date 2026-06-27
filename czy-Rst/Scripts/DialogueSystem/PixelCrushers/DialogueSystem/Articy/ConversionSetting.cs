using System;

namespace PixelCrushers.DialogueSystem.Articy
{
	[Serializable]
	public class ConversionSetting
	{
		public string Id { get; set; }

		public bool Include { get; set; }

		public EntityCategory Category { get; set; }

		public ConversionSetting()
		{
			Assign(null);
		}

		public ConversionSetting(string id)
		{
			Assign(id);
		}

		private void Assign(string id)
		{
			Id = id;
			Include = !string.IsNullOrEmpty(id);
			Category = EntityCategory.NPC;
		}
	}
}
