using System;
using Events.WorldMap;
using UnityEngine;

namespace Presentation.UI
{
	public class ScreenInteractableWorldArea : MonoBehaviour
	{
		[SerializeField]
		private float _radius;

		[SerializeField]
		private Transform _centerPoint;

		[SerializeField]
		private InteractableWorldAreaEvent _interactableAreaInitializedEvent;

		public float SqrRadius => _radius * _radius;

		public Transform CenterPoint => _centerPoint;

		public event Action OnAreaIsHoveredOverAction;

		public event Action OnAreaIsClickedAction;

		public event Action OnAreaStopHoverAction;

		public virtual void OnAreaIsHoveredOver()
		{
			if (this.OnAreaIsHoveredOverAction != null)
			{
				this.OnAreaIsHoveredOverAction();
			}
		}

		public virtual void OnAreaIsClicked()
		{
			if (this.OnAreaIsClickedAction != null)
			{
				this.OnAreaIsClickedAction();
			}
		}

		public virtual void OnAreaStopHover()
		{
			if (this.OnAreaStopHoverAction != null)
			{
				this.OnAreaStopHoverAction();
			}
		}

		private void Start()
		{
			if (_centerPoint == null)
			{
				_centerPoint = base.transform;
			}
			_interactableAreaInitializedEvent.Fire(this);
		}
	}
}
