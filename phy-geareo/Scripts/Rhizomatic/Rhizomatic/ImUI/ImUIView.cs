using Rhizomatic.Pooling;
using UnityEngine;

namespace Rhizomatic.ImUI
{
	public abstract class ImUIView : PoolObject
	{
		public string type;

		public RectTransform padding;

		public ViewParam[] viewParams;

		public ImUIManager manager { get; private set; }

		public ImUIViewState state { get; private set; }

		public bool changed { get; private set; }

		public bool canEdit => false;

		public void _Setup(ImUIManager manager, ImUIViewState state)
		{
		}

		public void UseViewParams(ViewParam[] newViewParams)
		{
		}

		public virtual void LoadState(ImUIViewState state)
		{
		}

		public virtual ImUIViewState GetState()
		{
			return null;
		}

		public void Changed()
		{
		}

		protected override void OnPooled()
		{
		}

		public virtual void Used()
		{
		}

		public void StartEdit()
		{
		}

		public void EndEdit()
		{
		}
	}
	public class ImUIView<T> : ImUIView where T : ImUIViewState
	{
		public new T state => null;

		public sealed override void LoadState(ImUIViewState state)
		{
		}

		protected virtual void LoadState(T state)
		{
		}
	}
}
