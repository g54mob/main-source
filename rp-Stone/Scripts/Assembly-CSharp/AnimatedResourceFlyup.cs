using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedResourceFlyup : MonoBehaviour
{
	private class Flyup
	{
		public AsciiString label;

		public float drag = 0.92f;

		public float acceleration = 0.15f;

		public Vector2 pos;

		public Vector2 end;

		public Vector2 vel;

		public Action callback;

		public Flyup()
		{
			label = new AsciiString();
			label.alignment = AsciiString.Alignment.Center;
		}

		public void UpdateTic()
		{
			Vector2 normalized = (end - pos).normalized;
			vel *= drag;
			vel += normalized * acceleration;
			pos += vel;
			Vector2 rhs = end - pos;
			if (Vector2.Dot(normalized, rhs) < 0.5f && rhs.magnitude < 2f)
			{
				callback();
				callback = null;
			}
		}

		public void Draw(AsciiRenderProcedural r)
		{
			label.Draw(r, Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y / 2f));
		}
	}

	private float drag = 0.82f;

	private float acceleration = 0.4f;

	private List<Flyup> flyups = new List<Flyup>();

	private Stack<Flyup> pool = new Stack<Flyup>();

	public static AnimatedResourceFlyup singleton { get; private set; }

	public void UpdateTic()
	{
		for (int num = flyups.Count - 1; num >= 0; num--)
		{
			Flyup flyup = flyups[num];
			flyup.UpdateTic();
			if (flyup.callback == null)
			{
				flyups.RemoveAt(num);
				pool.Push(flyup);
			}
		}
	}

	public void Draw(AsciiRenderProcedural r)
	{
		for (int i = 0; i < flyups.Count; i++)
		{
			flyups[i].Draw(r);
		}
	}

	public void Show(string text, Color textColor, float startX, float startY, float endX, float endY, float startVelocityX, float startVelocityY, Action callback)
	{
		Flyup pooled = GetPooled();
		flyups.Add(pooled);
		pooled.label.SetValue(text);
		pooled.label.color = textColor;
		pooled.pos = new Vector2(startX, startY * 2f);
		pooled.end = new Vector2(endX, endY * 2f);
		pooled.vel = new Vector2(startVelocityX, startVelocityY * 2f);
		pooled.drag = drag;
		pooled.acceleration = acceleration;
		pooled.callback = callback;
	}

	private Flyup GetPooled()
	{
		if (pool.Count > 0)
		{
			return pool.Pop();
		}
		return new Flyup();
	}

	private void Awake()
	{
		singleton = this;
	}
}
