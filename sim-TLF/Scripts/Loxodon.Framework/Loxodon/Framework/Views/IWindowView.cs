using Loxodon.Framework.Views.Animations;

namespace Loxodon.Framework.Views
{
	public interface IWindowView : IUIViewGroup, IUIView, IView
	{
		IAnimation ActivationAnimation { get; set; }

		IAnimation PassivationAnimation { get; set; }
	}
}
