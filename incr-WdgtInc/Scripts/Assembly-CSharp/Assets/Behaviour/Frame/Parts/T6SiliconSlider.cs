using Assets.Source.World;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Behaviour.Frame.Parts
{
	public class T6SiliconSlider : MonoBehaviour
	{
		[SerializeField]
		protected float _minX;

		[SerializeField]
		protected float _maxX;

		[SerializeField]
		private float _decayRate;

		[SerializeField]
		private UnityEvent _onFull;

		protected float _currentX;

		private bool _mouseDown;

		private float _timeout;

		public float Progress => (_currentX - _minX) / (_maxX - _minX);

		private void Awake()
		{
			_currentX = _minX;
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
			if (_mouseDown)
			{
				_currentX = PlayerControls.MouseWorld.x - base.transform.parent.position.x;
			}
			else
			{
				_currentX -= Time.deltaTime * _decayRate;
			}
			_currentX = Mathf.Clamp(_currentX, _minX, _maxX);
			base.transform.localPosition = new Vector3(_currentX, base.transform.localPosition.y, base.transform.localPosition.z);
			if (_currentX == _maxX)
			{
				_onFull.Invoke();
			}
		}

		public void Randomize()
		{
			_currentX = SeededRandom.Global.RandomRange(_minX, _maxX);
		}

		private void OnMouseDown()
		{
			if (_timeout <= 0f)
			{
				_mouseDown = true;
				UISounds.Button();
			}
		}

		public void DoCraft()
		{
			UISounds.CraftStep();
			_mouseDown = false;
			_timeout = 0.5f;
			GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
		}
	}
}
