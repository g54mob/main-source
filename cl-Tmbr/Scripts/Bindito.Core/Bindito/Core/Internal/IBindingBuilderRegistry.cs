namespace Bindito.Core.Internal
{
	public interface IBindingBuilderRegistry
	{
		void RegisterBindingBuilder<T>(BindingBuilder<T> bindingBuilder) where T : class;

		void RegisterMultiBindingBuilder<T>(BindingBuilder<T> bindingBuilder) where T : class;
	}
}
