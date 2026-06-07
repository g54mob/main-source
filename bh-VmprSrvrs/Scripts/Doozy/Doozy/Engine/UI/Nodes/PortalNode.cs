using System;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Navigation/Portal", 50, false, false)]
	public class PortalNode : Node
	{
		public enum ListenerType
		{
			GameEvent = 0,
			UIButton = 1,
			UIView = 2,
			UIDrawer = 3
		}

		private const ListenerType DEFAULT_LISTENER_TYPE = ListenerType.GameEvent;

		private const bool DEFAULT_ANY_VALUE = false;

		private const string DEFAULT_GAME_EVENT = "";

		[SerializeField]
		private string m_gameEvent;

		[NonSerialized]
		private Graph m_portalGraph;

		public ListenerType ListenFor;

		public bool AnyValue;

		public UIViewBehaviorType UIViewTriggerAction;

		public string ViewCategory;

		public string ViewName;

		public UIButtonBehaviorType UIButtonTriggerAction;

		public string ButtonCategory;

		public string ButtonName;

		public UIDrawerBehaviorType UIDrawerTriggerAction;

		public string DrawerName;

		public bool CustomDrawerName;

		public bool SwitchBackMode;

		private Node m_sourceNode;

		private bool m_activatedByEvent;

		public string GameEventToListenFor => null;

		public Graph PortalGraph
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasSource => false;

		public Node Source => null;

		public string WaitForInfoTitle => null;

		public string WaitForInfoDescription => null;

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		private void AddListeners()
		{
		}

		private void RemoveListeners()
		{
		}

		public override void Activate(Graph portalGraph)
		{
		}

		public override void Deactivate()
		{
		}

		private void UpdateSourceNode(Node node)
		{
		}

		private void OnGameEventMessage(GameEventMessage message)
		{
		}

		private void OnUIViewMessage(UIViewMessage message)
		{
		}

		private void OnUIButtonMessage(UIButtonMessage message)
		{
		}

		private void OnUIDrawerMessage(UIDrawerMessage message)
		{
		}

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void OnExit(Node nextActiveNode, Connection connection)
		{
		}

		public override void CheckForErrors()
		{
		}
	}
}
