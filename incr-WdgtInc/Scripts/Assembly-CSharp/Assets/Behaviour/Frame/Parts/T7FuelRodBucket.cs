using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7FuelRodBucket : FrameGizmo
	{
		[SerializeField]
		private SecretButton _secretButton;

		private ActiveWorldFrame _frame;

		private T7FuelRodItem _currentItem;

		private bool _consumed;

		private void Start()
		{
			_frame = GetComponentInParent<ActiveWorldFrame>();
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			if (_currentItem == null)
			{
				_currentItem = collision.gameObject.GetComponent<T7FuelRodItem>();
				_currentItem.DetachAndStop();
				if ((bool)_secretButton)
				{
					_secretButton.gameObject.SetActive(value: true);
					UISounds.CraftFinished();
				}
			}
		}

		public void ButtonPressed()
		{
			if (_consumed || ConsumeItem())
			{
				_frame.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			}
		}

		public bool ConsumeItem()
		{
			if (_currentItem != null)
			{
				Object.Destroy(_currentItem.gameObject);
				_currentItem = null;
				_consumed = true;
			}
			else
			{
				_frame.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T7FuelRodWarning");
				_consumed = false;
			}
			return _consumed;
		}

		public override void OnClickGizmo(float progress)
		{
			if (progress == 1f)
			{
				_consumed = false;
			}
		}
	}
}
