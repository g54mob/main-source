using System;
using System.Collections.Generic;
using Stonescript;
using Stonescript.Runtime;
using UnityEngine;

public class Neutral : Character
{
	public int ticsPerMove = 4;

	public AsciiSprite walkSprite;

	public AsciiSprite idleSprite;

	private Vector2Int? destination;

	public Action<Neutral> OnDestinationReached;

	private bool destinationReached;

	public bool immobile;

	private int stateElapsedTics;

	private IFunction destinationReachedCallbackMethod;

	private List<object> destinationReachedCallbackParameters;

	private void PlayAnimationIfAvailable(AsciiSprite sprite)
	{
		if (sprite != null)
		{
			AsciiAnimation component = sprite.GetComponent<AsciiAnimation>();
			if (component != null)
			{
				component.Play();
			}
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (GameStates.Singleton == null || GameStates.Singleton.hero == null)
		{
			return;
		}
		stateElapsedTics++;
		if (!immobile && destination.HasValue && stateElapsedTics >= ComputeTicsPerMove())
		{
			stateElapsedTics = 0;
			int x = destination.Value.x;
			int y = destination.Value.y;
			if (y < base.PositionZ)
			{
				base.PositionZ--;
			}
			else if (y > base.PositionZ)
			{
				base.PositionZ++;
			}
			if (x < base.PositionX)
			{
				base.PositionX--;
			}
			else if (x > base.PositionX)
			{
				base.PositionX++;
			}
			if (!destinationReached && base.PositionX == x && base.PositionZ == y)
			{
				destinationReached = true;
				OnDestinationReached?.Invoke(this);
			}
		}
	}

	private int ComputeTicsPerMove()
	{
		if (base.statModController != null)
		{
			return base.statModController.ModTicsPerMove(ticsPerMove);
		}
		return ticsPerMove;
	}

	private void DestinationReachedCallback(Neutral neutral)
	{
		base.MySprite = idleSprite;
		PlayAnimationIfAvailable(idleSprite);
		OnDestinationReached = (Action<Neutral>)Delegate.Remove(OnDestinationReached, new Action<Neutral>(DestinationReachedCallback));
		IFunction function = destinationReachedCallbackMethod;
		List<object> parameters = destinationReachedCallbackParameters;
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		function?.Invoke(parameters);
	}

	[StonescriptNativeMethod]
	public object SetDestination(List<object> parameters, InvocationContext ctx)
	{
		destination = new Vector2Int((int)parameters[0], (int)parameters[1]);
		destinationReached = false;
		OnDestinationReached = (Action<Neutral>)Delegate.Remove(OnDestinationReached, new Action<Neutral>(DestinationReachedCallback));
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		base.MySprite = walkSprite;
		PlayAnimationIfAvailable(walkSprite);
		if (parameters.Count >= 3)
		{
			if (!(parameters[2] is IFunction))
			{
				throw new RuntimeException(ctx, "SetDestination expects parameter 2 to be a function but it received something else.");
			}
			destinationReachedCallbackMethod = parameters[2] as IFunction;
			if (parameters.Count >= 4)
			{
				if (!(parameters[3] is StonescriptArray))
				{
					throw new StonescriptRuntimeException("Invalid parameter list for SetDestination callback.");
				}
				destinationReachedCallbackParameters = (parameters[3] as StonescriptArray).ToList<object>();
			}
			else
			{
				destinationReachedCallbackParameters = null;
			}
			OnDestinationReached = (Action<Neutral>)Delegate.Combine(OnDestinationReached, new Action<Neutral>(DestinationReachedCallback));
		}
		return null;
	}

	private void OnDestroy()
	{
		OnDestinationReached = (Action<Neutral>)Delegate.Remove(OnDestinationReached, new Action<Neutral>(DestinationReachedCallback));
	}

	[StonescriptNativeMethod]
	public object ClearDestination(List<object> parameters, InvocationContext ctx)
	{
		destination = null;
		OnDestinationReached = (Action<Neutral>)Delegate.Remove(OnDestinationReached, new Action<Neutral>(DestinationReachedCallback));
		destinationReachedCallbackMethod = null;
		destinationReachedCallbackParameters = null;
		return null;
	}

	[StonescriptNativeGetter("ticsPerMove")]
	public object GetTicksPerMove()
	{
		return ticsPerMove;
	}

	[StonescriptNativeSetter("ticsPerMove")]
	public void SetTicksPerMove(object value)
	{
		ticsPerMove = (int)value;
	}

	[StonescriptNativeGetter("walkSprite")]
	public object Property_GetWalkSprite()
	{
		return (walkSprite?.GetComponent<SSScriptableObject>())?.Target;
	}

	[StonescriptNativeSetter("walkSprite")]
	public void Property_SetWalkSprite(object value)
	{
		AsciiSprite component = (value as StonescriptObject).Scriptable.GetComponent<AsciiSprite>();
		walkSprite = component;
	}

	[StonescriptNativeGetter("idleSprite")]
	public object Property_GetIdleSprite()
	{
		return (idleSprite?.GetComponent<SSScriptableObject>())?.Target;
	}

	[StonescriptNativeSetter("idleSprite")]
	public void Property_SetIdleSprite(object value)
	{
		AsciiSprite component = (value as StonescriptObject).Scriptable.GetComponent<AsciiSprite>();
		idleSprite = component;
	}
}
