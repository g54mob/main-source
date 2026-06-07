using System.Collections.Generic;

namespace MoreMountains.Tools
{
	public class MMCircularList<T> : List<T>
	{
		private int _currentIndex;

		public int CurrentIndex
		{
			get
			{
				return GetCurrentIndex();
			}
			set
			{
				_currentIndex = value;
			}
		}

		public virtual T Current => base[CurrentIndex];

		public virtual int PreviousIndex
		{
			get
			{
				if (_currentIndex != 0)
				{
					return _currentIndex - 1;
				}
				return base.Count - 1;
			}
		}

		public virtual int NextIndex
		{
			get
			{
				if (_currentIndex != base.Count - 1)
				{
					return _currentIndex + 1;
				}
				return 0;
			}
		}

		protected virtual int GetCurrentIndex()
		{
			if (_currentIndex > base.Count - 1)
			{
				_currentIndex = 0;
			}
			if (_currentIndex < 0)
			{
				_currentIndex = base.Count - 1;
			}
			return _currentIndex;
		}

		public virtual void IncrementCurrentIndex()
		{
			_currentIndex++;
			GetCurrentIndex();
		}

		public virtual void DecrementCurrentIndex()
		{
			_currentIndex--;
			GetCurrentIndex();
		}
	}
}
