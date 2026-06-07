using System;
using System.Reflection;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	[Serializable]
	[Obfuscation(Exclude = true)]
	public class GameObjectTagCountProvider : APerformanceProvider
	{
		public const string CName = "GameObject Tag Count";

		[SerializeField]
		public string Tag = string.Empty;

		private int lastGameObjectCount;

		public override string Name => "GameObject Tag Count";

		public override bool IsSupported => true;

		public override string Unit => "";

		protected override void Awake()
		{
			base.Awake();
			lastGameObjectCount = TotalGameObjectCount();
			InvokeRepeating("UpdateTotalGameObjectCount", 0f, 0.5f);
		}

		private int TotalGameObjectCount()
		{
			return GameObject.FindGameObjectsWithTag(Tag).Length;
		}

		private void UpdateTotalGameObjectCount()
		{
			lastGameObjectCount = TotalGameObjectCount();
		}

		protected override float GetNextValue()
		{
			return lastGameObjectCount;
		}
	}
}
