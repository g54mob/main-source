using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

	public TDB Database => null;

	public SerializedObservableDictionary<string, TScene> SceneAnimations => null;

	public event ObjectChangedEventHandler ObjectChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public AnimationDatabase(TDB database, SerializedObservableDictionary<string, TScene> sceneAnimations)
	{
	}

	public void AddAnimation(string key, ITMPAnimation animation)
	{
	}

	public void RemoveAnimation(string key)
	{
	}

	private void RaiseObjectChanged(object sender)
	{
	}

	private void RaiseObjectChanged(object sender, PropertyChangedEventArgs args)
	{
	}

	public bool ContainsEffect(string name)
	{
		return false;
	}

	public ITMPAnimation GetEffect(string name)
	{
		return null;
	}

	public void Dispose()
	{
	}
}
