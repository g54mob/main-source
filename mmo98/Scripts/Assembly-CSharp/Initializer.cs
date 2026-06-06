using System;
using System.Collections.Generic;
using MessagePipe;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Initializer
{
	public static StatelessInitializerContext Assign<TValue>(TValue origin, out TValue target)
	{
		return StatelessInitializerContext.Cached.Assign(origin, out target);
	}

	public static StatelessInitializerContext Each<TValue>(IEnumerable<TValue> values, Action<TValue> callback)
	{
		return StatelessInitializerContext.Cached.Each(values, callback);
	}

	public static StatelessInitializerContext Invoke(Action callback)
	{
		return StatelessInitializerContext.Cached.Invoke(callback);
	}

	public static StatelessInitializerContext Bag(out DisposableBagBuilder bag)
	{
		return StatelessInitializerContext.Cached.Bag(out bag);
	}

	public static BehaviourInitializerContext Context(Behaviour target)
	{
		return InitializerContext<Behaviour>.GetContext<BehaviourInitializerContext>(target);
	}

	public static GameObjectInitializerContext Context(GameObject target)
	{
		return InitializerContext<GameObject>.GetContext<GameObjectInitializerContext>(target);
	}

	public static ButtonInitializerContext Context(Button target)
	{
		return InitializerContext<Button>.GetContext<ButtonInitializerContext>(target);
	}

	public static ImageInitializerContext Context(Image target)
	{
		return InitializerContext<Image>.GetContext<ImageInitializerContext>(target);
	}

	public static TextInitializerContext Context(TMP_Text target)
	{
		return InitializerContext<TMP_Text>.GetContext<TextInitializerContext>(target);
	}

	public static InputFieldInitializerContext Context(TMP_InputField target)
	{
		return InitializerContext<TMP_InputField>.GetContext<InputFieldInitializerContext>(target);
	}

	public static SliderInitializerContext Context(Slider target)
	{
		return InitializerContext<Slider>.GetContext<SliderInitializerContext>(target);
	}

	public static ToggleInitializerContext Context(Toggle target)
	{
		return InitializerContext<Toggle>.GetContext<ToggleInitializerContext>(target);
	}

	public static ScrollRectInitializerContext Context(ScrollRect target)
	{
		return InitializerContext<ScrollRect>.GetContext<ScrollRectInitializerContext>(target);
	}

	public static LocalizeStringHandlerContext Context(LocalizeStringHandler target)
	{
		return InitializerContext<LocalizeStringHandler>.GetContext<LocalizeStringHandlerContext>(target);
	}
}
