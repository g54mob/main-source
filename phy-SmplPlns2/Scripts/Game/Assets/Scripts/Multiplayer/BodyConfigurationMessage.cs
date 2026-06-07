using System.Collections.Generic;
using FishNet.Serializing;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class BodyConfigurationMessage
	{
		public class BodyInfo
		{
			public int Id { get; set; }

			public List<PartGroupInfo> PartGroups { get; private set; } = new List<PartGroupInfo>();
		}

		public class BodyIslandInfo
		{
			public class SubBodyInfo
			{
				public int Id { get; set; }

				public int ParentId { get; set; }

				public SubBodyInfo(int id, int parentId)
				{
					Id = id;
					ParentId = parentId;
				}
			}

			public List<SubBodyInfo> Bodies { get; private set; } = new List<SubBodyInfo>();

			public bool IsDebris { get; set; }

			public int RootId { get; set; }
		}

		public class PartGroupInfo
		{
			public int Id { get; set; }

			public Vector3 LocalPosition { get; set; }

			public Vector3 LocalRotation { get; set; }
		}

		private static class Profile
		{
			public static readonly ProfilerMarker SerializeRead = new ProfilerMarker("BodyConfigurationMessage.SerializeRead");

			public static readonly ProfilerMarker SerializeWrite = new ProfilerMarker("BodyConfigurationMessage.SerializeWrite");
		}

		public List<BodyIslandInfo> BodyIslands { get; private set; } = new List<BodyIslandInfo>();

		public List<int> DeadBodies { get; private set; } = new List<int>();

		public List<BodyInfo> NewBodies { get; private set; } = new List<BodyInfo>();

		public int State { get; set; }

		public void SerializeRead(Reader reader)
		{
			using (Profile.SerializeRead.Auto())
			{
				State = reader.ReadInt32();
				int num = reader.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					DeadBodies.Add(reader.ReadInt32());
				}
				int num2 = reader.ReadInt32();
				for (int j = 0; j < num2; j++)
				{
					BodyInfo bodyInfo = new BodyInfo();
					NewBodies.Add(bodyInfo);
					bodyInfo.Id = reader.ReadInt32();
					int num3 = reader.ReadInt32();
					for (int k = 0; k < num3; k++)
					{
						PartGroupInfo partGroupInfo = new PartGroupInfo();
						bodyInfo.PartGroups.Add(partGroupInfo);
						partGroupInfo.Id = reader.ReadInt32();
						partGroupInfo.LocalPosition = reader.ReadVector3();
						partGroupInfo.LocalRotation = reader.ReadVector3();
					}
				}
				int num4 = reader.ReadInt32();
				for (int l = 0; l < num4; l++)
				{
					BodyIslandInfo bodyIslandInfo = new BodyIslandInfo();
					BodyIslands.Add(bodyIslandInfo);
					bodyIslandInfo.RootId = reader.ReadInt32();
					bodyIslandInfo.IsDebris = reader.ReadBoolean();
					int num5 = reader.ReadInt32();
					for (int m = 0; m < num5; m++)
					{
						int id = reader.ReadInt32();
						int parentId = reader.ReadInt32();
						bodyIslandInfo.Bodies.Add(new BodyIslandInfo.SubBodyInfo(id, parentId));
					}
				}
			}
		}

		public void SerializeWrite(Writer writer)
		{
			using (Profile.SerializeWrite.Auto())
			{
				writer.WriteInt32(State);
				writer.WriteInt32(DeadBodies.Count);
				foreach (int deadBody in DeadBodies)
				{
					writer.WriteInt32(deadBody);
				}
				writer.WriteInt32(NewBodies.Count);
				foreach (BodyInfo newBody in NewBodies)
				{
					writer.WriteInt32(newBody.Id);
					writer.WriteInt32(newBody.PartGroups.Count);
					foreach (PartGroupInfo partGroup in newBody.PartGroups)
					{
						writer.WriteInt32(partGroup.Id);
						writer.WriteVector3(partGroup.LocalPosition);
						writer.WriteVector3(partGroup.LocalRotation);
					}
				}
				writer.WriteInt32(BodyIslands.Count);
				foreach (BodyIslandInfo bodyIsland in BodyIslands)
				{
					writer.WriteInt32(bodyIsland.RootId);
					writer.WriteBoolean(bodyIsland.IsDebris);
					writer.WriteInt32(bodyIsland.Bodies.Count);
					foreach (BodyIslandInfo.SubBodyInfo body in bodyIsland.Bodies)
					{
						writer.WriteInt32(body.Id);
						writer.WriteInt32(body.ParentId);
					}
				}
			}
		}
	}
}
