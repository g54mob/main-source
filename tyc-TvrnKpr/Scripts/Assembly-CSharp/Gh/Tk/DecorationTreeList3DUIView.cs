using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class DecorationTreeList3DUIView : TreeList3DUIView, IUpdateable
	{
		[SerializeField]
		private Button3DUIView _closeButton;

		private TreeNodeUIView _baseNode;

		private GameObjectX _goxShowing;

		private bool _isTryShowWaiting;

		protected bool _isClosed;

		public event EventHandler<EventArgs> DisplayStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnSyncedEntitiesChanged(object sender, EventArgs e)
		{
		}

		private void MarkDirty()
		{
		}

		public void UpdateObject()
		{
		}

		public bool CanShow()
		{
			return false;
		}

		public void TryShow()
		{
		}

		private void SelectEntityObjectNodes(EntityObject[] eos)
		{
		}

		public void ShowTreeViewForGox(GameObjectX parentGox)
		{
		}

		private void HideView()
		{
		}

		public void Close()
		{
		}

		private void RemoveBaseNode()
		{
		}
	}
}
