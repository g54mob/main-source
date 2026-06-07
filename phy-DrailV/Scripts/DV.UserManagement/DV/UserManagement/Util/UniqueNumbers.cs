using System;
using System.Collections.Generic;

namespace DV.UserManagement.Util
{
	public class UniqueNumbers
	{
		private HashSet<int> takenNumbers = new HashSet<int>();

		private int maxCount;

		private int firstFree;

		private readonly int maxNumber;

		public bool HasFree => takenNumbers.Count < maxCount;

		public int FirstFree => firstFree;

		public int MaxCount => maxCount;

		public int MaxNumber => maxNumber;

		public UniqueNumbers(int digits)
		{
			if (digits < 1 || digits > 9)
			{
				throw new ArgumentException("digits needs to be in [1-9] range.", "digits");
			}
			int num = 1;
			for (int i = 0; i < digits; i++)
			{
				num *= 10;
			}
			maxCount = num;
			maxNumber = num - 1;
		}

		public UniqueNumbers(int digits, IList<int> startingNumbers)
			: this(digits)
		{
			for (int i = 0; i < startingNumbers.Count; i++)
			{
				Put(startingNumbers[i]);
			}
		}

		public UniqueNumbers(int digits, int[] startingNumbers)
			: this(digits)
		{
			for (int i = 0; i < startingNumbers.Length; i++)
			{
				Put(startingNumbers[i]);
			}
		}

		public int TakeFirstFree()
		{
			if (!HasFree)
			{
				throw new ArgumentException($"Collection is full, all {maxCount} available numbers are taken");
			}
			int num = firstFree;
			Put(num);
			return num;
		}

		public void Put(int number)
		{
			if (number < 0 || number > maxNumber)
			{
				throw new ArgumentException($"Number {number} is out of range, it needs to be inside [0-{maxNumber}]", "number");
			}
			if (!HasFree)
			{
				throw new ArgumentException($"Collection is full, all {maxCount} available numbers are taken");
			}
			if (takenNumbers.Contains(number))
			{
				throw new ArgumentException($"Number {number} is currently taken", "number");
			}
			takenNumbers.Add(number);
			firstFree = Math.Max((number + 1) % maxCount, firstFree);
			CheckFirstFree();
		}

		public void Remove(int number)
		{
			if (number < 0 || number > maxNumber)
			{
				throw new ArgumentException($"Number {number} is out of range, it needs to be inside [0-{maxNumber}]", "number");
			}
			if (takenNumbers.Remove(number))
			{
				firstFree = Math.Min(firstFree, number);
				return;
			}
			throw new ArgumentException($"Number {number} wasn't taken in this collection, can't remove it", "number");
		}

		public bool Contains(int number)
		{
			return takenNumbers.Contains(number);
		}

		private void CheckFirstFree()
		{
			if (!HasFree)
			{
				firstFree = -1;
				return;
			}
			while (takenNumbers.Contains(firstFree))
			{
				firstFree = (firstFree + 1) % maxCount;
			}
		}
	}
}
