using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Laser")]
	public class MLaser : MonoBehaviour
	{
		[RequiredField]
		public TrailRenderer trail;

		[RequiredField]
		public Transform StartPoint;

		[RequiredField]
		public Transform EndPoint;

		private void OnEnable()
		{
			trail.AddPosition(StartPoint.position);
			trail.AddPosition(EndPoint.position);
			trail.enabled = true;
			trail.time = float.PositiveInfinity;
			trail.minVertexDistance = float.PositiveInfinity;
		}

		private void OnDisable()
		{
			trail.Clear();
		}

		private void Update()
		{
			trail.SetPosition(0, StartPoint.position);
			trail.SetPosition(1, EndPoint.position);
		}

		private void Reset()
		{
			trail = GetComponent<TrailRenderer>();
			if (trail == null)
			{
				trail = base.gameObject.AddComponent<TrailRenderer>();
			}
			StartPoint = base.transform;
			trail.time = float.PositiveInfinity;
			trail.minVertexDistance = float.PositiveInfinity;
			trail.material = MTools.GetInstance<Material>("ParticleSpark");
			trail.widthMultiplier = 0.1f;
		}
	}
}
