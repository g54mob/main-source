using CTS.BBT;
using CTS.Core;
using CTS.Emotes;
using UnityEngine;

namespace CTS
{
	public class StationMorgueEmote : CTSBehaviour
	{
		[SerializeField]
		private SelectionModes _visibleInSelectionModes;

		[Inject(false)]
		private Furniture _furniture;

		[Inject(false)]
		private StationMorgue _stationMorgue;

		private Emote _emote;

		private SelectableObject _selectableObject => _furniture.SelectableObject;

		private BarVisualObject _barVisualObject => _furniture.BarVisualObject;

		private Collider _collider => _furniture.Bounds.SelectionCollider;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_selectableObject.HoverEnter += OnHoverEnter;
			_selectableObject.HoverExit += OnHoverExit;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_selectableObject.HoverEnter -= OnHoverEnter;
			_selectableObject.HoverExit -= OnHoverExit;
		}

		private void OnHoverEnter(SelectionMode selectionMode)
		{
			_emote?.Kill();
			if (_visibleInSelectionModes.CanBeSelectedBy(selectionMode))
			{
				_emote = EmoteManager.Play<EmoteBBT>(_barVisualObject, GetEmoteText());
				_emote.SetStayDuration(-1f);
				_emote.SetHeight(_collider, 0.5f);
			}
		}

		private void OnHoverExit(SelectionMode selectionMode)
		{
			_emote?.Kill();
			_emote = null;
		}

		private string GetEmoteText()
		{
			return _stationMorgue.DeadBodyCount + " / " + _stationMorgue.MaxCount;
		}
	}
}
