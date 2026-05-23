using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Events;
using Events.FactoryFloor.Tools;
using Events.Generic;
using Logic.Factory;
using Logic.Factory.Blueprint;
using Presentation.FactoryFloor;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.FactoryTools
{
	[CreateAssetMenu(menuName = "Factory/Tools/SelectFactoryObjectTool", fileName = "SelectFactoryObjectTool", order = 0)]
	public class SelectFactoryObjectTool : FactoryTool
	{
		[Header("Select refs")]
		[SerializeField]
		private CurrentFactoryLayer _factoryLayer;

		[SerializeField]
		private MouseToGridInput _mouseToGridInput;

		[SerializeField]
		private IntListEvent _newFactoryObjectsSelectedEvent;

		[SerializeField]
		private IntListEvent _factoryObjectsDeSelectedEvent;

		[SerializeField]
		private SelectFactoryObjectEvent _selectFactoryObjectEvent;

		[SerializeField]
		private BaseEvent _selectFactoryObjectCancelledEvent;

		[SerializeField]
		private GridLocator _gridLocator;

		private FactoryObject _currentHoveredItem;

		private FactoryObjectView _currentHoveredView;

		private List<Type> _neededFactoryObjectBehaviourTypes = new List<Type>();

		private List<Type> _excludedFactoryObjectBehaviourTypes = new List<Type>();

		public override bool CanAutoSwapAwayFrom => false;

		public event Action OnComplete = delegate
		{
		};

		public event Action OnDeselectTool = delegate
		{
		};

		public event Action<FactoryObject, bool> OnHoverOverObject = delegate
		{
		};

		public override void SelectTool(Blueprint blueprint)
		{
			base.SelectTool(blueprint);
			_neededFactoryObjectBehaviourTypes.Clear();
			_excludedFactoryObjectBehaviourTypes.Clear();
		}

		public void SetNeededFactoryObjectBehaviours(List<Type> factoryObjectBehaviours)
		{
			_neededFactoryObjectBehaviourTypes.Clear();
			_neededFactoryObjectBehaviourTypes.AddRange(factoryObjectBehaviours);
		}

		public void SetExcludedFactoryObjectBehaviours(List<Type> factoryObjectBehaviours)
		{
			_excludedFactoryObjectBehaviourTypes.Clear();
			_excludedFactoryObjectBehaviourTypes.AddRange(factoryObjectBehaviours);
		}

		public void SetCursorTextKey(string text)
		{
			_cursorTextKey = text;
		}

		public override void UpdateTool(Vector3Int gridPos, Vector3 mousePos)
		{
			_currentHoveredView = _mouseToGridInput.GetSelectedFactoryObjectView();
			FactoryObject factoryObject;
			if (FactoryObjectHasBehaviours(_currentHoveredView))
			{
				factoryObject = _currentHoveredView.FactoryObject;
			}
			else
			{
				factoryObject = _factoryLayer.Value.GetObjectAt(gridPos);
				if (FactoryObjectHasBehaviours(factoryObject) && (bool)FactoryObjectViewManager.Instance)
				{
					FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out _currentHoveredView);
				}
				else
				{
					factoryObject = null;
				}
			}
			if (factoryObject != null)
			{
				if (_currentHoveredItem == factoryObject)
				{
					return;
				}
				if (_currentHoveredItem != null)
				{
					_factoryObjectsDeSelectedEvent.Fire(new List<int> { _currentHoveredItem.CreatedId });
				}
				_currentHoveredItem = factoryObject;
				_newFactoryObjectsSelectedEvent.Fire(new List<int> { _currentHoveredItem.CreatedId });
			}
			else if (_currentHoveredItem != null)
			{
				_factoryObjectsDeSelectedEvent.Fire(new List<int> { _currentHoveredItem.CreatedId });
				_currentHoveredItem = null;
			}
			this.OnHoverOverObject(_currentHoveredItem, _currentHoveredItem != null);
		}

		private bool FactoryObjectHasBehaviours(FactoryObjectView factoryObjectView)
		{
			if (factoryObjectView == null)
			{
				return false;
			}
			return FactoryObjectHasBehaviours(factoryObjectView.FactoryObject);
		}

		private bool FactoryObjectHasBehaviours(FactoryObject factoryObject)
		{
			if (_neededFactoryObjectBehaviourTypes.IsNullOrEmpty())
			{
				return true;
			}
			if (factoryObject == null)
			{
				return false;
			}
			bool result = true;
			foreach (Type neededFactoryObjectBehaviourType in _neededFactoryObjectBehaviourTypes)
			{
				bool flag = false;
				foreach (FactoryObjectBehaviour factoryObjectBehaviour in factoryObject.GetFactoryObjectBehaviours())
				{
					if (IsSameBehaviourType(factoryObjectBehaviour.GetType(), neededFactoryObjectBehaviourType))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					result = false;
					break;
				}
			}
			foreach (Type excludedFactoryObjectBehaviourType in _excludedFactoryObjectBehaviourTypes)
			{
				foreach (FactoryObjectBehaviour factoryObjectBehaviour2 in factoryObject.GetFactoryObjectBehaviours())
				{
					if (factoryObjectBehaviour2.GetType() == excludedFactoryObjectBehaviourType)
					{
						return false;
					}
				}
			}
			return result;
		}

		private bool IsSameBehaviourType(Type type, Type other)
		{
			if (!(other == type) && !other.IsSubclassOf(type))
			{
				return other.IsAssignableFrom(type);
			}
			return true;
		}

		public override void OnActionIntent(Vector3Int gridPos, Vector3 mousePos)
		{
		}

		public override void DoAction(Vector3Int gridPos, Vector3 mousePos)
		{
			if (_currentHoveredItem != null)
			{
				_selectFactoryObjectEvent.Fire(_currentHoveredItem);
			}
		}

		public override void DoAction(FactoryObject factoryObject)
		{
			_selectFactoryObjectEvent.Fire(factoryObject);
		}

		public void CallOnComplete()
		{
			this.OnComplete();
		}

		public override void CancelAction()
		{
			_selectFactoryObjectCancelledEvent.Fire();
		}

		public override void DeSelectTool()
		{
			if (_currentHoveredItem != null)
			{
				_factoryObjectsDeSelectedEvent.Fire(new List<int> { _currentHoveredItem.CreatedId });
				_currentHoveredItem = null;
			}
			_selectFactoryObjectEvent.UnRegisterAll();
			_selectFactoryObjectCancelledEvent.Fire();
			this.OnDeselectTool();
			this.OnComplete = delegate
			{
			};
			this.OnDeselectTool = delegate
			{
			};
			this.OnHoverOverObject = delegate
			{
			};
		}
	}
}
