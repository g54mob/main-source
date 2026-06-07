namespace App.Data
{
	public class Result
	{
		public string KeyName;

		public string Sprite;

		public int RC;

		public int GC;

		public int BC;

		public int RS;

		public int GS;

		public int BS;

		public int RT;

		public int GT;

		public int BT;

		public int Accuracy;

		public string words;

		public void InitEmpty()
		{
			RC = 1;
			GC = 1;
			BC = 1;
			RS = 1;
			GS = 1;
			BS = 1;
			RT = 1;
			GT = 1;
			BT = 1;
			Accuracy = 0;
			words = "";
			KeyName = "Sandbox";
		}
	}
}
