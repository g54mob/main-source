using UnityEngine;

namespace Motorways
{
	public struct TileEditResult
	{
		public TileEditResultCode resultCode;

		public TileEdit edit;

		public Vector2Int errorPosition;

		public static TileEditResult Success = new TileEditResult
		{
			resultCode = TileEditResultCode.Success
		};

		public static TileEditResult NotEnoughUpgrades = new TileEditResult
		{
			resultCode = TileEditResultCode.NotEnoughUpgrades
		};

		public static TileEditResult MotorwayTooShort = new TileEditResult
		{
			resultCode = TileEditResultCode.MotorwayTooShort
		};

		public bool IsSuccessful => resultCode == TileEditResultCode.Success;

		public static TileEditResult InvalidTileCoordinate(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.InvalidTileCoordinate,
				errorPosition = position
			};
		}

		public static TileEditResult CannotConnectToCarpark(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.CannotConnectToCarpark,
				errorPosition = position
			};
		}

		public static TileEditResult CannotConnectHouseToBridge(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.CannotConnectHouseToBridge,
				errorPosition = position
			};
		}

		public static TileEditResult CannotConnectHouseToTunnel(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.CannotConnectHouseToTunnel,
				errorPosition = position
			};
		}

		public static TileEditResult CannotConnectHouseToRail(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.CannotConnectHouseToRail,
				errorPosition = position
			};
		}

		public static TileEditResult CannotCreateBridge(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.CannotCreateBridge,
				errorPosition = position
			};
		}

		public static TileEditResult CannotCreateTunnel(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.CannotCreateTunnel,
				errorPosition = position
			};
		}

		public static TileEditResult CannotCreateCrossing(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.CannotCreateCrossing,
				errorPosition = position
			};
		}

		public static TileEditResult NotEnoughConcrete(Vector2Int position)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.NotEnoughConcrete,
				errorPosition = position
			};
		}
	}
}
