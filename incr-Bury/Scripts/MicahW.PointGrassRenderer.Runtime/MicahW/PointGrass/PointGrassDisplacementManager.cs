using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MicahW.PointGrass
{
	public class PointGrassDisplacementManager : MonoBehaviour
	{
		public delegate void DisplacementDelegate(PointGrassDisplacementManager manager);

		public static PointGrassDisplacementManager instance;

		private ComputeBuffer objectsBuffer;

		private List<PointGrassDisplacer> displacers;

		private static readonly int maxDisplacerCount = 32;

		private int DisplacerCount => Mathf.Min(displacers.Count, maxDisplacerCount);

		public static event DisplacementDelegate OnInitialize;

		private void Awake()
		{
			if (instance != null)
			{
				Object.Destroy(this);
				return;
			}
			instance = this;
			objectsBuffer = new ComputeBuffer(maxDisplacerCount, 20);
			displacers = new List<PointGrassDisplacer>();
			PointGrassDisplacementManager.OnInitialize?.Invoke(this);
		}

		private void OnDisable()
		{
			if (instance == this)
			{
				instance = null;
				objectsBuffer.Release();
				displacers.Clear();
			}
		}

		private void LateUpdate()
		{
			UpdateBuffer();
		}

		private void UpdateBuffer()
		{
			PointGrassCommon.ObjectData[] data = displacers.Select((PointGrassDisplacer a) => a.GetObjectData()).ToArray();
			objectsBuffer.SetData(data, 0, 0, DisplacerCount);
		}

		public void AddDisplacer(PointGrassDisplacer displacer)
		{
			displacers.Add(displacer);
		}

		public void RemoveDisplacer(PointGrassDisplacer displacer)
		{
			displacers.Remove(displacer);
		}

		public void UpdatePropertyBlock(ref MaterialPropertyBlock block)
		{
			block.SetBuffer(PointGrassCommon.ID_ObjBuff, objectsBuffer);
			block.SetInt(PointGrassCommon.ID_ObjCount, DisplacerCount);
		}
	}
}
