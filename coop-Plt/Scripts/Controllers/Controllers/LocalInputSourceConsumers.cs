using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
	public class LocalInputSourceConsumers : MonoBehaviour
	{
		private static List<IInputConsumer> _Consumers = new List<IInputConsumer>();

		private List<IInputConsumer> ConsumerList => _Consumers;

		public static List<IInputConsumer> Consumers
		{
			get
			{
				for (int num = _Consumers.Count - 1; num >= 0; num--)
				{
					IInputConsumer inputConsumer = _Consumers[num];
					if (inputConsumer == null)
					{
						_Consumers.RemoveAt(num);
					}
					if (inputConsumer is MonoBehaviour monoBehaviour && monoBehaviour == null)
					{
						_Consumers.RemoveAt(num);
					}
				}
				return _Consumers;
			}
		}

		public static void Register(IInputConsumer consumer, bool is_low_priority = false)
		{
			if (!_Consumers.Contains(consumer))
			{
				if (is_low_priority)
				{
					_Consumers.Insert(0, consumer);
				}
				else
				{
					_Consumers.Add(consumer);
				}
			}
		}

		public static void Remove(IInputConsumer consumer)
		{
			if (_Consumers.Contains(consumer))
			{
				_Consumers.Remove(consumer);
			}
		}
	}
}
