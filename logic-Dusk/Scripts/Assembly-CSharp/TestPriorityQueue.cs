using UnityEngine;

public static class TestPriorityQueue
{
	public class Cat
	{
		public string Name { get; set; }
	}

	public static void TestIt()
	{
		PriorityQueue<Cat, float> priorityQueue = new PriorityQueue<Cat, float>();
		Cat cat = new Cat();
		cat.Name = "spot";
		Cat item = cat;
		cat = new Cat();
		cat.Name = "garfield";
		Cat item2 = cat;
		cat = new Cat();
		cat.Name = "mittens";
		Cat item3 = cat;
		cat = new Cat();
		cat.Name = "tigra";
		Cat item4 = cat;
		cat = new Cat();
		cat.Name = "killer";
		Cat item5 = cat;
		cat = new Cat();
		cat.Name = "fatCat";
		Cat item6 = cat;
		priorityQueue.Enqueue(item, 1.2f);
		priorityQueue.Enqueue(item2, 1.7f);
		priorityQueue.Enqueue(item3, 4.567f);
		priorityQueue.Enqueue(item4, 0.3f);
		priorityQueue.Enqueue(item6, 1f);
		priorityQueue.Enqueue(item5, 0.5f);
		priorityQueue.UpdatePriority(item, 2014.05f);
		priorityQueue.UpdatePriority(item4, 4.567f);
		priorityQueue.UpdatePriority(item2, 0.9f);
		string text = "Testing priority queue: ";
		while (!priorityQueue.IsEmpty())
		{
			Cat cat2 = priorityQueue.Dequeue();
			text = text + cat2.Name + ", ";
		}
		Debug.Log(text);
	}
}
