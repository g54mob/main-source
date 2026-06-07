using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class GameItemVisual : GameObjectX
	{
		public static HashSet<GameItemVisual> AllGameItemVisuals;

		public static EventHandler<EventArgs<GameItemVisual>> GameItemVisualAdded;

		public bool SuppressesTripping;

		private bool _highlightedParentGox;

		public GameObjectX ParentGameObjectX => null;

		public override void Start()
		{
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		protected override GameObject CreateUIModel()
		{
			return null;
		}

		public static void ClearIngredientVisuals(GameObject model)
		{
		}

		public static void HandleIngredientVisuals(GameObject model, GameItem gameItem)
		{
		}

		public static void HandleIngredientVisuals(GameObject model, Recipe recipe)
		{
		}

		public override void OnDestroy()
		{
		}

		public override void AddHighlight(Color? color = null)
		{
		}

		public override void RemoveHighlight()
		{
		}

		public override IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		public override IEnumerable<ContextMenuItem> GetAvailableManualJobs(Staff staff)
		{
			return null;
		}

		public override PrimaryClickAction GetPrimaryClickAction()
		{
			return null;
		}

		public override void Explode()
		{
		}

		public override void CatchFire(float startTemperature = 0.1f, Transform targetTransform = null)
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public override void PlaySoundEvent(string eventName)
		{
		}
	}
}
