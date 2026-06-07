using System;

namespace ModApi.Ui.Inspector
{
	public class ModelBuilder<T> where T : ItemModel
	{
		public T Model { get; }

		public ModelBuilder(T model)
		{
			Model = model;
		}

		public ModelBuilder<T> Build(Action<T> buildAction)
		{
			buildAction(Model);
			return this;
		}
	}
}
