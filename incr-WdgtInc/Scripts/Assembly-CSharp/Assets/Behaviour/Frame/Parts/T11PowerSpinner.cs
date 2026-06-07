using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T11PowerSpinner : MonoBehaviour
	{
		[SerializeField]
		private float _speed;

		private float _angle;

		private ActiveWorldFrame _parent;

		private float _inactivityTimer;

		private void Awake()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Update()
		{
			_angle += Time.deltaTime * _speed;
			base.transform.localEulerAngles = new Vector3(0f, 0f, _angle);
			if (_inactivityTimer > 0f)
			{
				_inactivityTimer -= Time.deltaTime;
			}
			else if (_parent.ActiveFrame is CraftingFrame craftingFrame && !craftingFrame.GetManualCrafter(0).Active)
			{
				craftingFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				if (!craftingFrame.GetManualCrafter(0).Active)
				{
					_inactivityTimer = 1f;
				}
			}
		}
	}
}
