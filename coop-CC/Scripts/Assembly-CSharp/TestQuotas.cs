using System;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class TestQuotas : MonoBehaviour
{
	public struct Card
	{
		public bool isInBound;

		public int boxCount;
	}

	[Serializable]
	public struct Load
	{
		public int loadCount;

		public int cardCount;
	}

	public int quotaAmount;

	public int boxAmount;

	public Load[] inboundLoadCounts;

	public Load[] outboundLoadCounts;

	public int shiftDuration;

	public int shiftCount;

	public int truckArriveDuration;

	public int startingInventoryCount;

	public Vector2 chanceForOutbound = new Vector2(0.25f, 0.75f);

	public Vector2 inventoryPercentageCount = new Vector2(0.25f, 0.75f);

	private void RunTest()
	{
		int num = shiftDuration / truckArriveDuration * shiftCount;
		int num2 = Mathf.CeilToInt((float)quotaAmount / (float)boxAmount);
		Unity.Mathematics.Random random = MathUtil.GetRandom(UnityEngine.Random.Range(int.MinValue, int.MaxValue));
		Deck<int> deck = new Deck<int>(random.NextInt());
		for (int i = 0; i < inboundLoadCounts.Length; i++)
		{
			Load load = inboundLoadCounts[i];
			deck.AddCard(load.loadCount, load.cardCount);
		}
		Deck<int> deck2 = new Deck<int>(random.NextInt());
		int num3 = int.MaxValue;
		for (int j = 0; j < outboundLoadCounts.Length; j++)
		{
			Load load2 = outboundLoadCounts[j];
			deck2.AddCard(load2.loadCount, load2.cardCount);
			num3 = math.min(num3, load2.loadCount);
		}
		deck.Shuffle();
		deck2.Shuffle();
		int x = Mathf.CeilToInt(inventoryPercentageCount.x * (float)num2);
		x = math.max(x, num3);
		int num4 = Mathf.FloorToInt(inventoryPercentageCount.y * (float)num2);
		int x2 = num2 + x - startingInventoryCount;
		x2 = math.max(x2, 0);
		Deck<Card> deck3 = new Deck<Card>(random.NextInt());
		int num5 = x2;
		int num6 = 0;
		while (num5 > 0)
		{
			int num7 = deck.DrawCard();
			deck3.AddCard(new Card
			{
				isInBound = true,
				boxCount = num7
			});
			num5 -= num7;
			num6++;
		}
		int num8 = num2;
		int num9 = 0;
		while (num8 > 0)
		{
			int num10 = deck2.DrawCard();
			deck3.AddCard(new Card
			{
				isInBound = false,
				boxCount = num10
			});
			num8 -= num10;
			num9++;
		}
		deck3.Shuffle();
		if (num6 + num9 > num)
		{
			Debug.Log($"Not enough trucks in the quota! Total Trucks: {num} Needed: {num6 + num9}");
		}
		else
		{
			Debug.Log($"Inbound Trucks: {num6} Inbound Boxes: {x2} Outbound Trucks: {num9} Outbound Boxes: {num2} Extra trucks in quota: {num - (num6 + num9)}");
		}
		string text = "Results\n";
		int num11 = 0;
		try
		{
			while (deck3.cardCount != 0)
			{
				while (true)
				{
					Card card = deck3.DrawCard();
					if (num11 < x)
					{
						if (card.isInBound)
						{
							deck3.DestroyLastCard();
							num11 += card.boxCount;
							text += $"INBOUND - Load Count: {card.boxCount} Inventory Count: {num11}\n";
							break;
						}
						continue;
					}
					if (num11 > num4)
					{
						if (!card.isInBound)
						{
							deck3.DestroyLastCard();
							num11 -= card.boxCount;
							text += $"OUTBOUND - Load Count: {card.boxCount} Inventory Count: {num11}\n";
							break;
						}
						continue;
					}
					float num12 = random.NextFloat();
					float num13 = math.lerp(chanceForOutbound.x, chanceForOutbound.y, (float)(num11 - x) / (float)(num4 - x));
					if (num12 < num13)
					{
						if (!card.isInBound)
						{
							deck3.DestroyLastCard();
							num11 -= card.boxCount;
							text += $"OUTBOUND - Load Count: {card.boxCount} Inventory Count: {num11}\n";
							break;
						}
					}
					else if (card.isInBound)
					{
						deck3.DestroyLastCard();
						num11 += card.boxCount;
						text += $"INBOUND - Load Count: {card.boxCount} Inventory Count: {num11}\n";
						break;
					}
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		Debug.Log(text);
	}
}
