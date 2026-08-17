using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class TextureReplacer : MonoBehaviour
{
	private List<Sprite> _Sprites;

	private List<string> _spriteNames;

	private Dictionary<string, Sprite> _spriteDic;

	private unsafe void Replace()
	{
		//IL_00cf: Expected I4, but got O
		//IL_00eb: Expected O, but got Ref
		if (_spriteDic != null)
		{
			_spriteDic.Clear();
		}
		if (_spriteNames != null)
		{
			List<string> spriteNames = _spriteNames;
			int version = spriteNames._version + 1;
			spriteNames._version = version;
			spriteNames._size = 0;
			if (spriteNames._size > 0)
			{
				Array.Clear(spriteNames._items, 0, spriteNames._size);
			}
		}
		Image[] array = UnityEngine.Object.FindObjectsOfType<Image>(includeInactive: true);
		System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)_Sprites;
		List<Sprite>.Enumerator enumerator = default(List<Sprite>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<object> spriteNames2 = (List<object>)(object)_spriteNames;
			List<Sprite>.Enumerator enumerator2 = (List<Sprite>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		int num = 0;
		for (int num2 = 0; num2 < array.Length; num2 = num)
		{
			Image image = array[num];
			Sprite sprite = image.m_Sprite;
			if ((object)image.m_Sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
			{
				string text = ((UnityEngine.Object)image.m_Sprite).GetName();
				int num3 = _spriteDic.FindEntry(text);
				if (num3 >= 0)
				{
					string text2 = ((UnityEngine.Object)image).GetName();
					string message = text2 + " : " + text;
					Debug.Log(message);
					Sprite sprite2 = _spriteDic.get_Item(text);
					image.sprite = sprite2;
					image.SetAllDirty();
					insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				}
			}
			num++;
		}
	}

	public TextureReplacer()
	{
		List<string> spriteNames = new List<string>();
		_spriteNames = spriteNames;
		Dictionary<string, Sprite> spriteDic = new Dictionary<string, Sprite>();
		_spriteDic = spriteDic;
	}
}
