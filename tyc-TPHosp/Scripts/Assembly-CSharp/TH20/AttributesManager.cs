using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class AttributesManager
	{
		private const int MaxPerFrame = 10;

		private List<Attributes> _attributes = new List<Attributes>();

		private int _lastProcessed;

		public void Add(Attributes attributes)
		{
			_attributes.Add(attributes);
		}

		public void Remove(Attributes attributes)
		{
			_attributes.Remove(attributes);
		}

		public void Update()
		{
			if (Time.timeScale <= 0f)
			{
				return;
			}
			int num = _lastProcessed;
			int i = 0;
			int num2 = Mathf.Min(10, _attributes.Count);
			if (num >= _attributes.Count)
			{
				num = 0;
			}
			for (; i < num2; i++)
			{
				_attributes[num].Update();
				num++;
				if (num >= _attributes.Count)
				{
					num = 0;
				}
			}
			_lastProcessed = num;
		}
	}
}
