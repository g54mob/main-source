using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.SyncData
{
	public class SyncVector : SyncValue<Vector3>
	{
		public override float Delta => (base.Value() - base.LastValueSent).sqrMagnitude;

		protected override Vector3 SerializeValue(Reader reader)
		{
			return reader.ReadVector3();
		}

		protected override void SerializeValue(Writer writer, Vector3 value)
		{
			writer.WriteVector3(value);
		}
	}
}
