using System;

namespace Assets.Nimbatus.Scripts.Behaviours.CoreBehaviours
{
	public class CounterBehaviour : CoreBehaviour
	{
		private int _count;

		public int StartCount;

		public event Action OnCountChanged;

		protected override void OnInit()
		{
			_count = StartCount;
		}

		protected override void OnRelease()
		{
		}

		public void SetCount(int count)
		{
			_count = count;
			Action action = this.OnCountChanged;
			if (action != null)
			{
				action();
			}
		}

		public void IncreaseCount(int amount)
		{
			_count += amount;
			Action action = this.OnCountChanged;
			if (action != null)
			{
				action();
			}
		}

		public void DecreaseCount(int amount)
		{
			_count -= amount;
			Action action = this.OnCountChanged;
			if (action != null)
			{
				action();
			}
		}

		public int GetCount()
		{
			return _count;
		}
	}
}
