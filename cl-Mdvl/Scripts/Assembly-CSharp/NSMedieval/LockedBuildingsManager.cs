using System.Collections.Generic;

namespace NSMedieval
{
	public static class LockedBuildingsManager
	{
		public static readonly HashSet<string> DefaultLockedBuildings = new HashSet<string>
		{
			"stone_chess_pawn", "stone_chess_rook", "stone_chess_knight", "stone_chess_bishop", "stone_chess_queen", "stone_chess_king", "wood_chess_pawn", "wood_chess_rook", "wood_chess_knight", "wood_chess_bishop",
			"wood_chess_queen", "wood_chess_king", "gold_chess_pawn", "gold_chess_rook", "gold_chess_knight", "gold_chess_bishop", "gold_chess_queen", "gold_chess_king", "silver_chess_pawn", "silver_chess_rook",
			"silver_chess_knight", "silver_chess_bishop", "silver_chess_queen", "silver_chess_king", "foxy_statue", "scarecrow", "sundial", "purple_torch", "purple_torch_wall", "purple_brazier"
		};

		public static readonly string[] ChessPieces = new string[24]
		{
			"stone_chess_pawn", "stone_chess_rook", "stone_chess_knight", "stone_chess_bishop", "stone_chess_queen", "stone_chess_king", "wood_chess_pawn", "wood_chess_rook", "wood_chess_knight", "wood_chess_bishop",
			"wood_chess_queen", "wood_chess_king", "gold_chess_pawn", "gold_chess_rook", "gold_chess_knight", "gold_chess_bishop", "gold_chess_queen", "gold_chess_king", "silver_chess_pawn", "silver_chess_rook",
			"silver_chess_knight", "silver_chess_bishop", "silver_chess_queen", "silver_chess_king"
		};

		public static readonly string[] EarlyAccessRewards = new string[1] { "foxy_statue" };
	}
}
