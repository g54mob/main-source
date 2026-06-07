using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gh.Tk
{
	public abstract class TurnsIntoXTrait : IngredientTrait, IProgressTrait
	{
		[PersistenceOptIn]
		private float _percentage;

		private int _displayPercentage;

		private bool _transformed;

		protected float Percentage
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float ProgressPercentage => 0f;

		private int DisplayPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static event EventHandler<(string oldTemplate, string newTemplate)> GameItemTransformedEvent
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

		public static event EventHandler<(string oldTemplate, string newTemplate)> TransformProgressChangedEvent
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

		protected TurnsIntoXTrait()
		{
		}

		public TurnsIntoXTrait(GameObjectX owner)
		{
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		protected abstract string GetTargetKey();

		public bool TurnsIntoItemKey(string itemKey)
		{
			return false;
		}

		protected bool AreRequirementsMet(StringBuilder details = null)
		{
			return false;
		}

		protected abstract bool AreRequirementsMetInternal(StringBuilder details = null);

		public override void Update()
		{
		}

		public virtual void TransformItem()
		{
		}
	}
}
