using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.Messages
{
	public class CreateNetworkMagnetJointInfo
	{
		public Vector3 MagnetLocalPosition { get; set; }

		public Vector3 MagnetLocalRotation { get; set; }

		public float Power { get; set; }

		public Vector3 SourceLocalPosition { get; set; }

		public int TargetBodyID { get; set; }

		public Vector3 TargetLocalPosition { get; set; }

		public int TargetOwnerID { get; set; }

		public int TargetPlayerID { get; set; }

		public void SerializeRead(Reader reader)
		{
			MagnetLocalPosition = reader.ReadVector3();
			MagnetLocalRotation = reader.ReadVector3();
			Power = reader.ReadSingle();
			SourceLocalPosition = reader.ReadVector3();
			TargetBodyID = reader.ReadUInt16();
			TargetLocalPosition = reader.ReadVector3();
			TargetOwnerID = reader.ReadUInt16();
			TargetPlayerID = reader.ReadUInt16();
		}

		public void SerializeWrite(Writer writer)
		{
			writer.WriteVector3(MagnetLocalPosition);
			writer.WriteVector3(MagnetLocalRotation);
			writer.WriteSingle(Power);
			writer.WriteVector3(SourceLocalPosition);
			writer.WriteUInt16((ushort)TargetBodyID);
			writer.WriteVector3(TargetLocalPosition);
			writer.WriteUInt16((ushort)TargetOwnerID);
			writer.WriteUInt16((ushort)TargetPlayerID);
		}
	}
}
