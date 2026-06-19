using TMPEffects.ObjectChanged;
using TMPEffects.Parameters;
using TMPEffects.SerializedCollections;
using UnityEngine;

namespace TMPEffects.Databases
{
	[CreateAssetMenu(fileName = "new KeywordDatabase", menuName = "TMPEffects/Database/Keywords")]
	public sealed class TMPKeywordDatabase : TMPKeywordDatabaseBase, ITMPKeywordDatabase, INotifyObjectChanged
	{
		[SerializeField]
		internal SerializedDictionary<string, float> floatKeywords;

		[SerializeField]
		internal SerializedDictionary<string, int> intKeywords;

		[SerializeField]
		internal SerializedDictionary<string, bool> boolKeywords;

		[SerializeField]
		internal SerializedDictionary<string, Color> colorKeywords;

		[SerializeField]
		internal SerializedDictionary<string, Vector3> vector3Keywords;

		[SerializeField]
		internal SerializedDictionary<string, Vector2> anchorKeywords;

		[SerializeField]
		internal SerializedDictionary<string, AnimationCurve> animationCurveKeywords;

		[SerializeField]
		internal SerializedDictionary<string, OffsetTypePowerEnum> offsetTypeKeywords;

		[SerializeField]
		internal SerializedDictionary<string, Object> unityObjectKeywords;

		[SerializeField]
		private SerializedDictionary<string, OffsetTypePowerEnum> OffsetProviderDict = new SerializedDictionary<string, OffsetTypePowerEnum>();

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
			OffsetTypePowerEnum value;
			bool result2 = OffsetProviderDict.TryGetValue(str, out value);
			result = value;
			return result2;
		}
	}
}
