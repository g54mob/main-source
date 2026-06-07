using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Dirt : MonoBehaviour, IDisposable
	{
		public DirtData.EType Type => DirtData.DirtType;

		public DirtData DirtData { get; private set; }

		protected virtual void Initialize(DirtData data, int meshIndex = -1)
		{
			DirtData = data;
		}

		public static Dirt Create(DirtData data)
		{
			Dirt dirt = UnityEngine.Object.Instantiate(data.Prefab);
			dirt.Initialize(data);
			return dirt;
		}

		public void Spawn(DirtData data, Vector3 position, Vector3 rotation, int meshIndex = -1)
		{
			base.transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
			Initialize(data, meshIndex);
			World.DirtManager.Register(this);
		}

		public virtual void Save()
		{
			SaveManager.CurrentSave.dirt.AddDirtData(new SaveClass_Dirt.SaveDirtData(DirtData, base.transform.position, base.transform.eulerAngles));
		}

		public virtual void Dispose()
		{
		}
	}
}
