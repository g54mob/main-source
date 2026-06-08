using System;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSnow : AsciiSprite
{
	[Serializable]
	public class Layer
	{
		public string symbol = "·";

		public int particleCount = 10;

		public float velMinX = -2f;

		public float velMaxX = -2f;

		public float velMinY = 0.5f;

		public float velMaxY = 0.5f;

		public Color color = Color.white;

		private int _symbol;

		private string lastSymbol;

		private List<Vector4> particles = new List<Vector4>();

		private float lastVelMinX;

		private float lastVelMaxX;

		private float lastVelMinY;

		private float lastVelMaxY;

		public bool simulating { get; set; }

		public void Update(float deltaTime)
		{
			if (lastSymbol != symbol)
			{
				lastSymbol = symbol;
				if (symbol.Length >= 1)
				{
					_symbol = SpecialSymbols.Map(symbol[0]);
				}
			}
			if (lastVelMinX != velMinX || lastVelMaxX != velMaxX)
			{
				lastVelMinX = velMinX;
				lastVelMaxX = velMaxX;
				for (int i = 0; i < particles.Count; i++)
				{
					Vector4 value = particles[i];
					value.z = UnityEngine.Random.Range(velMinX, velMaxX);
					particles[i] = value;
				}
			}
			if (lastVelMinY != velMinY || lastVelMaxY != velMaxY)
			{
				lastVelMinY = velMinY;
				lastVelMaxY = velMaxY;
				for (int j = 0; j < particles.Count; j++)
				{
					Vector4 value2 = particles[j];
					value2.w = UnityEngine.Random.Range(velMinY, velMaxY);
					particles[j] = value2;
				}
			}
			for (int k = 0; k < particles.Count; k++)
			{
				Vector4 value3 = particles[k];
				value3.x += value3.z * deltaTime;
				value3.y += value3.w * deltaTime;
				particles[k] = value3;
			}
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			DoDraw(r, offsetX, offsetY, color);
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
		{
			DoDraw(r, offsetX, offsetY, color * colorMultiply);
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
		{
			DoDraw(r, offsetX, offsetY, color * colorMultiply * tint);
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
		{
			DoDraw(r, offsetX, offsetY, overrideForeground);
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
		{
			DoDraw(r, offsetX, offsetY, overrideForeground);
		}

		private void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY, Color _color)
		{
			int num = particleCount - particles.Count;
			for (int num2 = particles.Count - 1; num2 >= 0; num2--)
			{
				Vector4 value = particles[num2];
				int num3 = Mathf.RoundToInt(value.x);
				int num4 = Mathf.RoundToInt(value.y);
				if (num3 < 0 || num3 > r.width || num4 < 0 || num4 > r.height)
				{
					if (!simulating)
					{
						particles.RemoveAt(num2);
						continue;
					}
					if (num3 < 0)
					{
						value.x += r.width;
						value.y = UnityEngine.Random.Range(0f, (float)r.height + 1f);
					}
					if (num3 > r.width)
					{
						value.x -= r.width;
						value.y = UnityEngine.Random.Range(0f, (float)r.height + 1f);
					}
					if (num4 < 0)
					{
						value.x = UnityEngine.Random.Range(0f, (float)r.width + 1f);
						value.y += r.height;
					}
					if (num4 > r.height)
					{
						value.x = UnityEngine.Random.Range(0f, (float)r.width + 1f);
						value.y -= r.height;
					}
					value.z = UnityEngine.Random.Range(velMinX, velMaxX);
					value.w = UnityEngine.Random.Range(velMinY, velMaxY);
					particles[num2] = value;
				}
				r.SetCell(num3 + offsetX, num4 + offsetY, _symbol, _color);
			}
			if (num < 0)
			{
				particles.RemoveRange(0, -num);
			}
			while (num > 0 && simulating)
			{
				AddParticle(r.width, r.height);
				num--;
			}
		}

		private void AddParticle(int gridWidth, int gridHeight)
		{
			float x = UnityEngine.Random.Range(0f, (float)gridWidth + 1f);
			float y = UnityEngine.Random.Range(0f, (float)gridHeight + 1f);
			float z = UnityEngine.Random.Range(velMinX, velMaxX);
			float w = UnityEngine.Random.Range(velMinY, velMaxY);
			Vector4 item = new Vector4(x, y, z, w);
			particles.Add(item);
		}
	}

	public bool simulating = true;

	public Layer[] layers;

	private void Update()
	{
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].simulating = simulating;
			layers[i].Update(Utils.deltaTime);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].Draw(r, -pivotX, -pivotY);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
	{
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].Draw(r, -pivotX, -pivotY, colorMultiply);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].Draw(r, -pivotX, -pivotY, colorMultiply, tint);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].Draw(r, -pivotX, -pivotY, overrideForeground);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].Draw(r, -pivotX, -pivotY, overrideForeground, overrideBackground);
		}
	}

	private void Start()
	{
		for (int i = 0; i < layers.Length; i++)
		{
			layers[i].simulating = simulating;
		}
	}
}
