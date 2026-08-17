using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Glyphs;

public abstract class ControllerElementGlyphBase : MonoBehaviour
{
	protected class GlyphOrTextObject
	{
		private GlyphOrTextBase _glyphOrText;

		private int _frame;

		private bool _isVisible;

		public virtual bool isVisible
		{
			get
			{
				return _isVisible;
			}
			protected set
			{
				_isVisible = value;
			}
		}

		public GlyphOrTextBase glyphOrText
		{
			get
			{
				return _glyphOrText;
			}
			set
			{
				_glyphOrText = value;
			}
		}

		public GlyphOrTextObject(GlyphOrTextBase glyphOrText)
		{
			_glyphOrText = glyphOrText;
		}

		public virtual void ShowGlyph(object glyph)
		{
			if (_glyphOrText != null)
			{
				_glyphOrText.ShowGlyph(glyph);
				int frameCount = Time.frameCount;
				_frame = frameCount;
				_isVisible = true;
			}
		}

		public virtual void ShowText(string text)
		{
			if (_glyphOrText != null)
			{
				_glyphOrText.ShowText(text);
				int frameCount = Time.frameCount;
				_frame = frameCount;
				_isVisible = true;
			}
		}

		public virtual void Hide()
		{
			bool flag = _glyphOrText == null;
			if (!flag && _isVisible != flag)
			{
				_glyphOrText.Hide();
				_isVisible = false;
			}
		}

		public virtual void HideIfIdle()
		{
			int frameCount = Time.frameCount;
			if (_frame != frameCount)
			{
				Hide();
			}
		}

		public virtual void Destroy()
		{
			if (_glyphOrText != null)
			{
				GameObject gameObject = _glyphOrText.gameObject;
				UnityEngine.Object.Destroy(gameObject);
				_glyphOrText = null;
				_isVisible = false;
			}
		}
	}

	public enum AllowedTypes
	{
		All,
		Glyphs,
		Text
	}

	private GameObject _glyphOrTextPrefab;

	private AllowedTypes _allowedTypes;

	[NonSerialized]
	private readonly List<GlyphOrTextObject> _entries;

	[NonSerialized]
	private List<object> _tempGlyphs;

	[NonSerialized]
	private GameObject _lastGlyphOrTextPrefab;

	public virtual GameObject glyphOrTextPrefab
	{
		get
		{
			return _glyphOrTextPrefab;
		}
		set
		{
			_glyphOrTextPrefab = value;
			RequireRebuild();
		}
	}

	public virtual AllowedTypes allowedTypes
	{
		get
		{
			return _allowedTypes;
		}
		set
		{
			_allowedTypes = value;
		}
	}

	protected List<GlyphOrTextObject> entries => _entries;

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void Update()
	{
		if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
		{
			GameObject glyphOrTextPrefabOrDefault = GetGlyphOrTextPrefabOrDefault();
			if (_lastGlyphOrTextPrefab != glyphOrTextPrefabOrDefault)
			{
				GameObject glyphOrTextPrefabOrDefault2 = GetGlyphOrTextPrefabOrDefault();
				_lastGlyphOrTextPrefab = glyphOrTextPrefabOrDefault2;
				RequireRebuild();
			}
		}
	}

	public virtual void RequireRebuild()
	{
		ClearObjects();
	}

	protected virtual void ClearObjects()
	{
		List<GlyphOrTextObject> list = _entries;
		int num = 0;
		int num2 = 0;
		List<GlyphOrTextObject> list2;
		while (true)
		{
			list2 = _entries;
			if (num2 >= list._size)
			{
				break;
			}
			GlyphOrTextObject glyphOrTextObject = list2.get_Item(num);
			if (glyphOrTextObject != null)
			{
				GlyphOrTextObject glyphOrTextObject2 = _entries.get_Item(num);
				glyphOrTextObject2.Destroy();
			}
			list = _entries;
			num++;
			num2 = num;
		}
		int version = list2._version + 1;
		list2._version = version;
		list2._size = 0;
		if (list2._size > 0)
		{
			Array.Clear(list2._items, 0, list2._size);
		}
		Hide();
	}

	protected virtual void EvaluateObjectVisibility()
	{
		List<GlyphOrTextObject> list = _entries;
		int num = 0;
		for (int num2 = 0; num2 < list._size; num2 = num)
		{
			GlyphOrTextObject glyphOrTextObject = _entries.get_Item(num);
			if (glyphOrTextObject != null)
			{
				GlyphOrTextObject glyphOrTextObject2 = _entries.get_Item(num);
				glyphOrTextObject2.HideIfIdle();
			}
			list = _entries;
			num++;
		}
	}

	protected virtual void EvaluateObjectVisibility(Transform transform)
	{
		EvaluateObjectVisibility(transform, _entries);
	}

	protected virtual void EvaluateObjectVisibility(Transform transform, List<GlyphOrTextObject> entries)
	{
		Transform transform2 = base.transform;
		if (!(transform != transform2))
		{
			return;
		}
		bool flag = false;
		int num = 0;
		int num2 = 0;
		while (num < entries._size)
		{
			GlyphOrTextObject glyphOrTextObject = entries.get_Item(num2);
			if (glyphOrTextObject.isVisible)
			{
				flag = true;
			}
			num2++;
			num = num2;
		}
		GameObject gameObject = transform.gameObject;
		bool activeSelf = gameObject.activeSelf;
		if (activeSelf != flag)
		{
			GameObject gameObject2 = transform.gameObject;
			gameObject2.SetActive(flag);
		}
	}

	protected virtual int ShowGlyphsOrText(ActionElementMap actionElementMap, Transform parent, List<GlyphOrTextObject> entries)
	{
		//IL_045b: Expected I4, but got O
		//IL_00df: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		List<object> tempGlyphs = _tempGlyphs;
		if (_tempGlyphs == null)
		{
			goto IL_044d;
		}
		int version = tempGlyphs._version + 1;
		tempGlyphs._version = version;
		tempGlyphs._size = 0;
		if (tempGlyphs._size > 0)
		{
			Array.Clear(tempGlyphs._items, 0, tempGlyphs._size);
		}
		int result;
		if (IsAllowed(AllowedTypes.Glyphs) && actionElementMap != null)
		{
			bool hasModifiers = actionElementMap.hasModifiers;
			bool flag = !hasModifiers;
			object obj = 1;
			if (!flag)
			{
				bool flag2 = actionElementMap._modifierKey1 == ModifierKey.None;
				bool flag3 = !flag2;
				object obj2 = (flag3 ? 1 : 0) + 1;
				object obj3 = obj2 + 1;
				if (actionElementMap._modifierKey2 == ModifierKey.None)
				{
					obj3 = obj2;
				}
				obj = obj3 + 1;
				if (actionElementMap._modifierKey3 == ModifierKey.None)
				{
					obj = obj3;
				}
			}
			int elementIdentifierGlyphCount = actionElementMap.elementIdentifierGlyphCount;
			if (elementIdentifierGlyphCount == (nint)obj)
			{
				int elementIdentifierGlyphs = actionElementMap.GetElementIdentifierGlyphs(_tempGlyphs);
				List<object> tempGlyphs2 = _tempGlyphs;
				if (_tempGlyphs != null)
				{
					if (!CreateObjectsAsNeeded(parent, entries, tempGlyphs2._size))
					{
						goto IL_043f;
					}
					List<object> tempGlyphs3 = _tempGlyphs;
					bool flag4 = _tempGlyphs == null;
					int num = 0;
					int num2 = 0;
					if (!flag4)
					{
						while (num < tempGlyphs3._size)
						{
							if (entries != null)
							{
								GlyphOrTextObject glyphOrTextObject = entries.get_Item(num2);
								if (_tempGlyphs != null)
								{
									object glyph = _tempGlyphs.get_Item(num2);
									if (glyphOrTextObject != null)
									{
										glyphOrTextObject.ShowGlyph(glyph);
										tempGlyphs3 = _tempGlyphs;
										num2++;
										if (_tempGlyphs != null)
										{
											num = num2;
											continue;
										}
									}
								}
							}
							goto IL_044d;
						}
						List<object> tempGlyphs4 = _tempGlyphs;
						if (_tempGlyphs != null)
						{
							result = tempGlyphs4._size;
							goto IL_04e3;
						}
					}
				}
				goto IL_044d;
			}
		}
		bool flag5 = IsAllowed(AllowedTypes.Text);
		bool flag6 = !flag5;
		result = 0;
		if (!flag6)
		{
			bool flag7 = actionElementMap == null;
			result = 0;
			if (!flag7)
			{
				if (!CreateObjectsAsNeeded(parent, entries, 1))
				{
					goto IL_043f;
				}
				if (entries != null)
				{
					GlyphOrTextObject glyphOrTextObject2 = entries.get_Item(0);
					string elementIdentifierName = actionElementMap.elementIdentifierName;
					if (glyphOrTextObject2 != null)
					{
						glyphOrTextObject2.ShowText(elementIdentifierName);
						result = 1;
						goto IL_04e3;
					}
				}
				goto IL_044d;
			}
		}
		goto IL_04e3;
		IL_044d:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
		IL_043f:
		return 0;
		IL_04e3:
		return result;
	}

	protected virtual int ShowGlyphsOrText(ActionElementMap actionElementMap)
	{
		Transform parent = base.transform;
		return ShowGlyphsOrText(actionElementMap, parent, _entries);
	}

	protected virtual int ShowGlyphsOrText(ControllerElementIdentifier elementIdentifier, AxisRange axisRange, Transform parent, List<GlyphOrTextObject> entries)
	{
		//IL_01ec: Expected I4, but got O
		int result;
		if (elementIdentifier != null)
		{
			List<GlyphOrTextObject> list = default(List<GlyphOrTextObject>);
			if (IsAllowed(AllowedTypes.Glyphs))
			{
				object glyph = elementIdentifier.GetGlyph(axisRange);
				if (glyph != null)
				{
					if (!CreateObjectsAsNeeded(parent, list, 1))
					{
						goto IL_01d0;
					}
					if (list != null)
					{
						GlyphOrTextObject glyphOrTextObject = list.get_Item(0);
						if (glyphOrTextObject != null)
						{
							glyphOrTextObject.ShowGlyph(glyph);
							result = 1;
							goto IL_020e;
						}
					}
					goto IL_01de;
				}
			}
			bool flag = IsAllowed(AllowedTypes.Text);
			bool flag2 = !flag;
			result = 0;
			if (flag2)
			{
				goto IL_020e;
			}
			if (CreateObjectsAsNeeded(parent, list, 1))
			{
				if (list != null)
				{
					GlyphOrTextObject glyphOrTextObject2 = list.get_Item(0);
					string displayName = elementIdentifier.GetDisplayName(axisRange);
					if (glyphOrTextObject2 != null)
					{
						glyphOrTextObject2.ShowText(displayName);
						return 1;
					}
				}
				goto IL_01de;
			}
		}
		goto IL_01d0;
		IL_01d0:
		return 0;
		IL_020e:
		return result;
		IL_01de:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	protected virtual int ShowGlyphsOrText(ControllerElementIdentifier elementIdentifier, AxisRange axisRange)
	{
		Transform parent = base.transform;
		return ShowGlyphsOrText(elementIdentifier, axisRange, parent, null);
	}

	protected virtual void Hide()
	{
		List<GlyphOrTextObject> list = _entries;
		int num = 0;
		for (int num2 = 0; num2 < list._size; num2 = num)
		{
			GlyphOrTextObject glyphOrTextObject = _entries.get_Item(num);
			if (glyphOrTextObject != null)
			{
				GlyphOrTextObject glyphOrTextObject2 = _entries.get_Item(num);
				glyphOrTextObject2.Hide();
			}
			list = _entries;
			num++;
		}
	}

	protected virtual GameObject GetGlyphOrTextPrefabOrDefault()
	{
		if (_glyphOrTextPrefab != null)
		{
			return _glyphOrTextPrefab;
		}
		return GetDefaultGlyphOrTextPrefab();
	}

	protected abstract GameObject GetDefaultGlyphOrTextPrefab();

	protected virtual bool CreateObjectsAsNeeded(Transform parent, List<GlyphOrTextObject> entries, int count)
	{
		//IL_027e: Expected I4, but got O
		if (count > 0)
		{
			GameObject glyphOrTextPrefabOrDefault = GetGlyphOrTextPrefabOrDefault();
			if (glyphOrTextPrefabOrDefault != null)
			{
				if (entries != null)
				{
					int num = entries._size;
					bool flag = entries._size >= count;
					Transform parent2 = parent;
					if (!flag)
					{
						while (true)
						{
							GameObject gameObject = UnityEngine.Object.Instantiate(glyphOrTextPrefabOrDefault);
							if ((object)gameObject != null)
							{
								gameObject.name = "Object";
								gameObject.hideFlags = HideFlags.DontSave;
								Transform transform = gameObject.transform;
								if ((object)transform != null)
								{
									transform.SetParent(parent2, worldPositionStays: false);
									GlyphOrTextBase component = gameObject.GetComponent<GlyphOrTextBase>();
									if (!(component == null))
									{
										GlyphOrTextObject glyphOrTextObject = new GlyphOrTextObject(null);
										glyphOrTextObject._glyphOrText = component;
										entries.Add(glyphOrTextObject);
										if (entries != _entries)
										{
											if (_entries == null)
											{
												goto IL_0270;
											}
											_entries.Add(glyphOrTextObject);
										}
									}
									else
									{
										Type type = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(GlyphOrTextBase));
										if ((object)type != null)
										{
											type = (Type)(object)type.ToString();
										}
										string message = "Rewired: Prefab does not contain a " + (string)(object)type + " component.";
										Debug.LogError(message);
										UnityEngine.Object.Destroy(gameObject);
									}
									num++;
									bool flag2 = num < count;
									parent2 = parent;
									if (!flag2)
									{
										break;
									}
									continue;
								}
							}
							goto IL_0270;
							IL_0270:
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
					}
					return true;
				}
			}
			else
			{
				Debug.LogError("Rewired: Default prefab is null.");
			}
		}
		return false;
	}

	protected virtual bool IsAllowed(AllowedTypes allowedType)
	{
		//IL_002e: Expected O, but got I4
		if (_allowedTypes != AllowedTypes.All)
		{
			object obj = allowedType - _allowedTypes;
			return obj == null;
		}
		return true;
	}

	protected static int GetGlyphs(ActionElementMap actionElementMap, List<object> results)
	{
		if (actionElementMap != null)
		{
			bool hasModifiers = actionElementMap.hasModifiers;
			bool flag = !hasModifiers;
			int num = 1;
			if (!flag)
			{
				bool flag2 = actionElementMap._modifierKey1 == ModifierKey.None;
				bool flag3 = !flag2;
				int num2 = (flag3 ? 1 : 0) + 1;
				int num3 = num2 + 1;
				if (actionElementMap._modifierKey2 == ModifierKey.None)
				{
					num3 = num2;
				}
				num = num3 + 1;
				if (actionElementMap._modifierKey3 == ModifierKey.None)
				{
					num = num3;
				}
			}
			int elementIdentifierGlyphCount = actionElementMap.elementIdentifierGlyphCount;
			if (elementIdentifierGlyphCount == num)
			{
				int elementIdentifierGlyphs = actionElementMap.GetElementIdentifierGlyphs(results);
				return num;
			}
		}
		return 0;
	}

	protected ControllerElementGlyphBase()
	{
		List<GlyphOrTextObject> list = new List<GlyphOrTextObject>();
		_entries = list;
		_tempGlyphs = new List<object>();
		base._002Ector();
	}
}
