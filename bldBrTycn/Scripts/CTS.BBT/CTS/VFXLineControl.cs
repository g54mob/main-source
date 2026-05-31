using CTS.Core;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(LineRenderer))]
	public class VFXLineControl : MonoBehaviour, IReceive<Transform>
	{
		private LineRenderer _lineRenderer;

		[SerializeField]
		private Vector3 FollowOffset;

		[SerializeField]
		private ShaderControl[] _shaderLengthParams;

		private MaterialPropertyBlock _propertyBlock;

		[field: SerializeField]
		public Transform Target { get; set; }

		private void Awake()
		{
			_lineRenderer = GetComponent<LineRenderer>();
			_propertyBlock = new MaterialPropertyBlock();
		}

		private void LateUpdate()
		{
			if ((bool)Target)
			{
				Vector3 vector = (_lineRenderer.useWorldSpace ? base.transform.position : Vector3.zero);
				Vector3 vector2 = Target.position + FollowOffset;
				if (!_lineRenderer.useWorldSpace)
				{
					vector2 = _lineRenderer.transform.InverseTransformPoint(vector2);
				}
				_lineRenderer.SetPosition(0, vector);
				_lineRenderer.SetPosition(1, vector2);
				float num = Vector3.Distance(vector2, vector);
				_lineRenderer.GetPropertyBlock(_propertyBlock);
				ShaderControl[] shaderLengthParams = _shaderLengthParams;
				for (int i = 0; i < shaderLengthParams.Length; i++)
				{
					ShaderControl shaderControl = shaderLengthParams[i];
					_propertyBlock.SetFloat(shaderControl.Name, (num + shaderControl.AddValue) * shaderControl.MultiplyValue);
				}
				_lineRenderer.SetPropertyBlock(_propertyBlock);
			}
		}

		public void OnReceive(Transform obj)
		{
			Target = obj;
		}
	}
}
