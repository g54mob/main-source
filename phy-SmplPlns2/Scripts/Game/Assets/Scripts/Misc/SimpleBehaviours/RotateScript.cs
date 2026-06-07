using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours
{
	public class RotateScript : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _axis = Vector3.up;

		[SerializeField]
		private float _speed = 5f;

		protected virtual void Update()
		{
			base.transform.Rotate(_axis * (_speed * Time.deltaTime), Space.Self);
		}
	}
}
