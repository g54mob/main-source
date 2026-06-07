using UnityEngine;
using UnityEngine.Events;

namespace Assets.Behaviour.Frame.Parts
{
	public class SecretButtonSlider : MonoBehaviour
	{
		[SerializeField]
		protected float _min;

		[SerializeField]
		protected float _max;

		[SerializeField]
		protected bool _xAxis;

		[SerializeField]
		private UnityEvent _onFull;

		[SerializeField]
		private UnityEvent _onEmpty;

		protected float _current;

		private bool _mouseDown;

		private float _timeout;

		private bool _minTriggered;

		private bool _maxTriggered;

		public float Progress => (_current - _min) / (_max - _min);

		private void Awake()
		{
			if (_xAxis)
			{
				_current = base.transform.localPosition.x;
			}
			else
			{
				_current = base.transform.localPosition.y;
			}
		}

		private void OnDisable()
		{
			_mouseDown = false;
		}

		private void Update()
		{
			if (PlayerControls.InteractRelease && _mouseDown)
			{
				UISounds.Button();
				_mouseDown = false;
			}
			if (_timeout > 0f)
			{
				_timeout -= Time.deltaTime;
			}
			if (_xAxis)
			{
				if (_mouseDown)
				{
					_current = Mathf.Clamp(PlayerControls.MouseWorld.x - base.transform.parent.position.x, _min, _max);
				}
				base.transform.localPosition = new Vector3(_current, base.transform.localPosition.y, base.transform.localPosition.z);
			}
			else
			{
				if (_mouseDown)
				{
					_current = Mathf.Clamp(PlayerControls.MouseWorld.y - base.transform.parent.position.y, _min, _max);
				}
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, _current, base.transform.localPosition.z);
			}
			if (_current == _max && !_maxTriggered)
			{
				_onFull.Invoke();
				_maxTriggered = true;
			}
			else if (_current == _min && !_minTriggered)
			{
				_onEmpty.Invoke();
				_minTriggered = true;
			}
		}

		private void OnMouseDown()
		{
			if (_timeout <= 0f)
			{
				_mouseDown = true;
				UISounds.Button();
			}
		}
	}
}
