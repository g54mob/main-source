using System.Collections.Generic;

namespace Obi
{
	public class RendererSet<T> where T : ObiRenderer<T>
	{
		private List<T> list = new List<T>();

		public T this[int i]
		{
			get
			{
				return list[i];
			}
			set
			{
				list[i] = value;
			}
		}

		public int Count => list.Count;

		public bool AddRenderer(T renderer)
		{
			if (!list.Contains(renderer))
			{
				list.Add(renderer);
				return true;
			}
			return false;
		}

		public int IndexOf(T renderer)
		{
			return list.IndexOf(renderer);
		}

		public IReadOnlyList<T> AsReadOnly()
		{
			return list.AsReadOnly();
		}

		public bool RemoveRenderer(T renderer)
		{
			return list.Remove(renderer);
		}

		public void Clear()
		{
			list.Clear();
		}
	}
}
