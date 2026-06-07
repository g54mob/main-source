using System.Collections.Generic;

namespace Tabletop.GameWorld
{
	public struct WargameState
	{
		public readonly bool playerAPlaying;

		public readonly bool[] squadAAlive;

		public readonly bool[] squadBAlive;

		public readonly int playerALife;

		public readonly int playerBLife;

		public readonly int playerATokens;

		public readonly int playerABet;

		public readonly int playerBTokens;

		public readonly int playerBBet;

		public readonly int playerAAssault;

		public readonly int playerADamage;

		public readonly int playerBAssault;

		public readonly int playerBDamage;

		public readonly float playerADice1Value;

		public readonly float playerADice2Value;

		public readonly float playerADice3Value;

		public readonly float playerBDice1Value;

		public readonly float playerBDice2Value;

		public readonly float playerBDice3Value;

		public readonly bool[] playerAActivatedMiniatures;

		public readonly bool[] playerBActivatedMiniatures;

		public readonly int[] playerAActivationBonuses;

		public readonly int[] playerBActivationBonuses;

		public readonly List<int> usedDices;

		public WargameState(bool playerAPlaying, bool[] squadAAlive, bool[] squadBAlive, int playerALife, int playerBLife, int playerATokens, int playerABet, int playerBTokens, int playerBBet, int playerAAssault, int playerADamage, int playerBAssault, int playerBDamage, float playerADice1Value, float playerADice2Value, float playerADice3Value, float playerBDice1Value, float playerBDice2Value, float playerBDice3Value, bool[] playerAActivatedMiniatures, bool[] playerBActivatedMiniatures, int[] playerAActivationBonuses, int[] playerBActivationBonuses, List<int> usedDices)
		{
			this.playerAPlaying = playerAPlaying;
			this.squadAAlive = new bool[squadAAlive.Length];
			squadAAlive.CopyTo(this.squadAAlive, 0);
			this.squadBAlive = new bool[squadBAlive.Length];
			squadBAlive.CopyTo(this.squadBAlive, 0);
			this.playerALife = playerALife;
			this.playerBLife = playerBLife;
			this.playerATokens = playerATokens;
			this.playerABet = playerABet;
			this.playerBTokens = playerBTokens;
			this.playerBBet = playerBBet;
			this.playerAAssault = playerAAssault;
			this.playerADamage = playerADamage;
			this.playerBAssault = playerBAssault;
			this.playerBDamage = playerBDamage;
			this.playerADice1Value = playerADice1Value;
			this.playerADice2Value = playerADice2Value;
			this.playerADice3Value = playerADice3Value;
			this.playerBDice1Value = playerBDice1Value;
			this.playerBDice2Value = playerBDice2Value;
			this.playerBDice3Value = playerBDice3Value;
			this.playerAActivatedMiniatures = new bool[playerAActivatedMiniatures.Length];
			playerAActivatedMiniatures.CopyTo(this.playerAActivatedMiniatures, 0);
			this.playerBActivatedMiniatures = new bool[playerBActivatedMiniatures.Length];
			playerBActivatedMiniatures.CopyTo(this.playerBActivatedMiniatures, 0);
			this.playerAActivationBonuses = new int[playerAActivationBonuses.Length];
			playerAActivationBonuses.CopyTo(this.playerAActivationBonuses, 0);
			this.playerBActivationBonuses = new int[playerBActivationBonuses.Length];
			playerBActivationBonuses.CopyTo(this.playerBActivationBonuses, 0);
			this.usedDices = new List<int>(usedDices);
		}
	}
}
