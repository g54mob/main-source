using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts.Linkages
{
	public class ControlRodLinkScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _nonRotatingContainer;

		[SerializeField]
		private Transform _rodBottom;

		private Transform _rodBottomAttachment;

		[SerializeField]
		private Transform _rodSleeve;

		[SerializeField]
		private Transform _rodTop;

		protected virtual void OnDestroy()
		{
			if (_rodBottomAttachment != null)
			{
				Object.Destroy(_rodBottomAttachment.gameObject);
			}
		}

		protected virtual void Start()
		{
			_rodBottomAttachment = new GameObject("rodBottom_" + base.name).transform;
			_rodBottomAttachment.parent = _nonRotatingContainer;
			_rodBottomAttachment.SetPositionAndRotation(_rodBottom.position, _rodBottom.rotation);
		}

		protected virtual void Update()
		{
			UpdateSwashplateBase();
		}

		private void UpdateSwashplateBase()
		{
			_rodBottom.position = _rodBottomAttachment.position;
			Vector3 vector = (_rodTop.position - _rodBottom.position) * 0.5f;
			_rodSleeve.position = _rodBottom.position + vector;
			Vector3 vector2 = _rodTop.position - _rodBottom.position;
			Quaternion quaternion = Quaternion.LookRotation(Vector3.Cross(_rodBottom.right, vector2), vector2);
			Transform rodBottom = _rodBottom;
			Transform rodTop = _rodTop;
			Quaternion quaternion2 = (_rodSleeve.rotation = quaternion);
			Quaternion rotation = (rodTop.rotation = quaternion2);
			rodBottom.rotation = rotation;
		}
	}
}
