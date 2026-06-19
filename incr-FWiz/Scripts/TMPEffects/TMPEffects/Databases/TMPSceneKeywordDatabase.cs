using System.Runtime.CompilerServices;
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
		private SerializedDictionary<string, SceneOffsetTypePowerEnum> OffsetProviderDict;

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
