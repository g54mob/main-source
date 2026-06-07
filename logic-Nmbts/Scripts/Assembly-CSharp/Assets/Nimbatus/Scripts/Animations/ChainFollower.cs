using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class ChainFollower : MonoBehaviour
	{
		public Transform ParentTransform;

		private float _parentDistance;

		public float RotationDelay = 0.5f;

		private void Start()
		{
			_parentDistance = Vector2.Distance(ParentTransform.position, base.transform.position);
			base.transform.parent = null;
		}

		private void LateUpdate()
		{
			Vector3 vector = ParentTransform.position - base.transform.position;
			float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f - 90f;
			Mathf.Clamp(Mathf.DeltaAngle(base.transform.eulerAngles.z, num), 0f, 25f);
			num = Mathf.LerpAngle(base.transform.eulerAngles.z, num, RotationDelay * Time.deltaTime);
			base.transform.eulerAngles = new Vector3(0f, 0f, num);
			vector.Normalize();
			vector *= -1f;
			base.transform.position = ParentTransform.position + vector * _parentDistance;
		}
	}
}
