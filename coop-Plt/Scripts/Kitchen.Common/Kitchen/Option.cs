using System;
using System.Collections.Generic;

namespace Kitchen
{
	public class Option<T>
	{
		private List<T> Options;

		public List<string> Names;

		public int Chosen;

		private Func<T, T, float> Comparer;

		public bool IsValidChoice
		{
			get
			{
				if (Chosen >= 0)
				{
					return Chosen < Options.Count;
				}
				return false;
			}
		}

		public event EventHandler<T> OnChanged = delegate
		{
		};

		public Option(List<T> values, T current, List<string> names, Func<T, T, float> comparer = null)
		{
			if (comparer == null)
			{
				comparer = (T a, T b) => (!a.Equals(b)) ? 1 : 0;
			}
			Options = values;
			Comparer = comparer;
			Names = names;
			Chosen = GetBestIndex(current);
		}

		public void SetOptions(List<T> values, List<string> names)
		{
			if (TryGetChosen(out var value))
			{
				Options = values;
				SetChosen(GetBestIndex(value));
			}
			else
			{
				Options = values;
				SetChosen(0);
			}
			Names = names;
		}

		public int GetBestIndex(T value)
		{
			int result = 0;
			float num = 99999f;
			for (int i = 0; i < Options.Count; i++)
			{
				T arg = Options[i];
				float num2 = Comparer(value, arg);
				if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public T GetOption(int index)
		{
			if (index < 0 || index >= Options.Count)
			{
				return default(T);
			}
			return Options[index];
		}

		public bool IsValidIndex(int i)
		{
			if (i >= 0)
			{
				return i < Options.Count;
			}
			return false;
		}

		public bool TryGetChosen(out T value)
		{
			if (IsValidChoice)
			{
				value = Options[Chosen];
				return true;
			}
			value = default(T);
			return false;
		}

		public T GetOrDefault(T def)
		{
			if (TryGetChosen(out var value))
			{
				return value;
			}
			return def;
		}

		public void SetChosen(int new_value)
		{
			if (new_value >= 0 && new_value < Options.Count)
			{
				Chosen = new_value;
				this.OnChanged(this, Options[new_value]);
			}
		}
	}
}
