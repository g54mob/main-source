using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rhizomatic.MemberBinding;
using UnityEngine;

namespace Rhizomatic.Reactive
{
	public abstract class View : MonoBehaviour
	{
		private List<State> states;

		private bool dirty;

		private List<State> statesBuffer;

		public CrewContainer crewContainer;

		public Action onOpen;

		public Action onClose;

		private bool _started;

		private bool _created;

		private bool _spawned;

		public ViewLoader attachedViewLoader { get; private set; }

		public IViewable viewable { get; private set; }

		public bool isViewActive { get; set; }

		public abstract Type viewableType { get; }

		public event Action onRendered
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

		protected virtual void OnRender()
		{
		}

		protected virtual void OnViewCreated()
		{
		}

		protected virtual void OnViewSpawned()
		{
		}

		protected virtual void OnViewDestroyed()
		{
		}

		protected virtual void OnViewOpen()
		{
		}

		protected virtual void OnViewClose()
		{
		}

		public bool CanOpen(IViewable viewable)
		{
			return false;
		}

		internal void HandleCreate()
		{
		}

		internal void HandleSpawned()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected virtual void OnEnable()
		{
		}

		public void TryRender()
		{
		}

		private void Render()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public void MarkDirty()
		{
		}

		public void ForceRender()
		{
		}

		public void Render(IViewable viewable)
		{
		}

		public void OpenView(IViewable viewable)
		{
		}

		public void OpenView(IViewable viewable, ViewLoader viewLoader)
		{
		}

		public void CloseView()
		{
		}

		internal void HandleClose()
		{
		}

		public void RegisterState(State state)
		{
		}

		public void UnregisterState(State state)
		{
		}

		public void RegisterViewable(IViewable viewable)
		{
		}

		public void UnregisterViewable(IViewable viewable)
		{
		}
	}
	[CustomMemberBinding]
	public abstract class View<T> : View where T : IViewable
	{
		public new T viewable => default(T);

		public override Type viewableType => null;

		public static void MemberBinder_CustomMemberBinding(MemberBindData bindData)
		{
		}
	}
}
