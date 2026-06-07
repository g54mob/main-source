using UnityEngine;

namespace Assets.Behaviour.Frame
{
	public class T5BottledLightningSecret : MonoBehaviour
	{
		[SerializeField]
		private SecretButton _button;

		[SerializeField]
		private ActiveWorldFrame _frame;

		[SerializeField]
		private T5LightningRod _base;

		[SerializeField]
		private Collider2D _collider;

		[SerializeField]
		private LineRenderer _line;

		[SerializeField]
		private Transform _target;

		private bool _detached;

		private bool _secretRevealed;

		private void Update()
		{
			if (_frame.ActiveFrame != null)
			{
				_collider.enabled = _frame.ActiveFrame.IsFullyUpgraded() && _base.LightningActive;
				if (_detached || _secretRevealed)
				{
					_base.DoLightning(Time.deltaTime);
				}
			}
		}

		private void OnMouseDown()
		{
			if (!_secretRevealed)
			{
				_base.enabled = false;
				_detached = true;
			}
		}

		private void OnMouseDrag()
		{
			if (_detached)
			{
				Vector2 mouseWorld = PlayerControls.MouseWorld;
				base.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, base.transform.position.z);
				_line.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, _line.transform.position.z);
				if (_collider.OverlapPoint(_target.transform.position))
				{
					_detached = false;
					mouseWorld = _target.transform.position;
					base.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, base.transform.position.z);
					_line.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, _line.transform.position.z);
					_secretRevealed = true;
					_button.gameObject.SetActive(value: true);
					UISounds.CraftFinished();
				}
			}
		}
	}
}
