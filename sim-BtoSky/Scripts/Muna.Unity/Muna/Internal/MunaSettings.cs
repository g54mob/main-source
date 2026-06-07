using System.Collections.Generic;
using UnityEngine;

namespace Muna.Internal
{
	[DefaultExecutionOrder(int.MinValue)]
	internal sealed class MunaSettings : ScriptableObject
	{
		public static MunaSettings Instance;

		[field: SerializeField]
		[field: HideInInspector]
		public string accessKey { get; private set; } = string.Empty;

		[field: SerializeField]
		[field: HideInInspector]
		public List<PredictionCache.CachedPrediction> cache { get; internal set; } = new List<PredictionCache.CachedPrediction>();

		public static MunaSettings Create(string accessKey)
		{
			MunaSettings munaSettings = ScriptableObject.CreateInstance<MunaSettings>();
			munaSettings.accessKey = accessKey;
			return munaSettings;
		}

		private void Awake()
		{
			if (!Application.isEditor)
			{
				Instance = this;
			}
		}
	}
}
