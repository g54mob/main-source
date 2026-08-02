using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[AssetCreator(typeof(MainAssetCategory))]
	[CreateAssetMenu(menuName = "GRP/Main/BookConfigEntry", fileName = "BookConfigEntry")]
	public class BookConfigEntry : ConfigEntry<BookConfig>
	{
	}
}
