using TMPro;
using UnityEngine;

namespace TH20
{
	public class RoomItemPlaceInfoMenu : InWorldMenuObject
	{
		[SerializeField]
		private GameObject _root;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private float _invalidTime = 0.5f;

		private RoomItem _item;

		private float _timeInvalid;

		public void Setup(RoomItem item, Level level)
		{
			_item = item;
			base.Setup(item, level);
			GameObjectUtils.SetActive(_root, isActive: false);
			Update();
		}

		protected override void Update()
		{
			base.Update();
			string invalidReasonDisplay = _item.InvalidReasonDisplay;
			if (_item.IsValid || string.IsNullOrEmpty(invalidReasonDisplay))
			{
				_timeInvalid = 0f;
				GameObjectUtils.SetActive(_root, isActive: false);
				return;
			}
			_timeInvalid += GameTime.unscaledDeltaTime;
			if (_timeInvalid > _invalidTime)
			{
				GameObjectUtils.SetActive(_root, isActive: true);
				_text.text = invalidReasonDisplay;
			}
		}

		protected override Vector3 GetMenuPosition()
		{
			return _item.Visual.WorldPosition + Vector3.up * _menuYOffset;
		}
	}
}
