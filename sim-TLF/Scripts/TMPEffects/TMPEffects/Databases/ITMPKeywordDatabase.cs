using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.Databases
{
	public interface ITMPKeywordDatabase
	{
		bool TryGetFloat(string str, out float result);

		bool TryGetInt(string str, out int result);

		bool TryGetBool(string str, out bool result);

		bool TryGetColor(string str, out Color result);

		bool TryGetVector3(string str, out Vector3 result);

		bool TryGetAnchor(string str, out Vector2 result);

		bool TryGetAnimCurve(string str, out AnimationCurve result);

		bool TryGetUnityObject(string str, out Object obj);

		bool TryGetOffsetProvider(string str, out ITMPOffsetProvider result);
	}
}
