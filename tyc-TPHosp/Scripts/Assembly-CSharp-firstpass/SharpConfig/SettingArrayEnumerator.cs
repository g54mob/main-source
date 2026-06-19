namespace SharpConfig
{
	internal sealed class SettingArrayEnumerator
	{
		private readonly string mStringValue;

		private readonly bool mShouldCalcElemString;

		private int mIdxInString;

		private readonly int mLastRBraceIdx;

		private int mPrevElemIdxInString;

		private int mBraceBalance;

		private bool mIsInQuotes;

		private bool mIsDone;

		public string Current { get; private set; }

		public bool IsValid { get; private set; }

		public SettingArrayEnumerator(string value, bool shouldCalcElemString)
		{
			mStringValue = value;
			mIdxInString = -1;
			mLastRBraceIdx = -1;
			mShouldCalcElemString = shouldCalcElemString;
			IsValid = true;
			mIsDone = false;
			for (int i = 0; i < value.Length; i++)
			{
				char c = value[i];
				if (c != ' ' && c != '{')
				{
					break;
				}
				if (c == '{')
				{
					mIdxInString = i + 1;
					mBraceBalance = 1;
					mPrevElemIdxInString = i + 1;
					break;
				}
			}
			if (mIdxInString < 0)
			{
				IsValid = false;
				mIsDone = true;
				return;
			}
			for (int num = value.Length - 1; num >= 0; num--)
			{
				char c2 = value[num];
				if (c2 != ' ' && c2 != '}')
				{
					break;
				}
				if (c2 == '}')
				{
					mLastRBraceIdx = num;
					break;
				}
			}
			if (mLastRBraceIdx < 0)
			{
				IsValid = false;
				mIsDone = true;
			}
			else if (mIdxInString == mLastRBraceIdx || !IsNonEmptyValue(mStringValue, mIdxInString, mLastRBraceIdx))
			{
				IsValid = true;
				mIsDone = true;
			}
		}

		public bool Next()
		{
			if (mIsDone)
			{
				return false;
			}
			int i;
			for (i = mIdxInString; i <= mLastRBraceIdx; i++)
			{
				char c = mStringValue[i];
				if (c == '{' && !mIsInQuotes)
				{
					mBraceBalance++;
				}
				else if (c == '}' && !mIsInQuotes)
				{
					mBraceBalance--;
					if (i == mLastRBraceIdx)
					{
						if (!IsNonEmptyValue(mStringValue, mPrevElemIdxInString, i))
						{
							IsValid = false;
						}
						else if (mShouldCalcElemString)
						{
							Current = mStringValue.Substring(mPrevElemIdxInString, i - mPrevElemIdxInString).Trim();
						}
						mIsDone = true;
						break;
					}
				}
				else if (c == '"')
				{
					int num = mStringValue.IndexOf('"', i + 1);
					if (num > 0)
					{
						i = num;
						mIsInQuotes = false;
					}
					else
					{
						mIsInQuotes = true;
					}
				}
				else if (c == Configuration.ArrayElementSeparator && mBraceBalance == 1 && !mIsInQuotes)
				{
					if (!IsNonEmptyValue(mStringValue, mPrevElemIdxInString, i))
					{
						IsValid = false;
					}
					else if (mShouldCalcElemString)
					{
						Current = mStringValue.Substring(mPrevElemIdxInString, i - mPrevElemIdxInString).Trim();
					}
					mPrevElemIdxInString = i + 1;
					i++;
					break;
				}
			}
			mIdxInString = i;
			if (mIsInQuotes)
			{
				IsValid = false;
			}
			return IsValid;
		}

		private static bool IsNonEmptyValue(string s, int begin, int end)
		{
			while (begin < end)
			{
				if (s[begin] != ' ')
				{
					return true;
				}
				begin++;
			}
			return false;
		}
	}
}
