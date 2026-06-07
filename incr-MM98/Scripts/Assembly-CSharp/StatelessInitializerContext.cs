using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MessagePipe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatelessInitializerContext : IInitializerContext
{
	public static StatelessInitializerContext Cached = new StatelessInitializerContext();

	public BehaviourInitializerContext Context(MonoBehaviour target)
	{
		return Initializer.Context(target);
	}

	public GameObjectInitializerContext Context(GameObject target)
	{
		return Initializer.Context(target);
	}

	public ImageInitializerContext Context(Image target)
	{
		return Initializer.Context(target);
	}

	public ButtonInitializerContext Context(Button target)
	{
		return Initializer.Context(target);
	}

	public TextInitializerContext Context(TMP_Text target)
	{
		return Initializer.Context(target);
	}

	public InputFieldInitializerContext Context(TMP_InputField target)
	{
		return Initializer.Context(target);
	}

	public SliderInitializerContext Context(Slider target)
	{
		return Initializer.Context(target);
	}

	public ToggleInitializerContext Context(Toggle target)
	{
		return Initializer.Context(target);
	}

	public ScrollRectInitializerContext Context(ScrollRect target)
	{
		return Initializer.Context(target);
	}

	public LocalizeStringHandlerContext Context(LocalizeStringHandler target)
	{
		return Initializer.Context(target);
	}

	public StatelessInitializerContext Assign<TValue>(TValue origin, out TValue target)
	{
		target = origin;
		return this;
	}

	public StatelessInitializerContext Each<TValue>(IEnumerable<TValue> values, Action<TValue> callback)
	{
		values.Each(callback);
		return this;
	}

	public StatelessInitializerContext Invoke(Action callback)
	{
		callback();
		return this;
	}

	public StatelessInitializerContext Bag(out DisposableBagBuilder bag)
	{
		bag = DisposableBag.CreateBuilder();
		return this;
	}

	[MustDisposeResource]
	public EventHubBuilder SceneEvents(int initialCapacity = 4)
	{
		return EventHub.Scene.For(initialCapacity);
	}

	[MustDisposeResource]
	public EventHubBuilder SceneEvents(DisposableBagBuilder bag)
	{
		return EventHub.Scene.For(bag);
	}
}
