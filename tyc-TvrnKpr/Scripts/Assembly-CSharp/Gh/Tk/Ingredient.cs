using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class Ingredient : GameItemCraftableBase
	{
		[PersistenceObjectReference]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private List<TooltipData> _craftLogSubTooltips;

		private static readonly string[] statLabels;

		[JsonIgnore]
		private float _spoilProgress;

		[JsonIgnore]
		private float _lastSpoilRateModifier;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _suspendSpoiling;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool HideSpoilOutcome;

		[JsonIgnore]
		private TooltipData _spoilOutcomeTooltip;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private string _spoilOutcomeId;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private float? _spoilRate;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int? _flavor;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int? _gross;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int? _tough;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int? _sweet;

		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private int? _pure;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new IngredientTemplate Template
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[JsonIgnore]
		public override int Stars => 0;

		[JsonIgnore]
		public float StarsF => 0f;

		[JsonIgnore]
		public new string FullNameKey => null;

		public List<string> CraftLog { get; set; }

		[JsonIgnore]
		public override int AveragePrice => 0;

		public float SpoilProgress
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float LastSpoilRateModifier
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public bool SuspendSpoiling
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public string SpoilOutcomeId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public float SpoilRate
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int flavor
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int gross
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int tough
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int sweet
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int pure
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<float>> SpoilProgressChanged
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

		public event EventHandler<EventArgs<float>> SpoilRateModifierChanged
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

		public event EventHandler<EventArgs<bool>> SuspendSpoilingChanged
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

		public Ingredient()
		{
		}

		public Ingredient(IngredientTemplate template, bool representsTemplate = false)
		{
		}

		protected override int GetCraftableTargetTier()
		{
			return 0;
		}

		public int CalculateEffectiveFlavor(StringBuilder details = null, bool ignoreModifiers = false)
		{
			return 0;
		}

		internal IDisposable RecordCraftEffect(string labelKey)
		{
			return null;
		}

		private void RecordCraftLogEntry(string labelKey, float[] oldAttributes, float[] newAttributes)
		{
		}

		public TooltipData GetTooltipDataForTemplateVariant(TooltipAlignment alignment = TooltipAlignment.Default)
		{
			return null;
		}

		public override TooltipData GetTooltipData(TooltipAlignment alignment = TooltipAlignment.Default)
		{
			return null;
		}

		private TooltipData CreateIngredientTooltip(TooltipAlignment alignment, bool useTemplateData)
		{
			return null;
		}

		public float CalculateEffectiveSpoilRateWithInheritance(StringBuilder details = null)
		{
			return 0f;
		}

		private void AppendCraftLog(StringBuilder sb)
		{
		}

		private void AppendRecipeDetails(StringBuilder sb)
		{
		}

		private void AppendUsageIconRow(StringBuilder tooltip)
		{
		}

		protected override void AppendUsedInTooltipData(out StringBuilderPool.DisposableStringBuilder sb)
		{
			sb = null;
		}

		private void AppendUsedInProcessesInfo(out StringBuilderPool.DisposableStringBuilder details)
		{
			details = null;
		}

		public Dictionary<string, List<(int, Func<TooltipData>)>> GetRaceFlavorRatingsPercentage()
		{
			return null;
		}

		public override float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public override int GetPrice()
		{
			return 0;
		}

		public override (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public override GameItem CreateCopy()
		{
			return null;
		}

		public string GetSpoilDurationTextKey()
		{
			return null;
		}

		public float GetSpoilEstimateInDaysF()
		{
			return 0f;
		}

		public bool UpdateSpoilProgress(float modifier)
		{
			return false;
		}

		public void ApplySpoilChaosEffect(bool isGood)
		{
		}

		public override void PlaceAtLocation(Vector3 position, Quaternion rotation, bool singleAccessPoint = false)
		{
		}
	}
}
