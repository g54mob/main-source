using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12ShieldingSecretPanel : MonoBehaviour
	{
		[SerializeField]
		private ActiveWorldFrame _frame;

		[SerializeField]
		private Collider2D _collider;

		[SerializeField]
		private Transform _outline;

		[SerializeField]
		private SecretButton _button;

		private bool _detached;

		private void Start()
		{
			_button.SetActive(active: false);
		}

		private void Update()
		{
			if (!_detached && _frame.ActiveFrame != null)
			{
				_collider.enabled = ((CraftingFrame)_frame.ActiveFrame).GetManualCrafter(0).Active;
			}
		}

		private void OnMouseDrag()
		{
			_detached = true;
			_outline.gameObject.SetActive(value: true);
			Vector2 mouseWorld = PlayerControls.MouseWorld;
			base.transform.position = new Vector3(mouseWorld.x, mouseWorld.y, base.transform.position.z);
			if (!_button.IsActive() && Vector3.Distance(base.transform.position, _button.transform.position) > 2f)
			{
				_button.SetActive(active: true);
			}
		}
	}
}
