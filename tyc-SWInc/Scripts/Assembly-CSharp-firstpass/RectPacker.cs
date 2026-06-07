using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RectPacker<T>
{
	public Vector2 FullSize;

	public Dictionary<T, List<Rect>> Items = new Dictionary<T, List<Rect>>();

	private List<T> _notPacked = new List<T>();

	private Func<T, Vector2> GetSize;

	private List<Rect> _subSpaces = new List<Rect>();

	private int _margin;

	private bool _canResize = true;

	public RectPacker(Vector2 maxSize)
	{
		FullSize = maxSize;
		_subSpaces.Add(new Rect(0f, 0f, FullSize.x, FullSize.y));
		_canResize = false;
	}

	public RectPacker(Func<T, Vector2> sizeFunc, int margin)
	{
		GetSize = sizeFunc;
		_margin = margin;
	}

	public void AddItem(T item)
	{
		_notPacked.Add(item);
	}

	public Rect AddItemInstant(T item, Vector2 size)
	{
		Rect rect = PackItem(size);
		Rect rect2 = new Rect(rect.x + (float)_margin, rect.y + (float)_margin, rect.width - (float)(_margin * 2), rect.height - (float)(_margin * 2));
		Append(item, rect2);
		return rect2;
	}

	public void Append(T key, Rect element)
	{
		List<Rect> value;
		if (!Items.TryGetValue(key, out value))
		{
			value = new List<Rect>();
			Items[key] = value;
		}
		value.Add(element);
	}

	public void RemoveItem(T item)
	{
		List<Rect> value;
		if (Items.TryGetValue(item, out value))
		{
			Items.Remove(item);
			for (int i = 0; i < value.Count; i++)
			{
				_subSpaces.Add(value[i]);
			}
			TryMerge();
		}
	}

	private void TryMerge()
	{
		for (int i = 0; i < _subSpaces.Count; i++)
		{
			Rect rect = _subSpaces[i];
			for (int j = i + 1; j < _subSpaces.Count; j++)
			{
				Rect rect2 = _subSpaces[j];
				if ((rect.xMin == rect2.xMin && rect.xMax == rect2.xMax && (rect.yMin == rect2.yMax || rect.yMax == rect2.yMin)) || (rect.yMin == rect2.yMin && rect.yMax == rect2.yMax && (rect.xMin == rect2.xMax || rect.xMax == rect2.xMin)))
				{
					Vector2 vector = Vector2.Min(rect.min, rect2.min);
					Vector2 vector2 = Vector2.Max(rect.max, rect2.max);
					Rect item = Rect.MinMaxRect(vector.x, vector.y, vector2.x, vector2.y);
					_subSpaces.RemoveAt(j);
					_subSpaces.RemoveAt(i);
					_subSpaces.Add(item);
					i = -1;
					break;
				}
			}
		}
	}

	public void Pack()
	{
		foreach (KeyValuePair<T, Vector2> item in from x in _notPacked.ToDictionary((T x) => x, (T x) => GetSize(x))
			orderby Mathf.Max(x.Value.x, x.Value.y) descending
			select x)
		{
			Rect rect = PackItem(item.Value);
			Append(item.Key, new Rect(rect.x + (float)_margin, rect.y + (float)_margin, rect.width - (float)(_margin * 2), rect.height - (float)(_margin * 2)));
		}
	}

	public IEnumerator Pack(Action<Rect, Vector2, List<Rect>> update, float delay)
	{
		foreach (KeyValuePair<T, Vector2> item in from x in _notPacked.ToDictionary((T x) => x, (T x) => GetSize(x))
			orderby Mathf.Max(x.Value.x, x.Value.y) descending
			select x)
		{
			Rect rect = PackItem(item.Value);
			Rect rect2 = new Rect(rect.x + (float)_margin, rect.y + (float)_margin, rect.width - (float)(_margin * 2), rect.height - (float)(_margin * 2));
			update(rect2, FullSize, _subSpaces);
			Append(item.Key, rect2);
			yield return new WaitForSeconds(delay);
		}
	}

	private Rect PackItem(Vector2 item)
	{
		Vector2 vector = item + Vector2.one * _margin * 2f;
		if (_canResize && Items.Count == 0)
		{
			FullSize = vector;
			return new Rect(0f, 0f, vector.x, vector.y);
		}
		int num = FindSpace(vector);
		if (num > -1)
		{
			Rect space = _subSpaces[num];
			_subSpaces.RemoveAt(num);
			return SplitSpace(vector, space);
		}
		if (_canResize)
		{
			if (FullSize.x + vector.x < FullSize.y + vector.y)
			{
				if (vector.y > FullSize.y)
				{
					AddSpace(new Rect(0f, FullSize.y, FullSize.x, vector.y - FullSize.y));
					FullSize = new Vector2(FullSize.x, vector.y);
				}
				Rect result = SplitSpace(space: new Rect(FullSize.x, 0f, vector.x, FullSize.y), item: vector);
				FullSize = new Vector2(FullSize.x + vector.x, FullSize.y);
				return result;
			}
			if (vector.x > FullSize.x)
			{
				AddSpace(new Rect(FullSize.x, 0f, vector.x - FullSize.x, FullSize.y));
				FullSize = new Vector2(vector.x, FullSize.y);
			}
			Rect result2 = SplitSpace(space: new Rect(0f, FullSize.y, FullSize.x, vector.y), item: vector);
			FullSize = new Vector2(FullSize.x, FullSize.y + vector.y);
			return result2;
		}
		throw new Exception("No more space in atlas to add rectangle");
	}

	private int FindSpace(Vector2 size)
	{
		if (_subSpaces.Count == 0)
		{
			return -1;
		}
		for (int num = _subSpaces.Count - 1; num >= 0; num--)
		{
			Rect rect = _subSpaces[num];
			if (rect.width >= size.x && rect.height >= size.y)
			{
				return num;
			}
		}
		return -1;
	}

	private Rect SplitSpace(Vector2 item, Rect space)
	{
		Vector2 vector = new Vector2(space.x + item.x, space.y + item.y);
		if (space.x - item.x > space.y - item.y)
		{
			AddSpace(new Rect(vector.x, space.y, space.width - item.x, item.y));
			AddSpace(new Rect(space.x, vector.y, space.width, space.height - item.y));
		}
		else
		{
			AddSpace(new Rect(vector.x, space.y, space.width - item.x, space.height));
			AddSpace(new Rect(space.x, vector.y, item.x, space.height - item.y));
		}
		return new Rect(space.x, space.y, item.x, item.y);
	}

	private void AddSpace(Rect space)
	{
		if (space.width == 0f || space.height == 0f)
		{
			return;
		}
		float num = space.width * space.height;
		for (int i = 0; i < _subSpaces.Count; i++)
		{
			float num2 = _subSpaces[i].width * _subSpaces[i].height;
			if (num > num2)
			{
				_subSpaces.Insert(i, space);
				return;
			}
		}
		_subSpaces.Add(space);
	}
}
