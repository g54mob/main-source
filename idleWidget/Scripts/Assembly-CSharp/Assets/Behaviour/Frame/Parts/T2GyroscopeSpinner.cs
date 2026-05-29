using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T2GyroscopeSpinner : MonoBehaviour
	{
		[SerializeField]
		private FrameHoldButton _button;

		private float _angle;

		private bool _firstHalf;

		private bool _reset;

		private ActiveWorldFrame _parent;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_firstHalf = true;
		}

		private void Update()
		{
			if (_button.IsDown)
			{
				if (!_reset)
				{
					_angle -= Time.deltaTime * 360f;
					if (_firstHalf && _angle < -180f)
					{
						_angle = -180f;
						_firstHalf = false;
						_reset = true;
						_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
						UISounds.CraftStep();
					}
					else if (!_firstHalf && _angle < -360f)
					{
						_angle = 0f;
						_firstHalf = true;
						_reset = true;
						_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
					}
					base.transform.localEulerAngles = new Vector3(0f, 0f, _angle);
				}
			}
			else
			{
				_reset = false;
			}
		}
	}
}
