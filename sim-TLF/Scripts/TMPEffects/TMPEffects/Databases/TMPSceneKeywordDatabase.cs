using TMPEffects.ObjectChanged;
using TMPEffects.Parameters;
using TMPEffects.SerializedCollections;
using UnityEngine;

namespace TMPEffects.Databases
{
	public sealed class TMPSceneKeywordDatabase : TMPSceneKeywordDatabaseBase, ITMPKeywordDatabase, INotifyObjectChanged
	{
		[SerializeField]
		private SerializedDictionary<string, float> floatKeywords;

		[SerializeField]
		private SerializedDictionary<string, int> intKeywords;

		[SerializeField]
		private SerializedDictionary<string, bool> boolKeywords;

		[SerializeField]
		private SerializedDictionary<string, Color> colorKeywords;

		[SerializeField]
		private SerializedDictionary<string, Vector3> vector3Keywords;

		[SerializeField]
		private SerializedDictionary<string, Vector2> anchorKeywords;

		[SerializeField]
		private SerializedDictionary<string, AnimationCurve> animationCurveKeywords;

		[SerializeField]
		private SerializedDictionary<string, SceneOffsetTypePowerEnum> offsetTypeKeywords;

		[SerializeField]
		private SerializedDictionary<string, Object> unityObjectKeywords;

		[SerializeField]
		private SerializedDictionary<string, SceneOffsetTypePowerEnum> OffsetProviderDict = new SerializedDictionary<string, SceneOffsetTypePowerEnum>();

		public event ObjectChangedEventHandler ObjectChanged;

		public override bool TryGetFloat(string str, out float result)
		{
			return floatKeywords.TryGetValue(str, out result);
		}

		public override bool TryGetInt(string str, out int result)
		{
			return intKeywords.TryGetValue(str, out result);
		}

		public override bool TryGetBool(string str, out bool result)
		{
			return boolKeywords.TryGetValue(str, out result);
		}

		public override bool TryGetColor(string str, out Color result)
		{
			return colorKeywords.TryGetValue(str, out result);
		}

		public override bool TryGetVector3(string str, out Vector3 result)
		{
			return vector3Keywords.TryGetValue(str, out result);
		}

		public override bool TryGetAnchor(string str, out Vector2 result)
		{
			return anchorKeywords.TryGetValue(str, out result);
		}

		public override bool TryGetAnimCurve(string str, out AnimationCurve result)
		{
			return animationCurveKeywords.TryGetValue(str, out result);
		}

		public override bool TryGetUnityObject(string str, out Object result)
		{
			return unityObjectKeywords.TryGetValue(str, out result);
		}

		private void OnValidate()
		{
			RaiseDatabaseChanged();
		}

		private void OnDestroy()
		{
			RaiseDatabaseChanged();
		}

		private void RaiseDatabaseChanged()
		{
			this.ObjectChanged?.Invoke(this);
		}

		public override bool TryGetOffsetProvider(string str, out ITMPOffsetProvider result)
		{
			SceneOffsetTypePowerEnum value;
			bool result2 = OffsetProviderDict.TryGetValue(str, out value);
			result = value;
			return result2;
		}
	}
}
