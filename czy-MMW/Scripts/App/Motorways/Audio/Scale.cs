using System.Collections.Generic;
using System.Linq;

namespace Motorways.Audio
{
	public class Scale
	{
		public struct Data
		{
			public string Name;

			public List<int> Stack;

			public Data(string name, params int[] stack)
			{
				Name = name;
				Stack = stack?.ToList() ?? null;
			}
		}

		public int Key;

		public string Name;

		public List<int> Intervals;

		public List<int> BaseStack;

		public List<int> FullStack;

		public List<string> Notes;

		public bool IsOriginal = true;

		public string FullName()
		{
			return Note.SCALE[Key] + " " + Name;
		}

		public Scale(int key, string name, List<int> intervals, List<int> baseStack = null)
		{
			Init(key, name, intervals, baseStack);
		}

		private void Init(int key, string name, List<int> intervals, List<int> baseStack = null)
		{
			Key = key;
			Name = name;
			Intervals = intervals;
			BaseStack = baseStack ?? Liszt.From<int>(12);
			int i = 0;
			int pointer;
			for (pointer = 0; i < BaseStack.Last(); i += Intervals.SafeGet(pointer++))
			{
			}
			FullStack = BaseStack.ToList();
			if (name.Contains("SUHMM"))
			{
				pointer = 0;
			}
			int num = Note.RANGE.Count - 11;
			while (FullStack.Last() + Intervals.SafeGet(pointer) < num)
			{
				FullStack.Add(FullStack.Last() + Intervals.SafeGet(pointer++));
			}
			Notes = Note.Transpose(key, Quality.IntervalsToNotes(FullStack));
		}

		public void Restack(List<int> baseStack = null)
		{
			Init(Key, Name, Intervals, baseStack);
		}

		public Scale Rotate(int posDelta, string newName = "")
		{
			List<int> intervals = Intervals.Rotate(posDelta);
			int num = 0;
			int num2 = 0;
			while (num2 < posDelta)
			{
				num += Intervals[num2++];
			}
			return new Scale(Maf.FloorMod(Key + num, 12), (newName.Length > 0) ? newName : (Name + " " + (num2 + 1)), intervals, BaseStack);
		}

		public Scale Transpose(int keyDelta)
		{
			return new Scale(Maf.FloorMod(Key + keyDelta, 12), Name, Intervals, BaseStack);
		}

		public override string ToString()
		{
			return string.Format("{0} {1} : {2}\nStack: {3}\n", Note.SCALE[Key], Name, string.Join(", ", Notes), string.Join(", ", FullStack));
		}
	}
}
