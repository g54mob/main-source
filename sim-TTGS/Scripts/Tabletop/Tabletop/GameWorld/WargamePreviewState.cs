namespace Tabletop.GameWorld
{
	public struct WargamePreviewState
	{
		public readonly bool knowOpponentDices;

		public readonly bool[] squadAAlive;

		public readonly bool[] squadBAlive;

		public readonly int playerALife;

		public readonly bool playerALifeModified;

		public readonly int playerBLife;

		public readonly bool playerBLifeModified;

		public readonly int playerATokens;

		public readonly bool playerATokensModified;

		public readonly int playerABet;

		public readonly int playerBTokens;

		public readonly bool playerBTokensModified;

		public readonly int playerBBet;

		public readonly int playerAAssault;

		public readonly bool playerAAssaultModified;

		public readonly int playerADamage;

		public readonly bool playerADamageModified;

		public readonly int playerBAssault;

		public readonly bool playerBAssaultModified;

		public readonly int playerBDamage;

		public readonly bool playerBDamageModified;

		public readonly float playerADice1Value;

		public readonly bool playerADice1ValueModified;

		public readonly float playerADice2Value;

		public readonly bool playerADice2ValueModified;

		public readonly float playerADice3Value;

		public readonly bool playerADice3ValueModified;

		public readonly float playerBDice1Value;

		public readonly bool playerBDice1ValueModified;

		public readonly float playerBDice2Value;

		public readonly bool playerBDice2ValueModified;

		public readonly float playerBDice3Value;

		public readonly bool playerBDice3ValueModified;

		public readonly int[] playerAActivatedMiniatures;

		public readonly int[] playerBActivatedMiniatures;

		public WargamePreviewState(WargameState origin, WargameState previewResult, int[] playerAActivationCounter, int[] playerBActivationCounter, bool knowOpponentDices)
		{
			this.knowOpponentDices = knowOpponentDices;
			squadAAlive = new bool[previewResult.squadAAlive.Length];
			previewResult.squadAAlive.CopyTo(squadAAlive, 0);
			squadBAlive = new bool[previewResult.squadBAlive.Length];
			previewResult.squadBAlive.CopyTo(squadBAlive, 0);
			playerALife = previewResult.playerALife;
			playerALifeModified = previewResult.playerALife != origin.playerALife;
			playerBLife = previewResult.playerBLife;
			playerBLifeModified = previewResult.playerBLife != origin.playerBLife;
			playerATokens = origin.playerATokens;
			playerATokensModified = previewResult.playerATokens != origin.playerATokens;
			playerABet = origin.playerABet;
			playerBTokens = origin.playerBTokens;
			playerBTokensModified = previewResult.playerBTokens != origin.playerBTokens;
			playerBBet = origin.playerBBet;
			playerAAssault = previewResult.playerAAssault;
			playerAAssaultModified = previewResult.playerAAssault != origin.playerAAssault;
			playerADamage = previewResult.playerADamage;
			playerADamageModified = previewResult.playerADamage != origin.playerADamage;
			playerBAssault = previewResult.playerBAssault;
			playerBAssaultModified = previewResult.playerBAssault != origin.playerBAssault;
			playerBDamage = previewResult.playerBDamage;
			playerBDamageModified = previewResult.playerBDamage != origin.playerBDamage;
			playerADice1Value = previewResult.playerADice1Value;
			playerADice1ValueModified = previewResult.playerADice1Value != origin.playerADice1Value;
			playerADice2Value = previewResult.playerADice2Value;
			playerADice2ValueModified = previewResult.playerADice2Value != origin.playerADice2Value;
			playerADice3Value = previewResult.playerADice3Value;
			playerADice3ValueModified = previewResult.playerADice3Value != origin.playerADice3Value;
			playerBDice1Value = previewResult.playerBDice1Value;
			playerBDice1ValueModified = previewResult.playerBDice1Value != origin.playerBDice1Value;
			playerBDice2Value = previewResult.playerBDice2Value;
			playerBDice2ValueModified = previewResult.playerBDice2Value != origin.playerBDice2Value;
			playerBDice3Value = previewResult.playerBDice3Value;
			playerBDice3ValueModified = previewResult.playerBDice3Value != origin.playerBDice3Value;
			playerAActivatedMiniatures = new int[playerAActivationCounter.Length];
			playerAActivationCounter.CopyTo(playerAActivatedMiniatures, 0);
			playerBActivatedMiniatures = new int[playerBActivationCounter.Length];
			playerBActivationCounter.CopyTo(playerBActivatedMiniatures, 0);
		}
	}
}
