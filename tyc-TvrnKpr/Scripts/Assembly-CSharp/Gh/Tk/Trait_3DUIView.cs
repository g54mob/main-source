using System;
using System.Collections.Generic;
using Gh.Tk.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class Trait_3DUIView : BaseInteractable3DUIView, IUpdateable
	{
		public const string TraitIconPrefix = "3DUI_TraitBadgeIcon_";

		public const string TraitIconDefault = "3DUI_TraitBadgeIcon_default";

		public const string TraitBadgeDefault = "3DUI_TraitBadge_default";

		private static Dictionary<string, GameObject> _traitIconPrefabs;

		private GameObject _badge;

		private GameObject _icon;

		[FormerlySerializedAs("isDoneVisual")]
		[SerializeField]
		private GameObject _isDoneVisual;

		[FormerlySerializedAs("failedVisual")]
		[SerializeField]
		private GameObject _failedVisual;

		[SerializeField]
		private BaseProgressBar3DUIView _progressBar;

		private IAiComponentVisualInfo _currentAiComponentVisualInfo;

		private IAiComponentIsDoneInfo _currentAIComponentIsDoneInfo;

		private float _nextPeriodicTooltipUpdate;

		public static GameObject GetBadgeIconOrDefault(IAiComponentVisualInfo aiComponentVisualInfo)
		{
			return null;
		}

		public static GameObject GetBadgeIconOrDefault(string badgeName)
		{
			return null;
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public void SetAiComponentVisualInfo(IAiComponentVisualInfo aiComponentVisualInfo)
		{
		}

		public void SetAsTrait(string traitIconName)
		{
		}

		private void UpdateProgressBar()
		{
		}

		public void UpdateObject()
		{
		}

		private void TraitTooltipChanged(object sender, EventArgs e)
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
