namespace Crosstales.Ude.Core
{
	public class CodingStateMachine
	{
		private int currentState;

		private SMModel model;

		private int currentCharLen;

		private int currentBytePos;

		public int CurrentCharLen => currentCharLen;

		public string ModelName => model.Name;

		public CodingStateMachine(SMModel model)
		{
			currentState = 0;
			this.model = model;
		}

		public int NextState(byte b)
		{
			int num = model.GetClass(b);
			if (currentState == 0)
			{
				currentBytePos = 0;
				currentCharLen = model.charLenTable[num];
			}
			currentState = model.stateTable.Unpack(currentState * model.ClassFactor + num);
			currentBytePos++;
			return currentState;
		}

		public void Reset()
		{
			currentState = 0;
		}
	}
}
