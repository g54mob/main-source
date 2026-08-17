using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Rewired.Glyphs.UnityUI;

public abstract class UnityUIPlayerControllerElementGlyphBase : UnityUIControllerElementGlyphBase
{
	private ControllerElementGlyphSelectorOptionsSOBase _options;

	private AxisRange _actionRange;

	private Transform _group1;

	private Transform _group2;

	[NonSerialized]
	private List<ActionElementMap> _tempAems;

	[NonSerialized]
	private List<ActionElementMap> _tempCombinedElementAems;

	[NonSerialized]
	private readonly List<GlyphOrTextObject> _group1Objects;

	[NonSerialized]
	private readonly List<GlyphOrTextObject> _group2Objects;

	public virtual ControllerElementGlyphSelectorOptionsSOBase options
	{
		get
		{
			return _options;
		}
		set
		{
			_options = value;
			base.RequireRebuild();
		}
	}

	public abstract int playerId { get; set; }

	public abstract int actionId { get; set; }

	public virtual AxisRange actionRange
	{
		get
		{
			return _actionRange;
		}
		set
		{
			_actionRange = value;
		}
	}

	public virtual Transform group1
	{
		get
		{
			return _group1;
		}
		set
		{
			_group1 = value;
			base.RequireRebuild();
		}
	}

	public virtual Transform group2
	{
		get
		{
			return _group2;
		}
		set
		{
			_group2 = value;
			base.RequireRebuild();
		}
	}

	protected virtual bool isMousePrioritizedOverKeyboard
	{
		get
		{
			bool flag = TryGetControllerTypeOrder(0, out var controllerType);
			bool flag2 = !flag;
			int num = 0;
			controllerType = ControllerType.Keyboard;
			if (!flag2)
			{
				do
				{
					if (0 != 1)
					{
						if (0 == 0)
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				while (TryGetControllerTypeOrder(num, out controllerType));
			}
			return false;
		}
	}

	protected virtual bool TryGetControllerTypeOrder(int index, out ControllerType controllerType)
	{
		//IL_004f: Expected I4, but got O
		ControllerElementGlyphSelectorOptions optionsOrDefault = GetOptionsOrDefault();
		if (optionsOrDefault != null)
		{
			return optionsOrDefault.TryGetControllerTypeOrder(index, out controllerType);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected override void Update()
	{
		base.Update();
		if (!ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			return;
		}
		int num = playerId;
		int num2 = actionId;
		AxisRange axisRange = actionRange;
		ControllerElementGlyphSelectorOptions optionsOrDefault = GetOptionsOrDefault();
		List<ActionElementMap> workingActionElementMaps = default(List<ActionElementMap>);
		ref ActionElementMap aemResult = default(ref ActionElementMap);
		ref ActionElementMap aemResult2 = default(ref ActionElementMap);
		if (GlyphTools.TryGetActionElementMaps(num, num2, axisRange, optionsOrDefault, workingActionElementMaps, out aemResult, out aemResult2))
		{
			ActionElementMap actionElementMap = default(ActionElementMap);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			if (actionElementMap != null)
			{
				if (actionElementMap2 == null)
				{
					bool flag = ShowBinding(actionElementMap);
				}
				else
				{
					bool flag2 = ShowSplitAxisBindings(actionElementMap, actionElementMap2);
				}
			}
			else if (actionElementMap2 != null)
			{
				bool flag3 = ShowBinding(actionElementMap2);
			}
		}
		else
		{
			Hide();
		}
	}

	protected override void ClearObjects()
	{
		List<GlyphOrTextObject> group1Objects = _group1Objects;
		int version = group1Objects._version + 1;
		group1Objects._version = version;
		group1Objects._size = 0;
		if (group1Objects._size > 0)
		{
			Array.Clear(group1Objects._items, 0, group1Objects._size);
		}
		List<GlyphOrTextObject> group2Objects = _group2Objects;
		int version2 = group2Objects._version + 1;
		group2Objects._version = version2;
		group2Objects._size = 0;
		if (group2Objects._size > 0)
		{
			Array.Clear(group2Objects._items, 0, group2Objects._size);
		}
		base.ClearObjects();
	}

	protected virtual bool ShowBinding(ActionElementMap actionElementMap)
	{
		if (actionElementMap != null)
		{
			Transform objectGroupTransform = GetObjectGroupTransform(0);
			int num = base.ShowGlyphsOrText(actionElementMap, objectGroupTransform, _group1Objects);
			EvaluateObjectVisibility();
			int num2 = num ^ num;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = num < 0;
			bool flag3 = num == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		return false;
	}

	protected virtual bool ShowSplitAxisBindings(ActionElementMap negativeAem, ActionElementMap positiveAem)
	{
		//IL_021d: Expected I4, but got O
		if (negativeAem == null && positiveAem == null)
		{
			return false;
		}
		int num2;
		if (negativeAem != null && positiveAem != null)
		{
			List<ActionElementMap> tempCombinedElementAems = _tempCombinedElementAems;
			if (_tempCombinedElementAems != null)
			{
				int version = tempCombinedElementAems._version + 1;
				tempCombinedElementAems._version = version;
				tempCombinedElementAems._size = 0;
				if (tempCombinedElementAems._size > 0)
				{
					Array.Clear(tempCombinedElementAems._items, 0, tempCombinedElementAems._size);
				}
				if (_tempCombinedElementAems != null)
				{
					_tempCombinedElementAems.Add(negativeAem);
					if (_tempCombinedElementAems != null)
					{
						_tempCombinedElementAems.Add(positiveAem);
						Transform objectGroupTransform = GetObjectGroupTransform(0);
						int num = ShowGlyphsOrText(_tempCombinedElementAems, objectGroupTransform, _group1Objects);
						bool flag = num != 0;
						num2 = num;
						if (!flag)
						{
							goto IL_01af;
						}
						goto IL_023d;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_01af;
		IL_023d:
		EvaluateObjectVisibility();
		int num3 = num2 ^ num2;
		int num4 = num2 & num3;
		bool flag2 = num4 < 0;
		bool flag3 = num2 < 0;
		bool flag4 = num2 == 0;
		bool flag5 = flag3 == flag2;
		bool flag6 = !flag4;
		return flag6 & flag5;
		IL_01af:
		Transform objectGroupTransform2 = GetObjectGroupTransform(0);
		int num5 = base.ShowGlyphsOrText(negativeAem, objectGroupTransform2, _group1Objects);
		Transform objectGroupTransform3 = GetObjectGroupTransform(1);
		int num6 = base.ShowGlyphsOrText(positiveAem, objectGroupTransform3, _group2Objects);
		num2 = num5 + num6;
		goto IL_023d;
	}

	protected override void EvaluateObjectVisibility()
	{
		base.EvaluateObjectVisibility();
		Transform objectGroupTransform = GetObjectGroupTransform(0);
		Transform objectGroupTransform2 = GetObjectGroupTransform(1);
		if (objectGroupTransform != objectGroupTransform2)
		{
			base.EvaluateObjectVisibility(objectGroupTransform, _group1Objects);
			base.EvaluateObjectVisibility(objectGroupTransform2, _group2Objects);
		}
		else
		{
			base.EvaluateObjectVisibility(objectGroupTransform);
		}
	}

	protected virtual int ShowGlyphsOrText(IList<ActionElementMap> bindings, Transform parent, List<GlyphOrTextObject> objects)
	{
		//IL_01db: Expected I4, but got O
		if (bindings != null)
		{
			if (base.IsAllowed(AllowedTypes.Glyphs) && ActionElementMap.TryGetCombinedElementIdentifierGlyph(bindings, out var result))
			{
				if (!base.CreateObjectsAsNeeded(parent, objects, 1))
				{
					goto IL_01c7;
				}
				if (objects != null)
				{
					GlyphOrTextObject glyphOrTextObject = objects.get_Item(0);
					if (glyphOrTextObject != null)
					{
						glyphOrTextObject.ShowGlyph(result);
						return 1;
					}
				}
			}
			else
			{
				if (!base.IsAllowed(AllowedTypes.Text) || !ActionElementMap.TryGetCombinedElementIdentifierName(bindings, out var result2) || !base.CreateObjectsAsNeeded(parent, objects, 1))
				{
					goto IL_01c7;
				}
				if (objects != null)
				{
					GlyphOrTextObject glyphOrTextObject2 = objects.get_Item(0);
					if (glyphOrTextObject2 != null)
					{
						glyphOrTextObject2.ShowText(result2);
						return 1;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		goto IL_01c7;
		IL_01c7:
		return 0;
	}

	protected override void Hide()
	{
		base.Hide();
		if (_group1 != null)
		{
			Transform transform = base.transform;
			if (_group1 != transform)
			{
				GameObject gameObject = _group1.gameObject;
				gameObject.SetActive(value: false);
			}
		}
		if (_group2 != null)
		{
			Transform transform2 = base.transform;
			if (_group2 != transform2)
			{
				GameObject gameObject2 = _group2.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
	}

	protected virtual Transform GetObjectGroupTransform(int groupIndex)
	{
		int num = default(int);
		if (num <= 1)
		{
			if (num == 0)
			{
				if (_group1 != null)
				{
					goto IL_0053;
				}
			}
			else
			{
				if (num != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					NotImplementedException ex = new NotImplementedException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
					throw ex;
				}
				if (_group1 != null)
				{
					if (!(_group2 == null))
					{
						return _group2;
					}
					if (!(_group1 == null))
					{
						goto IL_0053;
					}
				}
			}
			return base.transform;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex2;
		IL_0053:
		return _group1;
	}

	protected virtual ControllerElementGlyphSelectorOptions GetOptionsOrDefault()
	{
		if (_options != null)
		{
			if ((object)_options != null)
			{
				ControllerElementGlyphSelectorOptions controllerElementGlyphSelectorOptions = _options.options;
				if (controllerElementGlyphSelectorOptions != null)
				{
					goto IL_00fb;
				}
				Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ControllerElementGlyphSelectorOptions));
				if ((object)typeFromHandle != null)
				{
					string text = typeFromHandle.Name;
					string message = "Rewired: Options missing on " + text + ". Global default options will be used instead.";
					Debug.LogError(message);
					goto IL_00e8;
				}
			}
			goto IL_0157;
		}
		goto IL_00fb;
		IL_0157:
		return (ControllerElementGlyphSelectorOptions)(object)new NullReferenceException();
		IL_00e8:
		return ControllerElementGlyphSelectorOptions.defaultOptions;
		IL_00fb:
		if (!(_options != null))
		{
			goto IL_00e8;
		}
		if ((object)_options != null)
		{
			return _options.options;
		}
		goto IL_0157;
	}

	protected UnityUIPlayerControllerElementGlyphBase()
	{
		List<ActionElementMap> tempAems = new List<ActionElementMap>();
		_tempAems = tempAems;
		_tempCombinedElementAems = new List<ActionElementMap>();
		_group1Objects = new List<GlyphOrTextObject>();
		_group2Objects = new List<GlyphOrTextObject>();
		base._002Ector();
	}
}
