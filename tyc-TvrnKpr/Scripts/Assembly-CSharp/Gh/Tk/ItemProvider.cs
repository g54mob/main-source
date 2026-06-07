using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class ItemProvider : Service
	{
		public static HashSet<ItemProvider> AllItemProviders;

		[Header("Content throwing")]
		public bool canThrowIngredients;

		public float throwDistance;

		public override void Start()
		{
		}

		public abstract bool CanProvide(GameItemTemplate template, long amount, bool restrictToContainer);

		public virtual bool CanProvideTo(GameItemTemplate template, long amount, bool restrictToContainer, Actor actor)
		{
			return false;
		}

		public abstract float GetRating(GameItemTemplate template, int amount, bool includePlaceholderItems = false);

		public override void OnDestroy()
		{
		}
	}
}
