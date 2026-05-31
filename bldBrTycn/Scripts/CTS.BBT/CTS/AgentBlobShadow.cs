using System;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CTS
{
	public class AgentBlobShadow : CTSBehaviour
	{
		[SerializeField]
		private float _heightFade = 1f;

		[Inject(false)]
		private DecalProjector _decalProjector;

		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private AgentSkeletonData _agentSkeleton;

		private void LateUpdate()
		{
			if ((bool)_agentSkeleton && _agentSkeleton.TryGetBone(EBone.LeftFoot, out var boneTransform) && _agentSkeleton.TryGetBone(EBone.RightFoot, out var boneTransform2))
			{
				Transform parent = base.transform.parent;
				Vector3 vector = parent.InverseTransformPoint(boneTransform.position);
				Vector3 vector2 = parent.InverseTransformPoint(boneTransform2.position);
				float val = Math.Abs(vector.y) * _heightFade;
				float val2 = Math.Abs(vector2.y) * _heightFade;
				float num = Math.Min(val, val2);
				Vector2 vector3 = vector.ToHorizontal2D();
				Vector2 vector4 = vector2.ToHorizontal2D();
				float num2 = Vector2.Distance(vector3, vector4);
				float z = Vector2.SignedAngle(Vector2.right, (vector4 - vector3).normalized);
				_decalProjector.size = _decalProjector.size.SetX(num2 + 0.75f);
				Vector3 localPosition = Vector2.Lerp(vector3, vector4, 0.5f).ToHorizontal3D();
				base.transform.localPosition = localPosition;
				base.transform.localEulerAngles = new Vector3(90f, 0f, z);
				_decalProjector.fadeFactor = Mathf.Clamp01(1f - num);
			}
		}
	}
}
