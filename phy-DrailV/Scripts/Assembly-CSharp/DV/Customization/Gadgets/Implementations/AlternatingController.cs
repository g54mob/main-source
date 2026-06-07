using System;
using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class AlternatingController : GadgetSwitch
	{
		private const string KEY_ORDER = "order";

		private float[] intervals = new float[5]
		{
			0f,
			1f,
			0.5f,
			0.25f,
			float.PositiveInfinity
		};

		private int selectedInterval;

		private int alternatorState;

		private float timer;

		private readonly List<GadgetBase> subscribers = new List<GadgetBase>();

		public int SelectedInterval
		{
			get
			{
				return selectedInterval;
			}
			set
			{
				value = Mathf.Clamp(value, 0, intervals.Length - 1);
				if (selectedInterval != value)
				{
					selectedInterval = value;
					SetOutputValue((intervals[selectedInterval] != 0f) ? 1 : 0);
					FireOnOutputValueUpdated();
				}
			}
		}

		public int IntervalCount => intervals.Length;

		protected override void Awake()
		{
			base.Awake();
		}

		private void Update()
		{
			float num = intervals[selectedInterval];
			if (!base.PowerState || num == 0f)
			{
				alternatorState = 0;
				timer = 0f;
			}
			else
			{
				if (float.IsInfinity(num))
				{
					return;
				}
				timer += Time.deltaTime;
				if (timer > num)
				{
					timer -= num;
					alternatorState++;
					if (alternatorState > 1 && alternatorState >= subscribers.Count)
					{
						alternatorState = 0;
					}
					FireOnOutputValueUpdated();
				}
			}
		}

		protected override void OnGadgetWired(GadgetBase subscriber)
		{
			base.OnGadgetWired(subscriber);
			subscribers.Add(subscriber);
		}

		protected override void OnGadgetUnwired(GadgetBase subscriber)
		{
			base.OnGadgetUnwired(subscriber);
			subscribers.Remove(subscriber);
		}

		public override float OutputValueOf(Customization.CustomizerBase customizer)
		{
			if (float.IsInfinity(intervals[selectedInterval]))
			{
				return base.DefaultOutputValue;
			}
			if (customizer != null && (alternatorState >= subscribers.Count || customizer != subscribers[alternatorState]))
			{
				return 0f;
			}
			if (!(intervals[selectedInterval] > 0f))
			{
				return 0f;
			}
			return base.DefaultOutputValue;
		}

		public override void SaveDataRequested(JObject dst)
		{
			base.SaveDataRequested(dst);
			dst.SetInt("value", selectedInterval);
			dst.SetIntArray("order", subscribers.Select((GadgetBase g) => g.UID).ToArray());
		}

		public override void SaveDataLoaded(JObject src)
		{
			SelectedInterval = src.GetInt("value") ?? 0;
			base.SaveDataLoaded(src);
			SetOutputValue(1f);
		}

		public override void AfterSaveDataLoaded(JObject src)
		{
			base.AfterSaveDataLoaded(src);
			int[] orderedUIDs = src.GetIntArray("order");
			if (orderedUIDs != null)
			{
				List<GadgetBase> collection = subscribers.OrderBy((GadgetBase g) => Array.IndexOf(orderedUIDs, g.UID)).ToList();
				subscribers.Clear();
				subscribers.AddRange(collection);
			}
		}
	}
}
