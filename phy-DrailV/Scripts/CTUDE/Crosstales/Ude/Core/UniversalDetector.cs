namespace Crosstales.Ude.Core
{
	public abstract class UniversalDetector
	{
		protected const int FILTER_CHINESE_SIMPLIFIED = 1;

		protected const int FILTER_CHINESE_TRADITIONAL = 2;

		protected const int FILTER_JAPANESE = 4;

		protected const int FILTER_KOREAN = 8;

		protected const int FILTER_NON_CJK = 16;

		protected const int FILTER_ALL = 31;

		protected static int FILTER_CHINESE = 3;

		protected static int FILTER_CJK = 15;

		protected const float SHORTCUT_THRESHOLD = 0.95f;

		protected const float MINIMUM_THRESHOLD = 0.2f;

		internal InputState inputState;

		protected bool start;

		protected bool gotData;

		protected bool done;

		protected byte lastChar;

		protected int bestGuess;

		protected const int PROBERS_NUM = 3;

		protected int languageFilter;

		protected CharsetProber[] charsetProbers = new CharsetProber[3];

		protected CharsetProber escCharsetProber;

		protected string detectedCharset;

		public UniversalDetector(int languageFilter)
		{
			start = true;
			inputState = InputState.PureASCII;
			lastChar = 0;
			bestGuess = -1;
			this.languageFilter = languageFilter;
		}

		public virtual void Feed(byte[] buf, int offset, int len)
		{
			if (done)
			{
				return;
			}
			if (len > 0)
			{
				gotData = true;
			}
			if (start)
			{
				start = false;
				if (len > 3)
				{
					switch (buf[0])
					{
					case 239:
						if (187 == buf[1] && 191 == buf[2])
						{
							detectedCharset = "UTF-8";
						}
						break;
					case 254:
						if (byte.MaxValue == buf[1] && buf[2] == 0 && buf[3] == 0)
						{
							detectedCharset = "X-ISO-10646-UCS-4-3412";
						}
						else if (byte.MaxValue == buf[1])
						{
							detectedCharset = "UTF-16BE";
						}
						break;
					case 0:
						if (buf[1] == 0 && 254 == buf[2] && byte.MaxValue == buf[3])
						{
							detectedCharset = "UTF-32BE";
						}
						else if (buf[1] == 0 && byte.MaxValue == buf[2] && 254 == buf[3])
						{
							detectedCharset = "X-ISO-10646-UCS-4-2143";
						}
						break;
					case byte.MaxValue:
						if (254 == buf[1] && buf[2] == 0 && buf[3] == 0)
						{
							detectedCharset = "UTF-32LE";
						}
						else if (254 == buf[1])
						{
							detectedCharset = "UTF-16LE";
						}
						break;
					}
				}
				if (detectedCharset != null)
				{
					done = true;
					return;
				}
			}
			for (int i = 0; i < len; i++)
			{
				if ((buf[i] & 0x80) != 0 && buf[i] != 160)
				{
					if (inputState != InputState.Highbyte)
					{
						inputState = InputState.Highbyte;
						if (escCharsetProber != null)
						{
							escCharsetProber = null;
						}
						if (charsetProbers[0] == null)
						{
							charsetProbers[0] = new MBCSGroupProber();
						}
						if (charsetProbers[1] == null)
						{
							charsetProbers[1] = new SBCSGroupProber();
						}
						if (charsetProbers[2] == null)
						{
							charsetProbers[2] = new Latin1Prober();
						}
					}
				}
				else
				{
					if (inputState == InputState.PureASCII && (buf[i] == 27 || (buf[i] == 123 && lastChar == 126)))
					{
						inputState = InputState.EscASCII;
					}
					lastChar = buf[i];
				}
			}
			switch (inputState)
			{
			case InputState.EscASCII:
				if (escCharsetProber == null)
				{
					escCharsetProber = new EscCharsetProber();
				}
				if (escCharsetProber.HandleData(buf, offset, len) == ProbingState.FoundIt)
				{
					done = true;
					detectedCharset = escCharsetProber.GetCharsetName();
				}
				break;
			case InputState.Highbyte:
			{
				for (int j = 0; j < 3; j++)
				{
					if (charsetProbers[j] != null && charsetProbers[j].HandleData(buf, offset, len) == ProbingState.FoundIt)
					{
						done = true;
						detectedCharset = charsetProbers[j].GetCharsetName();
						break;
					}
				}
				break;
			}
			}
		}

		public virtual void DataEnd()
		{
			if (!gotData)
			{
				return;
			}
			if (detectedCharset != null)
			{
				done = true;
				Report(detectedCharset, 1f);
			}
			else if (inputState == InputState.Highbyte)
			{
				float num = 0f;
				float num2 = 0f;
				int num3 = 0;
				for (int i = 0; i < 3; i++)
				{
					if (charsetProbers[i] != null)
					{
						num = charsetProbers[i].GetConfidence();
						if (num > num2)
						{
							num2 = num;
							num3 = i;
						}
					}
				}
				if (num2 > 0.2f)
				{
					Report(charsetProbers[num3].GetCharsetName(), num2);
				}
			}
			else if (inputState == InputState.PureASCII)
			{
				Report("ASCII", 1f);
			}
		}

		public virtual void Reset()
		{
			done = false;
			start = true;
			detectedCharset = null;
			gotData = false;
			bestGuess = -1;
			inputState = InputState.PureASCII;
			lastChar = 0;
			if (escCharsetProber != null)
			{
				escCharsetProber.Reset();
			}
			for (int i = 0; i < 3; i++)
			{
				if (charsetProbers[i] != null)
				{
					charsetProbers[i].Reset();
				}
			}
		}

		protected abstract void Report(string charset, float confidence);
	}
}
