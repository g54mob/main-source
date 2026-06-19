using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InWorldHUDElement : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _clipRect;

		[SerializeField]
		private float _depthBias;

		public bool CanBeHidden;

		public Vector3 Position { get; set; }

		public RectTransform ClipRect => _clipRect;

		public float DepthBias
		{
			set
			{
				_depthBias = value;
			}
		}

		public float Depth(Vector3 cameraPosition)
		{
			return 0f - (Position - cameraPosition).magnitude + _depthBias;
		}
	}
}
