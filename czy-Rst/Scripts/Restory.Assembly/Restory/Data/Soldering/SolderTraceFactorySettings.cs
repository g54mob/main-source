using UnityEngine;

namespace Restory.Data.Soldering
{
	[CreateAssetMenu(fileName = "SolderTraceFactorySettings", menuName = "Restory/Soldering/SolderTraceFactorySettings")]
	public class SolderTraceFactorySettings : ScriptableObject
	{
		[SerializeField]
		private Material solderMaterial;

		[SerializeField]
		[Min(0.0001f)]
		private float traceWidth = 0.004f;

		[SerializeField]
		[Min(3f)]
		private int circleSegments = 8;

		public Material SolderMaterial => solderMaterial;

		public float TraceWidth => traceWidth;

		public int CircleSegments => circleSegments;
	}
}
