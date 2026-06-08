using System.Collections.Generic;
using Rhizomatic.Pooling;
using UnityEngine;
using UnityEngine.Events;

namespace Rhizomatic.ImUI
{
	[RequireComponent(typeof(ObjectPool))]
	public class ImUIManager : MonoBehaviour
	{
		public Transform container;

		public List<ImUIView> views;

		public UnityAction onEditStart;

		public UnityAction onEditEnd;

		private bool changed;

		public List<ImUIView> oldViews { get; }

		public List<ImUIView> currentViews { get; }

		public ImUIViewBuilder viewBuilder { get; private set; }

		public ObjectPool pool { get; private set; }

		public List<LayoutView> layouts { get; }

		public ImUIView editingView { get; private set; }

		public bool isEditing { get; private set; }

		public Context context { get; set; }

		public ImUIBuilder builder { get; private set; }

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Build()
		{
		}

		public void SetViewBuilder(ImUIViewBuilder viewBuilder)
		{
		}

		public void Clear()
		{
		}

		public void Begin()
		{
		}

		public void End()
		{
		}

		public void EndLayout()
		{
		}

		public T BuildLayoutView<T>(string type, T state, ViewParam[] viewParams) where T : LayoutViewState
		{
			return null;
		}

		public T BuildView<T>(string type, T state, ViewParam[] viewParams) where T : ImUIViewState
		{
			return null;
		}

		public void LoadState()
		{
		}

		public void Changed()
		{
		}

		public void StartEdit(ImUIView view)
		{
		}

		public void EndEdit(ImUIView view)
		{
		}
	}
}
