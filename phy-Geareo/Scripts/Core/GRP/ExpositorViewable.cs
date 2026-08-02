using System;
using Rhizomatic;
using Rhizomatic.ImUI;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ExpositorViewable : Viewable
	{
		public Action onEditStart;

		public Action onEditEnd;

		public Action<ImUIBuilder> onUI;

		public State<IExpositorUI> target;

		public Context context { get; }

		public ExpositorViewable(Context context)
		{
		}

		public void Changed()
		{
		}

		public void ChangedFor(IExpositorUI item)
		{
		}
	}
}
