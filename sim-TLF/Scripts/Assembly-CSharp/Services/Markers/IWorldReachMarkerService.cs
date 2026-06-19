using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Services.Markers
{
	public interface IWorldReachMarkerService
	{
		UniTask<WorldMarkerObjectView> CreateMarker(Vector3 pos);
	}
}
