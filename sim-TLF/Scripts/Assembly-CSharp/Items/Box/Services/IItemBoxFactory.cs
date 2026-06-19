using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Items.Box.Services
{
	public interface IItemBoxFactory
	{
		UniTask<ItemBoxView> CreateItemBox(Vector3 worldPos, List<AssetReference> contentRefs);
	}
}
