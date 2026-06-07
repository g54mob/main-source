using Unity.Collections;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	internal struct CircularSlice<T> where T : unmanaged
	{
		public int CurrentIndex;

		public int EndIndex;

		public int StartIndex;

		public IIndexable<T> Target;

		public readonly ref T Value => ref Target.ElementAt(CurrentIndex);

		public CircularSlice(IIndexable<T> target, int start, int count)
		{
			Target = target;
			StartIndex = start;
			CurrentIndex = start;
			EndIndex = start + count;
			if (EndIndex > target.Length)
			{
				EndIndex -= target.Length;
			}
		}

		public bool Next()
		{
			int currentIndex = CurrentIndex;
			if (CurrentIndex + 1 == Target.Length)
			{
				CurrentIndex = 0;
			}
			else
			{
				CurrentIndex++;
			}
			if (CurrentIndex == EndIndex)
			{
				CurrentIndex = currentIndex;
				return false;
			}
			return true;
		}

		public bool Prev()
		{
			if (CurrentIndex == StartIndex)
			{
				return false;
			}
			CurrentIndex--;
			if (CurrentIndex < 0)
			{
				CurrentIndex = Target.Length - 1;
			}
			return true;
		}
	}
}
