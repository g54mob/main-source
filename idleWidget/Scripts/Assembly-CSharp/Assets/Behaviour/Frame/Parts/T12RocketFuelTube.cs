using System.Collections;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12RocketFuelTube : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _sprite;

		[SerializeField]
		private float _minDistance;

		[SerializeField]
		private float _maxDistance;

		private bool _active;

		public bool Done { get; private set; }

		private void OnEnable()
		{
			_active = true;
		}

		private void OnMouseDrag()
		{
			if (_active)
			{
				float num = Mathf.Clamp(((Vector3)PlayerControls.MouseWorld - base.transform.parent.position).x, _minDistance, _maxDistance);
				_sprite.size = new Vector2(_maxDistance - num + 1f, _sprite.size.y);
				base.transform.localPosition = new Vector3(num, base.transform.localPosition.y, base.transform.localPosition.z);
				bool flag = num == _minDistance;
				if (flag && !Done)
				{
					UISounds.CraftStep();
				}
				Done = flag;
			}
		}

		public void Reset(float delay)
		{
			StartCoroutine(_resetTube(delay));
		}

		private IEnumerator _resetTube(float delay)
		{
			Done = false;
			_active = false;
			yield return new WaitForSeconds(delay);
			float time = 0f;
			while (time < 1f)
			{
				time += Time.deltaTime;
				float num = Mathf.SmoothStep(_minDistance, _maxDistance, time);
				_sprite.size = new Vector2(_maxDistance - num + 1f, _sprite.size.y);
				base.transform.localPosition = new Vector3(num, base.transform.localPosition.y, base.transform.localPosition.z);
				yield return null;
			}
			_active = true;
		}
	}
}
