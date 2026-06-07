using System;
using System.Collections.Generic;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.UI.Internal;
using UnityEngine;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("UINode", 0, false, false)]
	public class UINode : Node
	{
		public enum NodeState
		{
			OnEnter = 0,
			OnExit = 1
		}

		public enum ViewAction
		{
			ShowView = 0,
			HideView = 1
		}

		[SerializeField]
		private List<UIViewCategoryName> m_onEnterShowViews;

		[SerializeField]
		private List<UIViewCategoryName> m_onEnterHideViews;

		[SerializeField]
		private List<UIViewCategoryName> m_onExitShowViews;

		[SerializeField]
		private List<UIViewCategoryName> m_onExitHideViews;

		[NonSerialized]
		private bool m_timerIsActive;

		[NonSerialized]
		private double m_timerStart;

		[NonSerialized]
		private float m_timeDelay;

		[NonSerialized]
		private Socket m_activeSocketAfterTimeDelay;

		public List<UIViewCategoryName> OnEnterShowViews => null;

		public List<UIViewCategoryName> OnEnterHideViews => null;

		public List<UIViewCategoryName> OnExitShowViews => null;

		public List<UIViewCategoryName> OnExitHideViews => null;

		public float TimerProgress => 0f;

		public override void CopyNode(Node original)
		{
		}

		private List<UIViewCategoryName> UIViewCategoryNameListCopy(List<UIViewCategoryName> original)
		{
			return null;
		}

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public void SortShowViewsList()
		{
		}

		public void SortHideViewsList()
		{
		}

		private static List<UIViewCategoryName> SortViewsList(IEnumerable<UIViewCategoryName> list)
		{
			return null;
		}

		private void AddListeners()
		{
		}

		private void RemoveListeners()
		{
		}

		private void OnButtonMessage(UIButtonMessage message)
		{
		}

		private void OnGameEventMessage(GameEventMessage message)
		{
		}

		private void LookForTimeDelay()
		{
		}

		private void ActivateTimer(float timeDelay, Socket socket)
		{
		}

		private void ActivateOutputSocketInputNode(Socket socket)
		{
		}

		public override void Activate(Graph portalGraph)
		{
		}

		public override void Deactivate()
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void OnUpdate()
		{
		}

		public override void OnExit(Node nextActiveNode, Connection connection)
		{
		}

		public void ShowViews(List<UIViewCategoryName> views)
		{
		}

		public void HideViews(List<UIViewCategoryName> views)
		{
		}

		public void AddView(UIViewCategoryName view, NodeState nodeState, ViewAction viewAction, bool saveAssets = false)
		{
		}
	}
}
