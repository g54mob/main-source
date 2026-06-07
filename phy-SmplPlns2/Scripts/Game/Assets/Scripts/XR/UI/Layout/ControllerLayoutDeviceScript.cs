using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.XR.UI.Layout
{
	public class ControllerLayoutDeviceScript : MonoBehaviour
	{
		private Dictionary<string, Tuple<string, bool>> _actionToDisplayNameMap = new Dictionary<string, Tuple<string, bool>>
		{
			{
				"Pitch",
				Tuple.Create("Pitch", item2: false)
			},
			{
				"Roll",
				Tuple.Create("Roll", item2: false)
			},
			{
				"Pause",
				Tuple.Create("Pause", item2: true)
			},
			{
				"Vtol",
				Tuple.Create("VTOL", item2: false)
			},
			{
				"Yaw",
				Tuple.Create("Yaw", item2: false)
			},
			{
				"MenuRight",
				Tuple.Create("Pop-up Menu", item2: false)
			},
			{
				"MenuLeft",
				Tuple.Create("Pop-up Menu", item2: false)
			},
			{
				"RecenterView",
				Tuple.Create("Recenter View", item2: false)
			},
			{
				"GripPressedRight",
				Tuple.Create("Grab", item2: true)
			},
			{
				"GripPressedLeft",
				Tuple.Create("Grab", item2: true)
			},
			{
				"GripReleasedRight",
				Tuple.Create(string.Empty, item2: false)
			},
			{
				"GripReleasedLeft",
				Tuple.Create(string.Empty, item2: false)
			},
			{
				"InteractRight",
				Tuple.Create("Click\nFlip Switch\nPush Button", item2: false)
			},
			{
				"InteractLeft",
				Tuple.Create("Click\nFlip Switch\nPush Button", item2: false)
			},
			{
				"LaunchCountermeasures",
				Tuple.Create("Countermeasures", item2: true)
			},
			{
				"FireWeapons",
				Tuple.Create("Fire Weapons", item2: true)
			},
			{
				"FireGuns",
				Tuple.Create("Fire Guns", item2: true)
			},
			{
				"ThrottleVtolToggle",
				Tuple.Create("Switch Throttle/VTOL", item2: false)
			},
			{
				"Throttle",
				Tuple.Create("Throttle", item2: false)
			},
			{
				"LandingGear",
				Tuple.Create("Landing Gear", item2: false)
			},
			{
				"NextView",
				Tuple.Create("Next View", item2: false)
			},
			{
				"NextWeapon",
				Tuple.Create("Next Weapon", item2: true)
			},
			{
				"NextTarget",
				Tuple.Create("Next Target", item2: true)
			},
			{
				"CycleTargetingMode",
				Tuple.Create("Cycle Targeting Mode", item2: true)
			},
			{
				"UIClickRight",
				Tuple.Create("Click", item2: false)
			},
			{
				"UIClickLeft",
				Tuple.Create("Click", item2: false)
			}
		};

		private ControllerLayoutScript _controllerLayoutScript;

		private List<HandScriptBase> _hands;

		[SerializeField]
		private XRHandType _handType;

		private ControllerLayoutInputScript[] _inputs;

		private IQueryInputAction _query;

		private bool _refreshBindings;

		public XRHandType HandType => _handType;

		public void Initialize(ControllerLayoutScript controllerLayoutScript, IQueryInputAction query, List<HandScriptBase> hands)
		{
			_controllerLayoutScript = controllerLayoutScript;
			_query = query;
			_query.BindingsChanged += OnBindingsChanged;
			_inputs = GetComponentsInChildren<ControllerLayoutInputScript>(includeInactive: true);
			_refreshBindings = true;
			_hands = hands;
			foreach (HandScriptBase hand in _hands)
			{
				hand.IsVisible = false;
			}
		}

		public void QueueRefresh()
		{
			_refreshBindings = true;
		}

		protected virtual void OnDestroy()
		{
			_query?.Dispose();
			foreach (HandScriptBase hand in _hands)
			{
				hand.IsVisible = true;
			}
		}

		protected virtual void OnEnable()
		{
			_refreshBindings = true;
		}

		protected virtual void Update()
		{
			if (_refreshBindings)
			{
				_refreshBindings = false;
				RefreshLabels();
			}
		}

		private Tuple<string, bool> ConvertActionToDisplayName(string action)
		{
			if (_actionToDisplayNameMap.TryGetValue(action, out var value))
			{
				return value;
			}
			Debug.LogError("Could not find display name for action: '" + action + "'");
			return new Tuple<string, bool>(action, item2: false);
		}

		private void OnBindingsChanged()
		{
			_refreshBindings = true;
		}

		private void RefreshLabels()
		{
			bool flag = false;
			ControllerLayoutInputScript[] inputs = _inputs;
			foreach (ControllerLayoutInputScript controllerLayoutInputScript in inputs)
			{
				string text = string.Empty;
				foreach (string inputPath in controllerLayoutInputScript.InputPaths)
				{
					text = _query.GetActionName(inputPath, _hands[0]);
					if (!string.IsNullOrEmpty(text))
					{
						break;
					}
				}
				string[] obj = text?.Split(new string[1] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries) ?? new string[0];
				string text2 = string.Empty;
				bool flag2 = false;
				controllerLayoutInputScript.IsHighlighted = false;
				string[] array = obj;
				foreach (string text3 in array)
				{
					controllerLayoutInputScript.IsHighlighted |= _controllerLayoutScript.HighlightedActionIds.Contains(text3);
					Tuple<string, bool> tuple = ConvertActionToDisplayName(text3);
					if (!string.IsNullOrWhiteSpace(tuple.Item1))
					{
						flag2 = flag2 || tuple.Item2;
						text2 = text2 + (string.IsNullOrWhiteSpace(text2) ? string.Empty : "\n") + tuple.Item1;
					}
				}
				if (!string.IsNullOrWhiteSpace(text2))
				{
					controllerLayoutInputScript.Visible = true;
					controllerLayoutInputScript.Text = text2;
					controllerLayoutInputScript.BoldColor = flag2;
					flag = true;
				}
				else
				{
					controllerLayoutInputScript.Visible = false;
				}
			}
			if (!flag)
			{
				_refreshBindings = true;
			}
		}
	}
}
