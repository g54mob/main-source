using Noesis;

namespace NoesisApp
{
	public interface IAttachedObject
	{
		DependencyObject AssociatedObject { get; }

		void Attach(DependencyObject associatedObject);

		void Detach();
	}
}
