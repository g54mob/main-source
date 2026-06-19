using Loxodon.Framework.ViewModels;

namespace UI.Map
{
	public class MapSegmentViewModel : ViewModelBase
	{
		private int _currentX;

		private int _currentY;

		public int X
		{
			get
			{
				return _currentX;
			}
			set
			{
				Set(ref _currentX, value, "X");
			}
		}

		public int Y
		{
			get
			{
				return _currentY;
			}
			set
			{
				Set(ref _currentY, value, "Y");
			}
		}

		public MapSegmentViewModel(int X, int Y)
		{
			_currentX = X;
			_currentY = Y;
		}
	}
}
