using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[HelpURL("https://ferdowsur.gitbook.io/layout-system/layout-group/linear-layout-group")]
	[AddComponentMenu("Tiny Giant Studio/Layout/Linear Layout Group (M3D)", 30003)]
	public class LinearLayoutGroup : LayoutGroup
	{
		public enum Alignment
		{
			Top = 0,
			VerticleMiddle = 1,
			Bottom = 2,
			Left = 3,
			HorizontalMiddle = 4,
			Right = 5
		}

		public float spacing;

		public Alignment alignment;

		public Alignment secondaryAlignment;

		private bool startLoopFromEnd;

		public bool randomizeRotations;

		[SerializeField]
		private Vector3 _minimumRandomRotation;

		public Vector3 maximumRandomRotation;

		public bool rotationChanged;

		public Vector3 MinimumRandomRotation
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public override void UpdateLayout(int startRepositioningFrom = 0)
		{
		}

		public override List<MeshLayout> GetPositions(List<MeshLayout> meshLayouts)
		{
			return null;
		}

		private MeshLayout SetMeshPosition(ref float x, ref float y, Bounds bound, MeshLayout meshLayout)
		{
			return null;
		}

		private void SetChildPosition(ref float x, ref float y, int i, Bounds bound, int startRepositioningFrom)
		{
		}

		private void SetLocalPosition(Transform target, Vector3 targetPosition)
		{
		}

		private Vector3 GetRandomRotation(Vector3 min, Vector3 max)
		{
			return default(Vector3);
		}

		private Quaternion GetRandomQuaternionRotation(Vector3 min, Vector3 max)
		{
			return default(Quaternion);
		}

		private void GetStartingPosition(ref float x, ref float y, Bounds[] bounds)
		{
		}

		private float MaxBoundHeight(Bounds[] allBounds)
		{
			return 0f;
		}

		private bool StartLoopFromEnd()
		{
			return false;
		}
	}
}
