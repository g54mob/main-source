using System;
using Assets.Source.Ability;
using Assets.Source.World;
using LightJson;
using UnityEngine;

namespace Assets.Source.Buff
{
	public abstract class FrameBuff : IJsonSource
	{
		public string Identifier => GetType().Name;

		public ActivatedAbility Ability { get; private set; }

		public float TimeLeft { get; private set; }

		public float CurrentDuration { get; private set; }

		public float Progress => TimeLeft / CurrentDuration;

		public abstract Color WorldColor { get; }

		public abstract float BaseDuration { get; }

		public abstract bool IsValidTarget(WorldFrame frame);

		public abstract bool CanCoexistWith(FrameBuff other);

		public virtual bool AddStack(FrameBuff other)
		{
			return false;
		}

		public virtual double GetSpeedMultiplier(WorldFrame frame, bool handCraft)
		{
			return 1.0;
		}

		public virtual double GetProductivityMultiplier(WorldFrame frame, bool handCraft)
		{
			return 1.0;
		}

		public virtual double GetParallelMultiplier(WorldFrame frame, bool handCraft)
		{
			return 1.0;
		}

		public FrameBuff()
		{
		}

		public FrameBuff(ActivatedAbility a)
		{
			Ability = a;
		}

		public void AddDuration(float duration, bool refresh = false)
		{
			TimeLeft += duration;
			if (refresh)
			{
				CurrentDuration = TimeLeft;
			}
			else
			{
				CurrentDuration = duration;
			}
		}

		public virtual bool Update(WorldFrame frame, float delta)
		{
			TimeLeft -= delta;
			return TimeLeft <= 0f;
		}

		public virtual void DataFromJson(JsonObject data)
		{
			TimeLeft = (float)data["TimeLeft"].AsNumber;
			CurrentDuration = (float)data["CurrentDuration"].AsNumber;
			if (data["Ability"].IsString)
			{
				Ability = ActivatedAbility.Get(data["Ability"]);
			}
		}

		public virtual JsonValue ToJson()
		{
			return new JsonObject
			{
				{ "Identifier", Identifier },
				{
					"Ability",
					Ability?.Identifier ?? ((string)JsonValue.Null)
				},
				{ "TimeLeft", TimeLeft },
				{ "CurrentDuration", CurrentDuration }
			};
		}

		public static FrameBuff FromJson(JsonValue data)
		{
			FrameBuff frameBuff = Create(data["Identifier"]);
			frameBuff.DataFromJson(data);
			return frameBuff;
		}

		public static FrameBuff Create(string id)
		{
			return (FrameBuff)Type.GetType("Assets.Source.Buff." + id).GetConstructor(new Type[0]).Invoke(new object[0]);
		}
	}
}
