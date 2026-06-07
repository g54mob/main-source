using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	public class ControlRodLinkScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _connectedAnchor;

		private float _initialRodLength;

		private Vector3 _initialRodWorldScale;

		[SerializeField]
		private Transform _rodBottom;

		private Transform _rodBottomAttachment;

		[SerializeField]
		private Transform _rodSleeve;

		[SerializeField]
		private Transform _rodTop;

		private Vector3 _rodTopInitialScale;

		public Transform RodBottom => _rodBottom;

		public void UpdateControlRod()
		{
			_rodBottom.position = _rodBottomAttachment.position;
			Vector3 vector = _rodTop.position - _rodBottom.position;
			float magnitude = vector.magnitude;
			float num = base.transform.lossyScale.z / _initialRodWorldScale.z;
			float num2 = magnitude / _initialRodLength;
			num2 /= num;
			_rodTop.localScale = new Vector3(_rodTopInitialScale.x, _rodTopInitialScale.y, _rodTopInitialScale.z * num2);
			Vector3 vector2 = _rodBottom.position - _rodTop.position;
			Vector3 upwards = Vector3.Cross(_rodBottomAttachment.right, vector2);
			Quaternion quaternion = Quaternion.LookRotation(vector2, upwards);
			if (_rodSleeve != null)
			{
				Vector3 vector3 = vector * 0.5f;
				_rodSleeve.position = _rodBottom.position + vector3;
				Transform rodBottom = _rodBottom;
				Transform rodTop = _rodTop;
				Quaternion quaternion2 = (_rodSleeve.rotation = quaternion);
				Quaternion rotation = (rodTop.rotation = quaternion2);
				rodBottom.rotation = rotation;
			}
			else
			{
				Transform rodBottom2 = _rodBottom;
				Quaternion rotation = (_rodTop.rotation = quaternion);
				rodBottom2.rotation = rotation;
			}
		}

		private void Awake()
		{
			_rodBottomAttachment = new GameObject("rodBottom_" + base.name).transform;
			_rodBottomAttachment.parent = _connectedAnchor;
			_rodBottomAttachment.SetPositionAndRotation(_rodBottom.position, _rodBottom.rotation);
			_initialRodLength = (_rodTop.position - _rodBottom.position).magnitude;
			_initialRodWorldScale = base.transform.lossyScale;
			_rodTopInitialScale = _rodTop.localScale;
		}

		private void OnDestroy()
		{
			if (_rodBottomAttachment != null)
			{
				Object.Destroy(_rodBottomAttachment.gameObject);
			}
		}
	}
}
