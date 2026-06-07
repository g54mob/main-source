using System;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class CameraSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public Vector3 Pos;

		public float Zoom;

		public float Yaw;

		public float Pitch;

		public CameraSaveData(Vector3 pos, float zoom, float yaw, float pitch)
			: base(0)
		{
			Pos = pos;
			Zoom = zoom;
			Yaw = yaw;
			Pitch = pitch;
		}
	}
}
