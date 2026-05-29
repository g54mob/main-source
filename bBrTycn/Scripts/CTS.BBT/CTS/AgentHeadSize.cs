using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AgentHeadSize : CTSBehaviour
	{
		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private AgentSkeletonData _agent;

		public static float Size { get; set; } = 1f;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			StartCoroutine(WaitAFrame());
		}

		private IEnumerator WaitAFrame()
		{
			yield return null;
			UpdateSize();
		}

		public void UpdateSize()
		{
			if (_agent.TryGetBone(EBone.Head, out var boneTransform))
			{
				boneTransform.localScale = Vector3.one * Size;
			}
		}
	}
}
