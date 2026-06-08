using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/GameSessionConfig", fileName = "GameSessionConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class GameSessionConfig : ScriptableObject
	{
		public EntityManagerConfig items;
	}
}
