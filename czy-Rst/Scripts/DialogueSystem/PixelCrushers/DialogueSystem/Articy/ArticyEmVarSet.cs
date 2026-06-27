using System;

namespace PixelCrushers.DialogueSystem.Articy
{
	[Serializable]
	public class ArticyEmVarSet
	{
		public ArticyEmVars[] emVars;

		public ArticyEmVarSet()
		{
			InitializeEmVars();
		}

		public void InitializeEmVars()
		{
			emVars = new ArticyEmVars[4];
			for (int i = 0; i < 4; i++)
			{
				emVars[i] = new ArticyEmVars();
			}
		}
	}
}
