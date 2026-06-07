using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[RequireComponent(typeof(LineRenderer))]
	public class LineRendererUtility : MonoBehaviour
	{
		public Transform target;

		private LineRenderer lineRenderer;

		private void Awake()
		{
			lineRenderer = GetComponent<LineRenderer>();
		}

		private void Update()
		{
			if (!(target == null))
			{
				lineRenderer.positionCount = 2;
				lineRenderer.SetPositions(new Vector3[2]
				{
					base.transform.position,
					target.position
				});
			}
		}
	}
}
