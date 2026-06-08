using System;
using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.Entities.Serialization;

namespace Kitchen
{
	[DisableAutoCreation]
	public class WorldSerializer : SystemBase
	{
		protected unsafe override void OnUpdate()
		{
			using (MemoryBinaryWriter memoryBinaryWriter = new MemoryBinaryWriter())
			{
				SerializeUtility.SerializeWorld(base.World.EntityManager, memoryBinaryWriter);
				byte[] destination = new byte[memoryBinaryWriter.Length];
				Marshal.Copy((IntPtr)memoryBinaryWriter.Data, destination, 0, memoryBinaryWriter.Length);
			}
			base.EntityManager.DestroyAndResetAllEntities();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
