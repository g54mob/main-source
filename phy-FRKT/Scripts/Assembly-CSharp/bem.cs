using System;
using Infrastructure.Scenes.Sandbox.Services.Creatures;
using UnityEngine;

public interface bem
{
	bool sty { get; }

	void iny(Action<float> a, float b);

	void inz(Action<CollisionCachedData> a, Collision b);
}
