using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPAnimations;
using TMPEffects.TMPAnimations.Animations;

internal class AnimationDatabase<TDB, TScene> : ITMPEffectDatabase<ITMPAnimation>, ITMPEffectDatabase, INotifyObjectChanged, IDisposable where TDB : class, ITMPEffectDatabase<ITMPAnimation>, INotifyObjectChanged where TScene : TMPSceneAnimationBase
{
	private TDB database;

	private SerializedObservableDictionary<string, TScene> sceneAnimations;

	private Dictionary<string, ITMPAnimation> customAnimations;

	private bool disposed;

	public TDB Database => database;

	public SerializedObservableDictionary<string, TScene> SceneAnimations => sceneAnimations;

	public event ObjectChangedEventHandler ObjectChanged;

	public AnimationDatabase(TDB database, SerializedObservableDictionary<string, TScene> sceneAnimations)
	{
		this.database = database;
		this.sceneAnimations = sceneAnimations;
		customAnimations = new Dictionary<string, ITMPAnimation>();
		if (database != null)
		{
			database.ObjectChanged += RaiseObjectChanged;
		}
		if (sceneAnimations != null)
		{
			sceneAnimations.ObjectChanged += RaiseObjectChanged;
		}
	}

	public void AddAnimation(string key, ITMPAnimation animation)
	{
		if (customAnimations.ContainsKey(key))
		{
			throw new InvalidOperationException();
		}
		customAnimations[key] = animation;
		RaiseObjectChanged(this);
	}

	public void RemoveAnimation(string key)
	{
		customAnimations.Remove(key);
		RaiseObjectChanged(this);
	}

	private void RaiseObjectChanged(object sender)
	{
		this.ObjectChanged?.Invoke(this);
	}

	private void RaiseObjectChanged(object sender, PropertyChangedEventArgs args)
	{
		this.ObjectChanged?.Invoke(this);
	}

	public bool ContainsEffect(string name)
	{
		if (database != null && database.ContainsEffect(name))
		{
			return true;
		}
		if (sceneAnimations != null && sceneAnimations.ContainsKey(name) && sceneAnimations[name] != null)
		{
			return true;
		}
		return customAnimations.ContainsKey(name);
	}

	public ITMPAnimation GetEffect(string name)
	{
		if (database != null && database.ContainsEffect(name))
		{
			return database.GetEffect(name);
		}
		if (sceneAnimations != null && sceneAnimations.ContainsKey(name) && sceneAnimations[name] != null)
		{
			return sceneAnimations[name];
		}
		if (customAnimations.ContainsKey(name))
		{
			return customAnimations[name];
		}
		throw new KeyNotFoundException(name);
	}

	public void Dispose()
	{
		if (!disposed)
		{
			disposed = true;
			if (database != null)
			{
				database.ObjectChanged -= RaiseObjectChanged;
			}
			if (sceneAnimations != null)
			{
				sceneAnimations.ObjectChanged -= RaiseObjectChanged;
			}
			database = null;
			sceneAnimations = null;
			customAnimations = null;
			this.ObjectChanged = null;
		}
	}
}
