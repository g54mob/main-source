using Assets.Nimbatus.Scripts.World.Terrain;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;

namespace Assets.Nimbatus.Scripts.WorldObjects
{
	public class WorldTerrainObject : NimbatusWorldObject
	{
		public EObjectPlacement Placement;

		public EObjectAmount Amount;

		public int AllowedAngle = 180;

		internal NimbatusTerrainChunk ParentTerrainChunk;

		public void SetParentChunk(NimbatusTerrainChunk nimbatusTerrainChunk)
		{
			ParentTerrainChunk = nimbatusTerrainChunk;
		}

		public int GetProbability(EFoliageDensity density)
		{
			int num = 0;
			switch (Amount)
			{
			case EObjectAmount.VeryLow:
				num = -10;
				break;
			case EObjectAmount.Low:
				num = -5;
				break;
			case EObjectAmount.Medium:
				num = 0;
				break;
			case EObjectAmount.High:
				num = 5;
				break;
			case EObjectAmount.Maximum:
				num = 10;
				break;
			}
			int num2 = 0;
			switch (density)
			{
			case EFoliageDensity.Low:
				num2 = 30;
				break;
			case EFoliageDensity.Medium:
				num2 = 50;
				break;
			case EFoliageDensity.High:
				num2 = 70;
				break;
			case EFoliageDensity.Maximum:
				num2 = 90;
				break;
			case EFoliageDensity.VeryLow:
				num2 = 15;
				break;
			}
			return num2 + num;
		}
	}
}
