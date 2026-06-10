using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.UI
{
	[ExecuteInEditMode]
	public class LayoutGroupView : UIView
	{
		[SerializeField]
		private LayoutGroupItemView prefab;

		[SerializeField]
		private string prefabKey;

		public LayoutGroupItemView Prefab
		{
			get
			{
				if (!prefab)
				{
					return MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(prefabKey).GetComponent<LayoutGroupItemView>();
				}
				return prefab;
			}
		}

		public string PrefabKey => prefabKey;

		private void OnEnable()
		{
			if (prefab != null && string.IsNullOrEmpty(PrefabKey))
			{
				prefabKey = prefab.name;
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(10, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Base\\LayoutGroupView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(PrefabKey);
					messageBuilder.AppendLiteral(" key saved");
				}
				Log.Trace(messageBuilder);
			}
		}
	}
}
