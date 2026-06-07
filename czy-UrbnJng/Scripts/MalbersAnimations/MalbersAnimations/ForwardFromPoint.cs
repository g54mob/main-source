using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Forward from Point")]
	public class ForwardFromPoint : MonoBehaviour
	{
		[Header("Use Point to Aim at it using Transform.forward")]
		public TransformReference Point;

		private void OnEnable()
		{
			if (Point.Value == null)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			base.transform.forward = (Point.position - base.transform.position).normalized;
		}
	}
}
