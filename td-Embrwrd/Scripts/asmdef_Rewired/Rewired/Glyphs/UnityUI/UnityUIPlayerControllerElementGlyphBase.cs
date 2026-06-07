using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Glyphs.UnityUI
{
	public abstract class UnityUIPlayerControllerElementGlyphBase : UnityUIControllerElementGlyphBase
	{
		public delegate int ResultSelectionHandler(IList<ActionElementMapPair> results);

		public delegate int Result2DSelectionHandler(IList<Pair<ActionElementMapPair>> results);

		[SerializeField]
		[Tooltip("Optional reference to an object that defines options. If blank, the global default options will be used.")]
		private ControllerElementGlyphSelectorOptionsSOBase _options;

		[SerializeField]
		[Tooltip("The range of the Action for which to show glyphs / text. This determines whether to show the glyph for an axis-type Action (ex: Move Horizontal), or the positive/negative pole of an Action (ex: Move Right). For button-type Actions, Full and Positive are equivalent. This value has no effect when displaying two Actions.")]
		private AxisRange _actionRange;

		[SerializeField]
		[Tooltip("Optional parent Transform of the first group of instantiated glyph / text objects. For a single Action query, if an axis-type Action is bound to multiple elements, the glyphs bound to the negative pole of the Action will be instantiated under this Transform. For a two Action query, if multiple glyphs are returned, the glyphs bound to the first Action will be instantiated under this Transform. If a single glyph is returned, it will be instantiated under this Transform as well.This allows you to separate results by negative / positive binding or Action 1 / Action 2 in order to stack glyph groups horizontally or vertically, for example. If an Action is only bound to one element, the glyph will be instantiated under this transform. If blank, objects will be created as children of this object's Transform.")]
		private Transform _group1;

		[SerializeField]
		[Tooltip("Optional parent Transform of the second group of instantiated glyph / text objects. For a single Action query, if an axis-type Action is bound to multiple elements, the glyphs bound to the positive pole of the Action will be instantiated under this Transform. For a two Action query, if multiple glyphs are returned, the glyphs bound to the second Action will be instantiated under this Transform unless there were no results found for the first Action, in which case they will be displayed under group1. Otherwise, if a single glyph is returned, it will be instantiated under group1.This allows you to separate results by negative / positive binding or Action 1 / Action 2 in order to stack glyph groups horizontally or vertically, for example. If an Action is only bound to one element, the glyph will be instantiated under group1 instead. If blank, objects will be created as children of either group1 if set or the object's Transform.")]
		private Transform _group2;

		[Tooltip("The index of the result to return. This can be used to return, for example, the second matching glpyh(s) instead of the first found. This will be ignored if you are using a custom result selector.")]
		[SerializeField]
		private int _resultIndex;

		[Tooltip("Determines the display order of split-axis and button glyphs for the first Action.When two glyphs for an axis-type action are displayed, this determines which pole is displayed first.")]
		[SerializeField]
		private Pole _action1FirstPole;

		[Tooltip("Determines the display order of split-axis and button glyphs for the second Action.When two glyphs for an axis-type action are displayed, this determines which pole is displayed first.")]
		[SerializeField]
		private Pole _action2FirstPole;

		[NonSerialized]
		private List<Pair<ActionElementMapPair>> _temp2dResults;

		[NonSerialized]
		private List<ActionElementMap> _tempCombinedElementAems;

		[NonSerialized]
		private List<ActionElementMapPair> _tempResults;

		[NonSerialized]
		private readonly List<GlyphOrTextObject> _group1Objects;

		[NonSerialized]
		private readonly List<GlyphOrTextObject> _group2Objects;

		[NonSerialized]
		private ResultSelectionHandler _resultSelectionHandler;

		[NonSerialized]
		private Result2DSelectionHandler _result2dSelectionHandler;

		public virtual ControllerElementGlyphSelectorOptionsSOBase options
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract int playerId { get; set; }

		public abstract int actionId { get; set; }

		public abstract int actionId2 { get; set; }

		public virtual AxisRange actionRange
		{
			get
			{
				return default(AxisRange);
			}
			set
			{
			}
		}

		public virtual Transform group1
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual Transform group2
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int resultIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public Pole action1FirstPole
		{
			get
			{
				return default(Pole);
			}
			set
			{
			}
		}

		public Pole action2FirstPole
		{
			get
			{
				return default(Pole);
			}
			set
			{
			}
		}

		public virtual ResultSelectionHandler resultSelectionHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual Result2DSelectionHandler result2dSelectionHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual bool isMousePrioritizedOverKeyboard => false;

		protected virtual bool TryGetControllerTypeOrder(int index, out ControllerType controllerType)
		{
			controllerType = default(ControllerType);
			return false;
		}

		protected override void Update()
		{
		}

		private static bool TryGetActionElementMaps(int playerId, int actionId, AxisRange actionRange, ControllerElementGlyphSelectorOptions options, int resultIndex, ResultSelectionHandler resultSelectionHandler, List<ActionElementMapPair> tempResults, out ActionElementMapPair result)
		{
			result = default(ActionElementMapPair);
			return false;
		}

		private static bool TryGetActionElementMaps(int playerId, int actionId, int actionId2, ControllerElementGlyphSelectorOptions options, int resultIndex, Result2DSelectionHandler resultSelectionHandler, List<Pair<ActionElementMapPair>> tempResults, out ActionElementMapPair action1Result, out ActionElementMapPair action2Result)
		{
			action1Result = default(ActionElementMapPair);
			action2Result = default(ActionElementMapPair);
			return false;
		}

		protected override void ClearObjects()
		{
		}

		protected virtual bool ShowBinding(ActionElementMap actionElementMap)
		{
			return false;
		}

		protected virtual bool ShowSplitAxisBindings(ActionElementMap negativeAem, ActionElementMap positiveAem)
		{
			return false;
		}

		protected virtual bool ShowAction2DBindings(ActionElementMapPair result1, ActionElementMapPair result2)
		{
			return false;
		}

		private int ShowAction2dBindings_ShowResultBindings(int groupIndex, Pole poleOrder, ActionElementMapPair result, ref int groupObjectCount)
		{
			return 0;
		}

		protected override void EvaluateObjectVisibility()
		{
		}

		protected virtual int ShowGlyphsOrText(IList<ActionElementMap> bindings, Transform parent, List<GlyphOrTextObject> objects)
		{
			return 0;
		}

		protected virtual int ShowGlyphsOrText(IList<ActionElementMap> bindings, Transform parent, List<GlyphOrTextObject> objects, ref int currentUsedObjectCount)
		{
			return 0;
		}

		protected override void Hide()
		{
		}

		protected virtual Transform GetObjectGroupTransform(int groupIndex)
		{
			return null;
		}

		protected virtual ControllerElementGlyphSelectorOptions GetOptionsOrDefault()
		{
			return null;
		}
	}
}
