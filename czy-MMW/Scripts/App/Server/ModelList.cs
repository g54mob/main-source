using System.Collections.Generic;

namespace Server
{
	public struct ModelList<T> where T : class, IModel
	{
		private IList<IModel> _models;

		public T this[int index]
		{
			get
			{
				if (Diagnostics.Verify(_models != null, "Object not set to a reference.") && Diagnostics.Verify(index < _models.Count && index >= 0, "Index out of range in ModelList."))
				{
					return _models[index] as T;
				}
				return null;
			}
		}

		public int Count
		{
			get
			{
				if (_models != null)
				{
					return _models.Count;
				}
				return 0;
			}
		}

		public ModelList(IList<IModel> models)
		{
			_models = models;
		}

		public ModelListEnumerator<T> GetEnumerator()
		{
			return new ModelListEnumerator<T>(_models);
		}
	}
}
