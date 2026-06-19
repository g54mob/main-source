using System.Runtime.CompilerServices;
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
		private SerializedDictionary<string, OffsetTypePowerEnum> OffsetProviderDict;

		public event ObjectChangedEventHandler ObjectChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public override bool TryGetFloat(string str, out float result)
		{
			result = default(float);
			return false;
		}

		public override bool TryGetInt(string str, out int result)
		{
			result = default(int);
			return false;
		}

		public override bool TryGetBool(string str, out bool result)
		{
			result = default(bool);
			return false;
		}

		public override bool TryGetColor(string str, out Color result)
		{
			result = default(Color);
			return false;
		}

		public override bool TryGetVector3(string str, out Vector3 result)
		{
			result = default(Vector3);
			return false;
		}

		public override bool TryGetAnchor(string str, out Vector2 result)
		{
			result = default(Vector2);
			return false;
		}

		public override bool TryGetAnimCurve(string str, out AnimationCurve result)
		{
			result = null;
			return false;
		}

		public override bool TryGetUnityObject(string str, out Object result)
		{
			result = null;
			return false;
		}

		private void OnValidate()
		{
		}

		private void OnDestroy()
		{
		}

		private void RaiseDatabaseChanged()
		{
		}

		public override bool TryGetOffsetProvider(string str, out ITMPOffsetProvider result)
		{
			result = null;
			return false;
		}
	}
}
