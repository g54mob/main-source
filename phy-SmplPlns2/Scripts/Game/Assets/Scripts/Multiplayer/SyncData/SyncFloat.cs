using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public class SyncFloat : SyncValue<float>
	{
		public override float Delta => Mathf.Abs(base.Value() - base.LastValueSent) * DeltaScale;

		public float DeltaScale { get; set; } = 1f;

		protected override float SerializeValue(Reader reader)
		{
			return reader.ReadSingle();
		}

		protected override void SerializeValue(Writer writer, float value)
		{
			writer.WriteSingle(value);
		}
	}
}
