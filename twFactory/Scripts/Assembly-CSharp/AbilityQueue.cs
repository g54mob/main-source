using System.Collections.Generic;

public class AbilityQueue
{
	public delegate void OnQueueChanged(QueuedAbility changedQueuedAbility, int position);

	private List<QueuedAbility> queue;

	private int maxQueueSize = -1;

	public List<QueuedAbility> Queue => queue;

	public int MaxQueueSize
	{
		get
		{
			return maxQueueSize;
		}
		set
		{
			maxQueueSize = value;
			if (queue.Count >= maxQueueSize)
			{
				for (int num = queue.Count - 1; num >= maxQueueSize; num--)
				{
					RemoveAbilityAtPosition(num);
				}
			}
		}
	}

	public event OnQueueChanged onAbilityQueued;

	public event OnQueueChanged onAbilityDequeued;

	public AbilityQueue()
	{
		queue = new List<QueuedAbility>();
	}

	public bool IsFull()
	{
		if (maxQueueSize != -1)
		{
			return queue.Count >= maxQueueSize;
		}
		return false;
	}

	public bool AddAbility(QueuedAbility qAbility)
	{
		if (qAbility.ability.CanQueue() && maxQueueSize != 0)
		{
			if (IsFull())
			{
				RemoveAbilityAtPosition(queue.Count - 1);
			}
			Queue.Add(qAbility);
			qAbility.ability.OnQueue();
			this.onAbilityQueued?.Invoke(qAbility, queue.Count - 1);
			return true;
		}
		return false;
	}

	public bool AddAbilityAtPosition(QueuedAbility qAbility, int position)
	{
		if (qAbility.ability.CanQueue() && maxQueueSize != 0)
		{
			if (IsFull())
			{
				RemoveAbilityAtPosition(queue.Count - 1);
			}
			Queue.Insert(position, qAbility);
			qAbility.ability.OnQueue();
			this.onAbilityQueued?.Invoke(qAbility, position);
			return true;
		}
		return false;
	}

	public bool RemoveAbilityAtPosition(int position)
	{
		if (position >= 0 && position < queue.Count)
		{
			QueuedAbility changedQueuedAbility = queue[position];
			changedQueuedAbility.ability.OnDequeue();
			Queue.RemoveAt(position);
			this.onAbilityDequeued?.Invoke(changedQueuedAbility, position);
			return true;
		}
		return false;
	}

	public void RemoveAbility(Ability ability)
	{
		for (int num = queue.Count - 1; num >= 0; num--)
		{
			if (queue[num].ability.gameObject == ability.gameObject)
			{
				RemoveAbilityAtPosition(num);
			}
		}
	}

	public QueuedAbility ConsumeAbility()
	{
		QueuedAbility queuedAbility = Queue[0];
		Queue.RemoveAt(0);
		this.onAbilityDequeued?.Invoke(queuedAbility, 0);
		return queuedAbility;
	}

	public void EmptyQueue()
	{
		for (int i = 0; i < queue.Count; i++)
		{
			queue[i].ability.OnDequeue();
			this.onAbilityDequeued?.Invoke(queue[i], i);
		}
		queue.Clear();
	}

	public List<Ability> GetAbilities()
	{
		List<Ability> list = new List<Ability>();
		foreach (QueuedAbility item in queue)
		{
			list.Add(item.ability);
		}
		return list;
	}

	public bool IsEmpty()
	{
		return queue.Count <= 0;
	}
}
