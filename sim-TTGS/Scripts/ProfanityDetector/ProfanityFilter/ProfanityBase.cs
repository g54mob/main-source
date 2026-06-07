using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProfanityFilter
{
	public class ProfanityBase
	{
		protected List<string> _profanities;

		private readonly string[] _wordList = new string[0];

		public int Count => _profanities.Count;

		public ProfanityBase()
		{
			_profanities = new List<string>(_wordList);
		}

		protected ProfanityBase(string[] profanityList)
		{
			if (profanityList == null)
			{
				throw new ArgumentNullException("profanityList");
			}
			_profanities = new List<string>(profanityList);
		}

		protected ProfanityBase(List<string> profanityList)
		{
			if (profanityList == null)
			{
				throw new ArgumentNullException("profanityList");
			}
			_profanities = profanityList;
		}

		public void AddProfanity(string profanity)
		{
			if (string.IsNullOrEmpty(profanity))
			{
				throw new ArgumentNullException("profanity");
			}
			_profanities.Add(profanity);
		}

		public void AddProfanity(string[] profanityList)
		{
			if (profanityList == null)
			{
				throw new ArgumentNullException("profanityList");
			}
			_profanities.AddRange(profanityList);
		}

		public void AddProfanity(List<string> profanityList)
		{
			if (profanityList == null)
			{
				throw new ArgumentNullException("profanityList");
			}
			_profanities.AddRange(profanityList);
		}

		public bool RemoveProfanity(string profanity)
		{
			if (string.IsNullOrEmpty(profanity))
			{
				throw new ArgumentNullException("profanity");
			}
			return _profanities.Remove(profanity.ToLower(CultureInfo.InvariantCulture));
		}

		public bool RemoveProfanity(List<string> profanities)
		{
			if (profanities == null)
			{
				throw new ArgumentNullException("profanities");
			}
			foreach (string profanity in profanities)
			{
				if (!RemoveProfanity(profanity))
				{
					return false;
				}
			}
			return true;
		}

		public bool RemoveProfanity(string[] profanities)
		{
			if (profanities == null)
			{
				throw new ArgumentNullException("profanities");
			}
			foreach (string profanity in profanities)
			{
				if (!RemoveProfanity(profanity))
				{
					return false;
				}
			}
			return true;
		}

		public void Clear()
		{
			_profanities.Clear();
		}
	}
}
