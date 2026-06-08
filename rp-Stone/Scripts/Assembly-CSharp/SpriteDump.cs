using System.Collections.Generic;
using UnityEngine;

public class SpriteDump : MonoBehaviour
{
	private struct TravelSprite
	{
		public AsciiSprite sprite;

		public Vector2 start;

		public Vector2 end;

		public int endX;

		public int endY;

		public float timeRemaining;
	}

	public int PositionX;

	public int PositionY;

	public float StartX;

	public float StartY;

	public float StartWidth = 10f;

	public float StartHeight = 10f;

	public float EndX;

	public float EndY = 20f;

	public float EndWidth = 10f;

	public float EndHeight = 10f;

	public float travelTime = 0.2f;

	public float totalTime = 2f;

	public int maxSprites = 200;

	private Dictionary<AsciiSprite, int> spritesRemaining = new Dictionary<AsciiSprite, int>();

	private List<TravelSprite> travelSprites = new List<TravelSprite>();

	private int amountTotal;

	private int amountSpawned;

	private float elapsedTime;

	public void Clear()
	{
		if (spritesRemaining != null)
		{
			spritesRemaining.Clear();
			travelSprites.Clear();
		}
		amountTotal = 0;
		amountSpawned = 0;
		elapsedTime = 0f;
	}

	public void AddSprite(AsciiSprite sprite, int amount)
	{
		amountTotal += amount;
		if (spritesRemaining == null)
		{
			spritesRemaining = new Dictionary<AsciiSprite, int>();
			travelSprites = new List<TravelSprite>();
		}
		if (spritesRemaining.ContainsKey(sprite))
		{
			spritesRemaining[sprite] += amount;
		}
		else
		{
			spritesRemaining.Add(sprite, amount);
		}
	}

	public void Play()
	{
		base.enabled = true;
		elapsedTime = 0f;
	}

	public void Stop()
	{
		base.enabled = false;
	}

	private void Update()
	{
		elapsedTime += Time.deltaTime;
		for (int i = 0; i < travelSprites.Count; i++)
		{
			TravelSprite value = travelSprites[i];
			value.timeRemaining -= Time.deltaTime;
			travelSprites[i] = value;
		}
		if (amountSpawned < amountTotal)
		{
			float num = totalTime - travelTime;
			int num2 = Mathf.CeilToInt(elapsedTime * (float)amountTotal / num);
			while (amountSpawned < num2 && amountSpawned < amountTotal)
			{
				SpawnOne();
				amountSpawned++;
			}
		}
	}

	private void SpawnOne()
	{
		int num = Random.Range(0, amountTotal - amountSpawned);
		foreach (KeyValuePair<AsciiSprite, int> item2 in spritesRemaining)
		{
			AsciiSprite key = item2.Key;
			int value = item2.Value;
			if (num >= value)
			{
				num -= value;
				continue;
			}
			if (value == 1)
			{
				spritesRemaining.Remove(key);
			}
			else
			{
				spritesRemaining[key]--;
			}
			TravelSprite item = default(TravelSprite);
			item.sprite = key;
			float x = StartX + Random.Range(0f, StartWidth);
			float y = StartY + Random.Range(0f, StartHeight);
			item.start = new Vector2(x, y);
			x = EndX + Random.Range(0f, EndWidth);
			y = EndY + Random.Range(0f, EndHeight);
			item.end = new Vector2(x, y);
			item.endX = Mathf.RoundToInt(item.end.x);
			item.endY = Mathf.RoundToInt(item.end.y);
			item.timeRemaining = travelTime;
			travelSprites.Add(item);
			if (travelSprites.Count > maxSprites)
			{
				travelSprites.RemoveAt(0);
			}
			break;
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		for (int i = 0; i < travelSprites.Count; i++)
		{
			TravelSprite travelSprite = travelSprites[i];
			int num = offsetX;
			int num2 = offsetY;
			if (travelSprite.timeRemaining > 0f)
			{
				float t = 1f - travelSprite.timeRemaining / travelTime;
				Vector2 vector = Vector2.Lerp(travelSprite.start, travelSprite.end, t);
				num += Mathf.RoundToInt(vector.x);
				num2 += Mathf.RoundToInt(vector.y);
			}
			else
			{
				num += travelSprite.endX;
				num2 += travelSprite.endY;
			}
			travelSprite.sprite.Draw(r, num, num2);
		}
	}
}
