using System.Collections.Generic;

namespace Loxodon.Framework.Views
{
	public interface IViewGroup : IView
	{
		List<IView> Views { get; }

		IView GetView(string name);

		void AddView(IView view, bool worldPositionStays = false);

		void AddView(IView view, Layout layout);

		void RemoveView(IView view, bool worldPositionStays = false);
	}
}
