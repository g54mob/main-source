using System.Collections;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9SuperconductorTube : MonoBehaviour
	{
		[SerializeField]
		private float _minDistance;

		[SerializeField]
		private float _maxDistance;

		[SerializeField]
		private bool _xAxis;

		private bool _active;

		private bool _resetting;

		public bool Done { get; private set; }

		private void OnEnable()
		{
			_active = true;
			if (_resetting)
			{
				base.transform.localPosition = new Vector3(0f, _maxDistance, 0.5f);
				_resetting = false;
			}
		}

		private void OnMouseDrag()
		{
			if (_active)
			{
				Vector3 vector = PlayerControls.MouseWorld;
				vector -= base.transform.parent.position;
				float num = ((!_xAxis) ? Mathf.Clamp(vector.y, _minDistance, _maxDistance) : Mathf.Clamp(vector.x * -1f, _minDistance, _maxDistance));
				base.transform.localPosition = new Vector3(0f, num, 0.5f);
				bool flag = num == _minDistance;
				if (flag && !Done)
				{
					UISounds.CraftStep();
				}
				Done = flag;
			}
		}

		public void Reset()
		{
			StartCoroutine(_resetTube());
		}

		private IEnumerator _resetTube()
		{
			_resetting = true;
			Done = false;
			_active = false;
			yield return new WaitForSeconds(1.5f);
			float time = 0f;
			while (time < 1f)
			{
				time += Time.deltaTime;
				float y = Mathf.SmoothStep(_minDistance, _maxDistance, time);
				base.transform.localPosition = new Vector3(0f, y, 0.5f);
				yield return null;
			}
			_active = true;
			_resetting = false;
		}
	}
}
