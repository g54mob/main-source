using System;
using Unity.Mathematics;

[Serializable]
public class ArcadeWorldConfig
{
	public int _fps;

	public bool _fixedStep;

	public double _timeScale;

	public float2 _gravity;

	public ArcadeBodyBounds _bounds;

	public CheckCollisionObject _checkCollision;

	public double _overlapBias;

	public double _tileBias;

	public bool _forceX;

	public bool _isPaused;

	public bool _debugShowRTrees;

	public bool _debugShowBody;

	public bool _debugShowStaticBody;

	public bool _debugShowVelocity;

	public int _debugBodyColor;

	public int _debugStaticBodyColor;

	public int _debugVelocityColor;

	public int _maxEntries;

	public bool _useTree;

	public bool _customUpdate;

	[NonSerialized]
	public const float _globalScale = 0.01f;
}
