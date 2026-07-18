using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class BuildFinishComponent
{
	public TransformComponent transformComponent;

	public Vector3 targetVector;

	public float time;

	public bool append;

	public Ease easeMode;
}
