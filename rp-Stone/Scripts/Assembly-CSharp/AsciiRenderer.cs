using System.Collections.Generic;
using UnityEngine;

public abstract class AsciiRenderer : MonoBehaviour
{
	public struct Clip
	{
		public int top;

		public int bottom;

		public int left;

		public int right;
	}

	public struct GridValue
	{
		public int value;

		public float remainder;

		public GridValue(int v, float r)
		{
			value = v;
			remainder = r;
		}
	}

	public int width = 46;

	public int height = 25;

	private Stack<Clip> clipStack = new Stack<Clip>();

	public Color defaultForegroundColor = Color.white;

	public Color defaultBackgroundColor = Color.black;

	private List<_IPostAsciiRendererEffect> postEffects = new List<_IPostAsciiRendererEffect>();

	public Clip clip { get; private set; }

	public void InvertDefaultColors()
	{
		Color color = defaultForegroundColor;
		defaultForegroundColor = defaultBackgroundColor;
		defaultBackgroundColor = color;
	}

	public abstract void SetCell(int x, int y, int value, bool skipSafety = false);

	public abstract void SetCell(int x, int y, int value, Color foreground, bool skipSafety = false);

	public abstract void SetCell(int x, int y, int value, Color foreground, Color background, bool skipSafety = false);

	public abstract void SetCell(int x, int y, char unicode, bool skipSafety = false);

	public abstract void SetCell(int x, int y, char unicode, Color foreground, bool skipSafety = false);

	public abstract void SetCell(int x, int y, char unicode, Color foreground, Color background, bool skipSafety = false);

	public abstract IAsciiCell GetCell(int x, int y, bool skipSafety = false);

	public abstract void Clear();

	public abstract void Push();

	public abstract GridValue GetColumnAt(float x);

	public abstract GridValue GetRowAt(float y);

	public virtual bool IsClipped(int x, int y)
	{
		if (x >= clip.left && x < width - clip.right && y >= clip.top)
		{
			return y >= height - clip.bottom;
		}
		return true;
	}

	public void PushClip(Clip c, bool computeIntersection = true)
	{
		if (computeIntersection)
		{
			c.top = Mathf.Max(c.top, clip.top);
			c.bottom = Mathf.Max(c.bottom, clip.bottom);
			c.left = Mathf.Max(c.left, clip.left);
			c.right = Mathf.Max(c.right, clip.right);
		}
		clipStack.Push(c);
		clip = c;
	}

	public void PopClip()
	{
		clipStack.Pop();
		if (clipStack.Count > 0)
		{
			clip = clipStack.Peek();
		}
		else
		{
			clip = default(Clip);
		}
	}

	public virtual void ResetClip()
	{
		while (clipStack.Count > 0)
		{
			clipStack.Pop();
		}
		clip = default(Clip);
	}

	public virtual void ApplyPostEffects()
	{
		for (int i = 0; i < postEffects.Count; i++)
		{
			postEffects[i].ApplyPostEffect(this);
		}
	}

	public void AddPostEffect(_IPostAsciiRendererEffect effect)
	{
		if (!postEffects.Contains(effect))
		{
			postEffects.Add(effect);
		}
	}

	public void RemovePostEffect(_IPostAsciiRendererEffect effect)
	{
		postEffects.Remove(effect);
	}
}
