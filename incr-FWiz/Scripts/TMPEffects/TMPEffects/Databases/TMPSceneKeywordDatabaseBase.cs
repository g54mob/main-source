using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.Databases
{
	public abstract class TMPSceneKeywordDatabaseBase : MonoBehaviour, ITMPKeywordDatabase
	{
		public abstract bool TryGetFloat(string str, out float result);

		public abstract bool TryGetInt(string str, out int result);

		public abstract bool TryGetBool(string str, out bool result);

		public abstract bool TryGetColor(string str, out Color result);

		public abstract bool TryGetVector3(string str, out Vector3 result);

		public abstract bool TryGetAnchor(string str, out Vector2 result);

		public abstract bool TryGetAnimCurve(string str, out AnimationCurve result);

		public abstract bool TryGetUnityObject(string str, out Object obj);

		public abstract bool TryGetOffsetProvider(string str, out ITMPOffsetProvider result);
	}
}
