using UnityEngine;

namespace MicahW.PointGrass
{
	public class PointGrassDisplacer : MonoBehaviour
	{
		public Vector3 localPosition = Vector3.zero;

		public float radius = 0.5f;

		public float strength = 1f;

		private void Reset()
		{
			localPosition = Vector3.zero;
			radius = 0.5f;
			strength = 1f;
		}

		private void OnEnable()
		{
			if (PointGrassDisplacementManager.instance != null)
			{
				PointGrassDisplacementManager.instance.AddDisplacer(this);
			}
			else
			{
				PointGrassDisplacementManager.OnInitialize += Initialize;
			}
		}

		private void OnDisable()
		{
			if (PointGrassDisplacementManager.instance != null)
			{
				PointGrassDisplacementManager.instance.RemoveDisplacer(this);
			}
		}

		private void Initialize(PointGrassDisplacementManager manager)
		{
			manager.AddDisplacer(this);
			PointGrassDisplacementManager.OnInitialize -= Initialize;
		}

		public PointGrassCommon.ObjectData GetObjectData()
		{
			return new PointGrassCommon.ObjectData(base.transform.TransformPoint(localPosition), radius, strength);
		}
	}
}
