using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MonoBeast : Entity, ICursorSelectable, IMultipleHighlight
	{
		private MonoBeastDefinition _definition;

		private Vector3 _position;

		private float _rotation;

		private bool _visible;

		private StateMachine _stateMachine;

		private Room _room;

		private float _reactionTime;

		public float PanicTime;

		[DontSave]
		private GameObject _gameObject;

		[DontSave]
		private Collider _collider;

		public Vector3 Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
				_gameObject.transform.position = value;
			}
		}

		public float Rotation
		{
			get
			{
				return _rotation;
			}
			set
			{
				_rotation = value;
				_gameObject.transform.rotation = Quaternion.Euler(0f, value, 0f);
			}
		}

		public Room Room => _room;

		public MonoBeastDefinition Definition => _definition;

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				_visible = value;
				GameObjectUtils.SetActive(_gameObject, value);
			}
		}

		public MonoBeast(MonoBeastDefinition definition, Level level, Vector3 position, float rotation, Room room)
			: base(definition, level)
		{
			_definition = definition;
			_room = room;
			_reactionTime = _definition.GetRandomReactionTime();
			position.y = 0f;
			SetupVisual(position, rotation, visible: true);
			_stateMachine = new StateMachine(null);
			_stateMachine.PushState(new MonoBeastControlState(this));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			SetupVisual(_position, _rotation, _visible);
			_stateMachine.TopState.RestoreFromSave();
		}

		private void SetupVisual(Vector3 position, float rotation, bool visible)
		{
			_gameObject = Object.Instantiate(_definition.VisualPrefab);
			_collider = _gameObject.GetComponent<Collider>();
			Visible = visible;
			Position = position;
			Rotation = rotation;
		}

		public override void Destroy()
		{
			_stateMachine.Destroy();
			Object.Destroy(_gameObject);
			base.Destroy();
		}

		public void Update()
		{
			if (_stateMachine != null)
			{
				_stateMachine.Update();
			}
			_reactionTime -= GameTime.deltaTime;
			if (_reactionTime <= 0f)
			{
				_reactionTime = _definition.GetRandomReactionTime();
				base.Level.CharacterEvents.TriggerGlobalCharacterAction(null, _room, Position, _definition.GetRandomReaction());
			}
		}

		public bool RayCast(Ray ray, out RaycastHit hit)
		{
			if (_collider != null && _collider.Raycast(ray, out hit, 400f))
			{
				return true;
			}
			hit = default(RaycastHit);
			return false;
		}

		public bool IsSelectable()
		{
			return Visible;
		}

		public void ToggleDebugInfo()
		{
		}

		public bool HasTooltip()
		{
			return false;
		}

		public bool CanHighlight()
		{
			return Visible;
		}

		public Renderer GetHighlightGameObject()
		{
			return _gameObject.GetComponentInChildren<Renderer>();
		}

		void IMultipleHighlight.GetMultipleHighlightGameObjects(List<Renderer> result)
		{
			_gameObject.GetComponentsInChildren(result);
		}

		public Vector3 GetMenuAnchorPosition()
		{
			return Position;
		}

		public GameObject GetCameraTrackObject()
		{
			return null;
		}

		public bool CanDragHoldSelect()
		{
			return false;
		}

		public void SetActiveMenu(InWorldMenuObject menu)
		{
		}

		public InWorldMenuObject GetActiveMenu()
		{
			return null;
		}

		public void CancelNav()
		{
			if (_stateMachine.TopState is MonoBeastNav monoBeastNav)
			{
				monoBeastNav.ReachedDestination();
			}
		}
	}
}
