using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class InspectorSubItemRoomDescription : InspectorSubItem
	{
		[SerializeField]
		private Localize _titleLabel;

		[SerializeField]
		private TMP_Text _titleLabelTextObject;

		[SerializeField]
		private Localize _descriptionLabel;

		[SerializeField]
		private TMP_Text _descriptionLabelTextObject;

		[SerializeField]
		private Image _roomIcon;

		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private float _scrollPadding = 160f;

		private Room _room;

		private bool _firstUpdate;

		public void Setup(Room room)
		{
			_room = room;
			_titleLabelTextObject.text = _room.Definition.GetLocalisedName();
			_descriptionLabel.SetTerm(_room.Definition.LongDescription.Term);
			_roomIcon.overrideSprite = _room.Definition._icon;
			_firstUpdate = true;
		}

		private void Update()
		{
			_scroller.content.sizeDelta = new Vector2(_scroller.content.sizeDelta.x, _roomIcon.preferredHeight + _titleLabelTextObject.preferredHeight + _descriptionLabelTextObject.preferredHeight + _scrollPadding);
			if (_firstUpdate)
			{
				_scroller.normalizedPosition = new Vector2(0f, 1f);
				_firstUpdate = false;
			}
		}
	}
}
