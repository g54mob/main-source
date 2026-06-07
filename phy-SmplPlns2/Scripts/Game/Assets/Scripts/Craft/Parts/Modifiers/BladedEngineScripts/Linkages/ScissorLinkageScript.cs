using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Linkages
{
	public class ScissorLinkageScript : MonoBehaviour
	{
		private bool _firstFrame = true;

		[SerializeField]
		private Transform _midpoint;

		[SerializeField]
		private Transform _nonRotatingContainer;

		private float _scissorArmLength;

		[SerializeField]
		private Transform _scissorBottom;

		private Transform _scissorBottomAttachment;

		[SerializeField]
		private Transform _scissorTop;

		[SerializeField]
		private Transform _scissorTopConnector;

		protected virtual void LateUpdate()
		{
			if (_firstFrame)
			{
				_firstFrame = false;
				_scissorArmLength = (_scissorTop.position - _scissorTopConnector.position).magnitude;
			}
		}

		protected virtual void Start()
		{
			_scissorBottomAttachment = new GameObject("scissorBottom_" + base.name).transform;
			_scissorBottomAttachment.parent = _nonRotatingContainer;
			_scissorBottomAttachment.SetPositionAndRotation(_scissorBottom.transform.position, _scissorBottom.transform.rotation);
			_scissorArmLength = (_scissorTop.position - _scissorTopConnector.position).magnitude;
		}

		protected virtual void Update()
		{
			_scissorBottom.position = _scissorBottomAttachment.position;
			Vector3 vector = (_scissorTop.position - _scissorBottom.position) * 0.5f;
			float scissorArmLength = _scissorArmLength;
			float magnitude = vector.magnitude;
			float num = scissorArmLength * scissorArmLength - magnitude * magnitude;
			float num2 = ((num > 0f) ? Mathf.Sqrt(num) : 0f);
			_midpoint.position = _scissorBottom.position + vector + _scissorBottomAttachment.up * num2;
			Vector3 vector2 = _midpoint.position - _scissorBottom.position;
			Quaternion rotation = Quaternion.LookRotation(Vector3.Cross(vector2, base.transform.right), vector2);
			_scissorBottom.rotation = rotation;
			vector2 = _midpoint.position - _scissorTop.position;
			rotation = Quaternion.LookRotation(Vector3.Cross(base.transform.right, vector2), vector2);
			_scissorTop.rotation = rotation;
		}
	}
}
