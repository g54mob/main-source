using System.Collections.Generic;

namespace Server
{
	public struct ModelListEnumerator<T> where T : class, IModel
	{
		private int _index;

		private IList<IModel> _models;

		public T Current => _models[_index] as T;

		public ModelListEnumerator(IList<IModel> models)
		{
			_index = -1;
			_models = models;
		}

		public bool MoveNext()
		{
			if (_models != null && _index + 1 < _models.Count)
			{
				_index++;
				return true;
			}
			return false;
		}
	}
}
