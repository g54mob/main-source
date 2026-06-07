using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public class SyncBool : SyncValue<bool>
	{
		public override float Delta
		{
			get
			{
				if (!base.Value())
				{
					return DeltaWhenOff;
				}
				return DeltaWhenTrue;
			}
		}

		public float DeltaWhenOff { get; set; }

		public float DeltaWhenTrue { get; set; }

		public SyncBool()
		{
			DeltaWhenTrue = 1f;
			DeltaWhenOff = 0f;
		}

		protected override bool SerializeValue(Reader reader)
		{
			return reader.ReadBoolean();
		}

		protected override void SerializeValue(Writer writer, bool value)
		{
			writer.WriteBoolean(value);
		}
	}
}
